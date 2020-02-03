using System;
using System.Drawing;


namespace GameTut.BaseObject
{

    public abstract class BaseObject : ICollision
    {
        protected Point position;
        protected Point direct;
        protected Size size;
        public bool Clash { protected get; set; }

        public Rectangle Rect
        {
            get { return new Rectangle(position, size); }
        }

        protected Random random = new Random();

        public BaseObject(Point position, Point direct, Size size)
        {
            this.position = position;
            this.direct = direct;
            this.size = size;
            Clash = false;
        }

        public abstract void Draw();

        public virtual void Update()
        {
            position.X = position.X + direct.X;

            if (position.X < 0 || position.X > Game.Width)
            {
                direct.X = -direct.X;
            }
        }

        public bool Collision(ICollision obj)
        {
            if (obj.Rect.IntersectsWith(this.Rect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
