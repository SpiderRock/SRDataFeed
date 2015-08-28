using System;
using System.Collections.Generic;
using System.Linq;

namespace SpiderRock.DataFeed
{
    internal class ChannelFactory
    {
        private readonly Dictionary<Key, Channel> channelsByKey = new Dictionary<Key, Channel>(20);

        public ISet<Channel> Instances
        {
            get
            {
                lock (channelsByKey)
                {
                    return new HashSet<Channel>(channelsByKey.Select(kvp => kvp.Value));
                }
            }
        }

        public event EventHandler<ChannelCreatedEventArgs> ChannelCreated;

        public Channel GetOrCreate(ChannelType channelType, string channelAddr, string sourceAddr)
        {
            var key = new Key(channelType, channelAddr);
            Channel channel;
            if (!channelsByKey.TryGetValue(key, out channel))
            {
                lock (channelsByKey)
                {
                    if (!channelsByKey.TryGetValue(key, out channel))
                    {
                        channel = new Channel(channelType, channelAddr, sourceAddr);
                        channel.Closed += RemoveClosedChannel;
                        channelsByKey[key] = channel;
                        var channelCreated = ChannelCreated;
                        if (channelCreated != null)
                        {
                            channelCreated(this, new ChannelCreatedEventArgs(channel));
                        }
                    }
                }
            }
            return channel;
        }

        private void RemoveClosedChannel(object sender, EventArgs eventArgs)
        {
            var channel = (Channel)sender;

            lock (channelsByKey)
            {
                channelsByKey.Remove(new Key(channel.Type, channel.Address));
            }
        }

        private struct Key : IEquatable<Key>
        {
            private readonly string channelAddr;
            private readonly ChannelType channelType;

            public Key(ChannelType channelType, string channelAddr)
            {
                if (channelAddr == null) throw new ArgumentNullException("channelAddr");
                this.channelType = channelType;
                this.channelAddr = channelAddr;
            }

            public bool Equals(Key other)
            {
                return channelType == other.channelType && string.Equals(channelAddr, other.channelAddr);
            }

            public override bool Equals(object obj)
            {
                if (obj.GetType() != GetType()) return false;
                return Equals((Key) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) channelType*397) ^ channelAddr.GetHashCode();
                }
            }
        }
    }
}