using System;
using System.IO;

namespace StarServer.Utils
{
    public static class Authenticator
    {
        public static string LoggedUser { get; private set; }
        public static string Hostname { get; private set; }

        public static void Login()
        {
            Hostname = File.Exists(@"0:\system\host.cfg")
                ? File.ReadAllText(@"0:\system\host.cfg").Trim()
                : "StarServer";

            // 🔧 Recovery: brak bazy użytkowników → reinstall
            if (!Directory.Exists(@"0:\system\users"))
            {
                Console.WriteLine("User database missing.");
                Console.WriteLine("Starting installer...");
                Installer.Run();
                return; // teoretycznie nigdy tu nie dojdzie
            }

            while (true)
            {
                Console.Write("Username: ");
                string user = Console.ReadLine();

                string userFile = $@"0:\system\users\{user}.cfg";
                if (!File.Exists(userFile))
                {
                    Console.WriteLine("User does not exist.\n");
                    continue;
                }

                Console.Write("Password: ");
                string pass = ReadPassword();

                string[] data = File.ReadAllText(userFile).Split(':');

                if (data.Length >= 2 && data[1] == pass)
                {
                    LoggedUser = user;
                    Console.WriteLine($"\nWelcome, {LoggedUser}!");
                    break;
                }

                Console.WriteLine("Wrong password.\n");
            }
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
