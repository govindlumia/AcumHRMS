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

public partial class Leave_admin_Lopreport : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_fyear();
            FillControl();
        }
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(ddlbranch, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void bindempdetail()
    {
      string sqlstr = @"select tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.emp_fname,tbl_payroll_employee_attendence.LWP from tbl_payroll_employee_attendence 
                          inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_attendence.EMPCODE=tbl_intranet_employee_jobDetails.empcode
                          where tbl_payroll_employee_attendence.MONTH='" + Ddlmonth.SelectedItem.Text + "' and tbl_payroll_employee_attendence.FYEAR='" + ddlyear.SelectedItem.Text + "' and  tbl_intranet_employee_jobDetails.branch_id=" + ddlbranch.SelectedValue + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        else
        {
            empgrid.DataSource = null;
            empgrid.DataBind();
        }
    }

   
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }
    protected void bind_fyear()
    {
        string sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        ddlyear.DataTextField = "year";
        ddlyear.DataValueField = "year";
        ddlyear.DataSource = ds;
        ddlyear.DataBind();
    }

   

   
    protected void empgrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bindempdetail();

    }
}