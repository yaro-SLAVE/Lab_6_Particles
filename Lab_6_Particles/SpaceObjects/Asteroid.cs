using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.SpaceObjects
{
    public class Asteroid : BaseSpaceObject
    {
        public float StartTraectoryAngle = 180;

        public Action<Sun> onSunOverlap;
        public Action<Planet> onPlanetOverlap;
        
        public Asteroid() { }

        public Asteroid(float X, float Y, int Radius, float angle)
        {
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
            this.StartTraectoryAngle += angle;
            colorField = Color.White;
            float speed = 6;
            this.SpeedX = (float)(speed * Math.Cos(StartTraectoryAngle / 180 * Math.PI));
            this.SpeedY = (float)(speed * Math.Sin(StartTraectoryAngle / 180 * Math.PI));
            this.Weight = Radius * 35;
        }

        public override void UpdateState()
        {
            this.X += this.SpeedX;
            this.Y += this.SpeedY;
        }

        public override void objectOverlap(BaseSpaceObject obj)
        {
            base.objectOverlap(obj);

            if (obj is Planet)
            {
                onPlanetOverlap(obj as Planet);
            }

            else if (obj is Sun) 
            { 
                onSunOverlap(obj as Sun);
            }
        }
    }
}
