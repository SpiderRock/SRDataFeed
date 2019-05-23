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
	/// FutureBookQuote:360
	/// </summary>
	/// <remarks>
	/// This table contains live future quote records from the listing exchange.  Each record contains up to four price levels and represents a live snapshot of the book for a specific future.
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
			private ExpiryKey fkey;

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
			
			
			public ExpiryKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = ExpiryKey.GetCreateExpiryKey(body.fkey)); }
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
			public ExpiryKeyLayout fkey;

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
			public UpdateType updateType;
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
			public long srcTimestamp;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		
        public UpdateType UpdateType { get { return body.updateType; } set { body.updateType = value; } }
 
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
 
		/// <summary>source high precision timestamp (if available)</summary>
        public long SrcTimestamp { get { return body.srcTimestamp; } set { body.srcTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // FutureBookQuote


	/// <summary>
	/// FuturePrint:370
	/// </summary>
	/// <remarks>
	/// The most recent (last) print record for each active futures market.
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
			private ExpiryKey fkey;

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
			
			
			public ExpiryKey Fkey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return fkey ?? (fkey = ExpiryKey.GetCreateExpiryKey(body.fkey)); }
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
			public ExpiryKeyLayout fkey;

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
			public FutExch prtExch;
			public int prtSize;
			public double prtPrice;
			public int prtClusterNum;
			public int prtClusterSize;
			public byte prtType;
			public ushort prtOrders;
			public int prtQuan;
			public int prtVolume;
			public float bid;
			public float ask;
			public ushort bsz;
			public ushort asz;
			public float age;
			public PrtSide prtSide;
			public long prtTimestamp;
			public long netTimestamp;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>print exchange</summary>
        public FutExch PrtExch { get { return body.prtExch; } set { body.prtExch = value; } }
 
		/// <summary>print size [contracts]</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>print price</summary>
        public double PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>incremental print cluster counter (one counter per fkey; used to group prints into clusters)</summary>
        public int PrtClusterNum { get { return body.prtClusterNum; } set { body.prtClusterNum = value; } }
 
		/// <summary>cumulative size of prints in this sequence (sequence of prints @ same or better price with less than 25 ms elapsing since first print)</summary>
        public int PrtClusterSize { get { return body.prtClusterSize; } set { body.prtClusterSize = value; } }
 
		/// <summary>print type [exchange specific]</summary>
        public byte PrtType { get { return body.prtType; } set { body.prtType = value; } }
 
		/// <summary>number of orders participating in this print</summary>
        public ushort PrtOrders { get { return body.prtOrders; } set { body.prtOrders = value; } }
 
		/// <summary>cumulative (electronic) print size at current price level</summary>
        public int PrtQuan { get { return body.prtQuan; } set { body.prtQuan = value; } }
 
		/// <summary>cumulative day (electronic) print volume in contracts</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		/// <summary>exchange bid (@ print time)</summary>
        public float Bid { get { return body.bid; } set { body.bid = value; } }
 
		/// <summary>exchange ask (@ print time)</summary>
        public float Ask { get { return body.ask; } set { body.ask = value; } }
 
		/// <summary>cumulative bid size (@ print time)</summary>
        public ushort Bsz { get { return body.bsz; } set { body.bsz = value; } }
 
		/// <summary>cumulative ask size (@ print time)</summary>
        public ushort Asz { get { return body.asz; } set { body.asz = value; } }
 
		/// <summary>age of prevailing quote at time of print</summary>
        public float Age { get { return body.age; } set { body.age = value; } }
 
		/// <summary>implied print side (from bid/ask)</summary>
        public PrtSide PrtSide { get { return body.prtSide; } set { body.prtSide = value; } }
 
		/// <summary>exchange high precision timestamp (if available)</summary>
        public long PrtTimestamp { get { return body.prtTimestamp; } set { body.prtTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // FuturePrint


	/// <summary>
	/// IndexQuote:137
	/// </summary>
	/// <remarks>
	/// Live index levels and quotes including SpiderRock synthetic index levels and quotes.
	/// </remarks>

    public partial class IndexQuote
    {
		public IndexQuote()
		{
		}
		
		public IndexQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public IndexQuote(IndexQuote source)
        {
            source.CopyTo(this);
        }
		
		internal IndexQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as IndexQuote);
		}
		
		public bool Equals(IndexQuote other)
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
		public void CopyTo(IndexQuote target)
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
        internal Header header = new Header {msgtype = MessageType.IndexQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
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
        } // IndexQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout ticker;

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
        } // IndexQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public IdxSrc priceSource;
			public double idxBid;
			public double idxAsk;
			public double idxPrice;
			public long netTimestamp;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>price source of the quote (indication print or quote message)</summary>
        public IdxSrc PriceSource { get { return body.priceSource; } set { body.priceSource = value; } }
 
		/// <summary>index bid value (if from quote, otherwise idxPrice)</summary>
        public double IdxBid { get { return body.idxBid; } set { body.idxBid = value; } }
 
		/// <summary>index ask value (if from quote, otherwise idxPrice)</summary>
        public double IdxAsk { get { return body.idxAsk; } set { body.idxAsk = value; } }
 
		/// <summary>index price</summary>
        public double IdxPrice { get { return body.idxPrice; } set { body.idxPrice = value; } }
 
		/// <summary>index price timestamp</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // IndexQuote


	/// <summary>
	/// LiveSurfaceAtm:2160
	/// </summary>
	/// <remarks>
	/// LiveSurfaceAtm (surfaceType = 'Live') records are computed and publish continuously during trading hours and represent a current best implied volatility market fit.
	/// SurfaceType = 'PriorDay' records contain the `closing surface record from the prior trading period (usually from just before the last main session close).
	/// SurfaceType = 'Live' records are published to the SpiderRock elastic cluster at 5 minute intervals.
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
			private ExpiryKey ekey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ekey = other.ekey;
				
			}
			
			
			public ExpiryKey Ekey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ekey ?? (ekey = ExpiryKey.GetCreateExpiryKey(body.ekey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ekey = value.Layout; ekey = value; }
			}
 			
			public LiveSurfaceType SurfaceType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.surfaceType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.surfaceType = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ekey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ekey = ekey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ekey = ekey;

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
			public ExpiryKeyLayout ekey;
 			public LiveSurfaceType surfaceType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ekey.Equals(other.ekey) &&
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
					var hashCode = ekey.GetHashCode();
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
			public FixedString10Layout date;
			public FixedString8Layout time;
			public TickerKeyLayout ticker;
			public ExpiryKeyLayout fkey;
			public float uBid;
			public float uAsk;
			public float years;
			public float rate;
			public float ddiv;
			public byte exType;
			public byte modelType;
			public float earnCnt;
			public float earnCntAdj;
			public float axisVolRT;
			public float axisFUPrc;
			public MoneynessType moneynessType;
			public UnderlierMode underlierMode;
			public float atmVol;
			public float atmCen;
			public float atmVolHist;
			public float atmCenHist;
			public float minAtmVol;
			public float maxAtmVol;
			public float minCPAdjVal;
			public float maxCPAdjVal;
			public float eMove;
			public float eMoveHist;
			public float uPrcOffset;
			public float uPrcOffsetEMA;
			public float sdiv;
			public float sdivEMA;
			public float atmMove;
			public float atmCenMove;
			public float atmVega;
			public float slope;
			public float varSwapFV;
			public GridType gridType;
			public float minXAxis;
			public float maxXAxis;
			public float xAxisScale;
			public float xAxisOffset;
			public float skewD11;
			public float skewD10;
			public float skewD9;
			public float skewD8;
			public float skewD7;
			public float skewD6;
			public float skewD5;
			public float skewD4;
			public float skewD3;
			public float skewD2;
			public float skewD1;
			public float skewC0;
			public float skewU1;
			public float skewU2;
			public float skewU3;
			public float skewU4;
			public float skewU5;
			public float skewU6;
			public float skewU7;
			public float skewU8;
			public float skewU9;
			public float skewU10;
			public float skewU11;
			public float sdivD3;
			public float sdivD2;
			public float sdivD1;
			public float sdivU1;
			public float sdivU2;
			public float sdivU3;
			public float pwidth;
			public float vwidth;
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
			public CallPut fitErrCP;
			public float fitErrBid;
			public float fitErrAsk;
			public float fitErrPrc;
			public float fitErrVol;
			public ExpiryKeyLayout sEKey;
			public LiveSurfaceType sType;
			public DateTimeLayout sTimestamp;
			public int counter;
			public int skewCounter;
			public int sdivCounter;
			public SurfaceResult surfaceResult;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedFixedLengthString<FixedString10Layout> date;
 		private CachedFixedLengthString<FixedString8Layout> time;
 		private CachedTickerKey ticker;
 		private CachedExpiryKey fkey;
 		private CachedExpiryKey sEKey;
		


		/// <summary>archive date</summary>
        public string Date { get { return CacheVar.AllocIfNull(ref date).Get(ref body.date, usn); } set { CacheVar.AllocIfNull(ref date).Set(value); body.date = value; } }
 
		/// <summary>archive time</summary>
        public string Time { get { return CacheVar.AllocIfNull(ref time).Get(ref body.time, usn); } set { CacheVar.AllocIfNull(ref time).Set(value); body.time = value; } }
             
		/// <summary>underlying stock key that this option expiration attaches to</summary>
        public TickerKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
             
		/// <summary>future that this option expiration month written on (if any)</summary>
        public ExpiryKey Fkey { get { return CacheVar.AllocIfNull(ref fkey).Get(ref body.fkey, usn); } set { CacheVar.AllocIfNull(ref fkey).Set(value); body.fkey = value.Layout; } }
 
		/// <summary>underlier bid price</summary>
        public float UBid { get { return body.uBid; } set { body.uBid = value; } }
 
		/// <summary>underlier ask price</summary>
        public float UAsk { get { return body.uAsk; } set { body.uAsk = value; } }
 
		/// <summary>time to expiration (in years)</summary>
        public float Years { get { return body.years; } set { body.years = value; } }
 
		/// <summary>interest rate</summary>
        public float Rate { get { return body.rate; } set { body.rate = value; } }
 
		/// <summary>present value of discrete dividend stream</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>exercise type of the options used to compute this surface</summary>
        public byte ExType { get { return body.exType; } set { body.exType = value; } }
 
		/// <summary>option pricing model used for price calcs</summary>
        public byte ModelType { get { return body.modelType; } set { body.modelType = value; } }
 
		/// <summary>number of qualifying earnings events prior to expiration [can be fractional] (from StockEarningsCalendar)</summary>
        public float EarnCnt { get { return body.earnCnt; } set { body.earnCnt = value; } }
 
		/// <summary>number of qualifying earnings events prior to expiration [adjusted] (from StockEarningsCalendar + LiveSurfaceTerm)</summary>
        public float EarnCntAdj { get { return body.earnCntAdj; } set { body.earnCntAdj = value; } }
 
		/// <summary>axis volatility x sqrt(years) (used to compute xAxis) [usually 4m atm vol]</summary>
        public float AxisVolRT { get { return body.axisVolRT; } set { body.axisVolRT = value; } }
 
		/// <summary>axis FwdUPrc (fwd underlying price used to compute xAxis)</summary>
        public float AxisFUPrc { get { return body.axisFUPrc; } set { body.axisFUPrc = value; } }
 
		/// <summary>moneyness (xAxis) convention</summary>
        public MoneynessType MoneynessType { get { return body.moneynessType; } set { body.moneynessType = value; } }
 
		/// <summary>underlier pricing mode (None=use spot/stock market; FrontMonth=use front month future market + uPrcOffset; Actual = use actual underlier future market)</summary>
        public UnderlierMode UnderlierMode { get { return body.underlierMode; } set { body.underlierMode = value; } }
 
		/// <summary>atm vol (xAxis = 0)</summary>
        public float AtmVol { get { return body.atmVol; } set { body.atmVol = value; } }
 
		/// <summary>atm vol (xAxis = 0) (eMove/earnCntAdj censored)</summary>
        public float AtmCen { get { return body.atmCen; } set { body.atmCen = value; } }
 
		/// <summary>historical realized volatility (includes eMoveHist x earnCntAdj adjustment).  Note that this is the default atmVol if no implied markets existed previous day.</summary>
        public float AtmVolHist { get { return body.atmVolHist; } set { body.atmVolHist = value; } }
 
		/// <summary>censored (earnings events removed) historical realized volatility.  Trailing periods is 2x forward time to expiration.  From HistoricalVolatility(windowType=hlCen).mv_nnn</summary>
        public float AtmCenHist { get { return body.atmCenHist; } set { body.atmCenHist = value; } }
 
		/// <summary>minimum estimated atm vol</summary>
        public float MinAtmVol { get { return body.minAtmVol; } set { body.minAtmVol = value; } }
 
		/// <summary>maximum estimated atm vol</summary>
        public float MaxAtmVol { get { return body.maxAtmVol; } set { body.maxAtmVol = value; } }
 
		/// <summary>minimum CP adjust value (sdiv or uPrcOffset)</summary>
        public float MinCPAdjVal { get { return body.minCPAdjVal; } set { body.minCPAdjVal = value; } }
 
		/// <summary>maximum CP adjust value (sdiv or uPrcOffset)</summary>
        public float MaxCPAdjVal { get { return body.maxCPAdjVal; } set { body.maxCPAdjVal = value; } }
 
		/// <summary>implied earnings move (from LiveSurfaceTerm)</summary>
        public float EMove { get { return body.eMove; } set { body.eMove = value; } }
 
		/// <summary>historical earnings move (avg of trailing 8 moves). From StockEarningsCalendar.eMoveHist</summary>
        public float EMoveHist { get { return body.eMoveHist; } set { body.eMoveHist = value; } }
 
		/// <summary>implied offset for use when underlierMode = FrontMonth</summary>
        public float UPrcOffset { get { return body.uPrcOffset; } set { body.uPrcOffset = value; } }
 
		/// <summary>time smoothed implied uPrcOffset (half-live ~ 20 seconds)</summary>
        public float UPrcOffsetEMA { get { return body.uPrcOffsetEMA; } set { body.uPrcOffsetEMA = value; } }
 
		/// <summary>stock dividend (borrow rate)</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>sdiv exp moving average (10 minutes)</summary>
        public float SdivEMA { get { return body.sdivEMA; } set { body.sdivEMA = value; } }
 
		/// <summary>fixed strike atm move from prior period</summary>
        public float AtmMove { get { return body.atmMove; } set { body.atmMove = value; } }
 
		/// <summary>fixed strike atm (censored) move from prior period</summary>
        public float AtmCenMove { get { return body.atmCenMove; } set { body.atmCenMove = value; } }
 
		/// <summary>surface vega @ ATM (xAxis=0)</summary>
        public float AtmVega { get { return body.atmVega; } set { body.atmVega = value; } }
 
		/// <summary>volatility surface slope (dVol / dXAxis) @ ATM (xAxis=0)</summary>
        public float Slope { get { return body.slope; } set { body.slope = value; } }
 
		/// <summary>variance swap fair value (estimated by numerical integration over OTM price surface)</summary>
        public float VarSwapFV { get { return body.varSwapFV; } set { body.varSwapFV = value; } }
 
		/// <summary>gridType defines D11 - U12 xAxis points + spline type</summary>
        public GridType GridType { get { return body.gridType; } set { body.gridType = value; } }
 
		/// <summary>minimum xAxis value;xAxis values to the left extrapolate horizontally</summary>
        public float MinXAxis { get { return body.minXAxis; } set { body.minXAxis = value; } }
 
		/// <summary>maximum xAxis value;xAxis values to the right extrapolate horizontally</summary>
        public float MaxXAxis { get { return body.maxXAxis; } set { body.maxXAxis = value; } }
 
		/// <summary>xAxis = (effStrike / effAxisFUPrc - 1.0) / axisVolRT; effStrike = strike * strikeRatio; effAxisFUPrc = axisFUPrc * symbolRatio</summary>
        public float XAxisScale { get { return body.xAxisScale; } set { body.xAxisScale = value; } }
 
		
        public float XAxisOffset { get { return body.xAxisOffset; } set { body.xAxisOffset = value; } }
 
		/// <summary>skew @ D11 point (volatility skew curve)</summary>
        public float SkewD11 { get { return body.skewD11; } set { body.skewD11 = value; } }
 
		/// <summary>skew @ D10 point</summary>
        public float SkewD10 { get { return body.skewD10; } set { body.skewD10 = value; } }
 
		/// <summary>skew @ D9 point</summary>
        public float SkewD9 { get { return body.skewD9; } set { body.skewD9 = value; } }
 
		/// <summary>skew @ D8 point</summary>
        public float SkewD8 { get { return body.skewD8; } set { body.skewD8 = value; } }
 
		/// <summary>skew @ D7 point</summary>
        public float SkewD7 { get { return body.skewD7; } set { body.skewD7 = value; } }
 
		/// <summary>skew @ D6 point</summary>
        public float SkewD6 { get { return body.skewD6; } set { body.skewD6 = value; } }
 
		/// <summary>skew @ D5 point</summary>
        public float SkewD5 { get { return body.skewD5; } set { body.skewD5 = value; } }
 
		/// <summary>skew @ D4 point</summary>
        public float SkewD4 { get { return body.skewD4; } set { body.skewD4 = value; } }
 
		/// <summary>skew @ D3 point</summary>
        public float SkewD3 { get { return body.skewD3; } set { body.skewD3 = value; } }
 
		/// <summary>skew @ D2 point</summary>
        public float SkewD2 { get { return body.skewD2; } set { body.skewD2 = value; } }
 
		/// <summary>skew @ D1 point</summary>
        public float SkewD1 { get { return body.skewD1; } set { body.skewD1 = value; } }
 
		/// <summary>central value (@xAxis = xAxisOffset) [usually min vol pt]</summary>
        public float SkewC0 { get { return body.skewC0; } set { body.skewC0 = value; } }
 
		/// <summary>skew @ U1 point</summary>
        public float SkewU1 { get { return body.skewU1; } set { body.skewU1 = value; } }
 
		/// <summary>skew @ U2 point</summary>
        public float SkewU2 { get { return body.skewU2; } set { body.skewU2 = value; } }
 
		/// <summary>skew @ U3 point</summary>
        public float SkewU3 { get { return body.skewU3; } set { body.skewU3 = value; } }
 
		/// <summary>skew @ U4 point</summary>
        public float SkewU4 { get { return body.skewU4; } set { body.skewU4 = value; } }
 
		/// <summary>skew @ U5 point</summary>
        public float SkewU5 { get { return body.skewU5; } set { body.skewU5 = value; } }
 
		/// <summary>skew @ U6 point</summary>
        public float SkewU6 { get { return body.skewU6; } set { body.skewU6 = value; } }
 
		/// <summary>skew @ U7 point</summary>
        public float SkewU7 { get { return body.skewU7; } set { body.skewU7 = value; } }
 
		/// <summary>skew @ U8 point</summary>
        public float SkewU8 { get { return body.skewU8; } set { body.skewU8 = value; } }
 
		/// <summary>skew @ U9 point</summary>
        public float SkewU9 { get { return body.skewU9; } set { body.skewU9 = value; } }
 
		/// <summary>skew @ U10 point</summary>
        public float SkewU10 { get { return body.skewU10; } set { body.skewU10 = value; } }
 
		/// <summary>skew @ U11 point</summary>
        public float SkewU11 { get { return body.skewU11; } set { body.skewU11 = value; } }
 
		/// <summary>sdiv @ D3 point</summary>
        public float SdivD3 { get { return body.sdivD3; } set { body.sdivD3 = value; } }
 
		/// <summary>sdiv @ D2 point</summary>
        public float SdivD2 { get { return body.sdivD2; } set { body.sdivD2 = value; } }
 
		/// <summary>sdiv @ D1 point</summary>
        public float SdivD1 { get { return body.sdivD1; } set { body.sdivD1 = value; } }
 
		/// <summary>sdiv @ U1 point</summary>
        public float SdivU1 { get { return body.sdivU1; } set { body.sdivU1 = value; } }
 
		/// <summary>sdiv @ U2 point</summary>
        public float SdivU2 { get { return body.sdivU2; } set { body.sdivU2 = value; } }
 
		/// <summary>sdiv @ U3 point</summary>
        public float SdivU3 { get { return body.sdivU3; } set { body.sdivU3 = value; } }
 
		/// <summary>minimum mkt premium width</summary>
        public float Pwidth { get { return body.pwidth; } set { body.pwidth = value; } }
 
		/// <summary>minimum mkt volatility width</summary>
        public float Vwidth { get { return body.vwidth; } set { body.vwidth = value; } }
 
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
        public CallPut FitErrCP { get { return body.fitErrCP; } set { body.fitErrCP = value; } }
 
		/// <summary>bid of the option with the largest fit error</summary>
        public float FitErrBid { get { return body.fitErrBid; } set { body.fitErrBid = value; } }
 
		/// <summary>ask of the option with the largest fit error</summary>
        public float FitErrAsk { get { return body.fitErrAsk; } set { body.fitErrAsk = value; } }
 
		/// <summary>surface prc of the option with the largest fit error</summary>
        public float FitErrPrc { get { return body.fitErrPrc; } set { body.fitErrPrc = value; } }
 
		/// <summary>surface vol of the option with the largest fit error</summary>
        public float FitErrVol { get { return body.fitErrVol; } set { body.fitErrVol = value; } }
             
		/// <summary>overnight LiveSurfaceAtm used for surface</summary>
        public ExpiryKey SEKey { get { return CacheVar.AllocIfNull(ref sEKey).Get(ref body.sEKey, usn); } set { CacheVar.AllocIfNull(ref sEKey).Set(value); body.sEKey = value.Layout; } }
 
		
        public LiveSurfaceType SType { get { return body.sType; } set { body.sType = value; } }
 
		/// <summary>[date/time from LiveSurfaceAtm surface record]</summary>
        public DateTime STimestamp { get { return body.sTimestamp; } set { body.sTimestamp = value; } }
 
		/// <summary>message counter - number of surface fits today</summary>
        public int Counter { get { return body.counter; } set { body.counter = value; } }
 
		/// <summary>skew surface fit counter</summary>
        public int SkewCounter { get { return body.skewCounter; } set { body.skewCounter = value; } }
 
		/// <summary>sdiv surface fit counter</summary>
        public int SdivCounter { get { return body.sdivCounter; } set { body.sdivCounter = value; } }
 
		
        public SurfaceResult SurfaceResult { get { return body.surfaceResult; } set { body.surfaceResult = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // LiveSurfaceAtm


	/// <summary>
	/// OptionImpliedQuote:2300
	/// </summary>
	/// <remarks>
	/// Records in this table are identical to the records in our live implied quote multicast feed.  CalcSource=Tick records are computed and published each time an option NBBO price changes.  CalcSource=Loop records are computed in a 2-3 minute background loop.  CalcSource=Close records are computed and published on the market close.
	/// Note that the underlier price (uPrc) will be the same for all options an underlier when CalcSource=Loop|Close.  This is not true for CalcSource=Tick where uPrc will be the underlier price that prevailed when the option price changed.
	/// If you are consuming multicast data and only want records with consistent uPrc values for all options you should ignore Tick records. Alternatively, you can use an independent underlier price source (our StockBookQuote feed or some other) and 'adjust' the values in this table to the new underlier value.
	/// If you are selecting records from SRSE you should note that OptionImpliedQuoteAdj table is a proxy implementation of this table that automatically applies the appropriate underlier adjustments as records are being returned.
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
 			/// <summary>Tick=nbbo tick; Loop=from background loop;</summary>
			public CalcType CalcType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.calcType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.calcType = value; }
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
 			public CalcType calcType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	okey.Equals(other.okey) &&
					 	calcType.Equals(other.calcType);
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
 					hashCode = (hashCode*397) ^ ((int) calcType);

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
			public TickerKeyLayout ticker;
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
			public float veSlope;
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
			public FixedString24Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
 		private CachedFixedLengthString<FixedString24Layout> calcErr;
		

            
		
        public TickerKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>underlier price (usually mid-market)</summary>
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
 
		/// <summary>veSlope = dVol / dUprc (assuming vol @ xAxis = 0 remains constant);hedgeDelta = (de + ve * 100 * veSlope) if hedging with this assumption</summary>
        public float VeSlope { get { return body.veSlope; } set { body.veSlope = value; } }
 
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
 
		/// <summary>underlier up 50% slide</summary>
        public float Up50 { get { return body.up50; } set { body.up50 = value; } }
 
		/// <summary>underlier dn 50% slide</summary>
        public float Dn50 { get { return body.dn50; } set { body.dn50 = value; } }
 
		/// <summary>underlier up 15% slide</summary>
        public float Up15 { get { return body.up15; } set { body.up15 = value; } }
 
		/// <summary>underlier dn 15% slide</summary>
        public float Dn15 { get { return body.dn15; } set { body.dn15 = value; } }
 
		/// <summary>underlier up 6% slide</summary>
        public float Up06 { get { return body.up06; } set { body.up06 = value; } }
 
		/// <summary>underlier dn 8% slide</summary>
        public float Dn08 { get { return body.dn08; } set { body.dn08 = value; } }
 
		/// <summary>option pricing error, otherwise, an empty string.  pertains to the Greeks (de, ga, th, ve, ro, ph) and sprc</summary>
        public string CalcErr { get { return CacheVar.AllocIfNull(ref calcErr).Get(ref body.calcErr, usn); } set { CacheVar.AllocIfNull(ref calcErr).Set(value); body.calcErr = value; } }
 
		/// <summary>Tick=nbbo tick; Loop=from background loop; Close=Final EOD record;</summary>
        public CalcSource CalcSource { get { return body.calcSource; } set { body.calcSource = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionImpliedQuote


	/// <summary>
	/// OptionNbboQuote:260
	/// </summary>
	/// <remarks>
	/// This table contains live option quote records from OPRA (equities) or the listing exchange (futures).  Each record contains up to two price levels and represents a live snapshot of the book for a specific option series.  There are typically 1mm+ records in this table if all ticker sources are enabled.
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
			public UpdateType updateType;
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
			public OpraMktType bidMktType;
			public OpraMktType askMktType;
			public float bidPrice2;
			public float askPrice2;
			public ushort cumBidSize2;
			public ushort cumAskSize2;
			public int bidTime;
			public int askTime;
			public long srcTimestamp;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		
        public UpdateType UpdateType { get { return body.updateType; } set { body.updateType = value; } }
 
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
 
		/// <summary>bid side quote flags (if any)</summary>
        public OpraMktType BidMktType { get { return body.bidMktType; } set { body.bidMktType = value; } }
 
		/// <summary>ask side quote flags (if any)</summary>
        public OpraMktType AskMktType { get { return body.askMktType; } set { body.askMktType = value; } }
 
		/// <summary>2nd best bid price</summary>
        public float BidPrice2 { get { return body.bidPrice2; } set { body.bidPrice2 = value; } }
 
		/// <summary>2nd best ask price</summary>
        public float AskPrice2 { get { return body.askPrice2; } set { body.askPrice2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort CumBidSize2 { get { return body.cumBidSize2; } set { body.cumBidSize2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort CumAskSize2 { get { return body.cumAskSize2; } set { body.cumAskSize2 = value; } }
 
		/// <summary>last bid price change (milliseconds since midnight) calculated from the srcTimestamp</summary>
        public int BidTime { get { return body.bidTime; } set { body.bidTime = value; } }
 
		/// <summary>last ask price change (milliseconds since midnight) calculated from the srcTimestamp</summary>
        public int AskTime { get { return body.askTime; } set { body.askTime = value; } }
 
		/// <summary>source high precision timestamp (if available)</summary>
        public long SrcTimestamp { get { return body.srcTimestamp; } set { body.srcTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // OptionNbboQuote


	/// <summary>
	/// OptionPrint:300
	/// </summary>
	/// <remarks>
	/// The most recent (last) print record for each active equity and future option series.  Quote markup represents quote that existed just prior to the print on the reporting exchange.
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
        } // OptionPrint.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public OptExch prtExch;
			public int prtSize;
			public float prtPrice;
			public int prtClusterNum;
			public int prtClusterSize;
			public byte prtType;
			public ushort prtOrders;
			public int prtVolume;
			public int cxlVolume;
			public ushort bidCount;
			public ushort askCount;
			public int bidVolume;
			public int askVolume;
			public float ebid;
			public float eask;
			public ushort ebsz;
			public ushort easz;
			public float eage;
			public PrtSide prtSide;
			public long prtTimestamp;
			public long netTimestamp;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		
        public OptExch PrtExch { get { return body.prtExch; } set { body.prtExch = value; } }
 
		/// <summary>print size [contracts]</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>print price</summary>
        public float PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>incremental print cluster counter (one counter per okey; used to group prints into clusters)</summary>
        public int PrtClusterNum { get { return body.prtClusterNum; } set { body.prtClusterNum = value; } }
 
		/// <summary>cumulative size of prints in this sequence (sequence of prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
        public int PrtClusterSize { get { return body.prtClusterSize; } set { body.prtClusterSize = value; } }
 
		/// <summary>print type</summary>
        public byte PrtType { get { return body.prtType; } set { body.prtType = value; } }
 
		/// <summary>number of participating orders</summary>
        public ushort PrtOrders { get { return body.prtOrders; } set { body.prtOrders = value; } }
 
		/// <summary>day print volume in contracts [this exchange]</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		/// <summary>day print/cancel volume (num of contracts printed and then cancelled)</summary>
        public int CxlVolume { get { return body.cxlVolume; } set { body.cxlVolume = value; } }
 
		/// <summary>number of bid prints</summary>
        public ushort BidCount { get { return body.bidCount; } set { body.bidCount = value; } }
 
		/// <summary>number of ask prints</summary>
        public ushort AskCount { get { return body.askCount; } set { body.askCount = value; } }
 
		/// <summary>bid print volume in contracts</summary>
        public int BidVolume { get { return body.bidVolume; } set { body.bidVolume = value; } }
 
		/// <summary>ask print volume in contracts</summary>
        public int AskVolume { get { return body.askVolume; } set { body.askVolume = value; } }
 
		/// <summary>exchange bid (@ print time)</summary>
        public float Ebid { get { return body.ebid; } set { body.ebid = value; } }
 
		/// <summary>exchange ask (@ print time)</summary>
        public float Eask { get { return body.eask; } set { body.eask = value; } }
 
		/// <summary>exchange bid size</summary>
        public ushort Ebsz { get { return body.ebsz; } set { body.ebsz = value; } }
 
		/// <summary>exchange ask size</summary>
        public ushort Easz { get { return body.easz; } set { body.easz = value; } }
 
		/// <summary>age of prevailing quote at time of print</summary>
        public float Eage { get { return body.eage; } set { body.eage = value; } }
 
		/// <summary>implied print side (based on ebid/eask and nbbo market)</summary>
        public PrtSide PrtSide { get { return body.prtSide; } set { body.prtSide = value; } }
 
		/// <summary>exchange high precision timestamp (if available)</summary>
        public long PrtTimestamp { get { return body.prtTimestamp; } set { body.prtTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionPrint


	/// <summary>
	/// OptionRiskFactor:2320
	/// </summary>
	/// <remarks>
	/// This table contains the up/dn underlier price slides used in OCC risk calculations.  Note that these values are computed by SpiderRock using similar methods but may not exactly match OCC values.
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
			public TickerKeyLayout ticker;
			public float svol;
			public float years;
			public float up50;
			public float dn50;
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
			public FixedString24Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
 		private CachedFixedLengthString<FixedString24Layout> calcErr;
		

            
		
        public TickerKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>option surface volatility</summary>
        public float Svol { get { return body.svol; } set { body.svol = value; } }
 
		/// <summary>years to expiration</summary>
        public float Years { get { return body.years; } set { body.years = value; } }
 
		/// <summary>underlier up 50% slide</summary>
        public float Up50 { get { return body.up50; } set { body.up50 = value; } }
 
		/// <summary>underlier dn 50% slide</summary>
        public float Dn50 { get { return body.dn50; } set { body.dn50 = value; } }
 
		/// <summary>underlier up 15% slide</summary>
        public float Up15 { get { return body.up15; } set { body.up15 = value; } }
 
		/// <summary>underlier dn 15% slide</summary>
        public float Dn15 { get { return body.dn15; } set { body.dn15 = value; } }
 
		/// <summary>underlier up 12% slide</summary>
        public float Up12 { get { return body.up12; } set { body.up12 = value; } }
 
		/// <summary>underlier dn 12% slide</summary>
        public float Dn12 { get { return body.dn12; } set { body.dn12 = value; } }
 
		/// <summary>underlier up 9% slide</summary>
        public float Up09 { get { return body.up09; } set { body.up09 = value; } }
 
		/// <summary>underlier dn 9% slide</summary>
        public float Dn09 { get { return body.dn09; } set { body.dn09 = value; } }
 
		/// <summary>underlier dn 8% slide</summary>
        public float Dn08 { get { return body.dn08; } set { body.dn08 = value; } }
 
		/// <summary>underlier up 6% slide</summary>
        public float Up06 { get { return body.up06; } set { body.up06 = value; } }
 
		/// <summary>underlier dn 6% slide</summary>
        public float Dn06 { get { return body.dn06; } set { body.dn06 = value; } }
 
		/// <summary>underlier up 3% slide</summary>
        public float Up03 { get { return body.up03; } set { body.up03 = value; } }
 
		/// <summary>underlier dn 3% slide</summary>
        public float Dn03 { get { return body.dn03; } set { body.dn03 = value; } }
 
		/// <summary>option pricing error, otherwise, an empty string.</summary>
        public string CalcErr { get { return CacheVar.AllocIfNull(ref calcErr).Get(ref body.calcErr, usn); } set { CacheVar.AllocIfNull(ref calcErr).Set(value); body.calcErr = value; } }
 
		
        public CalcSource CalcSource { get { return body.calcSource; } set { body.calcSource = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // OptionRiskFactor


	/// <summary>
	/// ProductDefinitionV2:2455
	/// </summary>
	/// <remarks>
	/// SpiderRock normalized exchange product definitions.  Includes future, option, and spread definitions from a number of exchanges.  TickerDefinitions, RootDefinitions and CCodeDefinitions are consistent with these records.
	/// </remarks>

    public partial class ProductDefinitionV2
    {
		public ProductDefinitionV2()
		{
		}
		
		public ProductDefinitionV2(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public ProductDefinitionV2(ProductDefinitionV2 source)
        {
            source.CopyTo(this);
        }
		
		internal ProductDefinitionV2(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as ProductDefinitionV2);
		}
		
		public bool Equals(ProductDefinitionV2 other)
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
		public void CopyTo(ProductDefinitionV2 target)
        {			
			target.header = header;
 			pkey.CopyTo(target.pkey);
 			target.body = body;
 
			if (LegsList != null)
			{
				target.LegsList = new LegsItem[LegsList.Length];
				for (int i = 0; i < LegsList.Length; i++)
				{
					var src = LegsList[i];
					
					var dest = new LegsItem();
					dest.LegID = src.LegID;
 					dest.SecKey = src.SecKey;
 					dest.SecType = src.SecType;
 					dest.Side = src.Side;
 					dest.Ratio = src.Ratio;
 					dest.RefDelta = src.RefDelta;
 					dest.RefPrc = src.RefPrc;

					target.LegsList[i] = dest;
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
 			LegsList = null;

        }

		public long TimeRcvd { get; internal set; }
		
		public long TimeSent { get { return header.sentts; } }
		
		public SourceId SourceId { get { return header.sourceid; } }
		
		public byte SeqNum { get { return header.seqnum; } }

		public PKey Key { get { return pkey; } }

		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.ProductDefinitionV2};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private OptionKey secKey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				secKey = other.secKey;
				
			}
			
			/// <summary>SR Security Key [can be partially filled in (look at secType)]</summary>
			public OptionKey SecKey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return secKey ?? (secKey = OptionKey.GetCreateOptionKey(body.secKey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.secKey = value.Layout; secKey = value; }
			}
 			/// <summary>Security Type [Stock, Future, Option]</summary>
			public SpdrKeyType SecType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.secType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.secType = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				secKey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.secKey = secKey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.secKey = secKey;

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
        } // ProductDefinitionV2.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public OptionKeyLayout secKey;
 			public SpdrKeyType secType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	secKey.Equals(other.secKey) &&
					 	secType.Equals(other.secType);
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
					var hashCode = secKey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) secType);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // ProductDefinitionV2.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 		
		#region Repeats 
		

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class LegsItem
        {
            public const int Length = 66;

            public LegsItem() { }
            
            public LegsItem(string legID, OptionKey secKey, SpdrKeyType secType, BuySell side, ushort ratio, float refDelta, double refPrc)
            {
                this.LegID = legID;
                this.SecKey = secKey;
                this.SecType = secType;
                this.Side = side;
                this.Ratio = ratio;
                this.RefDelta = refDelta;
                this.RefPrc = refPrc;
            }

            private FixedString24Layout _legID;
			public string LegID { get { return _legID; } internal set { _legID = value; } }
			public OptionKey SecKey { get; internal set; }
			public SpdrKeyType SecType { get; internal set; }
			public BuySell Side { get; internal set; }
			public ushort Ratio { get; internal set; }
			public float RefDelta { get; internal set; }
			public double RefPrc { get; internal set; }
        }

        public LegsItem[] LegsList { get; set; }


		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public FixedString24Layout securityID;
			public ProductClass productClass;
			public long underlierID;
			public ExpiryKeyLayout undKey;
			public SpdrKeyType undType;
			public FixedString6Layout productGroup;
			public FixedString6Layout securityGroup;
			public int marketSegmentID;
			public FixedString80Layout securityDesc;
			public FixedString8Layout exchange;
			public ProductType productType;
			public ProductTerm productTerm;
			public ProductIndexType productIndexType;
			public float productRate;
			public float contractSize;
			public ContractUnit contractUnit;
			public PriceFormat priceFormat;
			public double minTickSize;
			public double displayFactor;
			public double strikeScale;
			public short minLotSize;
			public short bookDepth;
			public short impliedBookDepth;
			public short impMarketInd;
			public float minPriceIncrementAmount;
			public float parValue;
			public float contMultiplier;
			public double cabPrice;
			public Currency tradeCurr;
			public Currency settleCurr;
			public Currency strikeCurr;
			public DateTimeLayout expiration;
			public DateKeyLayout maturity;
			public ExerciseType exerciseType;
			public YesNo userDefined;
			public short decayStartYear;
			public byte decayStartMonth;
			public byte decayStartDay;
			public int decayQty;
			public double priceRatio;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedFixedLengthString<FixedString24Layout> securityID;
 		private CachedExpiryKey undKey;
 		private CachedFixedLengthString<FixedString6Layout> productGroup;
 		private CachedFixedLengthString<FixedString6Layout> securityGroup;
 		private CachedFixedLengthString<FixedString80Layout> securityDesc;
 		private CachedFixedLengthString<FixedString8Layout> exchange;
 		private CachedDateKey maturity;
		


		/// <summary>unique exchange id (exch assigned)</summary>
        public string SecurityID { get { return CacheVar.AllocIfNull(ref securityID).Get(ref body.securityID, usn); } set { CacheVar.AllocIfNull(ref securityID).Set(value); body.securityID = value; } }
 
		
        public ProductClass ProductClass { get { return body.productClass; } set { body.productClass = value; } }
 
		/// <summary>underlier product id (option only) [securityID of undKey/undType product]</summary>
        public long UnderlierID { get { return body.underlierID; } set { body.underlierID = value; } }
             
		/// <summary>SR Underlier Security Key [can be partially filled in (look at undType)] (option only)</summary>
        public ExpiryKey UndKey { get { return CacheVar.AllocIfNull(ref undKey).Get(ref body.undKey, usn); } set { CacheVar.AllocIfNull(ref undKey).Set(value); body.undKey = value.Layout; } }
 
		/// <summary>Underlier Security Type [Stock, Future] (option only)</summary>
        public SpdrKeyType UndType { get { return body.undType; } set { body.undType = value; } }
 
		/// <summary>Underlying product code.  I.E. All GE (Eurodollar) spreads, options, futures will be in the same productGroup - This is the Asset field from the SecurityDefinition message</summary>
        public string ProductGroup { get { return CacheVar.AllocIfNull(ref productGroup).Get(ref body.productGroup, usn); } set { CacheVar.AllocIfNull(ref productGroup).Set(value); body.productGroup = value; } }
 
		/// <summary>Exchange specific code for a group of related securities that are all affected by market events.  I.E. All E-mini weekly options (EW) - This is SecurityGroup field from the SecurityDefinition messages</summary>
        public string SecurityGroup { get { return CacheVar.AllocIfNull(ref securityGroup).Get(ref body.securityGroup, usn); } set { CacheVar.AllocIfNull(ref securityGroup).Set(value); body.securityGroup = value; } }
 
		/// <summary>Exchange specific market segment identifier</summary>
        public int MarketSegmentID { get { return body.marketSegmentID; } set { body.marketSegmentID = value; } }
 
		/// <summary>full exchange symbol</summary>
        public string SecurityDesc { get { return CacheVar.AllocIfNull(ref securityDesc).Get(ref body.securityDesc, usn); } set { CacheVar.AllocIfNull(ref securityDesc).Set(value); body.securityDesc = value; } }
 
		/// <summary>listing exchange</summary>
        public string Exchange { get { return CacheVar.AllocIfNull(ref exchange).Get(ref body.exchange, usn); } set { CacheVar.AllocIfNull(ref exchange).Set(value); body.exchange = value; } }
 
		
        public ProductType ProductType { get { return body.productType; } set { body.productType = value; } }
 
		
        public ProductTerm ProductTerm { get { return body.productTerm; } set { body.productTerm = value; } }
 
		
        public ProductIndexType ProductIndexType { get { return body.productIndexType; } set { body.productIndexType = value; } }
 
		
        public float ProductRate { get { return body.productRate; } set { body.productRate = value; } }
 
		
        public float ContractSize { get { return body.contractSize; } set { body.contractSize = value; } }
 
		
        public ContractUnit ContractUnit { get { return body.contractUnit; } set { body.contractUnit = value; } }
 
		
        public PriceFormat PriceFormat { get { return body.priceFormat; } set { body.priceFormat = value; } }
 
		
        public double MinTickSize { get { return body.minTickSize; } set { body.minTickSize = value; } }
 
		
        public double DisplayFactor { get { return body.displayFactor; } set { body.displayFactor = value; } }
 
		/// <summary>manual strike price adjustment multiplier (used for some CME products if set, otherwise displayFactor is used) (okey_xx = strikePrice * manualStrikeScale)</summary>
        public double StrikeScale { get { return body.strikeScale; } set { body.strikeScale = value; } }
 
		/// <summary>minimum lot size</summary>
        public short MinLotSize { get { return body.minLotSize; } set { body.minLotSize = value; } }
 
		/// <summary>levels in the Globex quote book</summary>
        public short BookDepth { get { return body.bookDepth; } set { body.bookDepth = value; } }
 
		/// <summary>levels in the globex implied quote book (0 if no implied depth)</summary>
        public short ImpliedBookDepth { get { return body.impliedBookDepth; } set { body.impliedBookDepth = value; } }
 
		/// <summary>implied market type (0 = no implied, 1 = implied in, 2 = implied out, 3 = implied in &amp; out)</summary>
        public short ImpMarketInd { get { return body.impMarketInd; } set { body.impMarketInd = value; } }
 
		/// <summary>(depricate) minimum price amount (points per handle)</summary>
        public float MinPriceIncrementAmount { get { return body.minPriceIncrementAmount; } set { body.minPriceIncrementAmount = value; } }
 
		/// <summary>per contract par value</summary>
        public float ParValue { get { return body.parValue; } set { body.parValue = value; } }
 
		/// <summary>contract deliverable multipler</summary>
        public float ContMultiplier { get { return body.contMultiplier; } set { body.contMultiplier = value; } }
 
		/// <summary>(depricate) cabinet price (minimum closing price for OOM options)</summary>
        public double CabPrice { get { return body.cabPrice; } set { body.cabPrice = value; } }
 
		
        public Currency TradeCurr { get { return body.tradeCurr; } set { body.tradeCurr = value; } }
 
		
        public Currency SettleCurr { get { return body.settleCurr; } set { body.settleCurr = value; } }
 
		
        public Currency StrikeCurr { get { return body.strikeCurr; } set { body.strikeCurr = value; } }
 
		/// <summary>future expiration or option expiration (if product is an option). we use the last TRADING day as the expiration date.</summary>
        public DateTime Expiration { get { return body.expiration; } set { body.expiration = value; } }
             
		/// <summary>future maturity date or option maturity date.  this is the delivery month.</summary>
        public DateKey Maturity { get { return CacheVar.AllocIfNull(ref maturity).Get(ref body.maturity, usn); } set { CacheVar.AllocIfNull(ref maturity).Set(value); body.maturity = value.Layout; } }
 
		/// <summary>(depricate; in RootDefinition) Exercise style</summary>
        public ExerciseType ExerciseType { get { return body.exerciseType; } set { body.exerciseType = value; } }
 
		
        public YesNo UserDefined { get { return body.userDefined; } set { body.userDefined = value; } }
 
		
        public short DecayStartYear { get { return body.decayStartYear; } set { body.decayStartYear = value; } }
 
		
        public byte DecayStartMonth { get { return body.decayStartMonth; } set { body.decayStartMonth = value; } }
 
		
        public byte DecayStartDay { get { return body.decayStartDay; } set { body.decayStartDay = value; } }
 
		/// <summary>daily decay quantity</summary>
        public int DecayQty { get { return body.decayQty; } set { body.decayQty = value; } }
 
		/// <summary>price ratio for interest rate intercommodity spreads</summary>
        public double PriceRatio { get { return body.priceRatio; } set { body.priceRatio = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // ProductDefinitionV2


	/// <summary>
	/// RootDefinition:240
	/// </summary>
	/// <remarks>
	/// RootDefinition records are sourced from the listing exchange for future options and from OCC for US equity options.  Records are updated as SpiderRock receives changes.
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
			private TickerKey root;

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
			
			
			public TickerKey Root
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return root ?? (root = TickerKey.GetCreateTickerKey(body.root)); }
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
			public TickerKeyLayout root;

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
            public const int Length = 18;

            public UnderlyingItem() { }
            
            public UnderlyingItem(TickerKey ticker, float spc)
            {
                this.Ticker = ticker;
                this.Spc = spc;
            }

            public TickerKey Ticker { get; internal set; }
			public float Spc { get; internal set; }
        }

        public UnderlyingItem[] UnderlyingList { get; set; }


		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public TickerKeyLayout ticker;
			public FixedString8Layout osiRoot;
			public TickerKeyLayout ccode;
			public ExpirationMap expirationMap;
			public UnderlierMode underlierMode;
			public OptionType optionType;
			public Multihedge multihedge;
			public ExerciseTime exerciseTime;
			public ExerciseType exerciseType;
			public TimeMetric timeMetric;
			public PricingModel pricingModel;
			public MoneynessType moneynessType;
			public PriceQuoteType priceQuoteType;
			public VolumeTier volumeTier;
			public int positionLimit;
			public FixedString24Layout exchanges;
			public float tickValue;
			public float pointValue;
			public double strikeScale;
			public float strikeRatio;
			public float cashOnExercise;
			public int underliersPerCn;
			public double premiumMult;
			public AdjConvention adjConvention;
			public OptPriceInc optPriceInc;
			public PriceFormat priceFormat;
			public Currency tradeCurr;
			public Currency settleCurr;
			public Currency strikeCurr;
			public TickerKeyLayout defaultSurfaceRoot;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
 		private CachedFixedLengthString<FixedString8Layout> osiRoot;
 		private CachedTickerKey ccode;
 		private CachedFixedLengthString<FixedString24Layout> exchanges;
 		private CachedTickerKey defaultSurfaceRoot;
		

            
		/// <summary>master underlying</summary>
        public TickerKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>long version of the root.  the short version is used in the TickerKey (for example RYAAY1, not RYAA1)</summary>
        public string OsiRoot { get { return CacheVar.AllocIfNull(ref osiRoot).Get(ref body.osiRoot, usn); } set { CacheVar.AllocIfNull(ref osiRoot).Set(value); body.osiRoot = value; } }
             
		
        public TickerKey Ccode { get { return CacheVar.AllocIfNull(ref ccode).Get(ref body.ccode, usn); } set { CacheVar.AllocIfNull(ref ccode).Set(value); body.ccode = value.Layout; } }
 
		
        public ExpirationMap ExpirationMap { get { return body.expirationMap; } set { body.expirationMap = value; } }
 
		
        public UnderlierMode UnderlierMode { get { return body.underlierMode; } set { body.underlierMode = value; } }
 
		/// <summary>indicator for option type</summary>
        public OptionType OptionType { get { return body.optionType; } set { body.optionType = value; } }
 
		/// <summary>indicates type of multihedge</summary>
        public Multihedge Multihedge { get { return body.multihedge; } set { body.multihedge = value; } }
 
		/// <summary>Exercise time type</summary>
        public ExerciseTime ExerciseTime { get { return body.exerciseTime; } set { body.exerciseTime = value; } }
 
		/// <summary>Exercise style</summary>
        public ExerciseType ExerciseType { get { return body.exerciseType; } set { body.exerciseType = value; } }
 
		/// <summary>trading time metric - 252 or 365 trading days or a weekly cycle type</summary>
        public TimeMetric TimeMetric { get { return body.timeMetric; } set { body.timeMetric = value; } }
 
		
        public PricingModel PricingModel { get { return body.pricingModel; } set { body.pricingModel = value; } }
 
		/// <summary>moneyness (xAxis) convention: PctStd = (K / fUPrc - 1) / (axisVol * RT), LogStd = LOG(K/fUPrc) / (axisVol * RT), NormStd = (K - fUPrc) / (axisVol * RT)</summary>
        public MoneynessType MoneynessType { get { return body.moneynessType; } set { body.moneynessType = value; } }
 
		/// <summary>quoting style for the option series on the exchange, price (standard price quote) or volatility quoted (vol points)</summary>
        public PriceQuoteType PriceQuoteType { get { return body.priceQuoteType; } set { body.priceQuoteType = value; } }
 
		
        public VolumeTier VolumeTier { get { return body.volumeTier; } set { body.volumeTier = value; } }
 
		/// <summary>max contract limit</summary>
        public int PositionLimit { get { return body.positionLimit; } set { body.positionLimit = value; } }
 
		/// <summary>exchange codes</summary>
        public string Exchanges { get { return CacheVar.AllocIfNull(ref exchanges).Get(ref body.exchanges, usn); } set { CacheVar.AllocIfNull(ref exchanges).Set(value); body.exchanges = value; } }
 
		/// <summary>$NLV value of a single tick change in display premium	(pointValue = tickValue / tickSize)</summary>
        public float TickValue { get { return body.tickValue; } set { body.tickValue = value; } }
 
		/// <summary>$NLV value of a single point change in display premium (pointValue = tickValue / tickSize)</summary>
        public float PointValue { get { return body.pointValue; } set { body.pointValue = value; } }
 
		/// <summary>manual strike price adjustment multiplier (used for some CME products if set, otherwise displayFactor is used) (okey_xx = strikePrice * manualStrikeScale)</summary>
        public double StrikeScale { get { return body.strikeScale; } set { body.strikeScale = value; } }
 
		/// <summary>note: effective strike = strike * strikeRatio - cashOnExercise</summary>
        public float StrikeRatio { get { return body.strikeRatio; } set { body.strikeRatio = value; } }
 
		/// <summary>note: cashOnExercise is positive if it decreases the effective strike price</summary>
        public float CashOnExercise { get { return body.cashOnExercise; } set { body.cashOnExercise = value; } }
 
		/// <summary>note: always 100 if underlying list is in use</summary>
        public int UnderliersPerCn { get { return body.underliersPerCn; } set { body.underliersPerCn = value; } }
 
		/// <summary>note: OCC premium/strike multiplier (usually 100)</summary>
        public double PremiumMult { get { return body.premiumMult; } set { body.premiumMult = value; } }
 
		
        public AdjConvention AdjConvention { get { return body.adjConvention; } set { body.adjConvention = value; } }
 
		
        public OptPriceInc OptPriceInc { get { return body.optPriceInc; } set { body.optPriceInc = value; } }
 
		/// <summary>price display format</summary>
        public PriceFormat PriceFormat { get { return body.priceFormat; } set { body.priceFormat = value; } }
 
		
        public Currency TradeCurr { get { return body.tradeCurr; } set { body.tradeCurr = value; } }
 
		
        public Currency SettleCurr { get { return body.settleCurr; } set { body.settleCurr = value; } }
 
		
        public Currency StrikeCurr { get { return body.strikeCurr; } set { body.strikeCurr = value; } }
             
		/// <summary>fallback ticker to use for option surfaces if no native surfaces are available</summary>
        public TickerKey DefaultSurfaceRoot { get { return CacheVar.AllocIfNull(ref defaultSurfaceRoot).Get(ref body.defaultSurfaceRoot, usn); } set { CacheVar.AllocIfNull(ref defaultSurfaceRoot).Set(value); body.defaultSurfaceRoot = value.Layout; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // RootDefinition


	/// <summary>
	/// SpreadBookQuote:525
	/// </summary>
	/// <remarks>
	/// This table contains live spread quote records from the individual equity option exchanges.  Each record contains up to two price levels and represents a live snapshot of the book for a specific spread.
	/// </remarks>

    public partial class SpreadBookQuote
    {
		public SpreadBookQuote()
		{
		}
		
		public SpreadBookQuote(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public SpreadBookQuote(SpreadBookQuote source)
        {
            source.CopyTo(this);
        }
		
		internal SpreadBookQuote(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as SpreadBookQuote);
		}
		
		public bool Equals(SpreadBookQuote other)
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
		public void CopyTo(SpreadBookQuote target)
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
        internal Header header = new Header {msgtype = MessageType.SpreadBookQuote};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey skey;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				skey = other.skey;
				
			}
			
			/// <summary>SR Spread Key (should have corresponding ProductDefinition record)</summary>
			public TickerKey Skey
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return skey ?? (skey = TickerKey.GetCreateTickerKey(body.skey)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.skey = value.Layout; skey = value; }
			}
 			/// <summary>Yes indicates that response is made of entirely of isTest=Yes SpreadExchOrders</summary>
			public YesNo IsTest
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.isTest; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.isTest = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				skey = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.skey = skey;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.skey = skey;

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
        } // SpreadBookQuote.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout skey;
 			public YesNo isTest;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	skey.Equals(other.skey) &&
					 	isTest.Equals(other.isTest);
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
					var hashCode = skey.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) isTest);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // SpreadBookQuote.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public TickerKeyLayout ticker;
			public double bidPrice1;
			public double askPrice1;
			public ushort bidSize1;
			public ushort askSize1;
			public double bidPrice2;
			public double askPrice2;
			public ushort bidSize2;
			public ushort askSize2;
			public OptExch bidExch1;
			public OptExch askExch1;
			public uint bidMask1;
			public uint askMask1;
			public DateTimeLayout bidTime;
			public DateTimeLayout askTime;
			public UpdateType updateType;
			public long srcTimestamp;
			public long netTimestamp;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
		

            
		/// <summary>common spread underlier</summary>
        public TickerKey Ticker { get { return CacheVar.AllocIfNull(ref ticker).Get(ref body.ticker, usn); } set { CacheVar.AllocIfNull(ref ticker).Set(value); body.ticker = value.Layout; } }
 
		/// <summary>bid price</summary>
        public double BidPrice1 { get { return body.bidPrice1; } set { body.bidPrice1 = value; } }
 
		/// <summary>ask price</summary>
        public double AskPrice1 { get { return body.askPrice1; } set { body.askPrice1 = value; } }
 
		/// <summary>cumulative size at bidPrice</summary>
        public ushort BidSize1 { get { return body.bidSize1; } set { body.bidSize1 = value; } }
 
		/// <summary>cumulative size at askPrice</summary>
        public ushort AskSize1 { get { return body.askSize1; } set { body.askSize1 = value; } }
 
		/// <summary>2nd best bid price</summary>
        public double BidPrice2 { get { return body.bidPrice2; } set { body.bidPrice2 = value; } }
 
		/// <summary>2nd best ask price</summary>
        public double AskPrice2 { get { return body.askPrice2; } set { body.askPrice2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort BidSize2 { get { return body.bidSize2; } set { body.bidSize2 = value; } }
 
		/// <summary>cumulative size at 2nd price</summary>
        public ushort AskSize2 { get { return body.askSize2; } set { body.askSize2 = value; } }
 
		/// <summary>exchange at bid price with the largest size (if any)</summary>
        public OptExch BidExch1 { get { return body.bidExch1; } set { body.bidExch1 = value; } }
 
		/// <summary>exchange at ask price with the largest size (if any)</summary>
        public OptExch AskExch1 { get { return body.askExch1; } set { body.askExch1 = value; } }
 
		/// <summary>exchange bid bit mask (OptExch mask for NMS spreads; zero for single exchange spreads)</summary>
        public uint BidMask1 { get { return body.bidMask1; } set { body.bidMask1 = value; } }
 
		/// <summary>exchange ask bit mask (OptExch mask for NMS spreads; zero for single exchange spreads)</summary>
        public uint AskMask1 { get { return body.askMask1; } set { body.askMask1 = value; } }
 
		/// <summary>last bid price or size change</summary>
        public DateTime BidTime { get { return body.bidTime; } set { body.bidTime = value; } }
 
		/// <summary>last ask price or size change</summary>
        public DateTime AskTime { get { return body.askTime; } set { body.askTime = value; } }
 
		
        public UpdateType UpdateType { get { return body.updateType; } set { body.updateType = value; } }
 
		/// <summary>source high precision timestamp (if available)</summary>
        public long SrcTimestamp { get { return body.srcTimestamp; } set { body.srcTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // SpreadBookQuote


	/// <summary>
	/// StockBookQuote:430
	/// </summary>
	/// <remarks>
	/// This table contains live equity quote records for all CQS/UQDF securities as well as US OTC equity securities, SpiderRock synthetic markets, and a number of major indexes.  Each record contains up to two price levels and represents a live snapshot of the book for a specific market.
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
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
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
			public TickerKeyLayout ticker;

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
			public UpdateType updateType;
			public MarketStatus marketStatus;
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
			public uint haltMask;
			public long srcTimestamp;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		
        public UpdateType UpdateType { get { return body.updateType; } set { body.updateType = value; } }
 
		/// <summary>market status (open, halted, etc)</summary>
        public MarketStatus MarketStatus { get { return body.marketStatus; } set { body.marketStatus = value; } }
 
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
 
		/// <summary>bit mask of halted exchanges</summary>
        public uint HaltMask { get { return body.haltMask; } set { body.haltMask = value; } }
 
		/// <summary>source high precision timestamp (if available)</summary>
        public long SrcTimestamp { get { return body.srcTimestamp; } set { body.srcTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // StockBookQuote


	/// <summary>
	/// StockExchImbalance:490
	/// </summary>
	/// <remarks>
	/// StockExchImbalance records contain live exchange closing auction imbalance details.  Imbalance information can be available from more than one exchange for each ticker.
	/// Final StockExchImbalance records are published to the SpiderRock elastic cluster nightly after the auction close.
	/// </remarks>

    public partial class StockExchImbalance
    {
		public StockExchImbalance()
		{
		}
		
		public StockExchImbalance(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockExchImbalance(StockExchImbalance source)
        {
            source.CopyTo(this);
        }
		
		internal StockExchImbalance(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockExchImbalance);
		}
		
		public bool Equals(StockExchImbalance other)
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
		public void CopyTo(StockExchImbalance target)
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
        internal Header header = new Header {msgtype = MessageType.StockExchImbalance};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}
 			/// <summary>Projected Auction Time (hhmm).</summary>
			public DateTime AuctionTime
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.auctionTime; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.auctionTime = value; }
			}
 			/// <summary>Auction type: None; Open; Market; Halt; Closing; RegulatoryImbalance</summary>
			public AuctionReason AuctionType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.auctionType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.auctionType = value; }
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
        } // StockExchImbalance.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout ticker;
 			public DateTimeLayout auctionTime;
 			public AuctionReason auctionType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker) &&
					 	auctionTime.Equals(other.auctionTime) &&
					 	auctionType.Equals(other.auctionType);
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
 					hashCode = (hashCode*397) ^ (auctionTime.GetHashCode());
 					hashCode = (hashCode*397) ^ ((int) auctionType);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockExchImbalance.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float referencePx;
			public int pairedQty;
			public int totalImbalanceQty;
			public int marketImbalanceQty;
			public ImbalanceSide imbalanceSide;
			public float continuousBookClrPx;
			public float closingOnlyClrPx;
			public float ssrFillingPx;
			public float indicativeMatchPx;
			public float upperCollar;
			public float lowerCollar;
			public AuctionStatus auctionStatus;
			public YesNo freezeStatus;
			public byte numExtensions;
			public DateTimeLayout sourceTime;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>For Pillar-powered markets, the Reference Price is used to calculate the Indicative Match Price.</summary>
        public float ReferencePx { get { return body.referencePx; } set { body.referencePx = value; } }
 
		/// <summary>For Pillar-powered markets, the number of shares paired off at the Indicative Match Price.</summary>
        public int PairedQty { get { return body.pairedQty; } set { body.pairedQty = value; } }
 
		/// <summary>For Pillar-powered markets, the total imbalance quantity at the Indicative Match Price. If the value is negative, the imbalance is on the sell side; if the value is positive, the imbalance is on the buy side.</summary>
        public int TotalImbalanceQty { get { return body.totalImbalanceQty; } set { body.totalImbalanceQty = value; } }
 
		/// <summary>For Pillar-powered markets, the total market order imbalance quantity at the Indicative Match Price. If the value is negative, the imbalance is on the sell side; if the value is positive the imbalance is on the buy side.</summary>
        public int MarketImbalanceQty { get { return body.marketImbalanceQty; } set { body.marketImbalanceQty = value; } }
 
		/// <summary>The side of the TotalImbalanceQty.</summary>
        public ImbalanceSide ImbalanceSide { get { return body.imbalanceSide; } set { body.imbalanceSide = value; } }
 
		/// <summary>For Pillar-powered markets, the price at which all interest on the book can trade, including auction and imbalance offset interest, and disregarding auction collars.</summary>
        public float ContinuousBookClrPx { get { return body.continuousBookClrPx; } set { body.continuousBookClrPx = value; } }
 
		/// <summary>For Pillar-powered markets, the price at which all eligible auction-only interest would trade, subject to auction collars.</summary>
        public float ClosingOnlyClrPx { get { return body.closingOnlyClrPx; } set { body.closingOnlyClrPx = value; } }
 
		/// <summary>For Pillar-powered markets, not supported and defaulted to 0.</summary>
        public float SsrFillingPx { get { return body.ssrFillingPx; } set { body.ssrFillingPx = value; } }
 
		/// <summary>For Pillar-powered markets, the price that has the highest executable volume of auction-eligible shares, subject to auction collars. It includes the non-displayed quantity of Reserve Orders.</summary>
        public float IndicativeMatchPx { get { return body.indicativeMatchPx; } set { body.indicativeMatchPx = value; } }
 
		/// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
        public float UpperCollar { get { return body.upperCollar; } set { body.upperCollar = value; } }
 
		/// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
        public float LowerCollar { get { return body.lowerCollar; } set { body.lowerCollar = value; } }
 
		/// <summary>Indicates whether the auction will run.</summary>
        public AuctionStatus AuctionStatus { get { return body.auctionStatus; } set { body.auctionStatus = value; } }
 
		/// <summary>Indicates freeze</summary>
        public YesNo FreezeStatus { get { return body.freezeStatus; } set { body.freezeStatus = value; } }
 
		/// <summary>Number of times the halt period has been extended.</summary>
        public byte NumExtensions { get { return body.numExtensions; } set { body.numExtensions = value; } }
 
		/// <summary>Time record was generated in the order book (in seconds)</summary>
        public DateTime SourceTime { get { return body.sourceTime; } set { body.sourceTime = value; } }
 
		/// <summary>PTP timestamp</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // StockExchImbalance


	/// <summary>
	/// StockExchImbalanceV2:491
	/// </summary>
	/// <remarks>
	/// StockExchImbalanceV2 records contain live exchange closing auction imbalance details.  Imbalance information can be available from more than one exchange for each ticker.
	/// Final StockExchImbalanceV2 records are published to the SpiderRock elastic cluster nightly after the auction close.
	/// </remarks>

    public partial class StockExchImbalanceV2
    {
		public StockExchImbalanceV2()
		{
		}
		
		public StockExchImbalanceV2(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockExchImbalanceV2(StockExchImbalanceV2 source)
        {
            source.CopyTo(this);
        }
		
		internal StockExchImbalanceV2(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockExchImbalanceV2);
		}
		
		public bool Equals(StockExchImbalanceV2 other)
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
		public void CopyTo(StockExchImbalanceV2 target)
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
        internal Header header = new Header {msgtype = MessageType.StockExchImbalanceV2};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.ticker = value.Layout; ticker = value; }
			}
 			/// <summary>Projected Auction Time (hhmm).</summary>
			public DateTime AuctionTime
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.auctionTime; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.auctionTime = value; }
			}
 			
			public AuctionReason AuctionType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.auctionType; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.auctionType = value; }
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
        } // StockExchImbalanceV2.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout ticker;
 			public DateTimeLayout auctionTime;
 			public AuctionReason auctionType;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker) &&
					 	auctionTime.Equals(other.auctionTime) &&
					 	auctionType.Equals(other.auctionType);
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
 					hashCode = (hashCode*397) ^ (auctionTime.GetHashCode());
 					hashCode = (hashCode*397) ^ ((int) auctionType);

                    return hashCode;
					// ReSharper restore NonReadonlyFieldInGetHashCode
                }
            }
        } // StockExchImbalanceV2.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public float referencePx;
			public int pairedQty;
			public int totalImbalanceQty;
			public int marketImbalanceQty;
			public ImbalanceSide imbalanceSide;
			public float continuousBookClrPx;
			public float closingOnlyClrPx;
			public float ssrFillingPx;
			public float indicativeMatchPx;
			public float upperCollar;
			public float lowerCollar;
			public AuctionStatus auctionStatus;
			public YesNo freezeStatus;
			public byte numExtensions;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>For Pillar-powered markets, the Reference Price is used to calculate the Indicative Match Price.</summary>
        public float ReferencePx { get { return body.referencePx; } set { body.referencePx = value; } }
 
		/// <summary>For Pillar-powered markets, the number of shares paired off at the Indicative Match Price.</summary>
        public int PairedQty { get { return body.pairedQty; } set { body.pairedQty = value; } }
 
		/// <summary>For Pillar-powered markets, the total imbalance quantity at the Indicative Match Price.</summary>
        public int TotalImbalanceQty { get { return body.totalImbalanceQty; } set { body.totalImbalanceQty = value; } }
 
		/// <summary>For Pillar-powered markets, the total market order imbalance quantity at the Indicative Match Price.</summary>
        public int MarketImbalanceQty { get { return body.marketImbalanceQty; } set { body.marketImbalanceQty = value; } }
 
		/// <summary>The side of the TotalImbalanceQty.</summary>
        public ImbalanceSide ImbalanceSide { get { return body.imbalanceSide; } set { body.imbalanceSide = value; } }
 
		/// <summary>For Pillar-powered markets, the price at which all interest on the book can trade, including auction and imbalance offset interest, and disregarding auction collars.</summary>
        public float ContinuousBookClrPx { get { return body.continuousBookClrPx; } set { body.continuousBookClrPx = value; } }
 
		/// <summary>For Pillar-powered markets, the price at which all eligible auction-only interest would trade, subject to auction collars.</summary>
        public float ClosingOnlyClrPx { get { return body.closingOnlyClrPx; } set { body.closingOnlyClrPx = value; } }
 
		/// <summary>For Pillar-powered markets, not supported and defaulted to 0.</summary>
        public float SsrFillingPx { get { return body.ssrFillingPx; } set { body.ssrFillingPx = value; } }
 
		/// <summary>For Pillar-powered markets, the price that has the highest executable volume of auction-eligible shares, subject to auction collars. It includes the non-displayed quantity of Reserve Orders.</summary>
        public float IndicativeMatchPx { get { return body.indicativeMatchPx; } set { body.indicativeMatchPx = value; } }
 
		/// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
        public float UpperCollar { get { return body.upperCollar; } set { body.upperCollar = value; } }
 
		/// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
        public float LowerCollar { get { return body.lowerCollar; } set { body.lowerCollar = value; } }
 
		/// <summary>Indicates whether the auction will run.</summary>
        public AuctionStatus AuctionStatus { get { return body.auctionStatus; } set { body.auctionStatus = value; } }
 
		
        public YesNo FreezeStatus { get { return body.freezeStatus; } set { body.freezeStatus = value; } }
 
		/// <summary>Number of times the halt period has been extended.</summary>
        public byte NumExtensions { get { return body.numExtensions; } set { body.numExtensions = value; } }
 
		/// <summary>PTP timestamp</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // StockExchImbalanceV2


	/// <summary>
	/// StockMarketSummary:445
	/// </summary>
	/// <remarks>
	/// These records represent live market summary snapshots for equity, index, and synthetic markets.
	/// </remarks>

    public partial class StockMarketSummary
    {
		public StockMarketSummary()
		{
		}
		
		public StockMarketSummary(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public StockMarketSummary(StockMarketSummary source)
        {
            source.CopyTo(this);
        }
		
		internal StockMarketSummary(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StockMarketSummary);
		}
		
		public bool Equals(StockMarketSummary other)
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
		public void CopyTo(StockMarketSummary target)
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
        internal Header header = new Header {msgtype = MessageType.StockMarketSummary};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
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
        } // StockMarketSummary.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout ticker;

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
        } // StockMarketSummary.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public double iniPrice;
			public double mrkPrice;
			public double clsPrice;
			public double minPrice;
			public double maxPrice;
			public int sharesOutstanding;
			public int bidCount;
			public int bidVolume;
			public int askCount;
			public int askVolume;
			public int midCount;
			public int midVolume;
			public int prtCount;
			public double prtPrice;
			public int expCount;
			public double expWidth;
			public float expBidSize;
			public float expAskSize;
			public DateTimeLayout lastPrint;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>first print price of the day during regular market hours</summary>
        public double IniPrice { get { return body.iniPrice; } set { body.iniPrice = value; } }
 
		/// <summary>last print handling during regular market hours</summary>
        public double MrkPrice { get { return body.mrkPrice; } set { body.mrkPrice = value; } }
 
		/// <summary>official exchange closing price</summary>
        public double ClsPrice { get { return body.clsPrice; } set { body.clsPrice = value; } }
 
		/// <summary>minimum print price within market hours</summary>
        public double MinPrice { get { return body.minPrice; } set { body.minPrice = value; } }
 
		/// <summary>maximum print price within market hours</summary>
        public double MaxPrice { get { return body.maxPrice; } set { body.maxPrice = value; } }
 
		/// <summary>shares outstanding</summary>
        public int SharesOutstanding { get { return body.sharesOutstanding; } set { body.sharesOutstanding = value; } }
 
		/// <summary>num prints &lt;= quote.bid</summary>
        public int BidCount { get { return body.bidCount; } set { body.bidCount = value; } }
 
		/// <summary>volume when prtPrice &lt;= quote.bid</summary>
        public int BidVolume { get { return body.bidVolume; } set { body.bidVolume = value; } }
 
		/// <summary>num prints &gt;= quote.ask</summary>
        public int AskCount { get { return body.askCount; } set { body.askCount = value; } }
 
		/// <summary>volume when prtPrice &gt;= quote.ask</summary>
        public int AskVolume { get { return body.askVolume; } set { body.askVolume = value; } }
 
		/// <summary>num prints inside quote.bid / quote.ask</summary>
        public int MidCount { get { return body.midCount; } set { body.midCount = value; } }
 
		/// <summary>volume inside quote.bid / quote.ask</summary>
        public int MidVolume { get { return body.midVolume; } set { body.midVolume = value; } }
 
		/// <summary>number of distinct print reports</summary>
        public int PrtCount { get { return body.prtCount; } set { body.prtCount = value; } }
 
		/// <summary>last print price</summary>
        public double PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>number of updates included in exponential average</summary>
        public int ExpCount { get { return body.expCount; } set { body.expCount = value; } }
 
		/// <summary>exponential average market width (10 minute 1/2 life)</summary>
        public double ExpWidth { get { return body.expWidth; } set { body.expWidth = value; } }
 
		/// <summary>exponential average bid size (10 minute 1/2 life)</summary>
        public float ExpBidSize { get { return body.expBidSize; } set { body.expBidSize = value; } }
 
		/// <summary>exponential average ask size (10 minute 1/2 life)</summary>
        public float ExpAskSize { get { return body.expAskSize; } set { body.expAskSize = value; } }
 
		
        public DateTime LastPrint { get { return body.lastPrint; } set { body.lastPrint = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockMarketSummary


	/// <summary>
	/// StockPrint:440
	/// </summary>
	/// <remarks>
	/// The most recent (last) print record for CTS/UTDF markets as well as SpiderRock synthetic markets.  Records also incorporate some summary detail and closing mark information as well.
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
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
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
			public TickerKeyLayout ticker;

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
			public StkExch prtExch;
			public int prtSize;
			public float prtPrice;
			public int prtClusterNum;
			public int prtClusterSize;
			public int prtVolume;
			public float mrkPrice;
			public float clsPrice;
			public StkPrintType prtType;
			public byte prtCond1;
			public byte prtCond2;
			public byte prtCond3;
			public byte prtCond4;
			public float ebid;
			public float eask;
			public ushort ebsz;
			public ushort easz;
			public float eage;
			public PrtSide prtSide;
			public long prtTimestamp;
			public long netTimestamp;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>print exch</summary>
        public StkExch PrtExch { get { return body.prtExch; } set { body.prtExch = value; } }
 
		/// <summary>print size</summary>
        public int PrtSize { get { return body.prtSize; } set { body.prtSize = value; } }
 
		/// <summary>print price level</summary>
        public float PrtPrice { get { return body.prtPrice; } set { body.prtPrice = value; } }
 
		/// <summary>incremental print cluster counter (one counter per ticker; used to group prints into clusters)</summary>
        public int PrtClusterNum { get { return body.prtClusterNum; } set { body.prtClusterNum = value; } }
 
		/// <summary>cumulative size of prints in this sequence (prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
        public int PrtClusterSize { get { return body.prtClusterSize; } set { body.prtClusterSize = value; } }
 
		/// <summary>cumulative print size today</summary>
        public int PrtVolume { get { return body.prtVolume; } set { body.prtVolume = value; } }
 
		/// <summary>last regular market print price</summary>
        public float MrkPrice { get { return body.mrkPrice; } set { body.mrkPrice = value; } }
 
		/// <summary>official closing price (if available)</summary>
        public float ClsPrice { get { return body.clsPrice; } set { body.clsPrice = value; } }
 
		
        public StkPrintType PrtType { get { return body.prtType; } set { body.prtType = value; } }
 
		/// <summary>print condition (from SIP feed)</summary>
        public byte PrtCond1 { get { return body.prtCond1; } set { body.prtCond1 = value; } }
 
		
        public byte PrtCond2 { get { return body.prtCond2; } set { body.prtCond2 = value; } }
 
		
        public byte PrtCond3 { get { return body.prtCond3; } set { body.prtCond3 = value; } }
 
		
        public byte PrtCond4 { get { return body.prtCond4; } set { body.prtCond4 = value; } }
 
		/// <summary>exchange bid (@ print time) [SIP feed]</summary>
        public float Ebid { get { return body.ebid; } set { body.ebid = value; } }
 
		/// <summary>exchange ask (@ print time) [SIP feed]</summary>
        public float Eask { get { return body.eask; } set { body.eask = value; } }
 
		/// <summary>exchange bid size</summary>
        public ushort Ebsz { get { return body.ebsz; } set { body.ebsz = value; } }
 
		/// <summary>exchange ask size</summary>
        public ushort Easz { get { return body.easz; } set { body.easz = value; } }
 
		/// <summary>age of prevailing quote at time of print</summary>
        public float Eage { get { return body.eage; } set { body.eage = value; } }
 
		
        public PrtSide PrtSide { get { return body.prtSide; } set { body.prtSide = value; } }
 
		/// <summary>exchange high precision timestamp (if available)</summary>
        public long PrtTimestamp { get { return body.prtTimestamp; } set { body.prtTimestamp = value; } }
 
		/// <summary>inbound packet PTP timestamp from SR gateway switch; usually syncronized with facility grandfather clock</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // StockPrint


	/// <summary>
	/// TickerDefinition:420
	/// </summary>
	/// <remarks>
	/// TickerDefinition records exist for all SpiderRock tickers including equity tickers (stocks and ETFs) as well as index tickers and synthetic tickers for future chains and option multihedge baskets.
	/// TickerDefinition records are published nightly to the SpiderRock elastic cluster during product rotation windows.
	/// </remarks>

    public partial class TickerDefinition
    {
		public TickerDefinition()
		{
		}
		
		public TickerDefinition(PKey pkey)
		{
			this.pkey.body = pkey.body;
		}
		
        public TickerDefinition(TickerDefinition source)
        {
            source.CopyTo(this);
        }
		
		internal TickerDefinition(PKeyLayout pkey)
		{
			this.pkey.body = pkey;
		}

		public override bool Equals(object other)
		{
			return Equals(other as TickerDefinition);
		}
		
		public bool Equals(TickerDefinition other)
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
		public void CopyTo(TickerDefinition target)
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
        internal Header header = new Header {msgtype = MessageType.TickerDefinition};
 	
		#region PKey
		
		public sealed class PKey : IEquatable<PKey>, ICloneable
		{
			private TickerKey ticker;

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
			
			
			public TickerKey Ticker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker ?? (ticker = TickerKey.GetCreateTickerKey(body.ticker)); }
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
        } // TickerDefinition.PKey        

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        internal struct PKeyLayout : IEquatable<PKeyLayout>
        {
			public TickerKeyLayout ticker;

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
        } // TickerDefinition.PKeyLayout

		// ReSharper disable once InconsistentNaming
        internal readonly PKey pkey = new PKey();

		#endregion
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public SymbolType symbolType;
			public FixedString32Layout name;
			public short indNum;
			public short subNum;
			public short grpNum;
			public PrimaryExch primaryExch;
			public FixedString6Layout symbol;
			public FixedString1Layout issueClass;
			public int securityID;
			public FixedString4Layout sic;
			public FixedString10Layout cusip;
			public TapeCode tapeCode;
			public StkPriceInc stkPriceInc;
			public float stkVolume;
			public float futVolume;
			public float optVolume;
			public FixedString8Layout exchString;
			public int numOptions;
			public int sharesOutstanding;
			public TimeMetric timeMetric;
			public FixedString2Layout tickPilotGroup;
			public TkDefSource tkDefSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedFixedLengthString<FixedString32Layout> name;
 		private CachedFixedLengthString<FixedString6Layout> symbol;
 		private CachedFixedLengthString<FixedString1Layout> issueClass;
 		private CachedFixedLengthString<FixedString4Layout> sic;
 		private CachedFixedLengthString<FixedString10Layout> cusip;
 		private CachedFixedLengthString<FixedString8Layout> exchString;
 		private CachedFixedLengthString<FixedString2Layout> tickPilotGroup;
		


		
        public SymbolType SymbolType { get { return body.symbolType; } set { body.symbolType = value; } }
 
		/// <summary>Symbol name</summary>
        public string Name { get { return CacheVar.AllocIfNull(ref name).Get(ref body.name, usn); } set { CacheVar.AllocIfNull(ref name).Set(value); body.name = value; } }
 
		/// <summary>industry code number</summary>
        public short IndNum { get { return body.indNum; } set { body.indNum = value; } }
 
		/// <summary>sub-industry code number</summary>
        public short SubNum { get { return body.subNum; } set { body.subNum = value; } }
 
		/// <summary>industry group code</summary>
        public short GrpNum { get { return body.grpNum; } set { body.grpNum = value; } }
 
		
        public PrimaryExch PrimaryExch { get { return body.primaryExch; } set { body.primaryExch = value; } }
 
		/// <summary>stock symbol</summary>
        public string Symbol { get { return CacheVar.AllocIfNull(ref symbol).Get(ref body.symbol, usn); } set { CacheVar.AllocIfNull(ref symbol).Set(value); body.symbol = value; } }
 
		/// <summary>issue class of stock symbol.  if no issue class field will be blank.</summary>
        public string IssueClass { get { return CacheVar.AllocIfNull(ref issueClass).Get(ref body.issueClass, usn); } set { CacheVar.AllocIfNull(ref issueClass).Set(value); body.issueClass = value; } }
 
		/// <summary>Security ID number</summary>
        public int SecurityID { get { return body.securityID; } set { body.securityID = value; } }
 
		/// <summary>SIC code</summary>
        public string Sic { get { return CacheVar.AllocIfNull(ref sic).Get(ref body.sic, usn); } set { CacheVar.AllocIfNull(ref sic).Set(value); body.sic = value; } }
 
		/// <summary>Cusip</summary>
        public string Cusip { get { return CacheVar.AllocIfNull(ref cusip).Get(ref body.cusip, usn); } set { CacheVar.AllocIfNull(ref cusip).Set(value); body.cusip = value; } }
 
		/// <summary>None; A; B; C</summary>
        public TapeCode TapeCode { get { return body.tapeCode; } set { body.tapeCode = value; } }
 
		/// <summary>Price increment: None; FullPenny; Nickle</summary>
        public StkPriceInc StkPriceInc { get { return body.stkPriceInc; } set { body.stkPriceInc = value; } }
 
		/// <summary>trailing average daily stock volume</summary>
        public float StkVolume { get { return body.stkVolume; } set { body.stkVolume = value; } }
 
		/// <summary>trailing average daily future volume</summary>
        public float FutVolume { get { return body.futVolume; } set { body.futVolume = value; } }
 
		/// <summary>trailing average daily option volume</summary>
        public float OptVolume { get { return body.optVolume; } set { body.optVolume = value; } }
 
		/// <summary>exchanges listing any options on this underlying</summary>
        public string ExchString { get { return CacheVar.AllocIfNull(ref exchString).Get(ref body.exchString, usn); } set { CacheVar.AllocIfNull(ref exchString).Set(value); body.exchString = value; } }
 
		/// <summary>total number of listed options</summary>
        public int NumOptions { get { return body.numOptions; } set { body.numOptions = value; } }
 
		/// <summary>symbol shares outstanding</summary>
        public int SharesOutstanding { get { return body.sharesOutstanding; } set { body.sharesOutstanding = value; } }
 
		/// <summary>trading time metric - 252 or 365 trading days or a weekly cycle type</summary>
        public TimeMetric TimeMetric { get { return body.timeMetric; } set { body.timeMetric = value; } }
 
		/// <summary>SEC Tick Size Pilot Group: C = Quote/Trade in pennies, G1 = Quote in 0.05, trade in pennies, G2 = Quote/Trade = 0.05 with some exemptions, G3 = Quote/Trade in 0.05</summary>
        public string TickPilotGroup { get { return CacheVar.AllocIfNull(ref tickPilotGroup).Get(ref body.tickPilotGroup, usn); } set { CacheVar.AllocIfNull(ref tickPilotGroup).Set(value); body.tickPilotGroup = value; } }
 
		/// <summary>Ticker definition source: None; Vendor; OTC; SR; Exchange</summary>
        public TkDefSource TkDefSource { get { return body.tkDefSource; } set { body.tkDefSource = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // TickerDefinition


	#endregion

	#region Admin

	/// <summary>
	/// CacheComplete:4106
	/// </summary>
	/// <remarks>

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
	/// GetCache:4096
	/// </summary>
	/// <remarks>

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


	/// <summary>
	/// NetPulse:5000
	/// </summary>
	/// <remarks>

	/// </remarks>

    internal partial class NetPulse
    {
		// ReSharper disable once InconsistentNaming
        internal Header header = new Header {msgtype = MessageType.NetPulse};
 
		#region Body
		
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		internal struct BodyLayout
		{
			public TimeSpanLayout frequency;
			public TimeSpanLayout timeout;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		


		
        public TimeSpan Frequency { get { return body.frequency; } set { body.frequency = value; } }
 
		
        public TimeSpan Timeout { get { return body.timeout; } set { body.timeout = value; } }
 
		
        public DateTime Timestamp { get { return body.timestamp; } set { body.timestamp = value; } }

		
		#endregion	

    } // NetPulse


	#endregion
}
