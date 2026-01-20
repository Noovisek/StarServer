using System;
using System.IO;
using StarServer.Utils;

namespace StarServer.Commands
{
    public static class AddUser
    {
        public static void Execute(string[] args)
        {
            if (Authenticator.LoggedUser != "root")
            {
                Console.WriteLine("Only root can add users.");
                return;
            }

            string username;

            if (args.Length == 0)
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();
            }
            else
            {
                username = args[0];
            }

            string userFile = $@"0:\system\users\{username}.cfg";

            if (File.Exists(userFile))
            {
                Console.WriteLine("User already exists.");
                return;
            }

            Console.Write("Enter password: ");
            string password = ReadPassword();

            File.WriteAllText(userFile, $"{username}:{password}");
            Console.WriteLine($"User '{username}' created.");
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
