using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
public partial class leave_view_approvedod_details : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string comment;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_empdetail();
            bind_od_detail();
        }
    }
    protected void bind_empdetail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Request.QueryString["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();
    }
    protected void bind_od_detail()
    {
        string str = @"select tbl_leave_apply_od.id, tbl_leave_apply_od.empcode, convert(varchar,date,101)date,convert(varchar,fromtime,101)fromtime,tbl_leave_apply_od.reason, tbl_leave_apply_od.working_hour,tbl_leave_apply_od.comment  
        from tbl_leave_apply_od where id='" + Request.QueryString["id"] + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str);
        int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
        ViewState["id"] = id;
        lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
        lbl_ftime.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
        lbl_date.Text = ds.Tables[0].Rows[0]["date"].ToString();
        lbl_whour.Text = ds.Tables[0].Rows[0]["working_hour"].ToString();
        lbl_comment.Text = ds.Tables[0].Rows[0]["comment"].ToString();

    }

}
