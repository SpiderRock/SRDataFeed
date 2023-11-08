using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.Diagnostics;

internal class NetStatisticsAggregator : IDisposable
{
    private const int NanosInSecond = 1_000_000_000;

    private readonly HashSet<Channel> openChannels = new();
    private readonly HashSet<Channel> closedChannels = new();
    private readonly string label;

    public NetStatisticsAggregator(string label)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException($"'{nameof(label)}' cannot be null or whitespace.", nameof(label));
        }

        this.label = label;

        SRTrace.Aggregate += Flush;
    }

    ~NetStatisticsAggregator()
    {
        InternalDispose();
    }

    public void Register(Channel channel)
    {
        channel.Closed += UnRegisterChannel;

        lock (openChannels)
        {
            if (openChannels.Add(channel))
            {
                SRTrace.Net.Channels.TraceDebug($"{ToString()}: channel {channel} registered");
            }
            else
            {
                SRTrace.Net.Channels.TraceWarning("{ToString()}: attempt to double register a channel");
            }
        }
    }

    public override string ToString() => $"{nameof(NetStatisticsAggregator)}[{label}]";

    private void UnRegisterChannel(object sender, EventArgs args)
    {
        if (sender is not Channel channel)
        {
            return;
        }

        lock (openChannels)
        {
            _ = closedChannels.Add(channel);

            if (!openChannels.Remove(channel))
            {
                SRTrace.Net.Channels.TraceWarning($"{ToString()}: attempt to unregister non-existent channel");
            }
        }
    }

    private static TValue GetOrCreate<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key) where TValue : new()
    {
        if (!dict.TryGetValue(key, out var value))
        {
            value = new TValue();
            dict[key] = value;
        }

        return value;
    }

    public void Flush(double elapsedSeconds)
    {
        if (elapsedSeconds.Equals(0d)) return;

        try
        {
            List<Channel> copyOfChannels;

            lock (openChannels)
            {
                copyOfChannels = new(openChannels.Concat(closedChannels));
                closedChannels.Clear();
            }

            if (!copyOfChannels.Any())
            {
                return;
            }

            foreach (var channel in copyOfChannels)
            {
                channel.FlushStatistics();
            }

            GetMessageStats(label, copyOfChannels, elapsedSeconds);

            GetChannelStats(label, copyOfChannels, elapsedSeconds);
        }
        catch (Exception e)
        {
            SRTrace.Default.TraceError(e, $"{ToString()} failure");
        }
    }

    private static void GetMessageStats(string label, IEnumerable<Channel> channelList, double elapsed)
    {
        if (elapsed < 1.0) elapsed = 1.0;

        var aggregate = new Dictionary<string, (long Count, long Bytes, long Gaps, long TotalGaps, long TotalCount, long Sources)>();

        long numSenders = 0;
        long numMessages = 0;
        long numGaps = 0;

        long totalMessages = 0;
        long totalGaps = 0;

        // --- aggregate by channelType + MessageType ---

        foreach (Channel channel in channelList)
        {
            foreach (var stats in channel.EnumerateMessageTypeStatistics())
            {
                var msgType = stats.MessageType;

                string key = String.Format("{0,8} ({1,24}/{2,4})", channel.Type, msgType, (int)msgType);

                var agg = GetOrCreate(aggregate, key);

                agg.Gaps += stats.Incremental.Gaps;
                agg.Count += stats.Incremental.Count;
                agg.Sources += 1;
                agg.TotalGaps += stats.Total.Gaps;
                agg.TotalCount += stats.Total.Count;

                aggregate[key] = agg;

                numSenders += 1;
                numMessages += stats.Incremental.Count;

                totalMessages += stats.Incremental.Count;
            }
        }

        // --- compose aggregate list ---

        var lines = new List<object>();

        foreach (var kv in aggregate)
        {
            numGaps += kv.Value.Gaps;
            totalGaps += kv.Value.TotalGaps;

            string line = String.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,12} {5,12} {6,15:N0}",
                kv.Key,
                kv.Value.Count,
                kv.Value.Count / elapsed,
                kv.Value.Sources,
                kv.Value.Gaps,
                kv.Value.TotalGaps,
                kv.Value.TotalCount
                );

            lines.Add(line);
        }

        lines.Sort();

        int insertPos = 0;

        const string horizontalSeparator = "-------------------------------------------------------------------------------------------------------------------------";

        lines.Insert(insertPos++, string.Empty);
        lines.Insert(insertPos++, $"--- [{label} messages] ".PadRight(horizontalSeparator.Length, '-'));
        lines.Insert(insertPos++, "channel  (msg)                               msgCount    msgRate/s   numSources      numGaps      cumGaps        cumCount");
        lines.Insert(insertPos, horizontalSeparator);

        lines.Add(horizontalSeparator);
        lines.Add(string.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,12} {5,12} {6,15:N0}", "TOTAL:", numMessages, numMessages / elapsed, numSenders, numGaps, totalGaps, totalMessages));
        lines.Add(horizontalSeparator);

        lines.Add(string.Empty);

        SRTrace.Net.Channels.TraceData(TraceEventType.Verbose, 0, lines.ToArray());
    }

    private static double TicksToSeconds(double ticks) => ticks / Stopwatch.Frequency;

    private static void GetChannelStats(string label, IEnumerable<Channel> channelList, double elapsed)
    {
        var lines = new List<object>();

        if (elapsed < 1.0) elapsed = 1.0;

        long numBytes = 0;
        long numFrames = 0;
        long numMessages = 0;
        long numLarge = 0;
        long numGaps = 0;

        double maxAsyncTime = 0;
        double maxHandlerTime = 0;

        double sumHandlerTime = 0;
        double sumAsyncTime = 0;

        DateTime now = DateTime.Now;

        foreach (Channel channel in channelList)
        {
            // compute incremental changes

            long newBytes = channel.Bytes - channel.LastBytes;
            channel.LastBytes = channel.Bytes;

            long newFrames = channel.Frames - channel.LastFrames;
            channel.LastFrames = channel.Frames;

            long newMessages = channel.Messages - channel.LastMessages;
            channel.LastMessages = channel.Messages;

            long newLarge = channel.Large - channel.LastLarge;
            channel.LastLarge = channel.Large;

            long newGaps = channel.Gaps;

            long newErrors = channel.Errors - channel.LastErrors;
            channel.LastErrors = channel.Errors;

            double asyncTime = TicksToSeconds(channel.SumAsyncTimeTicks - channel.LastSumAsyncTimeTicks);
            channel.LastSumAsyncTimeTicks = channel.SumAsyncTimeTicks;

            double handlerTime = TicksToSeconds(channel.SumHandlerTimeTicks - channel.LastSumHandlerTimeTicks);
            channel.LastSumHandlerTimeTicks = channel.SumHandlerTimeTicks;

            string error = "";

            if (channel.Type == ChannelType.WssRecv)
            {
                newGaps = 0;
                if (newBytes == 0 && newFrames == 0 && newMessages == 0) continue;
            }
            else if (channel.Type == ChannelType.MlxRecv || channel.Type == ChannelType.UdpRecv)
            {
                if (TicksToSeconds(channel.MaxHandlerTimeTicks) > 0.250)
                {
                    error = "SLOW HANDLER";
                }

                if (newErrors > 0)
                {
                    error = !string.IsNullOrEmpty(error)
                        ? string.Format("{0} + SEND ERRORS: {1:N0}", error, newErrors)
                        : string.Format("SEND ERRORS: {0:N0}", newErrors);
                }

                maxAsyncTime = Math.Max(maxAsyncTime, TicksToSeconds(channel.MaxAsyncTimeTicks));
                maxHandlerTime = Math.Max(maxHandlerTime, TicksToSeconds(channel.MaxHandlerTimeTicks));

                sumHandlerTime += handlerTime;
                sumAsyncTime += asyncTime;
            }

            numBytes += newBytes;
            numFrames += newFrames;
            numMessages += newMessages;
            numLarge += newLarge;
            numGaps += newGaps;

            string msg = string.Format(
                "{0,8} {1,10:N3} {2,15:N3} {3,10:N0} {4,10:N0} {5,8:N0} {6,7:N0} {7,12:N6} {8,12:N6} {9,15:N0} {10,15:N0} {11,15:N3} {12,15:N3} {13,15:P2} {14,55} {15,25}  {16,-30}",
                channel.Type,
                newBytes / (1024.0 * 1024.0),
                Math.Round(newBytes * 8.0 / 1_000_000 / elapsed, 3),
                Math.Round(newFrames / elapsed),
                Math.Round(newMessages / elapsed),
                Math.Round((double)newBytes / newFrames),
                newGaps,
                (TicksToSeconds(channel.MaxAsyncTimeTicks) > elapsed * 2 ? double.PositiveInfinity : TicksToSeconds(channel.MaxAsyncTimeTicks)),
                (TicksToSeconds(channel.MaxHandlerTimeTicks) > elapsed * 2 ? double.PositiveInfinity : TicksToSeconds(channel.MaxHandlerTimeTicks)),
                newMessages == 0 ? "--" : (handlerTime * NanosInSecond) / newMessages,
                newFrames == 0 ? "--" : (handlerTime * NanosInSecond) / newFrames,
                (asyncTime > elapsed * 2 ? double.PositiveInfinity : asyncTime),
                handlerTime,
                handlerTime / elapsed,
                channel.Name,
                channel.SourceAddress,
                error
                );

            channel.MaxAsyncTimeTicks = 0;
            channel.MaxHandlerTimeTicks = 0;

            lines.Add(msg);
        }

        lines.Sort();

        int insertPos = 0;

        var headerLine = string.Format(
            "{0,8} {1,10} {2,15} {3,10} {4,10} {5,8} {6,7} {7,12} {8,12} {9,15} {10,15} {11,15} {12,15} {13,15} {14,55} {15,25}",
            "channel", "mbytes", "lineRate (mbps)", "frames/s", "messages/s", "avgFrame", "gaps", "maxWait", "maxHandler", "nsPerMessage", "nsPerFrame", "sumWait", "sumHandler", "handler (%)", "channel.label", "source.address");
        var separatorLine = "-".PadRight(headerLine.Length, '-');

        lines.Insert(insertPos++, string.Empty);
        lines.Insert(insertPos++, $"--- [{label} channel stats] ".PadRight(headerLine.Length, '-'));
        lines.Insert(insertPos++, headerLine);
        lines.Insert(insertPos, separatorLine);

        lines.Add(separatorLine);
        lines.Add(string.Format(
            "{0,8} {1,10:N3} {2,15:N3} {3,10:N0} {4,10:N0} {5,8:N0} {6,7:N0} {7,12:N6} {8,12:N6} {9,15:N0} {10,15:N0} {11,15:N3} {12,15:N3} {13,15:P2} {14,55} {15,25}  {16,-30}",
            "TOTAL:",
            numBytes / (1024.0 * 1024.0),
            Math.Round(numBytes * 8.0 / 1_000_000 / elapsed, 3),
            Math.Round(numFrames / elapsed),
            Math.Round(numMessages / elapsed),
            string.Empty,
            numGaps,
            maxAsyncTime > elapsed * 2 ? double.PositiveInfinity : maxAsyncTime,
            maxHandlerTime > elapsed * 2 ? double.PositiveInfinity : maxHandlerTime,
            numMessages == 0 ? "" : (sumHandlerTime * NanosInSecond) / numMessages,
            numFrames == 0 ? "" : (sumHandlerTime * NanosInSecond) / numFrames,
            "",
            sumHandlerTime,
            sumHandlerTime / elapsed,
            "",
            "",
            ""
            ));
        lines.Add(separatorLine);

        lines.Add(string.Empty);

        SRTrace.Net.Channels.TraceData(TraceEventType.Verbose, 0, lines.ToArray());
    }

    public void Dispose()
    {
        InternalDispose();
        GC.SuppressFinalize(this);
    }

    private void InternalDispose()
    {
        SRTrace.Aggregate -= Flush;
    }
}
