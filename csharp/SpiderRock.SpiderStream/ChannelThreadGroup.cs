using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream;

internal abstract class ChannelThreadGroup : IDisposable
{
    readonly object syncRoot = new();
    readonly NetStatisticsAggregator netStats;

    protected ChannelThreadGroup(string label, IEnumerable<IPEndPoint> channels)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException($"'{nameof(label)}' cannot be null or whitespace.", nameof(label));
        }

        if (channels.FirstOrDefault() is null)
        {
            throw new ArgumentException("Argument must be a non-empty sequence", nameof(channels));
        }

        Channels = channels.Distinct().ToArray();

        netStats = new(label);

        SRTrace.Aggregate += WriteStatistics;
    }

    public event EventHandler SequenceNumberGapsDetected;

    public IPEndPoint[] Channels { get; }

    protected abstract void Open();

    protected abstract void Close();

    protected abstract void Join(IPEndPoint channel);

    protected abstract void WriteStatistics(double elapsedSeconds);

    protected Channel GetCreateChannel(ChannelType channelType, string channelAddr, string sourceAddr)
    {
        var channel = new Channel(channelType, channelAddr, sourceAddr);
        channel.SequenceNumberGapsDetected += (sender, args) => SequenceNumberGapsDetected?.Invoke(sender, args);
        netStats.Register(channel);
        return channel;
    }

    public void Start()
    {
        lock (syncRoot)
        {
            try
            {
                Open();

                foreach (var channel in Channels)
                {
                    Join(channel);
                }
            }
            catch
            {
                try { Close(); } catch { /* just ignore */ }
                throw;
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        lock (syncRoot)
        {
            Close();
        }
    }

    ~ChannelThreadGroup()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);

        GC.SuppressFinalize(this);
    }
}
