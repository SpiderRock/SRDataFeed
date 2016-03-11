namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    internal delegate int DblReadHandler(byte[] buffer, int length, long netTimestamp, object channel);
}