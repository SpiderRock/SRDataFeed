using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace SpiderRock.DataFeed
{
    public abstract class ChannelThreadGroup : IEnumerable<UdpChannel>
    {
        private readonly HashSet<UdpChannel> channels = new HashSet<UdpChannel>();

        protected ChannelThreadGroup()
        {
            Priority = ThreadPriority.Normal;
        }

        public abstract Protocol Proto { get; }

        public ThreadPriority Priority { get; set; }

        public IEnumerator<UdpChannel> GetEnumerator()
        {
            return channels.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Add(UdpChannel channel)
        {
            return channels.Add(channel);
        }

        public override string ToString()
        {
            return GetType().Name + ": " + string.Join(", ", channels);
        }
    }
}