using System.Collections;
using System.Collections.Generic;

namespace SpiderRock.DataFeed
{
    public sealed class DblChannelThreadGroup : IEnumerable<UdpChannel>
    {
        private readonly HashSet<UdpChannel> channels = new HashSet<UdpChannel>();

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
            return "UdpChannelThreadGroup: " + string.Join(", ", channels);
        }
    }
}