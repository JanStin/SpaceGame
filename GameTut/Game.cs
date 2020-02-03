using System;
using System.Windows.Forms;
using System.Drawing;
using GameTut.BaseObject;
using System.Collections.Generic;

namespace GameTut
{
    public static class Game
    {
        static BaseObject.BaseObject[] objects;
        static Bullet bullet;
        static Asteroid[] asteroids;

        static List<BaseObject.BaseObject> objectsList = new List<BaseObject.BaseObject>();

        static BufferedGraphicsContext bufGrhContext;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        // Construct 
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

            Timer timer = new Timer
            {
                Interval = 100
            };
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
            Buffer.Graphics.DrawImage(Properties.Resources.starrySky, 0, 0, Width, Height);
            
            
            foreach (var obj in objects)
            {
                obj.Draw();
            }
            foreach (var obj in asteroids)
            {
                obj.Draw();
            }
            bullet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var obj in asteroids)
            {
                if (obj.Collision(bullet))
                {
                    obj.Clash = true;
                    bullet.Clash = true;
                }

                obj.Update();
            }
            foreach (var obj in objects)
            {
                obj.Update();
            }
            bullet.Update();
        }

        public static void Load()
        {
            Random random = new Random();

            objects = new BaseObject.BaseObject[30];
            asteroids = new Asteroid[3];

            bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(8, 8));

            int placeCreated;
            int sizeAsteroid;          

            for (var i = 0; i < objects.Length; i++)
            {
                placeCreated = random.Next(5, 51);
                objects[i] = new Star(new Point(Width, random.Next(0, Height)), new Point(-placeCreated, 0), new Size(15, 15));
            }

            for (var i = 0; i < asteroids.Length; i++)
            {
                sizeAsteroid = random.Next(10, 56);
                asteroids[i] = new Asteroid(new Point(Width, random.Next(0, Height)), new Point(-sizeAsteroid, sizeAsteroid), new Size(sizeAsteroid, sizeAsteroid));
            }
        }
    }
}
