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

public partial class RecruitmentMaster : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();

            lblName.Text = Convert.ToString(Session["EmpName"]);
            _EmployeeDetails();

            VacReqCreator.HRef = "ViewVacRequest.aspx?Type=C";
            VacReqApprover.HRef = "ViewVacRequest.aspx?Type=A";
            VacReqHRHead.HRef = "ViewVacRequest.aspx?Type=HRH";
            VacReqCOO.HRef = "ViewVacRequest.aspx?Type=O";
            VacReqHRExecutive.HRef = "ViewVacRequest.aspx?Type=HRE";

            CanReqCreator.HRef = "ViewCanRequest.aspx?Type=C";
            CanReqHRExcutive.HRef = "ViewCanRequest.aspx?Type=HRE";
            CanReqEmployee.HRef = "ViewCanRequest.aspx?Type=EMP";
            CanReqCOO.HRef = "ViewCanRequest.aspx?Type=COO";

            CanCreateRound.HRef = "CanCreateRound.aspx?E=False";

            _EnableDisable();

            _IsRM_HR();
            _IsHC();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    public void _EnableDisable()
    {
        if (string.Compare(Session["Role"].ToString(), "5") == 0) /// if user is COO 
        {
            DivCOO.Visible = true;
        }
        else
        {
            DivCOO.Visible = false;
        }
        if (string.Compare(Session["Role"].ToString(), "3") == 0) /// if user is HR Head 
        {
            DivHRHead.Visible = true;
        }
        else
        {
            DivHRHead.Visible = false;
        }
    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/Login.aspx");
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

        ds = ObjEmpJobDetailBusiness.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            lblNameA.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            lblDept.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            lblDesig.Text = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
        }
    }

    protected void _IsRM_HR()
    {
        string sqlstr = "Select count(*) APPROVERID FROM TBL_EMPLOYEE_HIERARCHY WHERE EMPLOYEECODE = '" + Session["empcode"].ToString() + "'  and APPROVERPRIORITY = 1 ";
        string sqlstr1 = "Select count(*) APPROVERID FROM TBL_EMPLOYEE_HIERARCHY WHERE EMPLOYEECODE = '" + Session["empcode"].ToString() + "'  and HR = 1  ";
        
        ReportsBussiness balObj = new ReportsBussiness();

        if (balObj.checkRight(sqlstr) > 0 && balObj.checkRight(sqlstr1) > 0)
        {
            dvMyActivities.Visible = true;
        }
        else
        {
            dvMyActivities.Visible = false;
        }
    }

    protected void _IsHC()
    {
        string sqlstr = "select count(*) approverid from tbl_Employee_Hierarchy where hr = 1 and approverpriority = 3 and approverid = '" + Session["empcode"].ToString() + "' ";

        ReportsBussiness balObj = new ReportsBussiness();

        if (balObj.checkRight(sqlstr) > 0)
        {
            DivHR.Visible = true;
        }
        else
        {
            DivHR.Visible = false;
        }
    }
}
