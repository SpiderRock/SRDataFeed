using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.FrameHandling
{
    internal sealed unsafe class FrameHandler
    {
        private sealed class ErrorCounter
        {
            private int counter;
            private readonly int max;
            private volatile bool maxReached;

            public ErrorCounter(string label, int max)
            {
                Label = label;
                this.max = max;
            }

            public string Label { get; private set; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool TryIncrement()
            {
                if (maxReached) return false;
                var c = Interlocked.Increment(ref counter);
                if (c == max)
                {
                    SRTrace.Default.TraceWarning(
                        "Error category '{0}' reached its max of {1} log messages.  Logging for this error category will be suppressed going forward.",
                        Label, max);
                }
                else if (c < max)
                {
                    return true;
                }
                maxReached = true;
                return false;
            }
        }

        private readonly ErrorCounter frameParseError = new ErrorCounter("frame parse error", 50);

        private readonly ErrorCounter[] channelCrossErrors =
            MessageType.CreateSizedArray(messageType => new ErrorCounter(messageType + " channel cross error", 20));

        private readonly ErrorCounter[] messageParseErrors =
            MessageType.CreateSizedArray(messageType => new ErrorCounter(messageType + " message parse error", 20));

        private readonly ErrorCounter[] unknownMessageTypeErrors =
            MessageType.CreateSizedArray(messageType => new ErrorCounter(messageType + " unknown message type", 1));

        private readonly MessageHandler[] messageHandlers;

        public FrameHandler(SysEnvironment sysEnvironment)
        {
            if (sysEnvironment == SysEnvironment.None)
            {
                throw new ArgumentOutOfRangeException("sysEnvironment", "Argument may not be None");
            }
            messageHandlers = MessageType.CreateSizedArray<MessageHandler>();
            SysEnvironment = sysEnvironment;
        }

        public SysEnvironment SysEnvironment { get; set; }

        [ThreadStatic]
        private static Header thdLastHeader;

        public int OnFrame(byte[] buffer, int length, long netTimestamp, Channel channel)
        {
            int offset = 0;

            try
            {
                fixed (byte* ptr = buffer)
                {
                    while (offset + sizeof(Header) <= length)
                    {
                        Header header = *(Header*) unchecked(ptr + offset);

                        if (!header.environment.IsValid() ||
                            header.msglen <= unchecked(sizeof (Header) + header.keylen) ||
                            header.msgtype >= MessageType.Max)
                        {
                            channel.LastError = frameParseError.Label;

                            if (frameParseError.TryIncrement())
                            {
                                LogError(channel, buffer, offset, null, "Frame parsing error: invalid header detected");
                            }

                            return -1; // throw invalid frame error
                        }

                        if (offset + header.msglen > length) break;

                        channel.IncrementMsgCount(header.msgtype, header.msglen);
                        channel.CheckSeqNumber(header.sourceid, header.msgtype, header.seqnum);

                        if (header.environment == SysEnvironment)
                        {
                            try
                            {
                                MessageHandler handler = messageHandlers[header.msgtype];

                                if (handler != null)
                                {
                                    handler(ptr, buffer.Length, offset, header, netTimestamp, channel);
                                }
                                else if (unknownMessageTypeErrors[header.msgtype].TryIncrement())
                                {
                                    SRTrace.Default.TraceError("ParseMessage: {0}", unknownMessageTypeErrors[header.msgtype].Label);
                                }
                            }
                            catch (Exception e)
                            {
                                var parseMessageErrorCounter = messageParseErrors[header.msgtype];

                                channel.LastError = parseMessageErrorCounter.Label;
                                channel.LastException = e;

                                if (parseMessageErrorCounter.TryIncrement())
                                {
                                    LogError(channel, buffer, offset, e, "ParseMessage Exception: MsgType={0}", header.msgtype);
                                }
                            }
                        }
                        else
                        {
                            var crossChannelErrorCounter = channelCrossErrors[header.msgtype];

                            channel.LastError = crossChannelErrorCounter.Label;

                            if (crossChannelErrorCounter.TryIncrement())
                            {
                                SRTrace.Default.TraceWarning(
                                    "Received {0} from SysEnvironment {1} on {2} (channel.addr={3}, from.addr={4})",
                                    header.msgtype, header.environment, channel, channel.Address, channel.SourceAddress);
                            }
                        }

                        channel.LastHeader = header;
                        thdLastHeader = header;

                        offset += header.msglen;
                    } // while              
                }

                if (offset < 0) return offset; // frame parse error (generally not recoverable)

                if (offset == length) return 0;
                if (offset == 0) return length;

                // copy residual to beginning of buffer            
                Buffer.BlockCopy(buffer, offset, buffer, 0, length - offset);

                return length - offset;
            }
            catch (Exception e)
            {
                if (channel != null)
                {
                    channel.LastError = frameParseError.Label;
                    channel.LastException = e;
                }

                if (frameParseError.TryIncrement())
                {
                    LogError(channel, buffer, offset, e, "Frame parsing error: unexpected failure");
                }

                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int OnFrame(byte[] buffer, int length, long netTimestamp, object channel)
        {
            return OnFrame(buffer, length, netTimestamp, (channel as Channel));
        }

        private static void LogError(Channel channel, byte[] buffer, int offset, Exception e, string format, params object[] args)
        {
            try
            {
                var lastBytesStr = string.Join(",",
                    buffer
                        .Skip(offset > 200 ? offset - 200 : 0)
                        .Take(Math.Min(offset, 200))
                        .Select(b => b.ToString(CultureInfo.InvariantCulture)));

                var remoteEndPoint = channel.RemoteEp == null ? "???" : channel.RemoteEp.ToString();

                var msg = new StringBuilder();
                msg.AppendFormat(format, args);
                switch (channel.Type)
                {
                    case ChannelType.UdpRecv:
                    case ChannelType.TcpRecv:
                        msg.AppendFormat(
                            " [offset={0}, ch={1} [{2}], remoteEP={3}, last.hdr=({4}), trailing.bytes=({5})]",
                            offset, channel.Address, channel, remoteEndPoint, channel.LastHeader, lastBytesStr);
                        break;
                    case ChannelType.DblRecv:
                        msg.AppendFormat(
                            " [offset={0}, ch={1} [{2}], remoteEP={3}, last.hdr=({4}), trailing.bytes=({5})]",
                            offset, channel.Address, channel, remoteEndPoint, thdLastHeader, lastBytesStr);
                        break;
                    default:
                        msg.AppendFormat(
                            " [offset={0}, ch={1} [{2}], remoteEP={3}, ch.last.hdr=({4}), thd.last.hdr=({5}), trailing.bytes=({6})]",
                            offset, channel.Address, channel, remoteEndPoint, channel.LastHeader, thdLastHeader, lastBytesStr);
                        break;
                }

                SRTrace.Default.TraceError(e, msg.ToString());
            }
            catch (Exception loggingError)
            {
                SRTrace.Default.TraceError(loggingError, "LogError() failure");
            }
        }

        public void OnMessage(MessageType messageType, MessageHandler handler)
        {
            messageHandlers[messageType] = handler;
        }
    } // Frame Handler
}