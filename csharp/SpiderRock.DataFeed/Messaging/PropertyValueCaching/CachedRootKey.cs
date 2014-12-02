using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Messaging.Keys;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal sealed class CachedRootKey : CachedKey<RootKey, RootKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override RootKey ToKey(RootKeyLayout keyLayout)
        {
            return RootKey.GetCreateRootKey(keyLayout);
        }
    }
}