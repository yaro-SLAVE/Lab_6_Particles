using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles
{
    public abstract class IImpactPoint
    {
        protected float x;
        protected float y;

        public float X
        {
            get => x; 
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    x - 5,
                    y - 5,
                    10,
                    10
                );
        }
    }
}
