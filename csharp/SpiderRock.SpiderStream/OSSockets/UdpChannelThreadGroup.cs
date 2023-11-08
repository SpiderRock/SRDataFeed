using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using SpiderRock.SpiderStream.FastSockets;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.OSSockets;

internal sealed class UdpChannelThreadGroup<TFrameHandler> : ChannelThreadGroup
     where TFrameHandler : IFrameHandler
{
    private readonly UdpDevice<TFrameHandler> device;

    public UdpChannelThreadGroup(IPAddress ifAddress, TFrameHandler frameHandler, string label, IEnumerable<IPEndPoint> channels)
        : base(label, channels)
    {
        if (ifAddress is null)
        {
            throw new ArgumentNullException(nameof(ifAddress));
        }

        if (frameHandler is null)
        {
            throw new ArgumentNullException(nameof(frameHandler));
        }

        device = new(ifAddress, frameHandler, 20 * 1024 * 1024, ThreadPriority.Highest);
    }

    protected override void WriteStatistics(double elapsedSeconds)
    {
    }

    protected override void Open()
    {
        device.Open();
    }

    protected override void Close()
    {
        device.Close();
    }

    protected override void Join(IPEndPoint channel)
    {
        if (device.IsOpen)
        {
            device.Join(channel, GetCreateChannel(ChannelType.UdpRecv, channel.ToString(), "any"));
        }
    }
}
