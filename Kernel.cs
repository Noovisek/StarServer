using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using StarServer.Commands;
using StarServer.Utils;
using System;
using System.IO;
using Sys = Cosmos.System;
using StarServer.GUI; // GUI manager
using Cosmos.System; // KeyboardManager, ConsoleKeyEx
using StarServer.Processes;

namespace StarServer
{
    public class Kernel : Sys.Kernel
    {
        private CosmosVFS vfs;
        private bool guiMode = false; // tryb GUI
        private Process guiProcess;

        protected override void BeforeRun()
        {
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);

            System.Console.Clear();
            System.Console.WriteLine("StarServer OS booting...");

            if (!File.Exists(@"0:\installed.flag"))
            {
                Installer.Run();
            }
            else
            {
                Authenticator.Login();
                System.Console.Clear();
                ShowAsciiBanner();
                System.Console.WriteLine("Type 'gui' to start graphical mode.");
            }
        }

        protected override void Run()
        {
            if (guiMode)
            {
                RunGUI();
            }
            else
            {
                RunCLI();
            }
        }

        private void RunCLI()
        {
            System.Console.Write($"{Authenticator.LoggedUser}@{Authenticator.Hostname}:~$ ");
            string input = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return;

            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();
            string[] args = new string[parts.Length - 1];
            Array.Copy(parts, 1, args, 0, args.Length);

            switch (command)
            {
                case "help": Help.Execute(args); break;
                case "whoami": WhoAmI.Execute(args); break;
                case "hostname": Hostname.Execute(args); break;
                case "clear": Clear.Execute(args); break;
                case "reboot": Reboot.Execute(args); break;
                case "reinstall": Reinstall.Execute(args); break;
                case "addusr": AddUser.Execute(args); break;
                case "network": NetworkCmd.Run(args); break;
                case "panel": PanelCmd.Run(args); break;
                case "gui": StartGUI(); break;
                default:
                    System.Console.WriteLine($"{command}: command not found");
                    break;
            }
        }

        private void ShowAsciiBanner()
        {
            System.Console.WriteLine(@"  _________ __                _________                                ");
            System.Console.WriteLine(@" /   _____//  |______ _______/   _____/ ______________  __ ___________ ");
            System.Console.WriteLine(@" \_____  \\   __\__  \\_  __ \_____  \_/ __ \_  __ \  \/ // __ \_  __ \");
            System.Console.WriteLine(@" /        \|  |  / __ \|  | \/        \  ___/|  | \/\   /\  ___/|  | \/");
            System.Console.WriteLine(@"/_______  /|__| (____  /__| /_______  /\___  >__|    \_/  \___  >__|   ");
            System.Console.WriteLine(@"        \/           \/             \/     \/                 \/        ");
            System.Console.WriteLine();
        }

        // ================= GUI =================

        private void StartGUI()
        {
            guiMode = true;
            System.Console.Clear();

            GuiManager.Init();

            // Włącz mysz


            // Tworzymy proces GUI
            guiProcess = new DesktopProcess();
            guiProcess.Start();

            // Tworzymy proces start message
            var startMsg = new StartMessageProcess();
            startMsg.Start();
            startMsg.Update(); // wyświetla od razu
        }


        private void RunGUI()
        {
            guiProcess?.Update();

            // ESC wychodzi z GUI
            if (KeyboardManager.TryReadKey(out var key))
            {
                if (key.Key == ConsoleKeyEx.Escape)
                {
                    guiProcess?.Stop();
                    guiMode = false;

                    System.Console.Clear();
                    ShowAsciiBanner();
                    System.Console.WriteLine("Type 'gui' to start graphical mode.");
                }
            }
        }
    }
}
