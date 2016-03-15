using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderRock.DataFeed.Diagnostics
{
    public static class SRTrace
    {
        private static CancellationTokenSource aggregateEventCancellationTokenSource;
        private static TimeSpan aggregateEventFrequency;
        private static readonly HashSet<TraceListener> GlobalTraceListenerSet = new HashSet<TraceListener>();

        static SRTrace()
        {
            Default = new SRTraceSource("SpiderRock");

            KeyErrors = new SRTraceSource("SpiderRock.KeyErrors");

            Process = new SRTraceSource("SpiderRock.Process");

            NetTcp = new SRTraceSource("SpiderRock.Net.TCP");
            NetDbl = new SRTraceSource("SpiderRock.Net.DBL");
            NetUdp = new SRTraceSource("SpiderRock.Net.UDP");
            NetChannels = new SRTraceSource("SpiderRock.Net.Channels");
            NetLatency = new SRTraceSource("SpiderRock.Net.Latency");
            NetSeqNumber = new SRTraceSource("SpiderRock.Net.SeqNumber");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            AggregateEventFrequency = TimeSpan.FromMinutes(1);

            Trace.AutoFlush = true;

            GlobalSwitch = new SourceSwitch("SRTraceSource (All)") {Level = SourceLevels.All};
            AddGlobalListener(new SRConsoleTraceListener());
        }

        private static async void FireAggregate(CancellationToken cancellationToken)
        {
            // ReSharper disable once EmptyGeneralCatchClause
            try
            {
                var timer = new Stopwatch();

                while (!cancellationToken.IsCancellationRequested)
                {
                    timer.Restart();

                    await Task.Delay(AggregateEventFrequency, cancellationToken);

                    foreach (var aggregate in Aggregate.GetInvocationList())
                    {
                        var handler = (Action<double>) aggregate;
                        try
                        {
                            handler(timer.Elapsed.TotalSeconds);
                        }
                        catch (Exception e)
                        {
                            Default.TraceError(e);
                        }
                    }
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch
            {
            }
        }

        public static TimeSpan AggregateEventFrequency
        {
            get { return aggregateEventFrequency; }
            set
            {
                if (aggregateEventCancellationTokenSource != null)
                {
                    aggregateEventCancellationTokenSource.Cancel();
                }
                aggregateEventCancellationTokenSource = new CancellationTokenSource();
                aggregateEventFrequency = value;
                FireAggregate(aggregateEventCancellationTokenSource.Token);
            }
        }

        public static event Action<double> Aggregate = delegate { }; 

        public static void AddGlobalListener(TraceListener traceListener)
        {
            lock (GlobalTraceListenerSet)
            {
                if (!GlobalTraceListenerSet.Add(traceListener)) return;

                Default.Listeners.Add(traceListener);
                KeyErrors.Listeners.Add(traceListener);
                NetTcp.Listeners.Add(traceListener);
                NetUdp.Listeners.Add(traceListener);
                NetDbl.Listeners.Add(traceListener);
                NetChannels.Listeners.Add(traceListener);
                NetLatency.Listeners.Add(traceListener);
                NetSeqNumber.Listeners.Add(traceListener);
                Process.Listeners.Add(traceListener);
            }
        }

        public static void RemoveGlobalListener(TraceListener traceListener)
        {
            lock (GlobalTraceListenerSet)
            {
                if (!GlobalTraceListenerSet.Remove(traceListener)) return;

                Default.Listeners.Remove(traceListener);
                KeyErrors.Listeners.Remove(traceListener);
                NetTcp.Listeners.Remove(traceListener);
                NetUdp.Listeners.Remove(traceListener);
                NetDbl.Listeners.Remove(traceListener);
                NetChannels.Listeners.Remove(traceListener);
                NetLatency.Listeners.Remove(traceListener);
                NetSeqNumber.Listeners.Remove(traceListener);
                Process.Listeners.Remove(traceListener);
            }
        }

        public static void RemoveGlobalListenersWhere(Func<TraceListener, bool> predicate)
        {
            lock (GlobalTraceListenerSet)
            {
                foreach (var globalTraceListener in GlobalListeners)
                {
                    if (predicate(globalTraceListener))
                    {
                        RemoveGlobalListener(globalTraceListener);
                    }
                }
            }
        }

        public static TraceListener[] GlobalListeners
        {
            get
            {
                lock (GlobalTraceListenerSet)
                {
                    return GlobalTraceListenerSet.ToArray();
                }
            }
        }

        public static SourceSwitch GlobalSwitch
        {
            set
            {
                Default.Switch = value;
                KeyErrors.Switch = value;
                NetTcp.Switch = value;
                NetUdp.Switch = value;
                NetDbl.Switch = value;
                NetChannels.Switch = value;
                NetLatency.Switch = value;
                NetSeqNumber.Switch = value;
                Process.Switch = value;
            }
        }

        public static SRTraceSource Default { get; private set; }

        public static SRTraceSource KeyErrors { get; private set; }

        internal static SRTraceSource Process { get; private set; }

        public static SRTraceSource NetTcp { get; private set; }
        public static SRTraceSource NetDbl { get; private set; }
        internal static SRTraceSource NetUdp { get; private set; }
        public static SRTraceSource NetChannels { get; private set; }
        public static SRTraceSource NetLatency { get; private set; }
        public static SRTraceSource NetSeqNumber { get; private set; }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Default.TraceEvent(args.IsTerminating ? TraceEventType.Critical : TraceEventType.Error, 0, args.ExceptionObject.ToString());
            Default.Flush();
        }
    }
}