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

		
		#endregion	

    } // IndexQuote


	/// <summary>
	/// LiveSurfaceAtm:2160
	/// </summary>
	/// <remarks>
	/// LiveSurfaceAtm (surfaceType = 'Live') records are computed and publish continuously during trading hours and represent a current best implied volatility market fit.
	/// SurfaceType = 'PriorDay' records contain the closing surface record from the prior trading period (usually from just before the last main session close).
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
 			private string pricingAccnt;

			// ReSharper disable once InconsistentNaming
			internal PKeyLayout body;
			
			public PKey()					{ }
			internal PKey(PKeyLayout body)	{ this.body = body; }
			public PKey(PKey other)
			{
				if (other == null) throw new ArgumentNullException("other");
				body = other.body;
				ekey = other.ekey;
 				pricingAccnt = other.pricingAccnt;
				
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
 			
			public PricingGroup PricingGroup
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.pricingGroup; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.pricingGroup = value; }
			}
 			
			public string PricingAccnt
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return pricingAccnt ?? (pricingAccnt = body.pricingAccnt); }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.pricingAccnt = value; pricingAccnt = value; }
			}

			public void Clear()
			{
				body = new PKeyLayout();
				ekey = null;
 				pricingAccnt = null;

			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CopyTo(PKey target)
			{
				target.body = body;
				target.ekey = ekey;
 				target.pricingAccnt = pricingAccnt;

			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public object Clone()
			{
				var target = new PKey(body);
				target.ekey = ekey;
 				target.pricingAccnt = pricingAccnt;

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
 			public PricingGroup pricingGroup;
 			public FixedString16Layout pricingAccnt;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ekey.Equals(other.ekey) &&
					 	surfaceType.Equals(other.surfaceType) &&
					 	pricingGroup.Equals(other.pricingGroup) &&
					 	pricingAccnt.Equals(other.pricingAccnt);
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
 					hashCode = (hashCode*397) ^ ((int) pricingGroup);
 					hashCode = (hashCode*397) ^ (pricingAccnt.GetHashCode());

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
			public float sdiv;
			public float ddiv;
			public byte exType;
			public float earnCnt;
			public float earnCntAdj;
			public float axisVolRT;
			public float axisFUPrc;
			public MoneynessType moneynessType;
			public float cAtm;
			public float pAtm;
			public float minAtmVol;
			public float maxAtmVol;
			public float eMove;
			public float cAtmCen;
			public float pAtmCen;
			public float surfVariance;
			public GridType gridType;
			public float minXAxis;
			public float maxXAxis;
			public float xAxisScale;
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
			public float sdivD8;
			public float sdivD4;
			public float sdivU4;
			public float sdivU8;
			public float pwidth;
			public float vwidth;
			public float sdivEMA;
			public float sdivLo;
			public float sdivHi;
			public float atmMAC;
			public float cprMAC;
			public float slope;
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
			public CallPut fitErrCP;
			public float fitErrBid;
			public float fitErrAsk;
			public float fitErrPrc;
			public float fitErrVol;
			public FitType fitType;
			public ExpiryKeyLayout sEKey;
			public LiveSurfaceType sType;
			public DateTimeLayout sTimestamp;
			public int counter;
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
 
		/// <summary>stock dividend (borrow rate)</summary>
        public float Sdiv { get { return body.sdiv; } set { body.sdiv = value; } }
 
		/// <summary>present value of discrete dividend stream</summary>
        public float Ddiv { get { return body.ddiv; } set { body.ddiv = value; } }
 
		/// <summary>exercise type of the options used to compute this surface</summary>
        public byte ExType { get { return body.exType; } set { body.exType = value; } }
 
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
 
		/// <summary>call atm vol (xAxis = 0)</summary>
        public float CAtm { get { return body.cAtm; } set { body.cAtm = value; } }
 
		/// <summary>put atm vol (xAxis = 0)</summary>
        public float PAtm { get { return body.pAtm; } set { body.pAtm = value; } }
 
		/// <summary>minimum estimated atm vol</summary>
        public float MinAtmVol { get { return body.minAtmVol; } set { body.minAtmVol = value; } }
 
		/// <summary>maximum estimated atm vol</summary>
        public float MaxAtmVol { get { return body.maxAtmVol; } set { body.maxAtmVol = value; } }
 
		/// <summary>implied earnings move (from LiveSurfaceTerm)</summary>
        public float EMove { get { return body.eMove; } set { body.eMove = value; } }
 
		/// <summary>call atm vol (xAxis = 0) (eMove/earnCntAdj censored)</summary>
        public float CAtmCen { get { return body.cAtmCen; } set { body.cAtmCen = value; } }
 
		/// <summary>put atm vol (xAxis = 0) (eMove/earnCntAdj censored)</summary>
        public float PAtmCen { get { return body.pAtmCen; } set { body.pAtmCen = value; } }
 
		/// <summary>estimate of surface variance; full surface integration</summary>
        public float SurfVariance { get { return body.surfVariance; } set { body.surfVariance = value; } }
 
		/// <summary>gridType defines D8 - U8 xAxis points</summary>
        public GridType GridType { get { return body.gridType; } set { body.gridType = value; } }
 
		/// <summary>minimum xAxis value;xAxis values to the left extrapolate horizontally</summary>
        public float MinXAxis { get { return body.minXAxis; } set { body.minXAxis = value; } }
 
		/// <summary>maximum xAxis value;xAxis values to the right extrapolate horizontally</summary>
        public float MaxXAxis { get { return body.maxXAxis; } set { body.maxXAxis = value; } }
 
		/// <summary>xAxis @ left (skewD8) end point = -xAxisScale; xAxis @ right (skewU8) end point = +xAxisScale; [xAxis = (effStrike / effAxisFUPrc - 1.0) / axisVolRT; effStrike = strike * strikeRatio; effAxisFUPrc = axisFUPrc * symbolRatio]</summary>
        public float XAxisScale { get { return body.xAxisScale; } set { body.xAxisScale = value; } }
 
		/// <summary>skew @ D8 point (volatility skew curve)</summary>
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
 
		/// <summary>central value (@xAxis = 0) [usually zero]</summary>
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
 
		/// <summary>sdiv @ D8 point (sdiv rate curve)</summary>
        public float SdivD8 { get { return body.sdivD8; } set { body.sdivD8 = value; } }
 
		/// <summary>sdiv @ D4 point</summary>
        public float SdivD4 { get { return body.sdivD4; } set { body.sdivD4 = value; } }
 
		/// <summary>sdiv @ U4 point</summary>
        public float SdivU4 { get { return body.sdivU4; } set { body.sdivU4 = value; } }
 
		/// <summary>sdiv @ U8 point</summary>
        public float SdivU8 { get { return body.sdivU8; } set { body.sdivU8 = value; } }
 
		/// <summary>minimum mkt premium width</summary>
        public float Pwidth { get { return body.pwidth; } set { body.pwidth = value; } }
 
		/// <summary>minimum mkt volatility width</summary>
        public float Vwidth { get { return body.vwidth; } set { body.vwidth = value; } }
 
		/// <summary>sdiv exp moving average (10 minutes)</summary>
        public float SdivEMA { get { return body.sdivEMA; } set { body.sdivEMA = value; } }
 
		/// <summary>maximum sdiv bid (all markets in this expiration)</summary>
        public float SdivLo { get { return body.sdivLo; } set { body.sdivLo = value; } }
 
		/// <summary>minimum sdiv ask (all markets in this expiration)</summary>
        public float SdivHi { get { return body.sdivHi; } set { body.sdivHi = value; } }
 
		/// <summary>atm max abs change (half-life ~ 1 minute)</summary>
        public float AtmMAC { get { return body.atmMAC; } set { body.atmMAC = value; } }
 
		/// <summary>cpr max abs change (half-life ~ 1 minute)</summary>
        public float CprMAC { get { return body.cprMAC; } set { body.cprMAC = value; } }
 
		/// <summary>Surface slope (dVol / dXAxis) @ ATM (x=0)</summary>
        public float Slope { get { return body.slope; } set { body.slope = value; } }
 
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
        public CallPut FitErrCP { get { return body.fitErrCP; } set { body.fitErrCP = value; } }
 
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
             
		/// <summary>overnight LiveSurfaceAtm used for surface</summary>
        public ExpiryKey SEKey { get { return CacheVar.AllocIfNull(ref sEKey).Get(ref body.sEKey, usn); } set { CacheVar.AllocIfNull(ref sEKey).Set(value); body.sEKey = value.Layout; } }
 
		
        public LiveSurfaceType SType { get { return body.sType; } set { body.sType = value; } }
 
		/// <summary>[date/time from LiveSurfaceAtm surface record]</summary>
        public DateTime STimestamp { get { return body.sTimestamp; } set { body.sTimestamp = value; } }
 
		/// <summary>message counter - number of surface fits today</summary>
        public int Counter { get { return body.counter; } set { body.counter = value; } }
 
		
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
	/// If you are selecting records from SRSE you should note that OptionImpliedQuoteAdj table is a proxy implementation of this table that automaticall applies the appropriate underlier adjustments as records are being returned.
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
			public FixedString16Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
 		private CachedFixedLengthString<FixedString16Layout> calcErr;
		

            
		
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
 
		/// <summary>last bid price change (milliseconds since midnight)</summary>
        public int BidTime { get { return body.bidTime; } set { body.bidTime = value; } }
 
		/// <summary>last ask price change (milliseconds since midnight)</summary>
        public int AskTime { get { return body.askTime; } set { body.askTime = value; } }
 
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
			public FixedString16Layout calcErr;
			public CalcSource calcSource;
			public DateTimeLayout timestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		private volatile int usn;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { ++usn; }
		
 		private CachedTickerKey ticker;
 		private CachedFixedLengthString<FixedString16Layout> calcErr;
		

            
		
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
 			
			public StkExch Exch
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)] get { return body.exch; }
				[MethodImpl(MethodImplOptions.AggressiveInlining)] set { body.exch = value; }
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
 			public StkExch exch;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(PKeyLayout other)
            {
                return	ticker.Equals(other.ticker) &&
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
					var hashCode = ticker.GetHashCode();
 					hashCode = (hashCode*397) ^ ((int) exch);

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
			public DateTimeLayout auctionTime;
			public AuctionReason auctionType;
			public BuySell imbalanceSide;
			public float continuousBookClrPx;
			public float closingOnlyClrPx;
			public float ssrFillingPx;
			public long netTimestamp;
		}

		// ReSharper disable once InconsistentNaming
		internal BodyLayout body;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Invalidate() { }
		
		


		/// <summary>The last sale if the last sale is at or between the current best quote.  Otherwise, it's the bid price if last sale is lower than bid price, or the offer price if last sale is higher than offer price.</summary>
        public float ReferencePx { get { return body.referencePx; } set { body.referencePx = value; } }
 
		/// <summary>Paired off quantity at the referencePx point.</summary>
        public int PairedQty { get { return body.pairedQty; } set { body.pairedQty = value; } }
 
		/// <summary>Total imbalance quantity at the referencePx point.</summary>
        public int TotalImbalanceQty { get { return body.totalImbalanceQty; } set { body.totalImbalanceQty = value; } }
 
		/// <summary>Total market order imbalance at the referencePx.</summary>
        public int MarketImbalanceQty { get { return body.marketImbalanceQty; } set { body.marketImbalanceQty = value; } }
 
		/// <summary>Auction time with seconds resolution in CST</summary>
        public DateTime AuctionTime { get { return body.auctionTime; } set { body.auctionTime = value; } }
 
		
        public AuctionReason AuctionType { get { return body.auctionType; } set { body.auctionType = value; } }
 
		/// <summary>Side of the imbalance.</summary>
        public BuySell ImbalanceSide { get { return body.imbalanceSide; } set { body.imbalanceSide = value; } }
 
		/// <summary>Price closest to last sale where imbalance is zero.</summary>
        public float ContinuousBookClrPx { get { return body.continuousBookClrPx; } set { body.continuousBookClrPx = value; } }
 
		/// <summary>Indicative price against closing only order only.</summary>
        public float ClosingOnlyClrPx { get { return body.closingOnlyClrPx; } set { body.closingOnlyClrPx = value; } }
 
		/// <summary>SSR Filling Price.  This price is the price at which sell short interest will be filed in the matching in the event a sell short restriction is in effect for the security.</summary>
        public float SsrFillingPx { get { return body.ssrFillingPx; } set { body.ssrFillingPx = value; } }
 
		/// <summary>PTP timestamp</summary>
        public long NetTimestamp { get { return body.netTimestamp; } set { body.netTimestamp = value; } }

		
		#endregion	

    } // StockExchImbalance


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
