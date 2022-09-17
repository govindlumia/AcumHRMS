using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Data;
using System.Configuration;
using HRMS.BusinessLogic.TimeSheet;


public partial class TimeSheet_User_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("../../Login.aspx");
        }
        if (!IsPostBack)
        {
            _EmployeeDetails();

        }
        confirmhr();
        confirmSupervisor();
        confirmAdmin();
    }


    protected void confirmhr()
    {
     string  sqlstr = "select count(employeecode) as hr from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and hr=1 and approverpriority=3";
     ReportsBussiness balObj = new ReportsBussiness();
        
        if (balObj.checkRight(sqlstr) > 0)
        {
            div_HC.Visible = true;
        }
        else
        {
            div_HC.Visible = false;
        }
    }

    protected void confirmSupervisor()
    {
      string  sqlstrSuperviser = "select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1 ";
      ReportsBussiness balObj = new ReportsBussiness();
        if (balObj.checkRight(sqlstrSuperviser) > 0)
        {

            manager.Visible = true;
        }
        else
        {
            manager.Visible = false;
        }
    }
    private void confirmAdmin()
    {
        string sqlstrAdmin = "select count(Id) from Tbl_TimeSheet_ProjectMaster where ProAdmin=" + Session["empcode"].ToString();
        ReportsBussiness balObj = new ReportsBussiness();
        if (balObj.checkRight(sqlstrAdmin) > 0)
        {

            div_admin.Visible = true;
        }
        else
        {
            div_admin.Visible = false;
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../../Login.aspx");
    }

    public void _EmployeeDetails()
    {
        EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
        EmpJobDetailBusiness ObjEmpJobDetailBusiness = new EmpJobDetailBusiness();

        ObjEmpJobDetailENT.Empcode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Degination_id = 0;
        ObjEmpJobDetailENT.Category_id = 0;
        ObjEmpJobDetailENT.Status = true;
        ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
        ObjEmpJobDetailENT.EmployeeCode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Emp_fname = "";

        DataSet ds = ObjEmpJobDetailBusiness.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
        }
    }
}
