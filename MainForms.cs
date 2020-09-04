using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion.UserControls;

namespace WindowsFormsApp1
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
        }

        /*Controls user component extantion presenter*/
        public void AddControlsToPanel(UserControl control)
        {
            control.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(control);
        }
    }
}
