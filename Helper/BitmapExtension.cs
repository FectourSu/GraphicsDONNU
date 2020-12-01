using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Helper
{
    static class BitmapExtension
    {
        public static Bitmap Setting(this Bitmap main, Bitmap adding, Rectangle rectangle)
        {
            using (Graphics g = Graphics.FromImage(main))
            {
                g.DrawImage(adding, rectangle);

                return main;
            }
        }
    }
}
