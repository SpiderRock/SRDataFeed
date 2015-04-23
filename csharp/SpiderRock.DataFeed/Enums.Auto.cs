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

	public enum CallOrPut : byte { Call=0,Put=1 };		
 	public enum FitType : byte { None=0,Ci=1,Ii=2,CiCs=3,IiCs=4,CiCm=5,IiCm=6,CiCsCm=7,IiCsCm=8 };		
 	public enum FutExch : byte { None=0,CFE=1,CME=2,CBT=3,COMEX=4,NYMEX=5,ICE=6 };		
 	public enum LiveSurfaceType : byte { None=0,Live=1,Hist=2,PriorDay=3 };		
 	public enum MarkSource : byte { None=0,NbboMid=1,SRVol=2,LoBound=3,HiBound=4,SRPricer=5,SRQuote=6 };		
 	public enum MarketStatus : byte { None=0,PreOpen=1,Open=2,AfterHours=3,Halted=4 };		
 	public enum OptExch : byte { None=0,AMEX=1,BOX=2,CBOE=3,ISE=4,NYSE=5,PHLX=6,NSDQ=7,BATS=8,C2=9,NQBX=10,MIAX=11,GMNI=12,CME=13,CBOT=14,NYMEX=15,COMEX=16 };		
 	public enum SettleTime : byte { None=0,PM=1,AM=2 };		
 	public enum StkExch : byte { None=0,AMEX=1,NQBX=2,NSX=3,FNRA=4,ISE=5,EDGA=6,EDGX=7,CHX=8,NYSE=9,ARCA=10,NSDQ=11,CBSX=12,PSX=13,BTSY=14,BATS=15,CBIDX=16 };		
 	public enum StockTick : byte { None=0,Up=1,Down=2 };		
 	public enum YesNo : byte { None=0,Yes=1,No=2 };		

}
