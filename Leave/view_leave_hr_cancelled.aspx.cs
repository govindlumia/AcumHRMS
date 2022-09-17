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

public partial class leave_view_leave_hr_cancelled : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
    DataTable dtable;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;

    protected void Page_Load(object sender, EventArgs e)
    {
        message1 = "";
        message.InnerHtml = "";
        //dd_typeleave.Attributes.Add("onchange", "disablesubmit();");
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

            //if (Request.QueryString["hr"] == "cancelled")
            //{
            //    btncancel.Enabled = false;
            //}
        }
    }

    protected void createadjustment()
    {
        dtable = new DataTable();
        dtable.Columns.Add("leaveid", typeof(int));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["leaveid"] };
        dtable.Columns.Add("leavename", typeof(string));
        dtable.Columns.Add("status", typeof(int));
        dtable.Columns.Add("noofdays", typeof(string));
        Session["adjusttable"] = dtable;
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

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
            {
                divfull.Visible = true;
                divhalf.Visible = false;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]).ToString("MM/dd/yyyy");
                lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
            }
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
        }
        else
        {
            message.InnerHtml = "No data available";
            return;
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            if (Session["adjusttable"] == null)
                createadjustment();
            DataRow dr;
            DataTable sdata;

            sdata = (DataTable)Session["adjusttable"];
            for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
            {
                dr = sdata.NewRow();
                dr["leaveid"] = (ds.Tables[1].Rows[i]["leaveid"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["leaveid"].ToString()) : 0;
                dr["leavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";
                dr["noofdays"] = (ds.Tables[1].Rows[i]["noofdays"] != null) ? ds.Tables[1].Rows[i]["noofdays"].ToString() : "";
                dr["status"] = (Convert.ToBoolean(ds.Tables[1].Rows[i]["status"]) != true) ? 1 : 0;

                sdata.Rows.Add(dr);
            }
            Session["adjusttable"] = sdata;
            adjustgrid.DataSource = sdata;
            adjustgrid.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[2];
            approvergrid.DataBind();
        }
    }
    protected void bindadjustment()
    {
        dtable = (DataTable)Session["adjusttable"];
        adjustgrid.DataSource = dtable;
        adjustgrid.DataBind();
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
        lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd - MMM - yyyy");
        adjustgrid.DataSource = null;
        adjustgrid.DataBind();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //updateleave(0);
        message.InnerHtml = "Leave Updated successfully";

    }

    //protected void btn_cancel_Click(object sender, EventArgs e)
    //{
    //    updateapprover(3,"Leave applciation rejected sucessfully");
    //}



    protected void btn_approve_Click(object sender, EventArgs e)
    {
        DataTable sdate;
        sdate = (DataTable)Session["adjusttable"];
        Single noofdays = 0;
        DataSet ds121;
        for (int i = 0; sdate.Rows.Count > i; i++)
        {
            noofdays = noofdays + Convert.ToSingle(sdate.Rows[i]["noofdays"].ToString());

            SqlParameter[] sqlparm121 = new SqlParameter[3];

            sqlparm121[0] = new SqlParameter("@leaveid", SqlDbType.Int);
            sqlparm121[0].Value = Convert.ToInt32(sdate.Rows[i]["leaveid"]);

            sqlparm121[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm121[1].Value = hidd_empcode.Value;

            sqlparm121[2] = new SqlParameter("@noofdays", SqlDbType.Int);
            sqlparm121[2].Value = Convert.ToSingle(sdate.Rows[i]["noofdays"].ToString());

            ds121 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_hr_check", sqlparm121);

            if (Convert.ToInt32(ds121.Tables[0].Rows[0][0]) == 0)
            {
                message.InnerHtml = "Please check leave balance.Leave balance cannot be negative.";
                return;
            }
        }
        if (Convert.ToSingle(lbl_nod.Text) != noofdays)
        {
            message.InnerHtml = "Adjusted no of leave is not equal to leave applied";
            return;
        }
        try
        {
            sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01": Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application is in pending status");
                    break;
                case "11": updatependingleave();
                    updateleaveapplication(6, 1);
                    updatebackmonth();
                    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave application updated sucessfully");
                    break;
                case "21": Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already cancelled");
                    break;
                case "31": Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already rejected");
                    break;
                case "61": Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave application already updated");
                    break;
                case "10":
                    updatecancelleave(0);
                    updateleaveapplication(2, 1);
                    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave cancellation application updated sucessfully");
                    break;
                case "60": updatecancelleave(1);
                    updateleaveapplication(2, 1);
                    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave cancellation application updated sucessfully");
                    break;
                case "12": updatependingleave();
                    updateleaveapplication(6, 1);
                    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave modification application updated sucessfully");
                    break;
                case "62": updatemodifiedleave();
                    updateleaveapplication(6, 1);
                    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave modification application updated sucessfully");
                    break;
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling leave,try latter";
        }
        //updateadjustment(1);
        //updateapprover(1,"Leave updated Sucessfully");
    }


    protected void updatependingleave()
    {
        SqlParameter[] sqlparm;

        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);


        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[6];

            sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[1].Value = dtable.Rows[i]["leaveid"].ToString();

            sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[2].Value = dtable.Rows[i]["noofdays"].ToString();

            sqlparm[3] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
            sqlparm[4].Value = dtable.Rows[i]["leavename"].ToString();

            sqlparm[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[5].Value = hidd_empcode.Value;

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_saveleaveadjustment_pending]", sqlparm);
        }
    }

    protected void updatecancelleave(int mode)
    {
        SqlParameter[] sqlparm;

        sqlstr = "update tbl_leave_adjustment_apply set status=0 where apply_leave_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (mode == 0)
            return;
        sqlstr = "select apply_leave_id,leaveid,days from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[3];

            sqlparm[0] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[0].Value = ds.Tables[0].Rows[i]["leaveid"].ToString();

            sqlparm[1] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[1].Value = ds.Tables[0].Rows[i]["days"].ToString();

            sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[2].Value = hidd_empcode.Value;

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_saveleaveadjustment_cancellation", sqlparm);
        }
    }

    protected void updatemodifiedleave()
    {
        SqlParameter[] sqlparm;

        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[1].Value = dtable.Rows[i]["leaveid"].ToString();

            sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[2].Value = dtable.Rows[i]["noofdays"].ToString();

            sqlparm[3] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
            sqlparm[4].Value = dtable.Rows[i]["leavename"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_saveleaveadjustment_modification", sqlparm);
        }
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_fetchleavechanges", sqlparm);
        for (i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[3];

            sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[0].Value = hidd_empcode.Value;

            sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[1].Value = ds.Tables[0].Rows[i]["leaveid"].ToString();

            sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[2].Value = ds.Tables[0].Rows[i]["days"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_savemodifiedleave", sqlparm);

        }
    }

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
            message.InnerHtml = "Problem updating leave,try latter";
            return;
        }
        //}
        sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approvel_status=@approvel_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        sqlparm[0] = new SqlParameter("@comments", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leavestatus;

        sqlparm[4] = new SqlParameter("@approvel_status", SqlDbType.Int, 4);
        sqlparm[4].Value = approverstatus;

        sqlparm[5] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[5].Value = status;

        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling leave,try latter";
        }
    }
    //protected void btn_backuser_Click(object sender, EventArgs e)
    //{
    //    updateapprover(2,"Leave application cancelled sucessfully");
    //    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave application cancelled sucessfully");
    //}

    //protected void btn_reject_Click(object sender, EventArgs e)
    //{
    //    updateapprover(1, "Leave cancellation application rejected sucessfully");
    //    Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave cancellation application rejected sucessfully");
    //}

    /// grid activity

    protected void btn_add_Click(object sender, EventArgs e)
    {
        DataRow dr;
        if (Session["adjusttable"] == null)
            createadjustment();
        dtable = (DataTable)Session["adjusttable"];

        DataRow drfind = dtable.Rows.Find(drp_leave.SelectedValue.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Leave type already in queue";
        }
        else
        {
            dr = dtable.NewRow();
            dr["leaveid"] = drp_leave.SelectedValue.ToString();
            dr["leavename"] = drp_leave.SelectedItem.Text.ToString();
            dr["noofdays"] = txt_noofdays.Text;
            dr["status"] = 0;
            dtable.Rows.Add(dr);
        }


        Session["adjusttable"] = dtable;

        bindadjustment();
        drp_leave.SelectedIndex = -1;
        txt_noofdays.Text = "";
    }
    protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        dtable = (DataTable)Session["adjusttable"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(adjustgrid.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.BeginEdit();
            drfind["leaveid"] = ((DropDownList)adjustgrid.Rows[e.RowIndex].Cells[0].Controls[1]).SelectedValue;
            drfind["leavename"] = ((DropDownList)adjustgrid.Rows[e.RowIndex].Cells[0].Controls[1]).SelectedItem.Text;
            drfind["noofdays"] = ((TextBox)adjustgrid.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
            //drfind.EndEdit();
            // dtable.AcceptChanges();
            adjustgrid.EditIndex = -1;
            Session["adjusttable"] = dtable;
            bindadjustment();
        }
    }
    protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        adjustgrid.EditIndex = e.NewEditIndex;
        bindadjustment();
    }
    protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["adjusttable"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(adjustgrid.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["adjusttable"] = dtable;
            bindadjustment();
        }
    }
    protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        adjustgrid.EditIndex = -1;

        bindadjustment();
    }
    /// end grid work////////////////////////////////

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Session.Remove("adjusttable");
        fetchleavedata();
    }

    protected void updatebackmonth()
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode;
        string empcode;
        DataSet ds2, ds3;
        string str1 = "SELECT empcode, fromdate, todate FROM tbl_leave_apply_leave WHERE id=" + hidd_leaveapplyid.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]);
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
        updatecancelleave(1);
        updateleaveapplication(2, 1);
        Response.Redirect("leave_approval.aspx?leavestatus=1&hr=1&message=Leave cancellation application updated sucessfully");
    }

    protected void check_attendance()
    {

    }
}
