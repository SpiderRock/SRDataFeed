// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

public sealed partial class MbusClient
{
    MessageEventsDispatcher<FutureBookQuote> futureBookQuoteDispatch;
    MessageEventsDispatcher<FuturePrint> futurePrintDispatch;
    MessageEventsDispatcher<FuturePrintMarkup> futurePrintMarkupDispatch;
    MessageEventsDispatcher<IndexQuote> indexQuoteDispatch;
    MessageEventsDispatcher<LiveImpliedQuote> liveImpliedQuoteDispatch;
    MessageEventsDispatcher<LiveSurfaceAtm> liveSurfaceAtmDispatch;
    MessageEventsDispatcher<OptionCloseMark> optionCloseMarkDispatch;
    MessageEventsDispatcher<OptionExchOrder> optionExchOrderDispatch;
    MessageEventsDispatcher<OptionExchPrint> optionExchPrintDispatch;
    MessageEventsDispatcher<OptionMarketSummary> optionMarketSummaryDispatch;
    MessageEventsDispatcher<OptionNbboQuote> optionNbboQuoteDispatch;
    MessageEventsDispatcher<OptionOpenInterest> optionOpenInterestDispatch;
    MessageEventsDispatcher<OptionPrint> optionPrintDispatch;
    MessageEventsDispatcher<OptionPrint2> optionPrint2Dispatch;
    MessageEventsDispatcher<OptionPrintMarkup> optionPrintMarkupDispatch;
    MessageEventsDispatcher<OptionRiskFactor> optionRiskFactorDispatch;
    MessageEventsDispatcher<ProductDefinitionV2> productDefinitionV2Dispatch;
    MessageEventsDispatcher<RootDefinition> rootDefinitionDispatch;
    MessageEventsDispatcher<SpdrAuctionState> spdrAuctionStateDispatch;
    MessageEventsDispatcher<SpreadBookQuote> spreadBookQuoteDispatch;
    MessageEventsDispatcher<SpreadExchOrder> spreadExchOrderDispatch;
    MessageEventsDispatcher<SpreadExchPrint> spreadExchPrintDispatch;
    MessageEventsDispatcher<StockBookQuote> stockBookQuoteDispatch;
    MessageEventsDispatcher<StockExchImbalanceV2> stockExchImbalanceV2Dispatch;
    MessageEventsDispatcher<StockImbalance> stockImbalanceDispatch;
    MessageEventsDispatcher<StockMarketSummary> stockMarketSummaryDispatch;
    MessageEventsDispatcher<StockPrint> stockPrintDispatch;
    MessageEventsDispatcher<StockPrintMarkup> stockPrintMarkupDispatch;
    MessageEventsDispatcher<SyntheticPrint> syntheticPrintDispatch;
    MessageEventsDispatcher<SyntheticQuote> syntheticQuoteDispatch;
    MessageEventsDispatcher<TickerDefinitionExt> tickerDefinitionExtDispatch;

