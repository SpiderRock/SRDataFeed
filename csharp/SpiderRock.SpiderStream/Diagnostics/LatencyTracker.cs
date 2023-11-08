using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.Diagnostics;

public class LatencyTracker : IDisposable
{
    readonly SRTraceSource source;

    public LatencyTracker(SRTraceSource source = default)
    {
        this.source = source ?? SRTrace.Net.Latency;

        SRTrace.Aggregate += LogTable;
    }

    private void LogTable(double elapsed)
    {
        var stats = Statistics.Rotate();

        Task.Run(() =>
        {
            source.TraceData(
                TraceEventType.Verbose,
                0,
                LatenciesTable.Render(stats)
                    .Prepend("")
                    .Append("")
                    .Cast<object>()
                    .ToArray()
                );
        });
    }

    public void Track<TMessage>(IMessageEvents<TMessage> events) where TMessage : IMessage
        => Track<TMessage>(events, TimeSpan.FromMilliseconds(10));

    public void Track<TMessage>(IMessageEvents<TMessage> events, TimeSpan samplingFrequency, Func<TMessage, long> getTimeRcvd = null, Func<TMessage, long> getTimeSent = null) where TMessage : IMessage
    {
        var messageType = events.Type;

        SRTrace.Net.Latency.TraceInfo($"{nameof(LatencyTracker)}: tracking latency for {messageType}, sampling every {samplingFrequency}");

        events.Changed += [MethodImpl(MethodImplOptions.AggressiveOptimization)] (sender, args) =>
        {
            var changed = args.Changed;

            if (changed.ReceivedNsecsSinceUnixEpoch == 0)
            {
                return;
            }

            if (changed.FromCache)
            {
                return;
            }

            var timeRcvd = getTimeRcvd is null ? changed.ReceivedNsecsSinceUnixEpoch : getTimeRcvd(changed);
            var timeSent = getTimeSent is null ? changed.PublishedNsecsSinceUnixEpoch : getTimeSent(changed);

            try
            {
                Statistics
                    .GetCreate(messageType, args.Channel, samplingFrequency, SRTrace.AggregateEventFrequency, false)
                    .AddObservation(timeRcvd, timeSent);
            }
            catch (InvalidOperationException)
            {
                Statistics
                    .GetCreate(messageType, args.Channel, samplingFrequency, SRTrace.AggregateEventFrequency, true)
                    .AddObservation(timeRcvd, timeSent);
            }
        };
    }

    public void Dispose()
    {
        SRTrace.Aggregate -= LogTable;
        GC.SuppressFinalize(this);
    }

    private class LatenciesTable
    {
        const string Units = " (µs)";
        const double NsecsInUnit = 1_000;

        static readonly string TableHeader;
        static readonly string TableTitle;
        static readonly string TableSeparator;
        static readonly string TableRowFormatString;

        static LatenciesTable()
        {
            var columns = new[]
            {
                (name: "type / channel", width: -75, format: ""),
                (name: "mean" + Units, width: 15, format: "N0"),
                (name: "stdDev" + Units, width: 15, format: "N0"),
                (name: "50th %" + Units, width: 20, format: "N0"),
                (name: "75th %" + Units, width: 20, format: "N0"),
                (name: "90th %" + Units, width: 20, format: "N0"),
                (name: "95th %" + Units, width: 20, format: "N0"),
                (name: "99th %" + Units, width: 20, format: "N0"),
                (name: "min" + Units, width: 15, format: "N3"),
                (name: "max" + Units, width: 15, format: "N0"),
                (name: "# data points", width: 15, format: "N0"),
                (name: "# neg latencies", width: 17, format: "N0")
            };

            TableRowFormatString = string.Join("",
                Enumerable
                    .Range(0, columns.Length)
                    .Select(i => "{" + i + "," + columns[i].width + (string.IsNullOrWhiteSpace(columns[i].format) ? "" : ":" + columns[i].format) + "}"));

            TableHeader = string.Format(
                string.Join("",
                    Enumerable
                        .Range(0, columns.Length)
                        .Select(i => "{" + i + "," + columns[i].width + "}")),
                columns.Select(c => c.name).ToArray());

            TableTitle = "--- [channel latency] ".PadRight(TableHeader.Length, '-');

            TableSeparator = new string('-', TableHeader.Length);
        }

        public static IEnumerable<string> Render(IEnumerable<Statistics> statistics)
        {
            var renderHeader = true;
            var renderFooter = false;

            foreach (var line in ParallelEnumerable
                .Select(statistics.AsParallel(), RenderRow)
                .OrderBy(_ => _))
            {
                if (renderHeader)
                {
                    renderHeader = false;

                    yield return TableTitle;
                    yield return TableHeader;
                    yield return TableSeparator;
                }

                renderFooter = true;

                yield return line;
            }

            if (renderFooter)
            {
                yield return TableSeparator;
            }
        }

