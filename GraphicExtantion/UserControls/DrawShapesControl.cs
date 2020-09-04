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
    public partial class DrawShapesControl : UserControl
    {
        public DrawShapesControl()
        {
            InitializeComponent();
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
        /*Fill rectangle*/
        private void button1_Click_1(object sender, EventArgs e)
        {
            /*Сreated an object to fill the component*/
            Rectangle rect = pictureBox1.ClientRectangle;

            Random random = new Random();

            /*Random color*/
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));

            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            g.FillRectangle(blueBrush, rect);

            g.Dispose();
        }

        /*Not fill rect*/
        private void button2_Click_1(object sender, EventArgs e)
        {

            // Select pen 1 pixel size, color red
            Pen myPen = new Pen(Color.Red, 1);

            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            // Draw rectangle:
            g.DrawRectangle(myPen, 0, 0, pictureBox1.Size.Width - 1,

            pictureBox1.Size.Height - 1);

            g.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            g.Clear(Color.White);

            /*Сreated rect component*/
            Rectangle rect = pictureBox1.ClientRectangle;

            /*I'm too lazy to override*/
            PaintEventArgs z = new PaintEventArgs(g, rect);

            // Draw line
            g.DrawLine(Pens.Red, 332, 39, 110, 15);
            // Draw line
            g.DrawLine(Pens.Red, 332, 19, 110, 35);

            // Draw elipses
            g.DrawEllipse(Pens.Blue, 111, 70, 110, 45);

            // Draw rectangle
            g.DrawRectangle(Pens.Green, 111, 150, 110, 45);

            // Draw fill elipse
            g.FillEllipse(Brushes.Blue, 331, 70, 110, 45);

            // Draw fill rectangle
            g.FillRectangle(Brushes.Green, 331, 150, 110, 45);
        }
    }
}

