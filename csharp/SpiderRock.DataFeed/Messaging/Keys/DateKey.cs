// --------------------------------------------------------------------------------
//  SRMsgCore.Key.DateKey.cs
//  
//  Copyright 2013, SpiderRock Technology
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Messaging.Keys
{     
    public class DateKey : IEquatable<DateKey>, IKeyEquatable<DateKeyLayout>
    {
        public static readonly DateKey Empty = new DateKey(new DateKeyLayout(0));

        private static readonly Dictionary<DateKeyLayout, DateKey> KeyCache = new Dictionary<DateKeyLayout, DateKey>();
        private static SpinLock keyCacheLock = new SpinLock();

        internal readonly DateKeyLayout Layout;

        private readonly string dttmString;       
        private readonly DateTime dttm;

        public DateTime DateTime
        {
            get { return dttm; }
        }

        private DateKey(DateKeyLayout layout)
        {
            Layout = layout;
            dttm = new DateTime(Layout.Value);
            dttmString = string.Format("{0:D4}-{1:D2}-{2:D2}", dttm.Year, dttm.Month, dttm.Day);
        }

        internal static DateKey GetCreateDateKey(DateKeyLayout key)
        {
            DateKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);
                
                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new DateKey(key);
                }

                return cacheKey;
            }
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateDateKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateDateKey: SpinLock Miss");
                }
            }

            return Empty;
        }

        public static bool operator <(DateKey x, DateKey y)
        {
            return (x.Layout < y.Layout);
        }

        public static bool operator <=(DateKey x, DateKey y)
        {
            return (x.Layout <= y.Layout);
        }

        public static bool operator >(DateKey x, DateKey y)
        {
            return (x.Layout > y.Layout);
        }

        public static bool operator >=(DateKey x, DateKey y)
        {
            return (x.Layout >= y.Layout);
        }

        public static bool operator ==(DateKey x, DateKey y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Layout.Equals(y.Layout);
        }

        public static bool operator !=(DateKey x, DateKey y)
        {
            return !(x == y);
        }

        public override bool Equals(object b)
        {
            var bb = b as DateKey;
            return (bb != null && Layout == bb.Layout);
        }

        public bool Equals(DateKey b)
        {
            return (Layout == b.Layout);
        }

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        bool IKeyEquatable<DateKeyLayout>.Equals(ref DateKeyLayout other)
        {
            return Layout.Equals(other);
        }

        public override string ToString()
        {
            return dttmString;
        }
    }


} // namespace


