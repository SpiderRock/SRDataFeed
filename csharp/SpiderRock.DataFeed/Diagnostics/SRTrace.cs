using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderRock.DataFeed.Diagnostics
{
    public static class SRTrace
    {
        private static CancellationTokenSource aggregateEventCancellationTokenSource;
        private static TimeSpan aggregateEventFrequency;

        static SRTrace()
        {
            Default = new SRTraceSource("SpiderRock");

            KeyErrors = new SRTraceSource("SpiderRock.KeyErrors");

            Process = new SRTraceSource("SpiderRock.Process");

            NetTcp = new SRTraceSource("SpiderRock.Net.TCP");
            NetDbl = new SRTraceSource("SpiderRock.Net.DBL");
            NetUdp = new SRTraceSource("SpiderRock.Net.UDP");
            NetChannels = new SRTraceSource("SpiderRock.Net.Channels");
            NetSeqNumber = new SRTraceSource("SpiderRock.Net.SeqNumber");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            AutoFlush(CancellationToken.None);

            AggregateEventFrequency = TimeSpan.FromMinutes(1);
        }

        private static async void AutoFlush(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, cancellationToken);

                    Flush();
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception e)
            {
                Default.TraceError(e);
                Default.Flush();
            }
        }

        private static async void FireAggregate(CancellationToken cancellationToken)
        {
            try
            {
                var timer = new Stopwatch();

                while (!cancellationToken.IsCancellationRequested)
                {
                    timer.Restart();

                    await Task.Delay(AggregateEventFrequency, cancellationToken);

                    Aggregate(timer.Elapsed.TotalSeconds);
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception e)
            {
                Default.TraceError(e);
                Default.Flush();
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

        public static void Flush()
        {
            Default.Flush();
            KeyErrors.Flush();
            NetTcp.Flush();
            NetUdp.Flush();
            NetDbl.Flush();
            NetChannels.Flush();
            NetSeqNumber.Flush();
            Process.Flush();
        }

        public static void AddGlobalTraceListener(TraceListener traceListener)
        {
            Default.Listeners.Add(traceListener);
            KeyErrors.Listeners.Add(traceListener);
            NetTcp.Listeners.Add(traceListener);
            NetUdp.Listeners.Add(traceListener);
            NetDbl.Listeners.Add(traceListener);
            NetChannels.Listeners.Add(traceListener);
            NetSeqNumber.Listeners.Add(traceListener);
            Process.Listeners.Add(traceListener);
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
        public static SRTraceSource NetSeqNumber { get; private set; }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Default.TraceEvent(args.IsTerminating ? TraceEventType.Critical : TraceEventType.Error, 0, args.ExceptionObject.ToString());
            Default.Flush();
        }
    }
}