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
public partial class leave_casualworkcaptureview : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
    }
    protected void bindgrid()
    {
if (Session["role"].ToString()=="3")
    sqlstr = @"SELECT d.departmentid as deptcode,d.department_name as deptname,h.id id,h.casualno casualno,h.noofhours noofhours,convert(varchar, h.casualdate,101) casualdate,h.id id FROM tbl_internate_departmentdetails d
                INNER JOIN tbl_leave_casual_work_capture h ON d.departmentid = h.dept_id 
                WHERE h.status='0' ";
else
        sqlstr = @"SELECT d.departmentid as deptcode,d.department_name as deptname,h.id id,h.casualno casualno,h.noofhours noofhours,convert(varchar, h.casualdate,101) casualdate,h.id id FROM tbl_internate_departmentdetails d
                INNER JOIN tbl_leave_casual_work_capture h ON d.departmentid = h.dept_id 
                WHERE h.status='0' and h.empcode='" + Session["empcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        casualgrid.DataSource = ds;
        casualgrid.DataBind();
    }
    protected void casualgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        casualgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void casualgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)casualgrid.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_leave_casual_work_capture WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }
    protected void casualgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        casualgrid.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void casualgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int casualno = Convert.ToInt32(((TextBox)casualgrid.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
        decimal noofhours = Convert.ToDecimal(((TextBox)casualgrid.Rows[e.RowIndex].Cells[2].Controls[1]).Text);
        int code = (int)casualgrid.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_leave_casual_work_capture SET casualno=" + casualno + ", noofhours='" + noofhours + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        casualgrid.EditIndex = -1;
        bindgrid();
    }
    protected void casualgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        casualgrid.EditIndex = -1;
        bindgrid();
    }
}