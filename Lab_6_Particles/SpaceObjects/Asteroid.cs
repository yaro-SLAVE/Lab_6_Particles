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
        public float SpeedX;
        public float SpedY;
        public float StartTraectoryAngle = 180;

        public Action<Sun> onSunOverlap;
        

        public Asteroid(float X, float Y, int Radius, float angle)
        {
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
            this.StartTraectoryAngle += angle;
        }
    }
}
