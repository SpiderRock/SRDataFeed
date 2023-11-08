using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.MLink;

internal class FrameHandler<TMessageHandler> : IFrameHandler
    where TMessageHandler : IFrameHandler
{
    private readonly TMessageHandler messageHandler;
    private readonly MLinkStreamCheckPt mLinkStreamCheckPt = new();

    public FrameHandler(TMessageHandler messageHandler)
    {
        this.messageHandler = messageHandler;
    }

    public MLinkStreamState State { get; private set; }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public bool TryHandle(ref Frame frame)
    {
        var payload = frame.Payload;

        while (payload.Length > 0)
        {
            var header = MemoryMarshal.Read<Header>(payload);

            int messageLength = header.MessageLength;
            MessageType messageType = header.MessageType;

            if (messageLength > payload.Length)
            {
                throw new IOException("Incomplete frame detected");
            }

            if (header.Proto != Header.Protocol.Binary)
            {
                throw new IOException($"Invalid message format {header.Proto}");
            }

            payload = payload[Unsafe.SizeOf<Header>()..];

            if (messageType != MessageType.MLinkStreamCheckPt)
            {
                Frame childFrame = new(payload[..messageLength], frame.NetTimestamp, frame.Context, frame.FromCache);

                messageHandler.TryHandle(ref childFrame);
            }
            else
            {
                Formatter.Default.Decode(payload[..messageLength], mLinkStreamCheckPt);

                State = mLinkStreamCheckPt.State;
            }

            payload = payload[messageLength..];
        }

        return true;
    }
}
