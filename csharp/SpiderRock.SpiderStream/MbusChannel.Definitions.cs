using System.Net;
namespace SpiderRock.SpiderStream;

public static partial class MbusChannel
{
    /*
     * When synchronizing this with net.Channel contents, the regex is ^.*?=\s*(\w+).*?=\s*([^,]+).*$  
     * to be replaced with
     * public static IPEndPoint $1 { get; } = RegisteredIPEndPoint.Create(Environment, $2, nameof($1));\r\n
     */

    public const SysEnvironment Environment = SysEnvironment.Saturn;

    public static IPEndPoint StkNbboQuoteAB { get; } = RegisteredIPEndPoint.Create(Environment, 1, nameof(StkNbboQuoteAB));
    public static IPEndPoint StkNbboQuoteCD { get; } = RegisteredIPEndPoint.Create(Environment, 2, nameof(StkNbboQuoteCD));
    public static IPEndPoint StkNbboQuoteEF { get; } = RegisteredIPEndPoint.Create(Environment, 3, nameof(StkNbboQuoteEF));
    public static IPEndPoint StkNbboQuoteGH { get; } = RegisteredIPEndPoint.Create(Environment, 4, nameof(StkNbboQuoteGH));
    public static IPEndPoint StkNbboQuoteM { get; } = RegisteredIPEndPoint.Create(Environment, 5, nameof(StkNbboQuoteM));
    public static IPEndPoint StkNbboQuoteS { get; } = RegisteredIPEndPoint.Create(Environment, 6, nameof(StkNbboQuoteS));
    public static IPEndPoint StkNbboQuoteJ1 { get; } = RegisteredIPEndPoint.Create(Environment, 7, nameof(StkNbboQuoteJ1));
    public static IPEndPoint NmsSpreadQuote { get; } = RegisteredIPEndPoint.Create(Environment, 17, nameof(NmsSpreadQuote));
    public static IPEndPoint SRSynthetic { get; } = RegisteredIPEndPoint.Create(Environment, 18, nameof(SRSynthetic));
    public static IPEndPoint FutNbboQuoteV { get; } = RegisteredIPEndPoint.Create(Environment, 20, nameof(FutNbboQuoteV));
    public static IPEndPoint FutNbboQuoteX { get; } = RegisteredIPEndPoint.Create(Environment, 21, nameof(FutNbboQuoteX));
    public static IPEndPoint CmeAdmin { get; } = RegisteredIPEndPoint.Create(Environment, 25, nameof(CmeAdmin));
    public static IPEndPoint CfeAdmin { get; } = RegisteredIPEndPoint.Create(Environment, 27, nameof(CfeAdmin));
    public static IPEndPoint EqtAdmin { get; } = RegisteredIPEndPoint.Create(Environment, 28, nameof(EqtAdmin));
    public static IPEndPoint FundQuoteJ2J3J4J5 { get; } = RegisteredIPEndPoint.Create(Environment, 39, nameof(FundQuoteJ2J3J4J5));
    public static IPEndPoint IdxQuoteI1 { get; } = RegisteredIPEndPoint.Create(Environment, 51, nameof(IdxQuoteI1));
    public static IPEndPoint IdxQuoteI2 { get; } = RegisteredIPEndPoint.Create(Environment, 52, nameof(IdxQuoteI2));
    public static IPEndPoint IdxQuoteI3 { get; } = RegisteredIPEndPoint.Create(Environment, 53, nameof(IdxQuoteI3));
    public static IPEndPoint IdxQuoteI4 { get; } = RegisteredIPEndPoint.Create(Environment, 54, nameof(IdxQuoteI4));
    public static IPEndPoint StkQuoteProbABCD { get; } = RegisteredIPEndPoint.Create(Environment, 81, nameof(StkQuoteProbABCD));
    public static IPEndPoint StkQuoteProbEFGH { get; } = RegisteredIPEndPoint.Create(Environment, 82, nameof(StkQuoteProbEFGH));
    public static IPEndPoint StkQuoteProbM { get; } = RegisteredIPEndPoint.Create(Environment, 83, nameof(StkQuoteProbM));
    public static IPEndPoint StkQuoteProbS { get; } = RegisteredIPEndPoint.Create(Environment, 84, nameof(StkQuoteProbS));
    public static IPEndPoint FutQuoteProbV { get; } = RegisteredIPEndPoint.Create(Environment, 85, nameof(FutQuoteProbV));
    public static IPEndPoint FutQuoteProbX1 { get; } = RegisteredIPEndPoint.Create(Environment, 86, nameof(FutQuoteProbX1));
    public static IPEndPoint FutQuoteProbX2 { get; } = RegisteredIPEndPoint.Create(Environment, 87, nameof(FutQuoteProbX2));
    public static IPEndPoint FutQuoteProbX3 { get; } = RegisteredIPEndPoint.Create(Environment, 88, nameof(FutQuoteProbX3));
    public static IPEndPoint FutQuoteProbX4 { get; } = RegisteredIPEndPoint.Create(Environment, 89, nameof(FutQuoteProbX4));
    public static IPEndPoint OptQuoteProbAB { get; } = RegisteredIPEndPoint.Create(Environment, 91, nameof(OptQuoteProbAB));
    public static IPEndPoint OptQuoteProbCD { get; } = RegisteredIPEndPoint.Create(Environment, 92, nameof(OptQuoteProbCD));
    public static IPEndPoint OptQuoteProbEF { get; } = RegisteredIPEndPoint.Create(Environment, 93, nameof(OptQuoteProbEF));
    public static IPEndPoint OptQuoteProbGH { get; } = RegisteredIPEndPoint.Create(Environment, 94, nameof(OptQuoteProbGH));
    public static IPEndPoint OptQuoteProbM { get; } = RegisteredIPEndPoint.Create(Environment, 95, nameof(OptQuoteProbM));
    public static IPEndPoint OptQuoteProbS { get; } = RegisteredIPEndPoint.Create(Environment, 96, nameof(OptQuoteProbS));
    public static IPEndPoint OptQuoteProbX1 { get; } = RegisteredIPEndPoint.Create(Environment, 100, nameof(OptQuoteProbX1));
    public static IPEndPoint OptQuoteProbX2 { get; } = RegisteredIPEndPoint.Create(Environment, 101, nameof(OptQuoteProbX2));
    public static IPEndPoint OptQuoteProbX3 { get; } = RegisteredIPEndPoint.Create(Environment, 102, nameof(OptQuoteProbX3));
    public static IPEndPoint OptQuoteProbX4 { get; } = RegisteredIPEndPoint.Create(Environment, 103, nameof(OptQuoteProbX4));
    public static IPEndPoint OptNbboQuoteA { get; } = RegisteredIPEndPoint.Create(Environment, 110, nameof(OptNbboQuoteA));
    public static IPEndPoint OptNbboQuoteB { get; } = RegisteredIPEndPoint.Create(Environment, 111, nameof(OptNbboQuoteB));
    public static IPEndPoint OptNbboQuoteC { get; } = RegisteredIPEndPoint.Create(Environment, 112, nameof(OptNbboQuoteC));
    public static IPEndPoint OptNbboQuoteD { get; } = RegisteredIPEndPoint.Create(Environment, 113, nameof(OptNbboQuoteD));
    public static IPEndPoint OptNbboQuoteE { get; } = RegisteredIPEndPoint.Create(Environment, 114, nameof(OptNbboQuoteE));
    public static IPEndPoint OptNbboQuoteF { get; } = RegisteredIPEndPoint.Create(Environment, 115, nameof(OptNbboQuoteF));
    public static IPEndPoint OptNbboQuoteG { get; } = RegisteredIPEndPoint.Create(Environment, 116, nameof(OptNbboQuoteG));
    public static IPEndPoint OptNbboQuoteH { get; } = RegisteredIPEndPoint.Create(Environment, 117, nameof(OptNbboQuoteH));
    public static IPEndPoint OptNbboQuoteM { get; } = RegisteredIPEndPoint.Create(Environment, 118, nameof(OptNbboQuoteM));
    public static IPEndPoint OptNbboQuoteS { get; } = RegisteredIPEndPoint.Create(Environment, 119, nameof(OptNbboQuoteS));
    public static IPEndPoint OptNbboQuoteX1 { get; } = RegisteredIPEndPoint.Create(Environment, 125, nameof(OptNbboQuoteX1));
    public static IPEndPoint OptNbboQuoteX2 { get; } = RegisteredIPEndPoint.Create(Environment, 126, nameof(OptNbboQuoteX2));
    public static IPEndPoint OptNbboQuoteX3 { get; } = RegisteredIPEndPoint.Create(Environment, 127, nameof(OptNbboQuoteX3));
    public static IPEndPoint OptNbboQuoteX4 { get; } = RegisteredIPEndPoint.Create(Environment, 128, nameof(OptNbboQuoteX4));
    public static IPEndPoint OptNbboQuoteT { get; } = RegisteredIPEndPoint.Create(Environment, 129, nameof(OptNbboQuoteT));
    public static IPEndPoint CobExchQuoteIse { get; } = RegisteredIPEndPoint.Create(Environment, 150, nameof(CobExchQuoteIse));
    public static IPEndPoint CobExchQuoteCboe { get; } = RegisteredIPEndPoint.Create(Environment, 151, nameof(CobExchQuoteCboe));
    public static IPEndPoint CobExchQuotePhlx { get; } = RegisteredIPEndPoint.Create(Environment, 152, nameof(CobExchQuotePhlx));
    public static IPEndPoint SyntheticQuote { get; } = RegisteredIPEndPoint.Create(Environment, 158, nameof(SyntheticQuote));
    public static IPEndPoint C1OpenAuction { get; } = RegisteredIPEndPoint.Create(Environment, 159, nameof(C1OpenAuction));
    public static IPEndPoint OptOrder { get; } = RegisteredIPEndPoint.Create(Environment, 161, nameof(OptOrder));
    public static IPEndPoint OptOrderPhlx { get; } = RegisteredIPEndPoint.Create(Environment, 162, nameof(OptOrderPhlx));
    public static IPEndPoint OptOrderCboe { get; } = RegisteredIPEndPoint.Create(Environment, 163, nameof(OptOrderCboe));
    public static IPEndPoint OptOrderC2 { get; } = RegisteredIPEndPoint.Create(Environment, 164, nameof(OptOrderC2));
    public static IPEndPoint OptOrderIse { get; } = RegisteredIPEndPoint.Create(Environment, 165, nameof(OptOrderIse));
    public static IPEndPoint OptOrderBox { get; } = RegisteredIPEndPoint.Create(Environment, 166, nameof(OptOrderBox));
    public static IPEndPoint OptOrderMiax { get; } = RegisteredIPEndPoint.Create(Environment, 167, nameof(OptOrderMiax));
    public static IPEndPoint OptOrderEmld { get; } = RegisteredIPEndPoint.Create(Environment, 168, nameof(OptOrderEmld));
    public static IPEndPoint OptOrderNyse { get; } = RegisteredIPEndPoint.Create(Environment, 169, nameof(OptOrderNyse));
    public static IPEndPoint Imbalance { get; } = RegisteredIPEndPoint.Create(Environment, 170, nameof(Imbalance));
    public static IPEndPoint ImbalanceArca { get; } = RegisteredIPEndPoint.Create(Environment, 171, nameof(ImbalanceArca));
    public static IPEndPoint ImbalanceNyse { get; } = RegisteredIPEndPoint.Create(Environment, 172, nameof(ImbalanceNyse));
    public static IPEndPoint ImbalanceNasdaq { get; } = RegisteredIPEndPoint.Create(Environment, 173, nameof(ImbalanceNasdaq));
    public static IPEndPoint StkPrintMarkup { get; } = RegisteredIPEndPoint.Create(Environment, 180, nameof(StkPrintMarkup));
    public static IPEndPoint OptPrintMarkup { get; } = RegisteredIPEndPoint.Create(Environment, 181, nameof(OptPrintMarkup));
    public static IPEndPoint FutPrintMarkupV { get; } = RegisteredIPEndPoint.Create(Environment, 183, nameof(FutPrintMarkupV));
    public static IPEndPoint FutPrintMarkupX1 { get; } = RegisteredIPEndPoint.Create(Environment, 184, nameof(FutPrintMarkupX1));
    public static IPEndPoint FutPrintMarkupX2 { get; } = RegisteredIPEndPoint.Create(Environment, 185, nameof(FutPrintMarkupX2));
    public static IPEndPoint FutPrintMarkupX3 { get; } = RegisteredIPEndPoint.Create(Environment, 186, nameof(FutPrintMarkupX3));
    public static IPEndPoint FutPrintMarkupX4 { get; } = RegisteredIPEndPoint.Create(Environment, 187, nameof(FutPrintMarkupX4));
    public static IPEndPoint LiveImpliedQuoteAB { get; } = RegisteredIPEndPoint.Create(Environment, 190, nameof(LiveImpliedQuoteAB));
    public static IPEndPoint LiveImpliedQuoteCD { get; } = RegisteredIPEndPoint.Create(Environment, 191, nameof(LiveImpliedQuoteCD));
    public static IPEndPoint LiveImpliedQuoteEF { get; } = RegisteredIPEndPoint.Create(Environment, 192, nameof(LiveImpliedQuoteEF));
    public static IPEndPoint LiveImpliedQuoteGH { get; } = RegisteredIPEndPoint.Create(Environment, 193, nameof(LiveImpliedQuoteGH));
    public static IPEndPoint LiveImpliedQuoteM { get; } = RegisteredIPEndPoint.Create(Environment, 194, nameof(LiveImpliedQuoteM));
    public static IPEndPoint LiveImpliedQuoteS { get; } = RegisteredIPEndPoint.Create(Environment, 195, nameof(LiveImpliedQuoteS));
    public static IPEndPoint LiveImpliedQuoteX1 { get; } = RegisteredIPEndPoint.Create(Environment, 196, nameof(LiveImpliedQuoteX1));
    public static IPEndPoint LiveImpliedQuoteX2 { get; } = RegisteredIPEndPoint.Create(Environment, 197, nameof(LiveImpliedQuoteX2));
    public static IPEndPoint LiveImpliedQuoteX3 { get; } = RegisteredIPEndPoint.Create(Environment, 198, nameof(LiveImpliedQuoteX3));
    public static IPEndPoint LiveImpliedQuoteX4 { get; } = RegisteredIPEndPoint.Create(Environment, 199, nameof(LiveImpliedQuoteX4));
    public static IPEndPoint LiveImpliedQuoteT { get; } = RegisteredIPEndPoint.Create(Environment, 200, nameof(LiveImpliedQuoteT));
}
