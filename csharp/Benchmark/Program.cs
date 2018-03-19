﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Diagnostics;

namespace SRBenchmark
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

                var cacheArg = parsed.FirstOrDefault(arg => arg.Name == "-cache");
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

                using (var engine = new SRDataFeedEngine())
                {
                    engine.IFAddress = ifAddr;
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

                    if (parsed.Any(arg => arg.Name == "-latency"))
                    {
                        engine.TrackStockQuoteLatency();
                        engine.TrackOptionQuoteLatency();
                        engine.TrackFutureQuoteLatency();
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
                    "Usage: -ifAddr IPv4Address -channels UdpChannel1 UdpChannel2 ... [-freq SECONDS] [-recvBuf MBs] -cache MessageType1 MessageType2 ... [-latency]");
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