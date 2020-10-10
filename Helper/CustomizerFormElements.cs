using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Helper
{
    class CustomizerFormElements
    {
        //bypassing
        public static void CustomButton(List<Button> button)
        {
            for (int i = 0; i < button.Count; i++)
            {
                int isolation = i;
                button[isolation].MouseEnter += (s, e) => {
                    button[isolation].BackColor = Color.Black;
                    button[isolation].ForeColor = Color.White;
                };
                button[isolation].MouseLeave += (s, e) => {
                    button[isolation].BackColor = Color.Transparent;
                    button[isolation].ForeColor = SystemColors.ControlDarkDark;
                };
            }
        }
    }
}
