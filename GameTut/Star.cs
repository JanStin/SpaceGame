using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameTut
{
    public class Star : BaseObject
    {
        public Star(Point position, Point direct, Size size) : base(position, direct, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Gray, position.X, position.Y, size.Width, size.Height);
        }
    }
}
