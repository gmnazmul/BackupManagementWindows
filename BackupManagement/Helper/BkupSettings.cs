using BackupManagement.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupManagement.Helper
{
    public static class BkupSettings
    {
        private static string dbSettingsPath = Path.Combine(Application.StartupPath, "BackupConfigDB.zipConf");
        private static string folderSettingsPath = Path.Combine(Application.StartupPath, "BackupConfigFolder.zipConf");
        private static string generalSettingsPath = Path.Combine(Application.StartupPath, "BackupConfigGeneral.zipConf");
        //private static string passPhrase = "SecretKey";

        #region DBSettings
        public static DBSettings GetSettingsDB()
        {
            GeneralSettings gs = GetSettingsGeneral();
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
                                dBSettings.startHour = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 1)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.startMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 2)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.backupMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 3)
                        {
                            if (string.IsNullOrEmpty(line) == false && line == "1")
                                dBSettings.isZipEnable = true;
                        }
                        else if (lineNumber == 4)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                dBSettings.outputPath = EncryptDecrypt.DecryptString(line, gs.passPhrase);
                        }
                        else if (lineNumber >= 5)
                        {
                            if (string.IsNullOrEmpty(line) == false && string.IsNullOrEmpty(dBSettings.connectionStrings) == false)
                                dBSettings.connectionStrings += $"{Environment.NewLine}{EncryptDecrypt.DecryptString(line, gs.passPhrase)}";
                            else if (string.IsNullOrEmpty(line) == false)
                                dBSettings.connectionStrings += $"{EncryptDecrypt.DecryptString(line, gs.passPhrase)}";
                        }

                        lineNumber++;
                    }
                }
            }

            return dBSettings;
        }

        public static bool SaveSettingsDB(DBSettings dBSettings)
        {
            GeneralSettings gs = GetSettingsGeneral();
            using (var writer = new StreamWriter(dbSettingsPath))
            {
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.startHour.ToString(), gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.startMinute.ToString(), gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.backupMinute.ToString(), gs.passPhrase));
                if (dBSettings.isZipEnable == true)
                    writer.WriteLine("1");
                else
                    writer.WriteLine("0");
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.outputPath, gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(dBSettings.connectionStrings, gs.passPhrase));
            }
            return true;
        }
        #endregion

        #region FolderSettings

        public static FolderSettings GetSettingsFolder()
        {
            GeneralSettings gs = GetSettingsGeneral();
            FolderSettings folderSettings = new FolderSettings();
            folderSettings.outputPath = Path.Combine(Application.StartupPath, "OutputFolder");
            if (File.Exists(folderSettingsPath) == true)
            {
                StringBuilder sbText = new StringBuilder();
                string line = "";
                using (var reader = new StreamReader(folderSettingsPath))
                {
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber == 0)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.startHour = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 1)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.startMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 2)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.backupMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 3)
                        {
                            if (string.IsNullOrEmpty(line) == false && line == "1")
                                folderSettings.isZipEnable = true;
                        }
                        else if (lineNumber == 4)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.outputPath = EncryptDecrypt.DecryptString(line, gs.passPhrase);
                        }
                        else if (lineNumber >= 5)
                        {
                            if (string.IsNullOrEmpty(line) == false && string.IsNullOrEmpty(folderSettings.folderPaths) == false)
                                folderSettings.folderPaths += $"{Environment.NewLine}{EncryptDecrypt.DecryptString(line, gs.passPhrase)}";
                            else if (string.IsNullOrEmpty(line) == false)
                                folderSettings.folderPaths += $"{EncryptDecrypt.DecryptString(line, gs.passPhrase)}";
                        }

                        lineNumber++;
                    }
                }
            }

            return folderSettings;
        }

        public static bool SaveSettingsFolder(FolderSettings folderSettings)
        {
            GeneralSettings gs = GetSettingsGeneral();
            using (var writer = new StreamWriter(folderSettingsPath))
            {
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.startHour.ToString(), gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.startMinute.ToString(), gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.backupMinute.ToString(), gs.passPhrase));
                if (folderSettings.isZipEnable == true)
                    writer.WriteLine("1");
                else
                    writer.WriteLine("0");
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.outputPath, gs.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.folderPaths, gs.passPhrase));
            }
            return true;
        }
        #endregion


        #region GeneralSettings
        static string GetRandomString(int lenOfTheNewStr)
        {
            string output = string.Empty;
            while (true)
            {
                output += Path.GetRandomFileName().Replace(".", string.Empty);

                if (output.Length > lenOfTheNewStr)
                {
                    output = output.Substring(0, lenOfTheNewStr);
                    break;
                }
            }
            return output;
        }
        public static GeneralSettings GetSettingsGeneral()
        {
            GeneralSettings gs = new GeneralSettings();
            var rand = new Random();            
            gs.passPhrase = GetRandomString(20);
            if (File.Exists(generalSettingsPath) == true)
            {
                StringBuilder sbText = new StringBuilder();
                string line = "";
                using (var reader = new StreamReader(generalSettingsPath))
                {
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber == 0)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.passPhrase = line;
                        }
                        else if (lineNumber == 1)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.username = EncryptDecrypt.DecryptString(line, gs.passPhrase);
                        }
                        else if (lineNumber == 2)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.password = EncryptDecrypt.DecryptString(line, gs.passPhrase);
                        }
                        else if (lineNumber == 3)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.lastDBBackupTime = Convert.ToDateTime(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber == 4)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.lastFolderBackupTime = Convert.ToDateTime(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }
                        else if (lineNumber >= 5)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                gs.lastUploadTime = Convert.ToDateTime(EncryptDecrypt.DecryptString(line, gs.passPhrase));
                        }

                        lineNumber++;
                    }
                }
            }

            return gs;
        }

        public static bool SaveSettingsGeneral(GeneralSettings generalSettings)
        {
            using (var writer = new StreamWriter(generalSettingsPath))
            {
                writer.WriteLine(generalSettings.passPhrase);
                writer.WriteLine(EncryptDecrypt.EncryptString(generalSettings.username.ToString(), generalSettings.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(generalSettings.password.ToString(), generalSettings.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(generalSettings.lastDBBackupTime.ToString(), generalSettings.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(generalSettings.lastFolderBackupTime.ToString(), generalSettings.passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(generalSettings.lastUploadTime.ToString(), generalSettings.passPhrase));
            }
            return true;
        }
        #endregion

        public static bool BackupFolders(string directoryPath, string nameDatePart)
        {
            FolderSettings folderSettings = GetSettingsFolder();

            string[] folderPaths = folderSettings.folderPaths.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

            foreach (var folderPath in folderPaths)
            {
                string outputFileName = nameDatePart + "_" + folderPath.Replace("\\", "_").Replace(":", "") + ".zip";
                System.IO.Compression.ZipFile.CreateFromDirectory(folderPath, Path.Combine(directoryPath, outputFileName));
            }
            return true;
        }
    }
}