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
using HRMS.BusinessLogic;
using HRMS.BusinessEntity;

public partial class payroll_admin_payrolladmin : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
       // CheckSeeionA();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Response.Redirect("~/Main.aspx", true);  // to be removed
        ODRequestBusiness objOD = new ODRequestBusiness();
        ODRequestENT entityOD=new ODRequestENT ();
        if (Session["EmpCode"] == null)
        {
            string str = Server.UrlEncode(Convert.ToString(Request.Url));
            Response.Redirect("~/Login.aspx");
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        if (!IsPostBack)
        {
            if (Session["EmpCode"] != null)
            {
                entityOD.EmpCode=Session["EmpCode"].ToString();
                lblname.Text = Session["EmpName"].ToString();
             //   string res = objOD.SelectIsPayrollUser(entityOD);
                //if (Session["EmpCode"].ToString() == "AEC-2473" || Session["EmpCode"].ToString() == "AEC-743" || Session["EmpCode"].ToString() == "AEC-2653" || Session["EmpCode"].ToString() == "AEC-328" || Session["EmpCode"].ToString() == "AEC-99999" || Session["EmpCode"].ToString() == "AEC-3898" || Session["EmpCode"].ToString() == "DE-0001")
                //{ }
                //if (Convert.ToInt16(res) == 1)
                //{ }

                //Response.Redirect("~/Authenticate.aspx");
                //else
                //{
                //    Response.Redirect("~/Admin/Home.aspx");
                //}
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
        ////string companyID = Session["companyImageID"].ToString();
        //Session.Clear();


        ////Session["companyImageID"] = companyID;
        //Response.Redirect("~/Login.aspx");

        Session.Abandon();
        Session["EmpCode"] = null;
        Session["ACheck"] = null;
        Response.Redirect("~/Login.aspx", false);
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
    private void CheckSeeionA()
    {
        if (Session["ACheck"] == null)
        {
            Session["ACheck"] = true;
        }

        if (Session["EmpCode"] == null)
        {
            string str = Server.UrlEncode(Convert.ToString(Request.Url));
            Response.Redirect("~/Login.aspx");
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        if (Session["ACheck"].ToString() != Session["EmpCode"].ToString())
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
    }
}
