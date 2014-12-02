// --------------------------------------------------------------------------------
//  SRMsgCore.Key.DateKey.cs
//  
//  Copyright 2013, SpiderRock Technology
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed.Messaging.Keys
{     
    public class DateKey : IEquatable<DateKey>, IEquatable<DateKeyLayout>
    {
        public static readonly DateKey Empty = new DateKey(0);

        private static readonly Dictionary<DateKey, DateKey> KeyCache = new Dictionary<DateKey, DateKey>();

        private readonly DateKeyLayout data;
        private readonly string value;       
        private readonly DateTime dttm;

        public string Value
        {
            get { return value; }
        }     

        public DateTime DateTime
        {
            get { return dttm; }
        }

        private DateKey(string value)
        {
            int yr, mn, dy;

            string sValue = value.Replace("-", "");

            try
            {
                yr = int.Parse(sValue.Substring(0, 4));
                mn = int.Parse(sValue.Substring(4, 2));
                dy = int.Parse(sValue.Substring(6, 2));
            }
            catch
            {
                throw new ArgumentException(string.Format("Invalid Date Format: [{0}]", value), "value");
            }

            dttm = new DateTime(yr, mn, dy);
            data = new DateKeyLayout(dttm.Ticks);
           
            this.value = string.Format("{0:D4}-{1:D2}-{2:D2}", dttm.Year, dttm.Month, dttm.Day);
        }

        private DateKey(DateTime dttm)
        {
            this.dttm = dttm;
            data = new DateKeyLayout(dttm.Ticks);

            value = string.Format("{0:D4}-{1:D2}-{2:D2}", dttm.Year, dttm.Month, dttm.Day);
        }

        private DateKey(long data)
        {
            dttm = new DateTime(data);
            this.data = new DateKeyLayout(dttm.Ticks);

            value = string.Format("{0:D4}-{1:D2}-{2:D2}", dttm.Year, dttm.Month, dttm.Day);
        }

        public static DateKey GetCreateDateKey(DateKey key)
        {       
            DateKey rv;

            if (!KeyCache.TryGetValue(key, out rv))
            {
                rv = key;
                KeyCache[rv] = key;
            }

            return rv;
        }

        /// <summary>
        /// Returns value is equivalent to comp1 and comp2 or creates a new value, caches it, and returns it.
        /// </summary>
        /// <param name="value">Existing value.</param>
        /// <param name="comp">The value that is compared to value.data.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateKey CreateOrReuse(DateKey value, DateKeyLayout comp)
        {
            if (value != null && value.Equals(comp)) return value;

            return GetCreateDateKey(comp);
        }

        public static DateKey GetCreateDateKey(string value)
        {
            return GetCreateDateKey(new DateKey(value));
        }

        public static DateKey GetCreateDateKey(DateTime dttm)
        {
            return GetCreateDateKey(new DateKey(dttm.Date));
        }       

        public static DateKey GetCreateDateKey(long data)
        {
            return GetCreateDateKey(new DateKey(data));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DateKeyLayout(DateKey value)
        {
            return value.data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DateKey(DateKeyLayout value)
        {
            return value.Value == 0 ? Empty : GetCreateDateKey(value.Value);
        }

        public static bool operator <(DateKey x, DateKey y)
        {
            return (x.data < y.data);
        }

        public static bool operator <=(DateKey x, DateKey y)
        {
            return (x.data <= y.data);
        }

        public static bool operator >(DateKey x, DateKey y)
        {
            return (x.data > y.data);
        }

        public static bool operator >=(DateKey x, DateKey y)
        {
            return (x.data >= y.data);
        }

        public static bool operator ==(DateKey x, DateKey y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.data.Equals(y.data);
        }

        public static bool operator !=(DateKey x, DateKey y)
        {
            return !(x == y);
        }

        public override bool Equals(object b)
        {
            var bb = b as DateKey;
            return (bb != null && data == bb.data);
        }

        public bool Equals(DateKey b)
        {
            return (data == b.data);
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(DateKeyLayout other)
        {
            return data.Equals(other);
        }

        public override string ToString()
        {
            return value;
        }

        public unsafe int Write(byte* p)
        {
            *(DateKeyLayout*) p = data;
            return sizeof (long);
        }
    }


} // namespace


