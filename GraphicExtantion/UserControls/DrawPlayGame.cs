using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawPlayGame : UserControl
    {
        public DrawPlayGame()
        {
            InitializeComponent();

            this.timer1.Enabled = true;
            this.timer1.Tick += Timer1_Tick;
            pictureBox6.Paint += PictureBox6_Paint;

            img = state1;

            list.Add(new Bitmap("eat1.png"));
            list.Add(new Bitmap("eat2.png"));
            list.Add(new Bitmap("eat3.png"));
            list.Add(new Bitmap("eat4.png"));

            for (int i = 0; i < 4; i++)
                eats[i] = new Point(580, 0);
        }

        Point point, pointBub;
        Point[] eats = new Point[4];

        Rectangle rectangle1;
        Rectangle rectangle2;
        Rectangle rectangle3;
        Rectangle rectangle4;
        Rectangle rectanglePlayer;

        Random rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        Image img;
        Image state1 = new Bitmap("shark.png");
        Image state2 = new Bitmap("shark2.png");
        Image fish = new Bitmap("scoreFish.png");
        Image bubble = new Bitmap("unnamed.png");

        List<Image> list = new List<Image>();

        int e1 = 341, e2 = 220, e3 = 130, e4 = 80;
        int points = 0;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
        //shit code
        private void PictureBox6_Paint(object sender, PaintEventArgs e)
        {
            rectangle1 = new Rectangle(eats[0].X + 110, eats[0].Y + e1, 40, 20);
            rectangle2 = new Rectangle(eats[1].X + 190, eats[1].Y + e2, 50, 30);
            rectangle3 = new Rectangle(eats[2].X + 212, eats[2].Y + e3, 50, 30);
            rectangle4 = new Rectangle(eats[3].X + 350, eats[3].Y + e4, 40, 20);

            rectanglePlayer = new Rectangle(point.X, point.Y, 80, 50);
       
            e.Graphics.DrawImage(bubble, 532, pointBub.Y + 500, 20, 20);
            e.Graphics.DrawImage(bubble, 313, pointBub.Y + 200, 20, 20);
            e.Graphics.DrawImage(bubble, 155, pointBub.Y + 330, 20, 20);
            e.Graphics.DrawImage(bubble, 223, pointBub.Y + 100, 20, 20);

            e.Graphics.DrawImage(fish, 24, 395, 30, 15);

            e.Graphics.DrawImage(img, rectanglePlayer);

            e.Graphics.DrawImage(list[0], rectangle1);
            e.Graphics.DrawImage(list[1], rectangle2);
            e.Graphics.DrawImage(list[2], rectangle3);
            e.Graphics.DrawImage(list[3], rectangle4);
            
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            pointBub.Y -= 1;

            for (int i = 0; i < 4; i++)
            {
                eats[i].X -= 4;

                if (eats[i].X < -500)
                    eats[i].X = 500;
            }

            if (pointBub.Y < -100)
                pointBub.Y = 500;

            point.Y += 2;

            //todo
            if (point.Y < -50)
                point.Y = 500;
            if (point.Y > 580)
                point.Y = 0;
            if (point.X > 580)
                point.X = 0;
            if (point.X < -50)
                point.X = 580;

            pictureBox6.Invalidate();

            label1.Text = points.ToString();
        }
        
        private void DrawPlayGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.W:
                    point.Y -= 8;
                    break;
                case Keys.S:
                    point.Y += 8;
                    break;

                case Keys.D:
                    point.X += 8;
                    img = state1;
                    break;
                case Keys.A:
                    point.X -= 8;
                    img = state2;
                    break;
                case Keys.Space:
                    if (rectanglePlayer.IntersectsWith(rectangle1))
                    {
                        e1 = rng.Next(50, 450);
                        eats[0].X = 1000;
                        points++;
                    }
                    if (rectanglePlayer.IntersectsWith(rectangle2))
                    {
                        e2 = rng.Next(50, 450);
                        eats[1].X = 1000;
                        points++;
                    }
                    if (rectanglePlayer.IntersectsWith(rectangle3))
                    {
                        e3 = rng.Next(50, 450);
                        eats[2].X = 1000;
                        points++;
                    }
                    if (rectanglePlayer.IntersectsWith(rectangle4))
                    {
                        e4 = rng.Next(50, 450);
                        eats[3].X = 1000;
                        points++;
                    }
                    break;

                    //todo clear memory
                case Keys.Escape:
                    this.Dispose();
                    break;
            }
        }
    }
}

