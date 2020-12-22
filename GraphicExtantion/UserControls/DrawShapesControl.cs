using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawShapesControl : UserControl
    {
        public DrawShapesControl()
        {
            InitializeComponent();

            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
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
            pictureBox1.Refresh();

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
            pictureBox1.Refresh();

            // Draw rectangle:
            g.DrawRectangle(myPen, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);

            g.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // create bject g draw picture box 
            Graphics g = pictureBox1.CreateGraphics();

            /*Clear PBox*/
            pictureBox1.Refresh();

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

