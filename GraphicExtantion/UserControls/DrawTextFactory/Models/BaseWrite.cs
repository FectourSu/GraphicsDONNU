using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models
{
    [Serializable]
    [XmlInclude(typeof(WriteTextModel))]
    public abstract class BaseWrite
    {
        public BaseWrite()
        {
        }
        public BaseWrite(string value, Font font, StringFormatFlags formatFlags, StringAlignment alignment, StringAlignment linealigment)
        {
            Value = value;
            FormatFlags = formatFlags;
            Alignment = alignment;
            Linealigment = linealigment;
            FontSize = font.Size;
            FontFamily = font.FontFamily.Name;
        }
        public string Value { get; set; }
        public string FontFamily { get; set; }
        public float FontSize { get; set; }
        public StringFormatFlags FormatFlags { get; set; }
        public StringAlignment Alignment { get; set; }
        public StringAlignment Linealigment { get; set; }
    }
}
