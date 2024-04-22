using Lab_6_Particles.ObjectsGroups;
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
        private GroupOfGroups SolarSistem;

        public SolarSistemForm()
        {
            InitializeComponent();

            display.Image = new Bitmap(display.Width, display.Height);

            SolarSistem = new GroupOfGroups()
            {
                centralObject = new Sun(display.Width / 2, display.Height / 2),
                X = display.Width / 2,
                Y = display.Height / 2
            };

            SolarSistem.groups.Add(new GroupOfObjects(display.Width / 2, SolarSistem.Y + SolarSistem.centralObject.Radius, 40, 10, Color.Maroon));

            SolarSistem.groups.Add(new GroupOfObjects(display.Width / 2, SolarSistem.Y + SolarSistem.centralObject.Radius, 90, 20, Color.Brown));

            SolarSistem.groups.Add(new GroupOfObjects(display.Width / 2, SolarSistem.Y + SolarSistem.centralObject.Radius, 180, 20, Color.Blue));
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                SolarSistem.Render(g);
            }

            display.Invalidate();
        }
    }
}
