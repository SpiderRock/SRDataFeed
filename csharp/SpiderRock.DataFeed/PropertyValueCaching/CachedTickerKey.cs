using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
{ 
    internal sealed class CachedTickerKey : CachedKey<TickerKey, TickerKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override TickerKey ToKey(TickerKeyLayout keyLayout)
        {
            return TickerKey.GetCreateTickerKey(keyLayout);
        }
    }
}