    private void InitializeMessageEventsDispatch(MessageCache messageCache)
    {
        futureBookQuoteDispatch = new(messageCache.FutureBookQuote);
        futurePrintDispatch = new(messageCache.FuturePrint);
        futurePrintMarkupDispatch = new(messageCache.FuturePrintMarkup);
        indexQuoteDispatch = new(messageCache.IndexQuote);
        liveImpliedQuoteDispatch = new(messageCache.LiveImpliedQuote);
        liveSurfaceAtmDispatch = new(messageCache.LiveSurfaceAtm);
        optionCloseMarkDispatch = new(messageCache.OptionCloseMark);
        optionExchOrderDispatch = new(messageCache.OptionExchOrder);
        optionExchPrintDispatch = new(messageCache.OptionExchPrint);
        optionMarketSummaryDispatch = new(messageCache.OptionMarketSummary);
        optionNbboQuoteDispatch = new(messageCache.OptionNbboQuote);
        optionOpenInterestDispatch = new(messageCache.OptionOpenInterest);
        optionPrintDispatch = new(messageCache.OptionPrint);
        optionPrint2Dispatch = new(messageCache.OptionPrint2);
        optionPrintMarkupDispatch = new(messageCache.OptionPrintMarkup);
        optionRiskFactorDispatch = new(messageCache.OptionRiskFactor);
        productDefinitionV2Dispatch = new(messageCache.ProductDefinitionV2);
        rootDefinitionDispatch = new(messageCache.RootDefinition);
        spdrAuctionStateDispatch = new(messageCache.SpdrAuctionState);
        spreadBookQuoteDispatch = new(messageCache.SpreadBookQuote);
        spreadExchOrderDispatch = new(messageCache.SpreadExchOrder);
        spreadExchPrintDispatch = new(messageCache.SpreadExchPrint);
        stockBookQuoteDispatch = new(messageCache.StockBookQuote);
        stockExchImbalanceV2Dispatch = new(messageCache.StockExchImbalanceV2);
        stockImbalanceDispatch = new(messageCache.StockImbalance);
        stockMarketSummaryDispatch = new(messageCache.StockMarketSummary);
        stockPrintDispatch = new(messageCache.StockPrint);
        stockPrintMarkupDispatch = new(messageCache.StockPrintMarkup);
        syntheticPrintDispatch = new(messageCache.SyntheticPrint);
        syntheticQuoteDispatch = new(messageCache.SyntheticQuote);
        tickerDefinitionExtDispatch = new(messageCache.TickerDefinitionExt);
    }

    public IMessageEvents<IMessage> GetMessageEvents(MessageType messageType)
    {
        return (ushort)messageType switch
        {
            /* FutureBookQuote */ 2580 => futureBookQuoteDispatch,
            /* FuturePrint */ 2595 => futurePrintDispatch,
            /* FuturePrintMarkup */ 2605 => futurePrintMarkupDispatch,
            /* IndexQuote */ 2675 => indexQuoteDispatch,
            /* LiveImpliedQuote */ 1015 => liveImpliedQuoteDispatch,
            /* LiveSurfaceAtm */ 1030 => liveSurfaceAtmDispatch,
            /* OptionCloseMark */ 3140 => optionCloseMarkDispatch,
            /* OptionExchOrder */ 2765 => optionExchOrderDispatch,
            /* OptionExchPrint */ 2770 => optionExchPrintDispatch,
            /* OptionMarketSummary */ 2780 => optionMarketSummaryDispatch,
            /* OptionNbboQuote */ 2785 => optionNbboQuoteDispatch,
            /* OptionOpenInterest */ 3230 => optionOpenInterestDispatch,
            /* OptionPrint */ 2800 => optionPrintDispatch,
            /* OptionPrint2 */ 2805 => optionPrint2Dispatch,
            /* OptionPrintMarkup */ 2810 => optionPrintMarkupDispatch,
            /* OptionRiskFactor */ 1095 => optionRiskFactorDispatch,
            /* ProductDefinitionV2 */ 4360 => productDefinitionV2Dispatch,
            /* RootDefinition */ 4365 => rootDefinitionDispatch,
            /* SpdrAuctionState */ 2525 => spdrAuctionStateDispatch,
            /* SpreadBookQuote */ 2900 => spreadBookQuoteDispatch,
            /* SpreadExchOrder */ 2915 => spreadExchOrderDispatch,
            /* SpreadExchPrint */ 2920 => spreadExchPrintDispatch,
            /* StockBookQuote */ 3000 => stockBookQuoteDispatch,
            /* StockExchImbalanceV2 */ 3020 => stockExchImbalanceV2Dispatch,
            /* StockImbalance */ 3035 => stockImbalanceDispatch,
            /* StockMarketSummary */ 3040 => stockMarketSummaryDispatch,
            /* StockPrint */ 3045 => stockPrintDispatch,
            /* StockPrintMarkup */ 3055 => stockPrintMarkupDispatch,
            /* SyntheticPrint */ 2690 => syntheticPrintDispatch,
            /* SyntheticQuote */ 2695 => syntheticQuoteDispatch,
            /* TickerDefinitionExt */ 4380 => tickerDefinitionExtDispatch,
            _ => null
        };
    }

