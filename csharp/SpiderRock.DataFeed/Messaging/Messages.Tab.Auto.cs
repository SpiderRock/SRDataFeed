// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;

using SpiderRock.DataFeed.Messaging.Keys;

namespace SpiderRock.DataFeed.Messaging
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

		public const string TabHeader = "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy\tfutexch\tbidPrice1\taskPrice1\tbidSize1\taskSize1\tbidPrice2\taskPrice2\tbidSize2\taskSize2\tbidPrice3\taskPrice3\tbidSize3\taskSize3\tbidPrice4\taskPrice4\tbidSize4\taskSize4\tbidPrintQuan\taskPrintQuan\tdisplayFactor\tsession\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(Futexch);
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
				recordBuilder.Append(BidPrice3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice3);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize3);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrice4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice4);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize4);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrintQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrintQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(DisplayFactor);
				recordBuilder.Append("\t");
				recordBuilder.Append(Session);
				recordBuilder.Append("\t");
				recordBuilder.Append(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class FuturePrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy\tfutexch\tprtPrice\tprtQuan\tprtSize\tprtType\tprtVolume\tbidCount\taskCount\tbidVolume\taskVolume\tiniPrice\tmrkPrice\topnPrice\tclsPrice\tminPrice\tmaxPrice\tsession\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(Futexch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskCount);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(IniPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MrkPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(OpnPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClsPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(Session);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class FutureSettlementMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy\tearly\tpriorPeriod\tsettleDate\tsettlePx\tlowLmtPx\thighLmtPx\topenInt\tvolume\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.Early);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.PriorPeriod);
				recordBuilder.Append("\t");

				recordBuilder.Append(SettleDate);
				recordBuilder.Append("\t");
				recordBuilder.Append(SettlePx);
				recordBuilder.Append("\t");
				recordBuilder.Append(LowLmtPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(HighLmtPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(OpenInt);
				recordBuilder.Append("\t");
				recordBuilder.Append(Volume);
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

    public partial class LiveSurfaceAtm
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy\tsurfaceType\tticker_tk\tticker_ts\tticker_at\tuBid\tuAsk\tyears\trate\tsdiv\tddiv\taxisVol\tcAtm\tpAtm\tadjDI\tadjD8\tadjD7\tadjD6\tadjD5\tadjD4\tadjD3\tadjD2\tadjD1\tadjU1\tadjU2\tadjU3\tadjU4\tadjU5\tadjU6\tadjU7\tadjU8\tadjUI\tslope\tcmult\tpwidth\tvwidth\tsdivEMA\tatmMAC\tcprMAC\tcAtmMove\tpAtmMove\tcCnt\tpCnt\tcBidMiss\tcAskMiss\tpBidMiss\tpAskMiss\tfitAvgErr\tfitAvgAbsErr\tfitMaxPrcErr\tfitErrXX\tfitErrCP\tfitErrBid\tfitErrAsk\tfitErrPrc\tfitErrVol\tfitType\tsFKey_rt\tsFKey_ts\tsFKey_at\tsFKey_yr\tsFKey_mn\tsFKey_dy\tsType\tsTimestamp\tcounter\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Fkey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.SurfaceType);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(Years);
				recordBuilder.Append("\t");
				recordBuilder.Append(Rate);
				recordBuilder.Append("\t");
				recordBuilder.Append(Sdiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ddiv);
				recordBuilder.Append("\t");
				recordBuilder.Append(AxisVol);
				recordBuilder.Append("\t");
				recordBuilder.Append(CAtm);
				recordBuilder.Append("\t");
				recordBuilder.Append(PAtm);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjDI);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD8);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD7);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD6);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD5);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjD1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU1);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU2);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU3);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU4);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU5);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU6);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU7);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjU8);
				recordBuilder.Append("\t");
				recordBuilder.Append(AdjUI);
				recordBuilder.Append("\t");
				recordBuilder.Append(Slope);
				recordBuilder.Append("\t");
				recordBuilder.Append(Cmult);
				recordBuilder.Append("\t");
				recordBuilder.Append(Pwidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(Vwidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(SdivEMA);
				recordBuilder.Append("\t");
				recordBuilder.Append(AtmMAC);
				recordBuilder.Append("\t");
				recordBuilder.Append(CprMAC);
				recordBuilder.Append("\t");
				recordBuilder.Append(CAtmMove);
				recordBuilder.Append("\t");
				recordBuilder.Append(PAtmMove);
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
				recordBuilder.Append(FitType);
				recordBuilder.Append("\t");
				recordBuilder.Append(SFKey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(SType);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(STimestamp);
				recordBuilder.Append("\t");
				recordBuilder.Append(Counter);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionCloseMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tuBid\tuAsk\tbidPx\taskPx\tbidIV\taskIV\tsrPrc\tsrVol\tsrSrc\tde\tga\tth\tve\trh\tph\tsdiv\tddiv\trate\terror\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPx);
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
				recordBuilder.Append(Error);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionCloseQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tbidPrice\taskPrice\tbidSize\taskSize\tbidExch\taskExch\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(BidPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionImpliedQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tticker_tk\tticker_ts\tticker_at\tubid\tuask\tyears\trate\tsdiv\tddiv\tobid\toask\tobiv\toaiv\tsatm\tsmny\tsvol\tsprc\tde\tga\tth\tve\tro\tcalcErr\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(Ticker.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Ubid);
				recordBuilder.Append("\t");
				recordBuilder.Append(Uask);
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
				recordBuilder.Append(CalcErr);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionNbboQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tbidPrice\taskPrice\tbidSize\taskSize\tcumBidSize\tcumAskSize\tbidExch\taskExch\tbidMask\taskMask\tbidPrice2\taskPrice2\tcumBidSize2\tcumAskSize2\tbidTime\taskTime";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
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

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionOpenMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tuBid\tuAsk\tbidPx\taskPx\tbidIV\taskIV\tsrPrc\tsrVol\tsrSrc\tde\tga\tth\tve\trh\tph\tsdiv\tddiv\trate\terror\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(UBid);
				recordBuilder.Append("\t");
				recordBuilder.Append(UAsk);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPx);
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
				recordBuilder.Append(Error);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionPrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\texch\tprtPrice\tprtSize\tprtType\tprtVolume\tcxlVolume\tlastPrice\tlastSize\tlastTime\tbidCount\taskCount\tbidVolume\taskVolume\tebid\teask\tebsz\teasz\teage\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.Exch);
				recordBuilder.Append("\t");

				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtType);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(CxlVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(LastPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(LastSize);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(LastTime);
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
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class OptionSettlementMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp\tearly\tpriorPeriod\tsettleDate\tsettlePx\tsettleDe\tlowLmtPx\thighLmtPx\topenInt\tvolume\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Okey.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.Early);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.PriorPeriod);
				recordBuilder.Append("\t");

				recordBuilder.Append(SettleDate);
				recordBuilder.Append("\t");
				recordBuilder.Append(SettlePx);
				recordBuilder.Append("\t");
				recordBuilder.Append(SettleDe);
				recordBuilder.Append("\t");
				recordBuilder.Append(LowLmtPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(HighLmtPx);
				recordBuilder.Append("\t");
				recordBuilder.Append(OpenInt);
				recordBuilder.Append("\t");
				recordBuilder.Append(Volume);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class SpreadQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tsprdSource\tspreadID\tisOurs\tsource\ttype\tpremium\tquantity\tvalidTill\tstockSide\tstockShares\tnumLegs\tokey1_rt\tokey1_ts\tokey1_at\tokey1_yr\tokey1_mn\tokey1_dy\tokey1_xx\tokey1_cp\tmult1\tside1\tokey2_rt\tokey2_ts\tokey2_at\tokey2_yr\tokey2_mn\tokey2_dy\tokey2_xx\tokey2_cp\tmult2\tside2\tokey3_rt\tokey3_ts\tokey3_at\tokey3_yr\tokey3_mn\tokey3_dy\tokey3_xx\tokey3_cp\tmult3\tside3\tokey4_rt\tokey4_ts\tokey4_at\tokey4_yr\tokey4_mn\tokey4_dy\tokey4_xx\tokey4_cp\tmult4\tside4\tokey5_rt\tokey5_ts\tokey5_at\tokey5_yr\tokey5_mn\tokey5_dy\tokey5_xx\tokey5_cp\tmult5\tside5\tokey6_rt\tokey6_ts\tokey6_at\tokey6_yr\tokey6_mn\tokey6_dy\tokey6_xx\tokey6_cp\tmult6\tside6\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(pkey.SprdSource);
				recordBuilder.Append("\t");

				recordBuilder.Append(SpreadID);
				recordBuilder.Append("\t");
				recordBuilder.Append(IsOurs);
				recordBuilder.Append("\t");
				recordBuilder.Append(Source);
				recordBuilder.Append("\t");
				recordBuilder.Append(Type);
				recordBuilder.Append("\t");
				recordBuilder.Append(Premium);
				recordBuilder.Append("\t");
				recordBuilder.Append(Quantity);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(ValidTill);
				recordBuilder.Append("\t");
				recordBuilder.Append(StockSide);
				recordBuilder.Append("\t");
				recordBuilder.Append(StockShares);
				recordBuilder.Append("\t");
				recordBuilder.Append(NumLegs);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey1.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult1);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side1);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey2.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult2);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side2);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey3.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult3);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side3);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey4.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult4);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side4);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey5.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult5);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side5);
				recordBuilder.Append("\t");
				recordBuilder.Append(Okey6.TabRecord);
				recordBuilder.Append("\t");
				recordBuilder.Append(Mult6);
				recordBuilder.Append("\t");
				recordBuilder.Append(Side6);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockBookQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tbidPrice1\tbidSize1\tbidExch1\tbidMask1\taskPrice1\taskSize1\taskExch1\taskMask1\tbidPrice2\tbidSize2\tbidExch2\tbidMask2\taskPrice2\taskSize2\taskExch2\taskMask2\texpCnt\texpWidth\tbidPrintQuan\taskPrintQuan\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
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
				recordBuilder.Append(ExpCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpWidth);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidPrintQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrintQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockCloseMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tbidPrc\taskPrc\tclosePrc\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(BidPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClosePrc);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockCloseQuote
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tbidPrice\taskPrice\tbidSize\taskSize\tbidExch\taskExch\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(BidPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(BidExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskExch);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockOpenMark
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tbidPrc\taskPrc\tclosePrc\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(BidPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(AskPrc);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClosePrc);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }

    public partial class StockPrint
    {
		[ThreadStatic] private static StringBuilder recordBuilder;

		public const string TabHeader = "ticker_tk\tticker_ts\tticker_at\tmarketStatus\tprtExch\tprtSize\tprtQuan\tprtPrice\tprtVolume\tlastTick\tiniPrice\tmrkPrice\topnPrice\tclsPrice\tminPrice\tmaxPrice\tbCnt\tsCnt\tshBot\tshSld\tshMny\texpCnt\texpV1\texpV2\texpV3\texpV4\texpV5\ttimestamp";

		public string TabRecord
        {
            get
			{
				if (recordBuilder == null)	recordBuilder = new StringBuilder(4096);
				else						recordBuilder.Clear();

				recordBuilder.Append(pkey.Ticker.TabRecord);
				recordBuilder.Append("\t");

				recordBuilder.Append(MarketStatus);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtExch);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtSize);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtQuan);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(PrtVolume);
				recordBuilder.Append("\t");
				recordBuilder.Append(LastTick);
				recordBuilder.Append("\t");
				recordBuilder.Append(IniPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MrkPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(OpnPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(ClsPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MinPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(MaxPrice);
				recordBuilder.Append("\t");
				recordBuilder.Append(BCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(SCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(ShBot);
				recordBuilder.Append("\t");
				recordBuilder.Append(ShSld);
				recordBuilder.Append("\t");
				recordBuilder.Append(ShMny);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpCnt);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpV1);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpV2);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpV3);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpV4);
				recordBuilder.Append("\t");
				recordBuilder.Append(ExpV5);
				recordBuilder.Append("\t");
				recordBuilder.AppendInTabRecordFormat(Timestamp);

				return recordBuilder.ToString();
			}
        }
    }


}
