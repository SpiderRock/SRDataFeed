namespace SpiderRock.DataFeed
{
    public enum UdpChannel : byte
    {
        StkNbboQuote1 = 1,
        StkNbboQuote2 = 2,
        StkNbboQuote3 = 3,
        StkNbboQuote4 = 4,

        OptNbboQuote1 = 11,
        OptNbboQuote2 = 12,
        OptNbboQuote3 = 13,
        OptNbboQuote4 = 14,

        FutQuoteCme = 21,
        FutQuoteCbot = 22,
        FutQuoteNymex = 23,
        FutQuoteComex = 24,

        CMEAdmin = 25,

        OptQuoteCme = 31,
        OptQuoteCbot = 32,
        OptQuoteNymex = 33,
        OptQuoteComex = 34,

        FutQuoteCfe = 41,

        IdxQuoteRut = 51,
        IdxQuoteCboe = 52,

        ImpliedQuoteNmsLoop = 61,
        ImpliedQuoteCme = 62,
        ImpliedQuoteCbot = 63,
        ImpliedQuoteNymex = 64,
        ImpliedQuoteComex = 65,

        ImpliedQuoteNms1 = 71,
        ImpliedQuoteNms2 = 72,
        ImpliedQuoteNms3 = 73,
        ImpliedQuoteNms4 = 74,

        StkExchQuote1Nsdq = 101,
        StkExchQuote2Nsdq = 102,
        StkExchQuote3Nsdq = 103,
        StkExchQuote4Nsdq = 104,

        StkExchQuote1Bats = 111,
        StkExchQuote2Bats = 112,
        StkExchQuote3Bats = 113,
        StkExchQuote4Bats = 114,

        StkExchQuote1Btsy = 121,
        StkExchQuote2Btsy = 122,
        StkExchQuote3Btsy = 123,
        StkExchQuote4Btsy = 124,

        StkExchQuote1Edgx = 131,
        StkExchQuote2Edgx = 132,
        StkExchQuote3Edgx = 133,
        StkExchQuote4Edgx = 134,

        StkExchQuote1Edga = 141,
        StkExchQuote2Edga = 142,
        StkExchQuote3Edga = 143,
        StkExchQuote4Edga = 144
    }
}