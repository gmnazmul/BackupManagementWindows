using System;
using System.Windows.Forms;
using BackupManagement.Entities;
using BackupManagement.Helper;

namespace BackupManagement
{
    public partial class FrmSettingsDB : Form
    {
        public FrmSettingsDB()
        {
            InitializeComponent();
        }

        private void FrmDbSettings_Load(object sender, EventArgs e)
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();
            txtBackupStartHour.Text = dBSettings.startHour.ToString();
            txtBackupStartMinute.Text = dBSettings.startMinute.ToString();
            txtBackupMinute.Text = dBSettings.backupMinute.ToString();
            chkZipDbFiles.Checked = dBSettings.isZipEnable;
            txtOutputPath.Text = dBSettings.outputPath;
            txtConnectionStrings.Text = dBSettings.connectionStrings;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBSettings dBSettings = new DBSettings();
            dBSettings.startHour = Convert.ToInt32(txtBackupStartHour.Text);
            dBSettings.startMinute = Convert.ToInt32(txtBackupStartMinute.Text);
            dBSettings.backupMinute = Convert.ToInt32(txtBackupMinute.Text);
            if (chkZipDbFiles.Checked == true)
                dBSettings.isZipEnable = true;
            dBSettings.outputPath = txtOutputPath.Text;
            dBSettings.connectionStrings = txtConnectionStrings.Text;
            BkupSettings.SaveSettingsDB(dBSettings);
            MessageBox.Show("Settings Saved");
            btnClose.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBackupStartHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
