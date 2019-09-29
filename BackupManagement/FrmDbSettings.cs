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
    public partial class FrmDbSettings : Form
    {
        public FrmDbSettings()
        {
            InitializeComponent();
        }

        private void FrmDbSettings_Load(object sender, EventArgs e)
        {
            var dbSettingsPath= Path.Combine(Application.StartupPath,"dbConfig.zipConf");
            if (File.Exists(dbSettingsPath) ==false)
            {
                File.Create(dbSettingsPath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
