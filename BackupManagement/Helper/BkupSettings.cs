using BackupManagement.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupManagement.Helper
{
    public static class BkupSettings
    {
        private static string dbSettingsPath = Path.Combine(Application.StartupPath, "dbConfig.zipConf");
        private static string passPhrase = "SecretKey";

        public static DBSettings GetSettings()
        {
            DBSettings dBSettings = new DBSettings();
            dBSettings.outputPath = Path.Combine(Application.StartupPath, "OutputFolder");
            if (File.Exists(dbSettingsPath) == true)
            {
                StringBuilder sbText = new StringBuilder();
                string line = "";
                using (var reader = new StreamReader(dbSettingsPath))
                {
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber == 0)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.startHour = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 1)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.startMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 2)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.backupMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 3)
                        {
                            if (string.IsNullOrEmpty(line) == false && line == "1")
                                dBSettings.isZipEnable = true;
                        }
                        else if (lineNumber == 4)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.outputPath = EncryptDecrypt.DecryptString(line, passPhrase);
                        }
                        else if (lineNumber >= 5)
                        {
                            if (string.IsNullOrEmpty(line) == false && string.IsNullOrEmpty(dBSettings.connectionStrings) == false)
                                dBSettings.connectionStrings += $"{Environment.NewLine}{EncryptDecrypt.DecryptString(line, passPhrase)}";
                            else if (string.IsNullOrEmpty(line) == false)
                                dBSettings.connectionStrings += $"{EncryptDecrypt.DecryptString(line, passPhrase)}";
                        }

                        lineNumber++;
                    }
                }
            }

            return dBSettings;
        }

        public static bool SaveSettings(DBSettings dBSettings)
        {
            if (File.Exists(dbSettingsPath) == false)
            {
                File.Create(dbSettingsPath);
            }

            using (var writer = new StreamWriter(dbSettingsPath))
            {
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.startHour.ToString(), passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.startMinute.ToString(), passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.backupMinute.ToString(), passPhrase));
                if (dBSettings.isZipEnable == true)
                    writer.WriteLine("1");
                else
                    writer.WriteLine("0");
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.outputPath, passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.connectionStrings, passPhrase));
            }
            return true;
        }
    }
}
