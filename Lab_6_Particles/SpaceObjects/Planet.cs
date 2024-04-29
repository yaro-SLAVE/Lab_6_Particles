using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.SpaceObjects
{
    public class Planet : BaseSpaceObject
    {
        public Planet(float X, float Y, int PerihelionRadius, int Radius, Color color)
        {
            this.X = X;
            this.Radius = Radius;
            this.PerihelionRadius = PerihelionRadius;
            this.Y = Y + PerihelionRadius;
            this.colorField = color;

            this.AngleTick = 480 / PerihelionRadius;
        }
    }
}
