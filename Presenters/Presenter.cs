using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.GraphicExtantion;
using WindowsFormsApp1.GraphicExtantion.UserControls;

namespace WindowsFormsApp1.Presenter
{
    class Presenter
    {
        /*to switch to the next page*/
        private readonly List<Button> onePage;
        private readonly List<Button> twoPage;

        /*Object Main Forms*/
        private readonly MainForms view;

        /*Object UControls*/
        private readonly UserControls userControls;

        public Presenter(MainForms form)
        {
            onePage = new List<Button>();

            twoPage = new List<Button>();

            view = form;

            twoPage = view.Controls.OfType<Button>().Where((b, i) => i < 8).ToList();

            onePage = view.Controls.OfType<Button>().Where((b, i) => i > 7).ToList();

            userControls = new UserControls()
            {
                DrawShape = new DrawShapesControl(),
                DrawCordinate = new DrawCoordinateControl(),
                DrawText = new DrawTextControl(),
                DrawGraphics = new DrawGraphicsTemperatures(),
                DrawStatistic = new DrawStatistics(),
                DrawImage = new DrawStaticImage(),
                DrawAnimate = new DrawAnimateImage(),
                DrawPlay = new DrawPlayGame(),
                DrawRotate = new DrawRotate(),
                DrawClippingLines = new DrawClippingLines(),
                DrawGenerationCurves = new DrawGenerationCurves(),
                DrawB = new DrawBLine(),
                DrawPoly = new DrawPoly(),
                Draw3D = new DrawFigure3D(),
                Draw3DAnimation = new DrawFigure3DAnimation()
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

            view.btnDrawArt.Click += (s, e) => view.AddControlsToPanel(userControls.DrawImage);

            view.btnAnimate.Click += (s, e) => view.AddControlsToPanel(userControls.DrawAnimate);

            view.btnGame.Click += (s, e) => view.AddControlsToPanel(userControls.DrawGame);

            view.btnRotate.Click += (s, e) => view.AddControlsToPanel(userControls.DrawRotate);

            view.btn_DCL.Click += (s, e) => view.AddControlsToPanel(userControls.DrawClippingLines);

            view.btn_Gen.Click += (s, e) => view.AddControlsToPanel(userControls.DrawGenerationCurves);

            view.btnBline.Click += (s, e) => view.AddControlsToPanel(userControls.DrawB);
            
            view.btnPoly.Click += (s, e) => view.AddControlsToPanel(userControls.DrawPoly);

            view.btn3D.Click += (s, e) => view.AddControlsToPanel(userControls.Draw3D);

            view.btn3DAnimation.Click += (s, e) => view.AddControlsToPanel(userControls.Draw3DAnimation);

            /*Close main form*/
            view.pClose.Click += (s, e) => view.Close();
            #endregion

            #region Dark theme style
            /*Custom dark-theme*/
            view.pDarkTheme.Click += (s, e) =>
            {
                view.pDark.BackColor = Color.Black;

                view.btnPrev.BackColor = Color.Black;
                view.btnPrev.ForeColor = Color.White;

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

                view.btnPrev.BackColor = Color.Transparent;
                view.btnPrev.ForeColor = SystemColors.ControlDarkDark;

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


            view.btnNext.Click += (s, e) =>
            {
                view.btnNext.Visible = false;
                view.btnPrev.Visible = true;

                for (int i = 0; i < onePage.Count; i++)
                    onePage[i].Visible = false;

                for (int i = 0; i < twoPage.Count; i++)
                    twoPage[i].Visible = true;
            };

            view.btnPrev.Click += (s, e) =>
            {
                view.btnNext.Visible = true;
                view.btnPrev.Visible = false;

                for (int i = 0; i < onePage.Count; i++)
                    onePage[i].Visible = true;

                for (int i = 0; i < twoPage.Count; i++)
                    twoPage[i].Visible = false;

            };
            #endregion
        }
    }
}
