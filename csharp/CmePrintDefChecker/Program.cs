using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using SpiderRock.SpiderStream;
using SpiderRock.SpiderStream.Mbus.Layouts;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace CmePrintDefChecker;

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

            using (var futQuoteEngine = new MbusClient())
            using (var defEngine = new MbusClient())
            {
                futQuoteEngine.AddChannelThreadGroup(IPAddress.Parse("YOUR.LOCAL.ADAPTER.ADDRESS"), "", MbusChannel.FutNbboQuoteX);
                var definitions = new Dictionary<ExpiryKey, ProductDefinitionV2>();

                futQuoteEngine.FuturePrint.Created += (_, args) =>
                {
                    if (!definitions.TryGetValue(args.Created.Key.Fkey, out var def))
                    {
                        Console.Error.WriteLine($"No definition found for future print {args.Created.Key}");
                    }
                };

                defEngine.ProductDefinitionV2.Created += (_, args) =>
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

                futQuoteEngine.Start();

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
