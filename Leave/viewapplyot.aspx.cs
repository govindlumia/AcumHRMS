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
public partial class leave_viewapplyot : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
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
            bindapplyot();
        }
    }
    protected void bindapplyot()
    {
        if (Session["role"].ToString() == "3")
            sqlstr = "SELECT id,dep_id,convert(varchar(11),date,101) date,total_hours,status FROM tbl_leave_dep_overtime WHERE status='0'";
        else
            sqlstr = "SELECT id,dep_id,convert(varchar(11),date,101) date,total_hours,status FROM tbl_leave_dep_overtime WHERE status='0' and empcode='" + Session["empcode"].ToString() + "'";
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        applyotgrid.DataSource = ds;
        applyotgrid.DataBind();
    }
    protected void applyotgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        applyotgrid.PageIndex = e.NewPageIndex;
        bindapplyot();
    }
    protected void applyotgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)applyotgrid.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_leave_dep_overtime WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindapplyot();
    }
    protected void applyotgrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            int id = (int)applyotgrid.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            ViewState["id"] = id;
            bindapplyotdetail();
            divot.Visible = true;
            bindapplyot();
        }
    }
    protected void bindapplyotdetail()
    {
        sqlstr = @"SELECT id,dep_ot_id,job.empcode,noofhour,convert(varchar(11),date,101)date ,
                    coalesce(emp_fname,'')+' '+coalesce(emp_m_name,'')+' '+coalesce(emp_l_name,'') name
                    FROM tbl_leave_employee_overtime ot
                    inner join tbl_intranet_employee_jobDetails job
                    on ot.empcode=job.empcode
                    WHERE dep_ot_id=" + Convert.ToInt32(ViewState["id"]) + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        applyotviewgrid.DataSource = ds;
        applyotviewgrid.DataBind();
    }
    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        divot.Visible = false;
    }
    protected void applyotviewgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        applyotviewgrid.PageIndex = e.NewPageIndex;
        bindapplyotdetail();
    }
    protected void applyotviewgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)applyotviewgrid.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_leave_employee_overtime WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindapplyotdetail();
        updateapplyot();
    }
    protected void applyotviewgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        decimal noofhours = Convert.ToDecimal(((TextBox)applyotviewgrid.Rows[e.RowIndex].Cells[2].Controls[1]).Text);
        int code = (int)applyotviewgrid.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_leave_employee_overtime SET noofhour='" + noofhours + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        applyotviewgrid.EditIndex = -1;
        bindapplyotdetail();
        updateapplyot();
    }
    protected void updateapplyot()
    {
        sqlstr = @"update tbl_leave_dep_overtime
                    set total_hours=(select sum(noofhour) from tbl_leave_employee_overtime where dep_ot_id=" + Convert.ToInt32(ViewState["id"]) + ") where id=" + Convert.ToInt32(ViewState["id"]) + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindapplyot();
    }
    protected void applyotviewgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        applyotviewgrid.EditIndex = -1;
        bindapplyotdetail();
    }
    protected void applyotviewgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        applyotviewgrid.EditIndex = e.NewEditIndex;
        bindapplyotdetail();
    }
}
