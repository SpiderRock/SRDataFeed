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
    internal partial class CacheComplete
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "requestID\tresult";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();


				recordBuilder.Append("\t");

				recordBuilder.Append(RequestID);
				recordBuilder.Append("\t");
				recordBuilder.Append(Result);

				return recordBuilder.ToString();
			}
        }
    }

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

    internal partial class GetCache
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "requestID\tfilter\tlimit\tMsgType";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();


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

		public const string TabHeader = "ekey\tsurfaceType\tdate\ttime\tticker\tfkey\tuBid\tuAsk\tyears\trate\tddiv\texType\tmodelType\tearnCnt\tearnCntAdj\taxisVolRT\taxisFUPrc\tmoneynessType\tunderlierMode\tatmVol\tatmCen\tatmVolHist\tatmCenHist\tminAtmVol\tmaxAtmVol\tminCPAdjVal\tmaxCPAdjVal\teMove\teMoveHist\tuPrcOffset\tuPrcOffsetEMA\tsdiv\tsdivEMA\tatmMove\tatmCenMove\tatmVega\tslope\tvarSwapFV\tgridType\tminXAxis\tmaxXAxis\tskewMinX\tskewMinY\tskewD11\tskewD10\tskewD9\tskewD8\tskewD7\tskewD6\tskewD5\tskewD4\tskewD3\tskewD2\tskewD1\tskewC0\tskewU1\tskewU2\tskewU3\tskewU4\tskewU5\tskewU6\tskewU7\tskewU8\tskewU9\tskewU10\tskewU11\tsdivD3\tsdivD2\tsdivD1\tsdivU1\tsdivU2\tsdivU3\tpwidth\tvwidth\tcCnt\tpCnt\tcBidMiss\tcAskMiss\tpBidMiss\tpAskMiss\tfitPath\tfitAvgErr\tfitAvgAbsErr\tfitMaxPrcErr\tfitErrXX\tfitErrCP\tfitErrBid\tfitErrAsk\tfitErrPrc\tfitErrVol\tsEKey\tsType\tsTimestamp\tcounter\tskewCounter\tsdivCounter\tsurfaceResult\ttimestamp";

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
				recordBuilder.Append(FitErrBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(FitErrVol);
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

		public const string TabHeader = "skey\tisTest\tticker\tbidPrice1\taskPrice1\tbidSize1\taskSize1\tbidPrice2\taskPrice2\tbidSize2\taskSize2\tbidExch1\taskExch1\tbidMask1\taskMask1\tbidTime\taskTime\tupdateType\tsrcTimestamp\tnetTimestamp\ttimestamp";

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
				recordBuilder.Append(AskPrice1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize1);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice2);
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

    public partial class TickerDefinition
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker\tsymbolType\tname\tindNum\tsubNum\tgrpNum\tprimaryExch\tsymbol\tissueClass\tsecurityID\tsic\tcusip\ttapeCode\tstkPriceInc\tstkVolume\tfutVolume\toptVolume\texchString\tnumOptions\tsharesOutstanding\ttimeMetric\ttickPilotGroup\ttkDefSource\ttimestamp";

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
