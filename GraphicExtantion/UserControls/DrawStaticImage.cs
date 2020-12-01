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
using WindowsFormsApp1.ImageDraw;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawStaticImage : UserControl
    {
        private Bitmap bitmap;
        public DrawStaticImage()
        {
            InitializeComponent();

            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
        }

        private void DrawArt_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 33, 30, 64)), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }
            bitmap.Setting(new Road().Draw(), new Rectangle(0, 260, 900, 175))
                .Setting(new Human().Draw(), new Rectangle(250, 200, 80, 80))
                .Setting(new Star().Draw(), new Rectangle(65, 20, 30, 30))
                .Setting(new Star().Draw(), new Rectangle(100, 50, 20, 20))
                .Setting(new Star().Draw(), new Rectangle(30, 100, 40, 30))
                .Setting(new Star().Draw(), new Rectangle(200, 30, 30, 40))
                .Setting(new Star().Draw(), new Rectangle(250, 40, 20, 30))
                .Setting(new Star().Draw(), new Rectangle(400, 80, 30, 25))
                .Setting(new Star().Draw(), new Rectangle(450, 50, 20, 20))
                .Setting(new Star().Draw(), new Rectangle(350, 70, 40, 40));

        }
    }
}
