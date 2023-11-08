using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream.FastSockets;

internal sealed class MlxChannelThreadGroup<TFrameHandler> : ChannelThreadGroup
    where TFrameHandler : IFrameHandler
{
    private readonly MlxVirtDevice<TFrameHandler> device;

    public MlxChannelThreadGroup(IPAddress ifAddress, TFrameHandler frameHandler, string label, IEnumerable<IPEndPoint> channels)
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

        device = new(ifAddress, frameHandler, label);
    }

    protected override void WriteStatistics(double elapsedSeconds)
    {
        if (!device.IsOpen)
        {
            return;
        }

        var stats = device.RotateRxWorkerStatistics();

        if (stats is not null)
        {
            SRTrace.Net.Channels.TraceData(TraceEventType.Verbose, 0, stats.ToString());
        }
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
            device.Join(channel, new(GetCreateChannel(ChannelType.MlxRecv, channel.ToString(), "any")));
        }
    }
}
