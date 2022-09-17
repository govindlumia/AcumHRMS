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

public partial class suggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["view"] == "1")
                frame1.Attributes["src"] = "suggestionpost.aspx?view=1";

            if (Request.QueryString["view"] == "2")
                frame1.Attributes["src"] = "suggestionview.aspx?view=2";
        }
    }
}
