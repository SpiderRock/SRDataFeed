using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream.Mbus;

internal partial class FrameHandler<TMessageHandler> : IFrameHandler
    where TMessageHandler : IFrameHandler
{
    static readonly int SizeOfHeader = Unsafe.SizeOf<Header>();

    readonly TMessageHandler messageHandler;

    public FrameHandler(TMessageHandler messageHandler)
    {
        this.messageHandler = messageHandler;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public bool TryHandle(ref Frame frame)
    {
        var handlerEnter = Stopwatch.GetTimestamp();

        var ctx = frame.Context;
        var channel = ctx.Channel;
        var netTimestamp = frame.NetTimestamp;
        var payload = frame.Payload;
        var messages = 1;
        var isLargeFrame = payload.Length > 1000;

        try
        {
            if (JumboFrame.IsPartOf(ref frame))
            {
                if (!JumboFrame.TryComplete(ref frame))
                {
                    return true;
                }
                payload = frame.Payload;
            }

            while (payload.Length >= SizeOfHeader)
            {
                var header = MemoryMarshal.AsRef<Header>(payload);

                if (header.hdrlen > payload.Length)
                {
                    break;
                }

                if (header.msglen <= unchecked(header.hdrlen + header.keylen) || header.msgtype >= MessageType.Max)
                {
                    throw new IOException($"Invalid header detected on channel {channel} [messages={1}, header={{{header}}}]");
                }

                if (payload.Length < header.msglen)
                {
                    break;
                }

                try
                {
                    Frame messageFrame = new(payload[..header.msglen], netTimestamp, ctx, frame.FromCache);

                    if (messageHandler.TryHandle(ref messageFrame))
                    {
                        var expectedSeqNo = ctx.GetExpectedSequenceNumber(header.msgtype, header.sourceid);
                        var actualSeqNo = header.seqnum;

                        unchecked
                        {
                            // turn a blind eye to the zeroes since they may be caused by process restarts
                            if (expectedSeqNo == actualSeqNo || expectedSeqNo == 0 || actualSeqNo == 0)
                            {
                                expectedSeqNo++;
                            }
                            else
                            {
                                if (channel.IncrementGapCount(header.msgtype) < 5)
                                {
                                    SRTrace.Net.SeqNumber.TraceWarning($"{header.msgtype} sequence number gap on {channel} from source {header.sourceid}: expected {expectedSeqNo}, received {actualSeqNo}");
                                }

                                expectedSeqNo = (byte)(header.seqnum + 1);
                            }
                        };
                    }

                    channel.IncrementMsgCount(header.msgtype, header.msglen);
                }
                catch (Exception e)
                {
                    channel.LastException = e;
                    throw;
                }

                payload = payload[header.msglen..];
                messages++;
            }

            if (payload.Length > 0)
            {
                frame.Payload = payload;
                return false;
            }

            return true;
        }
        finally
        {
            var handlerExit = Stopwatch.GetTimestamp();

            channel.IncrementTimeCounters(
                handlerEnter - ctx.LastHandlerExitTimestamp,
                handlerExit - handlerEnter,
                isLargeFrame);

            ctx.LastHandlerExitTimestamp = handlerExit;
        }
    }
}
