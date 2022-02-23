using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MarginCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                   
                }
            }
            catch (Exception ex)
            {
                Cus_Exception.Instance.HandleMe(this, ex, this.Page.Form.Name.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}