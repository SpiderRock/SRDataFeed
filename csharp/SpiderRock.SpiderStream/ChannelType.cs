namespace SpiderRock.SpiderStream;

public enum ChannelType
{ 
    None = 0, 

    WssSend = 1, 
    WssRecv = 2, 

    UdpRecv = 4, 
    MlxRecv = 6
}
