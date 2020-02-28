using System.Drawing;

namespace GameTut.BaseObject
{
    class Ship : BaseObject
    {

        public bool Die { get; private set; }
        private int energy;

        public int Energy
        {
            get { return energy; }
        }

        public Ship(Point position, Point direct, Size size) : base(position, direct, size)
        {
            energy = 100;
            Die = false;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.spaceship, position.X, position.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            base.Update();
        }

        public void Damage()
        {
            System.Media.SystemSounds.Asterisk.Play();
            int damage = random.Next(1, 11);
            energy -= damage;

            if (Energy <= 0)
            {
                Die = true;
            }

        }

        public void Up()
        {
            position.Y = position.Y > 0 ? position.Y -= direct.Y : 1;
        }

        public void Down()
        {
            position.Y = position.Y < Game.Height ? position.Y += direct.Y : Game.Height - 1;
        }

        
    }
}
