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
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.IO;
public partial class leave_report_employeeresign : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindempoloyee();
            FillControl();
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
        sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.degination_id,
tbl_DesignationMaster.designationname,
tbl_intranet_employee_jobDetails.category,tbl_category_master.CategoryName                
            from tbl_intranet_employee_jobDetails 
            INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id
            INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID WHERE tbl_intranet_employee_jobDetails.emp_status=10";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }



    protected void btn_search_Click(object sender, EventArgs e)
    {
        sqlstr = "";
        sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') +  ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
        tbl_intranet_employee_jobDetails.empcode as empcode,tbl_intranet_employee_jobDetails.degination_id,
        tbl_DesignationMaster.designationname,
        tbl_intranet_employee_jobDetails.category,tbl_category_master.CategoryName ,
        tbl_intranet_employee_jobDetails.emp_doleaving emp_doleaving               
        from tbl_intranet_employee_jobDetails 
        INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id 
        inner join tbl_login on tbl_intranet_employee_jobDetails.empcode=tbl_login.empcode 
        INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID WHERE tbl_intranet_employee_jobDetails.emp_status=10";

        if (txt_employee.Text != "")
        {
            sqlstr = sqlstr + " AND (emp_fname like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or empcode like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%')";
        }

        if (dd_branch.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND CategoryName = '" + dd_branch.SelectedItem.Text + "'";
        }

        if (dd_designation.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND designationname ='" + dd_designation.SelectedItem.Text + "'";
        }

        if ((txt_edate.Text.Trim() != "") && (txt_sdate.Text.Trim() != ""))
        {
            sqlstr = sqlstr + " AND convert(varchar,emp_doleaving,101) ='" + Utilities.Utility.DateTimeForat(txt_sdate.Text.Trim().ToString()) + "' and '" + Utilities.Utility.DateTimeForat(txt_edate.Text.Trim().ToString()) + "'";
        }
        if (ddl_cmpny.SelectedValue != "0")
        {
            sqlstr += " and tbl_login.companyid='" + ddl_cmpny.SelectedValue + "' ";
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
    protected void empgrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {

        //        sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
        //             tbl_intranet_employee_jobDetails.empcode,tbl_DesignationMaster.designationname,tbl_category_master.CategoryName                
        //            from tbl_intranet_employee_jobDetails 
        //            INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id
        //            INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID WHERE tbl_intranet_employee_jobDetails.emp_status=10";
        sqlstr = @"select tbl_intranet_employee_jobDetails.empcode as empcode,coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') +  ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
              tbl_DesignationMaster.designationname,
    tbl_category_master.CategoryName
                    
        from tbl_intranet_employee_jobDetails 
        INNER JOIN tbl_DesignationMaster on tbl_intranet_employee_jobDetails.degination_id=tbl_DesignationMaster.id 
        inner join tbl_login on tbl_intranet_employee_jobDetails.empcode=tbl_login.empcode 
        INNER JOIN tbl_category_master on tbl_intranet_employee_jobDetails.category=tbl_category_master.ID WHERE tbl_intranet_employee_jobDetails.emp_status=10";

        if (txt_employee.Text != "")
        {
            sqlstr = sqlstr + " AND (emp_fname like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or empcode like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%')";
        }

        if (dd_branch.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND CategoryName = '" + dd_branch.SelectedItem.Text + "'";
        }

        if (dd_designation.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " AND designationname ='" + dd_designation.SelectedItem.Text + "'";
        }

        if ((txt_edate.Text.Trim() != "") && (txt_sdate.Text.Trim() != ""))
        {
            sqlstr = sqlstr + " AND convert(varchar,emp_doleaving,101) ='" + Utilities.Utility.DateTimeForat(txt_sdate.Text.Trim().ToString()) + "' and '" + Utilities.Utility.DateTimeForat(txt_edate.Text.Trim().ToString()) + "'";
        }
        if (ddl_cmpny.SelectedValue != "0")
        {
            sqlstr += " and tbl_login.companyid='" + ddl_cmpny.SelectedValue + "' ";
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        MailScript scriptObj = new MailScript();
        scriptObj.exportToExcelInCustomized(ds.Tables[0], empgrid.HeaderRow, "Resigned Employee Report", Page.Form, "resignemprep");

    }
}
