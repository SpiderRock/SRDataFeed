using System.Collections.Concurrent;
using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Messaging;

namespace ServerExample
{
    public class OptionBookQuoteHandler
    {
        private static ConcurrentDictionary<OptionNbboQuote.PKey, OptionNbboQuote> optionNbboQuotes =
            new ConcurrentDictionary<OptionNbboQuote.PKey, OptionNbboQuote>();

        public void OnCreate(object sender, CreatedEventArgs<OptionNbboQuote> args)
        {
        }

        public void OnUpdate(object sender, UpdatedEventArgs<OptionNbboQuote> arg)
        {
        }

        public void OnChange(object sender, ChangedEventArgs<OptionNbboQuote> args)
        {
        }
    }
}