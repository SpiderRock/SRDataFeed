// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

namespace SpiderRock.DataFeed
{
    // ReSharper disable InconsistentNaming

	public enum AdjConvention : byte { Original=0,OSI=1,SpcOnly=2,OSIAlt=3 };		
 	public enum AssetType : byte { None=0,EQT=1,IDX=2,BND=3,CUR=4,COM=5,FUT=6,SYN=7,WAR=8,FLX=9,MUT=10,SPD=11,MM=12,MF=13,COIN=14,TOKEN=15 };		
 	public enum AuctionLimitType : byte { None=0,Market=1,Limit=2 };		
 	public enum AuctionReason : byte { None=0,Open=1,Market=2,Halt=3,Closing=4,RegulatoryImbalance=5 };		
 	public enum AuctionState : byte { None=0,Start=1,Update=2,End=3 };		
 	public enum AuctionStatus : byte { None=0,WillRunOpenAndClose=1,WillRunInterest=2,WillNotRunImbalance=3,WillNotRunClsAuction=4 };		
 	public enum AuctionType : byte { None=0,Exposure=1,Improvement=2,Faciliation=3,Solicitation=4,Opening=5,Closing=6,RFQ=7 };		
 	public enum BuySell : byte { None=0,Buy=1,Sell=2 };		
 	public enum CalcSource : byte { None=0,Tick=1,Loop=2,Close=3 };		
 	public enum CalcType : byte { Loop=0,Tick=1 };		
 	public enum CallPut : byte { Call=0,Put=1,Pair=2 };		
 	public enum ClsMarkState : byte { None=0,LastPrt=1,SRClose=2,ExchClose=3,Final=4 };		
 	public enum ContractUnit : byte { None=0,AUD=1,BBL=2,BDFT=3,BRL=4,BU=5,CAD=6,CHF=7,CTRCT=8,CWT=9,CZK=10,EUR=11,GAL=12,GBP=13,HUF=14,ILS=15,IPNT=16,JPY=17,KRW=18,LBS=19,MMBTU=20,MWH=21,MXN=35,MYR=22,NOK=23,NZD=24,PLN=25,RMB=26,RUR=27,SEK=28,TON=29,TRY=31,TRYOZ=32,USD=33,ZAR=34 };		
 	public enum Currency : byte { None=0,AUD=1,BRL=2,CAD=3,CHF=4,CNH=5,CNY=6,EUR=7,GBP=8,JPY=9,KRW=10,MXN=11,MYR=12,NOK=13,NZD=14,SEK=15,TRY=16,USD=17,USDCents=18,CZK=19,ZAR=20,HUF=21,USX=22 };		
 	public enum ExchOrderStatus : byte { None=0,Open=1,Cancelled=2,Filled=3,Retry=4 };		
 	public enum ExchOrderType : byte { None=0,Market=1,Limit=2,Auction=3 };		
 	public enum ExchPrtType : byte { None=0 };		
 	public enum ExecQualifier : byte { None=0,AllOrNone=1 };		
 	public enum ExerciseTime : byte { None=0,PM=1,AM=2 };		
 	public enum ExerciseType : byte { None=0,American=1,European=2,Asian=3,Cliquet=4 };		
 	public enum ExpirationMap : byte { None=0,ExactMatch=1,UnderlierMap=2 };		
 	public enum FirmType : byte { None=0,Customer=1,Firm=2,MarketMaker=3,ProCustomer=4,BrokerDealer=5,AwayMM=6,FirmJBO=7,BrkrDlrCust=8 };		
 	public enum FitPath : byte { None=0,VolUPrc=2,VolUPrcDefault=3,VolSDiv=4,VolSDivDefault=5,BaseDefault=6,BaseDefaultAdj=7,HistVol=8,Default=9,NormalMid=10,WideMid=11,WideGap=12,WideBound=13,AtmRange=14 };		
 	public enum FutExch : byte { None=0,CFE=1,CME=2,CBOT=3,COMEX=4,NYMEX=5,ICE=6 };		
 	public enum GridType : byte { None=0,Unused=1,SRCubic=2,SRCubic2=3,BSpline=4,BSpline2=5 };		
 	public enum IdxSrc : byte { Unknown=0,Indication=1,Quote=2 };		
 	public enum ImbalanceSide : byte { None=0,Buy=1,Sell=2,NoImbalance=3,InsufOrdsToCalc=4 };		
 	public enum LiveSurfaceType : byte { None=0,Live=1,Hist=2,PriorDay=3,Skew=4,LiveSkew=5,LiveAdj=6,Interp=7,Test1=8,Test2=9,Test3=10,LiveC=11,BaseC=12,PrevC=13,HistC=14,InterpC=15,Default=16,BaseEMA_1=17,BaseEMA_2=18,BaseEMA_3=19,Archive=20 };		
 	public enum MarkSource : byte { None=0,NbboMid=1,SRVol=2,LoBound=3,HiBound=4,SRPricer=5,SRQuote=6,CloseMark=7 };		
 	public enum MarketQualifier : byte { None=0,NA=1,Opening=2,Implied=3 };		
 	public enum MarketSession : byte { None=0,EarlySession=1,RegularSession=2,LateSession=3,NextDay=4 };		
 	public enum MarketStatus : byte { None=0,PreOpen=1,PreCross=2,Cross=3,Open=4,Closed=5,Halted=6,AfterHours=7 };		
 	public enum MoneynessType : byte { PctStd=0,LogStd=1,NormStd=2 };		
 	public enum Multihedge : byte { None=0,Simple=1,Complex=2,AllCash=3,Binary=4 };		
 	public enum NoticeShape : byte { None=0,Single=1,MLeg=2 };		
 	[System.Flags] public enum OpraMktType : byte { None=0,Rotation=1,TradingHalted=2,CustInterest=4,QuoteNotFirm=8 };		
 	public enum OptExch : byte { None=0,AMEX=1,BOX=2,CBOE=3,ISE=4,NYSE=5,PHLX=6,NSDQ=7,BATS=8,C2=9,NQBX=10,MIAX=11,GMNI=12,CME=13,CBOT=14,NYMEX=15,COMEX=16,ICE=17,EDGO=18,MCRY=19,MPRL=20,SDRK=21,DQTE=22,EMLD=23,CFE=24 };		
 	public enum OptPriceInc : byte { None=0,PartPenny=1,PartNickle=2,FullPenny=3 };		
 	public enum OptionType : byte { None=0,Equity=1,Index=2,Future=3,Binary=4,Warrant=5,Flex=6,MapError=99 };		
 	public enum PositionType : byte { None=0,Opening=1,Closing=2,Auto=3 };		
 	public enum PriceFormat : byte { None=0,N0=1,N1=2,N2=3,N3=4,N4=5,N5=6,N6=7,N7=8,F4=9,F8=10,Q8=11,F16=12,F32=13,H32=14,Q32=15,F64=16,H64=17,FullPenny=18,PartPenny=19,PartNickle=20,EQT=21,V1=22,V2=23,V3=24,V4=25,V5=26,V6=27,V7=28,V8=29,V9=30,V10=31,V11=32,V12=33,V13=34,V14=35,V15=36,A0=37,A1=38,A2=39,A3=40,A4=41,A5=42,A6=43,A7=44 };		
 	public enum PriceQuoteType : byte { Price=0,Vol=1 };		
 	public enum PricingModel : byte { None=0,Equity=1,FutureApprox=2,FutureExact=3,NormalApprox=4,NormalExact=5 };		
 	public enum PrimaryExch : byte { None=0,NYSE=1,AMEX=2,Nasdaq=3,NasdaqSmallCap=4,Otc=5,Index=6,ARCA=7,CME=8,CBOT=9,NYMEX=10,COMEX=11,ICE=12,BATS=13,IEXG=14 };		
 	public enum ProductClass : byte { None=0,Equity=1,Index=2,Future=3,Option=4,Spread=5 };		
 	public enum ProductIndexType : byte { None=0,NextDay=1,FirstOfMonth=2,VWA=3,Russel=4 };		
 	public enum ProductTerm : byte { None=0,Month=1,Day=2,Week=3,BalanceOfMonth=4,Quarter=5,Season=6,BalanceOfWeek=7,CalendarYear=8,Variable=9,Custom=10,SameDay=11,NextDay=12,Weekly=13,Pack=14,Bundle=15,IRSAndCDSTenor=16 };		
 	public enum ProductType : byte { None=0,Outright=1,CalSpr=2,EqCalSpr=3,FXCalSpr=4,RedTick=5,BFly=6,Condor=7,Strip=8,InterCmd=9,Pack=10,MnPack=11,PackBFly=12,DblBFly=13,PackSpr=14,Crck=15,Bndl=16,BndlSpr=17,EnrStrp=18,BalStrp=19,UnbalStrp=20,EnICStrp=21,IRICStrp=22,ITRICSpr=23,UserDef=24,Combo=25,TAS=26,TASCalSpr=27,TAA=28,TIC=29,BIC=30,TAP=31,Index=32 };		
 	public enum PrtSide : byte { None=0,Mid=1,Bid=2,Ask=3 };		
 	public enum RunStatus : byte { None=0,Prod=1,UAT=2,Beta=3,Demo=4,Alpha=5,SysTest=6 };		
 	public enum SRDataCenter : byte { None=0,NY4=1,NY5=2,CH2=3,CH3=4 };		
 	public enum SpdrKeyType : byte { None=0,Stock=1,Future=2,Option=3,MLeg=4 };		
 	public enum StkExch : byte { None=0,AMEX=1,NQBX=2,NSX=3,FNRA=4,ISE=5,EDGA=6,EDGX=7,CHX=8,NYSE=9,ARCA=10,NSDQ=11,CBSX=12,PSX=13,BTSY=14,BATS=15,CBIDX=16,IEX=17,OTC=18,MPRL=19,LTSE=20,MEMX=21 };		
 	public enum StkPriceInc : byte { None=0,FullPenny=1,Nickle=2 };		
 	public enum StkPrintType : byte { None=0,RegularSequence=1,OutOfSequence=2,VolumeOnly=3,ExtendedHours=4 };		
 	public enum SurfaceResult : byte { None=0,OK=1,EOD=2,Init=3,Cache=4,PrevDay=5,NullExpIdx=6,NoStrikes=7,NoBaseCurve=8,BadBootAtm=9,NoGoodStrikes=10,BadAtmVol=11,Bootstrap=12,NoUPrc=13,NoIVols=14,NoModelPts=15,ZeroYears=16,NoSimpleVol=17,OptMktNotOpn=18,NoBaseSurface=19,UPrcOffCnt=20,SkewKnotCnt=21,Exception=22,AxisError=23,CAskFit1Err=24,CAskFit2Err=25,PAskFit1Err=26,PAskFit2Err=27,CBidFit1Err=28,CBidFit2Err=29,PBidFit1Err=30,PBidFit2Err=31,CobsMidFitErr=42,CobsSampleErr=32,NoPrcFit=33,NumStrikes=34,CMidFitErr=35,PMidFitErr=36,StrikeCount=37,VolKnotCnt=38,InterpError=39,NoAtmStrike=40,CobsConvexFitErr=41 };		
 	public enum SymbolType : byte { None=0,Equity=1,ADR=2,ETF=3,CashIndex=4,MutualFund=5,ShortETF=6,Future=7,Bond=8 };		
 	public enum SysEnvironment : byte { None=0,Stable=1,Current=2,V7_Stable=3,V7_Latest=4,V7_Stable_UAT=5,V7_Latest_UAT=6,V7_Dev=7,SysTest=8 };		
 	public enum TapeCode : byte { None=0,A=1,B=2,C=3 };		
 	public enum TickerSrc : byte { None=0,SR=1,NMS=2,CME=3,ICE=4,CFE=5,CBOT=6,TD=7,NYMEX=8,COMEX=9,RUT=10,CBOE=11,ISE=12,ARCA=13,NYSE=14,OTC=15,GDAX=16,BSTAMP=17,KRAKEN=18,TST=19,USR1=20,USR2=21,USR3=22,NSDQ=23,MFQS=24,PHLX=25,MIAX=26,TSE=27,DJI=28 };		
 	public enum TimeInForce : byte { None=0,Day=1,IOC=2,GTD=3,ExtDay=4,Week=5,ExtWeek=6 };		
 	public enum TimeMetric : byte { None=0,D252=1,D365=2,SPX=3,WK1=4,WK2=5,WK3=6,WK4=7 };		
 	public enum TkDefSource : byte { None=0,Vendor=1,OTC=2,SR=3,Exchange=4 };		
 	public enum TradeableStatus : byte { None=0,OK=1,SurfaceErr=2,LowCCnt=3,LowPCnt=4,FitPrcErr=5,BidAskMiss=6,LowCounter=7,DefaultSkew=8,SessionMiss=9,BaseErr=10,SwitchDelay=11,WideMktV=12,WideMktP=13,WideUMkt=14,UWidthEma=15,CCntEma=16,PCntEma=17,VWidthEma=18,PWidthEma=19,Closed=20 };		
 	public enum UnderlierMode : byte { None=0,Actual=1,FrontMonth=2,UPrcAdj=3 };		
 	public enum UpdateType : byte { None=0,PrcChange=1,SizeOnly=2,PrevPeriod=3 };		
 	public enum VolumeTier : byte { None=0,Top50=1 };		
 	public enum YesNo : byte { None=0,Yes=1,No=2 };		

}
