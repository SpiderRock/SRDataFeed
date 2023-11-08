using System;
using System.Collections.Concurrent;
using SpiderRock.SpiderStream;

namespace ServerExample;

public class StockBookQuoteHandler
{
    private readonly ConcurrentDictionary<StockBookQuote.PKey, StockBookQuote> StockBookQuotes = new();

    public StockBookQuoteHandler(IMessageEvents<StockBookQuote> stockBookQuoteEvents)
    {
        stockBookQuoteEvents.Created += OnCreate;
        stockBookQuoteEvents.Changed += OnChange;
    }

    private int numStockBookQuoteChanges;

    private void OnCreate(object sender, CreatedEventArgs<StockBookQuote> args)
    {
        /* This event will fire once for each new instance of a StockBookQuote.PKey.  The 
         * instance of the message is stored a the 'Created' property of the 'args' argument.
         * It is safe to retain a reference to the instance past the completion of the 
         * event handler as well as to continue accessing its properties.  The properties
         * will contain the latest values for that key rather than the initial ones.
         */

        StockBookQuotes[args.Created.Key] = args.Created;
    }

    private void OnChange(object sender, ChangedEventArgs<StockBookQuote> args)
    {
        /* The change event fires after the update event (if subscribed) and contains
         * an instance at the 'Changed' property of the 'args' argument with the latest values
         * for that key.  It is safe to retain and access past the completion of the event handler.
         */

        numStockBookQuoteChanges += 1;
    }
}
