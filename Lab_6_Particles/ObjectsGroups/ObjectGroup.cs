using Lab_6_Particles.SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.ObjectsGroups
{
    public class ObjectGroup
    {
        public float SpeedX;
        public float SpeedY;
        public float X;
        public float Y;
        public float PerihelionRadius = 0; //наибольшое расстояние от центра объекта до центра объекта вокруг которого вращается
        protected float G = 1.5f;
        public BaseSpaceObject centralObject;

        public virtual void Render(Graphics g)
        {
            centralObject.Render(g);
        }

        public virtual void UpdateState() 
        { 

        }

        public virtual void ObjectAttraction()
        {

        }
    }
}
