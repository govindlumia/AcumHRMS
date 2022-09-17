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
public partial class leave_viewapprovecompoff : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_requested_compoff();
        }
    }

    protected void leave_approval_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reject")
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            sqlstr = "update tbl_leave_approve_compoff set approval_status='2' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            message.InnerHtml = "Comp-off attendance request rejected successfully";
        }
        if (e.CommandName == "accept")
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            sqlstr = "update tbl_leave_approve_compoff set approval_status='1' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            insert_attendance_employee_compoff_table(eid);
        }
        bind_requested_compoff();
    }

    protected void insert_attendance_employee_compoff_table(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value =Convert.ToInt32(id);

        int y = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_insert_marked_compoff_attendance_approved]", sqlparam);

        if (y > 0)
        {
            message.InnerHtml = "Comp-off mark request accepted successfully";
        }
        else
            message.InnerHtml = "There is some problem, please try again";
    } 
   
    protected void bind_requested_compoff()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 20);
        sqlparam[0].Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_compoff_attendance_request", sqlparam);
        leave_approval_grid.DataSource = ds;
        leave_approval_grid.DataBind();
    }
}
