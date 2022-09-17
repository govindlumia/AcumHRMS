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
using System.Net.Mail;
using Utilities;

public partial class leave_approve_od : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
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
        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
       // HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
        {
            lbl_doj.Text = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
        }
    }

    protected void bind_od_detail()
    {
        string str = @"select tbl_leave_apply_od.id,tbl_leave_apply_od.empcode,convert(varchar,tbl_leave_apply_od.date,101)date,convert(varchar,tbl_leave_apply_od.fromtime,101)fromtime,tbl_leave_apply_od.reason,tbl_leave_apply_od.working_hour,tbl_leave_apply_od.comment,tbl_leave_apply_od.Leave_status  
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

    protected void btn_approve_Click(object sender, EventArgs e)
    {        
        SqlParameter[] sqlparm = new SqlParameter[4];

        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value=Request.QueryString["id"].ToString();

        sqlparm[1] = new SqlParameter("@comment", SqlDbType.VarChar,500);
        if (txt_comment.Text!="")            
             sqlparm[1].Value="<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
             sqlparm[1].Value = "";
           
        sqlparm[2] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[2].Value=1;

        sqlparm[3] = new SqlParameter("@Approval_status", SqlDbType.Int, 4);
        sqlparm[3].Value = 1;

        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,comment=comment + @comment,Approval_status=@Approval_status where id=@id";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1, sqlparm);

        updatebackmonth();

        //string str2 = "update tbl_payroll_employee_attendence_detail set mode='P' where id=@id";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str2, sqlparm);
                
        bind_od_detail();
        Response.Redirect("view_approverod.aspx?updated=true");
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["id"].ToString();

        sqlparm[1] = new SqlParameter("@comment", SqlDbType.VarChar, 500);
        if (txt_comment.Text != "")

            sqlparm[1].Value = "<h6><b>Comment added by " + Session["empcode"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[1].Value = "";

        sqlparm[2] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[2].Value = 3;

        sqlparm[3] = new SqlParameter("@Approval_status", SqlDbType.Int, 4);
        sqlparm[3].Value = 0;
        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,comment=comment + @comment,Approval_status=@Approval_status where id=@id";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1, sqlparm);
        bind_od_detail();
        Response.Redirect("view_approverod.aspx?updated=true");
     }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["id"].ToString();

        sqlparm[1] = new SqlParameter("@comment", SqlDbType.VarChar, 500);
        if (txt_comment.Text != "")

            sqlparm[1].Value = "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[1].Value = "";

        sqlparm[2] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[2].Value = 4;

        sqlparm[3] = new SqlParameter("@Approval_status", SqlDbType.Int, 4);
        sqlparm[3].Value = 0;

        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,comment=comment + @comment,Approval_status=@Approval_status where id=@id";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1, sqlparm);
        bind_od_detail();
        Response.Redirect("view_approverod.aspx?updated=true");
    }    

    protected void updatebackmonth()
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode;
        string empcode;
        DataSet ds2, ds3;
        string str1 = "SELECT empcode, date, fromtime FROM tbl_leave_apply_od WHERE id=" + Request.QueryString["id"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromtime"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();

            if (fromdate.Month != DateTime.Now.Month)
            {
                string str2 = "SELECT empshiftcode FROM tbl_leave_dutyroster WHERE empcode='" + empcode + "' and date='" + fromdate + "'";
                ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    empshiftcode = Convert.ToInt32(ds2.Tables[0].Rows[0]["empshiftcode"]);

                    string str3 = "SELECT starttime,endtime FROM tbl_leave_shift WHERE shiftid=" + empshiftcode;
                    ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str3);

                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        intime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["starttime"]);
                        outtime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["endtime"]);

                        string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='P', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str4);
                    }
                }
            }
        }
    }
}
