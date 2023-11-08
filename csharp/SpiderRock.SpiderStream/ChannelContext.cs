using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

internal class ChannelContext
{
    readonly CompactArray16<CompactArray16<byte>> seqNumbers = new();

    readonly CompactArray16<JumboFrame> jumboFrames = new();

    public ChannelContext(Channel channel)
    {
        Channel = channel ?? throw new ArgumentNullException(nameof(channel));
    }

    public Channel Channel { get; }

    public JumboFrame Packetizer { get; set; }

    public long LastHandlerExitTimestamp { get; set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public JumboFrame GetJumboFrame(SourceId sourceId)
    {
        try
        {
            return jumboFrames[sourceId] ?? throw null;
        }
        catch (NullReferenceException)
        {
            JumboFrame jumboFrame = new(Channel.Name);
            jumboFrames[sourceId] = jumboFrame;
            return jumboFrame;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref byte GetExpectedSequenceNumber(MessageType messageType, SourceId sourceId) => ref seqNumbers[messageType][sourceId];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(ChannelContext value) => GCHandle.ToIntPtr(GCHandle.Alloc(value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ChannelContext(IntPtr value) => GCHandle.FromIntPtr(value).Target as ChannelContext;
}
