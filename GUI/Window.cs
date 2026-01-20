using Cosmos.System.Graphics;
using System.Drawing;

namespace StarServer.GUI
{
    public class Window
    {
        public int X, Y, Width, Height;
        public string Title;

        public Window(string title, int x, int y, int width, int height)
        {
            Title = title;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            // tło
            GuiManager.Canvas.DrawFilledRectangle(
                new Pen(Color.DarkSlateGray),
                X,
                Y,
                Width,
                Height
            );

            // pasek tytułu
            GuiManager.Canvas.DrawFilledRectangle(
                new Pen(Color.DimGray),
                X,
                Y,
                Width,
                20
            );

            // ramka
            GuiManager.Canvas.DrawRectangle(
                new Pen(Color.White),
                X,
                Y,
                Width,
                Height
            );

            GuiManager.DrawString(Title, X + 5, Y + 3, Color.White);
        }
    }
}
