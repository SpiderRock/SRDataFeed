using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed
{
    internal partial class Channel
    {
        private static readonly SeqNumberCounter[][][] SeqNumberCounterIndex =
            new SeqNumberCounter[ushort.MaxValue][][];

        private static long numSlotsSeqNumberCounters = ushort.MaxValue;

        private SeqNumberCounter seqNumber;
        private volatile SeqNumberCounter[] seqNumberCounters = new SeqNumberCounter[0];

        private readonly bool supressSeqNumberCheck;

        private long Gaps
        {
            get { return seqNumberCounters.Sum(c => c.Gaps); }
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
                if (channelIndex != null && channelIndex.Length > Id) return;

                SeqNumberCounter[] tmp = channelIndex;

                messageTypeIndex[messageType] = channelIndex = new SeqNumberCounter[Math.Max(100, Id + 10)];
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
                seqNumber = SeqNumberCounterIndex[sourceId][messageType][Id];
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
            SeqNumberCounterIndex[sourceId][messageType][Id] = counter;
            seqNumberCounters = seqNumberCounters.Union(new[] {counter}).ToArray();
            return counter;
        }

        private void RefreshSeqNumberGapStatistics()
        {
            foreach (SeqNumberCounter seqNumberCounter in seqNumberCounters)
            {
                seqNumberCounter.RefreshStatistics();
            }
        }

        private long GetGapsByMessageType(MessageType messageType)
        {
            return seqNumberCounters.Where(c => c.MessageType == messageType).Sum(c => c.Gaps);
        }

        private long GetCumulativeGapsByMessageType(MessageType messageType)
        {
            return seqNumberCounters.Where(c => c.MessageType == messageType).Sum(c => c.CumulativeGaps);
        }

        private sealed class SeqNumberCounter : IEquatable<SeqNumberCounter>
        {
            private long gaps;
            private byte expected;
            private readonly Channel channel;

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

            public static bool operator ==(SeqNumberCounter left, SeqNumberCounter right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(SeqNumberCounter left, SeqNumberCounter right)
            {
                return !Equals(left, right);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void AssertEqual(byte actual)
            {
                unchecked
                {
                    expected += 1;
                }

                if (expected == actual) return;

                var tmp = expected;

                Interlocked.Increment(ref gaps);
                expected = actual;

                if (gaps > 10) return;

                SRTrace.NetChannels.TraceWarning("{0} sequence number gap on {1} (Id={2}) from {3}: expected {4}, received {5}",
                    MessageType, channel, channel.Id, SourceId, tmp, actual);
            }

            public void RefreshStatistics()
            {
                Gaps = Interlocked.Exchange(ref gaps, 0);
                CumulativeGaps += Gaps;
            }
        }
    }
}