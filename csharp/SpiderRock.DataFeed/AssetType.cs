namespace SpiderRock.DataFeed
{
    public enum AssetType : byte
    {
        None = 0,

        // ReSharper disable InconsistentNaming
        EQT = 1,
        IDX = 2,
        BND = 3,
        CUR = 4,
        COM = 5,
        FUT = 6
        // ReSharper restore InconsistentNaming
    }
}