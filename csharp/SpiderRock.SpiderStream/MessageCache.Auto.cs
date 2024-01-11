// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

internal sealed partial class MessageCache : IFrameHandler
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryHandle(ref Frame frame)
    {
        var header = MemoryMarshal.AsRef<Mbus.Header>(frame.Payload);

        return (int)header.msgtype switch
        {
            /* FutureBookQuote */ 2580 => futureBookQuote.TryHandle(ref frame),
            /* FuturePrint */ 2595 => futurePrint.TryHandle(ref frame),
            /* FuturePrintMarkup */ 2605 => futurePrintMarkup.TryHandle(ref frame),
            /* IndexQuote */ 2675 => indexQuote.TryHandle(ref frame),
            /* LiveImpliedQuote */ 1015 => liveImpliedQuote.TryHandle(ref frame),
            /* LiveSurfaceAtm */ 1030 => liveSurfaceAtm.TryHandle(ref frame),
            /* OptionCloseMark */ 3140 => optionCloseMark.TryHandle(ref frame),
            /* OptionExchOrder */ 2765 => optionExchOrder.TryHandle(ref frame),
            /* OptionExchPrint */ 2770 => optionExchPrint.TryHandle(ref frame),
            /* OptionMarketSummary */ 2780 => optionMarketSummary.TryHandle(ref frame),
            /* OptionNbboQuote */ 2785 => optionNbboQuote.TryHandle(ref frame),
            /* OptionOpenInterest */ 3230 => optionOpenInterest.TryHandle(ref frame),
            /* OptionPrint */ 2800 => optionPrint.TryHandle(ref frame),
            /* OptionPrint2 */ 2805 => optionPrint2.TryHandle(ref frame),
            /* OptionPrintMarkup */ 2810 => optionPrintMarkup.TryHandle(ref frame),
            /* OptionRiskFactor */ 1095 => optionRiskFactor.TryHandle(ref frame),
            /* ProductDefinitionV2 */ 4360 => productDefinitionV2.TryHandle(ref frame),
            /* RootDefinition */ 4365 => rootDefinition.TryHandle(ref frame),
            /* SpdrAuctionState */ 2525 => spdrAuctionState.TryHandle(ref frame),
            /* SpreadBookQuote */ 2900 => spreadBookQuote.TryHandle(ref frame),
            /* SpreadExchOrder */ 2915 => spreadExchOrder.TryHandle(ref frame),
            /* SpreadExchPrint */ 2920 => spreadExchPrint.TryHandle(ref frame),
            /* StockBookQuote */ 3000 => stockBookQuote.TryHandle(ref frame),
            /* StockExchImbalanceV2 */ 3020 => stockExchImbalanceV2.TryHandle(ref frame),
            /* StockImbalance */ 3035 => stockImbalance.TryHandle(ref frame),
            /* StockMarketSummary */ 3040 => stockMarketSummary.TryHandle(ref frame),
            /* StockPrint */ 3045 => stockPrint.TryHandle(ref frame),
            /* StockPrintMarkup */ 3055 => stockPrintMarkup.TryHandle(ref frame),
            /* SyntheticExpiryQuote */ 2700 => syntheticExpiryQuote.TryHandle(ref frame),
            /* SyntheticFutureQuote */ 2695 => syntheticFutureQuote.TryHandle(ref frame),
            /* TickerDefinitionExt */ 4380 => tickerDefinitionExt.TryHandle(ref frame),
            _ => false
        };
    }

    public IEnumerable<MessageType> WithEventHandlers
    {
        get
        {
            if (futureBookQuote.HasEventHandlers) yield return (MessageType)2580;
            if (futurePrint.HasEventHandlers) yield return (MessageType)2595;
            if (futurePrintMarkup.HasEventHandlers) yield return (MessageType)2605;
            if (indexQuote.HasEventHandlers) yield return (MessageType)2675;
            if (liveImpliedQuote.HasEventHandlers) yield return (MessageType)1015;
            if (liveSurfaceAtm.HasEventHandlers) yield return (MessageType)1030;
            if (optionCloseMark.HasEventHandlers) yield return (MessageType)3140;
            if (optionExchOrder.HasEventHandlers) yield return (MessageType)2765;
            if (optionExchPrint.HasEventHandlers) yield return (MessageType)2770;
            if (optionMarketSummary.HasEventHandlers) yield return (MessageType)2780;
            if (optionNbboQuote.HasEventHandlers) yield return (MessageType)2785;
            if (optionOpenInterest.HasEventHandlers) yield return (MessageType)3230;
            if (optionPrint.HasEventHandlers) yield return (MessageType)2800;
            if (optionPrint2.HasEventHandlers) yield return (MessageType)2805;
            if (optionPrintMarkup.HasEventHandlers) yield return (MessageType)2810;
            if (optionRiskFactor.HasEventHandlers) yield return (MessageType)1095;
            if (productDefinitionV2.HasEventHandlers) yield return (MessageType)4360;
            if (rootDefinition.HasEventHandlers) yield return (MessageType)4365;
            if (spdrAuctionState.HasEventHandlers) yield return (MessageType)2525;
            if (spreadBookQuote.HasEventHandlers) yield return (MessageType)2900;
            if (spreadExchOrder.HasEventHandlers) yield return (MessageType)2915;
            if (spreadExchPrint.HasEventHandlers) yield return (MessageType)2920;
            if (stockBookQuote.HasEventHandlers) yield return (MessageType)3000;
            if (stockExchImbalanceV2.HasEventHandlers) yield return (MessageType)3020;
            if (stockImbalance.HasEventHandlers) yield return (MessageType)3035;
            if (stockMarketSummary.HasEventHandlers) yield return (MessageType)3040;
            if (stockPrint.HasEventHandlers) yield return (MessageType)3045;
            if (stockPrintMarkup.HasEventHandlers) yield return (MessageType)3055;
            if (syntheticExpiryQuote.HasEventHandlers) yield return (MessageType)2700;
            if (syntheticFutureQuote.HasEventHandlers) yield return (MessageType)2695;
            if (tickerDefinitionExt.HasEventHandlers) yield return (MessageType)4380;
        }
    }

    private readonly FutureBookQuoteCache futureBookQuote = new();
    private readonly FuturePrintCache futurePrint = new();
    private readonly FuturePrintMarkupCache futurePrintMarkup = new();
    private readonly IndexQuoteCache indexQuote = new();
    private readonly LiveImpliedQuoteCache liveImpliedQuote = new();
    private readonly LiveSurfaceAtmCache liveSurfaceAtm = new();
    private readonly OptionCloseMarkCache optionCloseMark = new();
    private readonly OptionExchOrderCache optionExchOrder = new();
    private readonly OptionExchPrintCache optionExchPrint = new();
    private readonly OptionMarketSummaryCache optionMarketSummary = new();
    private readonly OptionNbboQuoteCache optionNbboQuote = new();
    private readonly OptionOpenInterestCache optionOpenInterest = new();
    private readonly OptionPrintCache optionPrint = new();
    private readonly OptionPrint2Cache optionPrint2 = new();
    private readonly OptionPrintMarkupCache optionPrintMarkup = new();
    private readonly OptionRiskFactorCache optionRiskFactor = new();
    private readonly ProductDefinitionV2Cache productDefinitionV2 = new();
    private readonly RootDefinitionCache rootDefinition = new();
    private readonly SpdrAuctionStateCache spdrAuctionState = new();
    private readonly SpreadBookQuoteCache spreadBookQuote = new();
    private readonly SpreadExchOrderCache spreadExchOrder = new();
    private readonly SpreadExchPrintCache spreadExchPrint = new();
    private readonly StockBookQuoteCache stockBookQuote = new();
    private readonly StockExchImbalanceV2Cache stockExchImbalanceV2 = new();
    private readonly StockImbalanceCache stockImbalance = new();
    private readonly StockMarketSummaryCache stockMarketSummary = new();
    private readonly StockPrintCache stockPrint = new();
    private readonly StockPrintMarkupCache stockPrintMarkup = new();
    private readonly SyntheticExpiryQuoteCache syntheticExpiryQuote = new();
    private readonly SyntheticFutureQuoteCache syntheticFutureQuote = new();
    private readonly TickerDefinitionExtCache tickerDefinitionExt = new();

    public IMessageEvents<FutureBookQuote> FutureBookQuote => futureBookQuote;
    public IMessageEvents<FuturePrint> FuturePrint => futurePrint;
    public IMessageEvents<FuturePrintMarkup> FuturePrintMarkup => futurePrintMarkup;
    public IMessageEvents<IndexQuote> IndexQuote => indexQuote;
    public IMessageEvents<LiveImpliedQuote> LiveImpliedQuote => liveImpliedQuote;
    public IMessageEvents<LiveSurfaceAtm> LiveSurfaceAtm => liveSurfaceAtm;
    public IMessageEvents<OptionCloseMark> OptionCloseMark => optionCloseMark;
    public IMessageEvents<OptionExchOrder> OptionExchOrder => optionExchOrder;
    public IMessageEvents<OptionExchPrint> OptionExchPrint => optionExchPrint;
    public IMessageEvents<OptionMarketSummary> OptionMarketSummary => optionMarketSummary;
    public IMessageEvents<OptionNbboQuote> OptionNbboQuote => optionNbboQuote;
    public IMessageEvents<OptionOpenInterest> OptionOpenInterest => optionOpenInterest;
    public IMessageEvents<OptionPrint> OptionPrint => optionPrint;
    public IMessageEvents<OptionPrint2> OptionPrint2 => optionPrint2;
    public IMessageEvents<OptionPrintMarkup> OptionPrintMarkup => optionPrintMarkup;
    public IMessageEvents<OptionRiskFactor> OptionRiskFactor => optionRiskFactor;
    public IMessageEvents<ProductDefinitionV2> ProductDefinitionV2 => productDefinitionV2;
    public IMessageEvents<RootDefinition> RootDefinition => rootDefinition;
    public IMessageEvents<SpdrAuctionState> SpdrAuctionState => spdrAuctionState;
    public IMessageEvents<SpreadBookQuote> SpreadBookQuote => spreadBookQuote;
    public IMessageEvents<SpreadExchOrder> SpreadExchOrder => spreadExchOrder;
    public IMessageEvents<SpreadExchPrint> SpreadExchPrint => spreadExchPrint;
    public IMessageEvents<StockBookQuote> StockBookQuote => stockBookQuote;
    public IMessageEvents<StockExchImbalanceV2> StockExchImbalanceV2 => stockExchImbalanceV2;
    public IMessageEvents<StockImbalance> StockImbalance => stockImbalance;
    public IMessageEvents<StockMarketSummary> StockMarketSummary => stockMarketSummary;
    public IMessageEvents<StockPrint> StockPrint => stockPrint;
    public IMessageEvents<StockPrintMarkup> StockPrintMarkup => stockPrintMarkup;
    public IMessageEvents<SyntheticExpiryQuote> SyntheticExpiryQuote => syntheticExpiryQuote;
    public IMessageEvents<SyntheticFutureQuote> SyntheticFutureQuote => syntheticFutureQuote;
    public IMessageEvents<TickerDefinitionExt> TickerDefinitionExt => tickerDefinitionExt;

    private sealed class FutureBookQuoteCache : MessageTypeCache<FutureBookQuote, FutureBookQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, FutureBookQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(FutureBookQuote fromMessage, FutureBookQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override FutureBookQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            FutureBookQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2580;
        
        public override string ToString() => nameof(FutureBookQuoteCache); 
    }

    private sealed class FuturePrintCache : MessageTypeCache<FuturePrint, FuturePrint.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, FuturePrint target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(FuturePrint fromMessage, FuturePrint toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override FuturePrint CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            FuturePrint message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2595;
        
        public override string ToString() => nameof(FuturePrintCache); 
    }

    private sealed class FuturePrintMarkupCache : MessageTypeCache<FuturePrintMarkup, FuturePrintMarkup.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, FuturePrintMarkup target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(FuturePrintMarkup fromMessage, FuturePrintMarkup toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override FuturePrintMarkup CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            FuturePrintMarkup message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2605;
        
        public override string ToString() => nameof(FuturePrintMarkupCache); 
    }

    private sealed class IndexQuoteCache : MessageTypeCache<IndexQuote, IndexQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, IndexQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(IndexQuote fromMessage, IndexQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IndexQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            IndexQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2675;
        
        public override string ToString() => nameof(IndexQuoteCache); 
    }

    private sealed class LiveImpliedQuoteCache : MessageTypeCache<LiveImpliedQuote, LiveImpliedQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, LiveImpliedQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(LiveImpliedQuote fromMessage, LiveImpliedQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override LiveImpliedQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            LiveImpliedQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 1015;
        
        public override string ToString() => nameof(LiveImpliedQuoteCache); 
    }

    private sealed class LiveSurfaceAtmCache : MessageTypeCache<LiveSurfaceAtm, LiveSurfaceAtm.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, LiveSurfaceAtm target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(LiveSurfaceAtm fromMessage, LiveSurfaceAtm toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override LiveSurfaceAtm CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            LiveSurfaceAtm message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 1030;
        
        public override string ToString() => nameof(LiveSurfaceAtmCache); 
    }

    private sealed class OptionCloseMarkCache : MessageTypeCache<OptionCloseMark, OptionCloseMark.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionCloseMark target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionCloseMark fromMessage, OptionCloseMark toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionCloseMark CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionCloseMark message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3140;
        
        public override string ToString() => nameof(OptionCloseMarkCache); 
    }

    private sealed class OptionExchOrderCache : MessageTypeCache<OptionExchOrder, OptionExchOrder.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionExchOrder target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionExchOrder fromMessage, OptionExchOrder toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionExchOrder CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionExchOrder message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2765;
        
        public override string ToString() => nameof(OptionExchOrderCache); 
    }

    private sealed class OptionExchPrintCache : MessageTypeCache<OptionExchPrint, OptionExchPrint.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionExchPrint target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionExchPrint fromMessage, OptionExchPrint toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionExchPrint CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionExchPrint message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2770;
        
        public override string ToString() => nameof(OptionExchPrintCache); 
    }

    private sealed class OptionMarketSummaryCache : MessageTypeCache<OptionMarketSummary, OptionMarketSummary.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionMarketSummary target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionMarketSummary fromMessage, OptionMarketSummary toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionMarketSummary CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionMarketSummary message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2780;
        
        public override string ToString() => nameof(OptionMarketSummaryCache); 
    }

    private sealed class OptionNbboQuoteCache : MessageTypeCache<OptionNbboQuote, OptionNbboQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionNbboQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionNbboQuote fromMessage, OptionNbboQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionNbboQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionNbboQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2785;
        
        public override string ToString() => nameof(OptionNbboQuoteCache); 
    }

    private sealed class OptionOpenInterestCache : MessageTypeCache<OptionOpenInterest, OptionOpenInterest.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionOpenInterest target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionOpenInterest fromMessage, OptionOpenInterest toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionOpenInterest CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionOpenInterest message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3230;
        
        public override string ToString() => nameof(OptionOpenInterestCache); 
    }

    private sealed class OptionPrintCache : MessageTypeCache<OptionPrint, OptionPrint.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionPrint target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionPrint fromMessage, OptionPrint toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionPrint CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionPrint message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2800;
        
        public override string ToString() => nameof(OptionPrintCache); 
    }

    private sealed class OptionPrint2Cache : MessageTypeCache<OptionPrint2, OptionPrint2.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionPrint2 target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionPrint2 fromMessage, OptionPrint2 toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionPrint2 CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionPrint2 message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2805;
        
        public override string ToString() => nameof(OptionPrint2Cache); 
    }

    private sealed class OptionPrintMarkupCache : MessageTypeCache<OptionPrintMarkup, OptionPrintMarkup.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionPrintMarkup target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionPrintMarkup fromMessage, OptionPrintMarkup toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionPrintMarkup CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionPrintMarkup message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2810;
        
        public override string ToString() => nameof(OptionPrintMarkupCache); 
    }

    private sealed class OptionRiskFactorCache : MessageTypeCache<OptionRiskFactor, OptionRiskFactor.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, OptionRiskFactor target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(OptionRiskFactor fromMessage, OptionRiskFactor toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override OptionRiskFactor CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            OptionRiskFactor message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 1095;
        
        public override string ToString() => nameof(OptionRiskFactorCache); 
    }

    private sealed class ProductDefinitionV2Cache : MessageTypeCache<ProductDefinitionV2, ProductDefinitionV2.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, ProductDefinitionV2 target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(ProductDefinitionV2 fromMessage, ProductDefinitionV2 toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override ProductDefinitionV2 CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            ProductDefinitionV2 message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 4360;
        
        public override string ToString() => nameof(ProductDefinitionV2Cache); 
    }

    private sealed class RootDefinitionCache : MessageTypeCache<RootDefinition, RootDefinition.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, RootDefinition target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(RootDefinition fromMessage, RootDefinition toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override RootDefinition CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            RootDefinition message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 4365;
        
        public override string ToString() => nameof(RootDefinitionCache); 
    }

    private sealed class SpdrAuctionStateCache : MessageTypeCache<SpdrAuctionState, SpdrAuctionState.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SpdrAuctionState target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SpdrAuctionState fromMessage, SpdrAuctionState toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SpdrAuctionState CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SpdrAuctionState message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2525;
        
        public override string ToString() => nameof(SpdrAuctionStateCache); 
    }

    private sealed class SpreadBookQuoteCache : MessageTypeCache<SpreadBookQuote, SpreadBookQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SpreadBookQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SpreadBookQuote fromMessage, SpreadBookQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SpreadBookQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SpreadBookQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2900;
        
        public override string ToString() => nameof(SpreadBookQuoteCache); 
    }

    private sealed class SpreadExchOrderCache : MessageTypeCache<SpreadExchOrder, SpreadExchOrder.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SpreadExchOrder target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SpreadExchOrder fromMessage, SpreadExchOrder toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SpreadExchOrder CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SpreadExchOrder message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2915;
        
        public override string ToString() => nameof(SpreadExchOrderCache); 
    }

    private sealed class SpreadExchPrintCache : MessageTypeCache<SpreadExchPrint, SpreadExchPrint.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SpreadExchPrint target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SpreadExchPrint fromMessage, SpreadExchPrint toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SpreadExchPrint CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SpreadExchPrint message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2920;
        
        public override string ToString() => nameof(SpreadExchPrintCache); 
    }

    private sealed class StockBookQuoteCache : MessageTypeCache<StockBookQuote, StockBookQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockBookQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockBookQuote fromMessage, StockBookQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockBookQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockBookQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3000;
        
        public override string ToString() => nameof(StockBookQuoteCache); 
    }

    private sealed class StockExchImbalanceV2Cache : MessageTypeCache<StockExchImbalanceV2, StockExchImbalanceV2.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockExchImbalanceV2 target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockExchImbalanceV2 fromMessage, StockExchImbalanceV2 toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockExchImbalanceV2 CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockExchImbalanceV2 message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3020;
        
        public override string ToString() => nameof(StockExchImbalanceV2Cache); 
    }

    private sealed class StockImbalanceCache : MessageTypeCache<StockImbalance, StockImbalance.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockImbalance target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockImbalance fromMessage, StockImbalance toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockImbalance CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockImbalance message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3035;
        
        public override string ToString() => nameof(StockImbalanceCache); 
    }

    private sealed class StockMarketSummaryCache : MessageTypeCache<StockMarketSummary, StockMarketSummary.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockMarketSummary target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockMarketSummary fromMessage, StockMarketSummary toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockMarketSummary CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockMarketSummary message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3040;
        
        public override string ToString() => nameof(StockMarketSummaryCache); 
    }

    private sealed class StockPrintCache : MessageTypeCache<StockPrint, StockPrint.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockPrint target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockPrint fromMessage, StockPrint toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockPrint CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockPrint message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3045;
        
        public override string ToString() => nameof(StockPrintCache); 
    }

    private sealed class StockPrintMarkupCache : MessageTypeCache<StockPrintMarkup, StockPrintMarkup.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, StockPrintMarkup target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(StockPrintMarkup fromMessage, StockPrintMarkup toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override StockPrintMarkup CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            StockPrintMarkup message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 3055;
        
        public override string ToString() => nameof(StockPrintMarkupCache); 
    }

    private sealed class SyntheticExpiryQuoteCache : MessageTypeCache<SyntheticExpiryQuote, SyntheticExpiryQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SyntheticExpiryQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SyntheticExpiryQuote fromMessage, SyntheticExpiryQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SyntheticExpiryQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SyntheticExpiryQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2700;
        
        public override string ToString() => nameof(SyntheticExpiryQuoteCache); 
    }

    private sealed class SyntheticFutureQuoteCache : MessageTypeCache<SyntheticFutureQuote, SyntheticFutureQuote.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, SyntheticFutureQuote target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(SyntheticFutureQuote fromMessage, SyntheticFutureQuote toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override SyntheticFutureQuote CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            SyntheticFutureQuote message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 2695;
        
        public override string ToString() => nameof(SyntheticFutureQuoteCache); 
    }

    private sealed class TickerDefinitionExtCache : MessageTypeCache<TickerDefinitionExt, TickerDefinitionExt.PKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void UpdateFromBuffer(ReadOnlySpan<byte> buffer, TickerDefinitionExt target, long timestamp)
        {
            Formatter.Default.Decode(buffer, target);
            target.ReceivedNsecsSinceUnixEpoch = timestamp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void CopyTo(TickerDefinitionExt fromMessage, TickerDefinitionExt toMessage) => fromMessage.CopyTo(toMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override TickerDefinitionExt CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache)
        {
            TickerDefinitionExt message = new();

            UpdateFromBuffer(buffer, message, timestamp);

            message.FromCache = fromCache;

            return message;
        }

        public override MessageType Type => 4380;
        
        public override string ToString() => nameof(TickerDefinitionExtCache); 
    }

}
