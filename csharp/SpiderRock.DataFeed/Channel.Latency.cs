using System;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed
{
    public partial class Channel
    {
        private readonly LatencyStatistics[] latencyStatistics = MessageType.CreateSizedArray<LatencyStatistics>();

        public LatencyStatistics[] Latencies
        {
            get { return latencyStatistics; }
        }

        public class LatencyStatistics
        {
            internal LatencyStatistics(MessageType messageType)
            {
                Type = messageType;
                Max = double.MinValue;
                Base = double.MaxValue;
            }

            public override int GetHashCode()
            {
                return Type.GetHashCode();
            }

            public MessageType Type { get; private set; }

            public long BucketMicro10 { get; private set; }
            public long BucketMicro100 { get; private set; }
            public long BucketMilli1 { get; private set; }
            public long BucketMilli10 { get; private set; }
            public long BucketMilli100 { get; private set; }
            public long BucketSec1 { get; private set; }
            public long BucketSecOther { get; private set; }

            public double Sum { get; private set; }
            public long Count { get; private set; }

            public double LastBase { get; private set; }
            public double Base { get; private set; }
            public double Max { get; private set; }

            public int Period { get; internal set; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal void Reset()
            {
                BucketMicro10 = 0;
                BucketMicro100 = 0;
                BucketMilli1 = 0;
                BucketMilli10 = 0;
                BucketMilli100 = 0;
                BucketSec1 = 0;
                BucketSecOther = 0;

                Sum = 0;
                Count = 0;
                Max = double.MinValue;
                LastBase = Base;
                Base = double.MaxValue;
            }

            /// <summary>
            /// Update channel's latency statistics.
            /// </summary>
            /// <param name="netTimestamp">
            /// Exchange message receipt time (in POSIX nanoseconds) of 
            /// that triggered the normalized message to be sent by SpiderRock.
            /// </param>
            /// <param name="clnTimestamp">
            /// Normalized message receipt time (in POSIX nanoseconds) 
            /// </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal void Update(long netTimestamp, long clnTimestamp)
            {
                var netLatency = (clnTimestamp - netTimestamp)/1000;

                Count += 1;
                Base = (int) Math.Min(netLatency, Base);

                var relLatency = Math.Abs(netLatency - LastBase);
                Max = (int) Math.Max(relLatency, Max);

                Sum += relLatency;

                if (relLatency <= 10)           BucketMicro10 += 1;
                else if (relLatency <= 100)     BucketMicro100 += 1;

                else if (relLatency <= 1000)    BucketMilli1 += 1;
                else if (relLatency <= 10000)   BucketMilli10 += 1;
                else if (relLatency <= 100000)  BucketMilli100 += 1;

                else if (relLatency <= 1000000) BucketSec1 += 1;
                else BucketSecOther += 1;
            }
        }
    }
}