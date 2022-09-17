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
using System.Data.SqlClient;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class general : System.Web.UI.MasterPage
{
    DataSet ds;
    string sqlstr;

    //-----------------------------ON PAGE LOAD-------------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            _EmployeeDetails();

           
          
            
        }
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
            //lblNameA.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            //lblDept.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            //lblDesig.Text = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
        }
    }

    //------------------------LOGOUT FROM INTRANET--------------------------------------------------------

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../Login.aspx");
    }

}
//---------------------------------------END OF PROGRAM-------------------------------------------------------