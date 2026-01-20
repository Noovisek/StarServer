using System;
using System.Xml.Linq;

namespace StarServer.Commands
{
    public static class Help
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            Console.WriteLine("help           - Show this help");
            Console.WriteLine("whoami         - Show current user");
            Console.WriteLine("hostname       - Show system hostname");
            Console.WriteLine("clear          - Clear the screen");
            Console.WriteLine("reboot         - Reboot the system");
            Console.WriteLine("reinstall      - Reinstall the system");
            Console.WriteLine("network        - Network management commands");
            Console.WriteLine("panel          - HTTP panel commands");
            Console.WriteLine("addusr < name > -Add new user(root only)");
            Console.WriteLine();



            Console.WriteLine("Tips:");
            Console.WriteLine("reinstall --yes        Confirm system reinstall");
            Console.WriteLine("network help          Show network subcommands");
            Console.WriteLine("panel start           Start HTTP panel");
        }
    }
}
