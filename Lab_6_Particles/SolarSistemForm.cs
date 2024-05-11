using Lab_6_Particles.Events;
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
        private List<BaseSpaceObject> spaceObjects = new List<BaseSpaceObject>();
        private GroupOfGroups SolarSistem;
        private bool asteroidInSistem = false;
        private Asteroid asteroid = new Asteroid();

        public SolarSistemForm()
        {
            InitializeComponent();

            AngleLabel.Text = trackBar2.Value.ToString();
            RadiusLabel.Text = RadiusBar.Value.ToString();

            display.Image = new Bitmap(display.Width, display.Height);

            SolarSistem = new GroupOfGroups()
            {
                centralObject = new Sun(display.Width / 2, display.Height / 2),
                X = display.Width / 2,
                Y = display.Height / 2
            };

            spaceObjects.Add(SolarSistem.centralObject);

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 100, 10, Color.Maroon));

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 180, 20, Color.Brown));

            SolarSistem.groups.Add(new GroupOfObjects(SolarSistem.X, SolarSistem.Y, 270, 20, Color.Blue));

            SolarSistem.groups.ElementAt(2).objects.Add(new Satellite(SolarSistem.groups.ElementAt(2).X, SolarSistem.groups.ElementAt(2).Y, 45, 5, Color.LightGray, 270));

            SolarSistem.groups.ElementAt(2).objects.Add(new Satellite(SolarSistem.groups.ElementAt(2).X, SolarSistem.groups.ElementAt(2).Y, 45, 3, Color.LightGray, 90));

            SolarSistem.groups.ElementAt(1).objects.Add(new Satellite(SolarSistem.groups.ElementAt(1).X, SolarSistem.groups.ElementAt(1).Y, 45, 3, Color.LightGray, 270));

            SolarSistem.groups.ElementAt(1).objects.Add(new Satellite(SolarSistem.groups.ElementAt(1).X, SolarSistem.groups.ElementAt(1).Y, 45, 3, Color.LightGray, 90));

            foreach (ObjectGroup group in SolarSistem.groups)
            {
                spaceObjects.Add(group.centralObject);
            }

            asteroid.onPlanetOverlap += (planet) =>
            {
            };

            asteroid.onSunOverlap += (sun) =>
            {
            };

            asteroid.onGravitationZoneOverlap += (a, obj) =>
            {
            };
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                g.Clear(Color.Black);
                SolarSistem.ObjectAttraction();
                SolarSistem.UpdateState();
                SolarSistem.Render(g);

                if (asteroidInSistem)
                {
                    asteroid.Render(g);
                    this.checkOverlaps(g);
                    asteroid.UpdateState();

                    if (asteroid.X < 0 || asteroid.Y < 0 || asteroid.Y > display.Height)
                    {
                        this.asteroidReset();
                    }
                }
                else
                {
                    asteroid = null;
                }

                if (pullButton.Enabled)
                {
                    int startX = display.Width;
                    int startY = display.Height / 2;
                    int finishX = (int)(startX - Math.Cos((double)trackBar2.Value / 180 * Math.PI) * display.Width);
                    int finishY = (int)(startY - Math.Sin((double)trackBar2.Value / 180 * Math.PI) * display.Height);

                    g.DrawLine(new Pen(Color.Orange),
                        startX, startY, finishX, finishY);
                }
            }

            display.Invalidate();
        }

        private void checkOverlaps(Graphics g)
        {
            foreach (BaseSpaceObject obj in spaceObjects.ToList())
            {
                if (asteroid != null && asteroid.overlapsObject(obj, g))
                {
                    asteroid.objectOverlap(obj);
                }

                if (asteroid != null && asteroid.overlapsGravitationZone(obj, g))
                {
                    asteroid.gravitationZoneOverlap(obj);
                }
            }
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
                readyButton.Text = "Разготовить астероид";
                pullButton.Enabled = true;
            }
        }

        private void pullButton_Click(object sender, EventArgs e)
        {
            asteroidInSistem = true;
            readyButton.Enabled = false;
            pullButton.Enabled = false;
            readyButton.Text = "Подготовить астероид";

            asteroid = new Asteroid(display.Width, display.Height / 2, RadiusBar.Value, trackBar2.Value);

            asteroid.onPlanetOverlap += (planet) =>
            {
                planet.bang = new Bang(planet, asteroid.X, asteroid.Y, asteroid.Radius);
                
                planet.bang.finishedSize += () =>
                {
                    planet.bang = null;
                };

                planet.Damage = asteroid.Weight;

                foreach (GroupOfObjects group in SolarSistem.groups)
                {
                    if (group.centralObject.Equals(planet))
                    {
                        group.createSatelite(asteroid.Radius);
                        break;
                    }
                }

                this.asteroidReset();
            };

            asteroid.onSunOverlap += (sun) =>
            {
                sun.bang = new Bang(sun, asteroid.X, asteroid.Y, asteroid.Radius);

                sun.bang.finishedSize += () =>
                {
                    sun.bang = null;
                };

                this.asteroidReset();
            };

            asteroid.onGravitationZoneOverlap += (a, obj) =>
            {
                obj.ImpactObject(a);
            };
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            AngleLabel.Text = trackBar2.Value.ToString();
        }

        private void RadiusBar_Scroll(object sender, EventArgs e)
        {
            RadiusLabel.Text = RadiusBar.Value.ToString();
        }

        private void asteroidReset()
        {
            asteroidInSistem = false;
            readyButton.Enabled = true;
        }
    }
}
