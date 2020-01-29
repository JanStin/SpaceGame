using System;
using System.Windows.Forms;
using System.Drawing;

namespace GameTut
{
    public static class Game
    {
        static BaseObject[] objects;

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

            Load();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += TimerTick;
            timer.Start();
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach (var obj in objects)
            {
                obj.Draw();
            }
            Buffer.Render();
        }

        public static void Update()
        {
            foreach(var obj in objects)
            {
                obj.Update();
            }
        }

        public static void Load()
        {
            objects = new BaseObject[30];

            for (var i = 0; i < 15; i++)
            {
                objects[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            }
            for (var i = 15; i < objects.Length; i++)
            {
                objects[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            }
        }
    }
}
