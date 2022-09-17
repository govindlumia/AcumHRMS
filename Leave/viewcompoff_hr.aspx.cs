using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
public partial class leave_viewcompoff_hr : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
            Session.Remove("adjusttable");
            //configurecontrol();
            bindemployee_detail();
            fetchleavedata();
        }

    }


    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetchin leave data,try latter";
            return;
        }
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;// Session["empcode"].ToString();

        //("@applyleaveid", Request.QueryString["leaveapplyid"].ToString());
        //@empcode

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewcompoffapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {

            lbl_fromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
            lbl_todate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");

            if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
            {
                btn_approve.Text = "Approve Cancellation";
                btn_cancel.Text = "Reset";
                btn_approve.CssClass = "button1";
                btn_cancel.CssClass = "button1";
            }
            if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
            {
                btn_approve.Text = "Approve Modification";
                btn_cancel.Text = "Reset";
                btn_approve.CssClass = "button1";
                btn_cancel.CssClass = "button1";
            }
            lbl_nodays.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();

            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comment"].ToString();

        }
        else
        {
            message.InnerHtml = "No data available";
            return;
        }       

        if (ds.Tables[1].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[1];
            approvergrid.DataBind();
        }
    }


    protected void bindemployee_detail()
    {
        if (hidd_empcode.Value == "0")
            return;
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = hidd_empcode.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        // lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        // lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd - MMM - yyyy");

    }



    //**************************************** Update modified compoff leave ********************************************//

    protected void updatependingleave()
    {
        SqlParameter[] sqlparm;

        sqlstr = "delete from tbl_leave_compoff_adjustment where compoff_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);


        dtable = (DataTable)Session["workedontable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[6];

            sqlparm[0] = new SqlParameter("@compoff_id", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparm[1].Value = 1;

            sqlparm[2] = new SqlParameter("@date", SqlDbType.DateTime);
            sqlparm[2].Value = dtable.Rows[i]["date"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_savecompoffadjustment_pending]", sqlparm);
        }
    }


    //*************************************** Update cancelled compoff leave *********************************//

    protected void updatecancelleave(int mode)
    {

        sqlstr = "update tbl_leave_compoff_adjustment set status=0 where compoff_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

    }


    //************************************** Update applied compoff leave ***************************************//

    protected void updateleaveapplication(int leavestatus, int status)
    {
        int approverstatus;
        sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode order by 1 desc";
        SqlParameter[] sqlparm;
        //if (leavestatus == 0)
        //    approverstatus = 0;
        //else
        //{
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;
        try
        {
            approverstatus = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm));
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem updating Comp-off leave,try latter";
            return;
        }

        sqlstr = "update tbl_leave_apply_compoff set comment=comment + @comment,leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approval_status=@approval_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leavestatus;

        sqlparm[4] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[4].Value = approverstatus;

        sqlparm[5] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[5].Value = status;

        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling comp-off leave,try latter";
        }
    }

    protected void btn_approve_Click(object sender, EventArgs e)
    {
        try
        {
            sqlstr = "select leave_status,status from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01": Response.Redirect("leave_approval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application is in pending status");
                    break;
                case "11": //updatependingleave();
                    updateleaveapplication(6, 1);
                    updatebackmonth();
                    Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave application updated sucessfully");
                    break;
                case "21": Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application already cancelled");
                    break;
                case "31": Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application already rejected");
                    break;
                case "61": Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave application already updated");
                    break;
                case "10":
                    updatecancelleave(0);
                    updateleaveapplication(2, 1);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave cancellation application updated sucessfully");
                    break;
                case "60": updatecancelleave(1);
                    updateleaveapplication(2, 1);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave cancellation application updated sucessfully");
                    break;
                case "12": updatependingleave();
                    updateleaveapplication(6, 1);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave modification application updated sucessfully");
                    break;
                case "62":
                    updateleaveapplication(6, 1);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=1&hr=1&message=Comp-off leave modification application updated sucessfully");
                    break;
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling comp-off leave,try latter";
        }
    }
    protected void updatebackmonth()
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode;
        string empcode;
        string displayleave;
        string displayleavename;
        int leavemode;

        DataSet ds2, ds3;
        string str1 = "SELECT empcode, half, fromdate, todate FROM tbl_leave_apply_compoff WHERE id=" + hidd_leaveapplyid.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["half"]);

            if (fromdate.Month != DateTime.Now.Month)
            {
                //string str2 = "SELECT empshiftcode FROM tbl_leave_dutyroster WHERE empcode='" + empcode + "' and date='" + fromdate + "'";
                //ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str2);

                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                if (leavemode == 0)
                {
                    displayleavename = "CO(HF)";
                }
                else
                {
                    displayleavename = "CO";
                }
                //empshiftcode = Convert.ToInt32(ds2.Tables[0].Rows[0]["empshiftcode"]);

                //string str3 = "SELECT starttime,endtime FROM tbl_leave_shift WHERE shiftid=" + empshiftcode;
                //ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str3);

                //if (ds3.Tables[0].Rows.Count > 0)
                //{
                //    intime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["starttime"]);
                //    outtime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["endtime"]);

                string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str4);
                //}
                //}
            }
        }
    }
}
