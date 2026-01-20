using Cosmos.Core;
using Cosmos.HAL;
using System;

namespace StarServer.Commands
{
    public static class Reboot
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine("Rebooting system...");
            CPU.Reboot(); // <- Cosmos HAL funkcja do twardego resetu
            while (true) { } // w razie gdyby CPU.Reset() nie zadziałało od razu
        }
    }
}
