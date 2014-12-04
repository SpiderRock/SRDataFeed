namespace SpiderRock.DataFeed
{
    public enum TickerSrc : byte
    {
        None = 0,

        // ReSharper disable InconsistentNaming
        SR = 1,
        NMS = 2,
        CME = 3,
        ICE = 4,
        CFE = 5,
        CBOT = 6,
        COIN = 7,
        NYMEX = 8,
        COMEX = 9,
        RUT = 10,
        CBOE = 11
        // ReSharper restore InconsistentNaming
    }
}