using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Helper
{
    //WARNINGS TRASH CODE!

    public sealed class Helper3d
    {
        private readonly PictureBox _pictureBox;
        private readonly SolidBrush solidBrush;
        public Helper3d(PictureBox pictureBox, SolidBrush brush)
        {
            solidBrush = brush;
            _pictureBox = pictureBox;
            _proc = HookProc;
            dc = _pictureBox.CreateGraphics();
            p = new Pen(solidBrush, 5);
            //Запуск хука
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
            rand = new Random();
        }
        Timer _timer1; Timer _timer2;
        public Helper3d(PictureBox pictureBox, Timer timer1, Timer timer2, SolidBrush brush)
            : this(pictureBox, brush)
        {
            coeff(rho, theta, phi);
            drawCube(h);
            _timer1 = timer1;
            _timer2 = timer2;
            flag = !flag;
            if (flag == true)
            {
                _timer1.Start();
                _timer2.Start();
            }
            else
            {
                _timer2.Stop();
                _timer2.Stop();
            }
        }

        #region Библиотеки
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
        const int
            WM_KEYDOWN = 0x100,       //Key down
            WM_KEYUP = 0x101;         //Key up

        public LowLevelKeyboardProc _proc;

        public static IntPtr hhook = IntPtr.Zero;

        Graphics dc; Pen p;
        /* Коэффициенты матрицы видового преобразования */
        double v11, v12, v13, v21, v22, v23, v32, v33, v43;
        /* Сферические координаты точки наблюдения */
        double rho = 140.0, theta = 320.0, phi = 45.0;
        /* Расстояние от точки наблюдения до экрана */
        double screen_dist = 100.0;
        private const double pi = Math.PI;
        bool flag = false;
        const float delta_theta = (float)pi / 2;

        int temp;
        Random rand;


        /* Cмещение относительно левого нижнего угла экрана */
        double c1 = 5.0, c2 = 3.5;
        /* Половина длины ребра куба */
        double h = 2;
        #endregion

        public void timer1_Tick(object sender, EventArgs e)
        {
            temp = rand.Next(0, 6);
        }

        public void timer2_Tick(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (temp == 0)
                {
                    theta = theta + delta_theta;
                }
                if (temp == 1)
                {
                    theta = theta - delta_theta;
                }
                if (temp == 2)
                {
                    phi = phi - delta_theta;
                }
                if (temp == 3)
                {
                    phi = phi + delta_theta;
                }
                if (temp == 4)
                {
                    rho = rho - delta_theta;
                }
                if (temp == 5)
                {
                    rho = rho + delta_theta;
                }


                //Проектируем выбранное нами геометрическое тело:
                _pictureBox.Refresh();
                coeff(rho, theta, phi);
                drawCube(h);
            }
        }

        //Функция преобразования вещественной координаты X в целую*/
        private int IX(double x)
        {
            double xx = x * (_pictureBox.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Функция преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = _pictureBox.Size.Height - y *

            (_pictureBox.Size.Height / 7.0) + 0.5;

            return (int)yy;
        }

        /* Вычисление коэффициентов, не зависящих от вершин куба */
        private void coeff(double rho, double theta, double phi)
        {
            double th, ph, costh, sinth, cosph, sinph, factor;
            factor = Math.PI / 180.0; // из градусов в радианы
            th = theta * factor;
            ph = phi * factor;
            costh = Math.Cos(th);
            sinth = Math.Sin(th);
            cosph = Math.Cos(ph);
            sinph = Math.Sin(ph);
            /* Элементы матрицы V видового преобразования
            | -sin(th) -cos(phi) * cos(th) -sin(phi) * cos(th) 0 |
            V= | cos(th) -cos(phi) * sin(th) -sin(phi) * sin(th) 0 |
            | 0 sin(phi) -cos(phi) 0 |
            | 0 0 rho 1 |
            */
            v11 = -sinth; v12 = -cosph * costh; v13 = -sinph * costh;
            v21 = costh; v22 = -cosph * sinth; v23 = -sinph * sinth;
            v32 = sinph; v33 = -cosph; v43 = rho;
        }
        /* Функция видового и перспективного преобразования координат */
        private void perspective(double x, double y, double z, ref
        double pX, ref double pY)

        {
            double xe, ye, ze;
            /*координаты точки наблюдения, вычисляемые по уравнению
            [Xe Ye Ze 1]= [Xw Yw Zw 1]*V
            */
            xe = v11 * x + v21 * y;
            ye = v12 * x + v22 * y + v32 * z;
            ze = v13 * x + v23 * y + v33 * z + v43;
            /* Экранные координаты,вычисляемые по формулам
            X= d* (x/z)+c1, Y= d*(y/z)+c2,
            где - расстояние от точки наблюдения до экрана
            */
            pX = screen_dist * xe / ze + c1;
            pY = screen_dist * ye / ze + c2;
        }
        /* Функция вычерчивания линии (экран 10х7 условн. единиц) */
        private void dw(double x1, double y1, double z1, double
        x2, double y2, double z2)

        {
            double X1 = 0, Y1 = 0, X2 = 0, Y2 = 0;
            /* Преобразование мировых координат в экранные */
            perspective(x1, y1, z1, ref X1, ref Y1);
            perspective(x2, y2, z2, ref X2, ref Y2);
            /* Вычерчивание линии */
            Point point1 = new Point(IX(X1), IY(Y1));
            Point point2 = new Point(IX(X2), IY(Y2));
            dc.DrawLine(p, point1, point2);
        }
        /* Функция рисования проволочной модели куба */
        private void drawCube(double h)
        {
            dw(h, -h, -h, -h, h, -h); // Отрезок BC
            dw(-h, h, -h, -h, h - 2, h); // +++
            dw(h - 4, -h + 2, h, h, -h, -h); // +++
            dw(h, -h, -h, -h, -h, -h); // +
            dw(-h, -h, -h, -h, h, -h); // +
            dw(-h, -h, -h, -h, -h + 2, h); // +++
        }
        /* Вызов главной функции рисования проволочной модели куба */
        public void button1_Click(object sender, EventArgs e)
        {
            new Helper3d(_pictureBox, solidBrush);
            coeff(rho, theta, phi);
            drawCube(h);
        }
        public IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN || code >= 0 && wParam == (IntPtr)260)
            {
                int vkCode = Marshal.ReadInt32(lParam); //Получить код клавиши
                                                        //Задаем угол поворота фигуры после нажатия клавиши:

                //Рассчитываем новые координаты глаза наблюдателя:
                if (vkCode == 39)
                    theta = theta + delta_theta;
                if (vkCode == 37)
                    theta = theta - delta_theta;
                if (vkCode == 38)
                    phi = phi - delta_theta;
                if (vkCode == 40)
                    phi = phi + delta_theta;
                if (vkCode == 107)
                    rho = rho - delta_theta;
                if (vkCode == 109)
                    rho = rho + delta_theta;


                //Проектируем выбранное нами геометрическое тело:
                _pictureBox.Refresh();
                coeff(rho, theta, phi);
                drawCube(h);
            }
            return IntPtr.Zero;
        }
        public void TimerStop()
        {
            flag = false;
            _timer1.Stop();
            _timer2.Stop();
        }
    }
}
