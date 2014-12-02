using System;
using System.Diagnostics;
using System.Net;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Messaging;
using SpiderRock.DataFeed.Diagnostics;

namespace ServerExample
{
    internal class Program
    {
        private static void Main()
        {
            SRDataFeedEngine engine = null;

            try
            {
                /////////////////////////////////////////////
                // Instantiate and configure a new engine

                engine = new SRDataFeedEngine
                {
                    SysEnvironment = SysEnvironment.Stable,

                    // Substitute the address of the adapter

                    IFAddress = IPAddress.Parse("127.0.0.1"),

                    // Substitute the address (or hostname) and port of the cache server

                    CacheHost = "127.0.0.1",
                    CachePort = 8123,


                    // Channel subscriptions.  One dedicated thread is used
                    // to process incoming messages

                    Channels = new[]
                    {
                        UdpChannel.OptNbboQuote1,
                        UdpChannel.OptNbboQuote2,

                        UdpChannel.StkNbboQuote1,
                        UdpChannel.StkNbboQuote2,

                        UdpChannel.OptNbboQuote3,
                        UdpChannel.OptNbboQuote4,

                        UdpChannel.StkNbboQuote3,
                        UdpChannel.StkNbboQuote4
                    }

                    // Alternatively, it's possible to create custom assignments of
                    // channels to dedicated threads by creating channel thread groups:

                    //ChannelThreadGroups = new[]
                    //{
                    //    new UdpChannelThreadGroup
                    //    {
                    //        UdpChannel.OptNbboQuote1,
                    //        UdpChannel.OptNbboQuote2,

                    //        UdpChannel.StkNbboQuote1,
                    //        UdpChannel.StkNbboQuote2
                    //    },

                    //    new UdpChannelThreadGroup
                    //    {
                    //        UdpChannel.OptNbboQuote3,
                    //        UdpChannel.OptNbboQuote4,

                    //        UdpChannel.StkNbboQuote3,
                    //        UdpChannel.StkNbboQuote4
                    //    }
                    //},
                };

                //////////////////////////////////
                // Configuring diagnostic tracing

                // SpiderRock uses .NET's native tracing mechanisms from the 
                // System.Diagnostics namespace so any built-in TraceListener can be 
                // used along with a few SpiderRock's custom ones: SRFileTraceListener and 
                // SRConsoleTraceListener.

                SRTrace.GlobalSwitch = new SourceSwitch("SRTraceSource (All)") {Level = SourceLevels.All};
                SRTrace.AddGlobalTraceListener(new SRFileTraceListener());
                SRTrace.AddGlobalTraceListener(new SRConsoleTraceListener());

                // The example above configures all trace sources uniformly.  However, each 
                // trace source (SRTrace.Default, SRTrace.KeyErrors, SRTrace.NetChannels, 
                // SRTrace.NetDbl, SRTrace.NetTcp) can be configured independently. For example, 
                // let's send all critical DBL related diagnostic information to the EventViewer:
                //
                // SRTrace.NetDbl.Switch = new SourceSwitch("SpiderRockCritical") {Level = SourceLevels.Critical};
                // SRTrace.NetDbl.Listeners.Add(new EventLogTraceListener(new EventLog("MyCompany")));
                // 
                // alternatively, via app.config:
                //
                // <configuration>
                //   <system.diagnostics>
                //     <sources>
                //       <source name="SpiderRock.Net.DBL"
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

                /////////////////////////////////////////////
                // Attach handlers before starting the engine

                var stockBookQuoteHandler = new StockBookQuoteHandler();
                engine.StockBookQuoteCreated += stockBookQuoteHandler.OnCreate;
                engine.StockBookQuoteUpdated += stockBookQuoteHandler.OnUpdate;
                engine.StockBookQuoteChanged += stockBookQuoteHandler.OnChange;

                var optionBookQuoteHandler = new OptionBookQuoteHandler();
                engine.OptionNbboQuoteCreated += optionBookQuoteHandler.OnCreate;
                engine.OptionNbboQuoteUpdated += optionBookQuoteHandler.OnUpdate;
                engine.OptionNbboQuoteChanged += optionBookQuoteHandler.OnChange;

                engine.Start();

                TimeSpan timeout = TimeSpan.FromMinutes(1);
                MessageType[] messageTypesToRequest = {MessageType.OptionNbboQuote, MessageType.StockBookQuote};

                // Synchronous request to get existing stock and option quote data.
                // While cache data is being retrieved, live quote data
                // is simultaneously arriving.  When the request completes
                // the application will contain the latest state of the data.

                if (!engine.GetCachedMessages(timeout, messageTypesToRequest))
                {
                    throw new TimeoutException("Cache request timed out");
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Cache request error: {0}", e);
                Console.ReadLine();
            }
            finally
            {
                if (engine != null)
                {
                    engine.Dispose();
                }
            }
        }
    }
}