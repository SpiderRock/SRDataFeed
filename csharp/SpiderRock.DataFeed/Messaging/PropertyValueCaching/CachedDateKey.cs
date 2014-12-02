using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Messaging.Keys;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal sealed class CachedDateKey : CachedKey<DateKey, DateKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override DateKey ToKey(DateKeyLayout keyLayout)
        {
            return DateKey.GetCreateDateKey(keyLayout);
        }
    }
}