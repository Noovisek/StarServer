using System;
using StarServer.Utils;

namespace StarServer.Commands
{
    public static class WhoAmI
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine(Authenticator.LoggedUser);
        }
    }
}
