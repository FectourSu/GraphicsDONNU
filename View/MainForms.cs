using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }
    }
}
