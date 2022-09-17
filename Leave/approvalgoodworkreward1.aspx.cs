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
using Utilities;
using System.Text;
public partial class leave_admin_approvalgoodworkreward1 : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }

    protected void bindgrid()
    {
        sqlstr = @"SELECT d.department_name deptname,o.empcode empcode,o.oddate oddate,o.noofhours noofhours,o.id id FROM
                tbl_payroll_goodwillreward_insert o INNER JOIN tbl_internate_departmentdetails d ON 
                 d.departmentid=o.dept_id WHERE o.status='0'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        goodworkgird.DataSource = ds;
        goodworkgird.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
        {
            btnapprove.Enabled = true;
            btnrejection.Enabled = true;
        }
        else
        {
            btnapprove.Enabled = false;
            btnrejection.Enabled = false;
        }
    }
    protected void goodworkgird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        goodworkgird.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void goodworkgird_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)goodworkgird.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_payroll_goodwillreward_insert WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }
    protected void goodworkgird_RowEditing(object sender, GridViewEditEventArgs e)
    {
        goodworkgird.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void goodworkgird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        decimal noofhours = Convert.ToDecimal(((TextBox)goodworkgird.Rows[e.RowIndex].Cells[4].Controls[1]).Text);
        int code = (int)goodworkgird.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_payroll_goodwillreward_insert SET noofhours='" + noofhours + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        goodworkgird.EditIndex = -1;
        bindgrid();
    }

    protected void bindapproval()
    {
        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < goodworkgird.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)goodworkgird.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                if (checkg.Checked)
                {
                    ViewState["checked"] = 1;
                    int strID = Convert.ToInt32(goodworkgird.DataKeys[i].Value);

                    string strUpdate = @"Update tbl_payroll_goodwillreward_insert set status='1' WHERE ID =" + strID + ";";
                    //append update statement in stringBuilder 
                    strSql.Append(strUpdate);
                }
            }
        }
        if (Convert.ToInt32(ViewState["checked"])==1)
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strSql.ToString());
        bindgrid();
    }

    protected void bindrejection()
    {
        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < goodworkgird.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)goodworkgird.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                if (checkg.Checked)
                {
                    ViewState["checked"] = 1;
                    int strID = Convert.ToInt32(goodworkgird.DataKeys[i].Value);

                    string strUpdate = @"Update tbl_payroll_goodwillreward_insert set status='2' WHERE ID =" + strID + ";";
                    //append update statement in stringBuilder 
                    strSql.Append(strUpdate);
                }
            }
        }
        if (Convert.ToInt32(ViewState["checked"]) == 1)
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strSql.ToString());
        bindgrid();
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        bindapproval();
    }
    protected void btnrejection_Click(object sender, EventArgs e)
    {
        bindrejection();
    }
    protected void goodworkgird_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        goodworkgird.EditIndex = -1;
        bindgrid();
    }
}
