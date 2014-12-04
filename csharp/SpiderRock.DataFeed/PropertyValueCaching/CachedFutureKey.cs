using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
{
    internal sealed class CachedFutureKey : CachedKey<FutureKey, FutureKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override FutureKey ToKey(FutureKeyLayout keyLayout)
        {
            return FutureKey.GetCreateFutureKey(keyLayout);
        }
    }
}