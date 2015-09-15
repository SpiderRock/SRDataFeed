using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed
{
    public partial class Channel
    {
        private static readonly SeqNumberCounter[][][] SeqNumberCounterIndex =
            new SeqNumberCounter[ushort.MaxValue][][];

        private static long numSlotsSeqNumberCounters = ushort.MaxValue;

        private readonly bool supressSeqNumberCheck;
        internal volatile SeqNumberCounter[] SeqNumberCounters = new SeqNumberCounter[0];
        private SeqNumberCounter seqNumber;

        internal long Gaps
        {
            get { return SeqNumberCounters.Sum(c => c.Gaps); }
        }

        private void AllocIndexSpaceForSeqNumberCounter(SourceId sourceId, MessageType messageType)
        {
            SeqNumberCounter[][] messageTypeIndex = SeqNumberCounterIndex[sourceId];
            if (messageTypeIndex == null)
            {
                lock (SeqNumberCounterIndex)
                {
                    messageTypeIndex = SeqNumberCounterIndex[sourceId];
                    if (messageTypeIndex == null)
                    {
                        SeqNumberCounterIndex[sourceId] =
                            messageTypeIndex = MessageType.CreateSizedArray<SeqNumberCounter[]>();

                        Interlocked.Add(ref numSlotsSeqNumberCounters, messageTypeIndex.Length);
                    }
                }
            }

            lock (messageTypeIndex)
            {
                SeqNumberCounter[] channelIndex = messageTypeIndex[messageType];
                if (channelIndex != null && channelIndex.Length > id) return;

                SeqNumberCounter[] tmp = channelIndex;

                messageTypeIndex[messageType] = channelIndex = new SeqNumberCounter[Math.Max(100, id + 10)];
                if (tmp != null) tmp.CopyTo(channelIndex, 0);

                Interlocked.Add(ref numSlotsSeqNumberCounters, channelIndex.Length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void CheckSeqNumber(SourceId sourceId, MessageType messageType, byte sequenceNumber)
        {
            if (supressSeqNumberCheck || sourceId == 0 /* client tools */) return;

            try
            {
                seqNumber = SeqNumberCounterIndex[sourceId][messageType][id];
                seqNumber.AssertEqual(sequenceNumber);
            }
            catch (Exception)
            {
                AllocIndexSpaceForSeqNumberCounter(sourceId, messageType);
                seqNumber = CreateSeqNumberCounter(sourceId, messageType, sequenceNumber);
            }
        }

        private SeqNumberCounter CreateSeqNumberCounter(SourceId sourceId, MessageType messageType,
            byte sequenceNumber)
        {
            var counter = new SeqNumberCounter(this, sourceId, messageType, sequenceNumber);
            SeqNumberCounterIndex[sourceId][messageType][id] = counter;
            SeqNumberCounters = SeqNumberCounters.Union(new[] {counter}).ToArray();
            return counter;
        }

        internal void RefreshSeqNumberGapStatistics()
        {
            switch (Type)
            {
                case ChannelType.UdpRecv:
                case ChannelType.DblRecv:
                    foreach (SeqNumberCounter seqNumberCounter in SeqNumberCounters)
                    {
                        seqNumberCounter.RefreshStatistics();
                    }
                    break;
            }
        }

        internal long GetGapsByMessageType(MessageType messageType)
        {
            return SeqNumberCounters.Where(c => c.MessageType == messageType).Sum(c => c.Gaps);
        }

        internal long GetCumulativeGapsByMessageType(MessageType messageType)
        {
            return SeqNumberCounters.Where(c => c.MessageType == messageType).Sum(c => c.CumulativeGaps);
        }

        private void BeginSequenceNumberGapsDetected()
        {
            EventHandler handler = SequenceNumberGapsDetected;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, EndFireSequenceNumberGapsDetected, null);
            }
        }

        private static void EndFireSequenceNumberGapsDetected(IAsyncResult iar)
        {
            var ar = (AsyncResult) iar;
            var invokedMethod = (EventHandler) ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, "SequenceNumberGapsDetected event handler failure");
            }
        }

        internal sealed class SeqNumberCounter : IEquatable<SeqNumberCounter>
        {
            private readonly Channel channel;
            private byte expected;
            private volatile int gaps;

            public SeqNumberCounter(Channel channel, SourceId source, MessageType type, byte value)
            {
                this.channel = channel;
                SourceId = source;
                MessageType = type;
                expected = value;
            }

            public SourceId SourceId { get; private set; }
            public MessageType MessageType { get; private set; }

            public long Gaps { get; private set; }
            public long CumulativeGaps { get; private set; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(SeqNumberCounter other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return SourceId.Equals(other.SourceId) && MessageType.Equals(other.MessageType);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override bool Equals(object obj)
            {
                return Equals(obj as SeqNumberCounter);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (SourceId.GetHashCode()*397) ^ MessageType.GetHashCode();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void AssertEqual(byte actual)
            {
                unchecked
                {
                    expected += 1;

                    if (expected == actual)
                    {
                        return;
                    }

                    if (actual == 0 || expected == 0)
                    {
                        expected = actual;
                        return;
                    }

                    byte tmp = expected;

                    gaps += 1;
                    expected = actual;

                    if (gaps > 5) return;

                    SRTrace.NetSeqNumber.TraceWarning(
                        "{0} sequence number gap on {1} (Id={2}) from {3}: expected {4}, received {5}",
                        MessageType, channel, channel.id, SourceId, tmp, actual);

                    channel.BeginSequenceNumberGapsDetected();
                }
            }

            public void RefreshStatistics()
            {
                Gaps = gaps;
                CumulativeGaps += Gaps;
            }
        }
    }
}