using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services.Interface;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models;
using System.IO;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    public partial class DrawTextControl : UserControl
    {
        private readonly SerializeText serializeText;
        private readonly ITextOutput textOutput;
        private readonly Point startPoint;

        private int countItem = 0;

        private List<BaseWrite> baseWrites;
        public DrawTextControl()
        {
            InitializeComponent();

            this.startPoint = new Point(0, 0);

            this.baseWrites = new List<BaseWrite>();

            this.textOutput = new TextOutput(pictureBox1);

            this.serializeText = new SerializeText($"{AppContext.BaseDirectory}data.xml");

            if (File.Exists($"{AppContext.BaseDirectory}data.xml"))
                this.baseWrites.AddRange(this.serializeText.Deserialize<BaseWrite[]>());

            CustomizerFormElements.CustomButton(this.Controls.OfType<Button>().ToList());
        }

        private IEnumerable<BaseWrite> Create(TextFactory textFactory, string text, Font font, StringAlignment aligment, int count)
        {
            var list = new List<BaseWrite>();

            for (int i = 0; i < count; i++, countItem++)
                list.Add(textFactory.CreateText($"{text} {countItem}", font, aligment));

            return list;
        }
        private void CreateAndPrintText()
        {
            pictureBox1.Refresh();

            var font1 = new Font("Arial Black", 24f, FontStyle.Bold);
            var font2 = new Font("Corbel", 18f, FontStyle.Italic);
            var font3 = new Font("Imprint MT Shadow", 44f, FontStyle.Regular);

            var horisontal = new HorizontalText();
            var vertical = new VerticalText();

            baseWrites.AddRange(Create(horisontal, "Horizontal", font1, StringAlignment.Near, 6));
            baseWrites.AddRange(Create(horisontal, "Horizontal", font2, StringAlignment.Center, 7));
            baseWrites.AddRange(Create(vertical, "Vertical", font3, StringAlignment.Near, 1));

            textOutput.DrawText(pictureBox1.CreateGraphics(), startPoint, baseWrites);
        }
        //Draw text
        private void button1_Click(object sender, EventArgs e)
        {
            if (baseWrites.Any())
                textOutput.DrawText(pictureBox1.CreateGraphics(), startPoint, baseWrites);
            else
                CreateAndPrintText();
        }

        //Serialization
        private void button2_Click(object sender, EventArgs e)
        {
            serializeText.Serialize(baseWrites.ToArray());
        }

        //Clear
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

            File.Delete($"{AppContext.BaseDirectory}data.xml");
        }
    }
}
