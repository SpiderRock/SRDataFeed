using System;
using System.Collections.Generic;
using System.Net;
namespace SpiderRock.SpiderStream;

public static class MbusChannel
{
    private static readonly Dictionary<string, RegisteredIPEndPoint> Registered = new();

    private class RegisteredIPEndPoint : IPEndPoint
    {
        private readonly string name;

        public RegisteredIPEndPoint(IPEndPoint ipEndPoint, string name)
            : base(ipEndPoint.Address, ipEndPoint.Port)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            this.name = name;

            Registered[this.name.ToLowerInvariant()] = this;
        }

        public override string ToString() => $"{name}[{base.ToString()}]";
    }

    public static IPEndPoint FromName(string name) => Registered.TryGetValue(name.ToLowerInvariant(), out var ep)
        ? ep
        : throw new ArgumentException($"Unknown channel {name}");

    /*
     * When synchronizing this with net.Channel contents, the regex is ^.*?=\s*(\w+).*?=\s*([^,]+).*$  
     * to be replaced with
     * public static IPEndPoint $1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("$2"), nameof($1));\r\n
     */

    public static IPEndPoint StkNbboQuoteABCD { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.1:28251"), nameof(StkNbboQuoteABCD));
    public static IPEndPoint StkNbboQuoteEFGH { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.2:28252"), nameof(StkNbboQuoteEFGH));
    public static IPEndPoint StkNbboQuoteM { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.3:28253"), nameof(StkNbboQuoteM));
    public static IPEndPoint StkNbboQuoteS { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.4:28254"), nameof(StkNbboQuoteS));
    public static IPEndPoint StkNbboQuoteJ1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.5:28255"), nameof(StkNbboQuoteJ1));
    public static IPEndPoint NmsSpreadQuote { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.17:28267"), nameof(NmsSpreadQuote));
    public static IPEndPoint SRSynthetic { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.18:28268"), nameof(SRSynthetic));
    public static IPEndPoint FutNbboQuoteV { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.20:28270"), nameof(FutNbboQuoteV));
    public static IPEndPoint FutNbboQuoteX { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.21:28271"), nameof(FutNbboQuoteX));
    public static IPEndPoint CmeAdmin { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.25:28275"), nameof(CmeAdmin));
    public static IPEndPoint CfeAdmin { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.27:28277"), nameof(CfeAdmin));
    public static IPEndPoint EqtAdmin { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.28:28278"), nameof(EqtAdmin));
    public static IPEndPoint Pulse { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.30:28280"), nameof(Pulse));
    public static IPEndPoint FundQuoteJ2J3J4J5 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.39:28289"), nameof(FundQuoteJ2J3J4J5));
    public static IPEndPoint IdxQuoteI1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.51:28301"), nameof(IdxQuoteI1));
    public static IPEndPoint IdxQuoteI2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.52:28302"), nameof(IdxQuoteI2));
    public static IPEndPoint IdxQuoteI3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.53:28303"), nameof(IdxQuoteI3));
    public static IPEndPoint IdxQuoteI4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.54:28304"), nameof(IdxQuoteI4));
    public static IPEndPoint StkQuoteProbABCD { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.81:28331"), nameof(StkQuoteProbABCD));
    public static IPEndPoint StkQuoteProbEFGH { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.82:28332"), nameof(StkQuoteProbEFGH));
    public static IPEndPoint StkQuoteProbM { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.83:28333"), nameof(StkQuoteProbM));
    public static IPEndPoint StkQuoteProbS { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.84:28334"), nameof(StkQuoteProbS));
    public static IPEndPoint FutQuoteProbV { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.85:28335"), nameof(FutQuoteProbV));
    public static IPEndPoint FutQuoteProbX1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.86:28336"), nameof(FutQuoteProbX1));
    public static IPEndPoint FutQuoteProbX2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.87:28337"), nameof(FutQuoteProbX2));
    public static IPEndPoint FutQuoteProbX3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.88:28338"), nameof(FutQuoteProbX3));
    public static IPEndPoint FutQuoteProbX4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.89:28339"), nameof(FutQuoteProbX4));
    public static IPEndPoint OptQuoteProbAB { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.91:28341"), nameof(OptQuoteProbAB));
    public static IPEndPoint OptQuoteProbCD { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.92:28342"), nameof(OptQuoteProbCD));
    public static IPEndPoint OptQuoteProbEF { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.93:28343"), nameof(OptQuoteProbEF));
    public static IPEndPoint OptQuoteProbGH { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.94:28344"), nameof(OptQuoteProbGH));
    public static IPEndPoint OptQuoteProbM { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.95:28345"), nameof(OptQuoteProbM));
    public static IPEndPoint OptQuoteProbS { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.96:28346"), nameof(OptQuoteProbS));
    public static IPEndPoint OptQuoteProbX1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.100:28350"), nameof(OptQuoteProbX1));
    public static IPEndPoint OptQuoteProbX2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.101:28351"), nameof(OptQuoteProbX2));
    public static IPEndPoint OptQuoteProbX3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.102:28352"), nameof(OptQuoteProbX3));
    public static IPEndPoint OptQuoteProbX4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.103:28353"), nameof(OptQuoteProbX4));
    public static IPEndPoint OptNbboQuoteA { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.110:28360"), nameof(OptNbboQuoteA));
    public static IPEndPoint OptNbboQuoteB { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.111:28361"), nameof(OptNbboQuoteB));
    public static IPEndPoint OptNbboQuoteC { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.112:28362"), nameof(OptNbboQuoteC));
    public static IPEndPoint OptNbboQuoteD { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.113:28363"), nameof(OptNbboQuoteD));
    public static IPEndPoint OptNbboQuoteE { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.114:28364"), nameof(OptNbboQuoteE));
    public static IPEndPoint OptNbboQuoteF { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.115:28365"), nameof(OptNbboQuoteF));
    public static IPEndPoint OptNbboQuoteG { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.116:28366"), nameof(OptNbboQuoteG));
    public static IPEndPoint OptNbboQuoteH { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.117:28367"), nameof(OptNbboQuoteH));
    public static IPEndPoint OptNbboQuoteM { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.118:28368"), nameof(OptNbboQuoteM));
    public static IPEndPoint OptNbboQuoteS { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.119:28369"), nameof(OptNbboQuoteS));
    public static IPEndPoint OptNbboQuoteX1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.125:28375"), nameof(OptNbboQuoteX1));
    public static IPEndPoint OptNbboQuoteX2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.126:28376"), nameof(OptNbboQuoteX2));
    public static IPEndPoint OptNbboQuoteX3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.127:28377"), nameof(OptNbboQuoteX3));
    public static IPEndPoint OptNbboQuoteX4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.128:28378"), nameof(OptNbboQuoteX4));
    public static IPEndPoint OptNbboQuoteT { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.129:28379"), nameof(OptNbboQuoteT));
    public static IPEndPoint CobExchQuoteIse { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.150:28400"), nameof(CobExchQuoteIse));
    public static IPEndPoint CobExchQuoteCboe { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.151:28401"), nameof(CobExchQuoteCboe));
    public static IPEndPoint CobExchQuotePhlx { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.152:28402"), nameof(CobExchQuotePhlx));
    public static IPEndPoint SyntheticQuote { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.158:28408"), nameof(SyntheticQuote));
    public static IPEndPoint C1OpenAuction { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.159:28409"), nameof(C1OpenAuction));
    public static IPEndPoint OptOrder { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.161:28411"), nameof(OptOrder));
    public static IPEndPoint OptOrderPhlx { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.162:28412"), nameof(OptOrderPhlx));
    public static IPEndPoint OptOrderCboe { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.163:28413"), nameof(OptOrderCboe));
    public static IPEndPoint OptOrderC2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.164:28414"), nameof(OptOrderC2));
    public static IPEndPoint OptOrderIse { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.165:28415"), nameof(OptOrderIse));
    public static IPEndPoint OptOrderBox { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.166:28416"), nameof(OptOrderBox));
    public static IPEndPoint OptOrderMiax { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.167:28417"), nameof(OptOrderMiax));
    public static IPEndPoint OptOrderEmld { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.168:28418"), nameof(OptOrderEmld));
    public static IPEndPoint OptOrderNyse { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.169:28419"), nameof(OptOrderNyse));
    public static IPEndPoint Imbalance { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.170:28420"), nameof(Imbalance));
    public static IPEndPoint ImbalanceArca { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.171:28421"), nameof(ImbalanceArca));
    public static IPEndPoint ImbalanceNyse { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.172:28422"), nameof(ImbalanceNyse));
    public static IPEndPoint ImbalanceNasdaq { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.173:28423"), nameof(ImbalanceNasdaq));
    public static IPEndPoint StkPrintMarkup { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.180:28430"), nameof(StkPrintMarkup));
    public static IPEndPoint OptPrintMarkup { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.181:28431"), nameof(OptPrintMarkup));
    public static IPEndPoint FutPrintMarkupV { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.183:28433"), nameof(FutPrintMarkupV));
    public static IPEndPoint FutPrintMarkupX1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.184:28434"), nameof(FutPrintMarkupX1));
    public static IPEndPoint FutPrintMarkupX2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.185:28435"), nameof(FutPrintMarkupX2));
    public static IPEndPoint FutPrintMarkupX3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.186:28436"), nameof(FutPrintMarkupX3));
    public static IPEndPoint FutPrintMarkupX4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.187:28437"), nameof(FutPrintMarkupX4));
    public static IPEndPoint LiveImpliedQuoteAB { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.190:28440"), nameof(LiveImpliedQuoteAB));
    public static IPEndPoint LiveImpliedQuoteCD { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.191:28441"), nameof(LiveImpliedQuoteCD));
    public static IPEndPoint LiveImpliedQuoteEF { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.192:28442"), nameof(LiveImpliedQuoteEF));
    public static IPEndPoint LiveImpliedQuoteGH { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.193:28443"), nameof(LiveImpliedQuoteGH));
    public static IPEndPoint LiveImpliedQuoteM { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.194:28444"), nameof(LiveImpliedQuoteM));
    public static IPEndPoint LiveImpliedQuoteS { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.195:28445"), nameof(LiveImpliedQuoteS));
    public static IPEndPoint LiveImpliedQuoteX1 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.196:28446"), nameof(LiveImpliedQuoteX1));
    public static IPEndPoint LiveImpliedQuoteX2 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.197:28447"), nameof(LiveImpliedQuoteX2));
    public static IPEndPoint LiveImpliedQuoteX3 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.198:28448"), nameof(LiveImpliedQuoteX3));
    public static IPEndPoint LiveImpliedQuoteX4 { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.199:28449"), nameof(LiveImpliedQuoteX4));
    public static IPEndPoint LiveImpliedQuoteT { get; } = new RegisteredIPEndPoint(IPEndPoint.Parse("233.117.185.200:28450"), nameof(LiveImpliedQuoteT));
}
