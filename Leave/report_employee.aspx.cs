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
using DataAccessLayer;
using HRMS.BusinessLogic;

public partial class leave_report_employee : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            FillControl();
            bindempoloyee();
        }
    }


    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(dd_branch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(dd_designation, commonBusiness.BindDropDowns("", "Designation"), "id", "designationname");
        BindDropDowns(ddl_cmpny, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    public void bindempoloyee()
    {
        sqlstr = @"select distinct 
                   coalesce(tbl_intranet_employee_jobDetails.emp_fname,'')  + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
                   tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.degination_id,
                    tbl_DesignationMaster.designationname,
                   tbl_intranet_employee_jobDetails.category,tbl_category_master.CategoryName                
                   from tbl_intranet_employee_jobDetails 
                   inner join tbl_Employee_Hierarchy eh on eh.approverid=tbl_intranet_employee_jobDetails.empcode
                   INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id
                   INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID where tbl_intranet_employee_jobDetails.emp_status not in (10,11,12)";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    

    protected void btn_search_Click(object sender, EventArgs e)
    {
        sqlstr = "";
        sqlstr = @"select distinct 
                   coalesce(tbl_intranet_employee_jobDetails.emp_fname,'')  + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
                   tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.degination_id,
                    tbl_DesignationMaster.designationname,
                   tbl_intranet_employee_jobDetails.category,tbl_category_master.CategoryName                
                   from tbl_intranet_employee_jobDetails 
inner join tbl_login on tbl_login.empcode=tbl_intranet_employee_jobDetails.empcode
                   inner join tbl_Employee_Hierarchy eh on eh.approverid=tbl_intranet_employee_jobDetails.empcode
                   INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id
                   INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID WHERE 1=1 and tbl_intranet_employee_jobDetails.emp_status not in (10,11,12) ";

        if (txt_employee.Text != "")
        {
            sqlstr = sqlstr + " AND (emp_fname like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or  emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or tbl_intranet_employee_jobDetails.empcode like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or  emp_fname + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%') ";
        }

        if (dd_branch.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND CategoryName = '" + dd_branch.SelectedItem.Text + "'";
        }

        if (dd_designation.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND designationname ='" + dd_designation.SelectedItem.Text + "'";
        } if (ddl_cmpny.SelectedValue != "0")
        {
            sqlstr += " and tbl_login.companyid='"+ddl_cmpny.SelectedValue+"' ";
        }
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        empgrid.DataSource = ds;
        empgrid.DataBind();      
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempoloyee();
    }
}
