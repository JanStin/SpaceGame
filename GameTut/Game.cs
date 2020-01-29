using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameTut
{
    public static class Game
    {
        static BufferedGraphicsContext bufGrhContext;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {

        }

        public static void Init(Form form)
        {
            Graphics grh;
            bufGrhContext = BufferedGraphicsManager.Current;
            grh = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = bufGrhContext.Allocate(grh, new Rectangle(0, 0, Width, Height));
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();
        }
    }
}
