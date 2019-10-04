using System;
using System.Windows.Forms;
using BackupManagement.Entities;
using BackupManagement.Helper;

namespace BackupManagement
{
    public partial class FrmSettingsFolder : Form
    {
        public FrmSettingsFolder()
        {
            InitializeComponent();
        }

        private void FrmFolderSettings_Load(object sender, EventArgs e)
        {
            FolderSettings folderettings = BkupSettings.GetSettingsFolder();
            txtBackupStartHour.Text = folderettings.startHour.ToString();
            txtBackupStartMinute.Text = folderettings.startMinute.ToString();
            txtBackupMinute.Text = folderettings.backupMinute.ToString();
            chkZipFolders.Checked = folderettings.isZipEnable;
            txtOutputPath.Text = folderettings.outputPath;
            txtFolderPaths.Text = folderettings.folderPaths;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderSettings folderSettings = new FolderSettings();
            folderSettings.startHour = Convert.ToInt32(txtBackupStartHour.Text);
            folderSettings.startMinute = Convert.ToInt32(txtBackupStartMinute.Text);
            folderSettings.backupMinute = Convert.ToInt32(txtBackupMinute.Text);
            if (chkZipFolders.Checked == true)
                folderSettings.isZipEnable = true;
            folderSettings.outputPath = txtOutputPath.Text;
            folderSettings.folderPaths = txtFolderPaths.Text;
            BkupSettings.SaveSettingsFolder(folderSettings);
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
