using System;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed.Messaging.PropertyValueCaching
{
    internal sealed class CachedFixedLengthString<TFixedLengthString> : CachedValue<string, TFixedLengthString>
        where TFixedLengthString : struct, IEquatable<string>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string Get(ref TFixedLengthString value, int version)
        {
            lock (this)
            {
                if (Value == null)
                {
                    Version = version;
                    Value = value.ToString();
                    return Value;
                }

                if (Version == version) return Value;

                Version = version;
                if (value.Equals(Value)) return Value;
                Value = value.ToString();

                return Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Set(string value)
        {
            lock (this)
            {
                Version = -1;
            }
        }
    }
}