using System;
using System.Drawing;

namespace GameTut.BaseObject
{
    public class Bullet : BaseObject
    {
        public Bullet(Point position, Point direct, Size size) : base(position, direct, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.pets, position.X, position.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            position.X = position.X + 3;
        }
    }
}
