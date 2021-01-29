using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Layouts;
using SpiderRock.DataFeed.Diagnostics;

namespace CmePrintDefChecker
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                SRTrace.GlobalSwitch = new SourceSwitch("SRTraceSource (All)")
                {
                    Level = SourceLevels.All
                };

                SRTrace.KeyErrors.Switch = new SourceSwitch("SRKeyErrors")
                {
                    Level = SourceLevels.Off
                };

                SRTrace.AggregateEventFrequency = TimeSpan.FromSeconds(10);

                using (var engine = new SRDataFeedEngine
                {
                    IFAddress = IPAddress.Parse("YOUR.LOCAL.ADAPTER.ADDRESS"),
                    Channels = new[] { UdpChannel.FutQuoteCme, UdpChannel.CmeAdmin }
                })
                {
                    var definitions = new Dictionary<ExpiryKey, ProductDefinitionV2>();

                    engine.FuturePrintCreated += (_, args) =>
                    {
                        if (!definitions.TryGetValue(args.Created.Key.Fkey, out var def))
                        {
                            Console.Error.WriteLine($"No definition found for future print {args.Created.Key}");
                        }
                    };

                    engine.ProductDefinitionV2Created += (_, args) =>
                    {
                        var key = args.Created.Key;

                        if (key.SecType != SpdrKeyType.Future)
                        {
                            return;
                        }

                        lock (definitions)
                        {
                            definitions[(ExpiryKey)key.SecKey] = args.Created;
                        }
                    };

                    engine.StartWith(MessageType.ProductDefinitionV2);

                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Engine failed to start: {0}", e);
                Console.ReadLine();
            }
        }
    }
}
