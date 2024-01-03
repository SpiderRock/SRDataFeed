using System.Collections.Concurrent;
using SpiderRock.SpiderStream;

namespace ServerExample;

public class OptionBookQuoteHandler
{
    private readonly ConcurrentDictionary<OptionNbboQuote.PKey, OptionNbboQuote> optionNbboQuotes = new();

    public void OnCreate(object sender, CreatedEventArgs<OptionNbboQuote> args)
    {
    }

    public void OnChange(object sender, ChangedEventArgs<OptionNbboQuote> args)
    {
    }

    public void OnUpdate(object sender, UpdatedEventArgs<OptionNbboQuote> args)
    {
    }
}
