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
    public partial class DrawAnimateImage : UserControl
    {
      
        public DrawAnimateImage()
        {
            InitializeComponent();


            DoubleBuffered = true;

            this.timer1.Tick += Timer1_Tick1;
            this.DrawArt.Click += DrawArt_Click1;
            this.pictureBox1.Paint += PictureBox1_Paint;
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (timer1.Enabled)
                e.Graphics.DrawImage(new Bitmap("pirate.png"), point.X, point.Y, 120, 80);
        }
        
        Point point;
        private void DrawArt_Click1(object sender, EventArgs e)
        {
            point = new Point(-100, 100);
            timer1.Enabled = true;
        }

        private void Timer1_Tick1(object sender, EventArgs e)
        {
            x:
            point.X += 5;

            if (point.X == 930)
            {
                point.X = -300;
                goto x;
            }

            pictureBox1.Invalidate();
        }


     
    }
}
