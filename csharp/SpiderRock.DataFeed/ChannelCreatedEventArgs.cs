using System;

namespace SpiderRock.DataFeed
{
    public class ChannelCreatedEventArgs : EventArgs
    {
        public ChannelCreatedEventArgs(Channel channel)
        {
            Channel = channel;
        }

        public Channel Channel { get; private set; }
    }
}