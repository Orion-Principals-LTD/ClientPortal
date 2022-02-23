using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HtmlGenericControl ctrl = new HtmlGenericControl("meta");
            ctrl.Attributes["http-equiv"] = "refresh";
            ctrl.Attributes["content"] = "180";
            this.Page.Header.Controls.Add(ctrl);
            if (!IsPostBack)
            {

                try
                {

                    if (Session["UserID"] == null)
                        Response.Redirect("~/Login.aspx");

                    LoadPage();
                    if (Session["clientID"] != null)
                    {
                        ddlClient.SelectedValue = Session["ClientID"].ToString();
                        LoadMargin();
                    }
                    else
                    {
                        ddlClient.SelectedIndex = 0;
                        LoadMargin();
                    }

                }
                catch (Exception ex)
                {
                    Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
            }
        }



        private DataSet LoadPage()
        {


            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(SqlAccessHelper.ConnectionString, CommandType.StoredProcedure, "sp_TRD_OPL_Margin_Client_Load");
            if (ds.Tables.Count != 0)
            {
                ddlClient.DataSource = ds.Tables[0];
                ddlClient.DataTextField = ds.Tables[0].Columns[1].ToString();
                ddlClient.DataValueField = ds.Tables[0].Columns[0].ToString();
                ddlClient.DataBind();

                ddlTicker_check.DataSource = ds.Tables[1];
                ddlTicker_check.DataTextField = ds.Tables[1].Columns[1].ToString();
                ddlTicker_check.DataValueField = ds.Tables[1].Columns[0].ToString();
                ddlTicker_check.DataBind();
            }

            lblClientName.Text = "Welcome ! " + Session["UserName"].ToString();

            return ds;

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Session["ClientID"] = ddlClient.SelectedValue.ToString();
                LoadMargin();
            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void LoadMargin()
        {


            DataSet ds = new DataSet();

            ds = GetDetails("-1", "0", "0", "0");

            if (ds.Tables[0].Rows.Count != 0)
            {
                double margin = Convert.ToDouble(ds.Tables[0].Rows[0]["Margin"]);
                double NAV = Convert.ToDouble(ds.Tables[0].Rows[0]["NAV"]);
                double Collateral = Convert.ToDouble(ds.Tables[0].Rows[0]["Collateral"]);

                lblMargin.Text = " Margin : " + margin.ToString();
                lblnav_colla.Text = " Collateral : " + Collateral.ToString() + "  NAV : " + NAV.ToString();
                lblMarginUpdtTime.Text = "Last Updated Time :   " + ds.Tables[0].Rows[0]["Updatetime"].ToString();

                if (margin >= 0 && margin <= 65.99)
                    lblMargin.BackColor = Color.Green;
                else if (margin >= 66.00 && margin <= 69.99)
                    lblMargin.BackColor = Color.OrangeRed;

                else if (margin >= 70.00)
                    lblMargin.BackColor = Color.Red;

            }
            else
            {
                lblMargin.Text = " Margin : 0.00";
                lblMargin.BackColor = Color.White;
            }

            if (ds.Tables[1].Rows.Count != 0)
            {
                GridView2.DataSource = ds.Tables[1];
                GridView2.DataBind();


            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            if (ds.Tables[2].Rows.Count != 0)
            {
                GridView3.DataSource = ds.Tables[2];
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();

            }



            if (ds.Tables[3].Rows.Count != 0)
                lblPostionLastUpDtTime.Text = "Last Updated Time :   " + ds.Tables[3].Rows[0][0].ToString();
            else
                lblPostionLastUpDtTime.Text = "";




        }

        private DataSet GetDetails(string tickerID, string Price, string Percent, string toUSD)
        {
            DataSet ds = new DataSet();
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@ClientID", SqlDbType.Int, 4);
            para[0].Value = Convert.ToInt32(ddlClient.SelectedValue);

            para[1] = new SqlParameter("@TickerID", SqlDbType.Int, 4);
            para[1].Value = Convert.ToInt32(tickerID);

            para[2] = new SqlParameter("@MarketPrice", SqlDbType.Decimal);
            para[2].Value = Convert.ToDecimal(Price);

            para[3] = new SqlParameter("@PercentUtilize", SqlDbType.Decimal);
            para[3].Value = Convert.ToDecimal(Percent);

            para[4] = new SqlParameter("@toUSD", SqlDbType.Decimal);
            para[4].Value = Convert.ToDecimal(toUSD);


            ds = SqlHelper.ExecuteDataset(SqlAccessHelper.ConnectionString, CommandType.StoredProcedure, "sp_TRD_OPL_MarginRisk_Realtime_IU", para);

            return ds;

        }

        protected void ddlTicker_check_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTicker_check.SelectedValue != "-1")
                    GetMarketPrice();
                else
                {
                    txtMarketPrice.Text = string.Empty;
                    txtToUSD.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void GetMarketPrice()
        {


            DataTable dt = new DataTable();

            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter("@UserID", SqlDbType.Int, 4);
            para[0].Value = Convert.ToInt32(Session["ClientID"]);

            para[1] = new SqlParameter("@CompID", SqlDbType.Int, 4);
            para[1].Value = Convert.ToInt32(Session["ClientID"]);

            para[2] = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            para[2].Value = Convert.ToInt32(Session["ClientID"]);

            para[3] = new SqlParameter("@TickerID", SqlDbType.Int, 4);
            para[3].Value = Convert.ToInt32(ddlTicker_check.SelectedValue);

            dt = SqlHelper.ExecuteDataTable(SqlAccessHelper.ConnectionString, CommandType.StoredProcedure, "sp_TRD_OPL_TickerMaster_GetTickerCom", para);
            if (dt.Rows.Count != 0)
            {
                txtMarketPrice.Text = dt.Rows[0][1].ToString();
                txtToUSD.Text = dt.Rows[0][2].ToString();

            }
        }



        protected void btnGetLatest_Click(object sender, EventArgs e)
        {

            try
            {
                if (Validation())
                {
                    DataSet ds = new DataSet();
                    ds = GetDetails(ddlTicker_check.SelectedValue, txtMarketPrice.Text, txtUtilization.Text, txtToUSD.Text);

                    if (ds.Tables[4].Rows.Count != 0)
                    {
                        gvLimit.DataSource = ds.Tables[4];
                        gvLimit.DataBind();
                    }
                    else
                    {
                        gvLimit.DataSource = null;
                        gvLimit.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {

                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private bool Validation()
        {
            if (txtMarketPrice.Text == string.Empty)
                return false;
            else if (txtUtilization.Text == string.Empty)
                return false;
            else if (txtToUSD.Text == string.Empty)
                return false;
            else
                return true;
        }
    }
}
