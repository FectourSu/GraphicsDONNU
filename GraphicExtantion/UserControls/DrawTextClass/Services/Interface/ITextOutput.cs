using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Models;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services.Interface
{
    interface ITextOutput
    {
        void DrawText(Graphics graphics, BaseWrite writeText, int x, int y);
        void DrawText(Graphics graphics, Point startPoint, IEnumerable<BaseWrite> texts);
    }
}
