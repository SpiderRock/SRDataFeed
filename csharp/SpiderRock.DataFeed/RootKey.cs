using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class RootKey : IEquatable<RootKey>, IComparable<RootKey>, IKeyLayoutEquatable<RootKeyLayout>
    {
        private static SpinLock keyCacheLock = new SpinLock();
        private static readonly Dictionary<RootKeyLayout, RootKey> KeyCache = new Dictionary<RootKeyLayout, RootKey>();

        public static readonly RootKey Empty = new RootKey(new RootKeyLayout());

        internal readonly RootKeyLayout Layout;

        private string root, stringKey, tabRecord;

        private RootKey(RootKeyLayout layout)
        {
            Layout = layout;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RootKey);
        }

        public bool Equals(RootKey other)
        {
            return other != null && Layout == other.Layout;
        }

        bool IKeyLayoutEquatable<RootKeyLayout>.Equals(ref RootKeyLayout other)
        {
            return Layout.Equals(other);
        }

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        public AssetType AssetType
        {
            get { return Layout.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return Layout.TickerSrc; }
        }

        public string Root
        {
            get { return root ?? (root = Layout.Root.ToString()); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static RootKey GetCreateRootKey(RootKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            RootKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

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
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateRootKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateRootKey: SpinLock Miss");
                }
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
            get { return !Layout.IsEmpty && Layout.Root.Length > 0; }            
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

        public override string ToString()
        {
            return StringKey;
        }

        public int CompareTo(RootKey other)
        {
            if (other == null) return 1;
            return Layout.CompareTo(other.Layout);
        }
    }
} // namespace


