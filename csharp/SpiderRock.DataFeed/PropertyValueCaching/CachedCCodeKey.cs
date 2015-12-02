using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.PropertyValueCaching
{
    internal sealed class CachedCCodeKey : CachedKey<CCodeKey, CCodeKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override CCodeKey ToKey(CCodeKeyLayout keyLayout)
        {
            return CCodeKey.GetCreateCCodeKey(keyLayout);
        }
    }
}