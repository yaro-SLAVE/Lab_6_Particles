using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab_6_Particles
{
    public partial class Form1 : Form
    {
        private List<Particle> particles = new List<Particle>();
        private int mousePositionX = 0;
        private int mousePositionY = 0;

        public Form1()
        {
            InitializeComponent();

            display.Width = this.Width - 25;
            display.Height = this.Height - 50;

            display.Image = new Bitmap(display.Width, display.Height);
        }

        private void UpdateState()
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

        private void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            UpdateState();

            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                Render(g);
                foreach (var particle in particles)
                {
                    particle.Draw(g);
                }
            }

            display.Invalidate();

        }

        private void display_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionX = e.X;
            mousePositionY = e.Y;
        }
    }
}
