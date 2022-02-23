
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;
using System.Text;

namespace WebApplication1
{
    public class Cus_Exception
    {
        private object logWriteLock = new object();
        private FileStream fileStream = null;
        private StreamWriter streamWriter = null;
        private static Cus_Exception _utException;

        private Cus_Exception()
        {

        }

        public static Cus_Exception Instance
        {
            get
            {
                if (_utException == null)
                {
                    _utException = new Cus_Exception();
                }
                return _utException;
            }
        }

        public void HandleMe(object sender, Exception ex, string MethodName)
        {
            try
            {
                if (!(ex is System.Threading.ThreadAbortException))
                {
                    WriteLog(sender.ToString(), MethodName + ";" + ex.Message.ToString() + " - " + ex.StackTrace);
                }
            }
            catch (Exception outex)
            {
                WriteLog("Exception_outer", outex.Message.ToString());
            }
        }

        private void WriteLog(string module, string message)
        {
            string strDateTime;
            strDateTime = DateTime.Now.Day.ToString() + "-" +
                DateTime.Now.Month.ToString() + "-" +
                DateTime.Now.Year.ToString() + " " +
                DateTime.Now.Hour.ToString() + "_" +
                DateTime.Now.Minute.ToString() + "_" +
                DateTime.Now.Millisecond.ToString();


            lock (logWriteLock)
            {
                string EmpID = "00";
                if (HttpContext.Current.Session["LoginID"] != null)
                    EmpID = HttpContext.Current.Session["LoginID"].ToString();
                if (string.IsNullOrWhiteSpace(EmpID))
                    EmpID = "Empty";
                string strLogFilePath = ConfigurationManager.AppSettings["ApplicationLog"].ToString();
                // For Shifad separate log path
                //if (EmpID == "REA22595")
                //{
                //    strLogFilePath = ConfigurationManager.AppSettings["ApplicationLog_Shifad"].ToString();
                //}
                strLogFilePath = strLogFilePath + DateTime.Now.ToString("ddMMMyyyy") + Path.DirectorySeparatorChar + EmpID;
                if (!(System.IO.Directory.Exists(strLogFilePath)))
                {
                    System.IO.Directory.CreateDirectory(strLogFilePath);
                }
                string LogFileName = strLogFilePath + Path.DirectorySeparatorChar + strDateTime + ".log";
                fileStream = new FileStream(LogFileName, FileMode.Append, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
                string ErrorMsg = GetIPAddress() + " - " +
                                   DateTime.Now.ToString() + " " +
                                   module + " - " + message;
                streamWriter.WriteLine(ErrorMsg);
                streamWriter.Flush();
                fileStream.Close();
            }
        }

        private string GetIPAddress()
        {
            string sIPAddress = string.Empty;
            sIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (sIPAddress == null || sIPAddress == "")
            {
                sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (HttpContext.Current.Session["LoginID"] != null && HttpContext.Current.Session["LoginName"] != null)
            {
                return sIPAddress + '-' + HttpContext.Current.Session["LoginID"].ToString() + '-' + HttpContext.Current.Session["LoginName"].ToString();
            }
            return sIPAddress + "- - ";
        }

    }
}