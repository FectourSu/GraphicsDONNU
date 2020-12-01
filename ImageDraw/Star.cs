using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ImageDraw
{
    class Star : IDrawable
    {
        public Bitmap Draw()
        {
            var size = new Size(250, 250);

            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Point[] star ={
                    new Point(0,-50),  new Point(11,-16),
                    new Point(48,-16), new Point(18,6),
                    new Point(30,41),  new Point(0,18),
                    new Point(-30,41), new Point(-18,6),
                    new Point(-48,-16),new Point(-11,-16)};

                    g.TranslateTransform(100, 75);

                    g.FillPolygon(Brushes.Yellow, star);

            }
            return bitmap;
        }
    }
}
