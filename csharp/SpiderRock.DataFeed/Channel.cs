using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed
{
    internal class Channel : IEquatable<Channel>
    {
        public const string LogName = "channels";

        private static DateTime lastDttmUtc = DateTime.UtcNow;

        private static long totalMsgIn;
        private static long totalMsgOut;
        private static long totalSysCallIn;
        private static long totalSysCallOut;

        private static long lastMsgIn;
        private static long lastMsgOut;
        private static long lastSysCallIn;
        private static long lastSysCallOut;

        private static readonly List<Channel> Channels = new List<Channel>();

        private static readonly TimeSpan StartTime = new TimeSpan(8, 30, 0);
        private static readonly TimeSpan EndTime = new TimeSpan(15, 0, 0);

        private static readonly Dictionary<string, int> DataFeedChannels = new Dictionary<string, int>();
        private readonly bool isRecv;
        private readonly MsgStats[] msgStats;

        public long Errors;
        public string LastError;
        public Exception LastException;
        public long Partials;
        public IPEndPoint RemoteEp;
        public long Syscalls;

        private long bytes;
        private volatile bool isClosed;
        private long lastBytes;
        private long lastErrors;
        private long lastMessages;
        private long lastPartials;
        private double lastSumAsyncTime;
        private double lastSumHandlerTime;
        private long lastSyscalls;
        private double maxAsyncTime;
        private double maxHandlerTime;
        private long messages;
        private double sumAsyncTime;
        private double sumHandlerTime;

        static Channel()
        {
            WriteChannelStats(CancellationToken.None);
        }

        public Channel(ChannelType channelType, string channelAddr, string sourceAddr)
        {
            if (channelAddr == null) throw new ArgumentNullException("channelAddr");
            if (sourceAddr == null) throw new ArgumentNullException("sourceAddr");

            ChannelType = channelType;
            ChannelAddr = channelAddr;
            SourceAddr = sourceAddr;

            key = new ChannelKey(ChannelType, ChannelAddr);

            msgStats = StatsByChannelKey.GetOrAdd(key, k => MessageType.CreateSizedArray<MsgStats>());

            ChannelName = channelAddr;

            lock (Channels)
            {
                Channels.Add(this);
            }

            isRecv = (channelType == ChannelType.TcpRecv || channelType == ChannelType.UdpRecv);
        }

        public string SourceAddr { get; set; }
        public string ChannelAddr { get; set; }

        public ChannelType ChannelType { get; set; }

        public string ChannelName { get; set; }

        public Header LastHeader { get; set; }

        public bool Equals(Channel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return key.Equals(other.key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Channel);
        }

        public override int GetHashCode()
        {
            return key.GetHashCode();
        }

        public override string ToString()
        {
            return ChannelName + " [" + ChannelType + "]";
        }

        public static bool operator ==(Channel left, Channel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Channel left, Channel right)
        {
            return !Equals(left, right);
        }

        public void IncrementTimeCounters(double asyncElapsed, double handlerElapsed, bool isPartial,
            bool errFlag = false)
        {
            Syscalls += 1;

            if (errFlag) Errors += 1;
            if (isPartial) Partials += 1;

            maxAsyncTime = Math.Max(maxAsyncTime, asyncElapsed);
            maxHandlerTime = Math.Max(maxHandlerTime, handlerElapsed);

            sumAsyncTime += asyncElapsed;
            sumHandlerTime += handlerElapsed;
        }

        public void IncrementMsgCount(int msgtype, int msglen)
        {
            bytes += msglen;
            messages += 1;

            if (msgtype >= msgStats.Length) return;

            MsgStats stats = msgStats[msgtype];

            if (stats == null)
            {
                stats = new MsgStats();
                msgStats[msgtype] = stats;
            }

            stats.Count += 1;
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

        public static List<string> GetMessageStats(List<Channel> channelList, double elapsed)
        {
            if (channelList == null) return null;

            if (elapsed < 1.0) elapsed = 1.0;

            var aggregate = new Dictionary<string, MsgStats>();

            long numSenders = 0;
            long numMessages = 0;

            long totalMessages = 0;

            // --- aggregate by channelType + MessageType ---

            foreach (Channel channel in channelList)
            {
                for (int i = 0; i < channel.msgStats.Length; i++)
                {
                    MsgStats stats = channel.msgStats[i];
                    if (stats == null || stats.Count == stats.LastCount) continue;

                    var msgType = new MessageType((ushort) i);

                    string key = String.Format("{0,8} ({1,25}/{2,3})", channel.ChannelType, msgType, i);

                    MsgStats agg = GetOrCreate(aggregate, key);

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
                string line = String.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,15:N0}",
                    kv.Key,
                    kv.Value.Count,
                    kv.Value.Count/elapsed,
                    kv.Value.LastCount,
                    kv.Value.TotalCount
                    );

                lines.Add(line);
            }

            lines.Sort();

            lines.Insert(0,
                "--- [messages] --------------------------------------------------------------------------------");
            lines.Insert(1,
                "channel  (msg)                               msgCount    msgRate/s   numSources        cumCount");
            lines.Insert(2,
                "-----------------------------------------------------------------------------------------------");

            lines.Add("-----------------------------------------------------------------------------------------------");
            lines.Add(String.Format("{0,40} {1,12:N0} {2,12:N1} {3,12} {4,15:N0}", "TOTAL:", numMessages,
                numMessages/elapsed, numSenders, totalMessages));

            return lines;
        }

        public static List<string> GetChannelStats(List<Channel> channelList, double elapsed)
        {
            var lines = new List<string>();

            if (elapsed < 1.0) elapsed = 1.0;

            long numBytes = 0;
            long numSyscalls = 0;
            long numMessages = 0;
            long numPartials = 0;

            double maxAsyncTime = 0;
            double maxHandlerTime = 0;

            double sumHandlerTime = 0;

            DateTime now = DateTime.Now;
            TimeSpan time = now.TimeOfDay;

            foreach (Channel channel in channelList)
            {
                // compute incremental changes

                long newBytes = channel.bytes - channel.lastBytes;
                channel.lastBytes = channel.bytes;

                long newSyscalls = channel.Syscalls - channel.lastSyscalls;
                channel.lastSyscalls = channel.Syscalls;

                long newMessages = channel.messages - channel.lastMessages;
                channel.lastMessages = channel.messages;

                long newPartials = channel.Partials - channel.lastPartials;
                channel.lastPartials = channel.Partials;

                long newErrors = channel.Errors - channel.lastErrors;
                channel.lastErrors = channel.Errors;

                double asyncTime = channel.sumAsyncTime - channel.lastSumAsyncTime;
                channel.lastSumAsyncTime = channel.sumAsyncTime;

                double handlerTime = channel.sumHandlerTime - channel.lastSumHandlerTime;
                channel.lastSumHandlerTime = channel.sumHandlerTime;

                string error = "";

                if (channel.ChannelType == ChannelType.TcpRecv)
                {
                    if (newBytes == 0 && newSyscalls == 0 && newMessages == 0) continue;
                }
                else if (channel.ChannelType == ChannelType.DblRecv || channel.ChannelType == ChannelType.UdpRecv)
                {
                    if (channel.maxHandlerTime > 0.250)
                    {
                        error = "SLOW HANDLER";
                    }

                    if (channel.maxAsyncTime > 0.250 && DataFeedChannels.ContainsKey(channel.ChannelAddr))
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

                    maxAsyncTime = Math.Max(maxAsyncTime, channel.maxAsyncTime);
                    maxHandlerTime = Math.Max(maxHandlerTime, channel.maxHandlerTime);

                    sumHandlerTime += handlerTime;
                }

                numBytes += newBytes;
                numSyscalls += newSyscalls;
                numMessages += newMessages;
                numPartials += newPartials;

                if (channel.isRecv)
                {
                    totalMsgIn += newMessages;
                    totalSysCallIn += newSyscalls;
                }
                else
                {
                    totalMsgOut += newMessages;
                    totalSysCallOut += newSyscalls;
                }

                // write channel incremental stats to log file                           

                string msg = String.Format(
                    "{0,8} {1,8:N1} {2,10:N0} {3,10:N1} {4,10:N1} {5,7:N0} {6,8:N4} {7,8:N4} {8,8:N3} {9,8:N3} {10,25} {11,25}  {12,-20}",
                    channel.ChannelType,
                    newBytes/(1024.0*1024.0),
                    newBytes/(1024.0*elapsed),
                    newSyscalls/elapsed,
                    newMessages/elapsed,
                    newPartials,
                    Math.Min(99, channel.maxAsyncTime),
                    Math.Min(99, channel.maxHandlerTime),
                    Math.Min(99, asyncTime),
                    Math.Min(99, handlerTime),
                    channel.ChannelName,
                    channel.SourceAddr,
                    error
                    );

                channel.maxAsyncTime = 0;
                channel.maxHandlerTime = 0;

                lines.Add(msg);
            }

            lines.Sort();

            lines.Insert(0,
                "--- [channel stats] ------------------------------------------------------------------------------------------------------------------------------");
            lines.Insert(1,
                " channel   mbytes   kbytes/s syscalls/s messages/s   parts  maxWait  maxProc  sumWait  sumProc             channel.label            source.address");
            lines.Insert(2,
                "--------------------------------------------------------------------------------------------------------------------------------------------------");

            lines.Add(
                "--------------------------------------------------------------------------------------------------------------------------------------------------");

            string footer = String.Format(
                "{0,8} {1,8:N1} {2,10:N0} {3,10:N1} {4,10:N1} {5,7:N0} {6,8:N4} {7,8:N4} {8,8} {9,8:N3} {10,25}",
                "TOTAL:",
                numBytes/(1024.0*1024.0),
                numBytes/(1024.0*elapsed),
                numSyscalls/elapsed,
                numMessages/elapsed,
                numPartials,
                Math.Min(99, maxAsyncTime),
                Math.Min(99, maxHandlerTime),
                "",
                Math.Min(99, sumHandlerTime),
                ""
                );

            lines.Add(footer);

            return lines;
        }

        public void CloseChannel()
        {
            if (isClosed) return;

            lock (Channels)
            {
                Channels.Remove(this);
            }

            isClosed = true;
        }

        private static async void WriteChannelStats(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
                try
                {
                    WriteChannelStats();
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "WriteChannelStats Exception");
                }
            }
        }

        public static void WriteChannelStats()
        {
            DateTime utcNow = DateTime.UtcNow;

            TimeSpan elapsed = utcNow - lastDttmUtc;

            lastDttmUtc = utcNow;

            List<Channel> localList;

            lock (Channels)
            {
                localList = new List<Channel>(Channels);
            }

            List<string> channelLines = GetChannelStats(localList, elapsed.TotalSeconds);
            List<string> messageLines = GetMessageStats(localList, elapsed.TotalSeconds);

            var lines = new List<string> {""};

            lines.AddRange(channelLines);

            lines.Add("");

            lines.AddRange(messageLines);

            lines.Add("");

            // --- write stats block ---

            SRTrace.NetChannels.TraceData(TraceEventType.Verbose, 0, lines.Cast<object>().ToArray());
        }

        public static void GetProcessStats(out long msgIn, out long msgOut, out long sysCallIn, out long sysCallOut)
        {
            msgIn = totalMsgIn - lastMsgIn;
            msgOut = totalMsgOut - lastMsgOut;
            sysCallIn = totalSysCallIn - lastSysCallIn;
            sysCallOut = totalSysCallOut - lastSysCallOut;

            lastMsgIn = totalMsgIn;
            lastMsgOut = totalMsgOut;
            lastSysCallIn = totalSysCallIn;
            lastSysCallOut = totalSysCallOut;
        }

        private sealed class MsgStats
        {
            public long Count;
            public long LastCount;
            public long TotalCount;
        }

        #region Stats by message type

        private static readonly ConcurrentDictionary<ChannelKey, MsgStats[]> StatsByChannelKey =
            new ConcurrentDictionary<ChannelKey, MsgStats[]>();

        private readonly ChannelKey key;

        private sealed class ChannelKey : IEquatable<ChannelKey>
        {
            private readonly string channelAddr;
            private readonly ChannelType channelType;

            public ChannelKey(ChannelType channelType, string channelAddr)
            {
                if (channelAddr == null) throw new ArgumentNullException("channelAddr");
                this.channelType = channelType;
                this.channelAddr = channelAddr;
            }

            public bool Equals(ChannelKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return channelType == other.channelType && string.Equals(channelAddr, other.channelAddr);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((ChannelKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) channelType*397) ^ channelAddr.GetHashCode();
                }
            }

            public static bool operator ==(ChannelKey left, ChannelKey right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ChannelKey left, ChannelKey right)
            {
                return !Equals(left, right);
            }
        }

        #endregion
    }
}