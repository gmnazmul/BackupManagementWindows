using BackupManagement.Entities;
using BackupManagement.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupManagement
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) == false && string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtUsername.Text) == false && string.IsNullOrEmpty(txtPassword.Text) == false)
            {
                GeneralSettings gs = BkupSettings.GetSettingsGeneral();
                if (string.IsNullOrEmpty(gs.username) || string.IsNullOrEmpty(gs.password))
                {
                    gs.username = txtUsername.Text.Trim();
                    gs.password = txtPassword.Text.Trim();
                    BkupSettings.SaveSettingsGeneral(gs);
                }
                else if (gs.username.ToLower() != txtUsername.Text.Trim().ToLower() || gs.password != txtPassword.Text.Trim())
                {
                    MessageBox.Show("Invalid Username or password.");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    return;
                }

                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter Username and password");
                txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
