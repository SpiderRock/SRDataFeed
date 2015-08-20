using System;
using System.Diagnostics;

namespace SpiderRock.DataFeed.Diagnostics
{
    public static class SRTrace
    {
        static SRTrace()
        {
            Default = new SRTraceSource("SpiderRock");

            KeyErrors = new SRTraceSource("SpiderRock.KeyErrors");

            Monitor = new SRTraceSource("SpiderRock.Monitor");

            NetTcp = new SRTraceSource("SpiderRock.Net.TCP");
            NetDbl = new SRTraceSource("SpiderRock.Net.DBL");
            NetUdp = new SRTraceSource("SpiderRock.Net.UDP");
            NetChannels = new SRTraceSource("SpiderRock.Net.Channels");
            NetSeqNumber = new SRTraceSource("SpiderRock.Net.SeqNumber");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
        }

        public static void Flush()
        {
            Default.Flush();
            KeyErrors.Flush();
            NetTcp.Flush();
            NetUdp.Flush();
            NetDbl.Flush();
            NetChannels.Flush();
            NetSeqNumber.Flush();
            Monitor.Flush();
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
            Monitor.Listeners.Add(traceListener);
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
                Monitor.Switch = value;
            }
        }

        public static SRTraceSource Default { get; private set; }

        public static SRTraceSource KeyErrors { get; private set; }

        internal static SRTraceSource Monitor { get; private set; }

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