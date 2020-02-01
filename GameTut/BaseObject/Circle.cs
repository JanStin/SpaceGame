using System;
using System.Drawing;

namespace GameTut.BaseObject
{
    public class Circle : BaseObject
    {
        public Circle(Point position, Point direct, Size size) : base(position, direct, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.star, position.X, position.Y, size.Width, size.Height);
        }
    }
}
