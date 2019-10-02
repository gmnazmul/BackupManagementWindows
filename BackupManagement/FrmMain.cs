using BackupManagement.Entities;
using BackupManagement.Helper;
using System;
using System.IO;
using System.Windows.Forms;

namespace BackupManagement
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            FrmDbSettings frmDbSettings = new FrmDbSettings();
            frmDbSettings.ShowDialog();
        }

        private void btnFolderSettings_Click(object sender, EventArgs e)
        {
            FrmFolderSettings frmFolderSettings = new FrmFolderSettings();
            frmFolderSettings.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();
            string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            string directoryPath = Path.Combine(dBSettings.outputPath, nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            BkupSettings.BackupDatabase(directoryPath, nameDatePart);

            MessageBox.Show("Backup Complated");
        }

        private void btnBackupFolder_Click(object sender, EventArgs e)
        {

            FolderSettings folderSettings = BkupSettings.GetSettingsFolder();
            string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            string directoryPath = Path.Combine(folderSettings.outputPath, nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            BkupSettings.BackupFolders(directoryPath);

            MessageBox.Show("Backup Complated");
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {

            DBSettings dBSettings = BkupSettings.GetSettingsDB();
            string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            string directoryPath = Path.Combine(dBSettings.outputPath, nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            BkupSettings.BackupDatabase(directoryPath, nameDatePart);

            BkupSettings.BackupFolders(directoryPath);

            MessageBox.Show("Backup Complated");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}