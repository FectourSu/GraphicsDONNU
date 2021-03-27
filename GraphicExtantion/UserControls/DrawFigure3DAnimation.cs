using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawFigure3DAnimation : UserControl
    {
        Helper3d helper;
        SolidBrush b = new SolidBrush(Color.Black);
        public DrawFigure3DAnimation()
        {
            InitializeComponent();
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper = new Helper3d(pictureBox1, timer1, timer2, b);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            helper.timer1_Tick(sender, e);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            helper.timer2_Tick(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            helper.TimerStop();
        }
    }
}
