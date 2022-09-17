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
using Utilities;
using System.Data.SqlClient;
public partial class leave_admin_manhourreport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindgrid()
    {
        sqlstr = @"select deptname,sum((case when empattendance.mode='P' then 8 else 0 end)) employeeworkhours, othour, casualhr,deptid
	               from
	               (
		                select department_name deptname,isnull(sum(depot.total_hours),0) othour,noofhours casualhr,departmentid deptid
			            from 
			            (
				            select dept.department_name,isnull(sum(casual.noofhours),0) noofhours,dept.departmentid
				            from tbl_leave_casual_work_capture casual
				            right outer join tbl_internate_departmentdetails dept 
				            on casual.dept_id=dept.departmentid
				            --where casual.status='1'
				            group by dept.department_name,dept.departmentid
			            ) casual1
			            left outer join tbl_leave_dep_overtime depot
			            on casual1.departmentid=depot.dep_id
			            --where depot.status='1'
			            group by department_name,departmentid,noofhours
	                ) ot_casual
	            left outer join tbl_intranet_employee_jobDetails empjobdetails
	            on ot_casual.deptid=empjobdetails.dept_id
	            left outer join tbl_payroll_employee_attendence_detail empattendance
	            on empattendance.empcode=empjobdetails.empcode 
                group by deptname,othour,casualhr,deptid ";
        if (dd_dept.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " having deptid='" + dd_dept.SelectedValue + "'";
        }
        //having deptid='" + dd_dept.SelectedValue + "'
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        attendancegrid.DataSource = ds;
        attendancegrid.DataBind();
    }
    protected void attendancegrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
        }
    }
    protected void attendancegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        attendancegrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
        dd_dept.Items.Insert(0, new ListItem("All", "0"));
    }
}
