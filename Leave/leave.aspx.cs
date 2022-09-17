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
using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class leave1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ApplyLeaveStatus"] = 1;
            if (Request.QueryString["status"] != null)
            {
                Session["StatusApproval"] = "0";
            }

            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            _EmployeeDetails();
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Login.aspx");
    }
    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Login.aspx");
    }

    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }

    public void _EmployeeDetails()
    {
        EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
        EmpJobDetailBusiness ObjEmpJobDetailBusiness = new EmpJobDetailBusiness();

        ObjEmpJobDetailENT.Empcode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Degination_id = 0;
        ObjEmpJobDetailENT.Category_id = 0;
        ObjEmpJobDetailENT.Status = true;
        //ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
        ObjEmpJobDetailENT.EmployeeCode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Emp_fname = "";

        DataSet ds = ObjEmpJobDetailBusiness.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            //lblNameA.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            //lblDept.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            //lblDesig.Text = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
        }
    }
}
