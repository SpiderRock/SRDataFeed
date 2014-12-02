using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Messaging.Keys;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal sealed class CachedStockKey : CachedKey<StockKey, StockKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockKey ToKey(StockKeyLayout keyLayout)
        {
            return StockKey.GetCreateStockKey(keyLayout);
        }
    }
}