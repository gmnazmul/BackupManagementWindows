using BackupManagement.Entities;
using BackupManagement.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BackupManagement
{
    public partial class FrmMain : Form
    {
        string machineName = Environment.MachineName;
        string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
        int dbStatus = 0;
        int folderStatus = 0;
        int uploadStatus = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"{Settings.Name} v{Settings.Version}";
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy") + Environment.NewLine + machineName;

            UpdateLastUpdateDate();

            //Thread thClockUpdate = new Thread(ClockUpdate);
            //thClockUpdate.Start();
        }
        
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();
            nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");

            var thDB = new Thread(BackupDatabase);
            thDB.Start();
        }

        private void btnBackupFolder_Click(object sender, EventArgs e)
        {

            FolderSettings folderSettings = BkupSettings.GetSettingsFolder();
            nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            var thFo = new Thread(BackupFolders);
            thFo.Start();
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {
            nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");

            var th = new Thread(BackupDatabase);
            th.Start();

            var thFo = new Thread(BackupFolders);
            thFo.Start();
        }

        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            FrmSettingsDB frmDbSettings = new FrmSettingsDB();
            frmDbSettings.ShowDialog();
        }

        private void btnFolderSettings_Click(object sender, EventArgs e)
        {
            FrmSettingsFolder frmFolderSettings = new FrmSettingsFolder();
            frmFolderSettings.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Environment.Exit(Environment.ExitCode);
        }

        #region Helper
        private void UpdateLastUpdateDate()
        {
            GeneralSettings gs = BkupSettings.GetSettingsGeneral();

            if (gs.lastDBBackupTime > new DateTime(2001, 1, 1))
                lblLastData.Text = $"Last DB backup: {gs.lastDBBackupTime.ToString("yyyy-MM-dd HH:mm")}";
            else
                lblLastData.Text = $"Last DB backup: - ";

            if (gs.lastFolderBackupTime > new DateTime(2001, 1, 1))
                lblLastData.Text += $"{Environment.NewLine}Last Folder backup: {gs.lastFolderBackupTime.ToString("yyyy-MM-dd HH:mm")}";
            else
                lblLastData.Text += $"{Environment.NewLine}Last Folder backup: - ";

            if (gs.lastUploadTime > new DateTime(2001, 1, 1))
                lblLastData.Text += $"{Environment.NewLine}Last Upload: {gs.lastUploadTime.ToString("yyyy-MM-dd HH:mm")}";
            else
                lblLastData.Text += $"{Environment.NewLine}Last Upload: - ";
        }

        private void ClockUpdate()
        {
            while (true)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                });

                Thread.Sleep(500);
            }
        }

        private void BackupDatabase()
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();

            ShowLogDb($"DATABAE BACKUP PROCESS STARTED @{DateTime.Now.ToString("HH:mm:ss")} [Do Not Close This Window]");

            string directoryPath = Path.Combine(dBSettings.outputPath, machineName + "_" + nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            string[] connectionStrings = dBSettings.connectionStrings.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );
            ShowLogDb($"{connectionStrings.Count()} Connection string found.");
            foreach (var connectionString in connectionStrings)
            {
                //Thread.Sleep(5000);
                List<string> parts = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string port = parts.Where(x => x.ToLower().StartsWith("port")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string host = parts.Where(x => x.ToLower().StartsWith("server")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string user = parts.Where(x => x.ToLower().StartsWith("userid")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string pass = parts.Where(x => x.ToLower().StartsWith("pwd")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string databaseName = parts.Where(x => x.ToLower().StartsWith("database")).FirstOrDefault()?.Split(new[] { '=' })[1];
                //databaseName = databaseName.ToLower().Replace("database=", "");
                if (string.IsNullOrEmpty(databaseName) == false)
                {
                    ShowLogDb($"Backup for Database: {databaseName} Started.");
                    string outputFileFullPath = Path.Combine(directoryPath, $"{nameDatePart}_{databaseName}.sql");
                    string outputFileFullPathTemp = Path.Combine(directoryPath, "temp", $"{nameDatePart}_{databaseName}.sql");
                    string arguments = $"/C mysqldump.exe -P {port} -h {host} --skip-extended-insert -u {user} -p{pass} {databaseName} > ";

                    if (dBSettings.isZipEnable == true)
                    {
                        if (Directory.Exists(Path.Combine(directoryPath, "temp")) == false)
                        {
                            Directory.CreateDirectory(Path.Combine(directoryPath, "temp"));
                        }
                        arguments += $" \"{outputFileFullPathTemp}\"";
                    }
                    else
                        arguments += $" \"{outputFileFullPath}\"";

                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = @"C:\Windows\System32\cmd.exe";
                    startInfo.Arguments = arguments;
                    ////startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    Thread.Sleep(5);
                    ShowLogDb($"Backup Completed.");
                    if (dBSettings.isZipEnable == true)
                    {
                        ShowLogDb($"Zipping Started.");
                        System.IO.Compression.ZipFile.CreateFromDirectory(Path.Combine(directoryPath, "temp"), Path.Combine(directoryPath, $"{nameDatePart}_{databaseName}.zip"));
                        ShowLogDb($"Zipping Completed.{Environment.NewLine}Deleting raw file...");

                        if (File.Exists(outputFileFullPathTemp))
                        {
                            File.Delete(outputFileFullPathTemp);
                        }
                        ShowLogDb($"Raw File Deleted.");
                    }
                    ShowLogDb($"Backup Completed for Database: {databaseName}");
                    ShowLogDb($"--------------------");
                }
            }
            if (Directory.Exists(Path.Combine(directoryPath, "temp")))
            {
                Directory.Delete(Path.Combine(directoryPath, "temp"), true);
            }
            ShowLogDb($"DATABAE BACKUP PROCESS COMPLETED @{DateTime.Now.ToString("HH:mm:ss")}");

            #region DB Backup time update
            GeneralSettings gs = BkupSettings.GetSettingsGeneral();
            gs.lastDBBackupTime = DateTime.Now;
            BkupSettings.SaveSettingsGeneral(gs);
            #endregion
            UpdateLastUpdateDate();
        }

        private void BackupFolders()
        {
            FolderSettings folderSettings = BkupSettings.GetSettingsFolder();

            ShowLogFolder($"FOLDER BACKUP PROCESS STARTED @{DateTime.Now.ToString("HH:mm:ss")} [Do Not Close This Window]");

            string directoryPath = Path.Combine(folderSettings.outputPath, machineName + "_" + nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            string[] folderPaths = folderSettings.folderPaths.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );
            ShowLogFolder($"{folderPaths.Count()} Folder(s) found.");
            foreach (var folderPath in folderPaths)
            {
                string outputFileName = nameDatePart + "_" + folderPath.Replace("\\", "_").Replace(":", "") + ".zip";
                ShowLogFolder($"Zipping Started for Folder: {outputFileName}");
                System.IO.Compression.ZipFile.CreateFromDirectory(folderPath, Path.Combine(directoryPath, outputFileName));
            }
            ShowLogFolder($"FOLDER BACKUP PROCESS COMPLETED @{DateTime.Now.ToString("HH:mm:ss")}");

            #region Folder Backup time update
            GeneralSettings gs = BkupSettings.GetSettingsGeneral();
            gs.lastFolderBackupTime = DateTime.Now;
            BkupSettings.SaveSettingsGeneral(gs);
            #endregion
            UpdateLastUpdateDate();
        }

        private void UploadBackup()
        {

        }

        private void ShowLogDb(string message)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                txtLogsDb.Text += $"{Environment.NewLine}{message}";
                txtLogsDb.SelectionStart = txtLogsDb.Text.Length;
                txtLogsDb.ScrollToCaret();
            });
        }

        private void ShowLogFolder(string message)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                txtLogsFolder.Text += $"{Environment.NewLine}{message}";
                txtLogsFolder.SelectionStart = txtLogsFolder.Text.Length;
                txtLogsFolder.ScrollToCaret();
            });
        }
        #endregion
    }
}