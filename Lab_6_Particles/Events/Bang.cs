using Lab_6_Particles.SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_6_Particles.Events
{
    public class Bang
    {
        public float X;
        public float Y;
        public float dX;
        public float dY;
        public float Radius = 1;
        public Color colorField = Color.OrangeRed;
        public int MaxRadius;

        public Action finishedSize;

        public Bang(BaseSpaceObject obj, float X, float Y, int AsteroidRadius)
        {
            this.X = X; 
            this.Y = Y;
            this.dX = this.X - obj.X;
            this.dY = this.Y - obj.Y;
            this.MaxRadius = AsteroidRadius * 4;
        }

        public void Render(Graphics g, float X, float Y)
        {
            var alpha = 255 - (int)(255 * this.Radius / this.MaxRadius);
            var color = Color.FromArgb(alpha, colorField);
            var b = new SolidBrush(color);

            g.DrawEllipse(new Pen(new SolidBrush(color), 5), X + dX - Radius, Y + dY - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public void updateRadius()
        {
            this.Radius += 0.25f;

            if (this.Radius >= (float)(this.MaxRadius))
            {
                this.finishedSize();
            }
        }
    }
}
