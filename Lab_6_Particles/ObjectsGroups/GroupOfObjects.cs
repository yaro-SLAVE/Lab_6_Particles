using Lab_6_Particles.SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.ObjectsGroups
{
    public class GroupOfObjects : ObjectGroup
    {
        public List<BaseSpaceObject> objects = new List<BaseSpaceObject>();

        public GroupOfObjects(float X, float Y, int PerihelionRadius, int Radius, Color color)
        {
            centralObject = new Planet(X, Y, PerihelionRadius, Radius, color);
            this.X = X;
            this.Y = Y;
            this.PerihelionRadius = PerihelionRadius;
        }

        public override void Render(Graphics g)
        {
            base.Render(g);

            foreach (BaseSpaceObject obj in objects)
            {
                obj.Render(g);
            }
        }
    }
}
