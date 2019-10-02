using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupManagement.Helper
{
    public static class MySqlDbBackup
    {

        public static string QueryHead(string dbName, DateTime startTime)
        {
            string head = $@"
/*
BackupManagement v1.0
MySQL - 10.2.21-MariaDB-log : Database - {dbName}
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`{dbName}` /*!40100 DEFAULT CHARACTER SET ucs2 COLLATE ucs2_unicode_ci */;

USE `{dbName}`;

";
            return head;
        }

        public static string QueryFoot(string dbName, DateTime startTime,DateTime endTime)
        {
            string foot = $@"

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

";
            return foot;
        }

        public static List<string> LoadTableNames()
        {
            return new List<string>();
        }

        public static string TableQueryDropAndCreate(string tableName)
        {
            string query = $@"

/*Table structure for table `{tableName}` */

DROP TABLE IF EXISTS `{tableName}`;

";
            return query;
        }

        public static List<string> TableQueryInsertSingle(string tableName)
        {
            return new List<string>();
        }
    }
}
