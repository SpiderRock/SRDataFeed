// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Mbus;
using SpiderRock.SpiderStream.Mbus.Layouts;

namespace SpiderRock.SpiderStream;

/// <summary>
/// FutureBookQuote:2580
/// </summary>
/// <remarks>
	/// This table contains live future quote records from the listing exchange.  Each record contains up to four price levels and represents a live snapshot of the book for a specific future./// </remarks>

public partial class FutureBookQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FutureBookQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.FutureBookQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public ExpiryKey Fkey { get => ExpiryKey.GetCreateExpiryKey(body.fkey); set => body.fkey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = fkey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public UpdateType updateType;
		public MarketStatus marketStatus;
		public double bidPrice1;
		public double askPrice1;
		public int bidSize1;
		public int askSize1;
		public ushort bidOrders1;
		public ushort askOrders1;
		public double bidPrice2;
		public double askPrice2;
		public int bidSize2;
		public int askSize2;
		public ushort bidOrders2;
		public ushort askOrders2;
		public double bidPrice3;
		public double askPrice3;
		public int bidSize3;
		public int askSize3;
		public ushort bidOrders3;
		public ushort askOrders3;
		public double bidPrice4;
		public double askPrice4;
		public int bidSize4;
		public int askSize4;
		public ushort bidOrders4;
		public ushort askOrders4;
		public long srcTimestamp;
		public long netTimestamp;
    }

    internal BodyLayout body;

    
    public UpdateType UpdateType { get => body.updateType; set => body.updateType = value; }
     /// <summary>market status (open, halted, etc)</summary>
    public MarketStatus MarketStatus { get => body.marketStatus; set => body.marketStatus = value; }
     /// <summary>bid price</summary>
    public double BidPrice1 { get => body.bidPrice1; set => body.bidPrice1 = value; }
     /// <summary>ask price</summary>
    public double AskPrice1 { get => body.askPrice1; set => body.askPrice1 = value; }
     /// <summary>bid size in contracts</summary>
    public int BidSize1 { get => body.bidSize1; set => body.bidSize1 = value; }
     /// <summary>ask size in contracts</summary>
    public int AskSize1 { get => body.askSize1; set => body.askSize1 = value; }
     /// <summary>number of participating orders at the bid price</summary>
    public ushort BidOrders1 { get => body.bidOrders1; set => body.bidOrders1 = value; }
     /// <summary>number of participating orders at the ask price</summary>
    public ushort AskOrders1 { get => body.askOrders1; set => body.askOrders1 = value; }
     /// <summary>bid price</summary>
    public double BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>ask price</summary>
    public double AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>bid size in contracts</summary>
    public int BidSize2 { get => body.bidSize2; set => body.bidSize2 = value; }
     /// <summary>ask size in contracts</summary>
    public int AskSize2 { get => body.askSize2; set => body.askSize2 = value; }
     /// <summary>number of participating orders at the bid price</summary>
    public ushort BidOrders2 { get => body.bidOrders2; set => body.bidOrders2 = value; }
     /// <summary>number of participating orders at the ask price</summary>
    public ushort AskOrders2 { get => body.askOrders2; set => body.askOrders2 = value; }
     /// <summary>bid price</summary>
    public double BidPrice3 { get => body.bidPrice3; set => body.bidPrice3 = value; }
     /// <summary>ask price</summary>
    public double AskPrice3 { get => body.askPrice3; set => body.askPrice3 = value; }
     /// <summary>bid size in contracts</summary>
    public int BidSize3 { get => body.bidSize3; set => body.bidSize3 = value; }
     /// <summary>ask size in contracts</summary>
    public int AskSize3 { get => body.askSize3; set => body.askSize3 = value; }
     /// <summary>number of participating orders at the bid price</summary>
    public ushort BidOrders3 { get => body.bidOrders3; set => body.bidOrders3 = value; }
     /// <summary>number of participating orders at the ask price</summary>
    public ushort AskOrders3 { get => body.askOrders3; set => body.askOrders3 = value; }
     /// <summary>bid price</summary>
    public double BidPrice4 { get => body.bidPrice4; set => body.bidPrice4 = value; }
     /// <summary>ask price</summary>
    public double AskPrice4 { get => body.askPrice4; set => body.askPrice4 = value; }
     /// <summary>bid size in contracts</summary>
    public int BidSize4 { get => body.bidSize4; set => body.bidSize4 = value; }
     /// <summary>ask size in contracts</summary>
    public int AskSize4 { get => body.askSize4; set => body.askSize4 = value; }
     /// <summary>number of participating orders at the bid price</summary>
    public ushort BidOrders4 { get => body.bidOrders4; set => body.bidOrders4 = value; }
     /// <summary>number of participating orders at the ask price</summary>
    public ushort AskOrders4 { get => body.askOrders4; set => body.askOrders4 = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }


} // FutureBookQuote


/// <summary>
/// FuturePrint:2595
/// </summary>
/// <remarks>
	/// The most recent (last) print record for each active futures market./// </remarks>

