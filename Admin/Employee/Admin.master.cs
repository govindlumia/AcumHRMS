using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Company_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "1" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");
        lblname.Text = Session["EmpName"].ToString();

    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../../Login.aspx");
    }

    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Main.aspx");
    }
}
