using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models
{
    public abstract class TextFactory
    {
        public abstract BaseWrite CreateText(string value, Font font, StringAlignment alignment);
    }
    public sealed class HorizontalText : TextFactory
    {
        public override BaseWrite CreateText(string value, Font font, StringAlignment alignment)
        {
            return new WriteTextModel(value, font, alignment, StringAlignment.Near);
        }
    }
    public sealed class VerticalText : TextFactory
    {
        public override BaseWrite CreateText(string value, Font font, StringAlignment alignment)
        {
            return new WriteTextModel(value, font, StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft, 
                alignment, StringAlignment.Near);
        }
    }
}
