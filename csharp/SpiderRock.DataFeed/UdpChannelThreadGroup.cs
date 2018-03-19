using System.Threading;

namespace SpiderRock.DataFeed
{
    public sealed class UdpChannelThreadGroup : ChannelThreadGroup
    {
        public UdpChannelThreadGroup(ThreadPriority priority)
        {
            Priority = priority;
        }

        public UdpChannelThreadGroup()
        {
        }
    }
}