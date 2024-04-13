using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles
{
    public class AntiGravityPoint : IImpactPoint
    {
        private int power = 100;

        public int Power
        {
            get => power;
            set => power = value;
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = x - particle.X;
            float gY = y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * power / r2;
            particle.SpeedY -= gY * power / r2;
        }
    }
}
