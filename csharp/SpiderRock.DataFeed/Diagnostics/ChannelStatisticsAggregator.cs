using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpiderRock.DataFeed.Diagnostics
{
    internal class ChannelStatisticsAggregator : IDisposable
    {
        private static readonly TimeSpan StartTime = new TimeSpan(8, 30, 0);
        private static readonly TimeSpan EndTime = new TimeSpan(15, 0, 0);

        private readonly HashSet<Channel> channels = new HashSet<Channel>();

        private static string latencyTableHeader;
        private static string latencyTableTitle;
        private static string latencyTableSeparator;
        private static string latencyRowFormat;

        public ChannelStatisticsAggregator()
        {
            SRTrace.Aggregate += Flush;
        }

        ~ChannelStatisticsAggregator()
        {
            InternalDispose();
        }

        public bool EnableLatencyAggregation { get; set; }

        public void Register(Channel channel)
        {
            channel.Closed += UnRegisterChannel;

            lock (channels)
            {
                if (channels.Add(channel))
                {
                    SRTrace.NetChannels.TraceDebug("ChannelStatisticsAggregator: channel {0} registered", channel);
                }
                else
                {
                    SRTrace.NetChannels.TraceWarning("ChannelStatisticsAggregator: attempt to double register a channel");                    
                }
            }
        }

        private void UnRegisterChannel(object sender, EventArgs args)
        {
            lock (channels)
            {
                if (!channels.Remove((Channel) sender))
                {
                    SRTrace.NetChannels.TraceWarning("ChannelStatisticsAggregator: attempt to unregister non-existent channel");
                }
            }
        }

        private static TValue GetOrCreate<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key) where TValue : new()
        {
            TValue value;

            if (!dict.TryGetValue(key, out value))
            {
                value = new TValue();
                dict[key] = value;
            }

            return value;
        }

        public void Flush(double elapsedSeconds)
        {
            try
            {
                List<Channel> copyOfChannels;

                lock (channels)
                {
                    copyOfChannels = new List<Channel>(channels);
                }

                foreach (var channel in copyOfChannels)
                {
                    channel.RefreshSeqNumberGapStatistics();
                }

                GetMessageStats(copyOfChannels, elapsedSeconds);

                GetChannelStats(copyOfChannels, elapsedSeconds);

                GetSeqNumberGapStats(copyOfChannels);

                GetLatencyStats(copyOfChannels);
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, "ChannelStatisticsAggregator failure");
            }
        }

        private void GetMessageStats(IEnumerable<Channel> channelList, double elapsed)
        {
            if (elapsed < 1.0) elapsed = 1.0;

            var aggregate = new Dictionary<string, Channel.Statistics>();

            long numSenders = 0;
            long numMessages = 0;
            long numGaps = 0;

            long totalMessages = 0;
            long totalGaps = 0;

            // --- aggregate by channelType + MessageType ---

            foreach (Channel channel in channelList)
            {
                for (int i = 0; i < channel.ByMessageType.Length; i++)
                {
                    Channel.Statistics stats = channel.ByMessageType[i];
                    if (stats == null || stats.Count == stats.LastCount) continue;

                    var msgType = new MessageType((ushort)i);

                    string key = String.Format("{0,8} ({1,25}/{2,3})", channel.Type, msgType, i);

                    Channel.Statistics agg = GetOrCreate(aggregate, key);

                    agg.Gaps += channel.GetGapsByMessageType(msgType);
                    agg.TotalGaps += channel.GetCumulativeGapsByMessageType(msgType);

                    long count = stats.Count - stats.LastCount;
                    stats.LastCount = stats.Count;

                    agg.Count += count;
                    agg.LastCount += 1;

                    agg.TotalCount += stats.Count;

                    numSenders += 1;
                    numMessages += count;

                    totalMessages += stats.Count;
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
                    kv.Value.LastCount,
                    kv.Value.Gaps,
                    kv.Value.TotalGaps,
                    kv.Value.TotalCount
                    );

                lines.Add(line);
            }

            lines.Sort();

            int insertPos = 0;

            lines.Insert(insertPos++, string.Empty);
            lines.Insert(insertPos++,
                "--- [messages] ----------------------------------------------------------------------------------------------------------");
            lines.Insert(insertPos++,
                "channel  (msg)                               msgCount    msgRate/s   numSources      numGaps      cumGaps        cumCount");
            lines.Insert(insertPos,
                "-------------------------------------------------------------------------------------------------------------------------");

            lines.Add(
                "-------------------------------------------------------------------------------------------------------------------------");
            lines.Add(String.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,12} {5,12} {6,15:N0}", "TOTAL:",
                numMessages, numMessages / elapsed, numSenders, numGaps, totalGaps, totalMessages));
            lines.Add(
                "-------------------------------------------------------------------------------------------------------------------------");
            lines.Add(string.Empty);

            SRTrace.NetChannels.TraceData(TraceEventType.Verbose, 0, lines.ToArray());
        }

        private void GetChannelStats(IEnumerable<Channel> channelList, double elapsed)
        {
            var lines = new List<object>();

            if (elapsed < 1.0) elapsed = 1.0;

            long numBytes = 0;
            long numSyscalls = 0;
            long numMessages = 0;
            long numPartials = 0;
            long numGaps = 0;

            double maxAsyncTime = 0;
            double maxHandlerTime = 0;

            double sumHandlerTime = 0;

            DateTime now = DateTime.Now;
            TimeSpan time = now.TimeOfDay;

            foreach (Channel channel in channelList)
            {
                // compute incremental changes

                long newBytes = channel.Bytes - channel.LastBytes;
                channel.LastBytes = channel.Bytes;

                long newSyscalls = channel.Syscalls - channel.LastSyscalls;
                channel.LastSyscalls = channel.Syscalls;

                long newMessages = channel.Messages - channel.LastMessages;
                channel.LastMessages = channel.Messages;

                long newPartials = channel.Partials - channel.LastPartials;
                channel.LastPartials = channel.Partials;

                long newGaps = channel.Gaps;

                long newErrors = channel.Errors - channel.LastErrors;
                channel.LastErrors = channel.Errors;

                double asyncTime = channel.SumAsyncTime - channel.LastSumAsyncTime;
                channel.LastSumAsyncTime = channel.SumAsyncTime;

                double handlerTime = channel.SumHandlerTime - channel.LastSumHandlerTime;
                channel.LastSumHandlerTime = channel.SumHandlerTime;

                string error = "";

                if (channel.Type == ChannelType.TcpRecv)
                {
                    newGaps = 0;
                    if (newBytes == 0 && newSyscalls == 0 && newMessages == 0) continue;
                }
                else if (channel.Type == ChannelType.DblRecv || channel.Type == ChannelType.UdpRecv)
                {
                    if (channel.MaxHandlerTime > 0.250)
                    {
                        error = "SLOW HANDLER";
                    }

                    if (channel.MaxAsyncTime > 0.250)
                    {
                        if (time > StartTime && time < EndTime)
                        {
                            error = "JITTER";
                        }
                    }

                    if (newErrors > 0)
                    {
                        error = !string.IsNullOrEmpty(error)
                            ? string.Format("{0} + SEND ERRORS: {1:N0}", error, newErrors)
                            : string.Format("SEND ERRORS: {0:N0}", newErrors);
                    }

                    maxAsyncTime = Math.Max(maxAsyncTime, channel.MaxAsyncTime);
                    maxHandlerTime = Math.Max(maxHandlerTime, channel.MaxHandlerTime);

                    sumHandlerTime += handlerTime;
                }

                numBytes += newBytes;
                numSyscalls += newSyscalls;
                numMessages += newMessages;
                numPartials += newPartials;
                numGaps += newGaps;

                // write channel incremental stats to log file                           

                string msg = string.Format(
                    "{0,8} {1,8:N1} {2,10:N0} {3,10:N1} {4,10:N1} {5,7:N0} {6,7:N0} {7,8:N4} {8,8:N4} {9,8:N3} {10,8:N3} {11,35} {12,25}  {13,-20}",
                    channel.Type,
                    newBytes / (1024.0 * 1024.0),
                    newBytes / (1024.0 * elapsed),
                    newSyscalls / elapsed,
                    newMessages / elapsed,
                    newPartials,
                    newGaps,
                    Math.Min(99, channel.MaxAsyncTime),
                    Math.Min(99, channel.MaxHandlerTime),
                    Math.Min(99, asyncTime),
                    Math.Min(99, handlerTime),
                    channel.Name,
                    channel.SourceAddress,
                    error
                    );

                channel.MaxAsyncTime = 0;
                channel.MaxHandlerTime = 0;

                lines.Add(msg);
            }

            lines.Sort();

            int insertPos = 0;

            lines.Insert(insertPos++, string.Empty);
            lines.Insert(insertPos++,
                "--- [channel stats] ------------------------------------------------------------------------------------------------------------------------------------------------");
            lines.Insert(insertPos++,
                " channel   mbytes   kbytes/s syscalls/s messages/s   parts    gaps  maxWait  maxProc  sumWait  sumProc                       channel.label            source.address");
            lines.Insert(insertPos,
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            lines.Add(
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            string footer = String.Format(
                "{0,8} {1,8:N1} {2,10:N0} {3,10:N1} {4,10:N1} {5,7:N0} {6,7:N0} {7,8:N4} {8,8:N4} {9,8} {10,8:N3} {11,25}",
                "TOTAL:",
                numBytes / (1024.0 * 1024.0),
                numBytes / (1024.0 * elapsed),
                numSyscalls / elapsed,
                numMessages / elapsed,
                numPartials,
                numGaps,
                Math.Min(99, maxAsyncTime),
                Math.Min(99, maxHandlerTime),
                "",
                Math.Min(99, sumHandlerTime),
                ""
                );

            lines.Add(footer);

            lines.Add(
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            lines.Add(string.Empty);

            SRTrace.NetChannels.TraceData(TraceEventType.Verbose, 0, lines.ToArray());
        }

        private void GetSeqNumberGapStats(IEnumerable<Channel> channelList)
        {
            if (channelList == null) return;

            var header = string.Format("{0,-60}{1,12}{2,12}", "channel / message / source", "gaps", "cumGaps");
            var separator = new string('-', header.Length);
            var lines = new List<object>();

            foreach (var channel in channelList)
            {
                switch (channel.Type)
                {
                    case ChannelType.UdpRecv:
                    case ChannelType.DblRecv:
                        foreach (var seqNumberCounter in channel
                            .SeqNumberCounters
                            .OrderBy(c => c.MessageType.ToString())
                            .ThenBy(c => (ushort) c.SourceId))
                        {
                            lines.Add(string.Format("{0,-60}{1,12:N0}{2,12:N0}",
                                string.Format("{0,-21} / {1,-20} / {2,-5}", channel.Address, seqNumberCounter.MessageType, seqNumberCounter.SourceId),
                                seqNumberCounter.Gaps,
                                seqNumberCounter.CumulativeGaps));
                        }
                        break;
                }
            }

            if (lines.Count == 0) return;

            lines.Sort();

            int insertPos = 0;

            lines.Insert(insertPos++, string.Empty);
            lines.Insert(insertPos++, "--- [channel seqno gaps] ---".PadRight(header.Length, '-'));
            lines.Insert(insertPos++, header);
            lines.Insert(insertPos, separator);
            lines.Add(separator);
            lines.Add(string.Empty);

            SRTrace.NetSeqNumber.TraceData(TraceEventType.Verbose, 0, lines.ToArray());
        }

        private void GetLatencyStats(IEnumerable<Channel> channelList)
        {
            if (!EnableLatencyAggregation) return;

            const int width = 10;

            var lines = new List<string>();

            if (latencyTableHeader == null)
            {
                var headerFormat = "{0,-50}{1,15}{2,15}{3,15}" +
                                   string.Join("", Enumerable.Range(4, 7).Select(i => "{" + i + "," + width + "}"));

                latencyRowFormat = "{0,-50}{1,15:N3}{2,15:N3}{3,15:N3}" +
                                   string.Join("", Enumerable.Range(4, 5).Select(i => "{" + i + "," + width + ":P0}")) +
                                   "{9," + width + ":N0}" +
                                   "{10," + width + ":N0}";

                latencyTableHeader = string.Format(headerFormat,
                    "type / channel", "base (ms)", "avg (ms)", "max (ms)", "< 10µs", "< 100µs", "< 1ms", "< 10ms", "< 100ms", "< 1s", ">= 1s");

                latencyTableTitle = "--- [channel latency] ".PadRight(latencyTableHeader.Length, '-');
                latencyTableSeparator = new string('-', latencyTableHeader.Length);
            }

            foreach (var channel in channelList)
            {
                foreach (var latencyStatistics in channel.Latencies)
                {
                    if (latencyStatistics == null) continue;
                    if (latencyStatistics.Count == 0) continue;
                    if (latencyStatistics.Period++ == 0) continue;

                    var baseDrift = latencyStatistics.Base - latencyStatistics.LastBase;

                    lines.Add(string.Format(latencyRowFormat,
                        latencyStatistics.Type + " / " + channel.Name,

                        latencyStatistics.Base/1000,
                        latencyStatistics.Sum/1000/latencyStatistics.Count,
                        latencyStatistics.Max/1000,

                        latencyStatistics.BucketMicro10/(double) latencyStatistics.Count,
                        latencyStatistics.BucketMicro100/(double) latencyStatistics.Count,

                        latencyStatistics.BucketMilli1/(double) latencyStatistics.Count,
                        latencyStatistics.BucketMilli10/(double) latencyStatistics.Count,
                        latencyStatistics.BucketMilli100/(double) latencyStatistics.Count,

                        latencyStatistics.BucketSec1,
                        latencyStatistics.BucketSecOther
                        ) + string.Format("\tbase drift (ms): {0,8:N3} ({1,5:P0})", baseDrift/1000, Math.Abs(baseDrift/latencyStatistics.LastBase)));

                    latencyStatistics.Reset();
                }
            }

            if (lines.Count == 0) return;

            lines.Sort();

            int insertPos = 0;
            lines.Insert(insertPos++, string.Empty);
            lines.Insert(insertPos++, latencyTableTitle);
            lines.Insert(insertPos++, latencyTableHeader);
            lines.Insert(insertPos, latencyTableSeparator);
            lines.Add(latencyTableSeparator);
            lines.Add(string.Empty);

            SRTrace.NetLatency.TraceData(TraceEventType.Verbose, 0, lines.Cast<object>().ToArray());
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
}