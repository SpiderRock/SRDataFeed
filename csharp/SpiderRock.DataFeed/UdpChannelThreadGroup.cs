namespace SpiderRock.DataFeed
{
    public sealed class UdpChannelThreadGroup : ChannelThreadGroup
    {
        public override Protocol Proto
        {
            get { return Protocol.UDP; }
        }
    }
}