using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Diagnostics;

namespace SRStreamBenchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var parsed = Parse(args).ToArray();

                IPAddress ifAddr;
                UdpChannel[] channels;
                var freq = 10;
                var proto = Protocol.UDP;
                var receiveBufferSize = 20;
                MessageType[] cache = null;

                var ifAddrArg = parsed.FirstOrDefault(arg => arg.Name == "-ifAddr");

                if (ifAddrArg == null || !IPAddress.TryParse(ifAddrArg.Values[0], out ifAddr))
                {
                    throw new UsageException(
                        "-ifAddr must be a valid IPv4 address (i.e. 192.168.0.1) of a local NIC (ipconfig /ALL)");
                }

                var freqArg = parsed.FirstOrDefault(arg => arg.Name == "-freq");
                if (freqArg != null && (!int.TryParse(freqArg.Values[0], out freq) || freq < 5 || freq > 120))
                {
                    throw new UsageException("-freq must be an integer [5, 120]");
                }

                var receiveBufferSizeArg = parsed.FirstOrDefault(arg => arg.Name == "-recvBuf");
                if (receiveBufferSizeArg != null &&
                    (!int.TryParse(receiveBufferSizeArg.Values[0], out receiveBufferSize) || receiveBufferSize < 1 ||
                     receiveBufferSize > 200))
                {
                    throw new UsageException("-recvBuf must be an integer [1, 200]");
                }

                var protoArg = parsed.FirstOrDefault(arg => arg.Name == "-proto");
                // ReSharper disable once AccessToStaticMemberViaDerivedType
                if (protoArg != null && !Protocol.TryParse(protoArg.Values[0], true, out proto))
                {
                    throw new UsageException("-proto must be UDP or DBL");
                }

                try
                {
                    var channelsArgs = parsed.First(arg => arg.Name == "-channels");
                    channels = channelsArgs
                        .Values
                        .Select(v => Enum.Parse(typeof (UdpChannel), v, true))
                        .Cast<UdpChannel>()
                        .ToArray();
                }
                catch
                {
                    throw new UsageException("-channels must be a space-separated list of channels names: " +
                                             string.Join(", ", Enum.GetNames(typeof (UdpChannel))));
                }

                var cacheArg = parsed.First(arg => arg.Name == "-cache");
                if (cacheArg != null)
                {
                    try
                    {
                        cache = cacheArg
                            .Values
                            .Select(MessageType.FromName)
                            .ToArray();
                    }
                    catch
                    {
                        throw new UsageException("-cache must be a space-separated list of valid message types: " +
                                                 string.Join(", ", MessageType.Core));
                    }
                }

                SRTrace.AggregateEventFrequency = TimeSpan.FromSeconds(freq);
                SRTrace.GlobalSwitch = new SourceSwitch("SRTraceSource (All)") {Level = SourceLevels.All};
                SRTrace.AddGlobalTraceListener(new SRFileTraceListener());
                SRTrace.AddGlobalTraceListener(new SRConsoleTraceListener());

                using (var engine = new SRDataFeedEngine {SysEnvironment = SysEnvironment.Beta})
                {
                    engine.IFAddress = ifAddr;
                    engine.Protocol = proto;
                    engine.Channels = channels;
                    engine.ReceiveBufferSize = receiveBufferSize*1024*1024;

                    if (cache == null || cache.Length == 0)
                    {
                        engine.Start();
                    }
                    else
                    {
                        engine.StartWith(cache);
                    }

                    Console.WriteLine("****************************************************************");
                    Console.WriteLine("*                                                              *");
                    Console.WriteLine("*                                                              *");
                    Console.WriteLine("*    SRDataFeedEngine instance started, press ENTER to quit    *");
                    Console.WriteLine("*                                                              *");
                    Console.WriteLine("*                                                              *");
                    Console.WriteLine("****************************************************************");
                    Console.ReadLine();
                }
            }
            catch (UsageException e)
            {
                Console.Error.WriteLine("Invalid usage: {0}", e.Message);
                Console.Error.WriteLine(
                    "Usage: -ifAddr IPv4Address -channels UdpChannel1 UdpChannel2 ... [-freq SECONDS] [-proto UDP|DBL] [-recvBuf MBs] -cache MessageType1 MessageType2 ...");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Engine failed to start: {0}", e);
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