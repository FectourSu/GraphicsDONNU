using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services.Interface;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services
{
    class TextOutput : ITextOutput
    {
        private readonly Size size;
        public TextOutput(Control control)
        {
            size = control.Size;
        }
        public void DrawText(Graphics graphics, BaseWrite writeText, int x, int y)
        {
            StringFormat format = StringFormat.GenericTypographic.Clone() as StringFormat;

            format.Alignment = writeText.Alignment;
            format.LineAlignment = writeText.Linealigment;
            format.FormatFlags = writeText.FormatFlags | StringFormatFlags.NoClip;

            Rectangle rectangle = new Rectangle(x, y, size.Width, size.Height);

            graphics.DrawString(writeText.Value, new Font(writeText.FontFamily, writeText.FontSize, FontStyle.Bold), 
                Brushes.Black, rectangle, format);
        }
            
        public void DrawText(Graphics graphics, Point startPoint, IEnumerable<BaseWrite> texts)
        {
            foreach (var text in texts)
            {
                if(text.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical))
                {
                    DrawText(graphics, text, startPoint.X, 0);

                    if (text.FormatFlags.HasFlag(StringFormatFlags.DirectionRightToLeft))
                        startPoint.X -= (int)text.FontSize;
                    else
                        startPoint.X += (int)text.FontSize;
                }
                else
                {
                    startPoint.X = 0;

                    DrawText(graphics, text, startPoint.X, startPoint.Y);
                }

                startPoint.Y += (int)text.FontSize;
            }
        }



    }
}
