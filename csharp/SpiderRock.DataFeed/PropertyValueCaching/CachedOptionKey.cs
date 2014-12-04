using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
{
    internal sealed class CachedOptionKey : CachedKey<OptionKey, OptionKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionKey ToKey(OptionKeyLayout keyLayout)
        {
            return OptionKey.GetCreateOptionKey(keyLayout);
        }
    }
}