        private static string RenderRow(Statistics stats)
        {
            // this causes an InvalidOperationException to be thrown
            // in AddObservation() which is a trigger
            // for the higher level logic to replace the statistics
            // vector
            stats.LockObservations();

            var latencies = ArrayPool<double>.Shared.Rent(stats.Count);

            try
            {
                stats.CopyTo(latencies);
                stats.Dispose();

                var count = stats.Count;

                for (int i = 0; i < count; i++)
                {
                    latencies[i] /= NsecsInUnit;
                }

                Array.Sort(latencies, 0, count);

                var min = latencies[0];
                var max = latencies[count - 1];
                var negCount = latencies.Take(count).Count(l => l < 0);

                var meanLatency = latencies.Take(count).Sum(l => l) / count;
                var stdDev = Math.Pow(latencies.Take(count).Sum(l => Math.Pow(l - meanLatency, 2)) / (count - 1), 0.5);

                return string.Format(TableRowFormatString,
                    $"{stats.Type} / {stats.Channel.Name}",

                    meanLatency,
                    stdDev,

                    latencies[(int)(0.50 * count)],
                    latencies[(int)(0.75 * count)],
                    latencies[(int)(0.90 * count)],
                    latencies[(int)(0.95 * count)],
                    latencies[(int)(0.99 * count)],

                    min,
                    max,

                    count,
                    negCount
                    );
            }
            finally
            {
                ArrayPool<double>.Shared.Return(latencies);
            }
        }
    }

    class Statistics : IDisposable
    {
        [ThreadStatic] private static Dictionary<(MessageType, Channel), Statistics> Instances;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Statistics GetCreate(MessageType messageType, Channel channel, TimeSpan samplingFrequency, TimeSpan aggregateFrequency, bool forceCreate = false)
        {
            Instances ??= new();

            var key = (messageType, channel);

            if (Instances.TryGetValue(key, out var stats) && !forceCreate)
            {
                return stats;
            }

            stats?.Dispose();

            Instances[key] = stats = new(messageType, channel, samplingFrequency, aggregateFrequency);

            Instances.TrimExcess();

            return stats;
        }

        static List<Statistics> instances = new();

        public static IEnumerable<Statistics> Rotate() => Interlocked.Exchange(ref instances, new());

        readonly IMemoryOwner<(long recvNsecs, long sentNsecs, long latencyNsecs)> memory;
        readonly Memory<(long recvNsecs, long sentNsecs, long latencyNsecs)> timeSeries;
        readonly long samplingFrequency;
        readonly int capacity;

        int index;
        long nextThreshold;
        bool isDisposed;
        bool isLocked;

        public Statistics(MessageType messageType, Channel channel, TimeSpan samplingFrequency, TimeSpan aggregateFrequency)
        {
            capacity = Math.Min((int)(aggregateFrequency.Ticks / samplingFrequency.Ticks), 10001);
            memory = MemoryPool<(long recvNsecs, long sentNsecs, long latencyNsecs)>.Shared.Rent(capacity);
            timeSeries = memory.Memory;
            Type = messageType;
            Channel = channel;
            this.samplingFrequency = samplingFrequency.Ticks;

            instances.Add(this);
        }

        public MessageType Type { get; }

        public Channel Channel { get; }

        public int Count => index;

        public void LockObservations()
        {
            lock (this)
            {
                isLocked = true;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddObservation(long recvNsecs, long sentNsecs)
        {
            lock (this)
            {
                if (isLocked)
                {
                    throw new InvalidOperationException($"{nameof(Statistics)} have been locked");
                }

                if (isDisposed)
                {
                    throw new ObjectDisposedException(nameof(Statistics));
                }

                var latencyNsecs = recvNsecs - sentNsecs;

                var ts = Stopwatch.GetTimestamp();

                if (ts < nextThreshold)
                {
                    return;
                }

                timeSeries.Span[index] = (recvNsecs, sentNsecs, latencyNsecs);

                index = (index + 1) % capacity;

                nextThreshold = ts + samplingFrequency;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (!isDisposed)
                {
                    memory.Dispose();

                    isDisposed = true;
                }
            }
        }

        ~Statistics()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void CopyTo(double[] latencies)
        {
            var timeSeriesSpan = timeSeries.Span;

            for (int i = 0; i < Count; i++)
            {
                latencies[i] = timeSeriesSpan[i].latencyNsecs;
            }
        }
    }
}
