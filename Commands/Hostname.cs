using System;
using StarServer.Utils; // aby użyć Authenticator

namespace StarServer.Commands
{
    public static class Hostname
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine(Authenticator.Hostname);
        }
    }
}
