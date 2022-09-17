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

public partial class payroll_admin_PayrollAdminTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmpCode"] != null)
            {
               
                    if (Session["EmpCode"].ToString() == "AEC-593")
                    {
                        //taxmasterAll.Visible = false;
                        taxmaster.Visible = true;
                    }
                    else
                    {
                       // taxmasterAll.Visible = true;
                        taxmaster.Visible = false;
                    }
              
                
               
            }
            else Response.Redirect("~/notlogged.aspx");
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