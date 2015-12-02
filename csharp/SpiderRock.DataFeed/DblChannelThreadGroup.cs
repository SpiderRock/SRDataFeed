using System.Threading;

namespace SpiderRock.DataFeed
{
    public class DblChannelThreadGroup : ChannelThreadGroup
    {
        public DblChannelThreadGroup(ThreadPriority priority)
        {
            Priority = priority;
        }

        public DblChannelThreadGroup()
        {
        }

        public override Protocol Proto
        {
            get { return Protocol.DBL; }
        }
    }
}