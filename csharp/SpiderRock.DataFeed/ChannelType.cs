namespace SpiderRock.DataFeed
{
    internal enum ChannelType
    { 
        None = 0, 

        TcpSend = 1, 
        TcpRecv = 2, 

        UdpRecv = 4, 
        DblRecv = 5
    }
}