using StarServer.Utils;
using StarServer.Utils.Network;
using System;

namespace StarServer.Commands
{
    public static class NetworkCmd
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0 || args[0].ToLower() == "help")
            {
                ShowHelp();
                return;
            }

            switch (args[0].ToLower())
            {
                case "dhcp":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Usage: network dhcp ask | release");
                        return;
                    }

                    switch (args[1].ToLower())
                    {
                        case "ask":
                            Dhcp.Ask();
                            break;

                        case "release":
                            Dhcp.Release();
                            break;

                        default:
                            Console.WriteLine("Unknown dhcp command. Use ask or release.");
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Unknown network command.");
                    Console.WriteLine("Type: network help");
                    break;
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Network commands:");
            Console.WriteLine();
            Console.WriteLine("network help            - Show this help");
            Console.WriteLine("network dhcp ask        - Request IP address via DHCP");
            Console.WriteLine("network dhcp release    - Release DHCP lease");
        }
    }
}
