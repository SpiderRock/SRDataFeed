using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.OSSockets;

internal sealed class UdpChannel<TFrameHandler> : IDisposable, IEquatable<UdpChannel<TFrameHandler>>, IEquatable<IPEndPoint>
    where TFrameHandler : IFrameHandler
{
    private static readonly long NanosecondsUpToUnixEpoch = DateTime.UnixEpoch.Ticks * 100;

    private static readonly double Frequency = Stopwatch.Frequency;
    private readonly byte[] buffer = GC.AllocateArray<byte>(ushort.MaxValue * 2, true);

    private readonly UdpDevice<TFrameHandler> device;
    private readonly TFrameHandler frameHandler;

    private readonly IPEndPoint groupEndPoint;
    private readonly IPEndPoint localEndPoint;
    private readonly int receiveBufferSize;
    private readonly IPEndPoint remoteEndPoint = new(IPAddress.Loopback, 0);

    private UdpClient client;
    private long handlerBegin;
    private long handlerEnd = Stopwatch.GetTimestamp();

    public UdpChannel(UdpDevice<TFrameHandler> device, IPEndPoint groupEndPoint, Channel recvChannel, int receiveBufferSize, TFrameHandler frameHandler)
    {
        this.device = device ?? throw new ArgumentNullException(nameof(device));
        this.frameHandler = frameHandler ?? throw new ArgumentNullException(nameof(frameHandler));
        this.groupEndPoint = groupEndPoint ?? throw new ArgumentNullException(nameof(groupEndPoint));

        this.receiveBufferSize = receiveBufferSize;

        RecvChannel = recvChannel ?? throw new ArgumentNullException(nameof(recvChannel));

        localEndPoint = new IPEndPoint(device.IFAddress, groupEndPoint.Port);
    }

    public Channel RecvChannel { get; }

    public long NumParseErrors { get; private set; }
    public long NumZeroLengthRecv { get; private set; }

    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    public bool Equals(IPEndPoint other) => groupEndPoint.Equals(other);

    public bool Equals(UdpChannel<TFrameHandler> other) => Equals(other?.groupEndPoint);

    public override bool Equals(object obj) => obj is UdpChannel<TFrameHandler> channel && Equals(channel);

    public override int GetHashCode() => groupEndPoint.GetHashCode();

    public override string ToString() => groupEndPoint.ToString();

    public void Join()
    {
        if (client != null) return;

        client = new UdpClient
        {
            ExclusiveAddressUse = false,
            Client =
            {
                Blocking = false,
                ReceiveBufferSize = receiveBufferSize
            }
        };

        client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        client.Client.Bind(localEndPoint);
        client.JoinMulticastGroup(groupEndPoint.Address, localEndPoint.Address);

        SRTrace.Net.UDP.Sockets.TraceInformation($"UdpDevice [{device.Handle}]: joined multicast channel [groupAddr={groupEndPoint.Address}, localEndPoint={localEndPoint}]");
    }

    ~UdpChannel()
    {
        Close();
    }

    public void Close()
    {
        if (client == null) return;

        try
        {
            client.DropMulticastGroup(groupEndPoint.Address);
            client.Close();
        }
        catch (Exception e)
        {
            SRTrace.Net.UDP.Sockets.TraceError(e, $"{nameof(UdpChannel<TFrameHandler>)}.{nameof(Close)}() failure");
        }

        SRTrace.Net.UDP.Sockets.TraceInformation($"UdpDevice [{device.Handle}]: left multicast channel [groupAddr={groupEndPoint.Address}, localEndPoint={localEndPoint}]");

        client = null;
    }

    public bool Handle()
    {
        if (client.Available == 0)
        {
            NumZeroLengthRecv += 1;
            return false;
        }

        EndPoint remoteEndPointRef = remoteEndPoint;
        var recvLength = client.Client.ReceiveFrom(buffer, ushort.MaxValue, SocketFlags.None, ref remoteEndPointRef);
        RecvChannel.RemoteEp = remoteEndPoint;

        handlerBegin = Stopwatch.GetTimestamp();

        var asyncElapsedTicks = handlerBegin - handlerEnd;

        var netTimestamp = unchecked(DateTime.UtcNow.Ticks * 100 - NanosecondsUpToUnixEpoch);

        ReadOnlySpan<byte> payload = buffer;

        Frame frame = new(payload[..recvLength], unchecked(DateTime.UtcNow.Ticks * 100 - NanosecondsUpToUnixEpoch), default, false);

        try
        {
            if (frameHandler.TryHandle(ref frame))
            {
                RecvChannel.IncrementTimeCounters(asyncElapsedTicks, handlerEnd - handlerBegin, recvLength >= 1000);
            }
        }
        catch (Exception e)
        {
            NumParseErrors++;
            SRTrace.Net.UDP.Sockets.TraceError(e, $"{nameof(UdpChannel<TFrameHandler>)}.{nameof(Handle)}() failure");
        }

        handlerEnd = Stopwatch.GetTimestamp();

        return true;
    }
}
