using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawClippingLines : UserControl
    {
        float xmin = -0.1f, xmax = 18.0f, ymin = 0.0f, ymax = 12.0f;
        Graphics dc; Pen p;
        Random random = new Random();

        /*Random color*/
       
        public DrawClippingLines()
        {
            InitializeComponent();

            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
            dc = pictureBox1.CreateGraphics();
        }

        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        /* Своя функция вычечивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
            p = new Pen(blueBrush, 1);

            int i; double r, pi, alpha, phi0, phi, x0, y0, x1, y1, x2, y2;
            pi = 4.0 * Math.Atan(1.0);
            alpha = 72.0 * pi / 180.0; phi0 = 0.0; x0 = 4.5; y0 = 4.5;
            /* Вычерчивание границ окна */
            Draw(xmin, ymin, xmax, ymin); Draw(xmax, ymin, xmax, ymax);
            Draw(xmax, ymax, xmin, ymax); Draw(xmin, ymax, xmin, ymin);
            /* В пределах границ окна вычерчиваются 20 правильных концентрических пятиугольников */
            for (r = 0.5; r < 15.5; r += 0.5)
            {
                Thread.Sleep(150);

                x2 = x0 + r * Math.Cos(phi0); y2 = y0 + r * Math.Sin(phi0);
                for (i = 1; i <= 5; i++)
                {
                    phi = phi0 + i * alpha;
                    x1 = x2; y1 = y2;
                    x2 = x0 + r * Math.Cos(phi); y2 = y0 + r * Math.Sin(phi);

                    clip(x1, y1, x2, y2);
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        /* Метод получение кода положения точки относительно окна по алгоритму Коєна-Сазерленда */
        private uint code(double x, double y)
        {
            return (uint)((Convert.ToUInt16(x < xmin) << 3) |
            (Convert.ToUInt16(x > xmax) << 2) |
            (Convert.ToUInt16(y < ymin) << 1) |
            Convert.ToUInt16(y > ymax));
        }
        /* Метод отсечения линий */
        private void clip(double x1, double y1, double x2, double y2)
        {
            uint c1;
            uint c2;
            double dx, dy;
            c1 = code(x1, y1);
            c2 = code(x2, y2);

            while ((c1 | c2) != 0)
            {
                if ((c1 & c2) != 0) return;
                dx = x2 - x1;
                dy = y2 - y1;
                if (c1 != 0)
                {
                    if (x1 < xmin) { y1 += dy * (xmin - x1) / dx; x1 = xmin; }
                    else
                    if (x1 > xmax) { y1 += dy * (xmax - x1) / dx; x1 = xmax; }
                    else
                    if (y1 < ymin) { x1 += dx * (ymin - y1) / dy; y1 = ymin; }
                    else
                    if (y1 > ymax) { x1 += dx * (ymax - y1) / dy; y1 = ymax; }
                    c1 = code(x1, y1);
                }
                else
                {
                    if (x2 < xmin) { y2 += dy * (xmin - x2) / dx; x2 = xmin; }
                    else
                    if (x2 > xmax) { y2 += dy * (xmax - x2) / dx; x2 = xmax; }
                    else
                    if (y2 < ymin) { x2 += dx * (ymin - y2) / dy; y2 = ymin; }
                    else
                    if (y2 > ymax) { x2 += dx * (ymax - y2) / dy; y2 = ymax; }
                    c2 = code(x2, y2);
                }
            }
            Draw(x1, y1, x2, y2); // Соединяем точки линией
        }
        /* Основной код программы */
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 132;
            timer1.Start();

        }
    }
}
