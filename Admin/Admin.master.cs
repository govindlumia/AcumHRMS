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
            if (!(Session["Role"].ToString().Trim() == "2" || (Session["Role"].ToString().Trim() == "3") || Session["Role"].ToString().Trim() == "1" || Session["Role"].ToString().Trim() == "4"))
                Response.Redirect("~/Authenticate.aspx");               
        }
        else
            Response.Redirect("~/notlogged.aspx");
            lblname.Text = Session["EmpName"].ToString();
    }



    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
         Session.RemoveAll();
         Response.Redirect("../Login.aspx"); 
    }
}
