namespace SpiderRock.DataFeed.Proto.UDP
{
    internal enum ReadLoopState
    {
        None,
        LoopStarting,
        ReadWait,
        ReadDone,
        EnterHandler,
        LoopDone
    }
}