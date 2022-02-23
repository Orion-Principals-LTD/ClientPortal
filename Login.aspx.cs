using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserID"] = null;
        }
        private bool ValidateUser()
        {
            try
            {
                DataSet dsLogin = new DataSet();
                Session["UserID"] = null;
                Session["UserID"] = 0;
                Session["CompID"] = 0;

                string sIPAddress = string.Empty;
                sIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (sIPAddress == null || sIPAddress == "")
                {
                    sIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                String str = LoginName.Value.Trim();
                Char value = '@';
                Boolean result = str.Contains(value);

                SqlParameter[] para = new SqlParameter[3];

                para[0] = new SqlParameter("@LoginID", SqlDbType.VarChar, 100);
                para[0].Value = LoginName.Value.Trim().ToLower();

                para[1] = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                para[1].Value = txtpassword.Value.Trim();

                para[2] = new SqlParameter("@IP", SqlDbType.VarChar, 20);
                para[2].Value = sIPAddress;

                if (result)
                { dsLogin = SqlHelper.ExecuteDataset(SqlAccessHelper.ConnectionString, CommandType.StoredProcedure, "sp_ADM_User_Validation_EmailID", para); }
                else
                {
                    dsLogin = SqlHelper.ExecuteDataset(SqlAccessHelper.ConnectionString, CommandType.StoredProcedure, "sp_ADM_User_Validation", para);
                }


                if (dsLogin.Tables.Count > 0)
                {
                    int userID = Convert.ToInt32(dsLogin.Tables[0].Rows[0]["UserID"]);

                    if (userID == -1) // No User registered
                    {
                        ErrorMessage.InnerText = "Your account does not exist, Kindly create a new account ! ";
                        return false;
                    }
                    else if (userID == 0)  // Wrong password
                    {
                        ErrorMessage.InnerText = "Invalid password..!";
                        ViewState["FailCount"] = Convert.ToInt32(ViewState["FailCount"]) + 1;
                        if (Convert.ToInt32(ViewState["FailCount"]) >= 3)
                        {
                            //LockUser();
                            ErrorMessage.InnerText = "Your Account has been Locked. Please contact your administartor or reset your password..!";
                        }
                        txtpassword.Value = "";
                        return false;
                    }
                    else if (userID > 0) // Valid UserID and Password
                    {
                        int compID = Convert.ToInt32(dsLogin.Tables[0].Rows[0]["CompID"]);
                        bool active = Convert.ToBoolean(dsLogin.Tables[0].Rows[0]["Active"]);
                        bool userLock = Convert.ToBoolean(dsLogin.Tables[0].Rows[0]["UserLock"]);
                        bool resetPwd = Convert.ToBoolean(dsLogin.Tables[0].Rows[0]["ResetPwd"]);
                        string UserName = Convert.ToString(dsLogin.Tables[0].Rows[0]["UserName"]);
                        string IsClient = Convert.ToString(dsLogin.Tables[0].Rows[0]["IsClient"]);
                        DateTime validTil = Convert.ToDateTime(dsLogin.Tables[0].Rows[0]["ValidTil"]);

                        if (!active)
                        {
                            ErrorMessage.InnerText = "Your account has been In-actived. Kindly contact IT admin.";
                            return false;
                        }
                        else if (userLock)
                        {
                            ErrorMessage.InnerText = "Your account has been locked. Kindly reset your password";
                            return false;
                        }

                        if (resetPwd)
                            Session["resetpswd"] = "1";

                        TimeSpan ts = validTil - DateTime.Now;
                        if (active && !userLock && ts.TotalDays >= 0)
                        {
                            Session["UserID"] = userID;
                            Session["CompID"] = compID;
                            Session["UserName"] = UserName;
                            Session["IsClient"] = IsClient;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + SqlAccessHelper.ConnectionString.ToString());
                return false;
            }
            return false;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginName.Value.Trim() == "")
                {
                    ErrorMessage.InnerText = "Please enter your User Name !";
                }
                else if (txtpassword.Value.Trim() == "")
                {
                    ErrorMessage.InnerText = "Please enter your Password!";
                }
                else
                {
                    ErrorMessage.InnerText = string.Empty;
                    if (ValidateUser())
                    {
                        try
                        {
                            if (Convert.ToInt32(Session["UserID"]) <= 0)
                            {
                                Response.Redirect("Login.aspx");
                            }
                        }
                        catch (Exception ex)
                        {
                            Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                            Response.Redirect("Login.aspx");
                        }

                        //Application.Lock();
                        //Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
                        //Application.UnLock();

                        Response.Redirect("Default.aspx");
                        ErrorMessage.InnerText = "";
                    }
                    else
                    {
                        ErrorMessage.InnerText = "Login failed ! ";
                    }
                }
            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + SqlAccessHelper.ConnectionString.ToString());
            }


            
        }
    }
}