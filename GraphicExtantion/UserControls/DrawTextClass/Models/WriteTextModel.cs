using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models
{
    public class WriteTextModel : BaseWrite
    {
        public WriteTextModel()
        {
        }
        public WriteTextModel(string text, Font font)
            : this(text, font, StringFormatFlags.NoWrap)
        { 
        }
        public WriteTextModel(string text, Font font, StringFormatFlags formatFlags)
            : base(text, font, formatFlags, StringAlignment.Near, StringAlignment.Far)
        {
        }
        public WriteTextModel(string text, Font font, StringFormatFlags formatFlags, StringAlignment alignment, StringAlignment linealigment)
            : base(text, font, formatFlags, alignment, linealigment)
        {
        }
        public WriteTextModel(string value, Font font, StringAlignment alignment, StringAlignment linealigment)
            : base(value, font, StringFormatFlags.NoWrap, alignment, linealigment)
        {
        }
    }
}
