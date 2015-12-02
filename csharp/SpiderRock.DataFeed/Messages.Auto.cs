// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.PropertyValueCaching;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
	#region Core

	/// <summary>
	/// CCodeDefinition:110
	/// </summary>
	/// <remarks>
	/// Live Future Market Data 
	/// --- CCodeDefinition ---
	/// </remarks>

    public partial class CCodeDefinition
    {
		public CCodeDefinition()
		{
		}
		
		public CCodeDefinition(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public CCodeDefinition(CCodeDefinition source)
        {
            source.CopyTo(this);
        }
		
		internal CCodeDefinition(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as CCodeDefinition);
		}
		
		public bool Equals(CCodeDefinition other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(CCodeDefinition target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.CCodeDefinition};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private CCodeKey ccode;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ccode = other.ccode;
				
			}
			
			
			public CCodeKey Ccode
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ccode ?? (ccode = CCodeKey.GetCreateCCodeKey(body.ccode)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ccode = value.Layout; ccode = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ccode = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ccode = ccode;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ccode = ccode;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // CCodeDefinition.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public CCodeKeyLayout ccode;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ccode.Equals(other.ccode);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ccode.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // CCodeDefinition.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public FutExch futexch;
			public StockKeyLayout ticker;
			public SettleTime settleTime;
			public int positionLimit;
			public float contractSize;
			public double minTickSize;
			public FixedString6Layout clearingCode;
			public FixedString6Layout ricCode;
			public FixedString6Layout bbgRoot;
			public YellowKey bbgGroup;
			public FixedString48Layout description;
			public DateTimeLayout lastUpdate;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedStockKey ticker;
 		private CachedFixedLengthString<FixedString6Layout> clearingCode;
 		private CachedFixedLengthString<FixedString6Layout> ricCode;
 		private CachedFixedLengthString<FixedString6Layout> bbgRoot;
 		private CachedFixedLengthString<FixedString48Layout> description;
		


		/// <summary>listing exchange</summary>
        public FutExch Futexch { get { return body.futexch; } set { body.futexch = value; } }
             
		/// <summary>master underlying</summary>
        public StockKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		
        public SettleTime SettleTime { get { return body.settleTime; } set { body.settleTime = value; } }
 
		/// <summary>max contract limit</summary>
        public int PositionLimit { get { return body.positionLimit; } set { body.positionLimit = value; } }
 
		
        public float ContractSize { get { return body.contractSize; } set { body.contractSize = value; } }
 
		
        public double MinTickSize { get { return body.minTickSize; } set { body.minTickSize = value; } }
 
		/// <summary>GMI/Clearing code</summary>
        public string ClearingCode { get { return CacheVar.AllocIfNull(ref clearingCode).Get(ref body.clearingCode, usn); } set { CacheVar.AllocIfNull(ref clearingCode).Set(value); body.clearingCode = value; } }
 
		/// <summary>RIC Code</summary>
        public string RicCode { get { return CacheVar.AllocIfNull(ref ricCode).Get(ref body.ricCode, usn); } set { CacheVar.AllocIfNull(ref ricCode).Set(value); body.ricCode = value; } }
 
		/// <summary>Bloomberg root</summary>
        public string BbgRoot { get { return CacheVar.AllocIfNull(ref bbgRoot).Get(ref body.bbgRoot, usn); } set { CacheVar.AllocIfNull(ref bbgRoot).Set(value); body.bbgRoot = value; } }
 
		/// <summary>Bloomberg Yellow Key</summary>
        public YellowKey BbgGroup { get { return body.bbgGroup; } set { body.bbgGroup = value; } }
 
		
        public string Description { get { return CacheVar.AllocIfNull(ref description).Get(ref body.description, usn); } set { CacheVar.AllocIfNull(ref description).Set(value); body.description = value; } }
 
		
        public DateTime LastUpdate { get { return body.lastUpdate; } set { body.lastUpdate = value; } }

		
		#endregion	

    } // CCodeDefinition


	/// <summary>
	/// FutureBookQuote:111
	/// </summary>
	/// <remarks>
	/// --- FutureBookQuote ---
	/// </remarks>

    public partial class FutureBookQuote
    {
		public FutureBookQuote()
		{
		}
		
		public FutureBookQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public FutureBookQuote(FutureBookQuote source)
        {
            source.CopyTo(this);
        }
		
		internal FutureBookQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as FutureBookQuote);
		}
		
		public bool Equals(FutureBookQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(FutureBookQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.FutureBookQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private FutureKey fkey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				fkey = other.fkey;
				
			}
			
			
			public FutureKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = FutureKey.GetCreateFutureKey(body.fkey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.fkey = value.Layout; fkey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				fkey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.fkey = fkey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.fkey = fkey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // FutureBookQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public FutureKeyLayout fkey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	fkey.Equals(other.fkey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = fkey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // FutureBookQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public MarketStatus marketStatus;
			public double bidPrice1;
			public double askPrice1;
			public ushort bidSize1;
			public ushort askSize1;
			public ushort bidOrders1;
			public ushort askOrders1;
			public double bidPrice2;
			public double askPrice2;
			public ushort bidSize2;
			public ushort askSize2;
			public ushort bidOrders2;
			public ushort askOrders2;
			public double bidPrice3;
			public double askPrice3;
			public ushort bidSize3;
			public ushort askSize3;
			public ushort bidOrders3;
			public ushort askOrders3;
			public double bidPrice4;
			public double askPrice4;
			public ushort bidSize4;
			public ushort askSize4;
			public ushort bidOrders4;
			public ushort askOrders4;
			public int bidPrintQuan;
			public int askPrintQuan;
			public int timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>market status (open, halted, etc)</summary>
        public MarketStatus MarketStatus { get { return body.marketStatus; } set { body.marketStatus = value; } }
 
		/// <summary>bid price</summary>
        public double BidPrice1 { get { return body.bidPrice1; } set { body.bidPrice1 = value; } }
 
		/// <summary>ask price</summary>
        public double AskPrice1 { get { return body.askPrice1; } set { body.askPrice1 = value; } }
 
		/// <summary>bid size in contracts</summary>
        public ushort BidSize1 { get { return body.bidSize1; } set { body.bidSize1 = value; } }
 
		/// <summary>ask size in contracts</summary>
        public ushort AskSize1 { get { return body.askSize1; } set { body.askSize1 = value; } }
 
		/// <summary>number of participating orders at the bid price</summary>
        public ushort BidOrders1 { get { return body.bidOrders1; } set { body.bidOrders1 = value; } }
 
		/// <summary>number of participating orders at the ask price</summary>
        public ushort AskOrders1 { get { return body.askOrders1; } set { body.askOrders1 = value; } }
 
		/// <summary>bid price</summary>
        public double BidPrice2 { get { return body.bidPrice2; } set { body.bidPrice2 = value; } }
 
		/// <summary>ask price</summary>
        public double AskPrice2 { get { return body.askPrice2; } set { body.askPrice2 = value; } }
 
		/// <summary>bid size in contracts</summary>
        public ushort BidSize2 { get { return body.bidSize2; } set { body.bidSize2 = value; } }
 
		/// <summary>ask size in contracts</summary>
        public ushort AskSize2 { get { return body.askSize2; } set { body.askSize2 = value; } }
 
		/// <summary>number of participating orders at the bid price</summary>
        public ushort BidOrders2 { get { return body.bidOrders2; } set { body.bidOrders2 = value; } }
 
		/// <summary>number of participating orders at the ask price</summary>
        public ushort AskOrders2 { get { return body.askOrders2; } set { body.askOrders2 = value; } }
 
		/// <summary>bid price</summary>
        public double BidPrice3 { get { return body.bidPrice3; } set { body.bidPrice3 = value; } }
 
		/// <summary>ask price</summary>
        public double AskPrice3 { get { return body.askPrice3; } set { body.askPrice3 = value; } }
 
		/// <summary>bid size in contracts</summary>
        public ushort BidSize3 { get { return body.bidSize3; } set { body.bidSize3 = value; } }
 
		/// <summary>ask size in contracts</summary>
        public ushort AskSize3 { get { return body.askSize3; } set { body.askSize3 = value; } }
 
		/// <summary>number of participating orders at the bid price</summary>
        public ushort BidOrders3 { get { return body.bidOrders3; } set { body.bidOrders3 = value; } }
 
		/// <summary>number of participating orders at the ask price</summary>
        public ushort AskOrders3 { get { return body.askOrders3; } set { body.askOrders3 = value; } }
 
		/// <summary>bid price</summary>
        public double BidPrice4 { get { return body.bidPrice4; } set { body.bidPrice4 = value; } }
 
		/// <summary>ask price</summary>
        public double AskPrice4 { get { return body.askPrice4; } set { body.askPrice4 = value; } }
 
		/// <summary>bid size in contracts</summary>
        public ushort BidSize4 { get { return body.bidSize4; } set { body.bidSize4 = value; } }
 
		/// <summary>ask size in contracts</summary>
        public ushort AskSize4 { get { return body.askSize4; } set { body.askSize4 = value; } }
 
		/// <summary>number of participating orders at the bid price</summary>
        public ushort BidOrders4 { get { return body.bidOrders4; } set { body.bidOrders4 = value; } }
 
		/// <summary>number of participating orders at the ask price</summary>
        public ushort AskOrders4 { get { return body.askOrders4; } set { body.askOrders4 = value; } }
 
		
        public int BidPrintQuan { get { return body.bidPrintQuan; } set { body.bidPrintQuan = value; } }
 
		
        public int AskPrintQuan { get { return body.askPrintQuan; } set { body.askPrintQuan = value; } }
 
		/// <summary>milliseconds since midnight</summary>
        public int Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // FutureBookQuote


	/// <summary>
	/// FuturePrint:115
	/// </summary>
	/// <remarks>
	/// --- FuturePrint ---
	/// </remarks>

    public partial class FuturePrint
    {
		public FuturePrint()
		{
		}
		
		public FuturePrint(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public FuturePrint(FuturePrint source)
        {
            source.CopyTo(this);
        }
		
		internal FuturePrint(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as FuturePrint);
		}
		
		public bool Equals(FuturePrint other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(FuturePrint target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.FuturePrint};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private FutureKey fkey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				fkey = other.fkey;
				
			}
			
			
			public FutureKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = FutureKey.GetCreateFutureKey(body.fkey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.fkey = value.Layout; fkey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				fkey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.fkey = fkey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.fkey = fkey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // FuturePrint.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public FutureKeyLayout fkey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	fkey.Equals(other.fkey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = fkey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // FuturePrint.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public FutExch futexch;
			public double prtPrice;
			public int prtQuan;
			public int prtSize;
			public byte prtType;
			public ushort prtOrders;
			public int prtVolume;
			public ushort bidCount;
			public ushort askCount;
			public int bidVolume;
			public int askVolume;
			public double iniPrice;
			public double mrkPrice;
			public double opnPrice;
			public double clsPrice;
			public double minPrice;
			public double maxPrice;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>print exchange</summary>
        public FutExch Futexch { get { return body.futexch; } set { body.futexch = value; } }
 
		/// <summary>print price</summary>
        public double PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>print (cum) size [contracts]</summary>
        public int PrtQuan { get { return body.prtQuan; } set { body.prtQuan = value; } }
 
		/// <summary>print size [contracts]</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>print type [exchange specific]</summary>
        public byte PrtType { get { return body.prtType; } set { body.prtType = value; } }
 
		/// <summary>number of orders participating in this print</summary>
        public ushort PrtOrders { get { return body.prtOrders; } set { body.prtOrders = value; } }
 
		/// <summary>cumulative day (electronic) print volume in contracts</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		/// <summary>number of bid prints</summary>
        public ushort BidCount { get { return body.bidCount; } set { body.bidCount = value; } }
 
		/// <summary>number of ask prints</summary>
        public ushort AskCount { get { return body.askCount; } set { body.askCount = value; } }
 
		/// <summary>bid print volume in contracts</summary>
        public int BidVolume { get { return body.bidVolume; } set { body.bidVolume = value; } }
 
		/// <summary>ask print volume in contracts</summary>
        public int AskVolume { get { return body.askVolume; } set { body.askVolume = value; } }
 
		/// <summary>first print price of the session</summary>
        public double IniPrice { get { return body.iniPrice; } set { body.iniPrice = value; } }
 
		/// <summary>last print within the session; used for after hours marks</summary>
        public double MrkPrice { get { return body.mrkPrice; } set { body.mrkPrice = value; } }
 
		/// <summary>open price (prior day close)</summary>
        public double OpnPrice { get { return body.opnPrice; } set { body.opnPrice = value; } }
 
		/// <summary>official settlement price</summary>
        public double ClsPrice { get { return body.clsPrice; } set { body.clsPrice = value; } }
 
		/// <summary>minimum print price within session hours</summary>
        public double MinPrice { get { return body.minPrice; } set { body.minPrice = value; } }
 
		/// <summary>maximum print price within session hours</summary>
        public double MaxPrice { get { return body.maxPrice; } set { body.maxPrice = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // FuturePrint


	/// <summary>
	/// FutureSettlementMark:375
	/// </summary>
	/// <remarks>
	/// --- FutureSettlementMark ---
	/// </remarks>

    public partial class FutureSettlementMark
    {
		public FutureSettlementMark()
		{
		}
		
		public FutureSettlementMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public FutureSettlementMark(FutureSettlementMark source)
        {
            source.CopyTo(this);
        }
		
		internal FutureSettlementMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as FutureSettlementMark);
		}
		
		public bool Equals(FutureSettlementMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(FutureSettlementMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.FutureSettlementMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private FutureKey fkey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				fkey = other.fkey;
				
			}
			
			
			public FutureKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = FutureKey.GetCreateFutureKey(body.fkey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.fkey = value.Layout; fkey = value; }
			}
 			
			public YesNo Early
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.early; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.early = value; }
			}
 			
			public YesNo PriorPeriod
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.priorPeriod; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.priorPeriod = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				fkey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.fkey = fkey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.fkey = fkey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // FutureSettlementMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public FutureKeyLayout fkey;
 			public YesNo early;
 			public YesNo priorPeriod;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	fkey.Equals(other.fkey) &&
					 	early.Equals(other.early) &&
					 	priorPeriod.Equals(other.priorPeriod);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = fkey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) early);
 					hashCode = (hashCode*397) ^ ((int) priorPeriod);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // FutureSettlementMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public DateKeyLayout settleDate;
			public double settlePx;
			public double lowLmtPx;
			public double highLmtPx;
			public int openInt;
			public int volume;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedDateKey settleDate;
		

            
		
        public DateKey SettleDate { get { return CacheVar.AllocIfNull(ref settleDate).Get(ref body.settleDate, usn); } set { CacheVar.AllocIfNull(ref settleDate).Set(value); body.settleDate = value.Layout; } }
 
		/// <summary>Exchange settlement price</summary>
        public double SettlePx { get { return body.settlePx; } set { body.settlePx = value; } }
 
		/// <summary>Exchange low limit price</summary>
        public double LowLmtPx { get { return body.lowLmtPx; } set { body.lowLmtPx = value; } }
 
		/// <summary>Exchange high limit price</summary>
        public double HighLmtPx { get { return body.highLmtPx; } set { body.highLmtPx = value; } }
 
		/// <summary>Exchange open interest (date prior to settle date)</summary>
        public int OpenInt { get { return body.openInt; } set { body.openInt = value; } }
 
		/// <summary>Exchange volume (date prior to settle date)</summary>
        public int Volume { get { return body.volume; } set { body.volume = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // FutureSettlementMark


	/// <summary>
	/// LiveSurfaceAtm:356
	/// </summary>
	/// <remarks>
	/// Live Surface Atm Records
	/// LiveSurfaceAtm
	/// note: this records is computed live during the day
	/// </remarks>

    public partial class LiveSurfaceAtm
    {
		public LiveSurfaceAtm()
		{
		}
		
		public LiveSurfaceAtm(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public LiveSurfaceAtm(LiveSurfaceAtm source)
        {
            source.CopyTo(this);
        }
		
		internal LiveSurfaceAtm(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as LiveSurfaceAtm);
		}
		
		public bool Equals(LiveSurfaceAtm other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(LiveSurfaceAtm target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.LiveSurfaceAtm};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private FutureKey fkey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				fkey = other.fkey;
				
			}
			
			
			public FutureKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = FutureKey.GetCreateFutureKey(body.fkey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.fkey = value.Layout; fkey = value; }
			}
 			
			public LiveSurfaceType SurfaceType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.surfaceType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.surfaceType = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				fkey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.fkey = fkey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.fkey = fkey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // LiveSurfaceAtm.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public FutureKeyLayout fkey;
 			public LiveSurfaceType surfaceType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	fkey.Equals(other.fkey) &&
					 	surfaceType.Equals(other.surfaceType);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = fkey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) surfaceType);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // LiveSurfaceAtm.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public StockKeyLayout ticker;
			public float uBid;
			public float uAsk;
			public float years;
			public float rate;
			public float sdiv;
			public float ddiv;
			public byte exType;
			public float axisVol;
			public float cAtm;
			public float pAtm;
			public float adjDI;
			public float adjD8;
			public float adjD7;
			public float adjD6;
			public float adjD5;
			public float adjD4;
			public float adjD3;
			public float adjD2;
			public float adjD1;
			public float adjU1;
			public float adjU2;
			public float adjU3;
			public float adjU4;
			public float adjU5;
			public float adjU6;
			public float adjU7;
			public float adjU8;
			public float adjUI;
			public float slope;
			public float cmult;
			public float pwidth;
			public float vwidth;
			public float sdivEMA;
			public float sdivLoEMA;
			public float sdivHiEMA;
			public float atmMAC;
			public float cprMAC;
			public float cAtmMove;
			public float pAtmMove;
			public byte cCnt;
			public byte pCnt;
			public byte cBidMiss;
			public byte cAskMiss;
			public byte pBidMiss;
			public byte pAskMiss;
			public float fitAvgErr;
			public float fitAvgAbsErr;
			public float fitMaxPrcErr;
			public float fitErrXX;
			public CallOrPut fitErrCP;
			public float fitErrBid;
			public float fitErrAsk;
			public float fitErrPrc;
			public float fitErrVol;
			public FitType fitType;
			public FutureKeyLayout sFKey;
			public LiveSurfaceType sType;
			public DateTimeLayout sTimestamp;
			public int counter;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedStockKey ticker;
 		private CachedFutureKey sFKey;
		

            
		
        public StockKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>underlyer bid price</summary>
        public float UBid { get { return body.uBid; } set { body.uBid = value; } }
 
		/// <summary>underlyer ask price</summary>
        public float UAsk { get { return body.uAsk; } set { body.uAsk = value; } }
 
		/// <summary>time to expiration (in years)</summary>
        public float Years { get { return body.years; } set { body.years = value; } }
 
		/// <summary>interest rate</summary>
        public float Rate { get { return body.rate; } set { body.rate = value; } }
 
		/// <summary>stock dividend (borrow rate)</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>present value of discrete dividend stream</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>exercise type of the options used to compute this surface</summary>
        public byte ExType { get { return body.exType; } set { body.exType = value; } }
 
		/// <summary>axis volatility (vol used to compute xAxis) [usually atm vol]</summary>
        public float AxisVol { get { return body.axisVol; } set { body.axisVol = value; } }
 
		/// <summary>call atm vol (xAxis = 0)</summary>
        public float CAtm { get { return body.cAtm; } set { body.cAtm = value; } }
 
		/// <summary>put atm vol (xAxis = 0)</summary>
        public float PAtm { get { return body.pAtm; } set { body.pAtm = value; } }
 
		/// <summary>h (x-axis step size; usually 0.5) [xAxis = (effStrike / fwdEffUPrc - 1.0) / volRT; fwdEffUPrc = effUPrc * exp(lsa.years * lsa.rate) - lsa.ddiv; volRT = axisVol * sqrt(max(1.0/252.0, lsa.years))]</summary>
        public float AdjDI { get { return body.adjDI; } set { body.adjDI = value; } }
 
		/// <summary>dn 8 steps [strikeVol = (cAtm|pAtm) * (SkewSpline(xAxis) + 1.0)]</summary>
        public float AdjD8 { get { return body.adjD8; } set { body.adjD8 = value; } }
 
		/// <summary>dn 7 steps</summary>
        public float AdjD7 { get { return body.adjD7; } set { body.adjD7 = value; } }
 
		/// <summary>dn 6 steps</summary>
        public float AdjD6 { get { return body.adjD6; } set { body.adjD6 = value; } }
 
		/// <summary>dn 5 steps</summary>
        public float AdjD5 { get { return body.adjD5; } set { body.adjD5 = value; } }
 
		/// <summary>dn 4 steps</summary>
        public float AdjD4 { get { return body.adjD4; } set { body.adjD4 = value; } }
 
		/// <summary>dn 3 steps</summary>
        public float AdjD3 { get { return body.adjD3; } set { body.adjD3 = value; } }
 
		/// <summary>dn 2 steps</summary>
        public float AdjD2 { get { return body.adjD2; } set { body.adjD2 = value; } }
 
		/// <summary>dn 1 step</summary>
        public float AdjD1 { get { return body.adjD1; } set { body.adjD1 = value; } }
 
		/// <summary>up 1 step</summary>
        public float AdjU1 { get { return body.adjU1; } set { body.adjU1 = value; } }
 
		/// <summary>up 2 steps</summary>
        public float AdjU2 { get { return body.adjU2; } set { body.adjU2 = value; } }
 
		/// <summary>up 3 steps</summary>
        public float AdjU3 { get { return body.adjU3; } set { body.adjU3 = value; } }
 
		/// <summary>up 4 steps</summary>
        public float AdjU4 { get { return body.adjU4; } set { body.adjU4 = value; } }
 
		/// <summary>up 5 steps</summary>
        public float AdjU5 { get { return body.adjU5; } set { body.adjU5 = value; } }
 
		/// <summary>up 6 steps</summary>
        public float AdjU6 { get { return body.adjU6; } set { body.adjU6 = value; } }
 
		/// <summary>up 7 steps</summary>
        public float AdjU7 { get { return body.adjU7; } set { body.adjU7 = value; } }
 
		/// <summary>up 8 steps</summary>
        public float AdjU8 { get { return body.adjU8; } set { body.adjU8 = value; } }
 
		/// <summary>unused</summary>
        public float AdjUI { get { return body.adjUI; } set { body.adjUI = value; } }
 
		/// <summary>surface slope (dVol / dXAxis) @ ATM (x=0)</summary>
        public float Slope { get { return body.slope; } set { body.slope = value; } }
 
		/// <summary>unused (always 1.0)</summary>
        public float Cmult { get { return body.cmult; } set { body.cmult = value; } }
 
		/// <summary>minimum mkt premium width</summary>
        public float Pwidth { get { return body.pwidth; } set { body.pwidth = value; } }
 
		/// <summary>minimum mkt volatility width</summary>
        public float Vwidth { get { return body.vwidth; } set { body.vwidth = value; } }
 
		/// <summary>sdiv exp moving average (10 minutes)</summary>
        public float SdivEMA { get { return body.sdivEMA; } set { body.sdivEMA = value; } }
 
		/// <summary>maximum sdiv bid (all markets in this expiration)</summary>
        public float SdivLoEMA { get { return body.sdivLoEMA; } set { body.sdivLoEMA = value; } }
 
		/// <summary>minimum sdiv ask (all markets in this expiration)</summary>
        public float SdivHiEMA { get { return body.sdivHiEMA; } set { body.sdivHiEMA = value; } }
 
		
        public float AtmMAC { get { return body.atmMAC; } set { body.atmMAC = value; } }
 
		
        public float CprMAC { get { return body.cprMAC; } set { body.cprMAC = value; } }
 
		/// <summary>fixed strike cAtm move from prior period</summary>
        public float CAtmMove { get { return body.cAtmMove; } set { body.cAtmMove = value; } }
 
		/// <summary>fixed strike pAtm move from prior period</summary>
        public float PAtmMove { get { return body.pAtmMove; } set { body.pAtmMove = value; } }
 
		/// <summary>num call strikes</summary>
        public byte CCnt { get { return body.cCnt; } set { body.cCnt = value; } }
 
		/// <summary>num put strikes</summary>
        public byte PCnt { get { return body.pCnt; } set { body.pCnt = value; } }
 
		/// <summary>number of call bid violations (surface outside the market)</summary>
        public byte CBidMiss { get { return body.cBidMiss; } set { body.cBidMiss = value; } }
 
		/// <summary>number of call ask violations (surface outside the market)</summary>
        public byte CAskMiss { get { return body.cAskMiss; } set { body.cAskMiss = value; } }
 
		/// <summary>number of put bid violations</summary>
        public byte PBidMiss { get { return body.pBidMiss; } set { body.pBidMiss = value; } }
 
		/// <summary>number of put ask violations</summary>
        public byte PAskMiss { get { return body.pAskMiss; } set { body.pAskMiss = value; } }
 
		/// <summary>surface fit R2 (mid-market values)</summary>
        public float FitAvgErr { get { return body.fitAvgErr; } set { body.fitAvgErr = value; } }
 
		/// <summary>mean square error (mid-market values)</summary>
        public float FitAvgAbsErr { get { return body.fitAvgAbsErr; } set { body.fitAvgAbsErr = value; } }
 
		/// <summary>worst case surface premium violation</summary>
        public float FitMaxPrcErr { get { return body.fitMaxPrcErr; } set { body.fitMaxPrcErr = value; } }
 
		/// <summary>okey_xx of the option with the largest fit error in this expiration</summary>
        public float FitErrXX { get { return body.fitErrXX; } set { body.fitErrXX = value; } }
 
		/// <summary>okey_cp of the option with the largest fit error in this expiration</summary>
        public CallOrPut FitErrCP { get { return body.fitErrCP; } set { body.fitErrCP = value; } }
 
		/// <summary>bid of the option with the largest fit error</summary>
        public float FitErrBid { get { return body.fitErrBid; } set { body.fitErrBid = value; } }
 
		/// <summary>ask of the option with the largest fit error</summary>
        public float FitErrAsk { get { return body.fitErrAsk; } set { body.fitErrAsk = value; } }
 
		/// <summary>surface prc of the option with the largest fit error</summary>
        public float FitErrPrc { get { return body.fitErrPrc; } set { body.fitErrPrc = value; } }
 
		/// <summary>surface vol of the option with the largest fit error</summary>
        public float FitErrVol { get { return body.fitErrVol; } set { body.fitErrVol = value; } }
 
		/// <summary>type of surface fit used</summary>
        public FitType FitType { get { return body.fitType; } set { body.fitType = value; } }
             
		/// <summary>overnight LiveSurfaceSpline used for surface</summary>
        public FutureKey SFKey { get { return CacheVar.AllocIfNull(ref sFKey).Get(ref body.sFKey, usn); } set { CacheVar.AllocIfNull(ref sFKey).Set(value); body.sFKey = value.Layout; } }
 
		
        public LiveSurfaceType SType { get { return body.sType; } set { body.sType = value; } }
 
		/// <summary>[date/time from LiveSurfaceSpline record]</summary>
        public DateTime STimestamp { get { return body.sTimestamp; } set { body.sTimestamp = value; } }
 
		/// <summary>message counter - number of surface fits today</summary>
        public int Counter { get { return body.counter; } set { body.counter = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // LiveSurfaceAtm


	/// <summary>
	/// OptionCloseMark:373
	/// </summary>
	/// <remarks>
	/// --- OptionCloseMark ---
	/// </remarks>

    public partial class OptionCloseMark
    {
		public OptionCloseMark()
		{
		}
		
		public OptionCloseMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionCloseMark(OptionCloseMark source)
        {
            source.CopyTo(this);
        }
		
		internal OptionCloseMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionCloseMark);
		}
		
		public bool Equals(OptionCloseMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionCloseMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionCloseMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionCloseMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionCloseMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float uBid;
			public float uAsk;
			public float bidPx;
			public float askPx;
			public float bidIV;
			public float askIV;
			public float srPrc;
			public float srVol;
			public MarkSource srSrc;
			public float de;
			public float ga;
			public float th;
			public float ve;
			public float rh;
			public float ph;
			public float sdiv;
			public float ddiv;
			public float rate;
			public byte error;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>SR closing underlyer bid</summary>
        public float UBid { get { return body.uBid; } set { body.uBid = value; } }
 
		/// <summary>SR closing underlyer ask</summary>
        public float UAsk { get { return body.uAsk; } set { body.uAsk = value; } }
 
		/// <summary>SR closing underlyer bid</summary>
        public float BidPx { get { return body.bidPx; } set { body.bidPx = value; } }
 
		/// <summary>SR closing underlyer ask</summary>
        public float AskPx { get { return body.askPx; } set { body.askPx = value; } }
 
		/// <summary>implied vol of SR closing bid price</summary>
        public float BidIV { get { return body.bidIV; } set { body.bidIV = value; } }
 
		/// <summary>implied vol of SR closing ask price</summary>
        public float AskIV { get { return body.askIV; } set { body.askIV = value; } }
 
		/// <summary>SR surface price (always within bidPx/askPx)</summary>
        public float SrPrc { get { return body.srPrc; } set { body.srPrc = value; } }
 
		/// <summary>SR surface volatility</summary>
        public float SrVol { get { return body.srVol; } set { body.srVol = value; } }
 
		
        public MarkSource SrSrc { get { return body.srSrc; } set { body.srSrc = value; } }
 
		/// <summary>greeks from SR surface volatility</summary>
        public float De { get { return body.de; } set { body.de = value; } }
 
		
        public float Ga { get { return body.ga; } set { body.ga = value; } }
 
		
        public float Th { get { return body.th; } set { body.th = value; } }
 
		
        public float Ve { get { return body.ve; } set { body.ve = value; } }
 
		
        public float Rh { get { return body.rh; } set { body.rh = value; } }
 
		
        public float Ph { get { return body.ph; } set { body.ph = value; } }
 
		/// <summary>SR sdiv rate</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>SR ddiv rate</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>SR interest rate</summary>
        public float Rate { get { return body.rate; } set { body.rate = value; } }
 
		/// <summary>SRPricingLib.CalcError</summary>
        public byte Error { get { return body.error; } set { body.error = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionCloseMark


	/// <summary>
	/// OptionCloseQuote:104
	/// </summary>
	/// <remarks>
	/// --- OptionCloseQuote ---
	/// </remarks>

    public partial class OptionCloseQuote
    {
		public OptionCloseQuote()
		{
		}
		
		public OptionCloseQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionCloseQuote(OptionCloseQuote source)
        {
            source.CopyTo(this);
        }
		
		internal OptionCloseQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionCloseQuote);
		}
		
		public bool Equals(OptionCloseQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionCloseQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionCloseQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionCloseQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionCloseQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrice;
			public float askPrice;
			public ushort bidSize;
			public ushort askSize;
			public OptExch bidExch;
			public OptExch askExch;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price</summary>
        public float BidPrice { get { return body.bidPrice; } set { body.bidPrice = value; } }
 
		/// <summary>ask price</summary>
        public float AskPrice { get { return body.askPrice; } set { body.askPrice = value; } }
 
		/// <summary>bid size in contracts (largest exch quote)</summary>
        public ushort BidSize { get { return body.bidSize; } set { body.bidSize = value; } }
 
		/// <summary>ask size in contracts (largest exch quote)</summary>
        public ushort AskSize { get { return body.askSize; } set { body.askSize = value; } }
 
		/// <summary>first (or largest remaining) exchange at bid price</summary>
        public OptExch BidExch { get { return body.bidExch; } set { body.bidExch = value; } }
 
		/// <summary>first (or largest remaining) exchange at ask price</summary>
        public OptExch AskExch { get { return body.askExch; } set { body.askExch = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionCloseQuote


	/// <summary>
	/// OptionImpliedQuote:377
	/// </summary>
	/// <remarks>
	/// --- OptionImpliedQuote ---
	/// </remarks>

    public partial class OptionImpliedQuote
    {
		public OptionImpliedQuote()
		{
		}
		
		public OptionImpliedQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionImpliedQuote(OptionImpliedQuote source)
        {
            source.CopyTo(this);
        }
		
		internal OptionImpliedQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionImpliedQuote);
		}
		
		public bool Equals(OptionImpliedQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionImpliedQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionImpliedQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionImpliedQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionImpliedQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public StockKeyLayout ticker;
			public float uprc;
			public float years;
			public float rate;
			public float sdiv;
			public float ddiv;
			public float obid;
			public float oask;
			public float obiv;
			public float oaiv;
			public float satm;
			public float smny;
			public float svol;
			public float sprc;
			public float smrk;
			public float de;
			public float ga;
			public float th;
			public float ve;
			public float ro;
			public float ph;
			public float up50;
			public float dn50;
			public float up15;
			public float dn15;
			public float up06;
			public float dn08;
			public FixedString16Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedStockKey ticker;
 		private CachedFixedLengthString<FixedString16Layout> calcErr;
		

            
		
        public StockKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>underlyer price (usually mid-market)</summary>
        public float Uprc { get { return body.uprc; } set { body.uprc = value; } }
 
		/// <summary>years to expiration</summary>
        public float Years { get { return body.years; } set { body.years = value; } }
 
		/// <summary>interest rate</summary>
        public float Rate { get { return body.rate; } set { body.rate = value; } }
 
		/// <summary>sdiv (stock dividend) rate</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>cumulative discrete dividend values</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>option bid price</summary>
        public float Obid { get { return body.obid; } set { body.obid = value; } }
 
		/// <summary>option ask price</summary>
        public float Oask { get { return body.oask; } set { body.oask = value; } }
 
		/// <summary>volatility implied by option bid price</summary>
        public float Obiv { get { return body.obiv; } set { body.obiv = value; } }
 
		/// <summary>volatility implied by option ask price</summary>
        public float Oaiv { get { return body.oaiv; } set { body.oaiv = value; } }
 
		/// <summary>option atm volatility (from SR surface)</summary>
        public float Satm { get { return body.satm; } set { body.satm = value; } }
 
		/// <summary>option moneyness</summary>
        public float Smny { get { return body.smny; } set { body.smny = value; } }
 
		/// <summary>option surface volatility</summary>
        public float Svol { get { return body.svol; } set { body.svol = value; } }
 
		/// <summary>option surface price</summary>
        public float Sprc { get { return body.sprc; } set { body.sprc = value; } }
 
		/// <summary>option surface mark (option surface price w/bounding rules)</summary>
        public float Smrk { get { return body.smrk; } set { body.smrk = value; } }
 
		/// <summary>option delta (from svol)</summary>
        public float De { get { return body.de; } set { body.de = value; } }
 
		/// <summary>option gamma (from svol)</summary>
        public float Ga { get { return body.ga; } set { body.ga = value; } }
 
		/// <summary>option theta (from svol)</summary>
        public float Th { get { return body.th; } set { body.th = value; } }
 
		/// <summary>option vega (from svol)</summary>
        public float Ve { get { return body.ve; } set { body.ve = value; } }
 
		/// <summary>option rho (from svol)</summary>
        public float Ro { get { return body.ro; } set { body.ro = value; } }
 
		/// <summary>option phi (from svol)</summary>
        public float Ph { get { return body.ph; } set { body.ph = value; } }
 
		/// <summary>underlyer up 50% slide</summary>
        public float Up50 { get { return body.up50; } set { body.up50 = value; } }
 
		/// <summary>underlyer dn 50% slide</summary>
        public float Dn50 { get { return body.dn50; } set { body.dn50 = value; } }
 
		/// <summary>underlyer up 15% slide</summary>
        public float Up15 { get { return body.up15; } set { body.up15 = value; } }
 
		/// <summary>underlyer dn 15% slide</summary>
        public float Dn15 { get { return body.dn15; } set { body.dn15 = value; } }
 
		/// <summary>underlyer up 6% slide</summary>
        public float Up06 { get { return body.up06; } set { body.up06 = value; } }
 
		/// <summary>underlyer dn 8% slide</summary>
        public float Dn08 { get { return body.dn08; } set { body.dn08 = value; } }
 
		/// <summary>option pricing error, otherwise, an empty string.  pertains to the Greeks (de, ga, th, ve, ro, ph) and sprc</summary>
        public string CalcErr { get { return CacheVar.AllocIfNull(ref calcErr).Get(ref body.calcErr, usn); } set { CacheVar.AllocIfNull(ref calcErr).Set(value); body.calcErr = value; } }
 
		/// <summary>Tick=from NBBO quote change; Loop=from background loop; Close=Final EOD record;</summary>
        public CalcSource CalcSource { get { return body.calcSource; } set { body.calcSource = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionImpliedQuote


	/// <summary>
	/// OptionNbboQuote:102
	/// </summary>
	/// <remarks>
	/// --- OptionNbboQuote ---
	/// </remarks>

    public partial class OptionNbboQuote
    {
		public OptionNbboQuote()
		{
		}
		
		public OptionNbboQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionNbboQuote(OptionNbboQuote source)
        {
            source.CopyTo(this);
        }
		
		internal OptionNbboQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionNbboQuote);
		}
		
		public bool Equals(OptionNbboQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionNbboQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionNbboQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionNbboQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionNbboQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrice;
			public float askPrice;
			public ushort bidSize;
			public ushort askSize;
			public ushort cumBidSize;
			public ushort cumAskSize;
			public OptExch bidExch;
			public OptExch askExch;
			public uint bidMask;
			public uint askMask;
			public float bidPrice2;
			public float askPrice2;
			public ushort cumBidSize2;
			public ushort cumAskSize2;
			public int bidTime;
			public int askTime;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price</summary>
        public float BidPrice { get { return body.bidPrice; } set { body.bidPrice = value; } }
 
		/// <summary>ask price</summary>
        public float AskPrice { get { return body.askPrice; } set { body.askPrice = value; } }
 
		/// <summary>bid size in contracts (largest exch quote)</summary>
        public ushort BidSize { get { return body.bidSize; } set { body.bidSize = value; } }
 
		/// <summary>ask size in contracts (largest exch quote)</summary>
        public ushort AskSize { get { return body.askSize; } set { body.askSize = value; } }
 
		/// <summary>bid size in contracts (total nbbo size)</summary>
        public ushort CumBidSize { get { return body.cumBidSize; } set { body.cumBidSize = value; } }
 
		/// <summary>ask size in contracts (total nbbo size)</summary>
        public ushort CumAskSize { get { return body.cumAskSize; } set { body.cumAskSize = value; } }
 
		/// <summary>first (or largest remaining) exchange at bid price</summary>
        public OptExch BidExch { get { return body.bidExch; } set { body.bidExch = value; } }
 
		/// <summary>first (or largest remaining) exchange at ask price</summary>
        public OptExch AskExch { get { return body.askExch; } set { body.askExch = value; } }
 
		/// <summary>exchange bid bit mask</summary>
        public uint BidMask { get { return body.bidMask; } set { body.bidMask = value; } }
 
		/// <summary>exchange ask bit mask</summary>
        public uint AskMask { get { return body.askMask; } set { body.askMask = value; } }
 
		/// <summary>2nd best bid price</summary>
        public float BidPrice2 { get { return body.bidPrice2; } set { body.bidPrice2 = value; } }
 
		/// <summary>2nd best ask price</summary>
        public float AskPrice2 { get { return body.askPrice2; } set { body.askPrice2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort CumBidSize2 { get { return body.cumBidSize2; } set { body.cumBidSize2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort CumAskSize2 { get { return body.cumAskSize2; } set { body.cumAskSize2 = value; } }
 
		/// <summary>last bid price change (milliseconds since midnight)</summary>
        public int BidTime { get { return body.bidTime; } set { body.bidTime = value; } }
 
		/// <summary>last ask price change (milliseconds since midnight)</summary>
        public int AskTime { get { return body.askTime; } set { body.askTime = value; } }

		
		#endregion	

    } // OptionNbboQuote


	/// <summary>
	/// OptionOpenMark:105
	/// </summary>
	/// <remarks>
	/// --- OptionOpenMark ---
	/// </remarks>

    public partial class OptionOpenMark
    {
		public OptionOpenMark()
		{
		}
		
		public OptionOpenMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionOpenMark(OptionOpenMark source)
        {
            source.CopyTo(this);
        }
		
		internal OptionOpenMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionOpenMark);
		}
		
		public bool Equals(OptionOpenMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionOpenMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionOpenMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionOpenMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionOpenMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float uBid;
			public float uAsk;
			public float bidPx;
			public float askPx;
			public float bidIV;
			public float askIV;
			public float srPrc;
			public float srVol;
			public MarkSource srSrc;
			public float de;
			public float ga;
			public float th;
			public float ve;
			public float rh;
			public float ph;
			public float sdiv;
			public float ddiv;
			public float rate;
			public byte error;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>SR closing bid</summary>
        public float UBid { get { return body.uBid; } set { body.uBid = value; } }
 
		/// <summary>SR closing ask</summary>
        public float UAsk { get { return body.uAsk; } set { body.uAsk = value; } }
 
		/// <summary>SR closing bid</summary>
        public float BidPx { get { return body.bidPx; } set { body.bidPx = value; } }
 
		/// <summary>SR closing ask</summary>
        public float AskPx { get { return body.askPx; } set { body.askPx = value; } }
 
		/// <summary>implied vol of SR closing bid price</summary>
        public float BidIV { get { return body.bidIV; } set { body.bidIV = value; } }
 
		/// <summary>implied vol of SR closing ask price</summary>
        public float AskIV { get { return body.askIV; } set { body.askIV = value; } }
 
		/// <summary>SR surface price (always within bidPx/askPx)</summary>
        public float SrPrc { get { return body.srPrc; } set { body.srPrc = value; } }
 
		/// <summary>SR surface volatility</summary>
        public float SrVol { get { return body.srVol; } set { body.srVol = value; } }
 
		
        public MarkSource SrSrc { get { return body.srSrc; } set { body.srSrc = value; } }
 
		/// <summary>greeks from SR surface volatility</summary>
        public float De { get { return body.de; } set { body.de = value; } }
 
		
        public float Ga { get { return body.ga; } set { body.ga = value; } }
 
		
        public float Th { get { return body.th; } set { body.th = value; } }
 
		
        public float Ve { get { return body.ve; } set { body.ve = value; } }
 
		
        public float Rh { get { return body.rh; } set { body.rh = value; } }
 
		
        public float Ph { get { return body.ph; } set { body.ph = value; } }
 
		/// <summary>SR live sdiv rate</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>SR live ddiv rate</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>SR live int rate</summary>
        public float Rate { get { return body.rate; } set { body.rate = value; } }
 
		/// <summary>SRPricingLib.CalcError</summary>
        public byte Error { get { return body.error; } set { body.error = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionOpenMark


	/// <summary>
	/// OptionPrint:106
	/// </summary>
	/// <remarks>
	/// --- OptionPrint ---
	/// </remarks>

    public partial class OptionPrint
    {
		public OptionPrint()
		{
		}
		
		public OptionPrint(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionPrint(OptionPrint source)
        {
            source.CopyTo(this);
        }
		
		internal OptionPrint(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionPrint);
		}
		
		public bool Equals(OptionPrint other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionPrint target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionPrint};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}
 			
			public OptExch Exch
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.exch; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.exch = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionPrint.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;
 			public OptExch exch;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey) &&
					 	exch.Equals(other.exch);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) exch);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionPrint.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float prtPrice;
			public int prtSize;
			public byte prtType;
			public ushort prtOrders;
			public int prtVolume;
			public int cxlVolume;
			public float lastPrice;
			public int lastSize;
			public DateTimeLayout lastTime;
			public ushort bidCount;
			public ushort askCount;
			public int bidVolume;
			public int askVolume;
			public float ebid;
			public float eask;
			public ushort ebsz;
			public ushort easz;
			public float eage;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>print price</summary>
        public float PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>print size [contracts]</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>print type</summary>
        public byte PrtType { get { return body.prtType; } set { body.prtType = value; } }
 
		/// <summary>number of participating orders</summary>
        public ushort PrtOrders { get { return body.prtOrders; } set { body.prtOrders = value; } }
 
		/// <summary>day print volume in contracts [this exchange]</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		/// <summary>day print/cancel volume (num of contracts printed and then cancelled)</summary>
        public int CxlVolume { get { return body.cxlVolume; } set { body.cxlVolume = value; } }
 
		
        public float LastPrice { get { return body.lastPrice; } set { body.lastPrice = value; } }
 
		
        public int LastSize { get { return body.lastSize; } set { body.lastSize = value; } }
 
		
        public DateTime LastTime { get { return body.lastTime; } set { body.lastTime = value; } }
 
		/// <summary>number of bid prints</summary>
        public ushort BidCount { get { return body.bidCount; } set { body.bidCount = value; } }
 
		/// <summary>number of ask prints</summary>
        public ushort AskCount { get { return body.askCount; } set { body.askCount = value; } }
 
		/// <summary>bid print volume in contracts</summary>
        public int BidVolume { get { return body.bidVolume; } set { body.bidVolume = value; } }
 
		/// <summary>ask print volume in contracts</summary>
        public int AskVolume { get { return body.askVolume; } set { body.askVolume = value; } }
 
		/// <summary>exchange bid (at print -1.0 sec)</summary>
        public float Ebid { get { return body.ebid; } set { body.ebid = value; } }
 
		/// <summary>exchange ask</summary>
        public float Eask { get { return body.eask; } set { body.eask = value; } }
 
		/// <summary>exchange bid size</summary>
        public ushort Ebsz { get { return body.ebsz; } set { body.ebsz = value; } }
 
		/// <summary>exchange ask size</summary>
        public ushort Easz { get { return body.easz; } set { body.easz = value; } }
 
		/// <summary>age of prevailing quote at time of print</summary>
        public float Eage { get { return body.eage; } set { body.eage = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionPrint


	/// <summary>
	/// OptionRiskFactor:379
	/// </summary>
	/// <remarks>
	/// --- OptionRiskFactor ---
	/// </remarks>

    public partial class OptionRiskFactor
    {
		public OptionRiskFactor()
		{
		}
		
		public OptionRiskFactor(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionRiskFactor(OptionRiskFactor source)
        {
            source.CopyTo(this);
        }
		
		internal OptionRiskFactor(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionRiskFactor);
		}
		
		public bool Equals(OptionRiskFactor other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionRiskFactor target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionRiskFactor};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionRiskFactor.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionRiskFactor.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public StockKeyLayout ticker;
			public float uprc;
			public float years;
			public float svol;
			public float sprc;
			public float de;
			public float obid;
			public float oask;
			public float up15;
			public float dn15;
			public float up12;
			public float dn12;
			public float up09;
			public float dn09;
			public float dn08;
			public float up06;
			public float dn06;
			public float up03;
			public float dn03;
			public FixedString16Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedStockKey ticker;
 		private CachedFixedLengthString<FixedString16Layout> calcErr;
		

            
		
        public StockKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>underlyer price (usually mid-market)</summary>
        public float Uprc { get { return body.uprc; } set { body.uprc = value; } }
 
		/// <summary>years to expiration</summary>
        public float Years { get { return body.years; } set { body.years = value; } }
 
		/// <summary>option surface volatility</summary>
        public float Svol { get { return body.svol; } set { body.svol = value; } }
 
		/// <summary>option surface price</summary>
        public float Sprc { get { return body.sprc; } set { body.sprc = value; } }
 
		/// <summary>option delta (from svol)</summary>
        public float De { get { return body.de; } set { body.de = value; } }
 
		/// <summary>option bid price</summary>
        public float Obid { get { return body.obid; } set { body.obid = value; } }
 
		/// <summary>option ask price</summary>
        public float Oask { get { return body.oask; } set { body.oask = value; } }
 
		/// <summary>underlyer up 15% slide</summary>
        public float Up15 { get { return body.up15; } set { body.up15 = value; } }
 
		/// <summary>underlyer dn 15% slide</summary>
        public float Dn15 { get { return body.dn15; } set { body.dn15 = value; } }
 
		/// <summary>underlyer up 12% slide</summary>
        public float Up12 { get { return body.up12; } set { body.up12 = value; } }
 
		/// <summary>underlyer dn 12% slide</summary>
        public float Dn12 { get { return body.dn12; } set { body.dn12 = value; } }
 
		/// <summary>underlyer up 9% slide</summary>
        public float Up09 { get { return body.up09; } set { body.up09 = value; } }
 
		/// <summary>underlyer dn 9% slide</summary>
        public float Dn09 { get { return body.dn09; } set { body.dn09 = value; } }
 
		/// <summary>underlyer dn 8% slide</summary>
        public float Dn08 { get { return body.dn08; } set { body.dn08 = value; } }
 
		/// <summary>underlyer up 6% slide</summary>
        public float Up06 { get { return body.up06; } set { body.up06 = value; } }
 
		/// <summary>underlyer dn 6% slide</summary>
        public float Dn06 { get { return body.dn06; } set { body.dn06 = value; } }
 
		/// <summary>underlyer up 3% slide</summary>
        public float Up03 { get { return body.up03; } set { body.up03 = value; } }
 
		/// <summary>underlyer dn 3% slide</summary>
        public float Dn03 { get { return body.dn03; } set { body.dn03 = value; } }
 
		/// <summary>option pricing error, otherwise, an empty string.</summary>
        public string CalcErr { get { return CacheVar.AllocIfNull(ref calcErr).Get(ref body.calcErr, usn); } set { CacheVar.AllocIfNull(ref calcErr).Set(value); body.calcErr = value; } }
 
		
        public CalcSource CalcSource { get { return body.calcSource; } set { body.calcSource = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionRiskFactor


	/// <summary>
	/// OptionSettlementMark:374
	/// </summary>
	/// <remarks>
	/// --- OptionSettlementMark ---
	/// </remarks>

    public partial class OptionSettlementMark
    {
		public OptionSettlementMark()
		{
		}
		
		public OptionSettlementMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public OptionSettlementMark(OptionSettlementMark source)
        {
            source.CopyTo(this);
        }
		
		internal OptionSettlementMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as OptionSettlementMark);
		}
		
		public bool Equals(OptionSettlementMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(OptionSettlementMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.OptionSettlementMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey okey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				okey = other.okey;
				
			}
			
			
			public OptionKey Okey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return okey ?? (okey = OptionKey.GetCreateOptionKey(body.okey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.okey = value.Layout; okey = value; }
			}
 			
			public YesNo Early
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.early; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.early = value; }
			}
 			
			public YesNo PriorPeriod
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.priorPeriod; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.priorPeriod = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				okey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.okey = okey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.okey = okey;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // OptionSettlementMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout okey;
 			public YesNo early;
 			public YesNo priorPeriod;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey) &&
					 	early.Equals(other.early) &&
					 	priorPeriod.Equals(other.priorPeriod);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = okey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) early);
 					hashCode = (hashCode*397) ^ ((int) priorPeriod);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // OptionSettlementMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public DateKeyLayout settleDate;
			public float settlePx;
			public float settleDe;
			public float lowLmtPx;
			public float highLmtPx;
			public int openInt;
			public int volume;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedDateKey settleDate;
		

            
		
        public DateKey SettleDate { get { return CacheVar.AllocIfNull(ref settleDate).Get(ref body.settleDate, usn); } set { CacheVar.AllocIfNull(ref settleDate).Set(value); body.settleDate = value.Layout; } }
 
		/// <summary>Exchange settlement price</summary>
        public float SettlePx { get { return body.settlePx; } set { body.settlePx = value; } }
 
		/// <summary>Exchange settlement delta</summary>
        public float SettleDe { get { return body.settleDe; } set { body.settleDe = value; } }
 
		/// <summary>Exchange low limit price</summary>
        public float LowLmtPx { get { return body.lowLmtPx; } set { body.lowLmtPx = value; } }
 
		/// <summary>Exchange high limit price</summary>
        public float HighLmtPx { get { return body.highLmtPx; } set { body.highLmtPx = value; } }
 
		/// <summary>Exchange open interest (date prior to settle date)</summary>
        public int OpenInt { get { return body.openInt; } set { body.openInt = value; } }
 
		/// <summary>Exchange volume (date prior to settle date)</summary>
        public int Volume { get { return body.volume; } set { body.volume = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionSettlementMark


	/// <summary>
	/// RootDefinition:100
	/// </summary>
	/// <remarks>
	/// --- RootDefinition ---
	/// </remarks>

    public partial class RootDefinition
    {
		public RootDefinition()
		{
		}
		
		public RootDefinition(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public RootDefinition(RootDefinition source)
        {
            source.CopyTo(this);
        }
		
		internal RootDefinition(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as RootDefinition);
		}
		
		public bool Equals(RootDefinition other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(RootDefinition target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 
			if (UnderlyingList != null)
			{
				target.UnderlyingList = new UnderlyingItem[UnderlyingList.Length];
				for (int i = 0; i < UnderlyingList.Length; i++)
				{
					var src = UnderlyingList[i];
					
					var dest = new UnderlyingItem();
					dest.Ticker = src.Ticker;
 					dest.Spc = src.Spc;

					target.UnderlyingList[i] = dest;
				}
			}
 			target.Invalidate();

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			Invalidate();
 			body = new BodyLayout();
 			UnderlyingList = null;

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.RootDefinition};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private RootKey root;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				root = other.root;
				
			}
			
			
			public RootKey Root
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return root ?? (root = RootKey.GetCreateRootKey(body.root)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.root = value.Layout; root = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				root = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.root = root;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.root = root;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // RootDefinition.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public RootKeyLayout root;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	root.Equals(other.root);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = root.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // RootDefinition.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 		
		#region Repeats 
		

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class UnderlyingItem
        {
            public const int Length = 20;

            public UnderlyingItem() { }
            
            public UnderlyingItem(StockKey ticker, float spc)
            {
                this.Ticker = ticker;
                this.Spc = spc;
            }

            public StockKey Ticker { get; internal set; }
			public float Spc { get; internal set; }
        }

        public UnderlyingItem[] UnderlyingList { get; set; }


		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public StockKeyLayout ticker;
			public FixedString8Layout osiRoot;
			public CCodeKeyLayout ccode;
			public ExpirationMap expirationMap;
			public OptionType optionType;
			public Multihedge multihedge;
			public ExerciseTime exerciseTime;
			public ExerciseType exerciseType;
			public TimeMetric timeMetric;
			public PricingModel pricingModel;
			public VolumeTier volumeTier;
			public int positionLimit;
			public FixedString8Layout exchanges;
			public float strikeRatio;
			public float cashOnExercise;
			public float sharesPerCn;
			public AdjConvention adjConvention;
			public DateTimeLayout lastUpdate;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedStockKey ticker;
 		private CachedFixedLengthString<FixedString8Layout> osiRoot;
 		private CachedCCodeKey ccode;
 		private CachedFixedLengthString<FixedString8Layout> exchanges;
		

            
		/// <summary>master underlying</summary>
        public StockKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>long version of the root.  the short version is used in the RootKey (for example RYAAY1, not RYAA1)</summary>
        public string OsiRoot { get { return CacheVar.AllocIfNull(ref osiRoot).Get(ref body.osiRoot, usn); } set { CacheVar.AllocIfNull(ref osiRoot).Set(value); body.osiRoot = value; } }
             
		
        public CCodeKey Ccode { get { return CacheVar.AllocIfNull(ref ccode).Get(ref body.ccode, usn); } set { CacheVar.AllocIfNull(ref ccode).Set(value); body.ccode = value.Layout; } }
 
		
        public ExpirationMap ExpirationMap { get { return body.expirationMap; } set { body.expirationMap = value; } }
 
		/// <summary>indicator for option type</summary>
        public OptionType OptionType { get { return body.optionType; } set { body.optionType = value; } }
 
		/// <summary>indicates type of multihedge</summary>
        public Multihedge Multihedge { get { return body.multihedge; } set { body.multihedge = value; } }
 
		/// <summary>Exercise time deadline</summary>
        public ExerciseTime ExerciseTime { get { return body.exerciseTime; } set { body.exerciseTime = value; } }
 
		/// <summary>Exercise style</summary>
        public ExerciseType ExerciseType { get { return body.exerciseType; } set { body.exerciseType = value; } }
 
		/// <summary>trading time metric - 232 trading days or 365</summary>
        public TimeMetric TimeMetric { get { return body.timeMetric; } set { body.timeMetric = value; } }
 
		
        public PricingModel PricingModel { get { return body.pricingModel; } set { body.pricingModel = value; } }
 
		
        public VolumeTier VolumeTier { get { return body.volumeTier; } set { body.volumeTier = value; } }
 
		/// <summary>max contract limit</summary>
        public int PositionLimit { get { return body.positionLimit; } set { body.positionLimit = value; } }
 
		/// <summary>exchange codes</summary>
        public string Exchanges { get { return CacheVar.AllocIfNull(ref exchanges).Get(ref body.exchanges, usn); } set { CacheVar.AllocIfNull(ref exchanges).Set(value); body.exchanges = value; } }
 
		/// <summary>note: effective strike = strike * strikeRatio - cashOnExercise</summary>
        public float StrikeRatio { get { return body.strikeRatio; } set { body.strikeRatio = value; } }
 
		/// <summary>note: cashOnExercise is positive if it decreases the effective strike price</summary>
        public float CashOnExercise { get { return body.cashOnExercise; } set { body.cashOnExercise = value; } }
 
		/// <summary>note: always 100 if underlying list is in use</summary>
        public float SharesPerCn { get { return body.sharesPerCn; } set { body.sharesPerCn = value; } }
 
		
        public AdjConvention AdjConvention { get { return body.adjConvention; } set { body.adjConvention = value; } }
 
		
        public DateTime LastUpdate { get { return body.lastUpdate; } set { body.lastUpdate = value; } }

		
		#endregion	

    } // RootDefinition


	/// <summary>
	/// StockBookQuote:121
	/// </summary>
	/// <remarks>
	/// Composite stock book feed computed for all available feeds.  This stream should
	/// be used to determine best ex stock routing and for internal micro market modeling.
	/// Updates on every tick
	/// </remarks>

    public partial class StockBookQuote
    {
		public StockBookQuote()
		{
		}
		
		public StockBookQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockBookQuote(StockBookQuote source)
        {
            source.CopyTo(this);
        }
		
		internal StockBookQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockBookQuote);
		}
		
		public bool Equals(StockBookQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(StockBookQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.StockBookQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private StockKey ticker;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ticker = other.ticker;
				
			}
			
			
			public StockKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = StockKey.GetCreateStockKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ticker = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ticker = ticker;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ticker = ticker;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // StockBookQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public StockKeyLayout ticker;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ticker.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockBookQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrice1;
			public ushort bidSize1;
			public StkExch bidExch1;
			public uint bidMask1;
			public float askPrice1;
			public ushort askSize1;
			public StkExch askExch1;
			public uint askMask1;
			public float bidPrice2;
			public ushort bidSize2;
			public StkExch bidExch2;
			public uint bidMask2;
			public float askPrice2;
			public ushort askSize2;
			public StkExch askExch2;
			public uint askMask2;
			public byte expCnt;
			public float expWidth;
			public int bidPrintQuan;
			public int askPrintQuan;
			public int timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price for best price level</summary>
        public float BidPrice1 { get { return body.bidPrice1; } set { body.bidPrice1 = value; } }
 
		/// <summary>bid size for best price level</summary>
        public ushort BidSize1 { get { return body.bidSize1; } set { body.bidSize1 = value; } }
 
		
        public StkExch BidExch1 { get { return body.bidExch1; } set { body.bidExch1 = value; } }
 
		/// <summary>bid exchange bit mask for best bid price level</summary>
        public uint BidMask1 { get { return body.bidMask1; } set { body.bidMask1 = value; } }
 
		/// <summary>ask price for best price level</summary>
        public float AskPrice1 { get { return body.askPrice1; } set { body.askPrice1 = value; } }
 
		/// <summary>ask size for best price level</summary>
        public ushort AskSize1 { get { return body.askSize1; } set { body.askSize1 = value; } }
 
		/// <summary>exchange</summary>
        public StkExch AskExch1 { get { return body.askExch1; } set { body.askExch1 = value; } }
 
		/// <summary>ask exchange bit mask for best ask price level</summary>
        public uint AskMask1 { get { return body.askMask1; } set { body.askMask1 = value; } }
 
		/// <summary>bid price for next best price level</summary>
        public float BidPrice2 { get { return body.bidPrice2; } set { body.bidPrice2 = value; } }
 
		/// <summary>bid size for next best price level</summary>
        public ushort BidSize2 { get { return body.bidSize2; } set { body.bidSize2 = value; } }
 
		/// <summary>exchange</summary>
        public StkExch BidExch2 { get { return body.bidExch2; } set { body.bidExch2 = value; } }
 
		/// <summary>bid exchange bit mask for next best bid price level</summary>
        public uint BidMask2 { get { return body.bidMask2; } set { body.bidMask2 = value; } }
 
		/// <summary>ask price for next best price level</summary>
        public float AskPrice2 { get { return body.askPrice2; } set { body.askPrice2 = value; } }
 
		/// <summary>ask size for next best price level</summary>
        public ushort AskSize2 { get { return body.askSize2; } set { body.askSize2 = value; } }
 
		/// <summary>exchange</summary>
        public StkExch AskExch2 { get { return body.askExch2; } set { body.askExch2 = value; } }
 
		/// <summary>ask exchange bit mask for next best ask price level</summary>
        public uint AskMask2 { get { return body.askMask2; } set { body.askMask2 = value; } }
 
		/// <summary>initialization counter for expWidth field</summary>
        public byte ExpCnt { get { return body.expCnt; } set { body.expCnt = value; } }
 
		/// <summary>exp [w=1/128] average market width (askPrice1 - bidPrice1)</summary>
        public float ExpWidth { get { return body.expWidth; } set { body.expWidth = value; } }
 
		
        public int BidPrintQuan { get { return body.bidPrintQuan; } set { body.bidPrintQuan = value; } }
 
		
        public int AskPrintQuan { get { return body.askPrintQuan; } set { body.askPrintQuan = value; } }
 
		/// <summary>number of milliseconds since midnight</summary>
        public int Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockBookQuote


	/// <summary>
	/// StockCloseMark:125
	/// </summary>
	/// <remarks>
	/// --- StockCloseMark ---
	/// </remarks>

    public partial class StockCloseMark
    {
		public StockCloseMark()
		{
		}
		
		public StockCloseMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockCloseMark(StockCloseMark source)
        {
            source.CopyTo(this);
        }
		
		internal StockCloseMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockCloseMark);
		}
		
		public bool Equals(StockCloseMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(StockCloseMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.StockCloseMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private StockKey ticker;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ticker = other.ticker;
				
			}
			
			
			public StockKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = StockKey.GetCreateStockKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ticker = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ticker = ticker;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ticker = ticker;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // StockCloseMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public StockKeyLayout ticker;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ticker.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockCloseMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrc;
			public float askPrc;
			public float closePrc;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price (SR mark from previous day)</summary>
        public float BidPrc { get { return body.bidPrc; } set { body.bidPrc = value; } }
 
		/// <summary>ask price (SR mark from previous day)</summary>
        public float AskPrc { get { return body.askPrc; } set { body.askPrc = value; } }
 
		/// <summary>official exchange closing mark</summary>
        public float ClosePrc { get { return body.closePrc; } set { body.closePrc = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockCloseMark


	/// <summary>
	/// StockCloseQuote:123
	/// </summary>
	/// <remarks>
	/// --- StockCloseQuote ---
	/// </remarks>

    public partial class StockCloseQuote
    {
		public StockCloseQuote()
		{
		}
		
		public StockCloseQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockCloseQuote(StockCloseQuote source)
        {
            source.CopyTo(this);
        }
		
		internal StockCloseQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockCloseQuote);
		}
		
		public bool Equals(StockCloseQuote other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(StockCloseQuote target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.StockCloseQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private StockKey ticker;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ticker = other.ticker;
				
			}
			
			
			public StockKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = StockKey.GetCreateStockKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ticker = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ticker = ticker;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ticker = ticker;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // StockCloseQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public StockKeyLayout ticker;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ticker.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockCloseQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrice;
			public float askPrice;
			public int bidSize;
			public int askSize;
			public StkExch bidExch;
			public StkExch askExch;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price</summary>
        public float BidPrice { get { return body.bidPrice; } set { body.bidPrice = value; } }
 
		/// <summary>ask price</summary>
        public float AskPrice { get { return body.askPrice; } set { body.askPrice = value; } }
 
		/// <summary>bid size</summary>
        public int BidSize { get { return body.bidSize; } set { body.bidSize = value; } }
 
		/// <summary>ask size</summary>
        public int AskSize { get { return body.askSize; } set { body.askSize = value; } }
 
		
        public StkExch BidExch { get { return body.bidExch; } set { body.bidExch = value; } }
 
		
        public StkExch AskExch { get { return body.askExch; } set { body.askExch = value; } }
 
		/// <summary>milliseconds since midnight</summary>
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockCloseQuote


	/// <summary>
	/// StockOpenMark:124
	/// </summary>
	/// <remarks>
	/// --- StockOpenMark ---
	/// </remarks>

    public partial class StockOpenMark
    {
		public StockOpenMark()
		{
		}
		
		public StockOpenMark(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockOpenMark(StockOpenMark source)
        {
            source.CopyTo(this);
        }
		
		internal StockOpenMark(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockOpenMark);
		}
		
		public bool Equals(StockOpenMark other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(StockOpenMark target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.StockOpenMark};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private StockKey ticker;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ticker = other.ticker;
				
			}
			
			
			public StockKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = StockKey.GetCreateStockKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ticker = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ticker = ticker;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ticker = ticker;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // StockOpenMark.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public StockKeyLayout ticker;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ticker.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockOpenMark.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float bidPrc;
			public float askPrc;
			public float closePrc;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>bid price (SR mark from previous day)</summary>
        public float BidPrc { get { return body.bidPrc; } set { body.bidPrc = value; } }
 
		/// <summary>ask price (SR mark from previous day)</summary>
        public float AskPrc { get { return body.askPrc; } set { body.askPrc = value; } }
 
		/// <summary>official exchange closing mark</summary>
        public float ClosePrc { get { return body.closePrc; } set { body.closePrc = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockOpenMark


	/// <summary>
	/// StockPrint:122
	/// </summary>
	/// <remarks>
	/// Consolidated stock print which contains last print and tick test across all
	/// data streams.  This stream is used to compute short sale tick tests at the point of order
	/// generation. Updates on every print.
	/// </remarks>

    public partial class StockPrint
    {
		public StockPrint()
		{
		}
		
		public StockPrint(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockPrint(StockPrint source)
        {
            source.CopyTo(this);
        }
		
		internal StockPrint(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockPrint);
		}
		
		public bool Equals(StockPrint other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;
			return pkey.Equals(other.pkey);
		}
		
		public override int GetHashCode()
		{
			return pkey.GetHashCode();
		}
		
		public override string ToString()
		{
			return TabRecord;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(StockPrint target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;

        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
			pkey.Clear();
 			body = new BodyLayout();

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.StockPrint};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private StockKey ticker;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ticker = other.ticker;
				
			}
			
			
			public StockKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = StockKey.GetCreateStockKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ticker = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ticker = ticker;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ticker = ticker;

				return target;
			}
			
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
				return Equals(obj as PKey);
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKey other)
			{
				if (ReferenceEquals(null, other)) return false;
				return body.Equals(other.body);
			}
			
			public override int GetHashCode()
			{
                // ReSharper disable NonReadonlyFieldInGetHashCode
				return body.GetHashCode();
                // ReSharper restore NonReadonlyFieldInGetHashCode
			}
        } // StockPrint.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public StockKeyLayout ticker;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
            {
                return Equals((PKeyLayout) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
					// ReSharper disable NonReadonlyFieldInGetHashCode
					var hashCode = ticker.GetHashCode();

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockPrint.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public MarketStatus marketStatus;
			public StkExch prtExch;
			public int prtSize;
			public int prtQuan;
			public float prtPrice;
			public int prtVolume;
			public StockTick lastTick;
			public float iniPrice;
			public float mrkPrice;
			public float opnPrice;
			public float clsPrice;
			public float minPrice;
			public float maxPrice;
			public int bCnt;
			public int sCnt;
			public int shBot;
			public int shSld;
			public float shMny;
			public ushort expCnt;
			public float expV1;
			public float expV2;
			public float expV3;
			public float expV4;
			public float expV5;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		
        public MarketStatus MarketStatus { get { return body.marketStatus; } set { body.marketStatus = value; } }
 
		/// <summary>print exch</summary>
        public StkExch PrtExch { get { return body.prtExch; } set { body.prtExch = value; } }
 
		/// <summary>print size</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>cumulative print size at this price level</summary>
        public int PrtQuan { get { return body.prtQuan; } set { body.prtQuan = value; } }
 
		/// <summary>print price level</summary>
        public float PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>cumulative print size today</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		
        public StockTick LastTick { get { return body.lastTick; } set { body.lastTick = value; } }
 
		/// <summary>first print price of the day [8:30 - 3:00]</summary>
        public float IniPrice { get { return body.iniPrice; } set { body.iniPrice = value; } }
 
		/// <summary>last print within market hours [8:30 - 3:00]; used for after hours marks</summary>
        public float MrkPrice { get { return body.mrkPrice; } set { body.mrkPrice = value; } }
 
		/// <summary>open price (prior day close)</summary>
        public float OpnPrice { get { return body.opnPrice; } set { body.opnPrice = value; } }
 
		/// <summary>official NMS closing price</summary>
        public float ClsPrice { get { return body.clsPrice; } set { body.clsPrice = value; } }
 
		/// <summary>minimum print price within market hours</summary>
        public float MinPrice { get { return body.minPrice; } set { body.minPrice = value; } }
 
		/// <summary>maximum print price within market hours</summary>
        public float MaxPrice { get { return body.maxPrice; } set { body.maxPrice = value; } }
 
		/// <summary>buy count (print w/last tick dn) [market maker perspective]</summary>
        public int BCnt { get { return body.bCnt; } set { body.bCnt = value; } }
 
		/// <summary>sell count (print w/last tick up)</summary>
        public int SCnt { get { return body.sCnt; } set { body.sCnt = value; } }
 
		/// <summary>cumulative shares w/last tick dn [8:30 - 3:00] [max 100k $delta per print]</summary>
        public int ShBot { get { return body.shBot; } set { body.shBot = value; } }
 
		/// <summary>cumulative shares w/last tick up</summary>
        public int ShSld { get { return body.shSld; } set { body.shSld = value; } }
 
		/// <summary>net bot/sld money</summary>
        public float ShMny { get { return body.shMny; } set { body.shMny = value; } }
 
		/// <summary>exp average counter [8:30 - 3:00]</summary>
        public ushort ExpCnt { get { return body.expCnt; } set { body.expCnt = value; } }
 
		/// <summary>exp average [move*move] (w=1/1)       note: does not include overnight move</summary>
        public float ExpV1 { get { return body.expV1; } set { body.expV1 = value; } }
 
		/// <summary>exp average [move*move] (w=1/4)</summary>
        public float ExpV2 { get { return body.expV2; } set { body.expV2 = value; } }
 
		/// <summary>exp average [move*move] (w=1/16)</summary>
        public float ExpV3 { get { return body.expV3; } set { body.expV3 = value; } }
 
		/// <summary>exp average [move*move] (w=1/64)</summary>
        public float ExpV4 { get { return body.expV4; } set { body.expV4 = value; } }
 
		/// <summary>exp average [move*move] (w=1/256)</summary>
        public float ExpV5 { get { return body.expV5; } set { body.expV5 = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockPrint


	#endregion

	#region Admin

	/// <summary>
	/// CacheComplete:504
	/// </summary>
	/// <remarks>
	/// CacheComplete - Generated by the cache server to indicate that the cache
	/// request has been completely filled and no more cache messages will be
	/// generated for this particular requestID.
	/// </remarks>

    internal partial class CacheComplete
    {
		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.CacheComplete};
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public int requestID;
			public FixedString256Layout result;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		


		/// <summary>unique client generated id returned in CacheComplete message</summary>
        public int RequestID { get { return body.requestID; } set { body.requestID = value; } }
 
		/// <summary>a human-readable response</summary>
        public string Result { get { return body.result; } set { body.result = value; } }

		
		#endregion	

    } // CacheComplete


	/// <summary>
	/// GetCache:503
	/// </summary>
	/// <remarks>
	/// admin (stateless) messages
	/// GetCache - Used by clients to request cache updates from an upstream cache
	/// server. The usual semantic is: open tcp connection, send GetCache message,
	/// parse all resulting messages, server sends CacheComplete message, client
	/// terminates connection on receipt of CacheComplete message.
	/// </remarks>

    internal partial class GetCache
    {
		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.GetCache};
 		
		#region Repeats 
		

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class MsgTypeItem
        {
            public const int Length = 2;

            public MsgTypeItem() { }
            
            public MsgTypeItem(ushort msgtype)
            {
                this.Msgtype = msgtype;
            }

            public ushort Msgtype { get; internal set; }
        }

        public MsgTypeItem[] MsgTypeList { get; set; }


		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public int requestID;
			public FixedString32Layout filter;
			public int limit;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		


		/// <summary>unique client generated id returned in CacheComplete message</summary>
        public int RequestID { get { return body.requestID; } set { body.requestID = value; } }
 
		
        public string Filter { get { return body.filter; } set { body.filter = value; } }
 
		
        public int Limit { get { return body.limit; } set { body.limit = value; } }

		
		#endregion	

    } // GetCache


	#endregion
}
