using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Data;

public partial class TimeSheet_User_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmpCode"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                _EmployeeDetails();
            }
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
