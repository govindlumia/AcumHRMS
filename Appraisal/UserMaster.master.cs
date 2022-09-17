using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_UserMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            _EmployeeDetails();
            ConfirmSupervisor();
            ConfirmReviewer();
            ConfirmManagement();
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

    private void ConfirmSupervisor()
    {
        String sqlstrSuperviser = "declare @count int set @count = (select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1) set @count += (select count(*) from KRAFormDetail where ISNULL(IsPeerManager,0)=1 and Peer='" + Session["empcode"].ToString() + "') select @count";
        //String sqlstrSuperviser = "select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1 ";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser)) > 0)
        {

            managerServices.Visible = true;
        }
        else
        {
            managerServices.Visible = false;
        }
    }

    private void ConfirmReviewer()
    {
        String sqlstrReviewer = "declare @count int set @count = (select count(*) from AppraisalRoleUserMapping where EmpCode='" + Session["empcode"].ToString() + "' and IsActive=1 and RoleId=1) set @count += (select count(*) from KRAFormApprovalHierarchy where ApproverCode='" + Session["empcode"].ToString() + "' and LevelId=2) select @count";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrReviewer)) > 0)
        {

            reviewerServices.Visible = true;
        }
        else
        {
            reviewerServices.Visible = false;
        }
    }

    private void ConfirmManagement()
    {
        String sqlstrManagement = "select count(*) from AppraisalRoleUserMapping where EmpCode='" + Session["empcode"].ToString() + "' and IsActive=1 and RoleId=2";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrManagement)) > 0)
        {

            managementServices.Visible = true;
        }
        else
        {
            managementServices.Visible = false;
        }
    }
}
