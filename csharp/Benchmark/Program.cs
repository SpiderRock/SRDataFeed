using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SpiderRock.SpiderStream;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SRBenchmark;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var parsed = Parse(args).ToArray();

            IPEndPoint[][] channels;
            var freq = 10;
            MessageType[] messageTypes = null;

            var ifAddrArg = parsed.FirstOrDefault(arg => arg.Name == "-ifAddr");

            if (ifAddrArg == null || !IPAddress.TryParse(ifAddrArg.Values[0], out var ifAddr))
            {
                throw new UsageException("-ifAddr must be a valid IPv4 address (i.e. 192.168.0.1) of a local NIC (ipconfig /ALL)");
            }

            var freqArg = parsed.FirstOrDefault(arg => arg.Name == "-freq");
            if (freqArg != null && (!int.TryParse(freqArg.Values[0], out freq) || freq < 5 || freq > 120))
            {
                throw new UsageException("-freq must be an integer [5, 120]");
            }

            var receiveBufferSizeArg = parsed.FirstOrDefault(arg => arg.Name == "-recvBuf");
            if (receiveBufferSizeArg != null &&
                (!int.TryParse(receiveBufferSizeArg.Values[0], out var receiveBufferSize) || receiveBufferSize < 1 ||
                 receiveBufferSize > 200))
            {
                throw new UsageException("-recvBuf must be an integer [1, 200]");
            }

            var channelsArgs = parsed.Where(arg => arg.Name == "-channels").ToArray();
            channels = parsed
                .Where(arg => arg.Name == "-channels")
                .Select(arg => arg.Values.Select(MbusChannel.FromName).ToArray())
                .ToArray();

            var messagesArgs = parsed.First(arg => arg.Name == "-messages");
            messageTypes = messagesArgs.Values.Select(v => MessageType.FromName(v)).ToArray();

            var apiKey = parsed.FirstOrDefault(arg => arg.Name == "-apiKey")?.Values[0];

            SRTrace.AggregateEventFrequency = TimeSpan.FromSeconds(freq);

            using MbusClient mbusClient = new()
            {
                LocalInterface = ifAddr,
                ApiKey = apiKey
            };

            LatencyTracker latencyTracker = parsed.Any(arg => arg.Name == "-latency") ? new() : null;

            if (latencyTracker is not null && freq < 60)
            {
                Console.Error.WriteLine("Adjusted sampling frequency (`-freq`) to be every minute because `-latency` argument was used");
                freq = 60;
            }

            foreach (var messageType in messageTypes)
            {
                var messageEvents = mbusClient.GetMessageEvents(messageType)
                    ?? throw new ArgumentException($"Unknown message type {messageType}");

                // by attaching empty even handlers we are enabling the processing of the messages
                if (latencyTracker is null)
                {
                    messageEvents.Changed += delegate { };
                }
                else
                {
                    latencyTracker.Track(
                        messageEvents,
                        TimeSpan.FromMilliseconds(5),
                        getTimeRcvd: m => unchecked((DateTime.UtcNow.Ticks - DateTime.UnixEpoch.Ticks) * 100),
                        getTimeSent: m => m.PublishedNsecsSinceUnixEpoch);
                }
            }

            for (int i = 0; i < channels.Length; i++)
            {
                mbusClient.AddChannelThreadGroup($"Group{i}", channels[i]);
            }

            Task.Run(mbusClient.Start);

            Console.WriteLine("****************************************************************");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("*    MbusClient instance started, press ENTER to quit    *");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("****************************************************************");
            Console.ReadLine();
        }
        catch (UsageException e)
        {
            Console.Error.WriteLine("Invalid usage: {0}", e.Message);
            Console.Error.WriteLine("Usage: -ifAddr IPv4Address -channels MbusChannel1 MbusChannel2 ... [-freq SECONDS] [-recvBuf MBs] -messages MessageType1 MessageType2 ... -apiKey ApiKeyString [-latency]");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Engine failed to start: {e}");
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
