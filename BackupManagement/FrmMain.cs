using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string constring = "server=localhost;user=root;pwd=root;database=netcore_cms_oua;";
            string file = "D:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportInfo.RowsExportMode = RowsDataExportMode.OnDuplicateKeyUpdate;
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }

        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            FrmDbSettings frmDbSettings = new FrmDbSettings();
            frmDbSettings.ShowDialog();            
        }
    }
}
