// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

namespace SpiderRock.DataFeed
{
    public partial struct MessageType
    {
        private static readonly MessageType Lowest = 137;
        private static readonly MessageType Highest = 5000;

        public static readonly MessageType None = 0;
        public static readonly MessageType Max = 11000;

		public static readonly MessageType FutureBookQuote = 360;
 		public static readonly MessageType FuturePrint = 370;
 		public static readonly MessageType FuturePrintMarkup = 3024;
 		public static readonly MessageType IndexQuote = 137;
 		public static readonly MessageType LiveSurfaceAtm = 2160;
 		public static readonly MessageType OptionCloseMark = 292;
 		public static readonly MessageType OptionExchOrder = 270;
 		public static readonly MessageType OptionExchPrint = 275;
 		public static readonly MessageType OptionImpliedQuote = 2300;
 		public static readonly MessageType OptionNbboQuote = 260;
 		public static readonly MessageType OptionOpenInterestV2 = 2131;
 		public static readonly MessageType OptionPrint = 300;
 		public static readonly MessageType OptionPrint2 = 301;
 		public static readonly MessageType OptionPrintMarkup = 3026;
 		public static readonly MessageType OptionRiskFactor = 2320;
 		public static readonly MessageType ProductDefinitionV2 = 2455;
 		public static readonly MessageType RootDefinition = 240;
 		public static readonly MessageType SpreadBookQuote = 525;
 		public static readonly MessageType StockBookQuote = 430;
 		public static readonly MessageType StockExchImbalanceV2 = 491;
 		public static readonly MessageType StockImbalance = 495;
 		public static readonly MessageType StockMarketSummary = 445;
 		public static readonly MessageType StockPrint = 440;
 		public static readonly MessageType StockPrintMarkup = 3022;
 		public static readonly MessageType TickerDefinition = 420;

		internal static readonly MessageType GetExtCache = 4096;
 		internal static readonly MessageType NetPulse = 5000;

		
		private static bool[] CreateIsCoreTestVector()
		{
			var isCore = CreateSizedArray<bool>();
			
			isCore[FutureBookQuote] = true;
 			isCore[FuturePrint] = true;
 			isCore[FuturePrintMarkup] = true;
 			isCore[IndexQuote] = true;
 			isCore[LiveSurfaceAtm] = true;
 			isCore[OptionCloseMark] = true;
 			isCore[OptionExchOrder] = true;
 			isCore[OptionExchPrint] = true;
 			isCore[OptionImpliedQuote] = true;
 			isCore[OptionNbboQuote] = true;
 			isCore[OptionOpenInterestV2] = true;
 			isCore[OptionPrint] = true;
 			isCore[OptionPrint2] = true;
 			isCore[OptionPrintMarkup] = true;
 			isCore[OptionRiskFactor] = true;
 			isCore[ProductDefinitionV2] = true;
 			isCore[RootDefinition] = true;
 			isCore[SpreadBookQuote] = true;
 			isCore[StockBookQuote] = true;
 			isCore[StockExchImbalanceV2] = true;
 			isCore[StockImbalance] = true;
 			isCore[StockMarketSummary] = true;
 			isCore[StockPrint] = true;
 			isCore[StockPrintMarkup] = true;
 			isCore[TickerDefinition] = true;

			
			return isCore;
		}
		
		private static bool[] CreateIsAdminTestVector()
		{
			var isAdmin = CreateSizedArray<bool>();
			
			isAdmin[GetExtCache] = true;
 			isAdmin[NetPulse] = true;

			
			return isAdmin;
		}
		
		private static string[] CreateNamesVector()
		{
			var names = CreateSizedArray<string>();

			names[FutureBookQuote] = "FutureBookQuote";
 			names[FuturePrint] = "FuturePrint";
 			names[FuturePrintMarkup] = "FuturePrintMarkup";
 			names[GetExtCache] = "GetExtCache";
 			names[IndexQuote] = "IndexQuote";
 			names[LiveSurfaceAtm] = "LiveSurfaceAtm";
 			names[NetPulse] = "NetPulse";
 			names[OptionCloseMark] = "OptionCloseMark";
 			names[OptionExchOrder] = "OptionExchOrder";
 			names[OptionExchPrint] = "OptionExchPrint";
 			names[OptionImpliedQuote] = "OptionImpliedQuote";
 			names[OptionNbboQuote] = "OptionNbboQuote";
 			names[OptionOpenInterestV2] = "OptionOpenInterestV2";
 			names[OptionPrint] = "OptionPrint";
 			names[OptionPrint2] = "OptionPrint2";
 			names[OptionPrintMarkup] = "OptionPrintMarkup";
 			names[OptionRiskFactor] = "OptionRiskFactor";
 			names[ProductDefinitionV2] = "ProductDefinitionV2";
 			names[RootDefinition] = "RootDefinition";
 			names[SpreadBookQuote] = "SpreadBookQuote";
 			names[StockBookQuote] = "StockBookQuote";
 			names[StockExchImbalanceV2] = "StockExchImbalanceV2";
 			names[StockImbalance] = "StockImbalance";
 			names[StockMarketSummary] = "StockMarketSummary";
 			names[StockPrint] = "StockPrint";
 			names[StockPrintMarkup] = "StockPrintMarkup";
 			names[TickerDefinition] = "TickerDefinition";

			
			return names;
		}
	}
}
