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
        public int Weight;
        public float PerihelionRadius = 0; //наибольшое расстояние от центра объекта до центра объекта вокруг которого вращается
        protected float G = 1.5f;

        public void Render(Graphics g)
        {
            int alpha = 255 - Damage;
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y- Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public void ObjectAttractio(BaseSpaceObject spaceObject)
        {
            float gX = X - spaceObject.X;
            float gY = Y - spaceObject.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + spaceObject.Radius < Power / 2)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                spaceObject.SpeedX += gX * Power / r2;
                spaceObject.SpeedY += gY * Power / r2;
            }
        }
    }
}
