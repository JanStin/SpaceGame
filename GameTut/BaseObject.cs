using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTut
{
    public class BaseObject
    {
        protected Point position;
        protected Point direct;
        protected Size size;

        public BaseObject(Point position, Point direct, Size size)
        {
            this.position = position;
            this.direct = direct;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Gray, position.X, position.Y, size.Width, size.Height);
        }

        public void Update()
        {
            position.X = position.X + direct.X;
            position.Y = position.Y + direct.Y;

            if (position.X < 0 || position.X > Game.Width)
            {
                direct.X = -direct.X;
            }

            if (position.Y < 0 || position.Y > Game.Height)
            {
                direct.Y = -direct.Y;
            }
        }
    }
}
