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

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["id"] == "2")
                frame1.Attributes["src"] = "changepassword.aspx";
         
             if (Request.QueryString["id"] == "3")
                frame1.Attributes["src"] = "leave/mydutyroster.aspx";

            if (Request.QueryString["id"] == "4")
                frame1.Attributes["src"] = "leave/holidaylist.aspx";
        }
    }
}
