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
        public FrmMain()
        {
            InitializeComponent();
            new Thread(ClockUpdate).Start();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy") + Environment.NewLine + machineName;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();
            nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");

            //var th = new Thread(BackupDatabase);
            //th.Start();

            Thread.Sleep(1000 * 60);
            //th.Join();

            MessageBox.Show("Backup Complated");
        }

        private void btnBackupFolder_Click(object sender, EventArgs e)
        {

            FolderSettings folderSettings = BkupSettings.GetSettingsFolder();
            string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            string directoryPath = Path.Combine(folderSettings.outputPath, nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            BkupSettings.BackupFolders(directoryPath, nameDatePart);

            MessageBox.Show("Backup Complated");
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {            
            nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
           
            new Thread(BackupDatabase).Start();

            BkupSettings.BackupFolders("", nameDatePart);

            MessageBox.Show("Backup Complated");
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
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Helper
        private void ClockUpdate()
        {
            while (true)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                });
                Thread.Sleep(1000);
            }
        }

        private void BackupDatabase()
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();


            this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}DATABAE BACKUP PROCESS COMPLETED"; });

            string directoryPath = Path.Combine(dBSettings.outputPath, machineName + "_" + nameDatePart);
            if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }

            string[] connectionStrings = dBSettings.connectionStrings.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );
            this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}{connectionStrings.Count()} Connection string found"; });
            foreach (var connectionString in connectionStrings)
            {
                List<string> parts = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string port = parts.Where(x => x.ToLower().StartsWith("port")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string host = parts.Where(x => x.ToLower().StartsWith("server")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string user = parts.Where(x => x.ToLower().StartsWith("userid")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string pass = parts.Where(x => x.ToLower().StartsWith("pwd")).FirstOrDefault()?.Split(new[] { '=' })[1];
                string databaseName = parts.Where(x => x.ToLower().StartsWith("database")).FirstOrDefault()?.Split(new[] { '=' })[1];
                //databaseName = databaseName.ToLower().Replace("database=", "");
                if (string.IsNullOrEmpty(databaseName) == false)
                {
                    this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} START"; });
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
                    //startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    //Thread.Sleep(5);
                    this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} Backup Complete"; });
                    if (dBSettings.isZipEnable == true)
                    {
                        this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} Zipping Start"; });
                        System.IO.Compression.ZipFile.CreateFromDirectory(Path.Combine(directoryPath, "temp"), Path.Combine(directoryPath, $"{nameDatePart}_{databaseName}.zip"));
                        this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} Zipping Complete, Raw file deleting..."; });

                        if (File.Exists(outputFileFullPathTemp))
                        {
                            File.Delete(outputFileFullPathTemp);
                        }
                        this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} Raw File Deleted."; });
                    }
                    this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}Database: {databaseName} Backup COMPLETED"; });
                }
            }
            if (Directory.Exists(Path.Combine(directoryPath, "temp")))
            {
                Directory.Delete(Path.Combine(directoryPath, "temp"), true);
            }
            this.Invoke((MethodInvoker)delegate () { lblLogs.Text = $"{Environment.NewLine}DATABAE BACKUP PROCESS COMPLETED"; });
        }

        private void FolderBackup()
        {
        }

        private void UploadBackup()
        {
        }
        #endregion
    }
}