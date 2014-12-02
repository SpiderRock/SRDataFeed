using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal abstract class CachedValue
    {
        protected int Version = int.MinValue;
    }

    internal abstract class CachedValue<TCached, TValue> : CachedValue
    {
        protected TCached Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public abstract TCached Get(ref TValue value, int version);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public abstract void Set(TCached value);
    }
}