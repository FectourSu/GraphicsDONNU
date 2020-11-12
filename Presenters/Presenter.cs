using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion.UserControls;

namespace WindowsFormsApp1.Presenter
{
    class Presenter
    {
        /*Object Main Forms*/
        private readonly MainForms view;

        /*Object UControls*/
        private readonly UserControls userControls;

        public Presenter(MainForms form)
        {
            view = form;

            userControls = new UserControls()
            {
                DrawShape = new DrawShapesControl(),
                DrawCordinate = new DrawCoordinateControl(),
                DrawText = new DrawTextControl(),
                DrawGraphics = new DrawGraphicsTemperatures(),
                DrawStatistic = new DrawStatistics()
            };

            #region Event

            /*Draw shape*/
            view.btnDrawShapes.Click += (s, e) => view.AddControlsToPanel(userControls.DrawShape);

            /*Draw coordinate*/
            view.btnCoordinate.Click += (s, e) => view.AddControlsToPanel(userControls.DrawCordinate);

            /*Draw text*/
            view.btnText.Click += (s, e) => view.AddControlsToPanel(userControls.DrawText);

            /*Draw graphics*/
            view.btnGraphics.Click += (s, e) => view.AddControlsToPanel(userControls.DrawGraphics);

            view.btn_Statistic.Click += (s, e) => view.AddControlsToPanel(userControls.DrawStatistic);

            /*Close main form*/
            view.pClose.Click += (s, e) => view.Close();
            /*Custom dark-theme*/
            view.pDarkTheme.Click += (s, e) =>
            {
                view.pDark.BackColor = Color.Black;

                view.label3.BackColor = Color.Black;
                view.label3.ForeColor = Color.White;

                foreach (Control controls in view.Controls)
                {
                    if (controls is Button)
                    {
                        controls.BackColor = Color.Black;
                        controls.ForeColor = Color.White;
                    }
                }
                view.pDarkTheme.Visible = false;
                view.pLightTheme.Visible = true;
                view.pBlackLine.BackColor = Color.White;
                view.pLineDarkVertical.Visible = false;
            };
            view.pLightTheme.Click += (s, e) =>
            {
                view.pDark.BackColor = Color.Transparent;

                view.label3.BackColor = Color.Transparent;
                view.label3.ForeColor = SystemColors.ControlDarkDark;

                foreach (Control controls in view.Controls)
                {
                    if (controls is Button)
                    {
                        controls.BackColor = Color.Transparent;
                        controls.ForeColor = SystemColors.ControlDarkDark;
                    }
                }
                view.pDarkTheme.Visible = true;
                view.pLightTheme.Visible = false;
                view.pBlackLine.BackColor = SystemColors.ControlDarkDark;
                view.pLineDarkVertical.Visible = true;
            };
            
            #endregion
        }
    }
}
