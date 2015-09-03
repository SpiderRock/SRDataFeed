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
        private readonly Dictionary<string, int> dataFeedChannels = new Dictionary<string, int>();

        public ChannelStatisticsAggregator()
        {
            SRTrace.Aggregate += Flush;
        }

        ~ChannelStatisticsAggregator()
        {
            InternalDispose();
        }

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

        private IEnumerable<string> GetMessageStats(IEnumerable<Channel> channelList, double elapsed)
        {
            if (channelList == null) return null;

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

            var lines = new List<string>();

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

            lines.Insert(0,
                "--- [messages] ----------------------------------------------------------------------------------------------------------");
            lines.Insert(1,
                "channel  (msg)                               msgCount    msgRate/s   numSources      numGaps      cumGaps        cumCount");
            lines.Insert(2,
                "-------------------------------------------------------------------------------------------------------------------------");

            lines.Add(
                "-------------------------------------------------------------------------------------------------------------------------");
            lines.Add(String.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,12} {5,12} {6,15:N0}", "TOTAL:",
                numMessages, numMessages / elapsed, numSenders, numGaps, totalGaps, totalMessages));

            return lines;
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
            List<Channel> copyOfChannels;

            lock (channels)
            {
                copyOfChannels = new List<Channel>(channels);
            }

            IEnumerable<string> channelLines = GetChannelStats(copyOfChannels, elapsedSeconds);
            IEnumerable<string> messageLines = GetMessageStats(copyOfChannels, elapsedSeconds);

            var lines = new List<string> { "" };

            lines.AddRange(channelLines);

            lines.Add("");

            lines.AddRange(messageLines);

            lines.Add("");

            // --- write stats block ---

            SRTrace.NetChannels.TraceData(TraceEventType.Verbose, 0, lines.Cast<object>().ToArray());
            SRTrace.NetSeqNumber.TraceData(TraceEventType.Verbose, 0, GetSeqNumberGapStats(channels).Cast<object>().ToArray());
        }

        private IEnumerable<string> GetChannelStats(IEnumerable<Channel> channelList, double elapsed)
        {
            var lines = new List<string>();

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

                    if (channel.MaxAsyncTime > 0.250 && dataFeedChannels.ContainsKey(channel.Address))
                    {
                        if (time > StartTime && time < EndTime)
                        {
                            error = "SLOW DATA FEED";
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

            lines.Insert(0,
                "--- [channel stats] ------------------------------------------------------------------------------------------------------------------------------------------------");
            lines.Insert(1,
                " channel   mbytes   kbytes/s syscalls/s messages/s   parts    gaps  maxWait  maxProc  sumWait  sumProc                       channel.label            source.address");
            lines.Insert(2,
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

            return lines;
        }

        private static IEnumerable<string> GetSeqNumberGapStats(IEnumerable<Channel> channelList)
        {
            if (channelList == null) yield break;

            const string header = " message / source                                gaps      cumGaps";
            var separator = new string('-', header.Length);

            bool appendEmptyLine = false;

            foreach (var channel in channelList)
            {
                switch (channel.Type)
                {
                    case ChannelType.UdpRecv:
                    case ChannelType.DblRecv:
                        channel.RefreshSeqNumberGapStatistics();

                        if (channel.SeqNumberCounters.All(c => c.Gaps == 0)) continue;

                        yield return string.Empty;

                        yield return string.Format("--- [{0} ({1}) gaps] ---", channel.Name, channel.Type).PadRight(header.Length, '-');
                        yield return header;
                        yield return separator;

                        foreach (var seqNumberCounter in channel
                            .SeqNumberCounters
                            .Where(c => c.Gaps > 0)
                            .OrderBy(c => c.MessageType.ToString())
                            .ThenBy(c => (ushort)c.SourceId))
                        {
                            yield return string.Format("{0,-40} {1,12:N0} {2,12:N0}",
                                seqNumberCounter.MessageType + " / " + seqNumberCounter.SourceId,
                                seqNumberCounter.Gaps,
                                seqNumberCounter.CumulativeGaps);
                        }

                        yield return separator;
                        appendEmptyLine = true;
                        break;
                }
            }

            if (appendEmptyLine) yield return string.Empty;
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