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
        

        public Asteroid(float X, float Y, int Radius, float angle)
        {
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
            this.StartTraectoryAngle += angle;
            colorField = Color.White;
            float speed = 3;
            this.SpeedX = (float)(speed * Math.Cos(StartTraectoryAngle / 180 * Math.PI));
            this.SpeedY = (float)(speed * Math.Sin(StartTraectoryAngle / 180 * Math.PI));
            this.Weight = Radius * 10;
        }

        public override void UpdateState()
        {
            this.X += this.SpeedX;
            this.Y += this.SpeedY;
        }
    }
}
