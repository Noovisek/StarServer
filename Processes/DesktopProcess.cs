using StarServer.GUI;
using StarServer.Utils;

namespace StarServer.Processes
{
    public class DesktopProcess : Process
    {
        public DesktopProcess() : base("Desktop") { }

        public override void Update()
        {
            Desktop.Draw();
            GuiManager.Update();
        }
    }
}
