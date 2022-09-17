using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_EmployeeDetail : System.Web.UI.UserControl
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string empCode = Convert.ToString(Session["UserEmpCode"]);

            if (!string.IsNullOrEmpty(empCode))
                bind_job_detail(empCode);
            else
                bind_job_detail(Convert.ToString(Session["EmpCode"]));
        }
        
    }

    public string Test
    {
        get;
        set;

    }
    public Label LblEmpCode
    {
        get
        {
            return lbl_emp_code;
        }
        set
        {
            lbl_emp_code = value;
        }
    }
    protected void bind_job_detail(string emp_code)
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
            lblExp.Text = ds.Tables[1].Rows[0][0].ToString();
        }

    }
}