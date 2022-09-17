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

public partial class leave_admin_leaveadmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3" && Session["role"].ToString() != "2")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
            lblname.Text = Session["name"].ToString();
            if (Session["companyImageID"] != null)
            {
                imageDynamic.Src = "~/slogo/" + Session["companyImageID"].ToString() + ".jpg";
            }
        }
    }
    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
        //string companyID = Session["companyImageID"].ToString();
        Session.Clear();


        //Session["companyImageID"] = companyID;
        Response.Redirect("~/Login.aspx");
    }
}
