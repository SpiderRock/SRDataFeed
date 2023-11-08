using System;

namespace SpiderRock.SpiderStream;

public class ChannelCreatedEventArgs : EventArgs
{
    public ChannelCreatedEventArgs(Channel channel)
    {
        Channel = channel;
    }

    public Channel Channel { get; private set; }
}