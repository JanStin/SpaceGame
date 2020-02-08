using System.Drawing;

namespace GameTut.BaseObject
{
    public class Asteroid : BaseObject
    {
        int power;

        public int Power
        {
            get { return power;  }
            set { power = value;  }
        }

        public Asteroid(Point position, Point direct, Size size) : base(position, direct, size)
        {
            power = random.Next(1, 4);
        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.releases, position.X, position.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            position.X = position.X + direct.X;

            if (position.X < 0 || position.X > Game.Width || Clash)
            {
                position.X = Game.Width;
                position.Y = random.Next(0, Game.Height);
                Clash = false;

                int sizeAsteroid = random.Next(10, 66);
                size.Height = sizeAsteroid;
                size.Width = sizeAsteroid;
            }
        }
    }
}
