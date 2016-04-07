using DelmoEncriptDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Methods.Login;

namespace WorkFlowMenagementMDI.Login
{
    public partial class LoginWindow : Form
    {
        LoginMethods dba = new LoginMethods();
        LoginSessionMonitor sessionMonitor = new LoginSessionMonitor();
        public LoginWindow()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {//●
            CheckPassword.Checked = false;
            TxtPassword.PasswordChar = '●';
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        { Application.Exit(); }

        private void Login_Load(object sender, EventArgs e)
        {
            ProvideConstrForm constr = new ProvideConstrForm();
            constr.Hide();
            TxtUserName.Text = Properties.Settings.Default.LastUser;
            ToolTip();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string name;
            string password = TxtPassword.Text;

            if (dba.GetEmployeAuth(TxtUserName.Text.Trim(), EncriptLib.SimpleCrypt(password)))
            {
                sessionMonitor.ExecuteLoginSession_SP(Properties.Settings.Default.UserID);
                Properties.Settings.Default.LastUser = TxtUserName.Text;
                Properties.Settings.Default.Save();

                this.Hide();
                name = TxtUserName.Text.ToLower();
                WorkFlowMenagement main = new WorkFlowMenagement();
                main.Show();
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Youe 'UserName' Or 'Password' is incorrect....!",
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                TxtPassword.Select(0, TxtPassword.TextLength);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
        public void ToolTip()
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.IsBalloon = true;
            ToolTip1.SetToolTip(this.BtnLogin, "Click to Login");
            ToolTip1.SetToolTip(this.BtnExit, "Click to Quit");
            ToolTip1.SetToolTip(this.TxtUserName, "Enter Username");
            ToolTip1.SetToolTip(this.TxtPassword, "Enter Password");
        }
        private void TxtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                LblCapslocAllert.Visible = true;
            }
            else
            {
                LblCapslocAllert.Visible = false;
            }
        }

        private void CheckPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = CheckPassword.Checked ? '\0' : '●';
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnLogin_Click(sender, e);
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPassword.Focus();
                e.Handled = true;
            }
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.Clear();
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
