using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Particles
{
    public class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        protected int mousePositionX;
        protected int mousePositionY;
        protected float gravitationX = 0;
        protected float gravitationY = 1;
        protected int particlesCount = 500;

        public int X;
        public int Y;
        public int Direction = 0;
        public int Spreading = 360;
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int HpMin = 20;
        public int HpMax = 100;

        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public int MousePositionX
        {
            get => mousePositionX;
            set => mousePositionX = value;
        }

        public int MousePositionY
        {
            get => mousePositionY;
            set => mousePositionY = value;
        }

        public float GravitationX
        {
            get => gravitationX;
            set => gravitationX = value;
        }

        public float GravitationY
        {
            get => gravitationY;
            set => gravitationY = value;
        }

        public int ParticlesCount
        {
            get => particlesCount;
            set => particlesCount = value;
        }

        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;
            foreach (var particle in particles)
            {
                if (particle.Hp < 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle1 = CreateParticle();
                ResetParticle(particle1);
                particles.Add(particle1);
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Hp = Particle.rand.Next(HpMin, HpMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
    }
}
