using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Threading;
using SpiderRock.DataFeed.Cache;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Proto.DBL;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Proto.UDP;

namespace SpiderRock.DataFeed
{
    /// <summary>
    /// Represents the data source of market 
    /// </summary>
    public sealed partial class SRDataFeedEngine : IDisposable
    {
        private readonly object startLock = new object();
        private readonly object disposeLock = new object();
        private readonly CancellationTokenSource disposeTokenSource;
        private readonly List<DblManager> dblManagers = new List<DblManager>();
        private UdpManager udpManager;
        private bool running;
        private bool disposed;
        private FrameHandler frameHandler;
        private readonly ChannelFactory channelFactory;

        private ChannelStatisticsAggregator channelStatisticsAggregator;
        private ProcessStatisticsAggregator processStatisticsAggregator;

        public SRDataFeedEngine()
        {
            SysEnvironment = SysEnvironment.Beta;
            disposeTokenSource = new CancellationTokenSource();
            ReceiveBufferSize = 20*1024*1024; // 20MB default
            LatencyMode = GCLatencyMode.SustainedLowLatency;

            channelFactory = new ChannelFactory();

            InitializeFrameHandler();
        }

        private void OnChannelCreated(object sender, ChannelCreatedEventArgs args)
        {
            channelStatisticsAggregator.Register(args.Channel);
            var channel = args.Channel;
            channel.SequenceNumberGapsDetected += OnChannelSequenceNumberGapsDetected;
            channel.Closed += (s, a) => channel.SequenceNumberGapsDetected -= OnChannelSequenceNumberGapsDetected;
        }

        private void OnChannelSequenceNumberGapsDetected(object sender, EventArgs args)
        {
            var handler = SequenceNumberGapsDetected;
            if (handler == null) return;
            handler(sender, args);
        }

        public event EventHandler SequenceNumberGapsDetected;

        public DblChannelThreadGroup[] DblChannelThreadGroups { get; set; }

        public SysEnvironment SysEnvironment { get; set; }

        public IPAddress IFAddress { get; set; }

        public UdpChannel[] Channels { get; set; }

        public Protocol Protocol { get; set; }

        /// <summary>
        /// Size of the UDP receive buffer.  Set to 20MB by default.
        /// </summary>
        /// <remarks>
        /// 20MB is an estimate based on (20K pkts/s * 1500 MTU * 5 seconds) / 10 msgs/s
        /// plus some slack
        /// </remarks>
        public int ReceiveBufferSize { get; set; }

        public GCLatencyMode LatencyMode { get; set; }

        public IEnumerable<IPEndPoint> CacheServers
        {
            get
            {
                var cacheServerPort = 2340 + ((int) SysEnvironment*1000);
                yield return new IPEndPoint(IPAddress.Parse("198.102.4.145"), cacheServerPort);
                yield return new IPEndPoint(IPAddress.Parse("198.102.4.146"), cacheServerPort);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Start()
        {
            lock (startLock)
            {
                if (running) return;

                if (SysEnvironment == SysEnvironment.None)
                {
                    throw new InvalidOperationException("Required SysEnvironment property set to an invalid value None");
                }

                if (IFAddress == null)
                {
                    throw new InvalidOperationException("Required IFAddress property not set");
                }

                Channels = Channels ?? new UdpChannel[0];
                DblChannelThreadGroups = DblChannelThreadGroups ?? new DblChannelThreadGroup[0];

                if (Channels.Length == 0 && DblChannelThreadGroups.Length == 0)
                {
                    throw new InvalidOperationException("No channels are configured");
                }

                SRFileTraceListener.SysEnvironment = SysEnvironment;

                GCSettings.LatencyMode = LatencyMode;

                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine SysEnvironment: {0}", SysEnvironment);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine IFAddress: {0}", IFAddress);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Cache servers: {0}", string.Join(", ", CacheServers.Select(ep => ep.ToString())));
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine ReceiveBufferSize: {0}", ReceiveBufferSize);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "IsServerGC: {0}", GCSettings.IsServerGC);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "GCLatencyMode: {0}", GCSettings.LatencyMode);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "Assembly: {0}", GetType().Assembly.FullName);

                processStatisticsAggregator = new ProcessStatisticsAggregator();

                InitializeChannelStatsAggregator();

                ClearContainerCaches();

                Channels = Channels.Except(DblChannelThreadGroups.SelectMany(g => g)).Distinct().ToArray();

                if (Channels.Length > 0)
                {
                    if (Protocol == Protocol.DBL)
                    {
                        var dblManager = new DblManager(IFAddress, "Default", channelFactory);
                        dblManagers.Add(dblManager);

                        foreach (UdpChannel udpChannel in Channels)
                        {
                            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Channel: {0}",
                                udpChannel);
                            dblManager.AddListener(GetIPEndPoint(udpChannel), frameHandler);
                        }
                    }
                    else
                    {
                        udpManager = new UdpManager(IFAddress, ReceiveBufferSize, channelFactory);

                        foreach (UdpChannel udpChannel in Channels)
                        {
                            SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Channel: {0}",
                                udpChannel);
                            udpManager.AddListener(GetIPEndPoint(udpChannel), frameHandler);
                        }
                    }
                }

                foreach (var channelThreadGroup in DblChannelThreadGroups)
                {
                    var dblManager = new DblManager(IFAddress, channelThreadGroup.ToString(), channelFactory);
                    dblManagers.Add(dblManager);

                    foreach (UdpChannel udpChannel in channelThreadGroup.Distinct())
                    {
                        SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Channel: {0}", udpChannel);
                        dblManager.AddListener(GetIPEndPoint(udpChannel), frameHandler);
                    }
                }

                running = true;
            }
        }

