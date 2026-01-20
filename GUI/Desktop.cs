using System.Drawing;
using Cosmos.System;
using Cosmos.System.Graphics;

namespace StarServer.GUI
{
    public static class Desktop
    {
        public static void Draw()
        {
            // Pobierz pozycję myszy i rzutuj na int
            int mouseX = (int)MouseManager.X;
            int mouseY = (int)MouseManager.Y;

            GuiManager.Canvas.Clear(Color.DarkSlateBlue);

            // Teksty
            GuiManager.DrawString("StarServer GUI", 10, 10, Color.White);
            GuiManager.DrawString("Press ESC to shutdown", 10, 30, Color.LightGray);

            // Kursor myszy (żółty kwadrat)
            GuiManager.Canvas.DrawFilledRectangle(new Pen(Color.Yellow), mouseX, mouseY, 3, 3);
        }
    }
}
