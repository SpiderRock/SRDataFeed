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
        private static readonly MessageType Lowest = 100;
        private static readonly MessageType Highest = 504;

        public static readonly MessageType None = 0;
        public static readonly MessageType Max = 1000;

		public static readonly MessageType CCodeDefinition = 110;
 		public static readonly MessageType FutureBookQuote = 111;
 		public static readonly MessageType FuturePrint = 115;
 		public static readonly MessageType FutureSettlementMark = 375;
 		public static readonly MessageType LiveSurfaceAtm = 356;
 		public static readonly MessageType OptionCloseMark = 373;
 		public static readonly MessageType OptionCloseQuote = 104;
 		public static readonly MessageType OptionImpliedQuote = 377;
 		public static readonly MessageType OptionNbboQuote = 102;
 		public static readonly MessageType OptionOpenMark = 105;
 		public static readonly MessageType OptionPrint = 106;
 		public static readonly MessageType OptionRiskFactor = 379;
 		public static readonly MessageType OptionSettlementMark = 374;
 		public static readonly MessageType RootDefinition = 100;
 		public static readonly MessageType StockBookQuote = 121;
 		public static readonly MessageType StockCloseMark = 125;
 		public static readonly MessageType StockCloseQuote = 123;
 		public static readonly MessageType StockOpenMark = 124;
 		public static readonly MessageType StockPrint = 122;

		internal static readonly MessageType CacheComplete = 504;
 		internal static readonly MessageType GetCache = 503;

		
		private static bool[] CreateIsCoreTestVector()
		{
			var isCore = CreateSizedArray<bool>();
			
			isCore[CCodeDefinition] = true;
 			isCore[FutureBookQuote] = true;
 			isCore[FuturePrint] = true;
 			isCore[FutureSettlementMark] = true;
 			isCore[LiveSurfaceAtm] = true;
 			isCore[OptionCloseMark] = true;
 			isCore[OptionCloseQuote] = true;
 			isCore[OptionImpliedQuote] = true;
 			isCore[OptionNbboQuote] = true;
 			isCore[OptionOpenMark] = true;
 			isCore[OptionPrint] = true;
 			isCore[OptionRiskFactor] = true;
 			isCore[OptionSettlementMark] = true;
 			isCore[RootDefinition] = true;
 			isCore[StockBookQuote] = true;
 			isCore[StockCloseMark] = true;
 			isCore[StockCloseQuote] = true;
 			isCore[StockOpenMark] = true;
 			isCore[StockPrint] = true;

			
			return isCore;
		}
		
		private static bool[] CreateIsAdminTestVector()
		{
			var isAdmin = CreateSizedArray<bool>();
			
			isAdmin[CacheComplete] = true;
 			isAdmin[GetCache] = true;

			
			return isAdmin;
		}
		
		private static string[] CreateNamesVector()
		{
			var names = CreateSizedArray<string>();

			names[CCodeDefinition] = "CCodeDefinition";
 			names[CacheComplete] = "CacheComplete";
 			names[FutureBookQuote] = "FutureBookQuote";
 			names[FuturePrint] = "FuturePrint";
 			names[FutureSettlementMark] = "FutureSettlementMark";
 			names[GetCache] = "GetCache";
 			names[LiveSurfaceAtm] = "LiveSurfaceAtm";
 			names[OptionCloseMark] = "OptionCloseMark";
 			names[OptionCloseQuote] = "OptionCloseQuote";
 			names[OptionImpliedQuote] = "OptionImpliedQuote";
 			names[OptionNbboQuote] = "OptionNbboQuote";
 			names[OptionOpenMark] = "OptionOpenMark";
 			names[OptionPrint] = "OptionPrint";
 			names[OptionRiskFactor] = "OptionRiskFactor";
 			names[OptionSettlementMark] = "OptionSettlementMark";
 			names[RootDefinition] = "RootDefinition";
 			names[StockBookQuote] = "StockBookQuote";
 			names[StockCloseMark] = "StockCloseMark";
 			names[StockCloseQuote] = "StockCloseQuote";
 			names[StockOpenMark] = "StockOpenMark";
 			names[StockPrint] = "StockPrint";

			
			return names;
		}
	}
}
