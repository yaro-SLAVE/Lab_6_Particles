using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles
{
    public class Particle
    {
        protected int radius;
        protected float x;
        protected float y;
        protected float speedX;
        protected float speedY;
        protected float hp;

        public int Radius
        {
            get => radius; 
            set => radius = value;
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public float SpeedX
        {
            get => speedX;
            set => speedX = value;
        }

        public float SpeedY
        {
            get => speedY; 
            set => speedY = value;
        }

        public float Hp
        {
            get => hp;
            set => hp = value;
        }

        public static Random rand = new Random();

        public Particle()
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            radius = 2 + rand.Next(10);
            hp = 20 + rand.Next(100);
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, hp / 100);
            int alpha = (int)(k * 255);

            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }
}
