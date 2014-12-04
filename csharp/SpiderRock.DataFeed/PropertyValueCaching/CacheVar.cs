using System.Runtime.CompilerServices;
using System.Threading;

namespace SpiderRock.DataFeed.PropertyValueCaching
{
    internal static class CacheVar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AllocIfNull<T>(ref T @var) where T : CachedValue, new()
        {
            if (@var == null) Interlocked.CompareExchange(ref @var, new T(), null);
            return @var;
        }
    }
}