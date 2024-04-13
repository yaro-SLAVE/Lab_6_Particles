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
        Emitter emitter = new Emitter();

        public Form1()
        {
            InitializeComponent();

            display.Width = this.Width - 25;
            display.Height = this.Height - 50;

            display.Image = new Bitmap(display.Width, display.Height);

            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(display.Width * 0.25),
                Y = display.Height / 2
            });

            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = display.Width / 2,
                Y = display.Height / 2
            });

            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(display.Width * 0.75),
                Y = display.Height / 2
            });
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
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
