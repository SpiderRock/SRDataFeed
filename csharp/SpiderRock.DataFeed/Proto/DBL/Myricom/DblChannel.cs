using System.Net;

namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    internal sealed class DblChannel
    {
        public DblReadHandler Handler;

        public IPEndPoint EndPoint;
        public object ChannelStats;

        public DblChannel(DblReadHandler handler, IPEndPoint endPoint, object channelStats)
        {
            Handler = handler;
            EndPoint = endPoint;
            ChannelStats = channelStats;
        }
    }
}