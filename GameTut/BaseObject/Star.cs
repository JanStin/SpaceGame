using System.Drawing;

namespace GameTut.BaseObject
{
    public class Star : BaseObject
    {
        public Star(Point position, Point direct, Size size) : base(position, direct, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.star, position.X, position.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            position.X = position.X + direct.X;
      
            if (position.X < 0 || position.X > Game.Width)
            {
                
                position.X = Game.Width;
                position.Y = random.Next(0, Game.Height);
            }
        }
    }
}
