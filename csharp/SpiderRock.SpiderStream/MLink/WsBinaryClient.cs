using System;
using System.Buffers;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.MLink;

internal sealed class WsBinaryClient<TFrameHandler>
    where TFrameHandler : IFrameHandler
{
    readonly string queryLabel;
    readonly FrameHandler<TFrameHandler> frameHandler;

    public unsafe WsBinaryClient(SysEnvironment environment, SysRealm realm, MessageType[] messageTypes, TFrameHandler frameHandler, string queryLabel, string authToken)
    {
        if (messageTypes is null)
        {
            throw new ArgumentNullException(nameof(messageTypes));
        }

        if (messageTypes.Length == 0)
        {
            throw new ArgumentException("Argumnet cannot be empty.", nameof(messageTypes));
        }

        if (string.IsNullOrWhiteSpace(queryLabel))
        {
            throw new ArgumentException("Argument cannot be null or whitespace.", nameof(queryLabel));
        }

        if (string.IsNullOrWhiteSpace(authToken))
        {
            throw new ArgumentException("Argument cannot be null or whitespace.", nameof(authToken));
        }

        Environment = environment;
        Realm = realm;
        MessageTypes = messageTypes;
        ApiKey = authToken;

        this.frameHandler = new(frameHandler);
        this.queryLabel = queryLabel;
    }

    public SysEnvironment Environment { get; }

    public SysRealm Realm { get; }

    public MessageType[] MessageTypes { get; }

    public string ApiKey { get; }

    public Uri MLinkEndPoint { get; init; } = new("wss://mlink.spiderrockconnect.com/mlink/binary", UriKind.Absolute);

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Channel sendChannel = new(ChannelType.WssSend, "mlink.req", MLinkEndPoint.Host);
        Channel recvChannel = new(ChannelType.WssRecv, "mlink.req", MLinkEndPoint.Host);

        using NetStatisticsAggregator netStats = new("cache request");
        netStats.Register(sendChannel);
        netStats.Register(recvChannel);

        Stopwatch stopwatch = new();

        try
        {
            using var webSocket = new ClientWebSocket();

            await SendRequest(webSocket, sendChannel, cancellationToken);

            stopwatch.Start();

            await ReceiveResponse(webSocket, recvChannel, cancellationToken);
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception e)
        {
            SRTrace.Net.MLink.TraceError(e, $"{ToString()}: {nameof(ExecuteAsync)} exception");
            throw;
        }
        finally
        {
            netStats.Flush(stopwatch.Elapsed.TotalSeconds);

            sendChannel.Close();
            recvChannel.Close();

            SRTrace.Net.MLink.TraceInfo($"{ToString()}: {nameof(ExecuteAsync)} exited");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    private async Task ReceiveResponse(ClientWebSocket webSocket, Channel recvChannel, CancellationToken cancellationToken)
    {
        SRTrace.Net.MLink.TraceInfo($"{ToString()}: receiving");

        using var memoryRental = MemoryPool<byte>.Shared.Rent(ushort.MaxValue * 2);

        var memory = memoryRental.Memory;

        int bytesReceived = 0;
        var nanosUpToUnixEpoch = DateTime.UnixEpoch.Ticks * 100;
        var frameHandlerState = frameHandler.State;
        var buffer = memory;
        var ctx = new ChannelContext(recvChannel);

        while (webSocket.State == WebSocketState.Open &&
            !cancellationToken.IsCancellationRequested &&
            frameHandlerState != MLinkStreamState.Complete &&
            frameHandlerState != MLinkStreamState.Terminated)
        {
            var receiveResult = await webSocket.ReceiveAsync(buffer, cancellationToken);

            bytesReceived += receiveResult.Count;

            if (receiveResult.MessageType == WebSocketMessageType.Close)
            {
                SRTrace.Net.MLink.TraceInfo($"{ToString()}: wss connection closed");
                break;
            }

            if (receiveResult.Count == 0)
            {
                SRTrace.Net.MLink.TraceInfo($"{ToString()}: zero bytes received from server");
                break;
            }

            if (receiveResult.EndOfMessage)
            {
                buffer = memory;
            }
            else
            {
                buffer = buffer[receiveResult.Count..];
                continue;
            }

            try
            {
                _ = TryHandle(buffer[..bytesReceived], unchecked(DateTime.UtcNow.Ticks * 100 - nanosUpToUnixEpoch), ctx);

                if (frameHandler.State != frameHandlerState)
                {
                    frameHandlerState = frameHandler.State;
                    SRTrace.Net.MLink.TraceInfo($"{ToString()}: state changed to {frameHandlerState}");
                }
            }
            catch (Exception ex)
            {
                SRTrace.Net.MLink.TraceError(ex, $"{ToString()}: {nameof(ExecuteAsync)} message handling exception");
            }

            bytesReceived = 0;
        }
    }

    private async Task SendRequest(ClientWebSocket webSocket, Channel sendChannel, CancellationToken cancellationToken)
    {
        SRTrace.Net.MLink.TraceInfo($"{ToString()}: connecting");

        // we expect the initiation of the connection and the request to succeed
        // rather quickly, much quicker than the full 15 seconds we are allocating
        using var memoryRental = MemoryPool<byte>.Shared.Rent(ushort.MaxValue);
        Memory<byte> memory = memoryRental.Memory;

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));

        webSocket.Options.SetRequestHeader("Authorization", $"Bearer {ApiKey}");
        await webSocket.ConnectAsync(MLinkEndPoint, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cts.Token).Token);

        var formatter = new Formatter();

        var mLinkCacheRequest = new MLinkCacheRequest()
        {
            header = { log = { origin = new(Environment, Realm) } },
            QueryLabel = queryLabel,
            MsgTypeList = MessageTypes.Select(messageType => new MLinkCacheRequest.MsgTypeItem((ushort)messageType, (long)messageType.SchemaHash)).ToArray()
        };

        var messageLength = formatter.Encode(memory[Unsafe.SizeOf<Header>()..].Span, mLinkCacheRequest);

        Header mLinkBinaryHeader = new()
        {
            MessageType = MessageType.MLinkCacheRequest,
            MessageLength = (ushort)messageLength
        };

        MemoryMarshal.Write(memory.Span, ref mLinkBinaryHeader);

        SRTrace.Net.MLink.TraceInfo($"{ToString()}: sending request");

        await webSocket.SendAsync(memory[..(Unsafe.SizeOf<Header>() + messageLength)], WebSocketMessageType.Binary, true, cancellationToken);

        sendChannel.IncrementMsgCount(MessageType.MLinkCacheRequest, messageLength);
    }

    /// <remarks>Async pattern doesn't allow for ref structs, hence, the rationale for the existence of this seemingly unnecessary method</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryHandle(Memory<byte> buffer, long netTimestamp, ChannelContext context)
    {
        Frame frame = new(buffer.Span, netTimestamp, context, true);

        return frameHandler.TryHandle(ref frame);
    }

    public override string ToString() => $"{nameof(WsBinaryClient<TFrameHandler>)}[{MLinkEndPoint}]";
}
