using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    public static class MyricomAdapter
    {
        public static readonly IPAddress[] Addresses = GetAddresses().ToArray();

        private static IEnumerable<IPAddress> GetAddresses()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(adapter => adapter.Description.StartsWith("Myri-"))
                .SelectMany(adapter => adapter.GetIPProperties().UnicastAddresses)
                .Where(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(ip => ip.Address);
        }
    }
}