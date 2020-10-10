using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;
using System.Collections.Generic;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    interface IDrawGraphicsTemperature
    {
        int[] RandomizeTemperature(int[] temperatures);
        void DrawGraph(int[] temperatures, Graphics graphics, Pen p, Font font, StringFormat sf);
        void DrawTemperatures(int[] temperatures, Graphics graphics, Pen p, Font font);
    }
    public partial class DrawGraphicsTemperatures : UserControl, IDrawGraphicsTemperature
    {
        public Graphics graphics { get; private set; }

        private readonly StringFormat stringFormat;

        public DrawGraphicsTemperatures()
        {
            InitializeComponent();
            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());

            this.graphics = pictureBox1.CreateGraphics();
            this.stringFormat = new StringFormat();
        }

        //Main draw
        private void DrawGraphics_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            graphics = pictureBox1.CreateGraphics();

            int[] temperature = new int[31];

            RandomizeTemperature(temperature);

            DrawGraph(temperature, graphics, new Pen(Color.Black), new Font("Roboto", 8), stringFormat);

            DrawTemperatures(temperature, graphics, new Pen(Color.MistyRose), new Font("Roboto", 8));
        }

        //Fill array random number temperatures (min: -10, max: 15 )
        public int[] RandomizeTemperature(int[] temperatures)
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < temperatures.Length; i++)
                temperatures[i] = rand.Next(-10, 15);
            
            return temperatures;
        }

        //Aligment graphics
        private void Draw(Graphics graphics, StringFormat stringFormat)
        {
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            graphics.DrawLine(new Pen(Color.DarkGray), 30, pictureBox1.Height / 2,
                pictureBox1.Width, pictureBox1.Height / 2);

            graphics.TranslateTransform(0, pictureBox1.Height / 2);
        }

        //Draw graphic X and Y
        public void DrawGraph(int[] temperatures, Graphics graphics, Pen p, Font font, StringFormat stringFormat)
        {
            Draw(graphics, stringFormat);

            DrawY(temperatures, graphics, font, stringFormat);

            DrawX(temperatures, graphics, font, stringFormat);
        }

        //Draw numbers Y axis
        private void DrawY(int[] temperatures, Graphics graphics, Font font, StringFormat stringFormat)
        {
            int countPoints = 8, max = temperatures.OrderByDescending(x => x).First();

            float value = 0, intervale = (pictureBox1.Height / 2 - font.Size) / (countPoints * font.Size); 

            for (int i = 0; i <= countPoints; i++, value += (float)(max) / (float)(countPoints))
            {
                graphics.DrawString(Convert.ToString((int)(value)), font,
                    new SolidBrush(Color.FromArgb(255, 255, 150 - i * (150 / countPoints), 0)), font.Size, i * intervale * -font.Size, stringFormat); 

                graphics.DrawString(Convert.ToString((int)(-value)), font,
                    new SolidBrush(Color.FromArgb(255, 0, 200 - i * (200 / countPoints), 255)), font.Size, i * intervale * font.Size, stringFormat);
            }
        }

        //Draw numbers X axis
        private void DrawX(int[] temperatures, Graphics graphics, Font font, StringFormat stringFormat)
        {
            float indentX = (float)(pictureBox1.Width - (20 + 8)) / (temperatures.Count() * 8);

            for (int i = 1; i <= 31; i++)
            {
                float x = i * 8 * indentX;

                graphics.DrawString(Convert.ToInt32(i).ToString(), font,
                   Brushes.DarkGray, x + 20, -12, stringFormat);

                graphics.DrawLine(new Pen(Color.DarkGray), x + 20, -5,
                    x + 20, 5);
            }

            //for (int i = 1, x = pictureBox1.Width / temperatures.Length, 
            //    y = pictureBox1.Height / pictureBox1.Width / 2;  i <= temperatures.Length; i++)
            //{
            //    graphics.DrawString(Convert.ToString(i), font,
            //        Brushes.Gray, x + 6, -font.Size * 2, stringFormat);

            //    graphics.DrawLine(new Pen(Color.Gray), x + 6, y - 6,
            //        x + 6, y + 6);

            //    x += pictureBox1.Width / temperatures.Length; 
            //}
        }

        //Draw graphic temperatures
        public void DrawTemperatures(int[] temperatures, Graphics graphics, Pen p, Font font)
        {
            graphics.TranslateTransform(20, 0);

            p = new Pen(Color.Violet, 2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            var listPoints = new List<PointF>();

            float indentX = (float)(pictureBox1.Width - (20 + 8)) / (temperatures.Count() * 8);
            float indentY = (pictureBox1.Height / 2 - 8) / (temperatures.Count() * 8f);

            for (int i = 1, max = temperatures.OrderByDescending(x => x).First();  i < temperatures.Count() + 1; i++)
            {
                float x = i * 8 * indentX;
                float y = (-temperatures[i - 1] * 8) / ((float)max / temperatures.Count()) * indentY;

                listPoints.Add(new PointF(x, y));

                graphics.DrawString(temperatures[i - 1].ToString(), font, Brushes.Purple, x - 6, y - 14 * Math.Sign(temperatures[i - 1]));
                graphics.FillEllipse(Brushes.Black, x - 2.5f, y - 2.5f, 5f, 5f);
            }

            graphics.DrawLines(p, listPoints.ToArray());
        }
    }
}

