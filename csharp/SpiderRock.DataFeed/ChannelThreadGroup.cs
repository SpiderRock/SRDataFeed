using System.Collections;
using System.Collections.Generic;

namespace SpiderRock.DataFeed
{
    public abstract class ChannelThreadGroup : IEnumerable<UdpChannel>
    {
        private readonly HashSet<UdpChannel> channels = new HashSet<UdpChannel>();

        public abstract Protocol Proto { get; }

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