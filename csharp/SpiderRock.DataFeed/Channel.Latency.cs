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
                Max = int.MinValue;
                Base = int.MaxValue;
            }

            public override int GetHashCode()
            {
                return Type.GetHashCode();
            }

            public MessageType Type { get; private set; }

            public int BucketMicro10 { get; internal set; }
            public int BucketMicro100 { get; internal set; }
            public int BucketMilli1 { get; internal set; }
            public int BucketMilli10 { get; internal set; }
            public int BucketMilli100 { get; internal set; }
            public int BucketSec1 { get; internal set; }
            public int BucketSecOther { get; internal set; }

            internal long Sum { get; set; }
            public int Total { get; internal set; }

            public int Base { get; internal set; }
            public int Max { get; internal set; }

            public int Period { get; internal set; } 

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
                Total = 0;
                Max = int.MinValue;
            }
        }
    }
}