using System;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DHCP;

namespace StarServer.Utils.Network
{
    public static class Dhcp
    {
        // Wysyła Discover i próbuje uzyskać konfigurację
        public static bool Ask()
        {
            var client = new DHCPClient();
            Console.WriteLine("Sending DHCP Discover...");

            int result = client.SendDiscoverPacket();

            if (result != -1)
            {
                client.Close();
                Console.WriteLine("DHCP configuration applied!");
                Console.WriteLine("Your local IPv4 Address is: " + NetworkConfiguration.CurrentAddress);
                return true;
            }
            else
            {
                client.Close();
                Console.WriteLine("DHCP request failed.");
                NetworkConfiguration.ClearConfigs();
                return false;
            }
        }

        // Zwalnia konfigurację DHCP
        public static void Release()
        {
            var client = new DHCPClient();
            client.SendReleasePacket();
            client.Close();
            NetworkConfiguration.ClearConfigs();
            Console.WriteLine("DHCP configuration released.");
        }
    }
}
