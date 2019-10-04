using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupManagement.Entities
{
    public class GeneralSettings
    {
        public string passPhrase = "";
        public string username = "";
        public string password = "";
        public DateTime lastDBBackupTime;
        public DateTime lastFolderBackupTime;
        public DateTime lastUploadTime;
    }
}

