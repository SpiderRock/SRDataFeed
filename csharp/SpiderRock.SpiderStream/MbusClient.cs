using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream;

/// <summary>
/// Central type of tuning into SpiderRock's
/// SpiderStream (MBUS) normalized feed
/// </summary>
public sealed partial class MbusClient : IDisposable
{
    public const SysEnvironment Environment = SysEnvironment.Saturn;
    public const SysRealm Realm = SysRealm.NMS;

    readonly object syncRoot = new();
    readonly MessageCache messageCache;
    readonly Mbus.FrameHandler<MessageCache> frameHandler;
    readonly List<ChannelThreadGroup> channelThreadGroups = new();

    bool running;
    bool disposed;

    public MbusClient()
    {
        messageCache = new();
        frameHandler = new(messageCache);
        InitializeMessageEventsDispatch(messageCache);
    }

    public void AddChannelThreadGroup(params IPEndPoint[] channels) => AddChannelThreadGroup(LocalInterface, "Default", channels);

    public void AddChannelThreadGroup(string label, params IPEndPoint[] channels) => AddChannelThreadGroup(LocalInterface, label, channels);

    public void AddChannelThreadGroup(IPAddress ifAddress, params IPEndPoint[] channels) => AddChannelThreadGroup(ifAddress, "Default", channels);

    public void AddChannelThreadGroup(IPAddress ifAddress, string label, params IPEndPoint[] channels)
    {
        if (ifAddress is null)
        {
            throw new ArgumentNullException(nameof(ifAddress));
        }

        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException("Argument cannot be null or whitespace.", nameof(label));
        }

        if (channels is null)
        {
            throw new ArgumentNullException(nameof(channels));
        }

        if (channels.Length == 0)
        {
            throw new ArgumentException("Argument must be an array of non-zero length", nameof(channels));
        }

        lock (syncRoot)
        {
            if (channelThreadGroups.Any(g => g.Channels.Intersect(channels).Any()))
            {
                throw new ArgumentException("Same channel used in multiple thread groups", nameof(channels));
            }

            ChannelThreadGroup channelThreadGroup;

            if (NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(adapter => adapter.Description.StartsWith("Mellanox"))
                    .SelectMany(adapter => adapter.GetIPProperties().UnicastAddresses)
                    .Where(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Any(ip => ip.Address.Equals(ifAddress)))
            {
                channelThreadGroup = new FastSockets.MlxChannelThreadGroup<Mbus.FrameHandler<MessageCache>>(ifAddress, frameHandler, label, channels);
            }
            else
            {
                channelThreadGroup = new OSSockets.UdpChannelThreadGroup<Mbus.FrameHandler<MessageCache>>(ifAddress, frameHandler, label, channels);
            }

            channelThreadGroup.SequenceNumberGapsDetected += (sender, args) => SequenceNumberGapsDetected?.Invoke(sender, args);

            channelThreadGroups.Add(channelThreadGroup);
        }
    }

    public event EventHandler SequenceNumberGapsDetected;

    public IPAddress LocalInterface { get; init; }

    public string LogBaseDirectory { get; init; }

    public bool LogToConsole { get; init; } = true;

    public bool LogToFile { get; init; } = true;

    public string ApiKey { get; init; }

    public GCLatencyMode LatencyMode { get; init; } = GCLatencyMode.SustainedLowLatency;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Start()
    {
        lock (syncRoot)
        {
            if (running) return;

            if (channelThreadGroups.Count == 0)
            {
                throw new InvalidOperationException("No chanel thread groups have been defined");
            }

            if (!LogToConsole)
            {
                SRTrace.RemoveGlobalListenersWhere(gl => gl is SRConsoleTraceListener);
            }

            var logBaseDir = string.IsNullOrWhiteSpace(LogBaseDirectory) ? @"C:\SRLog" : LogBaseDirectory;

            if (LogToFile)
            {
                SRTrace.AddGlobalListener(new SRFileTraceListener(Environment.ToString(), new DirectoryInfo(logBaseDir)));

                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine file logging is enabled [BaseDirectory={0}]", logBaseDir);
            }
            else
            {
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine file logging is disabled");
            }

            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine console logging is {0}", LogToConsole ? "enabled" : "disabled");

            var messageTypesWithEventHandlers = messageCache.WithEventHandlers.ToArray();

            if (!messageTypesWithEventHandlers.Any())
            {
                throw new InvalidOperationException("At least one event handler needs to be subscribed");
            }

            GCSettings.LatencyMode = LatencyMode;

            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine SysEnvironment: {0}", Environment.ToString());
            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "IsServerGC: {0}", GCSettings.IsServerGC);
            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "GCLatencyMode: {0}", GCSettings.LatencyMode);
            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "Assembly: {0}", GetType().Assembly.FullName);

            var thisProcess = Process.GetCurrentProcess();

            MLink.WsBinaryClient<Mbus.FrameHandler<MessageCache>> cacheRequest = null;

            try
            {
                cacheRequest = new(
                    Environment,
                    Realm,
                    messageTypesWithEventHandlers,
                    frameHandler,
                    $"SpiderStream.C#.{thisProcess.ProcessName}.{thisProcess.Id}",
                    ApiKey);

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                Task.Run(async () => await cacheRequest.ExecuteAsync(cts.Token), cts.Token).Wait();
            }
            catch (Exception ex)
            {
                cacheRequest = null;

                SRTrace.Default.TraceError(ex, $"Cache request failed, execution will continue but it may impact the efficiency of initial message processing");
            }

            foreach (var channelThreadGroup in channelThreadGroups)
            {
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, channelThreadGroup.ToString());

                channelThreadGroup.Start();
            }

            if (cacheRequest is not null)
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
                Task.Run(async () => await cacheRequest.ExecuteAsync(cts.Token), cts.Token);
            }

            running = true;
        }
    }

    ~MbusClient()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        lock (syncRoot)
        {
            if (disposed) return;

            try
            {
                if (!disposing) return;

                foreach (var channelThreadGroup in channelThreadGroups)
                {
                    channelThreadGroup.Dispose();
                }

                //if (processStatisticsAggregator != null)
                //{
                //    processStatisticsAggregator.Dispose();
                //    processStatisticsAggregator = null;
                //}

                SRTrace.Default.TraceEvent(TraceEventType.Stop, 0, "SRDataFeedEngine stopped");
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e);
            }
            finally
            {
                disposed = true;
            }
        }
    }
}
