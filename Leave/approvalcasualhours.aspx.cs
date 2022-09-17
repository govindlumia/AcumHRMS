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
public partial class leave_admin_approvalcasualhours : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
    }

    protected void bindgrid()
    {
        sqlstr = @"SELECT d.departmentid as deptcode,d.department_name as deptname,h.id id,h.casualno casualno,h.noofhours noofhours,convert(varchar, h.casualdate,101) casualdate,h.id id FROM tbl_internate_departmentdetails d
                INNER JOIN tbl_leave_casual_work_capture h ON d.departmentid = h.dept_id 
                WHERE h.status='0'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        casualhrgird.DataSource = ds;
        casualhrgird.DataBind();

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

    protected void casualhrgird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        casualhrgird.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void casualhrgird_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)casualhrgird.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_leave_casual_work_capture WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    protected void casualhrgird_RowEditing(object sender, GridViewEditEventArgs e)
    {
        casualhrgird.EditIndex = e.NewEditIndex;
        bindgrid();
    }

    protected void casualhrgird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int casualno = Convert.ToInt32(((TextBox)casualhrgird.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
        decimal noofhours = Convert.ToDecimal(((TextBox)casualhrgird.Rows[e.RowIndex].Cells[4].Controls[1]).Text);
        int code = (int)casualhrgird.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_leave_casual_work_capture SET casualno=" + casualno + ", noofhours='" + noofhours + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        casualhrgird.EditIndex = -1;
        bindgrid();
    }

    protected void bindapproval()
    {
        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < casualhrgird.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)casualhrgird.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                if (checkg.Checked)
                {
                    ViewState["checked"] = 1;
                    int strID = Convert.ToInt32(casualhrgird.DataKeys[i].Value);

                    string strUpdate = @"Update tbl_leave_casual_work_capture set status='1' WHERE ID =" + strID + ";";
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
    protected void casualhrgird_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        casualhrgird.EditIndex = -1;
        bindgrid();
    }
    protected void btnrejection_Click(object sender, EventArgs e)
    {
        bindrejection();
    }
    protected void bindrejection()
    {
        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < casualhrgird.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)casualhrgird.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                if (checkg.Checked)
                {
                    ViewState["checked"] = 1;
                    int strID = Convert.ToInt32(casualhrgird.DataKeys[i].Value);

                    string strUpdate = @"Update tbl_leave_casual_work_capture set status='2' WHERE ID =" + strID + ";";
                    //append update statement in stringBuilder 
                    strSql.Append(strUpdate);
                }
            }
        }
        if (Convert.ToInt32(ViewState["checked"]) == 1)
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strSql.ToString());
        bindgrid();
    }
}
