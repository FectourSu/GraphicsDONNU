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
    public partial class DrawFigure3D : UserControl
    {
        Helper3d helper;
        SolidBrush b = new SolidBrush(Color.DarkViolet);
        public DrawFigure3D()
        {
            InitializeComponent();
            helper = new Helper3d(pictureBox1, b);
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper.button1_Click(sender, e);
        }

    }
}
