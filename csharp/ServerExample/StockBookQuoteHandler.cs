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
            // note: this event will fire once for each new instance of a StockBookQuote.PKey.
            // the cObj instance reference will not change when a new quote arrives so it is safe to keep track of cObj references as below
            // if a reference to cObj is stored as below and properties of cObj are accessed later properties will contain current quote values, not values when initially created.

            StockBookQuotes[args.Created.Key] = args.Created;
        }

        public void OnUpdate(object sender, UpdatedEventArgs<StockBookQuote> args)
        {
            // note: this event is fired each time a new quote arrives. 
            // pObj will contain the new quote and cObj the prior quote
            // the first time this event fires cObj will be null            
            // this handler should not keep any pObj references on exit

            bool isBidPrice1Changed = (args.Previous == null ||
                                       Math.Abs(args.Current.BidPrice1 - args.Previous.BidPrice1) > 0.0001);

            if (isBidPrice1Changed)
            {
                numBidPriceChanges += 1;
            }
        }

        public void OnChange(object sender, ChangedEventArgs<StockBookQuote> args)
        {
            // note: this event is fired each time a new quote arrives.
            // when processing of UpdateEvent handlers is completed the newly arrived quote (pObj) is copied into the static cObj
            // this event is fired after the pObj->cObj copy takes place

            numStockBookQuoteChanges += 1;
        }
    }
}