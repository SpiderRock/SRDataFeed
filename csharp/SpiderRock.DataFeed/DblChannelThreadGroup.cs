namespace SpiderRock.DataFeed
{
    public class DblChannelThreadGroup : ChannelThreadGroup
    {
        public override Protocol Proto
        {
            get { return Protocol.DBL; }
        }
    }
}