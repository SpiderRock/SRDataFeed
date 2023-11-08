namespace SpiderRock.SpiderStream;

internal interface IFrameHandler
{
    bool TryHandle(ref Frame message);
}
