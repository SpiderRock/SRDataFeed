using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream.Mbus;

internal sealed class JumboFrame : IDisposable
{
    const int MaxPacketSize = 1400;

    /* corresponds to SRMsgBase.Header field values:
            sysEnvironment = 0x00 (None), 
            messageType = 0x0000 (None), 
            bits = 0xFF (All ON which makes no sense) */
    const uint JumboMessage = 0xFF000000;

    static readonly int FragmentsBufferLength = (int)(Unsafe.SizeOf<Fragment>() * Math.Ceiling((double)Header.MaxMessageLength / Fragment.MaxPayloadLength));

    readonly string channel;
    IMemoryOwner<byte> buffer;
    int pid;
    int appId;
    int id;
    int count;

    public JumboFrame(string channel)
    {
        if (string.IsNullOrWhiteSpace(channel))
        {
            throw new ArgumentException($"'{nameof(channel)}' cannot be null or whitespace.", nameof(channel));
        }

        buffer = MemoryPool<byte>.Shared.Rent(FragmentsBufferLength);
        this.channel = channel;
    }

    ~JumboFrame()
    {
        buffer?.Dispose();
    }

    public void Dispose()
    {
        Interlocked.Exchange(ref buffer, null)?.Dispose();
        GC.SuppressFinalize(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPartOf(ref Frame frame) => MemoryMarshal.AsRef<Fragment.Header>(frame.Payload).type == JumboMessage;

    public static bool TryComplete(ref Frame frame)
    {
        var header = MemoryMarshal.AsRef<Fragment.Header>(frame.Payload);
        var jumboFrame = frame.Context.GetJumboFrame(header.appID);

        if (jumboFrame.TryComplete(frame.Payload, out var fullFrame))
        {
            frame.Payload = fullFrame;
            return true;
        }

        return false;
    }

    private bool TryComplete(ReadOnlySpan<byte> frameFragment, out ReadOnlySpan<byte> fullFrame)
    {
        var header = MemoryMarshal.Read<Fragment.Header>(frameFragment);

        var fragments = buffer.Memory.Span;
        var payload = frameFragment[Unsafe.SizeOf<Fragment.Header>()..];

        if (header.index + 1 == header.count)
        {
            if (--count == 0)
            {
                // dispatch

                int msgLength = header.index * Fragment.MaxPayloadLength + payload.Length;

                payload.CopyTo(fragments[(Unsafe.SizeOf<Fragment>() * header.index)..]);

                fullFrame = buffer.Memory.Span[..msgLength];
                return true;
            }
            else
            {
                SRTrace.Net.JumboFrames.TraceError($"Received out-of-order fragment from app ID {appId} on channel {channel} [expected={{{GetStateSnapshot()}}}, fromHeader={{{GetStateSnapshot(ref header)}}}]");
            }
        }
        else if (frameFragment.Length == Unsafe.SizeOf<Fragment>())
        {
            // append

            if (header.index == 0)
            {
                appId = header.appID;
                pid = header.pid;
                id = header.id;
                count = header.count - 1;

                payload.CopyTo(fragments);
            }
            else if (header.pid == pid && header.id == id)
            {
                count -= 1;

                payload.CopyTo(fragments[(Unsafe.SizeOf<Fragment>() * header.index)..]);
            }
            else
            {
                SRTrace.Net.JumboFrames.TraceError($"Received mismatched PID/message ID from app ID {appId} on channel {channel} [expected={{{GetStateSnapshot()}}}, fromHeader={{{GetStateSnapshot(ref header)}}}]");
            }
        }
        else
        {
            SRTrace.Net.JumboFrames.TraceError($"Received tail fragment with unexpected index/count from app ID {appId} on channel {channel} [expected={{{GetStateSnapshot()}}}, fromHeader={{{GetStateSnapshot(ref header)}}}]");
        }

        fullFrame = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string GetStateSnapshot() => $"{nameof(channel)}={channel}, {nameof(appId)}={appId}, {nameof(pid)}={pid}, {nameof(id)}={id}, {nameof(count)}={count}";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string GetStateSnapshot(ref Fragment.Header header) => $"{nameof(header.appID)}={header.appID}, {nameof(header.pid)}={header.pid}, {nameof(header.id)}={header.id}, {nameof(header.index)}={header.index}, {nameof(header.count)}={header.count}, {nameof(header.type)}={header.type}";

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = MaxPacketSize)]
    private unsafe struct Fragment
    {
        public const int MaxPayloadLength = MaxPacketSize - 16;

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
        public struct Header
        {
            public uint type;
            public SourceId appID;
            public int pid;
            public int id;
            public byte index;
            public byte count;
        }

        public Header header;

        public fixed byte payload[MaxPayloadLength];
    }
}
