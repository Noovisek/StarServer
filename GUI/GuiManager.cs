using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;

namespace StarServer.GUI
{
    public static class GuiManager
    {
        public static Canvas Canvas;
        public static bool Initialized;

        public static void Init()
        {
            if (Initialized) return;

            Canvas = FullScreenCanvas.GetFullScreenCanvas();
            Canvas.Clear(Color.DarkBlue);

            Initialized = true;
        }

        // Tekst z kolorem
        public static void DrawString(string text, int x, int y, Color color)
        {
            Canvas.DrawString(
                text,
                PCScreenFont.Default,
                new Pen(color),
                x,
                y
            );
        }

        public static void Clear(Color color)
        {
            Canvas.Clear(color);
        }

        public static void Update()
        {
            Canvas.Display();
        }
    }
}
