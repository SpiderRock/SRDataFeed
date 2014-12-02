// --------------------------------------------------------------------------------
//  SRMsgCore.Key.RootKey.cs
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
    public class RootKey : IEquatable<RootKey>, IComparable<RootKey>, IEquatable<RootKeyLayout>
    {
        private static SpinLock spinLock = new SpinLock();
        private static readonly Dictionary<RootKeyLayout, RootKey> KeyCache = new Dictionary<RootKeyLayout, RootKey>();

        public static readonly RootKey Empty = new RootKey(new RootKeyLayout());

        internal static readonly string EmptyTab = Empty.TabRecord;
        internal static readonly string EmptyStr = Empty.StringKey;

        private RootKeyLayout key;

        private string root, stringKey, tabRecord;

        private RootKey(RootKeyLayout keyLayout)
        {
            key = keyLayout;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RootKey);
        }

        public bool Equals(RootKey other)
        {
            return !ReferenceEquals(null, other) && key == other.key;
        }

        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyFieldInGetHashCode
            return key.GetHashCode();
            // ReSharper restore NonReadonlyFieldInGetHashCode
        }

        public AssetType AssetType
        {
            get { return key.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return key.TickerSrc; }
        }

        public string Root
        {
            get { return root ?? (root = key.Root.ToString()); }
        }

        /// <summary>
        /// Returns value is equivalent to comp1 and comp2 or creates a new value, caches it, and returns it.
        /// </summary>
        /// <param name="value">Existing value.</param>
        /// <param name="comp">The value that is compared to <see cref="value"/>.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RootKey CreateOrReuse(RootKey value, RootKeyLayout comp)
        {
            return (value != null && value.key == comp) ? value : GetCreateRootKey(comp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static RootKey GetCreateRootKey(RootKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            RootKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;
            spinLock.Enter(ref lockTaken);

            if (!lockTaken)
            {
                SRTrace.KeyErrors.TraceError("GetCreateRootKey: SpinLock Miss");
            }

            try
            {
                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new RootKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateRootKey: Invalid: {0}",
                                  cacheKey.StringKey);
                    }
                }

                return cacheKey;
            }
            catch
            {
                SRTrace.KeyErrors.TraceError("GetCreateRootKey: Cache Exception");
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false);
            }

            return Empty;
        }

        public static RootKey GetCreateRootKey(string rootKeyStr)
        {
            if (rootKeyStr == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateRootKey: rootKeyStr Null");

                return Empty;       
            }

            string[] tokens = rootKeyStr.Split('-');

            if (tokens.Length != 3)
            {
                SRTrace.KeyErrors.TraceError("GetCreateRootKey: rootKeyStr: [{0}]", rootKeyStr);

                return Empty;     
            }

            return GetCreateRootKey(tokens[2], tokens[1], tokens[0]);
        }

        public static RootKey GetCreateRootKey(string assetType, string tickerSrc, string root)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);         

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);
            
            return GetCreateRootKey(at, ts, root);
        }

        public static RootKey GetCreateRootKey(AssetType assetType, TickerSrc tickerSrc, string root)
        {
            return GetCreateRootKey(new RootKeyLayout(assetType, tickerSrc, root));
        }

        public bool IsValid
        {
            get { return !key.IsEmpty && key.Root.Length > 0; }            
        }

        public bool HasDigit
        {
            get
            {
                string root2 = Root;

                for (int i = 0; i < root2.Length; i++)
                {
                    if (char.IsDigit(root2[i])) return true;
                }

                return false;
            }
        }

        public string StringKey
        {
            get
            {
                return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}", Root, TickerSrc, AssetType));
            }
        }

        public string TabRecord
        {
            get
            {
                return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}", Root, TickerSrc, AssetType));
            }
        }

        public static string TabHeader
        {
            get
            {
                return "rkey_rt\trkey_ts\trkey_at";
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RootKeyLayout other)
        {
            return key.Equals(other);
        }

        public override string ToString()
        {
            return StringKey;
        }

        public int CompareTo(RootKey other)
        {
            if (other == null) return 1;
            return key.CompareTo(other.key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator RootKeyLayout(RootKey v)
        {
            return v.key;
        }
    }
} // namespace


