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
        public static readonly MessageType Max = 0x2000;

		public static readonly MessageType FutureBookQuote = 360;
 		public static readonly MessageType FuturePrint = 370;
 		public static readonly MessageType IndexQuote = 137;
 		public static readonly MessageType LiveSurfaceAtm = 2160;
 		public static readonly MessageType OptionImpliedQuote = 2300;
 		public static readonly MessageType OptionNbboQuote = 260;
 		public static readonly MessageType OptionPrint = 300;
 		public static readonly MessageType OptionRiskFactor = 2320;
 		public static readonly MessageType ProductDefinitionV2 = 2455;
 		public static readonly MessageType RootDefinition = 240;
 		public static readonly MessageType SpreadBookQuote = 525;
 		public static readonly MessageType StockBookQuote = 430;
 		public static readonly MessageType StockExchImbalanceV2 = 491;
 		public static readonly MessageType StockMarketSummary = 445;
 		public static readonly MessageType StockPrint = 440;
 		public static readonly MessageType TickerDefinition = 420;

		internal static readonly MessageType CacheComplete = 4106;
 		internal static readonly MessageType GetCache = 4096;
 		internal static readonly MessageType NetPulse = 5000;

		
		private static bool[] CreateIsCoreTestVector()
		{
			var isCore = CreateSizedArray<bool>();
			
			isCore[FutureBookQuote] = true;
 			isCore[FuturePrint] = true;
 			isCore[IndexQuote] = true;
 			isCore[LiveSurfaceAtm] = true;
 			isCore[OptionImpliedQuote] = true;
 			isCore[OptionNbboQuote] = true;
 			isCore[OptionPrint] = true;
 			isCore[OptionRiskFactor] = true;
 			isCore[ProductDefinitionV2] = true;
 			isCore[RootDefinition] = true;
 			isCore[SpreadBookQuote] = true;
 			isCore[StockBookQuote] = true;
 			isCore[StockExchImbalanceV2] = true;
 			isCore[StockMarketSummary] = true;
 			isCore[StockPrint] = true;
 			isCore[TickerDefinition] = true;

			
			return isCore;
		}
		
		private static bool[] CreateIsAdminTestVector()
		{
			var isAdmin = CreateSizedArray<bool>();
			
			isAdmin[CacheComplete] = true;
 			isAdmin[GetCache] = true;
 			isAdmin[NetPulse] = true;

			
			return isAdmin;
		}
		
		private static string[] CreateNamesVector()
		{
			var names = CreateSizedArray<string>();

			names[CacheComplete] = "CacheComplete";
 			names[FutureBookQuote] = "FutureBookQuote";
 			names[FuturePrint] = "FuturePrint";
 			names[GetCache] = "GetCache";
 			names[IndexQuote] = "IndexQuote";
 			names[LiveSurfaceAtm] = "LiveSurfaceAtm";
 			names[NetPulse] = "NetPulse";
 			names[OptionImpliedQuote] = "OptionImpliedQuote";
 			names[OptionNbboQuote] = "OptionNbboQuote";
 			names[OptionPrint] = "OptionPrint";
 			names[OptionRiskFactor] = "OptionRiskFactor";
 			names[ProductDefinitionV2] = "ProductDefinitionV2";
 			names[RootDefinition] = "RootDefinition";
 			names[SpreadBookQuote] = "SpreadBookQuote";
 			names[StockBookQuote] = "StockBookQuote";
 			names[StockExchImbalanceV2] = "StockExchImbalanceV2";
 			names[StockMarketSummary] = "StockMarketSummary";
 			names[StockPrint] = "StockPrint";
 			names[TickerDefinition] = "TickerDefinition";

			
			return names;
		}
	}
}
