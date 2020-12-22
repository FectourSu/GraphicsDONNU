using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion.UserControls;

namespace WindowsFormsApp1.GraphicExtantion
{
    public partial class DrawGame : UserControl
    {
        public DrawGame()
        {
            InitializeComponent();
        }
        public void AddControlsToPanel(UserControl control)
        {
            control.Dock = DockStyle.Fill;

            this.Controls.Clear();

            this.Controls.Add(control);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dp = new DrawPlayGame();
            AddControlsToPanel(dp);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(new Bitmap("logo.png"),120,65, 370,200);
        }
    }
}
