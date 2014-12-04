namespace SpiderRock.DataFeed.FrameHandling
{
    internal unsafe delegate void MessageHandler(byte* ptr, int maxptr, int offset, Header hdr, long timestamp);
}