using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderRock.SpiderStream.Diagnostics;

public static class SRTrace
{
    private static CancellationTokenSource aggregateEventCancellationTokenSource;
    private static TimeSpan aggregateEventFrequency;
    private static readonly HashSet<TraceListener> GlobalTraceListenerSet = new();

    static SRTrace()
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

        AggregateEventFrequency = TimeSpan.FromMinutes(1);

        Trace.AutoFlush = true;

        GlobalSwitch = new SourceSwitch("SRTraceSource (All)") { Level = SourceLevels.All };
        AddGlobalListener(new SRConsoleTraceListener());
    }

    private static async Task FireAggregate(TimeSpan freq, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid();

        SRTrace.Default.TraceDebug($"{nameof(SRTrace)}: {nameof(FireAggregate)} task {guid} running [freq={freq}]");

        try
        {
            var timer = Stopwatch.StartNew();

            await Task.Delay(freq, cancellationToken);

            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var @delegate in Aggregate.GetInvocationList())
                {
                    var handler = (Action<double>)@delegate;
                    try
                    {
                        handler(timer.Elapsed.TotalSeconds);
                    }
                    catch (Exception e)
                    {
                        Default.TraceError(e);
                    }
                }

                timer.Restart();

                await Task.Delay(freq, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (ObjectDisposedException)
        {
        }
        catch(Exception e)
        {
            SRTrace.Default.TraceError(e, $"{nameof(SRTrace)}: {nameof(FireAggregate)} task {guid} failed [freq={freq}]");
        }
        finally
        {
            SRTrace.Default.TraceDebug($"{nameof(SRTrace)}: {nameof(FireAggregate)} task {guid} exited [freq={freq}]");
        }
    }

    public static TimeSpan AggregateEventFrequency
    {
        get { return aggregateEventFrequency; }
        set
        {
            var cur = new CancellationTokenSource();
            Interlocked.Exchange(ref aggregateEventCancellationTokenSource, cur)?.Cancel(true);
            Task.Run(async () => await FireAggregate(aggregateEventFrequency = value, cur.Token), cur.Token);
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
            Net.MLink.Listeners.Add(traceListener);
            Net.UDP.Sockets.Listeners.Add(traceListener);
            Net.UDP.FastSockets.Listeners.Add(traceListener);
            Net.Channels.Listeners.Add(traceListener);
            Net.Latency.Listeners.Add(traceListener);
            Net.SeqNumber.Listeners.Add(traceListener);
            Net.JumboFrames.Listeners.Add(traceListener);
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
            Net.MLink.Listeners.Remove(traceListener);
            Net.UDP.Sockets.Listeners.Remove(traceListener);
            Net.UDP.FastSockets.Listeners.Remove(traceListener);
            Net.Channels.Listeners.Remove(traceListener);
            Net.Latency.Listeners.Remove(traceListener);
            Net.SeqNumber.Listeners.Remove(traceListener);
            Net.JumboFrames.Listeners.Remove(traceListener);
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
            Net.MLink.Switch = value;
            Net.UDP.Sockets.Switch = value;
            Net.UDP.FastSockets.Switch = value;
            Net.Channels.Switch = value;
            Net.Latency.Switch = value;
            Net.SeqNumber.Switch = value;
            Net.JumboFrames.Switch = value;
            Process.Switch = value;
        }
    }

    public static class Net
    {
        public static SRTraceSource MLink { get; } = new("SpiderRock.Net.TCP");
        public static SRTraceSource Channels { get; } = new("SpiderRock.Net.Channels");
        public static SRTraceSource Latency { get; } = new("SpiderRock.Net.Latency");
        public static SRTraceSource SeqNumber { get; } = new("SpiderRock.Net.SeqNumber");
        public static SRTraceSource JumboFrames { get; } = new("SpiderRock.Net.JumboFrames");

        public static class UDP
        {
            public static SRTraceSource FastSockets { get; } = new("SpiderRock.Net.UDP.FastSockets");
            public static SRTraceSource Sockets { get; } = new("SpiderRock.Net.UDP.Sockets");
        }
    }

    public static SRTraceSource Default { get; } = new("SpiderRock");
    public static SRTraceSource KeyErrors { get; } = new("SpiderRock.KeyErrors");
    public static SRTraceSource Process { get; } = new("SpiderRock.Process");

    private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        Default.TraceEvent(args.IsTerminating ? TraceEventType.Critical : TraceEventType.Error, 0, args.ExceptionObject.ToString());
        Default.Flush();
    }
}
