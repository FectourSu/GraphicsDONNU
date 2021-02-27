using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawGenerationCurves : UserControl
    {
        Graphics dc; Pen p;
        Random random = new Random();

        public DrawGenerationCurves()
        {
            InitializeComponent();
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());

            dc = pictureBox1.CreateGraphics();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < random.Next(0, 10); i++)
            {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
            p = new Pen(blueBrush, 1);

            int n = 3;               // число вершин
            double R = random.Next(10, 60), r = random.Next(0, 18), r2 = 0;   // радиусы
            double alpha = random.Next(0, 360);        // поворот
            double x0 = random.Next(0, 600), y0 = random.Next(0, 300); // центр

            PointF[] points = new PointF[2 * n + 1];
            PointF[] points2 = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l, l2;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));

                l2 = k % 2 == 0 ? r2 : R;
                points2[k] = new PointF((float)(x0 + l2 * Math.Cos(a)), (float)(y0 + l2 * Math.Sin(a)));


                a += da;
            }
            dc.DrawLines(p, points);
            dc.DrawLines(p, points2);

            }
        }
    }
}
