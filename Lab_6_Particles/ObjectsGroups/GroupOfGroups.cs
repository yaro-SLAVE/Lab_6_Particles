using Lab_6_Particles.Events;
using Lab_6_Particles.SpaceObjects;
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
        public List<GroupOfObjects> groups = new List<GroupOfObjects>();
        public List<Bang> bangs = new List<Bang>();

        public override void Render(Graphics g)
        {
            base.Render(g);

            foreach (ObjectGroup group in groups)
            {
                group.Render(g);
            }

            if (bangs.Count > 0)
            {
                foreach (var bang in bangs.ToArray())
                {
                    bang.Render(g);
                    bang.updateRadius();
                }
            }
        }

        public override void UpdateState()
        {
            foreach (ObjectGroup group in groups)
            {
                group.UpdateState();
            }
        }

        public override void ObjectAttraction()
        {
            foreach (GroupOfObjects group in groups)
            {
                group.ObjectAttraction();

                this.centralObject.ObjectAttraction(group.centralObject);
            }
        }

        public void ImpactObject(BaseSpaceObject spaceObject)
        {
            this.centralObject.ImpactObject(spaceObject);

            foreach (ObjectGroup group in this.groups)
            {
                group.centralObject.ImpactObject(spaceObject);
            }
        }
    }
}
