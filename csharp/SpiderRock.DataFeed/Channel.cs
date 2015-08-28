using System;
using System.Net;
using System.Threading;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed
{
    public sealed partial class Channel
    {
        private static int idGenerator;
        private readonly int id;
        private bool isClosed;

        internal Channel(ChannelType channelType, string channelAddr, string sourceAddr)
        {
            if (channelAddr == null) throw new ArgumentNullException("channelAddr");
            if (sourceAddr == null) throw new ArgumentNullException("sourceAddr");

            Name = channelAddr;
            Type = channelType;
            Address = channelAddr;
            SourceAddress = sourceAddr;

            ByMessageType = MessageType.CreateSizedArray<Statistics>();

            IsReceiving = (channelType == ChannelType.TcpRecv || channelType == ChannelType.UdpRecv);

            supressSeqNumberCheck = channelType == ChannelType.TcpSend || channelType == ChannelType.TcpRecv;

            id = Interlocked.Increment(ref idGenerator);
        }

        ~Channel()
        {
            Close();
        }

        public event EventHandler Closed;
        public event EventHandler SequenceNumberGapsDetected;

        public ChannelType Type { get; private set; }
        public string Name { get; private set; }
        public string SourceAddress { get; private set; }
        public string Address { get; private set; }

        public long Errors { get; internal set; }
        public long Partials { get; internal set; }
        public IPEndPoint RemoteEp { get; internal set; }
        public long Syscalls { get; internal set; }
        public long Bytes { get; internal set; }
        public double MaxAsyncTime { get; internal set; }
        public double MaxHandlerTime { get; internal set; }
        public long Messages { get; internal set; }
        public double SumAsyncTime { get; internal set; }
        public double SumHandlerTime { get; internal set; }

        internal Statistics[] ByMessageType { get; private set; }
        internal long LastBytes { get; set; }
        internal long LastErrors { get; set; }
        internal long LastMessages { get; set; }
        internal long LastPartials { get; set; }
        internal long LastSyscalls { get; set; }
        internal double LastSumAsyncTime { get; set; }
        internal double LastSumHandlerTime { get; set; }
        internal string LastError { get; set; }
        internal Exception LastException { get; set; }

        internal bool IsReceiving { get; private set; }
        internal Header LastHeader { get; set; }

        public override string ToString()
        {
            return Name + " [" + Type + "]";
        }

        internal void IncrementTimeCounters(double asyncElapsed, double handlerElapsed, bool isPartial,
            bool errFlag = false)
        {
            Syscalls += 1;

            if (errFlag) Errors += 1;
            if (isPartial) Partials += 1;

            MaxAsyncTime = Math.Max(MaxAsyncTime, asyncElapsed);
            MaxHandlerTime = Math.Max(MaxHandlerTime, handlerElapsed);

            SumAsyncTime += asyncElapsed;
            SumHandlerTime += handlerElapsed;
        }

        internal void IncrementMsgCount(int msgtype, int msglen)
        {
            Bytes += msglen;
            Messages += 1;

            if (msgtype >= ByMessageType.Length) return;

            Statistics stats = ByMessageType[msgtype];

            if (stats == null)
            {
                stats = new Statistics();
                ByMessageType[msgtype] = stats;
            }

            stats.Count += 1;
        }

        internal void Close()
        {
            if (isClosed) return;

            EventHandler closed = Closed;
            if (closed != null)
            {
                closed(this, EventArgs.Empty);
            }

            isClosed = true;
        }

        public class Statistics
        {
            public long Count { get; internal set; }
            public long TotalCount { get; internal set; }

            public long Gaps { get; internal set; }
            public long TotalGaps { get; internal set; }

            internal long LastCount { get; set; }
        }
    }
}