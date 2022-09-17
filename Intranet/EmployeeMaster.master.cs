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
using querystring;

public partial class Employee_EmployeeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] == null)
                Response.Redirect("~/notlogged.aspx");

                lblname.Text = Session["name"].ToString();
                lblnm.Text = Session["name"].ToString();
            if (!String.IsNullOrEmpty(Session["Photo"].ToString()))
            {
                imageProf.Src = "../UploadPhoto/" + Session["Photo"].ToString();
            }
            else
                {
                    imageProf.Src="../UploadPhoto/avatar_2x.png";
                }
        }
    }

      ////-------------------Clearing session which are created in -------------------------------------

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {       
        Session.RemoveAll();
        Response.Redirect("../Login.aspx");
    }

    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Main.aspx");
    }

//------------------------------------END OF PROGRAM---------------------------------------------

    protected void lblnm_DataBinding(object sender, EventArgs e)
    {

    }
    protected string encodeempcode()
    {

        query q = new query();
        string pairs = String.Format("empcode={0}", Session["empcode"].ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        //return "<script language='javascript'>window.open('reports/projectedtaxdetailview.aspx?q=" + encoded + "')</script>";
        return "<a class='link01' href='payroll/aadmin/reports/projectedtaxdetailview.aspx?q=" + encoded + "' target='_blank' title='Click here to view detail of projected income-tax of an employee'>View Details</a>";

    }
}