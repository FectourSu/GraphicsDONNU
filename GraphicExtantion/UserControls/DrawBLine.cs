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
    public partial class DrawBLine : UserControl
    {
        int MAX = 100; int N = 30;
        Graphics dc; Pen p;
        double[] x, y;
        double eps = 0.04, X, Y, t, xA, xB, xC, xD, yA, yB, yC,

        yD, a0, a1, a2, a3, b0, b1, b2, b3;


        int n, i, j, first;

        public DrawBLine()
        {
            InitializeComponent(); 
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());

            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Purple, 1);
            x = new double[MAX]; y = new double[MAX];
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            /* Вызов функции чтения данных из файла Curv.dat */
            read_File();
            /* Вызов функции отрисовки B-сплайна */
            curv_Fit();
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
        /* Функция вычерчивания линии (область вывода 10х7 усл.ед.*/
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        /* Функция генерации B-сплайна */
        private void curv_Fit()
        {
            double Xold = 0, Yold = 0;
            /* Заданные точки отмечаются маркером */
            for (i = 0; i <= n; i++)
            {
                X = x[i]; Y = y[i];
                Draw(X - eps, Y - eps, X + eps, Y + eps);
                Draw(X + eps, Y - eps, X - eps, Y + eps);
            }
            /* Отрисовка B-сплайна */
            first = 1;
            for (i = 1; i < n - 1; i++)
            { /* Вычисление коэффициентов */
                xA = x[i - 1]; xB = x[i]; xC = x[i + 1]; xD = x[i + 2];
                yA = y[i - 1]; yB = y[i]; yC = y[i + 1]; yD = y[i + 2];
                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;
                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;
                a2 = (xA - 2 * xB + xC) / 2.0;
                b2 = (yA - 2 * yB + yC) / 2.0;
                a1 = (xC - xA) / 2.0;
                b1 = (yC - yA) / 2.0;
                a0 = (xA + 4 * xB + xC) / 6.0;
                b0 = (yA + 4 * yB + yC) / 6.0;
                /* Отрисовка сегмента дуги */

                for (j = 0; j <= N; j++)
                {
                        t = (double)j / (double)N;
                        X = ((a3 * t + a2) * t + a1) * t + a0;
                        Y = ((b3 * t + b2) * t + b1) * t + b0;
                        if (first == 1) { first = 0; }
                        else Draw(Xold, Yold, X, Y);
                        Xold = X; Yold = Y;
                }
            }
        }
        /* Функция чтения количества и координат точек из файла
        Curv.dat */
        private void read_File()
        {
            StreamReader reader = new StreamReader("Curv.dat");
            /* Чтение из файла количества точек*/
            n = Convert.ToInt32(reader.ReadLine());
            /* Чтение координат точек точек*/
            for (i = 0; i <= n; i++)
            {
                string[] xy = reader.ReadLine().Split(' ');
                x[i] = Convert.ToDouble(xy[0]);
                y[i] = Convert.ToDouble(xy[1]);
            }
            reader.Close();
        }

    }
}
