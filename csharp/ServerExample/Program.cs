#define MULTI_CHANNEL_THREAD_GROUPS
#define TRACK_LATENCIES

using System;
using System.Net;
using SpiderRock.SpiderStream;
using SpiderRock.SpiderStream.Diagnostics;

namespace ServerExample;

internal class Program
{
    private static void Main()
    {
        MbusClient mbusClient = null;

        try
        {
            /////////////////////////////////////////////
            // Instantiate and configure a MBUS client

            mbusClient = new MbusClient
            {
                // if set, will be implicitly used when creating channel thread groups
                LocalInterface = IPAddress.Parse("NIC_IPv4_ADDRESS"),

                //////////////////////////////////////////////////////////
                // Cache requests

                // SpiderRock will assign you an API key to use for
                // retrieving cache data (late joins).  If cache data is
                // unavailable processing will continue with a 30 second delay
                ApiKey = "ASSIGNED_API_KEY",

                //////////////////////////////////////////////////////////
                // Logging

                // Default: LogBaseDirectory = @"C:\SRLog"
                // Default: LogToConsole = true

                //////////////////////////////////////////////////////////
                // Performance tuning 

                // For maximum performance, we recommend the following settings:

                // in runtimeconfig.template.json (preset this way for this project):

                //  "configProperties": {
                //      "System.GC.Server": true,
                //      "System.GC.HeapCount": 12,
                //      "System.GC.CpuGroup":  true
                //  }

                // LatencyMode = GCLatencyMode.SustainedLowLatency (default)
            };

            //////////////////////////////////////////////////////////
            // Parallel processing / load distribution

            // MbusClient allows for sets of mutually exclusive channels to be
            // assigned to a worker thread which is termed a channel thread group.
            // The MbusClient.AddChannelThreadGroup(...) method overloads
            // are the mechanism for doing so

#if MULTI_CHANNEL_THREAD_GROUPS
            mbusClient.AddChannelThreadGroup("Opt/Stk[ABCD]",
                 MbusChannel.OptNbboQuoteA,
                 MbusChannel.OptNbboQuoteB,
                 MbusChannel.OptNbboQuoteC,
                 MbusChannel.OptNbboQuoteD,
                 MbusChannel.StkNbboQuoteABCD);

            mbusClient.AddChannelThreadGroup("Opt/Stk[EFGH]",
                MbusChannel.OptNbboQuoteE,
                MbusChannel.OptNbboQuoteF,
                MbusChannel.OptNbboQuoteG,
                MbusChannel.OptNbboQuoteH,
                MbusChannel.StkNbboQuoteEFGH);

            mbusClient.AddChannelThreadGroup("Opt[MTX]",
                MbusChannel.OptNbboQuoteM,
                MbusChannel.OptNbboQuoteT,
                MbusChannel.OptNbboQuoteX1,
                MbusChannel.OptNbboQuoteX2,
                MbusChannel.OptNbboQuoteX3,
                MbusChannel.OptNbboQuoteX4);
#else
            engine.AddChannelThreadGroup("Opt[A-HMTX]/Stk[A-H]",
                MbusChannel.OptNbboQuoteA,
                MbusChannel.OptNbboQuoteB,
                MbusChannel.OptNbboQuoteC,
                MbusChannel.OptNbboQuoteD,
                MbusChannel.OptNbboQuoteE,
                MbusChannel.OptNbboQuoteF,
                MbusChannel.OptNbboQuoteG,
                MbusChannel.OptNbboQuoteH,
                MbusChannel.OptNbboQuoteM,
                MbusChannel.OptNbboQuoteT,
                MbusChannel.OptNbboQuoteX1,
                MbusChannel.OptNbboQuoteX2,
                MbusChannel.OptNbboQuoteX3,
                MbusChannel.OptNbboQuoteX4,
                MbusChannel.StkNbboQuoteABCD,
                MbusChannel.StkNbboQuoteEFGH);
#endif
            //SRTrace.AggregateEventFrequency = TimeSpan.FromSeconds(10);

            //////////////////////////////////
            // Configuring diagnostic tracing

            // SpiderRock uses .NET's native tracing mechanisms from the 
            // System.Diagnostics namespace so any built-in TraceListener can be 
            // used along with a few SpiderRock's custom ones.

            // Default: SRTrace.GlobalSwitch = new SourceSwitch("SRTraceSource (All)") {Level = SourceLevels.All};

            // The frequency with which summary tables are logged can be adjusted like so:
            // Default: SRTrace.AggregateEventFrequency = TimeSpan.FromMinutes(1);

            // The example above configures all trace sources uniformly.  However, each 
            // trace source (SRTrace.Default, SRTrace.KeyErrors, SRTrace.Net.Channels, 
            // SRTrace.Net.UDP.FastSockets, SRTrace.NetTcp) can be configured independently. For example, 
            // let's send all critical Mellanox related diagnostic information to the EventViewer:
            //
            // SRTrace.Net.UDP.FastSockets.Switch = new SourceSwitch("SpiderRockCritical") {Level = SourceLevels.Critical};
            // SRTrace.Net.UDP.FastSockets.Listeners.Add(new EventLogTraceListener(new EventLog("MyCompany")));
            // 
            // alternatively, via app.config:
            //
            // <configuration>
            //   <system.diagnostics>
            //     <sources>
            //       <source name="SpiderRock.Net.UDP.FastSockets"
            //               switchName="SpiderRockCritical"
            //               switchType="System.Diagnostics.SourceSwitch" >
            //         <listeners>
            //           <clear/>
            //           <add name="eventLogListener"
            //             type="System.Diagnostics.EventLogTraceListener"
            //             initializeData="MyCompany"
            //             traceOutputOptions="ProcessId, DateTime, Callstack" />
            //         </listeners>
            //       </source>
            //     </sources>
            //     <switches>
            //       <add name="SpiderRockCritical" value="Critical" />
            //     </switches>
            //   </system.diagnostics>
            // </configuration>


#if TRACK_LATENCIES
            ///////////////////////////////////////////////////
            // Latency tracking can be enabled with the help
            // of the LatencyTracker type.  Keep in mind that
            // there's a slight performance overhead associated
            // tracking latencies.  SRBenchmark (the Benchmark
            // project) can assist with establishing some
            // baseline latency characteristics

            using LatencyTracker latencyTracker = new();
            latencyTracker.Track(mbusClient.StockBookQuote);
            latencyTracker.Track(mbusClient.StockPrint, TimeSpan.FromMilliseconds(1));
            latencyTracker.Track(mbusClient.IndexQuote);
            latencyTracker.Track(mbusClient.OptionNbboQuote);
            latencyTracker.Track(mbusClient.OptionPrint, TimeSpan.FromMilliseconds(1));
#endif

            ///////////////////////////////////////////////////
            // Attach event handlers before starting the engine

            // Attaching event handlers also drives which message types
            // will be tuned into and requested from the cache

            // Attach by passing IMessageEvents<T> into the constructor
            var stockBookQuoteHandler = new StockBookQuoteHandler(mbusClient.StockBookQuote);

            // Attach the event handlers externally
            var optionBookQuoteHandler = new OptionBookQuoteHandler();
            mbusClient.OptionNbboQuote.Created += optionBookQuoteHandler.OnCreate;
            mbusClient.OptionNbboQuote.Changed += optionBookQuoteHandler.OnChange;
            mbusClient.OptionNbboQuote.Updated += optionBookQuoteHandler.OnUpdate;

            // This activates the client by first initiating a cache request
            // and downloading all of the messages that were subscribed.  Once
            // completed, multicast groups are joined and the processing of
            // live data commences.  In parallel, another cache request
            // is initiated to ensure that no messages were missed in between
            // the first cache request and the initialization of the realtime
            // feed.
            mbusClient.Start();

            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Engine failed to start: {e}");
            Console.ReadLine();
        }
        finally
        {
            if (mbusClient != null)
            {
                mbusClient.Dispose();
            }
        }
    }
}
