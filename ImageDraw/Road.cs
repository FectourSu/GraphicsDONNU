using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.ImageDraw
{
    class Road : IDrawable
    {
        public Bitmap Draw()
        {
            var size = new Size(250, 250);

            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(100,0,0,0)), 0, 0, size.Width, size.Height);
            }

            return bitmap;
        }
    }
}
