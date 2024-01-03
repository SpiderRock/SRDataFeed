using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SpiderRock.SpiderStream;

public static class MellanoxAdapter
{
    public static IEnumerable<UnicastIPAddressInformation> FindInterfaces() => NetworkInterface
        .GetAllNetworkInterfaces()
        .Where(adapter => adapter.Description.StartsWith("Mellanox"))
        .SelectMany(adapter => adapter.GetIPProperties().UnicastAddresses)
        .Where(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

}
