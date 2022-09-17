using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class leave_my_balance_leave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["empcode"] == null)
                hidd_empcode.Value = Session["empcode"].ToString();
            else
                hidd_empcode.Value = Request.QueryString["empcode"].ToString().Trim();
        }
    }
}
