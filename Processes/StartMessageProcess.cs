using StarServer.GUI;
using StarServer.Utils;
using System.Drawing;

namespace StarServer.Processes
{
    public class StartMessageProcess : Process
    {
        private bool shown = false;

        public StartMessageProcess() : base("StartMessage") { }

        public override void Update()
        {
            if (shown) return;

            // Narysuj prosty komunikat w centrum ekranu
            GuiManager.DrawString("Welcome to StarServer!", 50, 100, Color.LightGreen);
            GuiManager.Update();

            shown = true; // pokazujemy tylko raz
            Stop();
        }
    }
}
