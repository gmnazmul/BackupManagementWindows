using BackupManagement.Entities;
using BackupManagement.Helper;
using MySql.Data.MySqlClient;
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

namespace BackupManagement
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            DBSettings dBSettings = BkupSettings.GetSettingsDB();

            string[] connectionStrings = dBSettings.connectionStrings.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );
            string nameDatePart = DateTime.Now.ToString("yyyyMMdd_HHmm");
            foreach (var connectionString in connectionStrings)
            {
                string databaseName = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => x.ToLower().StartsWith("database")).FirstOrDefault();
                if (string.IsNullOrEmpty(databaseName) == false)
                {
                    databaseName = databaseName.ToLower().Replace("database=", "");
                    string directoryPath = Path.Combine(dBSettings.outputPath, nameDatePart);
                    if (Directory.Exists(directoryPath) == false) { Directory.CreateDirectory(directoryPath); }
                    string file = Path.Combine(directoryPath, $"{databaseName}_{nameDatePart}.sql");
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ExportInfo.RowsExportMode = RowsDataExportMode.Insert;
                                mb.ExportToFile(file);
                                conn.Close();
                            }
                        }
                    }
                }

            }
        }

        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            FrmDbSettings frmDbSettings = new FrmDbSettings();
            frmDbSettings.ShowDialog();
        }

        #region Sample
        //string constring = "server=localhost;user=root;pwd=root;database=netcore_cms_oua;";
        //string file = "D:\\backup.sql";
        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            using (MySqlBackup mb = new MySqlBackup(cmd))
        //            {
        //                cmd.Connection = conn;
        //                conn.Open();
        //                mb.ExportInfo.RowsExportMode = RowsDataExportMode.OnDuplicateKeyUpdate;
        //                mb.ExportToFile(file);
        //                conn.Close();
        //            }
        //        }
        //    }
        #endregion
    }
}