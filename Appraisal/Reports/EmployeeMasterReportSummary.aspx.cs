using HRMS.BusinessEntity;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Reports_EmployeeMasterReportSummary : System.Web.UI.Page
{
    ReportsBAL objBAL;
    DataTable dt;
    ReportsEntity objEntity;
    DataSet ds;

    public Appraisal_Reports_EmployeeMasterReportSummary()
    {
        objBAL = new ReportsBAL();
        dt = new DataTable();
        objEntity = new ReportsEntity();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString.HasKeys())
            {
                string empCode = Request.QueryString["EmpCode"].ToString();
                bind_job_detail(empCode);
                BindData(empCode);
            }
            else
            {
                Response.Redirect("EmployeeMasterReport.aspx");
            }
        }
    }

    private void BindData(string empCode)
    {
        try
        {
            objEntity.EmployeeCode = empCode;
            dt = objBAL.EmployeeMasterReportSummary(objEntity);

            grdResult.DataSource = dt.Rows.Count > 0 ? dt : null;
            grdResult.DataBind();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
            EmpJobDetailENT userentity = new EmpJobDetailENT();
            //companyname	companyid	empcode	card_no	emp_gender	emp_fname	emp_m_name	emp_l_name	emp_status	employeestatus	Status	
            //degination_id	designationname	Job_type	DesgCode	category	CategoryName	HomeBU	HomeBUnit	SecondaryBU	SecondaryBUnit
            //photo	login_id	role1	role	emp_doj	salary_cal_from	emp_doleaving	emp_doreleiving
            userentity.Empcode = emp_code;
            ds = objSelectALL.SelectJobDetails(userentity);
            DataTable dt;
            dt = ds.Tables[0];

            if (dt.Rows.Count < 1)
                return;

            lbl_emp_name.Text = dt.Rows[0]["emp_fname"].ToString() + " " + Convert.ToString(dt.Rows[0]["emp_l_name"]);
            lbl_emp_code.Text = dt.Rows[0]["empcode"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["emp_doj"].ToString()))
            {
                lbl_dated.Text = Convert.ToDateTime(dt.Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            }
            else
            {
                lbl_dated.Text = "--NA--";
            }


            lbl_Designation.Text = dt.Rows[0]["designationname"].ToString();
            lbl_department.Text = dt.Rows[0]["CategoryName"].ToString();

            if (ds.Tables[1].Rows.Count > 0)
            {
                lblCE.Text = ds.Tables[1].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }


    }
}
