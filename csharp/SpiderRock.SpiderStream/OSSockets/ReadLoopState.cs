namespace SpiderRock.SpiderStream.OSSockets;

internal enum ReadLoopState
{
    None,
    LoopStarting,
    ReadWait,
    ReadDone,
    EnterHandler,
    LoopDone
}
