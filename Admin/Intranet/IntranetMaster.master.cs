using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Company_CompanyMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblname.Text = Session["name"].ToString();
    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../../Login.aspx");
    }
}
