namespace SpiderRock.DataFeed
{
    public enum UdpChannel : byte
    {
        StkNbboQuote1 = 1,
        StkNbboQuote2 = 2,
        StkNbboQuote3 = 3,
        StkNbboQuote4 = 4,

        OTCNbboQuote = 5,

        OptNbboQuote1 = 11,
        OptNbboQuote2 = 12,
        OptNbboQuote3 = 13,
        OptNbboQuote4 = 14,

        OptNbboQuoteSpx = 15,

        FutQuoteIce = 20,
        FutQuoteCme = 21,
        FutQuoteCbot = 22,
        FutQuoteNymex = 23,
        FutQuoteComex = 24,
        FutQuoteCfe = 41,

        CmeAdmin = 25,
        IceAdmin = 26,
        CfeAdmin = 27,
        EqtAdmin = 28,

        OptQuoteIce = 30,
        OptQuoteCme = 31,
        OptQuoteCbot = 32,
        OptQuoteNymex = 33,
        OptQuoteComex = 34,

        IdxQuoteRut = 51,
        IdxQuoteSR = 52,
        IdxQuoteCboe = 53,

        ImpliedQuoteNmsLoop = 61,

        ImpliedQuoteCme = 62,
        ImpliedQuoteCbot = 63,
        ImpliedQuoteNymex = 64,
        ImpliedQuoteComex = 65,
        ImpliedQuoteIce = 66,

        ImpliedQuoteNms1 = 71,
        ImpliedQuoteNms2 = 72,
        ImpliedQuoteNms3 = 73,
        ImpliedQuoteNms4 = 74,

        StkQuoteProb1 = 81,
        StkQuoteProb2 = 82,
        StkQuoteProb3 = 83,
        StkQuoteProb4 = 84,

        FutQuoteProbX = 89,

        OptQuoteProb1 = 91,
        OptQuoteProb2 = 92,
        OptQuoteProb3 = 93,
        OptQuoteProb4 = 94,

        OptQuoteProbX = 99,

        Pulse = 100,

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
        StkExchQuote4Edga = 144,

        CobExchQuoteIse = 150,
        CobExchQuoteCboe = 151,
        CobExchQuotePhlx = 152,
        CobExchQuoteIce = 153,

        OptAuction = 160,
        OptOrder = 161,

        OptOrderPhlx = 162,
        OptOrderCboe = 163,

        ImbalanceArca = 170,
        ImbalanceNyse = 171,
        ImbalanceNasdaq = 172,

		LiveImpliedQuote1 = 190,
		LiveImpliedQuote2 = 191,
		LiveImpliedQuote3 = 192,
		LiveImpliedQuote4 = 193,

		LiveImpliedQuoteCme = 194,
		LiveImpliedQuoteCbot = 195,
		LiveImpliedQuoteNymex = 196,
		LiveImpliedQuoteComex = 197,

        UTPNbboQuote1 = 200,
        UTPNbboQuote2 = 201,
        UTPNbboQuote3 = 202,
        UTPNbboQuote4 = 203,
    }
}
