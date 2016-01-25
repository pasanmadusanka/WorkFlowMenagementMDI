using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.FuelApp.Views
{
    public partial class Splash : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Splash_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #region FIELDS

        Timer timer = new Timer();
        bool fadeIn = true;
        bool fadeOut = true;

        #endregion

        #region METHODS

        public Splash()
        {
            InitializeComponent();

            ExtraFormSettings();
            SetAndStartTimer();
        }

        private void SetAndStartTimer()
        {
            timer.Interval = 35;
            timer.Tick += new EventHandler(t_Tick);
            timer.Start();
        }

        private void ExtraFormSettings()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.5;
            this.BackgroundImage = Properties.Resources.Half_Page;
        }

        #endregion

        #region EVENTS

        void t_Tick(object sender, EventArgs e)
        {
            if (fadeIn)
            {
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.02;
                }
                else
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }
            else if (fadeOut)
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.02;
                }
                else
                {
                    fadeOut = false;
                }
            }

            if (!(fadeIn || fadeOut))
            {
                timer.Stop();
                this.Close();
            }
        }

        #endregion

        
    }
}
