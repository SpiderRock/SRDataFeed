using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
{
    internal sealed class CachedExpiryKey : CachedKey<ExpiryKey, ExpiryKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override ExpiryKey ToKey(ExpiryKeyLayout keyLayout)
        {
            return ExpiryKey.GetCreateExpiryKey(keyLayout);
        }
    }
}