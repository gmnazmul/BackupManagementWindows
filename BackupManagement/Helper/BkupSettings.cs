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
        private static string passPhrase = "SecretKey";

        #region DBSettings
        public static DBSettings GetSettingsDB()
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

        public static bool SaveSettingsDB(DBSettings dBSettings)
        {
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
        #endregion

        #region FolderSettings

        public static FolderSettings GetSettingsFolder()
        {
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
                                folderSettings.startHour = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 1)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.startMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 2)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.backupMinute = Convert.ToInt32(EncryptDecrypt.DecryptString(line, passPhrase));
                        }
                        else if (lineNumber == 3)
                        {
                            if (string.IsNullOrEmpty(line) == false && line == "1")
                                folderSettings.isZipEnable = true;
                        }
                        else if (lineNumber == 4)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                                folderSettings.outputPath = EncryptDecrypt.DecryptString(line, passPhrase);
                        }
                        else if (lineNumber >= 5)
                        {
                            if (string.IsNullOrEmpty(line) == false && string.IsNullOrEmpty(folderSettings.folderPaths) == false)
                                folderSettings.folderPaths += $"{Environment.NewLine}{EncryptDecrypt.DecryptString(line, passPhrase)}";
                            else if (string.IsNullOrEmpty(line) == false)
                                folderSettings.folderPaths += $"{EncryptDecrypt.DecryptString(line, passPhrase)}";
                        }

                        lineNumber++;
                    }
                }
            }

            return folderSettings;
        }

        public static bool SaveSettingsFolder(FolderSettings folderSettings)
        {
            using (var writer = new StreamWriter(folderSettingsPath))
            {
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.startHour.ToString(), passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.startMinute.ToString(), passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.backupMinute.ToString(), passPhrase));
                if (folderSettings.isZipEnable == true)
                    writer.WriteLine("1");
                else
                    writer.WriteLine("0");
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.outputPath, passPhrase));
                writer.WriteLine(EncryptDecrypt.EncryptString(folderSettings.folderPaths, passPhrase));
            }
            return true;
        }
        #endregion

        public static bool BackupDatabase(string directoryPath, string nameDatePart)
        {
            DBSettings dBSettings = GetSettingsDB();

            string[] connectionStrings = dBSettings.connectionStrings.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

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
                    string outputFileFullPath = Path.Combine(directoryPath, $"{nameDatePart}_{databaseName}.sql");
                    string outputFileFullPathTemp = Path.Combine(directoryPath, "temp", $"{nameDatePart}_{databaseName}.sql");
                    string arguments = $"/C mysqldump.exe -P {port} -h {host} --skip-extended-insert -u {user} -p{pass} {databaseName} > ";

                    if (dBSettings.isZipEnable == true)
                    {
                        if (Directory.Exists(Path.Combine(directoryPath, "temp"))==false)
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
                    if (dBSettings.isZipEnable == true)
                    {
                        System.IO.Compression.ZipFile.CreateFromDirectory(Path.Combine(directoryPath, "temp"), Path.Combine(directoryPath, $"{nameDatePart}_{databaseName}.zip"));

                    }
                }
            }
            if (Directory.Exists(Path.Combine(directoryPath, "temp")))
            {
                Directory.Delete(Path.Combine(directoryPath, "temp"), true);
            }
            return true;
        }

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