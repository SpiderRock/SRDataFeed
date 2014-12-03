using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Messaging.Keys;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal abstract class CachedKey<TKey, TKeyLayout> : CachedValue<TKey, TKeyLayout>
        where TKey : class, IKeyEquatable<TKeyLayout> 
        where TKeyLayout : struct
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract TKey ToKey(TKeyLayout keyLayout);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override TKey Get(ref TKeyLayout keyLayout, int version)
        {
            lock (this)
            {
                if (Value == null)
                {
                    Value = ToKey(keyLayout);
                    Version = version;
                    return Value;
                }

                if (Version == version) return Value;

                Version = version;

                if (Value.Equals(ref keyLayout)) return Value;

                Value = ToKey(keyLayout);

                return Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Set(TKey value)
        {
            lock (this)
            {
                Value = value;
            }
        }
    }
}