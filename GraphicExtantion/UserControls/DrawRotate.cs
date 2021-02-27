using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawRotate : UserControl
    {
        private readonly List<float> _angles;
        private Bitmap _bmp;
        private PointF[] _points;

        private int rNumericUpDown = 87;

        private int nNmericUpDown = 15;

        private int x0numericUpDown = 18;
        private int y0numericUpDown = 2;

        public DrawRotate()
        {

            InitializeComponent();
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());

            _angles = new List<float>();
            for (float i = 0; i < 180; i += (int)rNumericUpDown)
                _angles.Add(i);
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            for (var i = 1; i < nNmericUpDown; i++)
            {
                _points = new PointF[_angles.Count];
                for (var j = 0; j < _angles.Count; j++)
                {
                    var angle = _angles[j];
                    _points[j] = new PointF(GetX(i, angle), GetY(i, angle));
                    pictureBox1.Invalidate();
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
                using (var g = Graphics.FromImage(_bmp))
                {
                    g.TranslateTransform(_bmp.Width / 2f, _bmp.Height / 2f);
                    g.DrawCurve(Pens.Blue, _points);
                }
                _points = null;
            }
            pictureBox1.Invalidate();
        }

        private float GetX(int i, float angle)
        {
            return
                (float)
                (x0numericUpDown + i * rNumericUpDown / nNmericUpDown * (decimal)Math.Cos(angle));
        }


        private float GetY(int i, float angle)
        {
            return
                (float)
                (y0numericUpDown
                 + (nNmericUpDown - i) * rNumericUpDown / nNmericUpDown * (decimal)Math.Sin(angle));
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_bmp != null)
                e.Graphics.DrawImage(_bmp, 0, 0);
            e.Graphics.TranslateTransform(
                pictureBox1.ClientSize.Width / 2f, pictureBox1.ClientSize.Height / 2f);
            if (_points != null)
                e.Graphics.DrawCurve(Pens.Black, _points);
        }
    }
}