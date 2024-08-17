using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Diagnostics;


namespace TimeBoxAnalysis {


    internal class Program
    {
        public readonly static TimeSpan BucketSize = TimeSpan.FromMinutes(5);
        private static void Main(string[] args)
        {
            var parsed = Parse(args).ToArray();
            Console.WriteLine($"parsed {parsed}");

            var ifAddrArg = parsed.FirstOrDefault(arg => arg.Name == "-ifAddr");

            if (ifAddrArg == null || !IPAddress.TryParse(ifAddrArg.Values[0], out var ifAddr))
            {
                throw new UsageException($"{nameof(TimeBoxAnalysis)}: -ifAddr must be a valid IPv4 address (i.e. 192.168.0.1) of a local NIC (see: ipconfig /ALL). Got {ifAddrArg}");
            }

            var apiKey = parsed.FirstOrDefault(arg => arg.Name == "-apiKey")?.Values[0];

            var logBaseDir = @"C:\SRDiagnostics";
            var logBaseDirArg = parsed.FirstOrDefault(arg => arg.Name == "-logBaseDir");
            if (logBaseDirArg != null) {
                logBaseDir = logBaseDirArg.Values[0];
            }

            SRDataFeedEngine engine = null;

            try
            {
                engine = new SRDataFeedEngine
                {
                    // TODO: Substitute the address of the adapter
                    IFAddress = ifAddr,

                    // Protocol is set to UDP by default but can be switched to DBL(Myricom)
                    Protocol = Protocol.DBL,

                    // Channel subscriptions.  A dedicated thread is used
                    // to process incoming messages when Protocol = DBL

                    ChannelThreadGroups = new[]
                    {
                        new DblChannelThreadGroup
                        {
                            UdpChannel.StkNbboQuote1,
                            UdpChannel.StkNbboQuote2,
                            UdpChannel.StkNbboQuote3,
                            UdpChannel.StkNbboQuote4
                        }
                    }
                };




                var stockBookQuoteHandler = new StockBookQuoteHandler();
                engine.StockBookQuoteChanged += stockBookQuoteHandler.OnChange;

                engine.Start();

                Console.WriteLine($"{nameof(TimeBoxAnalysis)} running. Hit [enter] to exit.");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Engine failed to start: {e}");
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
        private static IEnumerable<Arg> Parse(string[] args)
        {
            Arg current = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    if (current != null) yield return current;
                    current = new Arg(arg);
                }
                else if (current != null)
                {
                    current.Values.Add(arg);
                }
            }

            if (current != null) yield return current;
        }
        private class UsageException : Exception
        {
            public UsageException(string message) : base(message)
            {
            }
        }

        private class Arg
        {
            public Arg(string name)
            {
                Name = name;
                Values = new List<string>();
            }

            public string Name { get; private set; }
            public List<string> Values { get; private set; }
        }
    }
}
