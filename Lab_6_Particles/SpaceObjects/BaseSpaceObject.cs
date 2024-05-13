using Lab_6_Particles.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

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
        public float SpeedX;
        public float SpeedY;
        public Color colorField;
        public int Damage = 0;
        public float Power;
        public int Weight;
        public int PerihelionRadius = 0; //наибольшое расстояние от центра объекта до центра объекта вокруг которого вращается
        public float AnglePosition = 270;
        public float AngleTick = 2;
        public float G = 1.5f;

        public List<Bang> bangs = new List<Bang>();

        public Action<BaseSpaceObject, BaseSpaceObject> onObjectOverlap;
        public Action<BaseSpaceObject, BaseSpaceObject> onGravitationZoneOverlap;

        public virtual void Render(Graphics g)
        {
            var alpha = 255 - Damage;
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y- Radius, Radius * 2, Radius * 2);

            b.Dispose();

            if (bangs.Count != 0)
            {
                foreach(var bang in bangs.ToArray())
                {
                    bang.Render(g, X, Y);
                    bang.updateRadius();
                }
            }
        }

        public virtual void ObjectAttraction(BaseSpaceObject spaceObject)
        {
            spaceObject.AnglePosition = (spaceObject.AnglePosition + spaceObject.AngleTick) % 360;

            spaceObject.MoveX = this.X + (float)(Math.Cos(spaceObject.AnglePosition / 180 * Math.PI) * spaceObject.PerihelionRadius);
            spaceObject.MoveY = this.Y - (float)(Math.Sin(spaceObject.AnglePosition / 180 * Math.PI) * spaceObject.PerihelionRadius);
        }

        public virtual void UpdateState()
        {
            X = MoveX;
            Y = MoveY;
        }

        public virtual bool overlapsObject(BaseSpaceObject obj, Graphics g)
        {
            var path1 = this.getObjectGraphicsPath();
            var path2 = obj.getObjectGraphicsPath();

            path1.Transform(this.getTransform());
            path2.Transform(obj.getTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }

        public virtual bool overlapsGravitationZone(BaseSpaceObject obj, Graphics g)
        {
            var path1 = this.getObjectGraphicsPath();
            var path2 = obj.getGravitationZoneGraphicsPath();

            path1.Transform(this.getTransform());
            path2.Transform(obj.getTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }

        public Matrix getTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(this.X, this.Y);

            return matrix;
        }



        public GraphicsPath getObjectGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-this.Radius, -this.Radius, this.Radius * 2, this.Radius * 2);
            return path;
        }

        public GraphicsPath getGravitationZoneGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-this.Power, -this.Power, this.Power * 2, this.Power * 2);
            return path;
        }

        public void ImpactObject(BaseSpaceObject obj)
        {
            float gX = X - obj.X;
            float gY = Y - obj.Y;
            float r = (float)Math.Max(this.Power, gX * gX + gY * gY);
            obj.SpeedX += gX * Power / r;
            obj.SpeedY += gY * Power / r;
        }

        public virtual void objectOverlap(BaseSpaceObject obj)
        {
            if (this.onObjectOverlap != null)
            {
                this.onObjectOverlap(this, obj);
            }
        }

        public virtual void gravitationZoneOverlap(BaseSpaceObject obj)
        {
            if (this.onGravitationZoneOverlap != null)
            {
                this.onGravitationZoneOverlap(this, obj);
            }
        }
    }
}
