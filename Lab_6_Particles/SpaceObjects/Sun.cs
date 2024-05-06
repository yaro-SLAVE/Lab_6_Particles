using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.SpaceObjects
{
    public class Sun : BaseSpaceObject
    {
        public Sun(float x, float y)
        {
            X = x;
            Y = y;
            Radius = 45;
            Weight = 100;
            Power = 800;
            colorField = Color.Yellow;
            MoveX = 0;
            MoveY = 0;
        }
    }
}
