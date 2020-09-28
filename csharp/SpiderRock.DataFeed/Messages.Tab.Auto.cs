// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;

using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public partial class FutureBookQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey\tupdateType\tmarketStatus\tbidPrice1\taskPrice1\tbidSize1\taskSize1\tbidOrders1\taskOrders1\tbidPrice2\taskPrice2\tbidSize2\taskSize2\tbidOrders2\taskOrders2\tbidPrice3\taskPrice3\tbidSize3\taskSize3\tbidOrders3\taskOrders3\tbidPrice4\taskPrice4\tbidSize4\taskSize4\tbidOrders4\taskOrders4\tsrcTimestamp\tnetTimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey);
				recordBuilder.Append("\t");

				recordBuilder.Append(UpdateType);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidOrders1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskOrders1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidOrders2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskOrders2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice3);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize3);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidOrders3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskOrders3);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice4);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize4);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidOrders4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskOrders4);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class FuturePrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey\tprtExch\tprtSize\tprtPrice\tprtClusterNum\tprtClusterSize\tprtType\tprtOrders\tprtQuan\tprtVolume\tbid\task\tbsz\tasz\tage\tprtSide\tprtTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtOrders);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(Bid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Bsz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Asz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Age);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class FuturePrintMarkup
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey\tprtNumber\tticker\tprtExch\tprtSize\tprtPrice\tprtType\tprtOrders\tprtClusterNum\tprtClusterSize\tprtVolume\tprtSide\tbidPrice\taskPrice\tbidSize\taskSize\tbidPrice2\taskPrice2\tbidSize2\taskSize2\tsrcTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtNumber);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtOrders);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    internal partial class GetExtCache
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "appName\trequestID\tfilter\tlimit\tMsgType";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();


				recordBuilder.Append("\t");

				recordBuilder.Append(AppName);
				recordBuilder.Append("\t");
				recordBuilder.Append(RequestID);
				recordBuilder.Append("\t");
				recordBuilder.Append(Filter);
				recordBuilder.Append("\t");
				recordBuilder.Append(Limit);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class IndexQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tpriceSource\tidxBid\tidxAsk\tidxPrice\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(PriceSource);
				recordBuilder.Append("\t");
				recordBuilder.Append(IdxBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(IdxAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(IdxPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class LiveSurfaceAtm
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ekey\tsurfaceType\trunStatus\tdataCenter\tsysEnvironment\tdate\ttime\tticker\tfkey\tuBid\tuAsk\tyears\trate\tddiv\texType\tmodelType\tearnCnt\tearnCntAdj\taxisVolRT\taxisFUPrc\tmoneynessType\tunderlierMode\tpriceQuoteType\tatmVol\tatmCen\tatmVolHist\tatmCenHist\tminAtmVol\tmaxAtmVol\tminCPAdjVal\tmaxCPAdjVal\teMove\teMoveHist\tuPrcOffset\tuPrcOffsetEMA\tsdiv\tsdivEMA\tatmMove\tatmCenMove\tatmPhi\tatmVega\tslope\tvarSwapFV\tgridType\tminXAxis\tmaxXAxis\tminCurvValue\tminCurvXAxis\tmaxCurvValue\tmaxCurvXAxis\tskewMinX\tskewMinY\tskewD11\tskewD10\tskewD9\tskewD8\tskewD7\tskewD6\tskewD5\tskewD4\tskewD3\tskewD2\tskewD1\tskewC0\tskewU1\tskewU2\tskewU3\tskewU4\tskewU5\tskewU6\tskewU7\tskewU8\tskewU9\tskewU10\tskewU11\tsdivD3\tsdivD2\tsdivD1\tsdivU1\tsdivU2\tsdivU3\tpwidth\tvwidth\tcCnt\tpCnt\tcBidMiss\tcAskMiss\tpBidMiss\tpAskMiss\tfitPath\tfitAvgErr\tfitAvgAbsErr\tfitMaxPrcErr\tfitErrXX\tfitErrCP\tfitErrDe\tfitErrBid\tfitErrAsk\tfitErrPrc\tfitErrVol\tcBidMissT\tcAskMissT\tpBidMissT\tpAskMissT\tfitAvgAbsErrT\tsEKey\tsType\tsTimestamp\tcounter\tskewCounter\tsdivCounter\tmarketSession\ttradeableStatus\tsurfaceResult\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ekey);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.SurfaceType);
				recordBuilder.Append("\t");

				recordBuilder.Append(RunStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(DataCenter);
				recordBuilder.Append("\t");
				recordBuilder.Append(SysEnvironment);
				recordBuilder.Append("\t");
				recordBuilder.Append(Date);
				recordBuilder.Append("\t");
				recordBuilder.Append(Time);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(Fkey);
				recordBuilder.Append("\t");
				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(Years);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rate);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ddiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExType);
				recordBuilder.Append("\t");
				recordBuilder.Append(ModelType);
				recordBuilder.Append("\t");
				recordBuilder.Append(EarnCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(EarnCntAdj);
				recordBuilder.Append("\t");
				recordBuilder.Append(AxisVolRT);
				recordBuilder.Append("\t");
				recordBuilder.Append(AxisFUPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(MoneynessType);
				recordBuilder.Append("\t");
				recordBuilder.Append(UnderlierMode);
				recordBuilder.Append("\t");
				recordBuilder.Append(PriceQuoteType);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmCen);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmVolHist);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmCenHist);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinAtmVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxAtmVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinCPAdjVal);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxCPAdjVal);
				recordBuilder.Append("\t");
				recordBuilder.Append(EMove);
				recordBuilder.Append("\t");
				recordBuilder.Append(EMoveHist);
				recordBuilder.Append("\t");
				recordBuilder.Append(UPrcOffset);
				recordBuilder.Append("\t");
				recordBuilder.Append(UPrcOffsetEMA);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sdiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivEMA);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmMove);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmCenMove);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmPhi);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmVega);
				recordBuilder.Append("\t");
				recordBuilder.Append(Slope);
				recordBuilder.Append("\t");
				recordBuilder.Append(VarSwapFV);
				recordBuilder.Append("\t");
				recordBuilder.Append(GridType);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinXAxis);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxXAxis);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinCurvValue);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinCurvXAxis);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxCurvValue);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxCurvXAxis);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewMinX);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewMinY);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD11);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD10);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD9);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD8);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD7);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD6);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD5);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD4);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD3);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewD1);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewC0);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU1);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU3);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU4);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU5);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU6);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU7);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU8);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU9);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU10);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewU11);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivD3);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivD2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivD1);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivU1);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivU2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivU3);
				recordBuilder.Append("\t");
				recordBuilder.Append(Pwidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(Vwidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(CCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(PCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(CBidMiss);
				recordBuilder.Append("\t");
				recordBuilder.Append(CAskMiss);
				recordBuilder.Append("\t");
				recordBuilder.Append(PBidMiss);
				recordBuilder.Append("\t");
				recordBuilder.Append(PAskMiss);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitPath);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitAvgErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitAvgAbsErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitMaxPrcErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrXX);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrCP);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrDe);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(CBidMissT);
				recordBuilder.Append("\t");
				recordBuilder.Append(CAskMissT);
				recordBuilder.Append("\t");
				recordBuilder.Append(PBidMissT);
				recordBuilder.Append("\t");
				recordBuilder.Append(PAskMissT);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitAvgAbsErrT);
				recordBuilder.Append("\t");
				recordBuilder.Append(SEKey);
				recordBuilder.Append("\t");
				recordBuilder.Append(SType);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(STimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(Counter);
				recordBuilder.Append("\t");
				recordBuilder.Append(SkewCounter);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivCounter);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketSession);
				recordBuilder.Append("\t");
				recordBuilder.Append(TradeableStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(SurfaceResult);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    internal partial class NetPulse
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "frequency\ttimeout\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();


				recordBuilder.Append("\t");

				recordBuilder.Append(Frequency);
				recordBuilder.Append("\t");
				recordBuilder.Append(Timeout);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionCloseMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tclsMarkState\tuBid\tuAsk\tuSrCls\tuClose\tbidPrc\taskPrc\tsrClsPrc\tclosePrc\tbidIV\taskIV\tsrPrc\tsrVol\tsrSrc\tde\tga\tth\tve\tvo\tva\tdeDecay\trh\tph\tsdiv\tddiv\trate\tyears\terror\topenInterest\tprtCount\tprtVolume\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(ClsMarkState);
				recordBuilder.Append("\t");
				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(USrCls);
				recordBuilder.Append("\t");
				recordBuilder.Append(UClose);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrClsPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClosePrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidIV);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskIV);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrSrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(De);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ga);
				recordBuilder.Append("\t");
				recordBuilder.Append(Th);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ve);
				recordBuilder.Append("\t");
				recordBuilder.Append(Vo);
				recordBuilder.Append("\t");
				recordBuilder.Append(Va);
				recordBuilder.Append("\t");
				recordBuilder.Append(DeDecay);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rh);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ph);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sdiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ddiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rate);
				recordBuilder.Append("\t");
				recordBuilder.Append(Years);
				recordBuilder.Append("\t");
				recordBuilder.Append(Error);
				recordBuilder.Append("\t");
				recordBuilder.Append(OpenInterest);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionExchOrder
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tside\texch\texchOrderID\tsize\tprice\torigOrderSize\torderType\torderStatus\tmarketQualifier\texecQualifier\ttimeInForce\tfirmType\tpositionType\tclearingFirm\tclearingAccnt\totherDetail\tsrcTimestamp\tnetTimestamp\tdgwTimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.Side);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.Exch);
				recordBuilder.Append("\t");

				recordBuilder.Append(ExchOrderID);
				recordBuilder.Append("\t");
				recordBuilder.Append(Size);
				recordBuilder.Append("\t");
				recordBuilder.Append(Price);
				recordBuilder.Append("\t");
				recordBuilder.Append(OrigOrderSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(OrderType);
				recordBuilder.Append("\t");
				recordBuilder.Append(OrderStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketQualifier);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExecQualifier);
				recordBuilder.Append("\t");
				recordBuilder.Append(TimeInForce);
				recordBuilder.Append("\t");
				recordBuilder.Append(FirmType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PositionType);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClearingFirm);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClearingAccnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(OtherDetail);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(DgwTimestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionExchPrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "srPrintID\tokey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\texch\texchOrderID\tprtSize\tprtPrice\texchPrtType\tsrcTimestamp\tnetTimestamp\tdgwTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.SrPrintID);
				recordBuilder.Append("\t");

				recordBuilder.Append(Okey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Exch);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExchOrderID);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExchPrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(DgwTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionImpliedQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tcalcType\tticker\tuprc\tyears\trate\tsdiv\tddiv\tobid\toask\tobiv\toaiv\tsatm\tsmny\tsvol\tsprc\tsmrk\tveSlope\tde\tga\tth\tve\tro\tph\tup50\tdn50\tup15\tdn15\tup06\tdn08\tcalcErr\tcalcSource\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.CalcType);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(Uprc);
				recordBuilder.Append("\t");
				recordBuilder.Append(Years);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rate);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sdiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ddiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Obid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Oask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Obiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Oaiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Satm);
				recordBuilder.Append("\t");
				recordBuilder.Append(Smny);
				recordBuilder.Append("\t");
				recordBuilder.Append(Svol);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sprc);
				recordBuilder.Append("\t");
				recordBuilder.Append(Smrk);
				recordBuilder.Append("\t");
				recordBuilder.Append(VeSlope);
				recordBuilder.Append("\t");
				recordBuilder.Append(De);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ga);
				recordBuilder.Append("\t");
				recordBuilder.Append(Th);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ve);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ro);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ph);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up50);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn50);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up15);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn15);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up06);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn08);
				recordBuilder.Append("\t");
				recordBuilder.Append(CalcErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(CalcSource);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionNbboQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tupdateType\tbidPrice\taskPrice\tbidSize\taskSize\tcumBidSize\tcumAskSize\tbidExch\taskExch\tbidMask\taskMask\tbidMktType\taskMktType\tbidPrice2\taskPrice2\tcumBidSize2\tcumAskSize2\tbidTime\taskTime\tsrcTimestamp\tnetTimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(UpdateType);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumBidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumAskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidMask);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskMask);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidMktType);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskMktType);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumBidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumAskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionOpenInterestV2
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\topenInt\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(OpenInt);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionPrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tprtExch\tprtSize\tprtPrice\tprtClusterNum\tprtClusterSize\tprtType\tprtOrders\tprtVolume\tcxlVolume\tbidCount\taskCount\tbidVolume\taskVolume\tebid\teask\tebsz\teasz\teage\tprtSide\tprtTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtOrders);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(CxlVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebsz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Easz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eage);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionPrint2
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tprtExch\tprtSize\tprtPrice\tprtClusterNum\tprtClusterSize\tprtType\tprtOrders\tprtVolume\toosVolume\tisoVolume\tslaVolume\tmlaVolume\tcrxVolume\tflrVolume\tmlgVolume\tuknVolume\tcxlVolume\ttotalVolume\tbidCount\taskCount\tbidVolume\taskVolume\tebid\teask\tebsz\teasz\teage\tprtSide\tprtTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtOrders);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(OosVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsoVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(SlaVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(MlaVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(CrxVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(FlrVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(MlgVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(UknVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(CxlVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(TotalVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebsz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Easz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eage);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionPrintMarkup
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tprtNumber\tfkey\tticker\tprtExch\tprtSize\tprtPrice\tprtType\tprtOrders\tprtClusterNum\tprtClusterSize\tprtVolume\tcxlVolume\tbidCount\taskCount\tbidVolume\taskVolume\tebid\teask\tebsz\teasz\teage\tprtSide\toBid\toAsk\toBidSz\toAskSz\toBidEx\toAskEx\toBidExSz\toAskExSz\toBidCnt\toAskCnt\toBid2\toAsk2\toBidSz2\toAskSz2\tuBid\tuAsk\tuPrc\tyrs\trate\tsdiv\tddiv\txDe\txAxis\tmultihedge\tprtIv\tprtDe\tprtGa\tprtTh\tprtVe\tprtRo\tcalcErr\tsurfVol\tsurfOpx\tsurfAtm\tsrcTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtNumber);
				recordBuilder.Append("\t");
				recordBuilder.Append(Fkey);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtOrders);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(CxlVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebsz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Easz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eage);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBidSz);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAskSz);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBidEx);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAskEx);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBidExSz);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAskExSz);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBidCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAskCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBid2);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAsk2);
				recordBuilder.Append("\t");
				recordBuilder.Append(OBidSz2);
				recordBuilder.Append("\t");
				recordBuilder.Append(OAskSz2);
				recordBuilder.Append("\t");
				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(UPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(Yrs);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rate);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sdiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ddiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(XDe);
				recordBuilder.Append("\t");
				recordBuilder.Append(XAxis);
				recordBuilder.Append("\t");
				recordBuilder.Append(Multihedge);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtIv);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtDe);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtGa);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtTh);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVe);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtRo);
				recordBuilder.Append("\t");
				recordBuilder.Append(CalcErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(SurfVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(SurfOpx);
				recordBuilder.Append("\t");
				recordBuilder.Append(SurfAtm);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionRiskFactor
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tticker\tsvol\tyears\tup50\tdn50\tup15\tdn15\tup12\tdn12\tup09\tdn09\tdn08\tup06\tdn06\tup03\tdn03\tcalcErr\tcalcSource\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(Svol);
				recordBuilder.Append("\t");
				recordBuilder.Append(Years);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up50);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn50);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up15);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn15);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up12);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn12);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up09);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn09);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn08);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up06);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn06);
				recordBuilder.Append("\t");
				recordBuilder.Append(Up03);
				recordBuilder.Append("\t");
				recordBuilder.Append(Dn03);
				recordBuilder.Append("\t");
				recordBuilder.Append(CalcErr);
				recordBuilder.Append("\t");
				recordBuilder.Append(CalcSource);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class ProductDefinitionV2
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "secKey_rt\tsecKey_ts\tsecKey_at\tsecKey_yr\tsecKey_mn\tsecKey_dy\tsecKey_xx\tsecKey_cp\tsecType\tsecurityID\tproductClass\tunderlierID\tundKey\tundType\tproductGroup\tsecurityGroup\tmarketSegmentID\tsecurityDesc\texchange\tproductType\tproductTerm\tproductIndexType\tproductRate\tcontractSize\tcontractUnit\tpriceFormat\tminTickSize\tdisplayFactor\tstrikeScale\tminLotSize\tbookDepth\timpliedBookDepth\timpMarketInd\tminPriceIncrementAmount\tparValue\tcontMultiplier\tcabPrice\ttradeCurr\tsettleCurr\tstrikeCurr\texpiration\tmaturity\texerciseType\tuserDefined\tdecayStartYear\tdecayStartMonth\tdecayStartDay\tdecayQty\tpriceRatio\ttimestamp\tLegs";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.SecKey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.SecType);
				recordBuilder.Append("\t");

				recordBuilder.Append(SecurityID);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductClass);
				recordBuilder.Append("\t");
				recordBuilder.Append(UnderlierID);
				recordBuilder.Append("\t");
				recordBuilder.Append(UndKey);
				recordBuilder.Append("\t");
				recordBuilder.Append(UndType);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductGroup);
				recordBuilder.Append("\t");
				recordBuilder.Append(SecurityGroup);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketSegmentID);
				recordBuilder.Append("\t");
				recordBuilder.Append(SecurityDesc);
				recordBuilder.Append("\t");
				recordBuilder.Append(Exchange);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductType);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductTerm);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductIndexType);
				recordBuilder.Append("\t");
				recordBuilder.Append(ProductRate);
				recordBuilder.Append("\t");
				recordBuilder.Append(ContractSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(ContractUnit);
				recordBuilder.Append("\t");
				recordBuilder.Append(PriceFormat);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinTickSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(DisplayFactor);
				recordBuilder.Append("\t");
				recordBuilder.Append(StrikeScale);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinLotSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BookDepth);
				recordBuilder.Append("\t");
				recordBuilder.Append(ImpliedBookDepth);
				recordBuilder.Append("\t");
				recordBuilder.Append(ImpMarketInd);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinPriceIncrementAmount);
				recordBuilder.Append("\t");
				recordBuilder.Append(ParValue);
				recordBuilder.Append("\t");
				recordBuilder.Append(ContMultiplier);
				recordBuilder.Append("\t");
				recordBuilder.Append(CabPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(TradeCurr);
				recordBuilder.Append("\t");
				recordBuilder.Append(SettleCurr);
				recordBuilder.Append("\t");
				recordBuilder.Append(StrikeCurr);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Expiration);
				recordBuilder.Append("\t");
				recordBuilder.Append(Maturity);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExerciseType);
				recordBuilder.Append("\t");
				recordBuilder.Append(UserDefined);
				recordBuilder.Append("\t");
				recordBuilder.Append(DecayStartYear);
				recordBuilder.Append("\t");
				recordBuilder.Append(DecayStartMonth);
				recordBuilder.Append("\t");
				recordBuilder.Append(DecayStartDay);
				recordBuilder.Append("\t");
				recordBuilder.Append(DecayQty);
				recordBuilder.Append("\t");
				recordBuilder.Append(PriceRatio);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class RootDefinition
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "root\tticker\tosiRoot\tccode\texpirationMap\tunderlierMode\toptionType\tmultihedge\texerciseTime\texerciseType\ttimeMetric\tpricingModel\tmoneynessType\tpriceQuoteType\tvolumeTier\tpositionLimit\texchanges\ttickValue\tpointValue\tstrikeScale\tstrikeRatio\tcashOnExercise\tunderliersPerCn\tpremiumMult\tadjConvention\toptPriceInc\tpriceFormat\ttradeCurr\tsettleCurr\tstrikeCurr\tdefaultSurfaceRoot\ttimestamp\tUnderlying";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Root);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(OsiRoot);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ccode);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpirationMap);
				recordBuilder.Append("\t");
				recordBuilder.Append(UnderlierMode);
				recordBuilder.Append("\t");
				recordBuilder.Append(OptionType);
				recordBuilder.Append("\t");
				recordBuilder.Append(Multihedge);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExerciseTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExerciseType);
				recordBuilder.Append("\t");
				recordBuilder.Append(TimeMetric);
				recordBuilder.Append("\t");
				recordBuilder.Append(PricingModel);
				recordBuilder.Append("\t");
				recordBuilder.Append(MoneynessType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PriceQuoteType);
				recordBuilder.Append("\t");
				recordBuilder.Append(VolumeTier);
				recordBuilder.Append("\t");
				recordBuilder.Append(PositionLimit);
				recordBuilder.Append("\t");
				recordBuilder.Append(Exchanges);
				recordBuilder.Append("\t");
				recordBuilder.Append(TickValue);
				recordBuilder.Append("\t");
				recordBuilder.Append(PointValue);
				recordBuilder.Append("\t");
				recordBuilder.Append(StrikeScale);
				recordBuilder.Append("\t");
				recordBuilder.Append(StrikeRatio);
				recordBuilder.Append("\t");
				recordBuilder.Append(CashOnExercise);
				recordBuilder.Append("\t");
				recordBuilder.Append(UnderliersPerCn);
				recordBuilder.Append("\t");
				recordBuilder.Append(PremiumMult);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjConvention);
				recordBuilder.Append("\t");
				recordBuilder.Append(OptPriceInc);
				recordBuilder.Append("\t");
				recordBuilder.Append(PriceFormat);
				recordBuilder.Append("\t");
				recordBuilder.Append(TradeCurr);
				recordBuilder.Append("\t");
				recordBuilder.Append(SettleCurr);
				recordBuilder.Append("\t");
				recordBuilder.Append(StrikeCurr);
				recordBuilder.Append("\t");
				recordBuilder.Append(DefaultSurfaceRoot);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class SpreadBookQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "skey\tisTest\tticker\tbidPrice1\tisBidPrice1Valid\taskPrice1\tisAskPrice1Valid\tbidSize1\taskSize1\tbidPrice2\tisBidPrice2Valid\taskPrice2\tisAskPrice2Valid\tbidSize2\taskSize2\tbidExch1\taskExch1\tbidMask1\taskMask1\tbidTime\taskTime\tupdateType\tsrcTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Skey);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.IsTest);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsBidPrice1Valid);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsAskPrice1Valid);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsBidPrice2Valid);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsAskPrice2Valid);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidMask1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskMask1);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(BidTime);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(AskTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(UpdateType);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockBookQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tupdateType\tmarketStatus\tbidPrice1\tbidSize1\tbidExch1\tbidMask1\taskPrice1\taskSize1\taskExch1\taskMask1\tbidPrice2\tbidSize2\tbidExch2\tbidMask2\taskPrice2\taskSize2\taskExch2\taskMask2\thaltMask\tsrcTimestamp\tnetTimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(UpdateType);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidMask1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskMask1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidMask2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskMask2);
				recordBuilder.Append("\t");
				recordBuilder.Append(HaltMask);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockExchImbalanceV2
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tauctionTime\tauctionType\treferencePx\tpairedQty\ttotalImbalanceQty\tmarketImbalanceQty\timbalanceSide\tcontinuousBookClrPx\tclosingOnlyClrPx\tssrFillingPx\tindicativeMatchPx\tupperCollar\tlowerCollar\tauctionStatus\tfreezeStatus\tnumExtensions\tnetTimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(pkey.AuctionTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.AuctionType);
				recordBuilder.Append("\t");

				recordBuilder.Append(ReferencePx);
				recordBuilder.Append("\t");
				recordBuilder.Append(PairedQty);
				recordBuilder.Append("\t");
				recordBuilder.Append(TotalImbalanceQty);
				recordBuilder.Append("\t");
				recordBuilder.Append(MarketImbalanceQty);
				recordBuilder.Append("\t");
				recordBuilder.Append(ImbalanceSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(ContinuousBookClrPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClosingOnlyClrPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(SsrFillingPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(IndicativeMatchPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(UpperCollar);
				recordBuilder.Append("\t");
				recordBuilder.Append(LowerCollar);
				recordBuilder.Append("\t");
				recordBuilder.Append(AuctionStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(FreezeStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(NumExtensions);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockImbalance
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tauctionType\tauctionTime\tmaxImbalance\tmaxImbalanceExch\tmaxImbalanceMatchPx\tmaxImbalanceStatus\tcumBidImbalanceMkt\tcumAskImbalanceMkt\tcumBidImbalanceTot\tcumAskImbalanceTot\tcumPairedQty\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.AuctionType);
				recordBuilder.Append("\t");

				recordBuilder.AppendInTabRecordFormat(AuctionTime);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxImbalance);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxImbalanceExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxImbalanceMatchPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxImbalanceStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumBidImbalanceMkt);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumAskImbalanceMkt);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumBidImbalanceTot);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumAskImbalanceTot);
				recordBuilder.Append("\t");
				recordBuilder.Append(CumPairedQty);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockMarketSummary
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tiniPrice\tmrkPrice\tclsPrice\tminPrice\tmaxPrice\tsharesOutstanding\tbidCount\tbidVolume\taskCount\taskVolume\tmidCount\tmidVolume\tprtCount\tprtPrice\texpCount\texpWidth\texpBidSize\texpAskSize\tlastPrint\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(IniPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MrkPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClsPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(SharesOutstanding);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(MidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(MidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpWidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpBidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpAskSize);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(LastPrint);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockPrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tprtExch\tprtSize\tprtPrice\tprtClusterNum\tprtClusterSize\tprtVolume\tmrkPrice\tclsPrice\tprtType\tprtCond1\tprtCond2\tprtCond3\tprtCond4\tebid\teask\tebsz\teasz\teage\tprtSide\tprtTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(MrkPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClsPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond1);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond2);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond3);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond4);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eask);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ebsz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Easz);
				recordBuilder.Append("\t");
				recordBuilder.Append(Eage);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockPrintMarkup
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tprtNumber\tprtExch\tprtSize\tprtPrice\tprtClusterNum\tprtClusterSize\tprtVolume\tmrkPrice\tprtType\tprtCond1\tprtCond2\tprtCond3\tprtCond4\tprtSide\tbidPrice\taskPrice\tbidSize\taskSize\tbidPrice2\taskPrice2\tbidSize2\taskSize2\tsrcTimestamp\tnetTimestamp\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtNumber);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtClusterSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(MrkPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond1);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond2);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond3);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtCond4);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize2);
				recordBuilder.Append("\t");
				recordBuilder.Append(SrcTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(NetTimestamp);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class TickerDefinition
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tsymbolType\tname\tindNum\tsubNum\tgrpNum\tprimaryExch\tsymbol\tissueClass\tsecurityID\tsic\tcusip\tisin\tfigi\ttapeCode\tstkPriceInc\tstkVolume\tfutVolume\toptVolume\texchString\tnumOptions\tsharesOutstanding\ttimeMetric\ttickPilotGroup\ttkDefSource\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker);
				recordBuilder.Append("\t");

				recordBuilder.Append(SymbolType);
				recordBuilder.Append("\t");
				recordBuilder.Append(Name);
				recordBuilder.Append("\t");
				recordBuilder.Append(IndNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(SubNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(GrpNum);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrimaryExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(Symbol);
				recordBuilder.Append("\t");
				recordBuilder.Append(IssueClass);
				recordBuilder.Append("\t");
				recordBuilder.Append(SecurityID);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sic);
				recordBuilder.Append("\t");
				recordBuilder.Append(Cusip);
				recordBuilder.Append("\t");
				recordBuilder.Append(Isin);
				recordBuilder.Append("\t");
				recordBuilder.Append(Figi);
				recordBuilder.Append("\t");
				recordBuilder.Append(TapeCode);
				recordBuilder.Append("\t");
				recordBuilder.Append(StkPriceInc);
				recordBuilder.Append("\t");
				recordBuilder.Append(StkVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(FutVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(OptVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExchString);
				recordBuilder.Append("\t");
				recordBuilder.Append(NumOptions);
				recordBuilder.Append("\t");
				recordBuilder.Append(SharesOutstanding);
				recordBuilder.Append("\t");
				recordBuilder.Append(TimeMetric);
				recordBuilder.Append("\t");
				recordBuilder.Append(TickPilotGroup);
				recordBuilder.Append("\t");
				recordBuilder.Append(TkDefSource);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }


}
