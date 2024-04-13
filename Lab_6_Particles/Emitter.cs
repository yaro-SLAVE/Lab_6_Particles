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
        private int mousePositionX;
        private int mousePositionY;
        private float gravitationX = 0;
        private float gravitationY = 0;

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

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Hp -= 1;

                if (particle.Hp < 0)
                {
                    particle.Hp = 20 + Particle.rand.Next(100);

                    particle.X = mousePositionX;
                    particle.Y = mousePositionY;

                    var direction = (double)Particle.rand.Next(360);
                    var speed = 1 + Particle.rand.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    particle.Radius = 2 + Particle.rand.Next(10);

                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    var particle = new ParticleColorful();

                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);

                    particle.X = mousePositionX;
                    particle.Y = mousePositionY;

                    particles.Add(particle);
                }
                else
                {
                    break;
                }
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
    }
}
