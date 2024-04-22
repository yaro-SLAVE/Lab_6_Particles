﻿using Lab_6_Particles.SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles.ObjectsGroups
{
    public class GroupOfGroups : ObjectGroup
    {
        public List<ObjectGroup> groups = new List<ObjectGroup>();

        public override void Render(Graphics g)
        {
            base.Render(g);

            foreach (ObjectGroup group in groups)
            {
                group.Render(g);
            }
        }
    }
}