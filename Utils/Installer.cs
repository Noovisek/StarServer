using System;
using System.IO;

namespace StarServer.Utils
{
    public static class Installer
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== StarServer OS Installer ===");
            Console.WriteLine();

            Directory.CreateDirectory(@"0:\system");
            Directory.CreateDirectory(@"0:\system\users");

            // ROOT PASSWORD
            Console.Write("Set root password: ");
            string rootPassword = ReadPassword();

            // HOSTNAME
            Console.Write("Enter hostname: ");
            string hostname = Console.ReadLine();

            // Zapis roota
            File.WriteAllText(@"0:\system\users\root.cfg", $"root:{rootPassword}");
            File.WriteAllText(@"0:\system\host.cfg", hostname);
            File.WriteAllText(@"0:\installed.flag", "installed");

            Console.WriteLine();
            Console.WriteLine("Installation complete!");
            Console.WriteLine("Login as root.");
            Console.WriteLine("Please reboot the system.");

            while (true) { }
        }

        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
