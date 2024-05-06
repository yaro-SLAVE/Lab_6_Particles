﻿using Lab_6_Particles.ObjectsGroups;
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
        private bool asteroidInSistem = false;
        private Asteroid asteroid;

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

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 90, 10, Color.Maroon));

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 150, 20, Color.Brown));

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 240, 20, Color.Blue));

            SolarSistem.groups.ElementAt(2).objects.Add(new Satellite(SolarSistem.groups.ElementAt(2).X, SolarSistem.groups.ElementAt(2).Y, 45, 5, Color.LightGray, 270));

            SolarSistem.groups.ElementAt(2).objects.Add(new Satellite(SolarSistem.groups.ElementAt(2).X, SolarSistem.groups.ElementAt(2).Y, 45, 3, Color.LightGray, 90));

            SolarSistem.groups.ElementAt(1).objects.Add(new Satellite(SolarSistem.groups.ElementAt(1).X, SolarSistem.groups.ElementAt(1).Y, 35, 3, Color.Green, 270));

            SolarSistem.groups.ElementAt(1).objects.Add(new Satellite(SolarSistem.groups.ElementAt(1).X, SolarSistem.groups.ElementAt(1).Y, 35, 3, Color.Pink, 90));

            /*
            asteroid.onGravitationZoneOverlap += (a, obj) =>
            {
                obj.impactObject(a);
            };

            asteroid.onObjectOverlap += (a, obj) =>
            {

            };

            asteroid.onSunOverlap += (s) =>
            {

            };
            */
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                SolarSistem.Render(g);
                SolarSistem.ObjectAttraction();
                SolarSistem.UpdateState();

                if (asteroidInSistem)
                {
                    asteroid.Render(g);
                    SolarSistem.ImpactObject(asteroid);
                    asteroid.UpdateState();

                    if (asteroid.X < 0 || asteroid.Y < 0 || asteroid.Y > display.Height)
                    {
                        asteroid = null;
                        asteroidInSistem = false;
                        readyButton.Enabled = true;
                    }
                }

                if (pullButton.Enabled)
                {
                    int startX = display.Width;
                    int startY = display.Height / 2;
                    int finishX = 0;
                    int finishY = 0;

                    g.DrawLine(new Pen(Color.Orange),
                        startX, startY, finishX, finishY);
                }
            }

            display.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            displayTimer.Interval = 40 - 3 * trackBar1.Value;
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            if (pullButton.Enabled)
            {
                readyButton.Text = "Подготовить астероид";
                pullButton.Enabled = false;
            }
            else
            {
                readyButton.Text = "Разгатовить астероид";
                pullButton.Enabled = true;
            }
        }

        private void pullButton_Click(object sender, EventArgs e)
        {
            asteroidInSistem = true;
            readyButton.Enabled = false;
            pullButton.Enabled = false;
            readyButton.Text = "Подготовить астероид";

            asteroid = new Asteroid(display.Width, display.Height / 2, 5, trackBar2.Value);
        }
    }
}
