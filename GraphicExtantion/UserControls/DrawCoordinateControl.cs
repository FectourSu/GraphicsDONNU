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
        public DrawCoordinateControl()
        {
            InitializeComponent();
            
            /*Custom elements*/
            button1.MouseEnter += (s, e) => {
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
        //Draw diagramma
        private void DrawDiagram(float width, float height, GraphicsUnit gunit, float scale = 1)
        {
            //create graph picture box
            var graphics = pictureBox1.CreateGraphics();

            //millimetrs, inch, pixel
            graphics.PageUnit = gunit;

            //the beginning of coordinates
            graphics.TranslateTransform(width / 2, height / 2);

            //zoom
            graphics.ScaleTransform(scale, scale);

            //custom graphic
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var pen = new Pen(Color.Purple, 0.25f);

            graphics.DrawCurve(pen, SolveExpression((x) => (float)Math.Pow(x, 2) - x + 12, start: -100, end: 100).ToArray());
        }

        //Return collection and convertation Points array
        private IEnumerable<PointF> SolveExpression(Func<float, float> func, float start, float end)
        {
            //array point
            var points = new List<PointF>();

            //invoke calculated formula
            for (float i = start; i < end; i++)
            {
                points.Add(new PointF
                {
                    X = i,
                    Y = func.Invoke(i)
                });
            }

            //getting points for building a coordinate system
            return points;
        }

        private void DrawCoordinateSystem(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var control = sender as Control;

            //size picture box
            var width = control.Size.Width;
            var height = control.Size.Height;

            //rectangle
            graphics.DrawRectangle(
                Pens.Black,
                new Rectangle(new Point(0, 0),
                new Size(width - 1, height - 1))
                );

            //gorizontal line
            graphics.DrawLine(
               Pens.Black,
               new Point(width / 2, 0),
               new Point(width / 2, height));

            //vertical line
            graphics.DrawLine(
                Pens.Black,
                new Point(0, height / 2),
                new Point(width, height / 2));

            Font font = new Font("Roboto", 10);

            graphics.DrawString(
                "X",
                font,
                Brushes.Black,
                new Point(width - 20, height/2)
                );
            graphics.DrawString(
                "Y",
                font,
                Brushes.Black,
                new Point(width / 2 + 3, 3)
                );
        }

        //Pixel
        private void button1_Click(object sender, EventArgs e)
        {
            //Clear PB
            pictureBox1.Refresh();

            //pixel and  1f scale
            DrawDiagram(pictureBox1.Width, pictureBox1.Height, GraphicsUnit.Pixel, 1f);
        }

        //Millimetr
        private void button2_Click(object sender, EventArgs e)
        {
            //Clear PB
            pictureBox1.Refresh();

            //1 millimetr = 3.794f pixels and  0.5f scale
            DrawDiagram(pictureBox1.Width / 3.794f, pictureBox1.Height / 3.794f, GraphicsUnit.Millimeter, 0.5f);
        }

        //Inch
        private void button3_Click(object sender, EventArgs e)
        {
            //Clear PB
            pictureBox1.Refresh();

            //1 inch = 96.358 pixels and 0.025f scale
            DrawDiagram(pictureBox1.Width / 96.358f, pictureBox1.Height / 96.358f, GraphicsUnit.Inch, 0.025f);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawCoordinateSystem(sender, (PaintEventArgs)e);
        }
    }
}
