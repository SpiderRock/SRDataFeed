using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
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