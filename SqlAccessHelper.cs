
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
namespace WebApplication1
{
    public class SqlAccessHelper
    {
        //public static string ConnectionString = "Server=tcp:opl-dev.database.windows.net,1433;Initial Catalog=OPL_DEV;Persist Security Info=False;User ID=thomas;Password=Hydr@DMCC1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        //public static string ConnectionString = @"Data Source = HBERPSVR\SQLEXPRESS; Database = OPL; User ID = sa; pwd = $ql@dmin1";
        //public static string ConnectionString = "Data Source = 192.168.11.51; Database = OPL_Dev; User ID = thomas; pwd = thomas";
        //public static string ConnectionString = @"Data Source = .; Initial Catalog = DEV_HSMS; Integrated Security=True";
    }
}