        public void StartWith(params MessageType[] requestList)
        {
            Start();

            if (!GetCachedMessages(requestList))
            {
                throw new TimeoutException("Cache request timed out");
            }
        }

        public void StartWith(TimeSpan timeout, params MessageType[] requestList)
        {
            Start();

            if (!GetCachedMessages(timeout, requestList))
            {
                throw new TimeoutException("Cache request timed out");
            }
        }

        private CacheClient ConnectToCacheServer()
        {
            var cacheServers = CacheServers.ToArray();

            foreach (var cacheServerEndPoint in cacheServers)
            {
                var client = new CacheClient(cacheServerEndPoint, frameHandler, channelFactory);
                try
                {
                    client.Connect();
                    return client;
                }
                catch (Exception)
                {
                    SRTrace.Default.TraceWarning("Could not connect to cache server at {0}", cacheServerEndPoint);
                    client.Dispose();
                }
            }

            var cacheServerList = string.Join(", ", cacheServers.Select(ep => ep.ToString()));

            var errorMessage = string.Format("Cache server(s) [{0}] unavailable", cacheServerList);

            SRTrace.Default.TraceError(errorMessage);

            throw new CacheRequestException(errorMessage);
        }

        public bool GetCachedMessages(params MessageType[] requestList)
        {
            return GetCachedMessages(TimeSpan.FromMinutes(5), requestList);
        }

        public bool GetCachedMessages(TimeSpan timeout, params MessageType[] requestList)
        {
            var timeoutTokenSource = new CancellationTokenSource(timeout);

            SRTrace.Default.TraceDebug("SRDataFeedEngine: initiating remote cache request for: {0}",
                string.Join(", ", requestList.Select(t => t.ToString())));

            var disposedOrTimedout = CancellationTokenSource.CreateLinkedTokenSource(disposeTokenSource.Token, timeoutTokenSource.Token);

            InitializeChannelStatsAggregator();

            using (var cacheClient = ConnectToCacheServer())
            {
                cacheClient.Connect();

                var timer = Stopwatch.StartNew();

                cacheClient.SendRequest(requestList);
                cacheClient.ReadResponse(disposedOrTimedout.Token);

                channelStatisticsAggregator.Flush(timer.Elapsed.TotalSeconds);
            }

            SRTrace.Default.TraceDebug("SRDataFeedEngine: cache request completed");

            return !timeoutTokenSource.IsCancellationRequested;
        }

        private void InitializeChannelStatsAggregator()
        {
            if (channelStatisticsAggregator == null)
            {
                channelStatisticsAggregator = new ChannelStatisticsAggregator();
                channelFactory.ChannelCreated += OnChannelCreated;
            }
        }

        private IPEndPoint GetIPEndPoint(UdpChannel channel)
        {
            int envNumber = 30 + (int) SysEnvironment;
            int channelNumber = (int) channel;

            int ipPort = 40000 + (envNumber*500) + channelNumber;

            string ipAddress;

            if (SysEnvironment == SysEnvironment.Stable)
            {
                ipAddress = string.Format("233.74.249.{0}", channelNumber);
            }
            else if (SysEnvironment == SysEnvironment.Beta)
            {
                ipAddress = string.Format("233.117.185.{0}", channelNumber);
            }
            else
            {
                throw new NotSupportedException(
                    string.Format("GetIPEndPoint() does not support SysEnvironment {0}",
                        SysEnvironment));
            }

            return new IPEndPoint(IPAddress.Parse(ipAddress), ipPort);
        }

        ~SRDataFeedEngine()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            lock (disposeLock)
            {
                if (disposed) return;

                try
                {
                    disposeTokenSource.Cancel();
                    if (!disposing) return;

                    channelFactory.ChannelCreated -= OnChannelCreated;

                    if (udpManager != null)
                    {
                        udpManager.Dispose();
                    }

                    foreach (var dblManager in dblManagers)
                    {
                        dblManager.Dispose();
                    }

                    if (processStatisticsAggregator != null)
                    {
                        processStatisticsAggregator.Dispose();
                        processStatisticsAggregator = null;
                    }

                    if (channelStatisticsAggregator != null)
                    {
                        channelStatisticsAggregator.Dispose();
                        channelStatisticsAggregator = null;
                    }

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
}