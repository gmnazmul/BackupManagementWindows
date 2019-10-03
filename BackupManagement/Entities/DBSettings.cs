using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupManagement.Entities
{
    public class DBSettings
    {
        public int startHour = 0;
        public int startMinute = 0;
        public int backupMinute = 360;
        public bool isZipEnable = true;
        public string outputPath = "";
        public string connectionStrings = "";
    }
}
