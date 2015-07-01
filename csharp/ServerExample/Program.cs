using System;
using System.Diagnostics;
using System.Net;
using SpiderRock.DataFeed;
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

                    // TODO: Substitute the address of the adapter

                    IFAddress = IPAddress.Parse("YOUR.LOCAL.ADAPTER.ADDRESS"),

                    // Protocol is set to UDP by default but can be switched to DBL(Myricom)
                    //Protocol = Protocol.DBL,

                    // Channel subscriptions.  A dedicated thread is used
                    // to process incoming messages when Protocol = DBL

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

                    // Alternatively, it's possible to assign sets of channels to 
                    // dedicated threads by creating channel thread groups:

                    //DblChannelThreadGroups = new[]
                    //{
                    //    new DblChannelThreadGroup
                    //    {
                    //        UdpChannel.OptNbboQuote1,
                    //        UdpChannel.OptNbboQuote2,

                    //        UdpChannel.StkNbboQuote1,
                    //        UdpChannel.StkNbboQuote2
                    //    },

                    //    new DblChannelThreadGroup
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

                // This will start the engine and request all of the state corresponding
                // to the message types being requested
                engine.StartWith(MessageType.OptionNbboQuote, MessageType.StockBookQuote);

                // Alternatively, start without cache data
                engine.Start();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Engine failed to start: {0}", e);
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