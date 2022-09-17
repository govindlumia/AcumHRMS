using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Security.Cryptography;
using Utilities;

public partial class admin_AuditTrailView : System.Web.UI.Page
{
    DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ReadEmployee();
    }
    public void AllAudit(string fDate,string toDate,string empCode)
    {
        ds = new DataSet();
        SqlParameter[] sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@IN_From_Date", SqlDbType.VarChar, 50);
        sqlparam[0].Value = fDate;
        sqlparam[1] = new SqlParameter("@IN_To_Date", SqlDbType.VarChar, 50);
        sqlparam[1].Value = toDate;
        sqlparam[2] = new SqlParameter("@IN_Emp_Code", SqlDbType.VarChar, 50);
        sqlparam[2].Value = empCode;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Read_Audit_Trail", sqlparam);
        ddlAudit.DataSource = ds;
        ddlAudit.DataBind();
        if (ds.Tables[0].Rows.Count==0)
            General.Alert("No Record(s) Found", btnSearch);
    }

    public void ReadEmployee()
    {
        ds = new DataSet();
        //string sqlstr = "SELECT DISTINCT u.empcode,u.empcode + ' - ' + j.emp_fname +' '+ j.emp_m_name +' ' + j.emp_l_name AS EmpName FROM updateRecord u INNER JOIN tbl_intranet_employee_jobDetails j ON j.empcode=u.empcode";
        string sqlstr = "Select empcode,emp_fname +' '+ emp_m_name +' ' + emp_l_name as EmpName from tbl_intranet_employee_jobDetails j where empcode like 'AEC%' Order by EmpName";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlEmployee.DataSource = ds;
        ddlEmployee.DataTextField = "EmpName";
        ddlEmployee.DataValueField = "empcode";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        string fromDate = string.Empty;
        string toDate = string.Empty;
        string empCode = string.Empty;
        if (!string.IsNullOrEmpty(txtFromDate.Text.Trim()) && !string.IsNullOrEmpty(txtToDate.Text.Trim()))
        {
            if (Convert.ToDateTime(txtFromDate.Text.Trim()) > Convert.ToDateTime(txtToDate.Text.Trim()))
            {
                General.Alert("To Date must be greater than to From Date", btnSearch);
                return;
            }
            fromDate = txtFromDate.Text.Trim();
            toDate = txtToDate.Text.Trim();
        }
        if (!string.IsNullOrEmpty(txtToDate.Text.Trim()) && string.IsNullOrEmpty(txtToDate.Text.Trim()))
        {
            fromDate = txtFromDate.Text.Trim();
            toDate = fromDate;
        }
        if (string.IsNullOrEmpty(txtToDate.Text.Trim()) && !string.IsNullOrEmpty(txtToDate.Text.Trim()))
        {
            toDate = txtToDate.Text.Trim();
            fromDate = toDate;
        }
        if (ddlEmployee.SelectedIndex > 0)
            empCode = ddlEmployee.SelectedValue;

        if ((string.IsNullOrEmpty(txtFromDate.Text.Trim())) && (string.IsNullOrEmpty(txtToDate.Text.Trim())) && ddlEmployee.SelectedIndex == 0)
            General.Alert("Please provide at lease one value to search  the record(s)", btnSearch);
        else
            AllAudit(fromDate, toDate, empCode);
    }
}