public partial class FuturePrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FuturePrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.FuturePrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public ExpiryKey Fkey { get => ExpiryKey.GetCreateExpiryKey(body.fkey); set => body.fkey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = fkey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
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
		public int bsz;
		public int asz;
		public float age;
		public PrtSide prtSide;
		public long prtTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>print exchange</summary>
    public FutExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size [contracts]</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price</summary>
    public double PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>incremental print cluster counter (one counter per fkey; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (sequence of prints @ same or better price with less than 25 ms elapsing since first print)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>print type [exchange specific]</summary>
    public byte PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>number of orders participating in this print</summary>
    public ushort PrtOrders { get => body.prtOrders; set => body.prtOrders = value; }
     /// <summary>cumulative (electronic) print size at current price level</summary>
    public int PrtQuan { get => body.prtQuan; set => body.prtQuan = value; }
     /// <summary>cumulative day (electronic) print volume in contracts</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>exchange bid (@ print time)</summary>
    public float Bid { get => body.bid; set => body.bid = value; }
     /// <summary>exchange ask (@ print time)</summary>
    public float Ask { get => body.ask; set => body.ask = value; }
     /// <summary>cumulative bid size (@ print time)</summary>
    public int Bsz { get => body.bsz; set => body.bsz = value; }
     /// <summary>cumulative ask size (@ print time)</summary>
    public int Asz { get => body.asz; set => body.asz = value; }
     /// <summary>age of prevailing quote at time of print</summary>
    public float Age { get => body.age; set => body.age = value; }
     /// <summary>implied print side (from bid/ask)</summary>
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long PrtTimestamp { get => body.prtTimestamp; set => body.prtTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // FuturePrint


/// <summary>
/// FuturePrintMarkup:2605
/// </summary>
/// <remarks>
	/// FuturePrintMarkup records are created for all future prints/// </remarks>

public partial class FuturePrintMarkup : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public FuturePrintMarkup()
    {
    }
    
    public FuturePrintMarkup(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public FuturePrintMarkup(FuturePrintMarkup source)
    {
        source.CopyTo(this);
    }
    
    internal FuturePrintMarkup(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as FuturePrintMarkup);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FuturePrintMarkup other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(FuturePrintMarkup target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.FuturePrintMarkup};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public ExpiryKey Fkey { get => ExpiryKey.GetCreateExpiryKey(body.fkey); set => body.fkey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = fkey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public long prtNumber;
		public TickerKeyLayout ticker;
		public FutExch prtExch;
		public int prtSize;
		public double prtPrice;
		public byte prtType;
		public ushort prtOrders;
		public int prtClusterNum;
		public int prtClusterSize;
		public int prtVolume;
		public PrtSide prtSide;
		public double bidPrice;
		public double askPrice;
		public int bidSize;
		public int askSize;
		public double bidPrice2;
		public double askPrice2;
		public int bidSize2;
		public int askSize2;
		public long srcTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>Unique print set identifier; will increment but not guaranteed to be sequential.</summary>
    public long PrtNumber { get => body.prtNumber; set => body.prtNumber = value; }
     /// <summary>underlying stock key</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>print exchange</summary>
    public FutExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size [contracts]</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price</summary>
    public double PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>print type [exchange specific]</summary>
    public byte PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>number of orders participating in this print</summary>
    public ushort PrtOrders { get => body.prtOrders; set => body.prtOrders = value; }
     /// <summary>incremental print cluster counter (one counter per fkey; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>cumulative day (electronic) print volume in contracts</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>Print side: None; Mid; Bid; Ask</summary>
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>exch best bid @ print arrival time</summary>
    public double BidPrice { get => body.bidPrice; set => body.bidPrice = value; }
     /// <summary>exch best ask @ print arrival time</summary>
    public double AskPrice { get => body.askPrice; set => body.askPrice = value; }
     /// <summary>bid size @ print arrival time</summary>
    public int BidSize { get => body.bidSize; set => body.bidSize = value; }
     /// <summary>ask size @ print arrival time</summary>
    public int AskSize { get => body.askSize; set => body.askSize = value; }
     /// <summary>exch 2nd best bid @ print arrival time</summary>
    public double BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>exch 2nd best ask @ print arrival time</summary>
    public double AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>2nd best bid @ print arrival time</summary>
    public int BidSize2 { get => body.bidSize2; set => body.bidSize2 = value; }
     /// <summary>2nd best ask @ print arrival time</summary>
    public int AskSize2 { get => body.askSize2; set => body.askSize2 = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound print packet PTP timestamp from SR gateway switch</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // FuturePrintMarkup


/// <summary>
/// IndexQuote:2675
/// </summary>
/// <remarks>
	/// Live index levels and quotes including SpiderRock synthetic index levels and quotes./// </remarks>

public partial class IndexQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(IndexQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.IndexQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
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

    internal BodyLayout body;

    /// <summary>price source of the quote (indication print or quote message)</summary>
    public IdxSrc PriceSource { get => body.priceSource; set => body.priceSource = value; }
     /// <summary>index bid value (if from quote, otherwise idxPrice)</summary>
    public double IdxBid { get => body.idxBid; set => body.idxBid = value; }
     /// <summary>index ask value (if from quote, otherwise idxPrice)</summary>
    public double IdxAsk { get => body.idxAsk; set => body.idxAsk = value; }
     /// <summary>index price</summary>
    public double IdxPrice { get => body.idxPrice; set => body.idxPrice = value; }
     /// <summary>index price timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // IndexQuote


/// <summary>
/// LiveImpliedQuote:1015
/// </summary>
/// <remarks>
	/// CalcSource=Tick records are computed and published each time an option NBBO price changes.  CalcSource=Loop records are computed in a 2-3 minute background loop.
	/// Note that the underlier price (uPrc) will be the same for all options an underlier when CalcSource=Loop.  This is not true for CalcSource=Tick where uPrc will be the underlier price that prevailed when the option price changed.
	/// If you are consuming multicast data and only want records with consistent uPrc values for all options you should ignore Tick records. Alternatively, you can use an independent underlier price source (our StockBookQuote feed or some other) and 'adjust' the values in this table to the new underlier value.
	/// If you are selecting records from SRSE you should note that OptionImpliedQuoteAdj table is a proxy implementation of this table that automatically applies the appropriate underlier adjustments as records are being returned./// </remarks>

public partial class LiveImpliedQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public LiveImpliedQuote()
    {
    }
    
    public LiveImpliedQuote(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public LiveImpliedQuote(LiveImpliedQuote source)
    {
        source.CopyTo(this);
    }
    
    internal LiveImpliedQuote(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as LiveImpliedQuote);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(LiveImpliedQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(LiveImpliedQuote target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.LiveImpliedQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TickerKeyLayout ticker;
		public float uPrc;
		public float uOff;
		public float years;
		public float xAxis;
		public float rate;
		public float sdiv;
		public float ddiv;
		public float oBid;
		public float oAsk;
		public float oBidIv;
		public float oAskIv;
		public float atmVol;
		public float sVol;
		public float sPrc;
		public float sMark;
		public float veSlope;
		public float de;
		public float ga;
		public float th;
		public float ve;
		public float va;
		public float vo;
		public float ro;
		public float ph;
		public float deDecay;
		public float up50;
		public float dn50;
		public float up15;
		public float dn15;
		public float up06;
		public float dn08;
		public ImpliedQuoteError calcErr;
		public CalcSource calcSource;
		public long srcTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>SR Ticker that this option rolls up to</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>underlier price (usually mid-market)</summary>
    public float UPrc { get => body.uPrc; set => body.uPrc = value; }
     /// <summary>implied underlier price offset (if any)</summary>
    public float UOff { get => body.uOff; set => body.uOff = value; }
     /// <summary>years to expiration</summary>
    public float Years { get => body.years; set => body.years = value; }
     /// <summary>option moneyness</summary>
    public float XAxis { get => body.xAxis; set => body.xAxis = value; }
     /// <summary>discount rate</summary>
    public float Rate { get => body.rate; set => body.rate = value; }
     /// <summary>sdiv (continuous stock dividend) rate</summary>
    public float Sdiv { get => body.sdiv; set => body.sdiv = value; }
     /// <summary>cumulative discrete dividend value</summary>
    public float Ddiv { get => body.ddiv; set => body.ddiv = value; }
     /// <summary>option bid price</summary>
    public float OBid { get => body.oBid; set => body.oBid = value; }
     /// <summary>option ask price</summary>
    public float OAsk { get => body.oAsk; set => body.oAsk = value; }
     /// <summary>volatility implied by option bid price</summary>
    public float OBidIv { get => body.oBidIv; set => body.oBidIv = value; }
     /// <summary>volatility implied by option ask price</summary>
    public float OAskIv { get => body.oAskIv; set => body.oAskIv = value; }
     /// <summary>option atm volatility (from SR surface)</summary>
    public float AtmVol { get => body.atmVol; set => body.atmVol = value; }
     /// <summary>option surface volatility (SR surface fit model)</summary>
    public float SVol { get => body.sVol; set => body.sVol = value; }
     /// <summary>option surface price; ie. PRICE(sVol, uPrc + uOff, years, rate, sDiv, {discrete dividends, if any})</summary>
    public float SPrc { get => body.sPrc; set => body.sPrc = value; }
     /// <summary>option surface mark (option surface price w/bounding rules; always between bid/ask)</summary>
    public float SMark { get => body.sMark; set => body.sMark = value; }
     /// <summary>veSlope = dVol / dUprc (assuming vol @ xAxis = 0 remains constant); hedgeDelta = (de + ve * 100 * veSlope) if hedging with this assumption</summary>
    public float VeSlope { get => body.veSlope; set => body.veSlope = value; }
     /// <summary>option delta</summary>
    public float De { get => body.de; set => body.de = value; }
     /// <summary>option gamma</summary>
    public float Ga { get => body.ga; set => body.ga = value; }
     /// <summary>option theta</summary>
    public float Th { get => body.th; set => body.th = value; }
     /// <summary>option vega</summary>
    public float Ve { get => body.ve; set => body.ve = value; }
     /// <summary>option vanna</summary>
    public float Va { get => body.va; set => body.va = value; }
     /// <summary>option volga</summary>
    public float Vo { get => body.vo; set => body.vo = value; }
     /// <summary>option rho</summary>
    public float Ro { get => body.ro; set => body.ro = value; }
     /// <summary>option phi</summary>
    public float Ph { get => body.ph; set => body.ph = value; }
     /// <summary>option delta decay</summary>
    public float DeDecay { get => body.deDecay; set => body.deDecay = value; }
     /// <summary>underlier up 50% slide</summary>
    public float Up50 { get => body.up50; set => body.up50 = value; }
     /// <summary>underlier dn 50% slide</summary>
    public float Dn50 { get => body.dn50; set => body.dn50 = value; }
     /// <summary>underlier up 15% slide</summary>
    public float Up15 { get => body.up15; set => body.up15 = value; }
     /// <summary>underlier dn 15% slide</summary>
    public float Dn15 { get => body.dn15; set => body.dn15 = value; }
     /// <summary>underlier up 6% slide</summary>
    public float Up06 { get => body.up06; set => body.up06 = value; }
     /// <summary>underlier dn 8% slide</summary>
    public float Dn08 { get => body.dn08; set => body.dn08 = value; }
     /// <summary>option pricing calculation error (if any)</summary>
    public ImpliedQuoteError CalcErr { get => body.calcErr; set => body.calcErr = value; }
     
    public CalcSource CalcSource { get => body.calcSource; set => body.calcSource = value; }
     /// <summary>OPRA source timestamp (nanoseconds since epoch); will be zero if calcSource != Tick</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>SR timestamp @ publish time</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // LiveImpliedQuote


/// <summary>
/// LiveSurfaceAtm:1030
/// </summary>
/// <remarks>
/// </remarks>

public partial class LiveSurfaceAtm : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(LiveSurfaceAtm other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.LiveSurfaceAtm};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public ExpiryKey Ekey { get => ExpiryKey.GetCreateExpiryKey(body.ekey); set => body.ekey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public ExpiryKeyLayout ekey;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	ekey.Equals(other.ekey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ekey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
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
		public PriceQuoteType priceQuoteType;
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
		public float atmPhi;
		public float atmVega;
		public float slope;
		public float varSwapFV;
		public GridType gridType;
		public float minXAxis;
		public float maxXAxis;
		public float minCurvValue;
		public float minCurvXAxis;
		public float maxCurvValue;
		public float maxCurvXAxis;
		public float skewMinX;
		public float skewMinY;
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
		public float fitErrDe;
		public float fitErrBid;
		public float fitErrAsk;
		public float fitErrPrc;
		public float fitErrVol;
		public int counter;
		public int skewCounter;
		public int sdivCounter;
		public MarketSession marketSession;
		public TradeableStatus tradeableStatus;
		public SurfaceResult surfaceResult;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>underlying stock key that this option expiration attaches to</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>future that this option expiration month written on (if any)</summary>
    public ExpiryKey Fkey { get => ExpiryKey.GetCreateExpiryKey(body.fkey); set => body.fkey = value.Layout; }
     /// <summary>underlier bid price</summary>
    public float UBid { get => body.uBid; set => body.uBid = value; }
     /// <summary>underlier ask price</summary>
    public float UAsk { get => body.uAsk; set => body.uAsk = value; }
     /// <summary>time to expiration (in years)</summary>
    public float Years { get => body.years; set => body.years = value; }
     /// <summary>interest rate</summary>
    public float Rate { get => body.rate; set => body.rate = value; }
     /// <summary>present value of discrete dividend stream</summary>
    public float Ddiv { get => body.ddiv; set => body.ddiv = value; }
     /// <summary>exercise type of the options used to compute this surface</summary>
    public byte ExType { get => body.exType; set => body.exType = value; }
     /// <summary>option pricing model used for price calcs</summary>
    public byte ModelType { get => body.modelType; set => body.modelType = value; }
     /// <summary>number of qualifying earnings events prior to expiration [can be fractional] (from StockEarningsCalendar)</summary>
    public float EarnCnt { get => body.earnCnt; set => body.earnCnt = value; }
     /// <summary>number of qualifying earnings events prior to expiration [adjusted] (from StockEarningsCalendar + LiveSurfaceTerm)</summary>
    public float EarnCntAdj { get => body.earnCntAdj; set => body.earnCntAdj = value; }
     /// <summary>axis volatility x sqrt(years) (used to compute xAxis) [usually 4m atm vol]</summary>
    public float AxisVolRT { get => body.axisVolRT; set => body.axisVolRT = value; }
     /// <summary>axis FwdUPrc (fwd underlying price used to compute xAxis)</summary>
    public float AxisFUPrc { get => body.axisFUPrc; set => body.axisFUPrc = value; }
     /// <summary>moneyness (xAxis) convention</summary>
    public MoneynessType MoneynessType { get => body.moneynessType; set => body.moneynessType = value; }
     /// <summary>underlier pricing mode (None=use spot/stock market; FrontMonth=use front month future market + uPrcOffset; Actual = use actual underlier future market)</summary>
    public UnderlierMode UnderlierMode { get => body.underlierMode; set => body.underlierMode = value; }
     /// <summary>Price or Vol</summary>
    public PriceQuoteType PriceQuoteType { get => body.priceQuoteType; set => body.priceQuoteType = value; }
     /// <summary>atm vol (xAxis = 0)</summary>
    public float AtmVol { get => body.atmVol; set => body.atmVol = value; }
     /// <summary>atm vol (xAxis = 0) (eMove/earnCntAdj censored)</summary>
    public float AtmCen { get => body.atmCen; set => body.atmCen = value; }
     /// <summary>historical realized volatility (includes eMoveHist x earnCntAdj adjustment).  Note that this is the default atmVol if no implied markets existed previous day.</summary>
    public float AtmVolHist { get => body.atmVolHist; set => body.atmVolHist = value; }
     /// <summary>censored (earnings events removed) historical realized volatility.  Trailing periods is 2x forward time to expiration.  From HistoricalVolatility(windowType=hlCen).mv_nnn</summary>
    public float AtmCenHist { get => body.atmCenHist; set => body.atmCenHist = value; }
     /// <summary>minimum estimated atm vol</summary>
    public float MinAtmVol { get => body.minAtmVol; set => body.minAtmVol = value; }
     /// <summary>maximum estimated atm vol</summary>
    public float MaxAtmVol { get => body.maxAtmVol; set => body.maxAtmVol = value; }
     /// <summary>minimum CP adjust value (sdiv or uPrcOffset)</summary>
    public float MinCPAdjVal { get => body.minCPAdjVal; set => body.minCPAdjVal = value; }
     /// <summary>maximum CP adjust value (sdiv or uPrcOffset)</summary>
    public float MaxCPAdjVal { get => body.maxCPAdjVal; set => body.maxCPAdjVal = value; }
     /// <summary>implied earnings move (from LiveSurfaceTerm)</summary>
    public float EMove { get => body.eMove; set => body.eMove = value; }
     /// <summary>historical earnings move (avg of trailing 8 moves). From StockEarningsCalendar.eMoveHist</summary>
    public float EMoveHist { get => body.eMoveHist; set => body.eMoveHist = value; }
     /// <summary>implied offset for use when fkey is not the natural underlier for this option expiry</summary>
    public float UPrcOffset { get => body.uPrcOffset; set => body.uPrcOffset = value; }
     /// <summary>time smoothed implied uPrcOffset (half-live ~ 20 seconds)</summary>
    public float UPrcOffsetEMA { get => body.uPrcOffsetEMA; set => body.uPrcOffsetEMA = value; }
     /// <summary>stock dividend (borrow rate)</summary>
    public float Sdiv { get => body.sdiv; set => body.sdiv = value; }
     /// <summary>sdiv exp moving average (10 minutes)</summary>
    public float SdivEMA { get => body.sdivEMA; set => body.sdivEMA = value; }
     /// <summary>fixed strike atm move from prior period</summary>
    public float AtmMove { get => body.atmMove; set => body.atmMove = value; }
     /// <summary>fixed strike atm (censored) move from prior period</summary>
    public float AtmCenMove { get => body.atmCenMove; set => body.atmCenMove = value; }
     /// <summary>surface phi @ xAxis = 0</summary>
    public float AtmPhi { get => body.atmPhi; set => body.atmPhi = value; }
     /// <summary>surface vega @ xAxis = 0</summary>
    public float AtmVega { get => body.atmVega; set => body.atmVega = value; }
     /// <summary>volatility surface slope (dVol / dXAxis) @ ATM (xAxis=0)</summary>
    public float Slope { get => body.slope; set => body.slope = value; }
     /// <summary>variance swap fair value (estimated by numerical integration over OTM price surface)</summary>
    public float VarSwapFV { get => body.varSwapFV; set => body.varSwapFV = value; }
     /// <summary>gridType defines D11 - U12 xAxis points + spline type</summary>
    public GridType GridType { get => body.gridType; set => body.gridType = value; }
     /// <summary>minimum xAxis value; xAxis values to the left extrapolate horizontally</summary>
    public float MinXAxis { get => body.minXAxis; set => body.minXAxis = value; }
     /// <summary>maximum xAxis value; xAxis values to the right extrapolate horizontally</summary>
    public float MaxXAxis { get => body.maxXAxis; set => body.maxXAxis = value; }
     /// <summary>minimum curvature (2nd derivative) of skew curve (can be negative if curve is not strictly convex)</summary>
    public float MinCurvValue { get => body.minCurvValue; set => body.minCurvValue = value; }
     /// <summary>xAxis of minimum curvature point</summary>
    public float MinCurvXAxis { get => body.minCurvXAxis; set => body.minCurvXAxis = value; }
     /// <summary>maximum curvature (2nd derivative) of skew curve</summary>
    public float MaxCurvValue { get => body.maxCurvValue; set => body.maxCurvValue = value; }
     /// <summary>xAxis of maximum curvature point</summary>
    public float MaxCurvXAxis { get => body.maxCurvXAxis; set => body.maxCurvXAxis = value; }
     /// <summary>xAxis = (effStrike / effAxisFUPrc - 1.0) / axisVolRT; effStrike = strike * strikeRatio; effAxisFUPrc = axisFUPrc * symbolRatio</summary>
    public float SkewMinX { get => body.skewMinX; set => body.skewMinX = value; }
     /// <summary>skewMinX / skewMinY are the skew curve minimum point (usually a positive x value and a negative y value)</summary>
    public float SkewMinY { get => body.skewMinY; set => body.skewMinY = value; }
     /// <summary>skew @ D11 point (volatility skew curve)</summary>
    public float SkewD11 { get => body.skewD11; set => body.skewD11 = value; }
     /// <summary>skew @ D10 point</summary>
    public float SkewD10 { get => body.skewD10; set => body.skewD10 = value; }
     /// <summary>skew @ D9 point</summary>
    public float SkewD9 { get => body.skewD9; set => body.skewD9 = value; }
     /// <summary>skew @ D8 point</summary>
    public float SkewD8 { get => body.skewD8; set => body.skewD8 = value; }
     /// <summary>skew @ D7 point</summary>
    public float SkewD7 { get => body.skewD7; set => body.skewD7 = value; }
     /// <summary>skew @ D6 point</summary>
    public float SkewD6 { get => body.skewD6; set => body.skewD6 = value; }
     /// <summary>skew @ D5 point</summary>
    public float SkewD5 { get => body.skewD5; set => body.skewD5 = value; }
     /// <summary>skew @ D4 point</summary>
    public float SkewD4 { get => body.skewD4; set => body.skewD4 = value; }
     /// <summary>skew @ D3 point</summary>
    public float SkewD3 { get => body.skewD3; set => body.skewD3 = value; }
     /// <summary>skew @ D2 point</summary>
    public float SkewD2 { get => body.skewD2; set => body.skewD2 = value; }
     /// <summary>skew @ D1 point</summary>
    public float SkewD1 { get => body.skewD1; set => body.skewD1 = value; }
     /// <summary>central value (@xAxis = 0) [usually zero]</summary>
    public float SkewC0 { get => body.skewC0; set => body.skewC0 = value; }
     /// <summary>skew @ U1 point</summary>
    public float SkewU1 { get => body.skewU1; set => body.skewU1 = value; }
     /// <summary>skew @ U2 point</summary>
    public float SkewU2 { get => body.skewU2; set => body.skewU2 = value; }
     /// <summary>skew @ U3 point</summary>
    public float SkewU3 { get => body.skewU3; set => body.skewU3 = value; }
     /// <summary>skew @ U4 point</summary>
    public float SkewU4 { get => body.skewU4; set => body.skewU4 = value; }
     /// <summary>skew @ U5 point</summary>
    public float SkewU5 { get => body.skewU5; set => body.skewU5 = value; }
     /// <summary>skew @ U6 point</summary>
    public float SkewU6 { get => body.skewU6; set => body.skewU6 = value; }
     /// <summary>skew @ U7 point</summary>
    public float SkewU7 { get => body.skewU7; set => body.skewU7 = value; }
     /// <summary>skew @ U8 point</summary>
    public float SkewU8 { get => body.skewU8; set => body.skewU8 = value; }
     /// <summary>skew @ U9 point</summary>
    public float SkewU9 { get => body.skewU9; set => body.skewU9 = value; }
     /// <summary>skew @ U10 point</summary>
    public float SkewU10 { get => body.skewU10; set => body.skewU10 = value; }
     /// <summary>skew @ U11 point</summary>
    public float SkewU11 { get => body.skewU11; set => body.skewU11 = value; }
     /// <summary>sdiv @ D3 point</summary>
    public float SdivD3 { get => body.sdivD3; set => body.sdivD3 = value; }
     /// <summary>sdiv @ D2 point</summary>
    public float SdivD2 { get => body.sdivD2; set => body.sdivD2 = value; }
     /// <summary>sdiv @ D1 point</summary>
    public float SdivD1 { get => body.sdivD1; set => body.sdivD1 = value; }
     /// <summary>sdiv @ U1 point</summary>
    public float SdivU1 { get => body.sdivU1; set => body.sdivU1 = value; }
     /// <summary>sdiv @ U2 point</summary>
    public float SdivU2 { get => body.sdivU2; set => body.sdivU2 = value; }
     /// <summary>sdiv @ U3 point</summary>
    public float SdivU3 { get => body.sdivU3; set => body.sdivU3 = value; }
     /// <summary>minimum mkt premium width</summary>
    public float Pwidth { get => body.pwidth; set => body.pwidth = value; }
     /// <summary>minimum mkt volatility width</summary>
    public float Vwidth { get => body.vwidth; set => body.vwidth = value; }
     /// <summary>num call strikes</summary>
    public byte CCnt { get => body.cCnt; set => body.cCnt = value; }
     /// <summary>num put strikes</summary>
    public byte PCnt { get => body.pCnt; set => body.pCnt = value; }
     /// <summary>number of call bid violations (surface outside the market)</summary>
    public byte CBidMiss { get => body.cBidMiss; set => body.cBidMiss = value; }
     /// <summary>number of call ask violations (surface outside the market)</summary>
    public byte CAskMiss { get => body.cAskMiss; set => body.cAskMiss = value; }
     /// <summary>number of put bid violations</summary>
    public byte PBidMiss { get => body.pBidMiss; set => body.pBidMiss = value; }
     /// <summary>number of put ask violations</summary>
    public byte PAskMiss { get => body.pAskMiss; set => body.pAskMiss = value; }
     /// <summary>surface fit R2 (mid-market values)</summary>
    public float FitAvgErr { get => body.fitAvgErr; set => body.fitAvgErr = value; }
     /// <summary>mean square error (mid-market values)</summary>
    public float FitAvgAbsErr { get => body.fitAvgAbsErr; set => body.fitAvgAbsErr = value; }
     /// <summary>worst case surface premium violation</summary>
    public float FitMaxPrcErr { get => body.fitMaxPrcErr; set => body.fitMaxPrcErr = value; }
     /// <summary>okey_xx of the option with the largest fit error in this expiration</summary>
    public float FitErrXX { get => body.fitErrXX; set => body.fitErrXX = value; }
     /// <summary>okey_cp of the option with the largest fit error in this expiration</summary>
    public CallPut FitErrCP { get => body.fitErrCP; set => body.fitErrCP = value; }
     /// <summary>delta of fixErrXX</summary>
    public float FitErrDe { get => body.fitErrDe; set => body.fitErrDe = value; }
     /// <summary>bid of the option with the largest fit error</summary>
    public float FitErrBid { get => body.fitErrBid; set => body.fitErrBid = value; }
     /// <summary>ask of the option with the largest fit error</summary>
    public float FitErrAsk { get => body.fitErrAsk; set => body.fitErrAsk = value; }
     /// <summary>surface prc of the option with the largest fit error</summary>
    public float FitErrPrc { get => body.fitErrPrc; set => body.fitErrPrc = value; }
     /// <summary>surface vol of the option with the largest fit error</summary>
    public float FitErrVol { get => body.fitErrVol; set => body.fitErrVol = value; }
     /// <summary>message counter - number of surface fits today</summary>
    public int Counter { get => body.counter; set => body.counter = value; }
     /// <summary>skew surface fit counter</summary>
    public int SkewCounter { get => body.skewCounter; set => body.skewCounter = value; }
     /// <summary>sdiv surface fit counter</summary>
    public int SdivCounter { get => body.sdivCounter; set => body.sdivCounter = value; }
     /// <summary>market session this surface is from</summary>
    public MarketSession MarketSession { get => body.marketSession; set => body.marketSession = value; }
     /// <summary>indicates whether the surface is currently tradeable or not (all server surface integrity checks pass)</summary>
    public TradeableStatus TradeableStatus { get => body.tradeableStatus; set => body.tradeableStatus = value; }
     
    public SurfaceResult SurfaceResult { get => body.surfaceResult; set => body.surfaceResult = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // LiveSurfaceAtm


/// <summary>
/// OptionCloseMark:3140
/// </summary>
/// <remarks>
/// </remarks>

public partial class OptionCloseMark : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionCloseMark other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionCloseMark};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public DateKeyLayout tradeDate;
		public ClsMarkState clsMarkState;
		public double uBid;
		public double uAsk;
		public double uSrCls;
		public double uClose;
		public float bidPrc;
		public float askPrc;
		public double srClsPrc;
		public double closePrc;
		public YesNo hasSRClsPrc;
		public YesNo hasClosePrc;
		public float bidIV;
		public float askIV;
		public float srPrc;
		public float srVol;
		public MarkSource srSrc;
		public float de;
		public float ga;
		public float th;
		public float ve;
		public float vo;
		public float va;
		public float rh;
		public float ph;
		public float srSlope;
		public float deDecay;
		public float sdiv;
		public float ddiv;
		public float rate;
		public float years;
		public byte error;
		public int openInterest;
		public int prtCount;
		public int prtVolume;
		public DateTimeLayout srCloseMarkDttm;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public DateKey TradeDate { get => DateKey.GetCreateDateKey(body.tradeDate); set => body.tradeDate = value.Layout; }
     /// <summary>LastPrt = last print received; SRClose = SpiderRock snapshot; ExchClose = official exchange close price; Final = Final close mark</summary>
    public ClsMarkState ClsMarkState { get => body.clsMarkState; set => body.clsMarkState = value; }
     /// <summary>SpiderRock closing underlier bid (C - 1m)</summary>
    public double UBid { get => body.uBid; set => body.uBid = value; }
     /// <summary>SpiderRock closing underlier ask (C - 1m)</summary>
    public double UAsk { get => body.uAsk; set => body.uAsk = value; }
     /// <summary>SpiderRock underlier closing mark (C - 1m)</summary>
    public double USrCls { get => body.uSrCls; set => body.uSrCls = value; }
     /// <summary>exchange underlier closing mark</summary>
    public double UClose { get => body.uClose; set => body.uClose = value; }
     /// <summary>SpiderRock closing option bid (C - 1m)</summary>
    public float BidPrc { get => body.bidPrc; set => body.bidPrc = value; }
     /// <summary>SpiderRock closing option ask (C - 1m)</summary>
    public float AskPrc { get => body.askPrc; set => body.askPrc = value; }
     /// <summary>SpiderRock close mark (close - 1min)</summary>
    public double SrClsPrc { get => body.srClsPrc; set => body.srClsPrc = value; }
     /// <summary>official exchange closing mark (last print;then official close)</summary>
    public double ClosePrc { get => body.closePrc; set => body.closePrc = value; }
     
    public YesNo HasSRClsPrc { get => body.hasSRClsPrc; set => body.hasSRClsPrc = value; }
     
    public YesNo HasClosePrc { get => body.hasClosePrc; set => body.hasClosePrc = value; }
     /// <summary>implied vol of SpiderRock closing bid price (C - 1m)</summary>
    public float BidIV { get => body.bidIV; set => body.bidIV = value; }
     /// <summary>implied vol of SpiderRock closing ask price (C - 1m)</summary>
    public float AskIV { get => body.askIV; set => body.askIV = value; }
     /// <summary>SpiderRock surface price (always within bidPx/askPx) (C - 1m)</summary>
    public float SrPrc { get => body.srPrc; set => body.srPrc = value; }
     /// <summary>SpiderRock surface volatility (C - 1m)</summary>
    public float SrVol { get => body.srVol; set => body.srVol = value; }
     /// <summary>SpiderRock price source [NbboMid, SRVol, LoBound, HiBound, SRPricer, SRQuote, CloseMark]</summary>
    public MarkSource SrSrc { get => body.srSrc; set => body.srSrc = value; }
     /// <summary>delta (SR surface)</summary>
    public float De { get => body.de; set => body.de = value; }
     /// <summary>gamma (SR surface)</summary>
    public float Ga { get => body.ga; set => body.ga = value; }
     /// <summary>theta (SR surface)</summary>
    public float Th { get => body.th; set => body.th = value; }
     /// <summary>vega (SR surface)</summary>
    public float Ve { get => body.ve; set => body.ve = value; }
     /// <summary>volga (SR surface)</summary>
    public float Vo { get => body.vo; set => body.vo = value; }
     /// <summary>vanna (SR surface)</summary>
    public float Va { get => body.va; set => body.va = value; }
     /// <summary>rho (SR surrface)</summary>
    public float Rh { get => body.rh; set => body.rh = value; }
     /// <summary>phi (SR surface)</summary>
    public float Ph { get => body.ph; set => body.ph = value; }
     /// <summary>surface slope (SR surface)</summary>
    public float SrSlope { get => body.srSlope; set => body.srSlope = value; }
     /// <summary>delta decay (SR surface)</summary>
    public float DeDecay { get => body.deDecay; set => body.deDecay = value; }
     /// <summary>SpiderRock sdiv rate</summary>
    public float Sdiv { get => body.sdiv; set => body.sdiv = value; }
     /// <summary>SpiderRock ddiv rate (sum of discrete dividend amounts)</summary>
    public float Ddiv { get => body.ddiv; set => body.ddiv = value; }
     /// <summary>SpiderRock interest rate</summary>
    public float Rate { get => body.rate; set => body.rate = value; }
     /// <summary>years to expiration</summary>
    public float Years { get => body.years; set => body.years = value; }
     /// <summary>SpiderRock pricing library calculation error code</summary>
    public byte Error { get => body.error; set => body.error = value; }
     /// <summary>Open Interest</summary>
    public int OpenInterest { get => body.openInterest; set => body.openInterest = value; }
     /// <summary>print count</summary>
    public int PrtCount { get => body.prtCount; set => body.prtCount = value; }
     /// <summary>total printed volume</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>from MarketCloseQuote.srCloseMarkDttm</summary>
    public DateTime SrCloseMarkDttm { get => body.srCloseMarkDttm; set => body.srCloseMarkDttm = value; }
     /// <summary>record timestamp</summary>
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionCloseMark


/// <summary>
/// OptionExchOrder:2765
/// </summary>
/// <remarks>
/// </remarks>

public partial class OptionExchOrder : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionExchOrder()
    {
    }
    
    public OptionExchOrder(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionExchOrder(OptionExchOrder source)
    {
        source.CopyTo(this);
    }
    
    internal OptionExchOrder(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionExchOrder);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionExchOrder other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionExchOrder target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionExchOrder};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }
         
        public BuySell Side { get => body.side; set => body.side = value; }
         
        public OptExch Exch { get => body.exch; set => body.exch = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public OptionKeyLayout okey;
         public BuySell side;
         public OptExch exch;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	okey.Equals(other.okey) &&
					 	side.Equals(other.side) &&
					 	exch.Equals(other.exch);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) side);
                 hashCode = (hashCode*397) ^ ((int) exch);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public long exchOrderID;
		public int size;
		public double price;
		public int origOrderSize;
		public ExchOrderType orderType;
		public ExchOrderStatus orderStatus;
		public MarketQualifier marketQualifier;
		public ExecQualifier execQualifier;
		public TimeInForce timeInForce;
		public FirmType firmType;
		public PositionType positionType;
		public FixedString5Layout clearingFirm;
		public FixedString8Layout clearingAccnt;
		public FixedString16Layout otherDetail;
		public long srcTimestamp;
		public long netTimestamp;
		public long dgwTimestamp;
    }

    internal BodyLayout body;

    /// <summary>exchange assigned order ID (if any)</summary>
    public long ExchOrderID { get => body.exchOrderID; set => body.exchOrderID = value; }
     /// <summary>size available to trade</summary>
    public int Size { get => body.size; set => body.size = value; }
     
    public double Price { get => body.price; set => body.price = value; }
     /// <summary>original order size (if available)</summary>
    public int OrigOrderSize { get => body.origOrderSize; set => body.origOrderSize = value; }
     
    public ExchOrderType OrderType { get => body.orderType; set => body.orderType = value; }
     
    public ExchOrderStatus OrderStatus { get => body.orderStatus; set => body.orderStatus = value; }
     
    public MarketQualifier MarketQualifier { get => body.marketQualifier; set => body.marketQualifier = value; }
     
    public ExecQualifier ExecQualifier { get => body.execQualifier; set => body.execQualifier = value; }
     
    public TimeInForce TimeInForce { get => body.timeInForce; set => body.timeInForce = value; }
     
    public FirmType FirmType { get => body.firmType; set => body.firmType = value; }
     
    public PositionType PositionType { get => body.positionType; set => body.positionType = value; }
     
    public string ClearingFirm { get => body.clearingFirm; set => body.clearingFirm = value; }
     
    public string ClearingAccnt { get => body.clearingAccnt; set => body.clearingAccnt = value; }
     
    public string OtherDetail { get => body.otherDetail; set => body.otherDetail = value; }
     /// <summary>source (exch) high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>SpiderRock network PTP timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     /// <summary>SpiderRock data gateway timestamp</summary>
    public long DgwTimestamp { get => body.dgwTimestamp; set => body.dgwTimestamp = value; }


} // OptionExchOrder


/// <summary>
/// OptionExchPrint:2770
/// </summary>
/// <remarks>
/// </remarks>

public partial class OptionExchPrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionExchPrint()
    {
    }
    
    public OptionExchPrint(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionExchPrint(OptionExchPrint source)
    {
        source.CopyTo(this);
    }
    
    internal OptionExchPrint(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionExchPrint);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionExchPrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionExchPrint target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionExchPrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>SR Generated unique print ID</summary>
        public long SrPrintID { get => body.srPrintID; set => body.srPrintID = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public long srPrintID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	srPrintID.Equals(other.srPrintID);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = srPrintID.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public OptionKeyLayout okey;
		public OptExch exch;
		public long exchOrderID;
		public int prtSize;
		public double prtPrice;
		public ExchPrtType exchPrtType;
		public long srcTimestamp;
		public long netTimestamp;
		public long dgwTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }
     
    public OptExch Exch { get => body.exch; set => body.exch = value; }
     /// <summary>exchange assigned order ID (if any)</summary>
    public long ExchOrderID { get => body.exchOrderID; set => body.exchOrderID = value; }
     /// <summary>size available to trade</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     
    public double PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     
    public ExchPrtType ExchPrtType { get => body.exchPrtType; set => body.exchPrtType = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>SpiderRock network PTP timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     /// <summary>SpiderRock data gateway timestamp</summary>
    public long DgwTimestamp { get => body.dgwTimestamp; set => body.dgwTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionExchPrint


/// <summary>
/// OptionMarketSummary:2780
/// </summary>
/// <remarks>
	/// These records represent live market summary snapshots for each active option/// </remarks>

public partial class OptionMarketSummary : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionMarketSummary()
    {
    }
    
    public OptionMarketSummary(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionMarketSummary(OptionMarketSummary source)
    {
        source.CopyTo(this);
    }
    
    internal OptionMarketSummary(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionMarketSummary);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionMarketSummary other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionMarketSummary target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionMarketSummary};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public double opnPrice;
		public double opnVolatility;
		public double clsPrice;
		public double clsVolatility;
		public double minPrtPrc;
		public double minPrtVol;
		public double maxPrtPrc;
		public double maxPrtVol;
		public int openInterest;
		public int bidCount;
		public int bidVolume;
		public int askCount;
		public int askVolume;
		public int midCount;
		public int midVolume;
		public int prtCount;
		public double lastPrtPrice;
		public float lastPrtVolatility;
		public double avgWidth;
		public float avgBidSize;
		public float avgAskSize;
		public DateTimeLayout lastPrint;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>start of day (SR) open mark</summary>
    public double OpnPrice { get => body.opnPrice; set => body.opnPrice = value; }
     /// <summary>start of day (SR) open mark (volatility)</summary>
    public double OpnVolatility { get => body.opnVolatility; set => body.opnVolatility = value; }
     /// <summary>end of day (SR) close mark</summary>
    public double ClsPrice { get => body.clsPrice; set => body.clsPrice = value; }
     /// <summary>end of day (SR) close mark (volatility)</summary>
    public double ClsVolatility { get => body.clsVolatility; set => body.clsVolatility = value; }
     /// <summary>minimum print price within market hours</summary>
    public double MinPrtPrc { get => body.minPrtPrc; set => body.minPrtPrc = value; }
     /// <summary>minimum print volatility within market hours</summary>
    public double MinPrtVol { get => body.minPrtVol; set => body.minPrtVol = value; }
     /// <summary>maximum print price within market hours</summary>
    public double MaxPrtPrc { get => body.maxPrtPrc; set => body.maxPrtPrc = value; }
     /// <summary>maximum print volatility within market hours</summary>
    public double MaxPrtVol { get => body.maxPrtVol; set => body.maxPrtVol = value; }
     
    public int OpenInterest { get => body.openInterest; set => body.openInterest = value; }
     /// <summary>num prints &lt;= SR surface mark</summary>
    public int BidCount { get => body.bidCount; set => body.bidCount = value; }
     /// <summary>volume when prtPrice &lt;= quote.bid</summary>
    public int BidVolume { get => body.bidVolume; set => body.bidVolume = value; }
     /// <summary>num prints &gt;= SR surface mark</summary>
    public int AskCount { get => body.askCount; set => body.askCount = value; }
     /// <summary>volume when prtPrice &gt;= quote.ask</summary>
    public int AskVolume { get => body.askVolume; set => body.askVolume = value; }
     /// <summary>num prints inside quote.ebid / quote.eask</summary>
    public int MidCount { get => body.midCount; set => body.midCount = value; }
     /// <summary>volume inside quote.ebid / quote.eask</summary>
    public int MidVolume { get => body.midVolume; set => body.midVolume = value; }
     /// <summary>number of distinct print reports</summary>
    public int PrtCount { get => body.prtCount; set => body.prtCount = value; }
     /// <summary>last print price</summary>
    public double LastPrtPrice { get => body.lastPrtPrice; set => body.lastPrtPrice = value; }
     /// <summary>last print volatility</summary>
    public float LastPrtVolatility { get => body.lastPrtVolatility; set => body.lastPrtVolatility = value; }
     /// <summary>average market width (time weighted)</summary>
    public double AvgWidth { get => body.avgWidth; set => body.avgWidth = value; }
     /// <summary>average bid size (time weighted)</summary>
    public float AvgBidSize { get => body.avgBidSize; set => body.avgBidSize = value; }
     /// <summary>average ask size (time weighted)</summary>
    public float AvgAskSize { get => body.avgAskSize; set => body.avgAskSize = value; }
     
    public DateTime LastPrint { get => body.lastPrint; set => body.lastPrint = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionMarketSummary


/// <summary>
/// OptionNbboQuote:2785
/// </summary>
/// <remarks>
	/// This table contains live option quote records from OPRA (equities) or the listing exchange (futures).  Each record contains up to two price levels and represents a live snapshot of the book for a specific option series.  There are typically 1mm+ records in this table if all ticker sources are enabled./// </remarks>

public partial class OptionNbboQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionNbboQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionNbboQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public UpdateType updateType;
		public float bidPrice;
		public float askPrice;
		public int bidSize;
		public int askSize;
		public int cumBidSize;
		public int cumAskSize;
		public OptExch bidExch;
		public OptExch askExch;
		public uint bidMask;
		public uint askMask;
		public OpraMktType bidMktType;
		public OpraMktType askMktType;
		public float bidPrice2;
		public float askPrice2;
		public int cumBidSize2;
		public int cumAskSize2;
		public int bidTime;
		public int askTime;
		public long srcTimestamp;
		public long netTimestamp;
    }

    internal BodyLayout body;

    
    public UpdateType UpdateType { get => body.updateType; set => body.updateType = value; }
     /// <summary>bid price</summary>
    public float BidPrice { get => body.bidPrice; set => body.bidPrice = value; }
     /// <summary>ask price</summary>
    public float AskPrice { get => body.askPrice; set => body.askPrice = value; }
     /// <summary>bid size in contracts (largest exch quote)</summary>
    public int BidSize { get => body.bidSize; set => body.bidSize = value; }
     /// <summary>ask size in contracts (largest exch quote)</summary>
    public int AskSize { get => body.askSize; set => body.askSize = value; }
     /// <summary>bid size in contracts (total nbbo size)</summary>
    public int CumBidSize { get => body.cumBidSize; set => body.cumBidSize = value; }
     /// <summary>ask size in contracts (total nbbo size)</summary>
    public int CumAskSize { get => body.cumAskSize; set => body.cumAskSize = value; }
     /// <summary>first (or largest remaining) exchange at bid price</summary>
    public OptExch BidExch { get => body.bidExch; set => body.bidExch = value; }
     /// <summary>first (or largest remaining) exchange at ask price</summary>
    public OptExch AskExch { get => body.askExch; set => body.askExch = value; }
     /// <summary>exchange bid bit mask</summary>
    public uint BidMask { get => body.bidMask; set => body.bidMask = value; }
     /// <summary>exchange ask bit mask</summary>
    public uint AskMask { get => body.askMask; set => body.askMask = value; }
     /// <summary>bid side quote flags (if any)</summary>
    public OpraMktType BidMktType { get => body.bidMktType; set => body.bidMktType = value; }
     /// <summary>ask side quote flags (if any)</summary>
    public OpraMktType AskMktType { get => body.askMktType; set => body.askMktType = value; }
     /// <summary>2nd best bid price</summary>
    public float BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>2nd best ask price</summary>
    public float AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int CumBidSize2 { get => body.cumBidSize2; set => body.cumBidSize2 = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int CumAskSize2 { get => body.cumAskSize2; set => body.cumAskSize2 = value; }
     /// <summary>last bid price change (milliseconds since midnight) calculated from the srcTimestamp</summary>
    public int BidTime { get => body.bidTime; set => body.bidTime = value; }
     /// <summary>last ask price change (milliseconds since midnight) calculated from the srcTimestamp</summary>
    public int AskTime { get => body.askTime; set => body.askTime = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }


} // OptionNbboQuote


/// <summary>
/// OptionOpenInterest:3230
/// </summary>
/// <remarks>
	/// Open interest for each option series. Records are from the live OPRA feed./// </remarks>

public partial class OptionOpenInterest : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionOpenInterest()
    {
    }
    
    public OptionOpenInterest(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionOpenInterest(OptionOpenInterest source)
    {
        source.CopyTo(this);
    }
    
    internal OptionOpenInterest(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionOpenInterest);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionOpenInterest other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionOpenInterest target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionOpenInterest};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public int openInt;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public int OpenInt { get => body.openInt; set => body.openInt = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionOpenInterest


/// <summary>
/// OptionPrint:2800
/// </summary>
/// <remarks>
	/// The most recent (last) print record for each active equity and future option series.  Quote markup represents quote that existed just prior to the print on the reporting exchange./// </remarks>

public partial class OptionPrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionPrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionPrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public OptExch prtExch;
		public int prtSize;
		public float prtPrice;
		public int prtClusterNum;
		public int prtClusterSize;
		public PrtType prtType;
		public ushort prtOrders;
		public int prtVolume;
		public int cxlVolume;
		public ushort bidCount;
		public ushort askCount;
		public int bidVolume;
		public int askVolume;
		public float ebid;
		public float eask;
		public int ebsz;
		public int easz;
		public float eage;
		public float bidPrice;
		public float askPrice;
		public float bidPrice2;
		public float askPrice2;
		public int bidSize;
		public int askSize;
		public int cumBidSize;
		public int cumAskSize;
		public int cumBidSize2;
		public int cumAskSize2;
		public uint bidMask;
		public uint askMask;
		public PrtSide prtSide;
		public long prtTimestamp;
		public long netTimestamp;
		public long oqNetTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public OptExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size [contracts]</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price</summary>
    public float PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>incremental print cluster counter (one counter per okey; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (sequence of prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>print type</summary>
    public PrtType PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>number of participating orders</summary>
    public ushort PrtOrders { get => body.prtOrders; set => body.prtOrders = value; }
     /// <summary>day print volume in contracts [this exchange]</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>day print/cancel volume (num of contracts printed and then cancelled)</summary>
    public int CxlVolume { get => body.cxlVolume; set => body.cxlVolume = value; }
     /// <summary>number of bid prints</summary>
    public ushort BidCount { get => body.bidCount; set => body.bidCount = value; }
     /// <summary>number of ask prints</summary>
    public ushort AskCount { get => body.askCount; set => body.askCount = value; }
     /// <summary>bid print volume in contracts</summary>
    public int BidVolume { get => body.bidVolume; set => body.bidVolume = value; }
     /// <summary>ask print volume in contracts</summary>
    public int AskVolume { get => body.askVolume; set => body.askVolume = value; }
     /// <summary>exchange bid (@ print time)</summary>
    public float Ebid { get => body.ebid; set => body.ebid = value; }
     /// <summary>exchange ask (@ print time)</summary>
    public float Eask { get => body.eask; set => body.eask = value; }
     /// <summary>exchange bid size</summary>
    public int Ebsz { get => body.ebsz; set => body.ebsz = value; }
     /// <summary>exchange ask size</summary>
    public int Easz { get => body.easz; set => body.easz = value; }
     /// <summary>age of prevailing quote at time of print</summary>
    public float Eage { get => body.eage; set => body.eage = value; }
     /// <summary>nbbo bid price (@ print time)</summary>
    public float BidPrice { get => body.bidPrice; set => body.bidPrice = value; }
     /// <summary>nbbo ask price (@ print time)</summary>
    public float AskPrice { get => body.askPrice; set => body.askPrice = value; }
     /// <summary>2nd best bid price (@ print time)</summary>
    public float BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>2nd best ask price (@ print time)</summary>
    public float AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>bid size in contracts (largest exch quote)</summary>
    public int BidSize { get => body.bidSize; set => body.bidSize = value; }
     /// <summary>ask size in contracts (largest exch quote)</summary>
    public int AskSize { get => body.askSize; set => body.askSize = value; }
     /// <summary>bid size in contracts (total nbbo size)</summary>
    public int CumBidSize { get => body.cumBidSize; set => body.cumBidSize = value; }
     /// <summary>ask size in contracts (total nbbo size)</summary>
    public int CumAskSize { get => body.cumAskSize; set => body.cumAskSize = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int CumBidSize2 { get => body.cumBidSize2; set => body.cumBidSize2 = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int CumAskSize2 { get => body.cumAskSize2; set => body.cumAskSize2 = value; }
     /// <summary>exchange bid bit mask</summary>
    public uint BidMask { get => body.bidMask; set => body.bidMask = value; }
     /// <summary>exchange ask bit mask</summary>
    public uint AskMask { get => body.askMask; set => body.askMask = value; }
     /// <summary>implied print side (based on ebid/eask and nbbo market)</summary>
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long PrtTimestamp { get => body.prtTimestamp; set => body.prtTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long OqNetTimestamp { get => body.oqNetTimestamp; set => body.oqNetTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionPrint


/// <summary>
/// OptionPrint2:2805
/// </summary>
/// <remarks>
	/// The most recent (last) print record for each active equity and future option series.  Quote markup represents quote that existed just prior to the print on the reporting exchange./// </remarks>

public partial class OptionPrint2 : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionPrint2()
    {
    }
    
    public OptionPrint2(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionPrint2(OptionPrint2 source)
    {
        source.CopyTo(this);
    }
    
    internal OptionPrint2(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionPrint2);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionPrint2 other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionPrint2 target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionPrint2};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public OptExch prtExch;
		public int prtSize;
		public float prtPrice;
		public int prtClusterNum;
		public int prtClusterSize;
		public PrtType prtType;
		public ushort prtOrders;
		public int prtVolume;
		public int oosVolume;
		public int isoVolume;
		public int slaVolume;
		public int mlaVolume;
		public int crxVolume;
		public int flrVolume;
		public int mlgVolume;
		public int uknVolume;
		public int cxlVolume;
		public int totalVolume;
		public ushort bidCount;
		public ushort askCount;
		public int bidVolume;
		public int askVolume;
		public float ebid;
		public float eask;
		public int ebsz;
		public int easz;
		public float eage;
		public PrtSide prtSide;
		public long prtTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public OptExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size [contracts]</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price</summary>
    public float PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>incremental print cluster counter (one counter per okey; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (sequence of prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>print type</summary>
    public PrtType PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>number of participating orders</summary>
    public ushort PrtOrders { get => body.prtOrders; set => body.prtOrders = value; }
     /// <summary>day print volume in contracts (regular, electronic) [AUTO, REOP, MESL, TESL]</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>day print volume reported out of sequence (not regular way electronic) [OSEQ, LATE, OPEN, OPNL]</summary>
    public int OosVolume { get => body.oosVolume; set => body.oosVolume = value; }
     /// <summary>day ISO sweep volume [ISOI]</summary>
    public int IsoVolume { get => body.isoVolume; set => body.isoVolume = value; }
     /// <summary>single leg aution volume [SLAN, SLAI]</summary>
    public int SlaVolume { get => body.slaVolume; set => body.slaVolume = value; }
     /// <summary>multi leg auction volume [MLAT, TLAT, MASL, TASL]</summary>
    public int MlaVolume { get => body.mlaVolume; set => body.mlaVolume = value; }
     /// <summary>day electronic cross volume (no exposure period) [SLCN, SCLI, MLCT, TLCT]</summary>
    public int CrxVolume { get => body.crxVolume; set => body.crxVolume = value; }
     /// <summary>day exchange floor volume [SLFT, MLFT, MFSL, TLFT, TFSL, CMBO]</summary>
    public int FlrVolume { get => body.flrVolume; set => body.flrVolume = value; }
     /// <summary>multi-leg (complex) volume [MLET, TLET]</summary>
    public int MlgVolume { get => body.mlgVolume; set => body.mlgVolume = value; }
     /// <summary>other (uncategorized) volume</summary>
    public int UknVolume { get => body.uknVolume; set => body.uknVolume = value; }
     /// <summary>day print/cancel volume (num of contracts printed and then cancelled) [CANC, CNCL, CNCO, CNOL]</summary>
    public int CxlVolume { get => body.cxlVolume; set => body.cxlVolume = value; }
     /// <summary>total day volume</summary>
    public int TotalVolume { get => body.totalVolume; set => body.totalVolume = value; }
     /// <summary>number of bid prints</summary>
    public ushort BidCount { get => body.bidCount; set => body.bidCount = value; }
     /// <summary>number of ask prints</summary>
    public ushort AskCount { get => body.askCount; set => body.askCount = value; }
     /// <summary>bid print volume in contracts</summary>
    public int BidVolume { get => body.bidVolume; set => body.bidVolume = value; }
     /// <summary>ask print volume in contracts</summary>
    public int AskVolume { get => body.askVolume; set => body.askVolume = value; }
     /// <summary>exchange bid (@ print time)</summary>
    public float Ebid { get => body.ebid; set => body.ebid = value; }
     /// <summary>exchange ask (@ print time)</summary>
    public float Eask { get => body.eask; set => body.eask = value; }
     /// <summary>exchange bid size</summary>
    public int Ebsz { get => body.ebsz; set => body.ebsz = value; }
     /// <summary>exchange ask size</summary>
    public int Easz { get => body.easz; set => body.easz = value; }
     /// <summary>age of prevailing quote at time of print</summary>
    public float Eage { get => body.eage; set => body.eage = value; }
     /// <summary>implied print side (based on ebid/eask and nbbo market)</summary>
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long PrtTimestamp { get => body.prtTimestamp; set => body.prtTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionPrint2


/// <summary>
/// OptionPrintMarkup:2810
/// </summary>
/// <remarks>
	/// OptionPrintMarkup records contain every option print along with quote, surface details at print time/// </remarks>

public partial class OptionPrintMarkup : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public OptionPrintMarkup()
    {
    }
    
    public OptionPrintMarkup(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public OptionPrintMarkup(OptionPrintMarkup source)
    {
        source.CopyTo(this);
    }
    
    internal OptionPrintMarkup(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as OptionPrintMarkup);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionPrintMarkup other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(OptionPrintMarkup target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionPrintMarkup};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public long prtNumber;
		public ExpiryKeyLayout fkey;
		public TickerKeyLayout ticker;
		public OptExch prtExch;
		public int prtSize;
		public float prtPrice;
		public PrtType prtType;
		public ushort prtOrders;
		public int prtClusterNum;
		public int prtClusterSize;
		public int prtVolume;
		public int cxlVolume;
		public ushort bidCount;
		public ushort askCount;
		public int bidVolume;
		public int askVolume;
		public float ebid;
		public float eask;
		public int ebsz;
		public int easz;
		public float eage;
		public PrtSide prtSide;
		public float oBid;
		public float oAsk;
		public int oBidSz;
		public int oAskSz;
		public OptExch oBidEx;
		public OptExch oAskEx;
		public int oBidExSz;
		public int oAskExSz;
		public byte oBidCnt;
		public byte oAskCnt;
		public float oBid2;
		public float oAsk2;
		public int oBidSz2;
		public int oAskSz2;
		public double uBid;
		public double uAsk;
		public double uPrc;
		public float yrs;
		public float rate;
		public float sdiv;
		public float ddiv;
		public float xDe;
		public float xAxis;
		public Multihedge multihedge;
		public float prtIv;
		public float prtDe;
		public float prtGa;
		public float prtTh;
		public float prtVe;
		public float prtRo;
		public FixedString24Layout calcErr;
		public float surfVol;
		public float surfOpx;
		public float surfAtm;
		public long srcTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>Unique print set identifier, will increment but not guaranteed to be sequential</summary>
    public long PrtNumber { get => body.prtNumber; set => body.prtNumber = value; }
     /// <summary>underlying fkey (if any)</summary>
    public ExpiryKey Fkey { get => ExpiryKey.GetCreateExpiryKey(body.fkey); set => body.fkey = value.Layout; }
     /// <summary>underlying ticker</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>Exchange on which print took place</summary>
    public OptExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size [contracts]</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price</summary>
    public float PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>print type</summary>
    public PrtType PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>number of participating orders</summary>
    public ushort PrtOrders { get => body.prtOrders; set => body.prtOrders = value; }
     /// <summary>incremental print cluster counter (one counter per okey; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>day print volume in contracts [this exchange]</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>day print/cancel volume (num of contracts printed and then cancelled)</summary>
    public int CxlVolume { get => body.cxlVolume; set => body.cxlVolume = value; }
     /// <summary>number of bid prints</summary>
    public ushort BidCount { get => body.bidCount; set => body.bidCount = value; }
     /// <summary>number of ask prints</summary>
    public ushort AskCount { get => body.askCount; set => body.askCount = value; }
     /// <summary>bid print volume in contracts</summary>
    public int BidVolume { get => body.bidVolume; set => body.bidVolume = value; }
     /// <summary>ask print volume in contracts</summary>
    public int AskVolume { get => body.askVolume; set => body.askVolume = value; }
     /// <summary>exchange bid (@ print time)</summary>
    public float Ebid { get => body.ebid; set => body.ebid = value; }
     /// <summary>exchange ask (@ print time)</summary>
    public float Eask { get => body.eask; set => body.eask = value; }
     /// <summary>exchange bid size</summary>
    public int Ebsz { get => body.ebsz; set => body.ebsz = value; }
     /// <summary>exchange ask size</summary>
    public int Easz { get => body.easz; set => body.easz = value; }
     /// <summary>age of prevailing quote at time of print</summary>
    public float Eage { get => body.eage; set => body.eage = value; }
     
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>Option NBBO bid a the time the print was received</summary>
    public float OBid { get => body.oBid; set => body.oBid = value; }
     /// <summary>Option NBBO ask a the time the print was received</summary>
    public float OAsk { get => body.oAsk; set => body.oAsk = value; }
     /// <summary>Option NBBO cumulative bid size at the time the print was received</summary>
    public int OBidSz { get => body.oBidSz; set => body.oBidSz = value; }
     /// <summary>Option NBBO cumulative ask size at the time the print was received</summary>
    public int OAskSz { get => body.oAskSz; set => body.oAskSz = value; }
     /// <summary>First (or largest) option exchange on the bid</summary>
    public OptExch OBidEx { get => body.oBidEx; set => body.oBidEx = value; }
     /// <summary>First (or largest) option exchange on the ask</summary>
    public OptExch OAskEx { get => body.oAskEx; set => body.oAskEx = value; }
     /// <summary>Option bid size of the largest exchange on the bid at the time the print was received</summary>
    public int OBidExSz { get => body.oBidExSz; set => body.oBidExSz = value; }
     /// <summary>Option ask size of the largest exchange on the ask at the time the print was received</summary>
    public int OAskExSz { get => body.oAskExSz; set => body.oAskExSz = value; }
     /// <summary>Number of exchanges on the NBBO bid</summary>
    public byte OBidCnt { get => body.oBidCnt; set => body.oBidCnt = value; }
     /// <summary>Number of exchanges on the NBBO ask</summary>
    public byte OAskCnt { get => body.oAskCnt; set => body.oAskCnt = value; }
     /// <summary>Second level bid price</summary>
    public float OBid2 { get => body.oBid2; set => body.oBid2 = value; }
     /// <summary>Second level ask price</summary>
    public float OAsk2 { get => body.oAsk2; set => body.oAsk2 = value; }
     /// <summary>Cumulative size on the second level bid price</summary>
    public int OBidSz2 { get => body.oBidSz2; set => body.oBidSz2 = value; }
     /// <summary>Cumulative size on the second level ask price</summary>
    public int OAskSz2 { get => body.oAskSz2; set => body.oAskSz2 = value; }
     /// <summary>underlier bid</summary>
    public double UBid { get => body.uBid; set => body.uBid = value; }
     /// <summary>underlier ask</summary>
    public double UAsk { get => body.uAsk; set => body.uAsk = value; }
     /// <summary>underlier price</summary>
    public double UPrc { get => body.uPrc; set => body.uPrc = value; }
     /// <summary>years to expiry</summary>
    public float Yrs { get => body.yrs; set => body.yrs = value; }
     /// <summary>interest rate</summary>
    public float Rate { get => body.rate; set => body.rate = value; }
     /// <summary>continuous stock dividend</summary>
    public float Sdiv { get => body.sdiv; set => body.sdiv = value; }
     /// <summary>discrete stock dividend value (sum of dividends &lt;= expiration)</summary>
    public float Ddiv { get => body.ddiv; set => body.ddiv = value; }
     /// <summary>xDelta</summary>
    public float XDe { get => body.xDe; set => body.xDe = value; }
     /// <summary>SR surface xAxis value</summary>
    public float XAxis { get => body.xAxis; set => body.xAxis = value; }
     /// <summary>Distinguishes options that have a single underlying security from those that are more complex:  multiple securities,cash components, binary options,etc:  'None','Simple','Complex','AllCash','Binary'</summary>
    public Multihedge Multihedge { get => body.multihedge; set => body.multihedge = value; }
     /// <summary>print implied vol</summary>
    public float PrtIv { get => body.prtIv; set => body.prtIv = value; }
     /// <summary>print delta</summary>
    public float PrtDe { get => body.prtDe; set => body.prtDe = value; }
     /// <summary>print gamma</summary>
    public float PrtGa { get => body.prtGa; set => body.prtGa = value; }
     /// <summary>print theta</summary>
    public float PrtTh { get => body.prtTh; set => body.prtTh = value; }
     /// <summary>print vega</summary>
    public float PrtVe { get => body.prtVe; set => body.prtVe = value; }
     /// <summary>print rho</summary>
    public float PrtRo { get => body.prtRo; set => body.prtRo = value; }
     /// <summary>calc error flag</summary>
    public string CalcErr { get => body.calcErr; set => body.calcErr = value; }
     /// <summary>SR surface volatility</summary>
    public float SurfVol { get => body.surfVol; set => body.surfVol = value; }
     /// <summary>SR surface price</summary>
    public float SurfOpx { get => body.surfOpx; set => body.surfOpx = value; }
     /// <summary>SR surface ATM vol</summary>
    public float SurfAtm { get => body.surfAtm; set => body.surfAtm = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound print packet PTP timestamp from SR gateway switch</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionPrintMarkup


/// <summary>
/// OptionRiskFactor:1095
/// </summary>
/// <remarks>
	/// This table contains the up/dn underlier price slides used in OCC risk calculations.  Note that these values are computed by SpiderRock using similar methods but may not exactly match OCC values./// </remarks>

public partial class OptionRiskFactor : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionRiskFactor other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.OptionRiskFactor};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey Okey { get => OptionKey.GetCreateOptionKey(body.okey); set => body.okey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = okey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
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

    internal BodyLayout body;

    
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>option surface volatility</summary>
    public float Svol { get => body.svol; set => body.svol = value; }
     /// <summary>years to expiration</summary>
    public float Years { get => body.years; set => body.years = value; }
     /// <summary>underlier up 50% slide</summary>
    public float Up50 { get => body.up50; set => body.up50 = value; }
     /// <summary>underlier dn 50% slide</summary>
    public float Dn50 { get => body.dn50; set => body.dn50 = value; }
     /// <summary>underlier up 15% slide</summary>
    public float Up15 { get => body.up15; set => body.up15 = value; }
     /// <summary>underlier dn 15% slide</summary>
    public float Dn15 { get => body.dn15; set => body.dn15 = value; }
     /// <summary>underlier up 12% slide</summary>
    public float Up12 { get => body.up12; set => body.up12 = value; }
     /// <summary>underlier dn 12% slide</summary>
    public float Dn12 { get => body.dn12; set => body.dn12 = value; }
     /// <summary>underlier up 9% slide</summary>
    public float Up09 { get => body.up09; set => body.up09 = value; }
     /// <summary>underlier dn 9% slide</summary>
    public float Dn09 { get => body.dn09; set => body.dn09 = value; }
     /// <summary>underlier dn 8% slide</summary>
    public float Dn08 { get => body.dn08; set => body.dn08 = value; }
     /// <summary>underlier up 6% slide</summary>
    public float Up06 { get => body.up06; set => body.up06 = value; }
     /// <summary>underlier dn 6% slide</summary>
    public float Dn06 { get => body.dn06; set => body.dn06 = value; }
     /// <summary>underlier up 3% slide</summary>
    public float Up03 { get => body.up03; set => body.up03 = value; }
     /// <summary>underlier dn 3% slide</summary>
    public float Dn03 { get => body.dn03; set => body.dn03 = value; }
     /// <summary>option pricing error, otherwise, an empty string.</summary>
    public string CalcErr { get => body.calcErr; set => body.calcErr = value; }
     
    public CalcSource CalcSource { get => body.calcSource; set => body.calcSource = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // OptionRiskFactor


/// <summary>
/// ProductDefinitionV2:4360
/// </summary>
/// <remarks>
/// </remarks>

public partial class ProductDefinitionV2 : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ProductDefinitionV2 other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();
         LegsList = null;

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.ProductDefinitionV2};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>SR Security Key [can be partially filled in (look at secType)]</summary>
        public OptionKey SecKey { get => OptionKey.GetCreateOptionKey(body.secKey); set => body.secKey = value.Layout; }
         /// <summary>Security Type [Stock, Future, Option]</summary>
        public SpdrKeyType SecType { get => body.secType; set => body.secType = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = secKey.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) secType);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     

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

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public FixedString24Layout securityID;
		public TickerKeyLayout ticker;
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

    internal BodyLayout body;

    /// <summary>unique exchange id (exch assigned)</summary>
    public string SecurityID { get => body.securityID; set => body.securityID = value; }
     /// <summary>master underlier</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     
    public ProductClass ProductClass { get => body.productClass; set => body.productClass = value; }
     /// <summary>underlier product id (option only) [securityID of undKey/undType product]</summary>
    public long UnderlierID { get => body.underlierID; set => body.underlierID = value; }
     /// <summary>SR Underlier Security Key [can be partially filled in (look at undType)] (option only)</summary>
    public ExpiryKey UndKey { get => ExpiryKey.GetCreateExpiryKey(body.undKey); set => body.undKey = value.Layout; }
     /// <summary>Underlier Security Type [Stock, Future] (option only)</summary>
    public SpdrKeyType UndType { get => body.undType; set => body.undType = value; }
     /// <summary>Underlying product code.  I.E. All GE (Eurodollar) spreads, options, futures will be in the same productGroup - This is the Asset field from the SecurityDefinition message</summary>
    public string ProductGroup { get => body.productGroup; set => body.productGroup = value; }
     /// <summary>Exchange specific code for a group of related securities that are all affected by market events.  I.E. All E-mini weekly options (EW) - This is SecurityGroup field from the SecurityDefinition messages</summary>
    public string SecurityGroup { get => body.securityGroup; set => body.securityGroup = value; }
     /// <summary>Exchange specific market segment identifier</summary>
    public int MarketSegmentID { get => body.marketSegmentID; set => body.marketSegmentID = value; }
     /// <summary>full exchange symbol</summary>
    public string SecurityDesc { get => body.securityDesc; set => body.securityDesc = value; }
     /// <summary>listing exchange</summary>
    public string Exchange { get => body.exchange; set => body.exchange = value; }
     
    public ProductType ProductType { get => body.productType; set => body.productType = value; }
     
    public ProductTerm ProductTerm { get => body.productTerm; set => body.productTerm = value; }
     
    public ProductIndexType ProductIndexType { get => body.productIndexType; set => body.productIndexType = value; }
     
    public float ProductRate { get => body.productRate; set => body.productRate = value; }
     
    public float ContractSize { get => body.contractSize; set => body.contractSize = value; }
     
    public ContractUnit ContractUnit { get => body.contractUnit; set => body.contractUnit = value; }
     
    public PriceFormat PriceFormat { get => body.priceFormat; set => body.priceFormat = value; }
     
    public double MinTickSize { get => body.minTickSize; set => body.minTickSize = value; }
     
    public double DisplayFactor { get => body.displayFactor; set => body.displayFactor = value; }
     /// <summary>manual strike price adjustment multiplier (used for some CME products if set, otherwise displayFactor is used) (okey_xx = strikePrice * manualStrikeScale)</summary>
    public double StrikeScale { get => body.strikeScale; set => body.strikeScale = value; }
     /// <summary>minimum lot size</summary>
    public short MinLotSize { get => body.minLotSize; set => body.minLotSize = value; }
     /// <summary>levels in the Globex quote book</summary>
    public short BookDepth { get => body.bookDepth; set => body.bookDepth = value; }
     /// <summary>levels in the globex implied quote book (0 if no implied depth)</summary>
    public short ImpliedBookDepth { get => body.impliedBookDepth; set => body.impliedBookDepth = value; }
     /// <summary>implied market type (0 = no implied, 1 = implied in, 2 = implied out, 3 = implied in &amp; out)</summary>
    public short ImpMarketInd { get => body.impMarketInd; set => body.impMarketInd = value; }
     /// <summary>(depricate) minimum price amount (points per handle)</summary>
    public float MinPriceIncrementAmount { get => body.minPriceIncrementAmount; set => body.minPriceIncrementAmount = value; }
     /// <summary>per contract par value</summary>
    public float ParValue { get => body.parValue; set => body.parValue = value; }
     /// <summary>contract deliverable multipler</summary>
    public float ContMultiplier { get => body.contMultiplier; set => body.contMultiplier = value; }
     /// <summary>(depricate) cabinet price (minimum closing price for OOM options)</summary>
    public double CabPrice { get => body.cabPrice; set => body.cabPrice = value; }
     
    public Currency TradeCurr { get => body.tradeCurr; set => body.tradeCurr = value; }
     
    public Currency SettleCurr { get => body.settleCurr; set => body.settleCurr = value; }
     
    public Currency StrikeCurr { get => body.strikeCurr; set => body.strikeCurr = value; }
     /// <summary>future expiration or option expiration (if product is an option). we use the last TRADING day as the expiration date.</summary>
    public DateTime Expiration { get => body.expiration; set => body.expiration = value; }
     /// <summary>future maturity date or option maturity date.  this is the delivery month.</summary>
    public DateKey Maturity { get => DateKey.GetCreateDateKey(body.maturity); set => body.maturity = value.Layout; }
     /// <summary>(depricate; in RootDefinition) Exercise style</summary>
    public ExerciseType ExerciseType { get => body.exerciseType; set => body.exerciseType = value; }
     
    public YesNo UserDefined { get => body.userDefined; set => body.userDefined = value; }
     
    public short DecayStartYear { get => body.decayStartYear; set => body.decayStartYear = value; }
     
    public byte DecayStartMonth { get => body.decayStartMonth; set => body.decayStartMonth = value; }
     
    public byte DecayStartDay { get => body.decayStartDay; set => body.decayStartDay = value; }
     /// <summary>daily decay quantity</summary>
    public int DecayQty { get => body.decayQty; set => body.decayQty = value; }
     /// <summary>price ratio for interest rate intercommodity spreads</summary>
    public double PriceRatio { get => body.priceRatio; set => body.priceRatio = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // ProductDefinitionV2


/// <summary>
/// RootDefinition:4365
/// </summary>
/// <remarks>
/// </remarks>

public partial class RootDefinition : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(RootDefinition other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();
         UnderlyingList = null;

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.RootDefinition};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Root { get => TickerKey.GetCreateTickerKey(body.root); set => body.root = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = root.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     

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

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TickerKeyLayout ticker;
		public FixedString8Layout osiRoot;
		public TickerKeyLayout ccode;
		public ExpirationMap expirationMap;
		public UnderlierMode underlierMode;
		public PricingSource pricingSource;
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
		public Currency pointCurrency;
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

    internal BodyLayout body;

    /// <summary>master underlying</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>long version of the root.  the short version is used in the TickerKey (for example RYAAY1, not RYAA1)</summary>
    public string OsiRoot { get => body.osiRoot; set => body.osiRoot = value; }
     
    public TickerKey Ccode { get => TickerKey.GetCreateTickerKey(body.ccode); set => body.ccode = value.Layout; }
     
    public ExpirationMap ExpirationMap { get => body.expirationMap; set => body.expirationMap = value; }
     
    public UnderlierMode UnderlierMode { get => body.underlierMode; set => body.underlierMode = value; }
     /// <summary>note: synthetics are priced by root + expiry (from the SyntheticQuote/SyntheticPrint messages)</summary>
    public PricingSource PricingSource { get => body.pricingSource; set => body.pricingSource = value; }
     /// <summary>indicator for option type</summary>
    public OptionType OptionType { get => body.optionType; set => body.optionType = value; }
     /// <summary>indicates type of multihedge</summary>
    public Multihedge Multihedge { get => body.multihedge; set => body.multihedge = value; }
     /// <summary>Exercise time type</summary>
    public ExerciseTime ExerciseTime { get => body.exerciseTime; set => body.exerciseTime = value; }
     /// <summary>Exercise style</summary>
    public ExerciseType ExerciseType { get => body.exerciseType; set => body.exerciseType = value; }
     /// <summary>trading time metric - 252 or 365 trading days or a weekly cycle type</summary>
    public TimeMetric TimeMetric { get => body.timeMetric; set => body.timeMetric = value; }
     
    public PricingModel PricingModel { get => body.pricingModel; set => body.pricingModel = value; }
     /// <summary>moneyness (xAxis) convention: PctStd = (K / fUPrc - 1) / (axisVol * RT), LogStd = LOG(K/fUPrc) / (axisVol * RT), NormStd = (K - fUPrc) / (axisVol * RT)</summary>
    public MoneynessType MoneynessType { get => body.moneynessType; set => body.moneynessType = value; }
     /// <summary>quoting style for the option series on the exchange, price (standard price quote) or volatility quoted (vol points)</summary>
    public PriceQuoteType PriceQuoteType { get => body.priceQuoteType; set => body.priceQuoteType = value; }
     
    public VolumeTier VolumeTier { get => body.volumeTier; set => body.volumeTier = value; }
     /// <summary>max contract limit</summary>
    public int PositionLimit { get => body.positionLimit; set => body.positionLimit = value; }
     /// <summary>exchange codes</summary>
    public string Exchanges { get => body.exchanges; set => body.exchanges = value; }
     /// <summary>$NLV value of a single tick change in display premium	(pointValue = tickValue / tickSize)</summary>
    public float TickValue { get => body.tickValue; set => body.tickValue = value; }
     /// <summary>$NLV value of a single point change in display premium (pointValue = tickValue / tickSize)</summary>
    public float PointValue { get => body.pointValue; set => body.pointValue = value; }
     
    public Currency PointCurrency { get => body.pointCurrency; set => body.pointCurrency = value; }
     /// <summary>manual strike price adjustment multiplier (used for some CME products if set, otherwise displayFactor is used) (okey_xx = strikePrice * manualStrikeScale)</summary>
    public double StrikeScale { get => body.strikeScale; set => body.strikeScale = value; }
     /// <summary>note: effective strike = strike * strikeRatio - cashOnExercise</summary>
    public float StrikeRatio { get => body.strikeRatio; set => body.strikeRatio = value; }
     /// <summary>note: cashOnExercise is positive if it decreases the effective strike price</summary>
    public float CashOnExercise { get => body.cashOnExercise; set => body.cashOnExercise = value; }
     /// <summary>note: always 100 if underlying list is in use</summary>
    public int UnderliersPerCn { get => body.underliersPerCn; set => body.underliersPerCn = value; }
     /// <summary>note: OCC premium/strike multiplier (usually 100)</summary>
    public double PremiumMult { get => body.premiumMult; set => body.premiumMult = value; }
     
    public AdjConvention AdjConvention { get => body.adjConvention; set => body.adjConvention = value; }
     
    public OptPriceInc OptPriceInc { get => body.optPriceInc; set => body.optPriceInc = value; }
     /// <summary>price display format</summary>
    public PriceFormat PriceFormat { get => body.priceFormat; set => body.priceFormat = value; }
     
    public Currency TradeCurr { get => body.tradeCurr; set => body.tradeCurr = value; }
     
    public Currency SettleCurr { get => body.settleCurr; set => body.settleCurr = value; }
     
    public Currency StrikeCurr { get => body.strikeCurr; set => body.strikeCurr = value; }
     /// <summary>fallback ticker to use for option surfaces if no native surfaces are available</summary>
    public TickerKey DefaultSurfaceRoot { get => TickerKey.GetCreateTickerKey(body.defaultSurfaceRoot); set => body.defaultSurfaceRoot = value.Layout; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // RootDefinition


/// <summary>
/// SpdrAuctionState:2525
/// </summary>
/// <remarks>
/// </remarks>

public partial class SpdrAuctionState : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public SpdrAuctionState()
    {
    }
    
    public SpdrAuctionState(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public SpdrAuctionState(SpdrAuctionState source)
    {
        source.CopyTo(this);
    }
    
    internal SpdrAuctionState(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as SpdrAuctionState);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpdrAuctionState other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(SpdrAuctionState target)
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
					dest.LegSecKey = src.LegSecKey;
 					dest.LegSecType = src.LegSecType;
 					dest.LegSide = src.LegSide;
 					dest.LegRatio = src.LegRatio;

                target.LegsList[i] = dest;
            }
        }

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();
         LegsList = null;

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SpdrAuctionState};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public OptionKey SecKey { get => OptionKey.GetCreateOptionKey(body.secKey); set => body.secKey = value.Layout; }
         
        public SpdrKeyType SecType { get => body.secType; set => body.secType = value; }
         /// <summary>exchange handling the auction</summary>
        public OptExch AuctionExch { get => body.auctionExch; set => body.auctionExch = value; }
         /// <summary>external exDest of auction (usually means auction is off-exchange)</summary>
        public string AuctionExDest { get => body.auctionExDest; set => body.auctionExDest = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public OptionKeyLayout secKey;
         public SpdrKeyType secType;
         public OptExch auctionExch;
         public FixedString16Layout auctionExDest;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	secKey.Equals(other.secKey) &&
					 	secType.Equals(other.secType) &&
					 	auctionExch.Equals(other.auctionExch) &&
					 	auctionExDest.Equals(other.auctionExDest);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = secKey.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) secType);
                 hashCode = (hashCode*397) ^ ((int) auctionExch);
                 hashCode = (hashCode*397) ^ (auctionExDest.GetHashCode());

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class LegsItem
    {
        public const int Length = 30;

        public LegsItem() { }
        
        public LegsItem(OptionKey legSecKey, SpdrKeyType legSecType, BuySell legSide, ushort legRatio)
        {
            this.LegSecKey = legSecKey;
			this.LegSecType = legSecType;
			this.LegSide = legSide;
			this.LegRatio = legRatio;
        }

        public OptionKey LegSecKey { get; internal set; }
		public SpdrKeyType LegSecType { get; internal set; }
		public BuySell LegSide { get; internal set; }
		public ushort LegRatio { get; internal set; }
    }

    public LegsItem[] LegsList { get; set; }

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public long srAuctionID;
		public FixedString20Layout exchAuctionId;
		public FixedString4Layout exchAuctionType;
		public YesNo isTestAuction;
		public AuctionState auctionState;
		public NoticeShape auctionShape;
		public AuctionType auctionType;
		public BuySell auctionSide;
		public int auctionSize;
		public double auctionPrice;
		public YesNo isAuctionPriceValid;
		public int auctionDuration;
		public int auctionStartSize;
		public double auctionStartPrice;
		public long auctionStartTimestamp;
		public int minResponseSize;
		public AuctionLimitType limitType;
		public FirmType firmType;
		public FixedString10Layout memberMPID;
		public FixedString10Layout clientAccnt;
		public FixedString16Layout otherDetail;
		public int matchedSize;
		public byte numUpdates;
		public byte numResponses;
		public int bestResponseSize;
		public double bestResponsePrice;
		public int cumFillQuantity;
		public double avgFillPrice;
		public MarketStatus marketStatus;
		public long srcTimestamp;
		public long netTimestamp;
		public long dgwTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>unique SR AUCTION ID (required when responding to an auction notice)</summary>
    public long SrAuctionID { get => body.srAuctionID; set => body.srAuctionID = value; }
     
    public string ExchAuctionId { get => body.exchAuctionId; set => body.exchAuctionId = value; }
     
    public string ExchAuctionType { get => body.exchAuctionType; set => body.exchAuctionType = value; }
     /// <summary>test auction (should only respond from T.accnts)</summary>
    public YesNo IsTestAuction { get => body.isTestAuction; set => body.isTestAuction = value; }
     
    public AuctionState AuctionState { get => body.auctionState; set => body.auctionState = value; }
     
    public NoticeShape AuctionShape { get => body.auctionShape; set => body.auctionShape = value; }
     
    public AuctionType AuctionType { get => body.auctionType; set => body.auctionType = value; }
     /// <summary>Market side (client/imbalance side of auction; if known) [responder should be opposite side]</summary>
    public BuySell AuctionSide { get => body.auctionSide; set => body.auctionSide = value; }
     /// <summary>size available to trade</summary>
    public int AuctionSize { get => body.auctionSize; set => body.auctionSize = value; }
     /// <summary>auction price (can be positive or negative)</summary>
    public double AuctionPrice { get => body.auctionPrice; set => body.auctionPrice = value; }
     
    public YesNo IsAuctionPriceValid { get => body.isAuctionPriceValid; set => body.isAuctionPriceValid = value; }
     /// <summary>expected auction / imbalance action duration (ms)</summary>
    public int AuctionDuration { get => body.auctionDuration; set => body.auctionDuration = value; }
     /// <summary>initial (starting) auction size</summary>
    public int AuctionStartSize { get => body.auctionStartSize; set => body.auctionStartSize = value; }
     /// <summary>initial (starting) auction price</summary>
    public double AuctionStartPrice { get => body.auctionStartPrice; set => body.auctionStartPrice = value; }
     /// <summary>auction start timestamp</summary>
    public long AuctionStartTimestamp { get => body.auctionStartTimestamp; set => body.auctionStartTimestamp = value; }
     /// <summary>minimum size of the response order</summary>
    public int MinResponseSize { get => body.minResponseSize; set => body.minResponseSize = value; }
     /// <summary>client / imbalance limit type (if available)</summary>
    public AuctionLimitType LimitType { get => body.limitType; set => body.limitType = value; }
     /// <summary>firm type of the client side of auction (if available)</summary>
    public FirmType FirmType { get => body.firmType; set => body.firmType = value; }
     /// <summary>exchange member initiating auction (if available)</summary>
    public string MemberMPID { get => body.memberMPID; set => body.memberMPID = value; }
     /// <summary>client account designation (if known)</summary>
    public string ClientAccnt { get => body.clientAccnt; set => body.clientAccnt = value; }
     /// <summary>additional auction detail (exchange specific)</summary>
    public string OtherDetail { get => body.otherDetail; set => body.otherDetail = value; }
     /// <summary>size already matched (may still be available to trade at a better price)</summary>
    public int MatchedSize { get => body.matchedSize; set => body.matchedSize = value; }
     /// <summary>number of auction updates received (not counting auction termination message)</summary>
    public byte NumUpdates { get => body.numUpdates; set => body.numUpdates = value; }
     /// <summary>as reported by exchange (if available)</summary>
    public byte NumResponses { get => body.numResponses; set => body.numResponses = value; }
     
    public int BestResponseSize { get => body.bestResponseSize; set => body.bestResponseSize = value; }
     
    public double BestResponsePrice { get => body.bestResponsePrice; set => body.bestResponsePrice = value; }
     /// <summary>as reported by exchange (if available)</summary>
    public int CumFillQuantity { get => body.cumFillQuantity; set => body.cumFillQuantity = value; }
     
    public double AvgFillPrice { get => body.avgFillPrice; set => body.avgFillPrice = value; }
     /// <summary>market status (pre-open, open, closed, etc)</summary>
    public MarketStatus MarketStatus { get => body.marketStatus; set => body.marketStatus = value; }
     /// <summary>source timestamp (nanoseconds) if available</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>network timestamp message arrival @ direct exchange gateway</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     /// <summary>network timestamp mbus message send @ direct exchange gateway</summary>
    public long DgwTimestamp { get => body.dgwTimestamp; set => body.dgwTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SpdrAuctionState


/// <summary>
/// SpreadBookQuote:2900
/// </summary>
/// <remarks>
	/// This table contains live spread quote records from the individual equity option exchanges.  Each record contains up to two price levels and represents a live snapshot of the book for a specific spread./// </remarks>

public partial class SpreadBookQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpreadBookQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SpreadBookQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>SR Spread Key (should have corresponding ProductDefinition record)</summary>
        public TickerKey Skey { get => TickerKey.GetCreateTickerKey(body.skey); set => body.skey = value.Layout; }
         /// <summary>Yes indicates that response is made of entirely of isTest=Yes SpreadExchOrders</summary>
        public YesNo IsTest { get => body.isTest; set => body.isTest = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = skey.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) isTest);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TickerKeyLayout ticker;
		public double bidPrice1;
		public YesNo isBidPrice1Valid;
		public double askPrice1;
		public YesNo isAskPrice1Valid;
		public int bidSize1;
		public int askSize1;
		public double bidPrice2;
		public YesNo isBidPrice2Valid;
		public double askPrice2;
		public YesNo isAskPrice2Valid;
		public int bidSize2;
		public int askSize2;
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

    internal BodyLayout body;

    /// <summary>common spread underlier</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>bid price</summary>
    public double BidPrice1 { get => body.bidPrice1; set => body.bidPrice1 = value; }
     
    public YesNo IsBidPrice1Valid { get => body.isBidPrice1Valid; set => body.isBidPrice1Valid = value; }
     /// <summary>ask price</summary>
    public double AskPrice1 { get => body.askPrice1; set => body.askPrice1 = value; }
     
    public YesNo IsAskPrice1Valid { get => body.isAskPrice1Valid; set => body.isAskPrice1Valid = value; }
     /// <summary>cumulative size at bidPrice</summary>
    public int BidSize1 { get => body.bidSize1; set => body.bidSize1 = value; }
     /// <summary>cumulative size at askPrice</summary>
    public int AskSize1 { get => body.askSize1; set => body.askSize1 = value; }
     /// <summary>2nd best bid price</summary>
    public double BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     
    public YesNo IsBidPrice2Valid { get => body.isBidPrice2Valid; set => body.isBidPrice2Valid = value; }
     /// <summary>2nd best ask price</summary>
    public double AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     
    public YesNo IsAskPrice2Valid { get => body.isAskPrice2Valid; set => body.isAskPrice2Valid = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int BidSize2 { get => body.bidSize2; set => body.bidSize2 = value; }
     /// <summary>cumulative size at 2nd price</summary>
    public int AskSize2 { get => body.askSize2; set => body.askSize2 = value; }
     /// <summary>exchange at bid price with the largest size (if any)</summary>
    public OptExch BidExch1 { get => body.bidExch1; set => body.bidExch1 = value; }
     /// <summary>exchange at ask price with the largest size (if any)</summary>
    public OptExch AskExch1 { get => body.askExch1; set => body.askExch1 = value; }
     /// <summary>exchange bid bit mask (OptExch mask for NMS spreads; zero for single exchange spreads)</summary>
    public uint BidMask1 { get => body.bidMask1; set => body.bidMask1 = value; }
     /// <summary>exchange ask bit mask (OptExch mask for NMS spreads; zero for single exchange spreads)</summary>
    public uint AskMask1 { get => body.askMask1; set => body.askMask1 = value; }
     /// <summary>last bid price or size change</summary>
    public DateTime BidTime { get => body.bidTime; set => body.bidTime = value; }
     /// <summary>last ask price or size change</summary>
    public DateTime AskTime { get => body.askTime; set => body.askTime = value; }
     
    public UpdateType UpdateType { get => body.updateType; set => body.updateType = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SpreadBookQuote


/// <summary>
/// SpreadExchOrder:2915
/// </summary>
/// <remarks>
	/// Live public spread orders for each exchange (if available)/// </remarks>

public partial class SpreadExchOrder : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public SpreadExchOrder()
    {
    }
    
    public SpreadExchOrder(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public SpreadExchOrder(SpreadExchOrder source)
    {
        source.CopyTo(this);
    }
    
    internal SpreadExchOrder(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as SpreadExchOrder);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpreadExchOrder other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(SpreadExchOrder target)
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
					dest.LegSecKey = src.LegSecKey;
 					dest.LegSecType = src.LegSecType;
 					dest.LegSide = src.LegSide;
 					dest.LegRatio = src.LegRatio;
 					dest.PositionType = src.PositionType;

                target.LegsList[i] = dest;
            }
        }

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();
         LegsList = null;

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SpreadExchOrder};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>SR or exchange assigned Spread TickerKey (ProductDefinition.pkey) (might be null)</summary>
        public TickerKey Skey { get => TickerKey.GetCreateTickerKey(body.skey); set => body.skey = value.Layout; }
         
        public OptExch Exch { get => body.exch; set => body.exch = value; }
         
        public BuySell Side { get => body.side; set => body.side = value; }
         
        public YesNo IsTest { get => body.isTest; set => body.isTest = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public TickerKeyLayout skey;
         public OptExch exch;
         public BuySell side;
         public YesNo isTest;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	skey.Equals(other.skey) &&
					 	exch.Equals(other.exch) &&
					 	side.Equals(other.side) &&
					 	isTest.Equals(other.isTest);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = skey.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) exch);
                 hashCode = (hashCode*397) ^ ((int) side);
                 hashCode = (hashCode*397) ^ ((int) isTest);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class LegsItem
    {
        public const int Length = 33;

        public LegsItem() { }
        
        public LegsItem(OptionKey legSecKey, SpdrKeyType legSecType, BuySell legSide, uint legRatio, PositionType positionType)
        {
            this.LegSecKey = legSecKey;
			this.LegSecType = legSecType;
			this.LegSide = legSide;
			this.LegRatio = legRatio;
			this.PositionType = positionType;
        }

        public OptionKey LegSecKey { get; internal set; }
		public SpdrKeyType LegSecType { get; internal set; }
		public BuySell LegSide { get; internal set; }
		public uint LegRatio { get; internal set; }
		public PositionType PositionType { get; internal set; }
    }

    public LegsItem[] LegsList { get; set; }

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TickerKeyLayout ticker;
		public FixedString24Layout orderID;
		public int size;
		public double price;
		public YesNo isPriceValid;
		public int origOrderSize;
		public ExchOrderType orderType;
		public ExchOrderStatus orderStatus;
		public MarketQualifier marketQualifier;
		public ExecQualifier execQualifier;
		public TimeInForce timeInForce;
		public FirmType firmType;
		public FixedString5Layout clearingFirm;
		public FixedString8Layout clearingAccnt;
		public long srcTimestamp;
		public long netTimestamp;
		public long dgwTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>underlier (or product group) tickerKey</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     /// <summary>exchange order ID</summary>
    public string OrderID { get => body.orderID; set => body.orderID = value; }
     /// <summary>total spreads available</summary>
    public int Size { get => body.size; set => body.size = value; }
     
    public double Price { get => body.price; set => body.price = value; }
     
    public YesNo IsPriceValid { get => body.isPriceValid; set => body.isPriceValid = value; }
     /// <summary>original order size (if available)</summary>
    public int OrigOrderSize { get => body.origOrderSize; set => body.origOrderSize = value; }
     
    public ExchOrderType OrderType { get => body.orderType; set => body.orderType = value; }
     
    public ExchOrderStatus OrderStatus { get => body.orderStatus; set => body.orderStatus = value; }
     
    public MarketQualifier MarketQualifier { get => body.marketQualifier; set => body.marketQualifier = value; }
     
    public ExecQualifier ExecQualifier { get => body.execQualifier; set => body.execQualifier = value; }
     
    public TimeInForce TimeInForce { get => body.timeInForce; set => body.timeInForce = value; }
     
    public FirmType FirmType { get => body.firmType; set => body.firmType = value; }
     
    public string ClearingFirm { get => body.clearingFirm; set => body.clearingFirm = value; }
     
    public string ClearingAccnt { get => body.clearingAccnt; set => body.clearingAccnt = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>SpiderRock network PTP timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     /// <summary>SpiderRock data gateway timestamp</summary>
    public long DgwTimestamp { get => body.dgwTimestamp; set => body.dgwTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SpreadExchOrder


/// <summary>
/// SpreadExchPrint:2920
/// </summary>
/// <remarks>
/// </remarks>

public partial class SpreadExchPrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public SpreadExchPrint()
    {
    }
    
    public SpreadExchPrint(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public SpreadExchPrint(SpreadExchPrint source)
    {
        source.CopyTo(this);
    }
    
    internal SpreadExchPrint(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as SpreadExchPrint);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpreadExchPrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(SpreadExchPrint target)
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
					dest.LegSecKey = src.LegSecKey;
 					dest.LegSecType = src.LegSecType;
 					dest.LegSide = src.LegSide;
 					dest.LegRatio = src.LegRatio;
 					dest.PositionType = src.PositionType;

                target.LegsList[i] = dest;
            }
        }

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();
         LegsList = null;

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SpreadExchPrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>SR assigned print number</summary>
        public long PrintNumber { get => body.printNumber; set => body.printNumber = value; }
         /// <summary>Exchange reporting print</summary>
        public OptExch Exch { get => body.exch; set => body.exch = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public long printNumber;
         public OptExch exch;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	printNumber.Equals(other.printNumber) &&
					 	exch.Equals(other.exch);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = printNumber.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) exch);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class LegsItem
    {
        public const int Length = 33;

        public LegsItem() { }
        
        public LegsItem(OptionKey legSecKey, SpdrKeyType legSecType, BuySell legSide, uint legRatio, PositionType positionType)
        {
            this.LegSecKey = legSecKey;
			this.LegSecType = legSecType;
			this.LegSide = legSide;
			this.LegRatio = legRatio;
			this.PositionType = positionType;
        }

        public OptionKey LegSecKey { get; internal set; }
		public SpdrKeyType LegSecType { get; internal set; }
		public BuySell LegSide { get; internal set; }
		public uint LegRatio { get; internal set; }
		public PositionType PositionType { get; internal set; }
    }

    public LegsItem[] LegsList { get; set; }

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TickerKeyLayout skey;
		public FixedString24Layout strategyID;
		public TickerKeyLayout ticker;
		public BuySell side;
		public int printSize;
		public double printPrice;
		public YesNo isPrintPriceValid;
		public BuySell minAnchorSide;
		public OptionKeyLayout minAnchorLeg;
		public BuySell maxAnchorSide;
		public OptionKeyLayout maxAnchorLeg;
		public YesNo hasFlexLeg;
		public YesNo hasHedgeLeg;
		public BuySell stockLegSide;
		public BuySell futureLegSide;
		public StrategyClass strategyClass;
		public byte numOptLegs;
		public long srcTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>feed handler TickerKey</summary>
    public TickerKey Skey { get => TickerKey.GetCreateTickerKey(body.skey); set => body.skey = value.Layout; }
     
    public string StrategyID { get => body.strategyID; set => body.strategyID = value; }
     /// <summary>underlier (or product group) tickerKey (from leg option)</summary>
    public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
     
    public BuySell Side { get => body.side; set => body.side = value; }
     
    public int PrintSize { get => body.printSize; set => body.printSize = value; }
     
    public double PrintPrice { get => body.printPrice; set => body.printPrice = value; }
     
    public YesNo IsPrintPriceValid { get => body.isPrintPriceValid; set => body.isPrintPriceValid = value; }
     
    public BuySell MinAnchorSide { get => body.minAnchorSide; set => body.minAnchorSide = value; }
     /// <summary>earliest expiry / smallest strike / call prefered</summary>
    public OptionKey MinAnchorLeg { get => OptionKey.GetCreateOptionKey(body.minAnchorLeg); set => body.minAnchorLeg = value.Layout; }
     
    public BuySell MaxAnchorSide { get => body.maxAnchorSide; set => body.maxAnchorSide = value; }
     /// <summary>furtherest expiry / largest strike / put prefered</summary>
    public OptionKey MaxAnchorLeg { get => OptionKey.GetCreateOptionKey(body.maxAnchorLeg); set => body.maxAnchorLeg = value.Layout; }
     
    public YesNo HasFlexLeg { get => body.hasFlexLeg; set => body.hasFlexLeg = value; }
     
    public YesNo HasHedgeLeg { get => body.hasHedgeLeg; set => body.hasHedgeLeg = value; }
     
    public BuySell StockLegSide { get => body.stockLegSide; set => body.stockLegSide = value; }
     
    public BuySell FutureLegSide { get => body.futureLegSide; set => body.futureLegSide = value; }
     /// <summary>Synthetic = (+C/-P), RevCon = (+C/-P/-S), Box = (+C/-P) &amp; (-C/+P), CoveredSingle=(+C/-S) | (+P/+S), Straddle = (+C/+P), Vertical = SameExpiry, Horizontal = SameStrike, Mixed = Other</summary>
    public StrategyClass StrategyClass { get => body.strategyClass; set => body.strategyClass = value; }
     
    public byte NumOptLegs { get => body.numOptLegs; set => body.numOptLegs = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>PTP timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SpreadExchPrint


/// <summary>
/// StockBookQuote:3000
/// </summary>
/// <remarks>
	/// This table contains live equity quote records for all CQS/UQDF securities as well as US OTC equity securities, SpiderRock synthetic markets, and a number of major indexes.  Each record contains up to two price levels and represents a live snapshot of the book for a specific market./// </remarks>

public partial class StockBookQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockBookQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockBookQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public UpdateType updateType;
		public MarketStatus marketStatus;
		public float bidPrice1;
		public int bidSize1;
		public StkExch bidExch1;
		public uint bidMask1;
		public float askPrice1;
		public int askSize1;
		public StkExch askExch1;
		public uint askMask1;
		public float bidPrice2;
		public int bidSize2;
		public StkExch bidExch2;
		public uint bidMask2;
		public float askPrice2;
		public int askSize2;
		public StkExch askExch2;
		public uint askMask2;
		public uint haltMask;
		public long srcTimestamp;
		public long netTimestamp;
    }

    internal BodyLayout body;

    
    public UpdateType UpdateType { get => body.updateType; set => body.updateType = value; }
     /// <summary>market status (open, halted, etc)</summary>
    public MarketStatus MarketStatus { get => body.marketStatus; set => body.marketStatus = value; }
     /// <summary>bid price for best price level</summary>
    public float BidPrice1 { get => body.bidPrice1; set => body.bidPrice1 = value; }
     /// <summary>bid size for best price level</summary>
    public int BidSize1 { get => body.bidSize1; set => body.bidSize1 = value; }
     
    public StkExch BidExch1 { get => body.bidExch1; set => body.bidExch1 = value; }
     /// <summary>bid exchange bit mask for best bid price level</summary>
    public uint BidMask1 { get => body.bidMask1; set => body.bidMask1 = value; }
     /// <summary>ask price for best price level</summary>
    public float AskPrice1 { get => body.askPrice1; set => body.askPrice1 = value; }
     /// <summary>ask size for best price level</summary>
    public int AskSize1 { get => body.askSize1; set => body.askSize1 = value; }
     /// <summary>exchange</summary>
    public StkExch AskExch1 { get => body.askExch1; set => body.askExch1 = value; }
     /// <summary>ask exchange bit mask for best ask price level</summary>
    public uint AskMask1 { get => body.askMask1; set => body.askMask1 = value; }
     /// <summary>bid price for next best price level</summary>
    public float BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>bid size for next best price level</summary>
    public int BidSize2 { get => body.bidSize2; set => body.bidSize2 = value; }
     /// <summary>exchange</summary>
    public StkExch BidExch2 { get => body.bidExch2; set => body.bidExch2 = value; }
     /// <summary>bid exchange bit mask for next best bid price level</summary>
    public uint BidMask2 { get => body.bidMask2; set => body.bidMask2 = value; }
     /// <summary>ask price for next best price level</summary>
    public float AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>ask size for next best price level</summary>
    public int AskSize2 { get => body.askSize2; set => body.askSize2 = value; }
     /// <summary>exchange</summary>
    public StkExch AskExch2 { get => body.askExch2; set => body.askExch2 = value; }
     /// <summary>ask exchange bit mask for next best ask price level</summary>
    public uint AskMask2 { get => body.askMask2; set => body.askMask2 = value; }
     /// <summary>bit mask of halted exchanges</summary>
    public uint HaltMask { get => body.haltMask; set => body.haltMask = value; }
     /// <summary>source high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch;usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }


} // StockBookQuote


/// <summary>
/// StockExchImbalanceV2:3020
/// </summary>
/// <remarks>
	/// StockExchImbalanceV2 records contain live exchange closing auction imbalance details.  Imbalance information can be available from more than one exchange for each ticker.
	/// Final StockExchImbalanceV2 records are published to the SpiderRock elastic cluster nightly after the auction close./// </remarks>

public partial class StockExchImbalanceV2 : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockExchImbalanceV2 other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockExchImbalanceV2};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
         /// <summary>Projected Auction Time (hhmm).</summary>
        public DateTime AuctionTime { get => body.auctionTime; set => body.auctionTime = value; }
         
        public AuctionReason AuctionType { get => body.auctionType; set => body.auctionType = value; }
         
        public PrimaryExchange Exchange { get => body.exchange; set => body.exchange = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public TickerKeyLayout ticker;
         public DateTimeLayout auctionTime;
         public AuctionReason auctionType;
         public PrimaryExchange exchange;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	ticker.Equals(other.ticker) &&
					 	auctionTime.Equals(other.auctionTime) &&
					 	auctionType.Equals(other.auctionType) &&
					 	exchange.Equals(other.exchange);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();
                 hashCode = (hashCode*397) ^ (auctionTime.GetHashCode());
                 hashCode = (hashCode*397) ^ ((int) auctionType);
                 hashCode = (hashCode*397) ^ ((int) exchange);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
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

    internal BodyLayout body;

    /// <summary>For Pillar-powered markets, the Reference Price is used to calculate the Indicative Match Price.</summary>
    public float ReferencePx { get => body.referencePx; set => body.referencePx = value; }
     /// <summary>For Pillar-powered markets, the number of shares paired off at the Indicative Match Price.</summary>
    public int PairedQty { get => body.pairedQty; set => body.pairedQty = value; }
     /// <summary>For Pillar-powered markets, the total imbalance quantity at the Indicative Match Price.</summary>
    public int TotalImbalanceQty { get => body.totalImbalanceQty; set => body.totalImbalanceQty = value; }
     /// <summary>For Pillar-powered markets, the total market order imbalance quantity at the Indicative Match Price.</summary>
    public int MarketImbalanceQty { get => body.marketImbalanceQty; set => body.marketImbalanceQty = value; }
     /// <summary>The side of the TotalImbalanceQty.</summary>
    public ImbalanceSide ImbalanceSide { get => body.imbalanceSide; set => body.imbalanceSide = value; }
     /// <summary>For Pillar-powered markets, the price at which all interest on the book can trade, including auction and imbalance offset interest, and disregarding auction collars.</summary>
    public float ContinuousBookClrPx { get => body.continuousBookClrPx; set => body.continuousBookClrPx = value; }
     /// <summary>For Pillar-powered markets, the price at which all eligible auction-only interest would trade, subject to auction collars.</summary>
    public float ClosingOnlyClrPx { get => body.closingOnlyClrPx; set => body.closingOnlyClrPx = value; }
     /// <summary>For Pillar-powered markets, not supported and defaulted to 0.</summary>
    public float SsrFillingPx { get => body.ssrFillingPx; set => body.ssrFillingPx = value; }
     /// <summary>For Pillar-powered markets, the price that has the highest executable volume of auction-eligible shares, subject to auction collars. It includes the non-displayed quantity of Reserve Orders.</summary>
    public float IndicativeMatchPx { get => body.indicativeMatchPx; set => body.indicativeMatchPx = value; }
     /// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
    public float UpperCollar { get => body.upperCollar; set => body.upperCollar = value; }
     /// <summary>If the IndicativeMatchPrice is not strictly between the UpperCollar and the LowerCollar, special auction rules apply. See Rule 7.35P for details.</summary>
    public float LowerCollar { get => body.lowerCollar; set => body.lowerCollar = value; }
     /// <summary>Indicates whether the auction will run.</summary>
    public AuctionStatus AuctionStatus { get => body.auctionStatus; set => body.auctionStatus = value; }
     
    public YesNo FreezeStatus { get => body.freezeStatus; set => body.freezeStatus = value; }
     /// <summary>Number of times the halt period has been extended.</summary>
    public byte NumExtensions { get => body.numExtensions; set => body.numExtensions = value; }
     /// <summary>PTP timestamp</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }


} // StockExchImbalanceV2


/// <summary>
/// StockImbalance:3035
/// </summary>
/// <remarks>
	/// StockImbalance records contain live exchange closing auction imbalance details.  Imbalance information in aggregated across exchanges with imbalance feeds.
	/// Final StockImbalance records are published to the SpiderRock elastic cluster nightly after the auction close./// </remarks>

public partial class StockImbalance : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public StockImbalance()
    {
    }
    
    public StockImbalance(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public StockImbalance(StockImbalance source)
    {
        source.CopyTo(this);
    }
    
    internal StockImbalance(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as StockImbalance);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockImbalance other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(StockImbalance target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockImbalance};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }
         /// <summary>Opening/Closing</summary>
        public AuctionReason AuctionType { get => body.auctionType; set => body.auctionType = value; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public TickerKeyLayout ticker;
         public AuctionReason auctionType;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	ticker.Equals(other.ticker) &&
					 	auctionType.Equals(other.auctionType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();
                 hashCode = (hashCode*397) ^ ((int) auctionType);

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public DateTimeLayout auctionTime;
		public int maxImbalance;
		public StkExch maxImbalanceExch;
		public double maxImbalanceMatchPx;
		public AuctionStatus maxImbalanceStatus;
		public int cumBidImbalanceMkt;
		public int cumAskImbalanceMkt;
		public int cumBidImbalanceTot;
		public int cumAskImbalanceTot;
		public int cumPairedQty;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public DateTime AuctionTime { get => body.auctionTime; set => body.auctionTime = value; }
     
    public int MaxImbalance { get => body.maxImbalance; set => body.maxImbalance = value; }
     
    public StkExch MaxImbalanceExch { get => body.maxImbalanceExch; set => body.maxImbalanceExch = value; }
     
    public double MaxImbalanceMatchPx { get => body.maxImbalanceMatchPx; set => body.maxImbalanceMatchPx = value; }
     
    public AuctionStatus MaxImbalanceStatus { get => body.maxImbalanceStatus; set => body.maxImbalanceStatus = value; }
     
    public int CumBidImbalanceMkt { get => body.cumBidImbalanceMkt; set => body.cumBidImbalanceMkt = value; }
     
    public int CumAskImbalanceMkt { get => body.cumAskImbalanceMkt; set => body.cumAskImbalanceMkt = value; }
     
    public int CumBidImbalanceTot { get => body.cumBidImbalanceTot; set => body.cumBidImbalanceTot = value; }
     
    public int CumAskImbalanceTot { get => body.cumAskImbalanceTot; set => body.cumAskImbalanceTot = value; }
     
    public int CumPairedQty { get => body.cumPairedQty; set => body.cumPairedQty = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // StockImbalance


/// <summary>
/// StockMarketSummary:3040
/// </summary>
/// <remarks>
	/// These records represent live market summary snapshots for equity, index, and synthetic markets./// </remarks>

public partial class StockMarketSummary : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockMarketSummary other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockMarketSummary};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public double opnPrice;
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

    internal BodyLayout body;

    /// <summary>first print price of the day during regular market hours</summary>
    public double OpnPrice { get => body.opnPrice; set => body.opnPrice = value; }
     /// <summary>last print handled during regular market hours</summary>
    public double MrkPrice { get => body.mrkPrice; set => body.mrkPrice = value; }
     /// <summary>official exchange closing price</summary>
    public double ClsPrice { get => body.clsPrice; set => body.clsPrice = value; }
     /// <summary>minimum print price within market hours</summary>
    public double MinPrice { get => body.minPrice; set => body.minPrice = value; }
     /// <summary>maximum print price within market hours</summary>
    public double MaxPrice { get => body.maxPrice; set => body.maxPrice = value; }
     /// <summary>shares outstanding</summary>
    public int SharesOutstanding { get => body.sharesOutstanding; set => body.sharesOutstanding = value; }
     /// <summary>num prints &lt;= quote.bid</summary>
    public int BidCount { get => body.bidCount; set => body.bidCount = value; }
     /// <summary>volume when prtPrice &lt;= quote.bid</summary>
    public int BidVolume { get => body.bidVolume; set => body.bidVolume = value; }
     /// <summary>num prints &gt;= quote.ask</summary>
    public int AskCount { get => body.askCount; set => body.askCount = value; }
     /// <summary>volume when prtPrice &gt;= quote.ask</summary>
    public int AskVolume { get => body.askVolume; set => body.askVolume = value; }
     /// <summary>num prints inside quote.bid / quote.ask</summary>
    public int MidCount { get => body.midCount; set => body.midCount = value; }
     /// <summary>volume inside quote.bid / quote.ask</summary>
    public int MidVolume { get => body.midVolume; set => body.midVolume = value; }
     /// <summary>number of distinct print reports</summary>
    public int PrtCount { get => body.prtCount; set => body.prtCount = value; }
     /// <summary>last print price</summary>
    public double PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>number of updates included in exponential average</summary>
    public int ExpCount { get => body.expCount; set => body.expCount = value; }
     /// <summary>exponential average market width (10 minute 1/2 life)</summary>
    public double ExpWidth { get => body.expWidth; set => body.expWidth = value; }
     /// <summary>exponential average bid size (10 minute 1/2 life)</summary>
    public float ExpBidSize { get => body.expBidSize; set => body.expBidSize = value; }
     /// <summary>exponential average ask size (10 minute 1/2 life)</summary>
    public float ExpAskSize { get => body.expAskSize; set => body.expAskSize = value; }
     
    public DateTime LastPrint { get => body.lastPrint; set => body.lastPrint = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // StockMarketSummary


/// <summary>
/// StockPrint:3045
/// </summary>
/// <remarks>
	/// The most recent (last) print record for CTS/UTDF markets as well as SpiderRock synthetic markets.  Records also incorporate some summary detail and closing mark information as well./// </remarks>

public partial class StockPrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockPrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockPrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
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
		public int ebsz;
		public int easz;
		public float eage;
		public PrtSide prtSide;
		public long prtTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>print exch</summary>
    public StkExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price level</summary>
    public float PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>incremental print cluster counter (one counter per ticker; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>cumulative print size today</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>last regular market print price</summary>
    public float MrkPrice { get => body.mrkPrice; set => body.mrkPrice = value; }
     /// <summary>official closing price (if available)</summary>
    public float ClsPrice { get => body.clsPrice; set => body.clsPrice = value; }
     
    public StkPrintType PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>print condition (from SIP feed)</summary>
    public byte PrtCond1 { get => body.prtCond1; set => body.prtCond1 = value; }
     
    public byte PrtCond2 { get => body.prtCond2; set => body.prtCond2 = value; }
     
    public byte PrtCond3 { get => body.prtCond3; set => body.prtCond3 = value; }
     
    public byte PrtCond4 { get => body.prtCond4; set => body.prtCond4 = value; }
     /// <summary>exchange bid (@ print time) [SIP feed]</summary>
    public float Ebid { get => body.ebid; set => body.ebid = value; }
     /// <summary>exchange ask (@ print time) [SIP feed]</summary>
    public float Eask { get => body.eask; set => body.eask = value; }
     /// <summary>exchange bid size</summary>
    public int Ebsz { get => body.ebsz; set => body.ebsz = value; }
     /// <summary>exchange ask size</summary>
    public int Easz { get => body.easz; set => body.easz = value; }
     /// <summary>age of prevailing quote at time of print</summary>
    public float Eage { get => body.eage; set => body.eage = value; }
     
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long PrtTimestamp { get => body.prtTimestamp; set => body.prtTimestamp = value; }
     /// <summary>inbound packet PTP timestamp from SR gateway switch; usually syncronized with facility grandfather clock</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // StockPrint


/// <summary>
/// StockPrintMarkup:3055
/// </summary>
/// <remarks>
	/// StockPrintMarkup records are created/published for all stock prints/// </remarks>

public partial class StockPrintMarkup : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public StockPrintMarkup()
    {
    }
    
    public StockPrintMarkup(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public StockPrintMarkup(StockPrintMarkup source)
    {
        source.CopyTo(this);
    }
    
    internal StockPrintMarkup(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as StockPrintMarkup);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StockPrintMarkup other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(StockPrintMarkup target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.StockPrintMarkup};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public long prtNumber;
		public StkExch prtExch;
		public int prtSize;
		public float prtPrice;
		public int prtClusterNum;
		public int prtClusterSize;
		public int prtVolume;
		public float mrkPrice;
		public byte prtType;
		public byte prtCond1;
		public byte prtCond2;
		public byte prtCond3;
		public byte prtCond4;
		public PrtSide prtSide;
		public float bidPrice;
		public float askPrice;
		public int bidSize;
		public int askSize;
		public float bidPrice2;
		public float askPrice2;
		public int bidSize2;
		public int askSize2;
		public long srcTimestamp;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public long PrtNumber { get => body.prtNumber; set => body.prtNumber = value; }
     /// <summary>print exch</summary>
    public StkExch PrtExch { get => body.prtExch; set => body.prtExch = value; }
     /// <summary>print size</summary>
    public int PrtSize { get => body.prtSize; set => body.prtSize = value; }
     /// <summary>print price level</summary>
    public float PrtPrice { get => body.prtPrice; set => body.prtPrice = value; }
     /// <summary>incremental print cluster counter (one counter per ticker; used to group prints into clusters)</summary>
    public int PrtClusterNum { get => body.prtClusterNum; set => body.prtClusterNum = value; }
     /// <summary>cumulative size of prints in this sequence (prints @ same or more aggressive price with less than 25 ms elapsing since first print; can span exchanges)</summary>
    public int PrtClusterSize { get => body.prtClusterSize; set => body.prtClusterSize = value; }
     /// <summary>cumulative print size today</summary>
    public int PrtVolume { get => body.prtVolume; set => body.prtVolume = value; }
     /// <summary>last regular market print price</summary>
    public float MrkPrice { get => body.mrkPrice; set => body.mrkPrice = value; }
     /// <summary>OPRA message type (from OPRA spec)</summary>
    public byte PrtType { get => body.prtType; set => body.prtType = value; }
     /// <summary>print condition (from SIP feed)</summary>
    public byte PrtCond1 { get => body.prtCond1; set => body.prtCond1 = value; }
     
    public byte PrtCond2 { get => body.prtCond2; set => body.prtCond2 = value; }
     
    public byte PrtCond3 { get => body.prtCond3; set => body.prtCond3 = value; }
     
    public byte PrtCond4 { get => body.prtCond4; set => body.prtCond4 = value; }
     /// <summary>Print side: None; Mid; Bid; Ask</summary>
    public PrtSide PrtSide { get => body.prtSide; set => body.prtSide = value; }
     /// <summary>nbbo bid @ print arrival time</summary>
    public float BidPrice { get => body.bidPrice; set => body.bidPrice = value; }
     /// <summary>nbbo ask @ print arrival time</summary>
    public float AskPrice { get => body.askPrice; set => body.askPrice = value; }
     
    public int BidSize { get => body.bidSize; set => body.bidSize = value; }
     
    public int AskSize { get => body.askSize; set => body.askSize = value; }
     /// <summary>nbbo 2nd best bid @ print arrival time</summary>
    public float BidPrice2 { get => body.bidPrice2; set => body.bidPrice2 = value; }
     /// <summary>nbbo 2nd best ask @ print arrival time</summary>
    public float AskPrice2 { get => body.askPrice2; set => body.askPrice2 = value; }
     /// <summary>nbbo 2nd best bid size</summary>
    public int BidSize2 { get => body.bidSize2; set => body.bidSize2 = value; }
     /// <summary>nbbo 2nd best ask size</summary>
    public int AskSize2 { get => body.askSize2; set => body.askSize2 = value; }
     /// <summary>exchange high precision timestamp (if available)</summary>
    public long SrcTimestamp { get => body.srcTimestamp; set => body.srcTimestamp = value; }
     /// <summary>inbound print packet PTP timestamp from SR gateway switch</summary>
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // StockPrintMarkup


/// <summary>
/// SyntheticPrint:2690
/// </summary>
/// <remarks>
	/// Live synthetic prints are SpiderRock computed synthetic prints (actual prints in related markets adjusted to match the synthetic instrument)/// </remarks>

public partial class SyntheticPrint : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public SyntheticPrint()
    {
    }
    
    public SyntheticPrint(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public SyntheticPrint(SyntheticPrint source)
    {
        source.CopyTo(this);
    }
    
    internal SyntheticPrint(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as SyntheticPrint);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SyntheticPrint other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(SyntheticPrint target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SyntheticPrint};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public ExpiryKey Ekey { get => ExpiryKey.GetCreateExpiryKey(body.ekey); set => body.ekey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public ExpiryKeyLayout ekey;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	ekey.Equals(other.ekey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ekey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public double printPrice;
		public int printSize;
		public ExpiryKeyLayout prtKey;
		public SpdrKeyType prtSecType;
		public SyntheticSource prtSource;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>synthetic print price (best estimate of adjusted synthetic price)</summary>
    public double PrintPrice { get => body.printPrice; set => body.printPrice = value; }
     /// <summary>print size in the associated market adjusted to match the synthetic basis</summary>
    public int PrintSize { get => body.printSize; set => body.printSize = value; }
     
    public ExpiryKey PrtKey { get => ExpiryKey.GetCreateExpiryKey(body.prtKey); set => body.prtKey = value.Layout; }
     
    public SpdrKeyType PrtSecType { get => body.prtSecType; set => body.prtSecType = value; }
     
    public SyntheticSource PrtSource { get => body.prtSource; set => body.prtSource = value; }
     
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SyntheticPrint


/// <summary>
/// SyntheticQuote:2695
/// </summary>
/// <remarks>
	/// Live synthetic quotes are SpiderRock computed synthetic underlier quotes for options without a market based underlier.  Synthetic quotes are generated for
	/// index options (cash settled options written on an index), and options on futures./// </remarks>

public partial class SyntheticQuote : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public SyntheticQuote()
    {
    }
    
    public SyntheticQuote(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public SyntheticQuote(SyntheticQuote source)
    {
        source.CopyTo(this);
    }
    
    internal SyntheticQuote(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as SyntheticQuote);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SyntheticQuote other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(SyntheticQuote target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.SyntheticQuote};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        /// <summary>option root + expiry</summary>
        public ExpiryKey Ekey { get => ExpiryKey.GetCreateExpiryKey(body.ekey); set => body.ekey = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct PKeyLayout : IEquatable<PKeyLayout>
    {
        public ExpiryKeyLayout ekey;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKeyLayout other)
        {
            return	ekey.Equals(other.ekey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ekey.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public double bidPrice;
		public double askPrice;
		public int bidSize;
		public int askSize;
		public ExpiryKeyLayout bidKey;
		public SpdrKeyType bidKeyType;
		public ExpiryKeyLayout askKey;
		public SpdrKeyType askKeyType;
		public SyntheticSource bidSource;
		public SyntheticSource askSource;
		public double undBidPrice;
		public double undAskPrice;
		public int undBidSize;
		public int undAskSize;
		public ExpiryKeyLayout undKey;
		public SpdrKeyType undKeyType;
		public MarketStatus undMarketStatus;
		public double uOffPrice;
		public ExpiryKeyLayout uOffKey;
		public SpdrKeyType uOffKeyType;
		public long netTimestamp;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>best synthetic bid price</summary>
    public double BidPrice { get => body.bidPrice; set => body.bidPrice = value; }
     /// <summary>best synthetic ask price</summary>
    public double AskPrice { get => body.askPrice; set => body.askPrice = value; }
     /// <summary>best synthetic bid size</summary>
    public int BidSize { get => body.bidSize; set => body.bidSize = value; }
     /// <summary>best synthetic ask size</summary>
    public int AskSize { get => body.askSize; set => body.askSize = value; }
     
    public ExpiryKey BidKey { get => ExpiryKey.GetCreateExpiryKey(body.bidKey); set => body.bidKey = value.Layout; }
     
    public SpdrKeyType BidKeyType { get => body.bidKeyType; set => body.bidKeyType = value; }
     
    public ExpiryKey AskKey { get => ExpiryKey.GetCreateExpiryKey(body.askKey); set => body.askKey = value.Layout; }
     
    public SpdrKeyType AskKeyType { get => body.askKeyType; set => body.askKeyType = value; }
     
    public SyntheticSource BidSource { get => body.bidSource; set => body.bidSource = value; }
     
    public SyntheticSource AskSource { get => body.askSource; set => body.askSource = value; }
     /// <summary>bid price (actual underlier market; if any)</summary>
    public double UndBidPrice { get => body.undBidPrice; set => body.undBidPrice = value; }
     /// <summary>ask price (actual underlier market; if any)</summary>
    public double UndAskPrice { get => body.undAskPrice; set => body.undAskPrice = value; }
     /// <summary>bid size (actual underlier market; if any)</summary>
    public int UndBidSize { get => body.undBidSize; set => body.undBidSize = value; }
     /// <summary>ask size (actual underlier market; if any)</summary>
    public int UndAskSize { get => body.undAskSize; set => body.undAskSize = value; }
     
    public ExpiryKey UndKey { get => ExpiryKey.GetCreateExpiryKey(body.undKey); set => body.undKey = value.Layout; }
     
    public SpdrKeyType UndKeyType { get => body.undKeyType; set => body.undKeyType = value; }
     
    public MarketStatus UndMarketStatus { get => body.undMarketStatus; set => body.undMarketStatus = value; }
     /// <summary>uOffKey: 0.5 * (bid + ask) + uOffsetEMA (From LiveAtmVol/LiveSurfaceCurve)</summary>
    public double UOffPrice { get => body.uOffPrice; set => body.uOffPrice = value; }
     /// <summary>copied from LiveSurfaceCurve.fkey</summary>
    public ExpiryKey UOffKey { get => ExpiryKey.GetCreateExpiryKey(body.uOffKey); set => body.uOffKey = value.Layout; }
     
    public SpdrKeyType UOffKeyType { get => body.uOffKeyType; set => body.uOffKeyType = value; }
     
    public long NetTimestamp { get => body.netTimestamp; set => body.netTimestamp = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // SyntheticQuote


/// <summary>
/// TickerDefinitionExt:4380
/// </summary>
/// <remarks>
/// </remarks>

public partial class TickerDefinitionExt : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    public TickerDefinitionExt()
    {
    }
    
    public TickerDefinitionExt(PKey pkey)
    {
        this.pkey.body = pkey.body;
    }
    
    public TickerDefinitionExt(TickerDefinitionExt source)
    {
        source.CopyTo(this);
    }
    
    internal TickerDefinitionExt(PKeyLayout pkey)
    {
        this.pkey.body = pkey;
    }

    public override bool Equals(object other)
    {
        return Equals(other as TickerDefinitionExt);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(TickerDefinitionExt other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return pkey.Equals(other.pkey);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return pkey.GetHashCode();
    }
    
    public override string ToString()
    {
        return TabRecord;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(TickerDefinitionExt target)
    {			
        target.header = header;
         pkey.CopyTo(target.pkey);
         target.body = body;

    }

    public void Clear()
    {
        pkey.Clear();
         body = new BodyLayout();

    }

    public PKey Key => pkey;
    
    internal SourceId SourceId => header.sourceid;

    internal Header header = new() {msgtype = MessageType.TickerDefinitionExt};
    
     public sealed class PKey : IEquatable<PKey>, ICloneable
    {

        internal PKeyLayout body;
        
        public PKey()					{ }

        internal PKey(PKeyLayout body)	=> this.body = body;

        public PKey(PKey other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            body = other.body;
				
        }
        
        
        public TickerKey Ticker { get => TickerKey.GetCreateTickerKey(body.ticker); set => body.ticker = value.Layout; }

        public void Clear()
        {
            body = new PKeyLayout();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(PKey target)
        {
            target.body = body;

        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone()
        {
            var target = new PKey(body);

            return target;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PKey other && Equals(other);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PKey other) => other is not null && body.Equals(other.body);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => body.GetHashCode();
    } 

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
        public override bool Equals(object obj) => obj is PKeyLayout other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ticker.GetHashCode();

                return hashCode;
            }
        }
    }

    internal readonly PKey pkey = new();
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public SymbolType symbolType;
		public FixedString72Layout name;
		public FixedString72Layout issuerName;
		public FixedString2Layout cntryOfIncorp;
		public float parValue;
		public FixedString3Layout parValueCurrency;
		public float pointValue;
		public Currency pointCurrency;
		public PrimaryExchange primaryExch;
		public int altID;
		public FixedString4Layout mic;
		public FixedString4Layout micSeg;
		public FixedString12Layout symbol;
		public FixedString1Layout issueClass;
		public int securityID;
		public FixedString4Layout sic;
		public FixedString10Layout cik;
		public FixedString8Layout gics;
		public FixedString20Layout lei;
		public FixedString6Layout naics;
		public FixedString6Layout cfi;
		public FixedString4Layout cic;
		public FixedString40Layout fisn;
		public FixedString12Layout isin;
		public FixedString12Layout bbgCompositeTicker;
		public FixedString28Layout bbgExchangeTicker;
		public FixedString12Layout bbgCompositeGlobalID;
		public FixedString12Layout bbgGlobalID;
		public FixedString3Layout bbgCurrency;
		public StkPriceInc stkPriceInc;
		public float stkVolume;
		public float futVolume;
		public float optVolume;
		public FixedString8Layout exchString;
		public YesNo hasOptions;
		public int numOptions;
		public int sharesOutstanding;
		public TimeMetric timeMetric;
		public OTCPrimaryMarket otcPrimaryMarket;
		public OTCTier otcTier;
		public FixedString1Layout otcReportingStatus;
		public int otcDisclosureStatus;
		public int otcFlags;
		public TkDefSource tkDefSource;
		public TkStatusFlag statusFlag;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public SymbolType SymbolType { get => body.symbolType; set => body.symbolType = value; }
     /// <summary>Symbol name</summary>
    public string Name { get => body.name; set => body.name = value; }
     /// <summary>Name of issuer</summary>
    public string IssuerName { get => body.issuerName; set => body.issuerName = value; }
     /// <summary>ISO Issuer Country Code</summary>
    public string CntryOfIncorp { get => body.cntryOfIncorp; set => body.cntryOfIncorp = value; }
     /// <summary>Security Parvalue</summary>
    public float ParValue { get => body.parValue; set => body.parValue = value; }
     /// <summary>Security Parvalue currency</summary>
    public string ParValueCurrency { get => body.parValueCurrency; set => body.parValueCurrency = value; }
     
    public float PointValue { get => body.pointValue; set => body.pointValue = value; }
     
    public Currency PointCurrency { get => body.pointCurrency; set => body.pointCurrency = value; }
     
    public PrimaryExchange PrimaryExch { get => body.primaryExch; set => body.primaryExch = value; }
     /// <summary>Alt Security ID number</summary>
    public int AltID { get => body.altID; set => body.altID = value; }
     /// <summary>ISO Market Identification Code</summary>
    public string Mic { get => body.mic; set => body.mic = value; }
     /// <summary>ISO Market Indentification Segment Code</summary>
    public string MicSeg { get => body.micSeg; set => body.micSeg = value; }
     /// <summary>stock symbol</summary>
    public string Symbol { get => body.symbol; set => body.symbol = value; }
     /// <summary>issue class of stock symbol.  if no issue class field will be blank.</summary>
    public string IssueClass { get => body.issueClass; set => body.issueClass = value; }
     /// <summary>Security ID number from the source - Vendor, SR, Feed</summary>
    public int SecurityID { get => body.securityID; set => body.securityID = value; }
     /// <summary>SIC (Standard Industrial Classification) code</summary>
    public string Sic { get => body.sic; set => body.sic = value; }
     /// <summary>Central Index Key (US specific)</summary>
    public string Cik { get => body.cik; set => body.cik = value; }
     /// <summary>Global Industry Classification Standard</summary>
    public string Gics { get => body.gics; set => body.gics = value; }
     /// <summary>Legal Entity Identifier</summary>
    public string Lei { get => body.lei; set => body.lei = value; }
     /// <summary>North American Industry Classification System</summary>
    public string Naics { get => body.naics; set => body.naics = value; }
     /// <summary>ISO Classification of Financial Instruments</summary>
    public string Cfi { get => body.cfi; set => body.cfi = value; }
     /// <summary>Complementay Identification Code</summary>
    public string Cic { get => body.cic; set => body.cic = value; }
     /// <summary>Financial Instrument Short Name</summary>
    public string Fisn { get => body.fisn; set => body.fisn = value; }
     /// <summary>ISIN code</summary>
    public string Isin { get => body.isin; set => body.isin = value; }
     /// <summary>Bloomberg Composite Ticker</summary>
    public string BbgCompositeTicker { get => body.bbgCompositeTicker; set => body.bbgCompositeTicker = value; }
     /// <summary>Bloomberg Exchange Ticker</summary>
    public string BbgExchangeTicker { get => body.bbgExchangeTicker; set => body.bbgExchangeTicker = value; }
     /// <summary>Bloomberg Composite Global ID</summary>
    public string BbgCompositeGlobalID { get => body.bbgCompositeGlobalID; set => body.bbgCompositeGlobalID = value; }
     /// <summary>Bloomberg Global ID</summary>
    public string BbgGlobalID { get => body.bbgGlobalID; set => body.bbgGlobalID = value; }
     /// <summary>Bloomberg Trading Currency</summary>
    public string BbgCurrency { get => body.bbgCurrency; set => body.bbgCurrency = value; }
     /// <summary>Price increment: None; FullPenny; Nickle</summary>
    public StkPriceInc StkPriceInc { get => body.stkPriceInc; set => body.stkPriceInc = value; }
     /// <summary>trailing average daily stock volume</summary>
    public float StkVolume { get => body.stkVolume; set => body.stkVolume = value; }
     /// <summary>trailing average daily future volume</summary>
    public float FutVolume { get => body.futVolume; set => body.futVolume = value; }
     /// <summary>trailing average daily option volume</summary>
    public float OptVolume { get => body.optVolume; set => body.optVolume = value; }
     /// <summary>exchanges listing any options on this underlying</summary>
    public string ExchString { get => body.exchString; set => body.exchString = value; }
     /// <summary>Has Options flag</summary>
    public YesNo HasOptions { get => body.hasOptions; set => body.hasOptions = value; }
     /// <summary>total number of listed options</summary>
    public int NumOptions { get => body.numOptions; set => body.numOptions = value; }
     /// <summary>symbol shares outstanding, represented in thousands (actualsharesoutstanding = sharesoutstanding * 1000)</summary>
    public int SharesOutstanding { get => body.sharesOutstanding; set => body.sharesOutstanding = value; }
     /// <summary>trading time metric - 252 or 365 trading days or a weekly cycle type</summary>
    public TimeMetric TimeMetric { get => body.timeMetric; set => body.timeMetric = value; }
     
    public OTCPrimaryMarket OtcPrimaryMarket { get => body.otcPrimaryMarket; set => body.otcPrimaryMarket = value; }
     
    public OTCTier OtcTier { get => body.otcTier; set => body.otcTier = value; }
     
    public string OtcReportingStatus { get => body.otcReportingStatus; set => body.otcReportingStatus = value; }
     
    public int OtcDisclosureStatus { get => body.otcDisclosureStatus; set => body.otcDisclosureStatus = value; }
     
    public int OtcFlags { get => body.otcFlags; set => body.otcFlags = value; }
     /// <summary>Ticker definition source: None; Vendor; OTC; SR; Exchange</summary>
    public TkDefSource TkDefSource { get => body.tkDefSource; set => body.tkDefSource = value; }
     
    public TkStatusFlag StatusFlag { get => body.statusFlag; set => body.statusFlag = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // TickerDefinitionExt


/// <summary>
/// MLinkCacheRequest:3355
/// </summary>
/// <remarks>
/// </remarks>

internal partial class MLinkCacheRequest : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    internal Header header = new() {msgtype = MessageType.MLinkCacheRequest};
     

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class MsgTypeItem
    {
        public const int Length = 10;

        public MsgTypeItem() { }
        
        public MsgTypeItem(ushort msgType, long schemaHash)
        {
            this.MsgType = msgType;
			this.SchemaHash = schemaHash;
        }

        public ushort MsgType { get; internal set; }
		public long SchemaHash { get; internal set; }
    }

    public MsgTypeItem[] MsgTypeList { get; set; }

     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public AppNameString queryLabel;
		public long highwaterTs;
		public ushort sourceId;
		public FixedString32Layout stripe;
    }

    internal BodyLayout body;

    /// <summary>query label (optional)</summary>
    public string QueryLabel { get => body.queryLabel; set => body.queryLabel = value; }
     /// <summary>(optional) records must have a header.sentTs that is later than this value (nanoseconds after the UNIX epoch)</summary>
    public long HighwaterTs { get => body.highwaterTs; set => body.highwaterTs = value; }
     /// <summary>message.appId must match if &gt; 0</summary>
    public ushort SourceId { get => body.sourceId; set => body.sourceId = value; }
     /// <summary>message.stripe must be in stripe list (if exists)</summary>
    public string Stripe { get => body.stripe; set => body.stripe = value; }


} // MLinkCacheRequest


/// <summary>
/// MLinkStreamCheckPt:3382
/// </summary>
/// <remarks>
/// </remarks>

internal partial class MLinkStreamCheckPt : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    internal Header header = new() {msgtype = MessageType.MLinkStreamCheckPt};
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public short sessionID;
		public long queryID;
		public long signalID;
		public MLinkStreamState state;
		public long highwaterTs;
		public long numBytesSent;
		public int numMessagesSent;
		public double waitElapsed;
		public double queryElapsed;
		public double tryFwdElapsed;
		public double sendElapsed;
		public double flushElapsed;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    /// <summary>from MLinkStream.sessionID</summary>
    public short SessionID { get => body.sessionID; set => body.sessionID = value; }
     /// <summary>from MLinkStream.queryID</summary>
    public long QueryID { get => body.queryID; set => body.queryID = value; }
     /// <summary>from MLinkSignalReady.signalID (if send sequence triggered by an MLinkSignalReady message)</summary>
    public long SignalID { get => body.signalID; set => body.signalID = value; }
     
    public MLinkStreamState State { get => body.state; set => body.state = value; }
     
    public string Detail { get; set; } = string.Empty;
     
    public long HighwaterTs { get => body.highwaterTs; set => body.highwaterTs = value; }
     
    public long NumBytesSent { get => body.numBytesSent; set => body.numBytesSent = value; }
     
    public int NumMessagesSent { get => body.numMessagesSent; set => body.numMessagesSent = value; }
     /// <summary>wait time between active send operations (SRC or timer)</summary>
    public double WaitElapsed { get => body.waitElapsed; set => body.waitElapsed = value; }
     /// <summary>total time spent in active send loop</summary>
    public double QueryElapsed { get => body.queryElapsed; set => body.queryElapsed = value; }
     /// <summary>total time spent scan/skipping</summary>
    public double TryFwdElapsed { get => body.tryFwdElapsed; set => body.tryFwdElapsed = value; }
     /// <summary>total time spend encoding/copying to send buffer</summary>
    public double SendElapsed { get => body.sendElapsed; set => body.sendElapsed = value; }
     /// <summary>total time spend sending/blocking on web socket</summary>
    public double FlushElapsed { get => body.flushElapsed; set => body.flushElapsed = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // MLinkStreamCheckPt


/// <summary>
/// NetPulse:5900
/// </summary>
/// <remarks>
/// </remarks>

internal partial class NetPulse : IMessage
{
    #region IMessage implementation

    public DateTime Received => new(unchecked(ReceivedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public DateTime Published => new(unchecked(PublishedNsecsSinceUnixEpoch/100 + DateTime.UnixEpoch.Ticks), DateTimeKind.Utc);

    public long ReceivedNsecsSinceUnixEpoch { get; internal set; }
    
    public long PublishedNsecsSinceUnixEpoch => header.sentts;

    public bool FromCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (header.bits & HeaderBits.FromCache) == HeaderBits.FromCache;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal set
        {
            if (value)
            {
                header.bits |= HeaderBits.FromCache;
            }
            else
            {
                header.bits &= ~HeaderBits.FromCache;
            }
        }
    }

    public ushort Type => header.msgtype;

    #endregion

    internal Header header = new() {msgtype = MessageType.NetPulse};
     
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct BodyLayout
    {
        public TimeSpanLayout frequency;
		public TimeSpanLayout timeout;
		public DateTimeLayout timestamp;
    }

    internal BodyLayout body;

    
    public TimeSpan Frequency { get => body.frequency; set => body.frequency = value; }
     
    public TimeSpan Timeout { get => body.timeout; set => body.timeout = value; }
     
    public DateTime Timestamp { get => body.timestamp; set => body.timestamp = value; }


} // NetPulse

