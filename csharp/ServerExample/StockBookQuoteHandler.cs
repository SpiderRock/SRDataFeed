using System;
using System.Collections.Concurrent;
using SpiderRock.DataFeed;

namespace ServerExample
{
    public class StockBookQuoteHandler
    {
        private static readonly ConcurrentDictionary<StockBookQuote.PKey, StockBookQuote> StockBookQuotes =
            new ConcurrentDictionary<StockBookQuote.PKey, StockBookQuote>();

        private static int numBidPriceChanges;
        private static int numStockBookQuoteChanges;

        public void OnCreate(object sender, CreatedEventArgs<StockBookQuote> args)
        {
            /* This event will fire once for each new instance of a StockBookQuote.PKey.  The 
             * instance of the message is stored a the 'Created' property of the 'args' argument.
             * It is safe to retain a reference to the instance past the completion of the 
             * event handler as well as to continue accessing its properties.  The properties
             * will contain the latest values for that key rather than the initial ones.
             */

            StockBookQuotes[args.Created.Key] = args.Created;
        }

        public void OnUpdate(object sender, UpdatedEventArgs<StockBookQuote> args)
        {
            /* The UpdateEvent is useful when the consumer wishes to know the previous state of the object as well as the current.  
             * The 'args' argument contains a 'Previous' property with a reference to an object that contains
             * the last known state prior to the update and a 'Current' property with the latest data.  The engine
             * uses the instance at the 'Previous' property internally so it isn't safe to refer to it
             * past the completion of the event handler.  However, the instance at the 'Current' property is the same as 
             * the one in the create event (above) and is safe to retain and read.
             * 
             * It is important to note that there is a slight performance overhead associated with handling
             * this event.  The overhead is incurred by subscribing to the event even with an empty handler.
             */

            bool isBidPrice1Changed = (args.Previous == null ||
                                       Math.Abs(args.Current.BidPrice1 - args.Previous.BidPrice1) > 0.0001);

            if (isBidPrice1Changed)
            {
                numBidPriceChanges += 1;
            }
        }

        public void OnChange(object sender, ChangedEventArgs<StockBookQuote> args)
        {
            /* The change event fires after the update event (if subscribed) and contains
             * an instance at the 'Changed' property of the 'args' argument with the latest values
             * for that key.  It is safe to retain and access past the completion of the event handler.
             */

            numStockBookQuoteChanges += 1;
        }
    }
}