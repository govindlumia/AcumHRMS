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

public partial class Authenticate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       Page.RegisterStartupScript("Pop", "<script> javascript:window.open('Login.aspx','_top','')</script>");
    }

}
