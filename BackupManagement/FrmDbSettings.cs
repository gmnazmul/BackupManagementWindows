using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackupManagement.Helper;

namespace BackupManagement
{
    public partial class FrmDbSettings : Form
    {
        private string dbSettingsPath = Path.Combine(Application.StartupPath, "dbConfig.zipConf");
        public string passPhrase = "SecretKey";
        public FrmDbSettings()
        {
            InitializeComponent();
        }

        private void FrmDbSettings_Load(object sender, EventArgs e)
        {
            if (File.Exists(dbSettingsPath) == false)
            {
                File.Create(dbSettingsPath);
            }

            StringBuilder sbText = new StringBuilder();
            string line = "";
            using (var reader = new StreamReader(dbSettingsPath))
            {
                int lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber == 0)
                    {
                        if (string.IsNullOrEmpty(line))
                            txtBackupStartHour.Text = "0";
                        else
                            txtBackupStartHour.Text = EncryptDecrypt.DecryptString(line, passPhrase);
                    }
                    else if (lineNumber == 1)
                    {
                        if (string.IsNullOrEmpty(line))
                            txtBackupStartMinute.Text = "0";
                        else
                            txtBackupStartMinute.Text = EncryptDecrypt.DecryptString(line, passPhrase);
                    }
                    else if (lineNumber == 2)
                    {
                        if (string.IsNullOrEmpty(line))
                            txtBackupMinute.Text = "360";
                        else
                            txtBackupMinute.Text = EncryptDecrypt.DecryptString(line, passPhrase);
                    }
                    else if (lineNumber == 3)
                    {
                        if (string.IsNullOrEmpty(line) || line == "0")
                            chkZipDbFiles.Checked = false;
                        else
                            chkZipDbFiles.Checked = true;
                    }
                    else if (lineNumber == 4)
                    {
                        if (string.IsNullOrEmpty(line))
                            txtOutputPath.Text = Path.Combine(Application.StartupPath, "OutputFolder");
                        else
                            txtOutputPath.Text = EncryptDecrypt.DecryptString(line, passPhrase);
                    }
                    else if (lineNumber >= 5)
                    {
                        if (string.IsNullOrEmpty(line) == false && string.IsNullOrEmpty(txtConnectionStrings.Text) == false)
                            txtConnectionStrings.Text += $"{Environment.NewLine}{EncryptDecrypt.DecryptString(line, passPhrase)}";
                        else if (string.IsNullOrEmpty(line) == false)
                            txtConnectionStrings.Text += $"{EncryptDecrypt.DecryptString(line, passPhrase)}";
                    }

                    lineNumber++;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter(dbSettingsPath))
            {
                writer.WriteLine(EncryptDecrypt.EncryptString(txtBackupStartHour.Text, passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(txtBackupStartMinute.Text, passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(txtBackupMinute.Text, passPhrase));
                if (chkZipDbFiles.Checked == true)
                    writer.WriteLine("1");
                else
                    writer.WriteLine("0");
                writer.WriteLine(EncryptDecrypt.EncryptString(txtOutputPath.Text, passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(txtConnectionStrings.Text, passPhrase));
            }
            MessageBox.Show("Settings Saved");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
