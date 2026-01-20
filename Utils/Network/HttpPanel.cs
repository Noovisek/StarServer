using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using StarServer.Utils.Panel;
using Cosmos.System.Network.Config;
using Cosmos.System.Network;

namespace StarServer.Utils.Network
{
    public static class HttpPanel
    {
        public static void Start(ushort port = 8080)
        {
            Console.WriteLine($"Starting HTTP Panel on port {port}...");

            // Sprawdzenie sieci
            var config = NetworkConfiguration.CurrentNetworkConfig;
            if (config == null)
            {
                Console.WriteLine("No network configured. Run DHCP first.");
                return;
            }

           
        }
    }
}
