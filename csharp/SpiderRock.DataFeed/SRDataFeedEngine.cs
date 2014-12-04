using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SpiderRock.DataFeed.Cache;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Proto.DBL;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed
{
    /// <summary>
    /// Represents the data source of market 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public sealed partial class SRDataFeedEngine : IDisposable
    {
        private readonly object startLock = new object();
        private readonly object disposeLock = new object();
        private readonly CancellationTokenSource disposeTokenSource;
        private readonly List<DblManager> dblManagers = new List<DblManager>();
        private bool running;
        private bool disposed;
        private FrameHandler frameHandler;

        public SRDataFeedEngine()
        {
            SysEnvironment = SysEnvironment.Stable;
            disposeTokenSource = new CancellationTokenSource();
        }

        public UdpChannelThreadGroup[] ChannelThreadGroups { get; set; }

        public SysEnvironment SysEnvironment { get; set; }

        public IPAddress IFAddress { get; set; }

        public UdpChannel[] Channels { get; set; }

        public string CacheHost { get; set; }

        public int CachePort { get; set; }

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
                ChannelThreadGroups = ChannelThreadGroups ?? new UdpChannelThreadGroup[0];

                if (Channels.Length == 0 && ChannelThreadGroups.Length == 0)
                {
                    throw new InvalidOperationException("No channels are configured");
                }

                SRFileTraceListener.SysEnvironment = SysEnvironment;

                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine SysEnvironment: {0}", SysEnvironment);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine IFAddress: {0}", IFAddress);
                SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Cache: {0}:{1}", CacheHost,
                    CachePort);

                InitializeFrameHandler();

                Channels = Channels.Except(ChannelThreadGroups.SelectMany(g => g)).Distinct().ToArray();

                DblManager dblManager;

                if (Channels.Length > 0)
                {
                    dblManager = new DblManager(IFAddress, "Default");
                    dblManagers.Add(dblManager);

                    foreach (UdpChannel udpChannel in Channels)
                    {
                        SRTrace.Default.TraceEvent(TraceEventType.Start, 0, "SRDataFeedEngine Channel: {0}", udpChannel);
                        dblManager.AddListener(GetIPEndPoint(udpChannel), frameHandler);
                    }
                }

                foreach (var channelThreadGroup in ChannelThreadGroups)
                {
                    dblManager = new DblManager(IFAddress, channelThreadGroup.ToString());
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

        private static IPAddress ResolveCacheHost(string hostname)
        {
            if (string.IsNullOrWhiteSpace(hostname)) return null;

            IPAddress address;
            if (IPAddress.TryParse(hostname, out address)) return address;

            address = Dns
                .GetHostEntry(hostname)
                .AddressList
                .First(addr => addr.AddressFamily == AddressFamily.InterNetwork);

            return address;
        }

        public bool GetCachedMessages(TimeSpan timeout, params MessageType[] requestList)
        {
            if (!running)
            {
                throw new InvalidOperationException("Engine has not been started with Start()");
            }

            IPAddress address = ResolveCacheHost(CacheHost);

            if (address == null)
            {
                throw new InvalidOperationException("CacheHost has not been configured");
            }

            if (CachePort <= 0)
            {
                throw new InvalidOperationException("CachePort has not been set configured");
            }

            var endPoint = new IPEndPoint(address, CachePort);

            var timeoutTokenSource = new CancellationTokenSource(timeout);

            SRTrace.Default.TraceDebug("SRDataFeedEngine: initiating remote cache request for: {0}",
                string.Join(", ", requestList.Select(t => t.ToString())));

            var disposedOrTimedout = CancellationTokenSource.CreateLinkedTokenSource(disposeTokenSource.Token, timeoutTokenSource.Token);

            using (var cacheClient = new CacheClient(endPoint, frameHandler))
            {
                cacheClient.Connect();
                cacheClient.SendRequest(requestList);
                cacheClient.ReadResponse(disposedOrTimedout.Token);

                Channel.WriteChannelStats();
            }

            SRTrace.Default.TraceDebug("SRDataFeedEngine: cache request completed");

            return !timeoutTokenSource.IsCancellationRequested;
        }

        private IPEndPoint GetIPEndPoint(UdpChannel channel)
        {
            return new IPEndPoint(
                IPAddress.Parse(string.Format("233.74.249.{0}", (int) channel)),
                40000 + ((30 + (int) SysEnvironment)*500) + (int) channel);
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

                    foreach (var dblManager in dblManagers)
                    {
                        dblManager.Dispose();
                    }
                    SRTrace.Default.TraceEvent(TraceEventType.Stop, 0, "SRDataFeedEngine stopped");
                    SRTrace.Flush();
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