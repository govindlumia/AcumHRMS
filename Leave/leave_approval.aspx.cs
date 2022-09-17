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
using DataAccessLayer;
using querystring;
using System.Data.SqlClient;

public partial class leave_leave_approval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }

        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("leavestatus", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        helper.ApplyGroupSort();


        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }

        bind_requested_compoff();

    }


    protected string linkleaveCompOff(string empcode, string leavename, int id, string leavestatus)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (leavestatus != "Pending with Branch HR")
            return "<a href='viewcompoff_approver.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

        else
            return "<a href='viewcompoff_hr.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    }



    protected void leave_approval_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reject")
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            string sqlstr = "update tbl_leave_approve_compoff set approval_status='2' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            message.InnerHtml = "Comp-off attendance request rejected successfully";
        }
        if (e.CommandName == "accept")
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            string sqlstr = "update tbl_leave_approve_compoff set approval_status='1' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            insert_attendance_employee_compoff_table(eid);
        }
        bind_requested_compoff();
    }

    protected void insert_attendance_employee_compoff_table(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = Convert.ToInt32(id);

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
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_compoff_attendance_request", sqlparam);
        grdApproveRejectCompOff.DataSource = ds;
        grdApproveRejectCompOff.DataBind();
    }

    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "leavestatus")
        {
            //row.CssClass = "frm-rght-clr123";
            //row.HorizontalAlign = HorizontalAlign.Left;
            //row.Cells[0].Text = "&nbsp;&nbsp; Status : " + row.Cells[0].Text;
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }

    protected string linkleave(string empcode, string leavename, int id, string leavestatus)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (leavestatus != "Pending with Branch HR")
            return "<a href='viewleave_approver.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

        else
            return "<a href='viewleave_hr.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    }

    //protected string linkleaveCompOff(string empcode, string leavename, int id, string leavestatus)
    //{
    //    query q = new query();
    //    string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
    //    string encoded;
    //    encoded = q.EncodePairs(pairs);
    //    if (leavestatus != "Pending with Branch HR")
    //        return "<a href='viewcompoff_approver.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

    //    else
    //        return "<a href='viewcompoff_hr.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    //}

    protected void leave_approval_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_fromdate = (Label)e.Row.FindControl("l5");
            if(lbl_fromdate!=null)
            {
            if (!string.IsNullOrEmpty(lbl_fromdate.Text))
            {
                lbl_fromdate.Text = Convert.ToDateTime(lbl_fromdate.Text).ToString("dd-MMM-yyyy");
            }
            }
            Label lbl_todate = (Label)e.Row.FindControl("l6");
            if (lbl_todate != null)
            {
                if (!string.IsNullOrEmpty(lbl_todate.Text))
                {
                    lbl_todate.Text = Convert.ToDateTime(lbl_todate.Text).ToString("dd-MMM-yyyy");
                }
            }
        }
    }
    protected void grdApproveRejectCompOff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lbl_fromdate = (Label)e.Row.FindControl("l5");
            if (lbl_fromdate != null)
            {
                if (!string.IsNullOrEmpty(lbl_fromdate.Text))
                {
                    lbl_fromdate.Text = Convert.ToDateTime(lbl_fromdate.Text).ToString("dd-MMM-yyyy");
                }
            }
        }
    }
}
