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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        GravityPoint point2;

        public Form1()
        {
            InitializeComponent();

            display.Image = new Bitmap(display.Width, display.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = display.Width / 2,
                Y = display.Height / 2,
            };

            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = display.Width / 2 + 100,
                Y = display.Height / 2,
            };
            point2 = new GravityPoint
            {
                X = display.Width / 2 - 100,
                Y = display.Height / 2,
            };

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            display.Invalidate();

        }

        private void display_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
        }

        private void tbGravitation_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGravitation.Value;
        }

        private void tbGravitation2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGravitation2.Value;
        }
    }
}
