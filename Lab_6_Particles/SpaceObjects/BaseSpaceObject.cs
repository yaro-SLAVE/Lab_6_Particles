using System;
using System.Drawing;

namespace Lab_6_Particles.SpaceObjects
{
    public class BaseSpaceObject
    {
        public int Radius;
        public float SpeedX;
        public float SpeedY;
        public float X;
        public float Y;
        public Color colorField;
        public int Damage = 0;
        public int Power;
        protected int Weight;

        public BaseSpaceObject(int radius, float x, float y, Color color, int weight)
        {
            Radius = radius;
            X = x;
            Y = y;
            Weight = weight;
            Power = Radius * weight;
            this.colorField = color;
        }

        public void Render(Graphics g)
        {
            int alpha = 255 - Damage;
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y- Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }
    }
}
