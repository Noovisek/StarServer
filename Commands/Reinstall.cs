using System;
using System.IO;
using StarServer.Utils;

namespace StarServer.Commands
{
    public static class Reinstall
    {
        public static void Execute(string[] args)
        {
            if (args.Length == 0 || args[0] != "--yes")
            {
                Console.WriteLine("WARNING: This will REINSTALL the system!");
                Console.WriteLine("Usage: reinstall --yes");
                return;
            }

            try
            {
                if (File.Exists(@"0:\installed.flag"))
                {
                    File.Delete(@"0:\installed.flag");
                }

                Console.WriteLine("Starting installer...");
                Installer.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reinstall failed:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
