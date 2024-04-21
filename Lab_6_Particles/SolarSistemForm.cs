using Lab_6_Particles.SpaceObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6_Particles
{
    public partial class SolarSistemForm : Form
    {
        private Sun sun;

        public SolarSistemForm()
        {
            InitializeComponent();

            display.Image = new Bitmap(display.Width, display.Height);

            sun = new Sun(display.Width / 2, display.Height / 2);
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                sun.Render(g);
            }

            display.Invalidate();
        }
    }
}