    public IMessageEvents<FutureBookQuote> FutureBookQuote => messageCache.FutureBookQuote;
    public IMessageEvents<FuturePrint> FuturePrint => messageCache.FuturePrint;
    public IMessageEvents<FuturePrintMarkup> FuturePrintMarkup => messageCache.FuturePrintMarkup;
    public IMessageEvents<IndexQuote> IndexQuote => messageCache.IndexQuote;
    public IMessageEvents<LiveImpliedQuote> LiveImpliedQuote => messageCache.LiveImpliedQuote;
    public IMessageEvents<LiveSurfaceAtm> LiveSurfaceAtm => messageCache.LiveSurfaceAtm;
    public IMessageEvents<OptionCloseMark> OptionCloseMark => messageCache.OptionCloseMark;
    public IMessageEvents<OptionExchOrder> OptionExchOrder => messageCache.OptionExchOrder;
    public IMessageEvents<OptionExchPrint> OptionExchPrint => messageCache.OptionExchPrint;
    public IMessageEvents<OptionMarketSummary> OptionMarketSummary => messageCache.OptionMarketSummary;
    public IMessageEvents<OptionNbboQuote> OptionNbboQuote => messageCache.OptionNbboQuote;
    public IMessageEvents<OptionOpenInterest> OptionOpenInterest => messageCache.OptionOpenInterest;
    public IMessageEvents<OptionPrint> OptionPrint => messageCache.OptionPrint;
    public IMessageEvents<OptionPrint2> OptionPrint2 => messageCache.OptionPrint2;
    public IMessageEvents<OptionPrintMarkup> OptionPrintMarkup => messageCache.OptionPrintMarkup;
    public IMessageEvents<OptionRiskFactor> OptionRiskFactor => messageCache.OptionRiskFactor;
    public IMessageEvents<ProductDefinitionV2> ProductDefinitionV2 => messageCache.ProductDefinitionV2;
    public IMessageEvents<RootDefinition> RootDefinition => messageCache.RootDefinition;
    public IMessageEvents<SpdrAuctionState> SpdrAuctionState => messageCache.SpdrAuctionState;
    public IMessageEvents<SpreadBookQuote> SpreadBookQuote => messageCache.SpreadBookQuote;
    public IMessageEvents<SpreadExchOrder> SpreadExchOrder => messageCache.SpreadExchOrder;
    public IMessageEvents<SpreadExchPrint> SpreadExchPrint => messageCache.SpreadExchPrint;
    public IMessageEvents<StockBookQuote> StockBookQuote => messageCache.StockBookQuote;
    public IMessageEvents<StockExchImbalanceV2> StockExchImbalanceV2 => messageCache.StockExchImbalanceV2;
    public IMessageEvents<StockImbalance> StockImbalance => messageCache.StockImbalance;
    public IMessageEvents<StockMarketSummary> StockMarketSummary => messageCache.StockMarketSummary;
    public IMessageEvents<StockPrint> StockPrint => messageCache.StockPrint;
    public IMessageEvents<StockPrintMarkup> StockPrintMarkup => messageCache.StockPrintMarkup;
    public IMessageEvents<SyntheticPrint> SyntheticPrint => messageCache.SyntheticPrint;
    public IMessageEvents<SyntheticQuote> SyntheticQuote => messageCache.SyntheticQuote;
    public IMessageEvents<TickerDefinitionExt> TickerDefinitionExt => messageCache.TickerDefinitionExt;
}
