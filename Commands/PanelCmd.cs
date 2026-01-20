using System;
using StarServer.Utils.Panel; // Twój panel HTML w utils/Panel/Panel.cs

namespace StarServer.Commands
{
    public static class PanelCmd
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Panel commands: start");
                return;
            }

            switch (args[0].ToLower())
            {
                case "start":
                    Console.WriteLine("Starting HTTP panel...");
                    StarServer.Utils.Network.HttpPanel.Start(); // domyślnie port 8080
                    break;

                default:
                    Console.WriteLine("Unknown panel command. Use 'start'.");
                    break;
            }
        }
    }
}
