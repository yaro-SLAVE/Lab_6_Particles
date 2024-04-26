using System;
using System.Drawing;

namespace Lab_6_Particles.SpaceObjects
{
    public class BaseSpaceObject
    {
        public int Radius;
        public float MoveX;
        public float MoveY;
        public float X;
        public float Y;
        public Color colorField;
        public int Damage = 0;
        public int Power;
        public int Weight;
        public int PerihelionRadius = 0; //наибольшое расстояние от центра объекта до центра объекта вокруг которого вращается
        public float AnglePosition = 270;
        protected float AngleTick = 2;
        protected float G = 1.5f;

        public void Render(Graphics g)
        {
            var alpha = 255 - Damage;
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y- Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public void ObjectAttraction(BaseSpaceObject spaceObject)
        {
            spaceObject.AnglePosition = (spaceObject.AnglePosition + spaceObject.AngleTick) % 360;

            spaceObject.MoveX = this.X + (float)(Math.Cos(spaceObject.AnglePosition / 180 * Math.PI) * spaceObject.PerihelionRadius);
            spaceObject.MoveY = this.Y - (float)(Math.Sin(spaceObject.AnglePosition / 180 * Math.PI) * spaceObject.PerihelionRadius);
        }

        public void UpdateState()
        {
            X = MoveX;
            Y = MoveY;
        }
    }
}
