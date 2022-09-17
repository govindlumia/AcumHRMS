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
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

public partial class Leave_admin_pickapprover : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Request.QueryString["updated1"] != null)
            message.InnerHtml = "There is no leave profile for this employee"; 
        if (Request.QueryString["updated"] != null)
                message.InnerHtml = "Employee profile updated successfully";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
           // bindempdetail();
        }
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text.Trim();

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        //sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        //sqlparam[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        empgird.DataSource = ds;
        empgird.DataBind();
    }

//    public void bindempoloyee()
//    {
//        sqlstr = @"select distinct coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,tbl_leave_employee_leave_master.empcode,tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,
//        tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name                
//        from tbl_intranet_employee_jobDetails 
//        INNER JOIN tbl_intranet_designation on tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
//        INNER JOIN tbl_intranet_branch_detail on tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id
//        INNER JOIN tbl_leave_employee_leave_master on tbl_intranet_employee_jobDetails.empcode=tbl_leave_employee_leave_master.empcode";
       

//        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
//        empgird.DataSource = ds;
//        empgird.DataBind();
//    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        bindempdetail();
//        sqlstr = "";
//        sqlstr = @"select distinct coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,tbl_intranet_employee_jobDetails.empcode,tbl_leave_employee_leave_master.empcode,tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,
//        tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name                
//        from tbl_intranet_employee_jobDetails 
//        INNER JOIN tbl_intranet_designation on tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
//        INNER JOIN tbl_leave_employee_leave_master on tbl_intranet_employee_jobDetails.empcode=tbl_leave_employee_leave_master.empcode
//        INNER JOIN tbl_intranet_branch_detail on tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id WHERE 1=1";

//        if (txt_employee.Text != "")
//        {
//            sqlstr = sqlstr + " AND emp_fname like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%'";
//        }

//        if (dd_branch.SelectedIndex != 0)
//        {
//            sqlstr = sqlstr + " AND department_name = '" + dd_branch.SelectedItem.Text + "'";
//        }

//        if (dd_designation.SelectedIndex != 0)
//        {
//            sqlstr = sqlstr + " AND designationname ='" + dd_designation.SelectedItem.Text + "'";
//        }
//        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
//        empgird.DataSource = ds;
//        empgird.DataBind();
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("------ All ------", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("----- All -----", "0"));
        bindempdetail();
    }
    protected void empgird_RowEditing(object sender, GridViewEditEventArgs e)
    {
      
    }
    protected void empgird_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }
    protected void empgird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgird.PageIndex = e.NewPageIndex;
        bindempdetail(); 
    }
}
