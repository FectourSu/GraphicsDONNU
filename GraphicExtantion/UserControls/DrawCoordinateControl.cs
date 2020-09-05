using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawCoordinateControl : UserControl
    {
        private PointF[] p = new PointF[400];
        public DrawCoordinateControl()
        {
            InitializeComponent(); button1.MouseEnter += (s, e) => {
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            };
            button1.MouseLeave += (s, e) => {
                button1.BackColor = Color.Transparent;
                button1.ForeColor = SystemColors.ControlDarkDark;
            };
            button2.MouseEnter += (s, e) => {
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
            };
            button2.MouseLeave += (s, e) => {
                button2.BackColor = Color.Transparent;
                button2.ForeColor = SystemColors.ControlDarkDark;
            };
            button3.MouseEnter += (s, e) => {
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
            };
            button3.MouseLeave += (s, e) => {
                button3.BackColor = Color.Transparent;
                button3.ForeColor = SystemColors.ControlDarkDark;
            };
        }

        public void Graphic(Graphics g)
        {
            // Select pen 1 pixel size, color red
            Pen myPen = new Pen(Color.Black, 1);

            /*Draw center screen*/

            g.DrawRectangle(
                myPen, 0, 0, pictureBox1.Size.Width - 1,
                pictureBox1.Size.Height - 1
                );

            //vertical line
            g.DrawLine(
                Pens.Black,
                new Point(0, pictureBox1.Height / 2),
                new Point(pictureBox1.Width, pictureBox1.Height / 2)
                );

            //gorizontal line
            g.DrawLine(
                Pens.Black,
                new Point(pictureBox1.Width / 2, 0),
                new Point(pictureBox1.Width / 2, pictureBox1.Height)
                );

            Rectangle rect = pictureBox1.ClientRectangle;

            var e = new PaintEventArgs(g, rect);

            /*Smooth*/
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            /*Position - center screen*/
            e.Graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            /*Scale pen*/
            e.Graphics.ScaleTransform(1, 0.25F);

            /*Color graphics*/
            e.Graphics.DrawLines(Pens.Purple, p);

            g.Dispose();

        }
        private void Calc(double a, double b, double c, double d)
        {
            for (int x = -200; x < 200; x++)
            {
                double y = a * Math.Pow(Math.Sin(x - 1), 3) + b * Math.Pow(Math.Abs(x), 5) + c * x + d;
                p[x + 200] = new PointF(x, (float)y);
            }
        }
        //Pixel
        private void button1_Click(object sender, EventArgs z)
        {
            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            /*Formula calc*/
            Calc(0.00151, 0.00075, 0.0377, 7.559);

            // Draw rectangle:
            Graphic(g);
        }

        //Millimetr
        private void button2_Click(object sender, EventArgs e)
        {
            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            /*Formula calc*/
            Calc(0.0004, 0.0002, 0.01, 2.0);

            // Draw rectangle:
            Graphic(g);
        }

        //Inch
        private void button3_Click(object sender, EventArgs e)
        {
            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            /*Formula calc*/
            Calc(0.000015, 0.000008, 0.0004, 0.0787);

            // Draw rectangle:
            Graphic(g);
        }
    }
}
