using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab_6_Particles.SpaceObjects
{
    public class BaseSpaceObject
    {
        public int Radius;
        public float MoveX;
        public float MoveY;
        public float X;
        public float Y;
        public float XCenter;
        public float YCenter;
        public Color colorField;
        public int Damage = 0;
        public int Power;
        public int Weight;
        public int PerihelionRadius = 0; //наибольшое расстояние от центра объекта до центра объекта вокруг которого вращается
        public float AnglePosition = 270;
        public float AngleTick = 2;
        public float G = 1.5f;

        public Action<BaseSpaceObject, BaseSpaceObject> onOverlapGravitationZone;
        public Action<BaseSpaceObject, BaseSpaceObject> onOverlapObject;

        public void Render(Graphics g)
        {
            var alpha = 255 - Damage;
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y- Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public virtual void ObjectAttraction(BaseSpaceObject spaceObject)
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

        public virtual void overlap(BaseSpaceObject obj)
        {
            if (this.onOverlapGravitationZone != null)
            {
                this.onOverlapGravitationZone(this, obj);
            }

            if (this.onOverlapObject != null)
            {
                this.onOverlapObject(this, obj);
            }
        }

        public virtual bool overlapsGravitationZone(BaseSpaceObject obj, Graphics g)
        {
            return true;
        }

        public virtual bool overlapsObject(BaseSpaceObject obj, Graphics g)
        {
            return true;
        }

        public GraphicsPath getGravitationZoneGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-(this.Radius + this.Power), -(this.Radius + this.Power), (this.Radius + this.Power) * 2, (this.Radius + this.Power) * 2);
            return path;
        }

        public GraphicsPath getObjectGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-this.Radius, -this.Radius, this.Radius * 2, this.Radius * 2);
            return path;
        }

        public void impactObject(BaseSpaceObject obj)
        {

        }
    }
}
