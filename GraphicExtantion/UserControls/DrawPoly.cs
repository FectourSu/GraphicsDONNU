using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawPoly : UserControl
    {
        const int NMAX = 500;
        const double BIG = 1.0e30;
        Graphics dc; Pen p;
        int n; int[] v;
        double[] x, y;
        public DrawPoly()
        {
            InitializeComponent();
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());

            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Purple, 2);
            x = new double[NMAX];
            y = new double[NMAX];
            v = new int[NMAX];
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
            double yy = pictureBox1.Size.Height - y *

            (pictureBox1.Size.Height / 7.0) + 0.5;

            return (int)yy;
        }
        /* Функция вычерчивания линии (экран 10х7 условн. единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        // Функция вычисления длины диагонали
        private bool counter_clock(int h, int i, int j, ref
        double pdist)

        {
            double xh = x[v[h]], xi = x[v[i]], xj = x[v[j]],
            yh = y[v[h]], yi = y[v[i]], yj = y[v[j]],
            x_hi, y_hi, x_hj, y_hj, Determ;
            x_hi = xi - xh; y_hi = yi - yh;
            x_hj = xj - xh; y_hj = yj - yh;
            pdist = x_hj * x_hj + y_hj * y_hj;
            Determ = x_hi * y_hj - x_hj * y_hi;
            return (Determ > 1e-6);
        }
        /* Функция рисования полигона */
        private void draw_polygon()
        {
            int i; double xold, yold;
            xold = x[n - 1]; yold = y[n - 1];
            for (i = 0; i < n; i++)
            {
                Draw(xold, yold, x[i], y[i]);
                xold = x[i]; yold = y[i];
            }
        }
        /* Функция чтения информации из файла Polygon.dat */
        private void read_File()
        {
            StreamReader reader = new StreamReader("Polygon.dat");
            /* Чтение из файла количества точек*/
            n = Convert.ToInt32(reader.ReadLine());
            /* Чтение координат точек точек*/
            for (int i = 0; i < n; i++)
            {
                string[] xy = reader.ReadLine().Split(' ');
                x[i] = Convert.ToDouble(xy[0]);
                y[i] = Convert.ToDouble(xy[1]);
            }
            reader.Close();
        }
        /* Главная функция разбиения полигона на треугольники */
        private void poly_Tria()
        {
            int i, h, j, m, k, imin = 0;
            double diag = 0, min_diag;
            /* Заполнение массива v номерами вершин */
            for (i = 0; i < n; i++) { v[i] = i; }
            /* Отрисовка полигона */
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            draw_polygon();
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            m = n;
            while (m > 3)
            {
                min_diag = BIG;
                for (i = 0; i < m; i++)
                {
                    /* h - предыдущая вершина, i - текущая, j - следующая */
                
                    if (i == 0) h = m - 1; else h = i - 1;
                    if (i == m - 1) j = 0; else j = i + 1;
                    /* Запоминаем самую короткую диагональ */
                    if (counter_clock(h, i, j, ref diag) && (diag < min_diag))
                    { min_diag = diag; imin = i; }
                }
                i = imin;
                if (i == 0) h = m - 1; else h = i - 1;
                if (i == m - 1) j = 0; else j = i + 1;
                /* Вывод шриховой линии между вершинами h и j */
                Draw(x[v[h]], y[v[h]], x[v[j]], y[v[j]]);
                /* Уменьшение количества вершин */
                m--;
                /* Исключаем из последовательности вершин вершину i */
                for (k = i; k < m; k++) v[k] = v[k + 1];
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /* Вызов функции получения информации о полигоне */
            read_File();
            /* Вызов функции разбиения полигона на треугольники */
            poly_Tria();
        }
    }
}