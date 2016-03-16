using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    internal sealed class DblChannel
    {
        private static readonly double Frequency = Stopwatch.Frequency;

        private readonly DblReadHandler handler;
        private readonly Channel recvChannel;

        private long handlerBegin;
        private long handlerEnd = Stopwatch.GetTimestamp();

        public DblChannel(DblReadHandler handler, Channel recvChannel)
        {
            this.handler = handler;
            this.recvChannel = recvChannel;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Handle(byte[] buffer, int length, long netTimestamp)
        {
            handlerBegin = Stopwatch.GetTimestamp();

            var asyncElapsed = (handlerBegin - handlerEnd)/Frequency;

            var roffset = handler(buffer, length, netTimestamp, recvChannel);

            handlerEnd = Stopwatch.GetTimestamp();

            recvChannel.IncrementTimeCounters(asyncElapsed, (handlerEnd - handlerBegin)/Frequency, length >= 1000);

            return roffset;
        }
    }
}