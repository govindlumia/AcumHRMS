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
using Utilities;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity.Common;


public partial class leave_applyleave : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    string message1;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        //dd_typeleave.Attributes.Add("onchange", "disablesubmit();");
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";


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
        sqlparm[1].Value = hidd_empcode.Value;


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            Session["leaveType"] = ds.Tables[0].Rows[0]["leavetype"].ToString();
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
            {
                divfull.Visible = true;
                if (ds.Tables[0].Rows[0]["director"].ToString() != "")
                {
                    divDirector.Visible = true;
                    txt_employee.Text = ds.Tables[0].Rows[0]["resPerson"].ToString();
                    lblDirector.Text = ds.Tables[0].Rows[0]["directorName"].ToString();
                }
                else
                {
                    divDirector.Visible = false;
                    txt_employee.Text = ds.Tables[0].Rows[0]["resPerson"].ToString();
                    lblDirector.Text = ds.Tables[0].Rows[0]["directorName"].ToString();
                }
                divhalf.Visible = false;
                divshort.Visible = false;
                //divDirector.Visible = false;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("dd-MMM-yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("dd-MMM-yyyy");
            }
            else if ((ds.Tables[0].Rows[0]["half"]).ToString() != string.Empty)
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                divshort.Visible = false;
                divDirector.Visible = false;
                lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]).ToString("dd-MMM-yyyy");
                lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = false;
                divDirector.Visible = false;
                divshort.Visible = true;
                //commented
                //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                lbl_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_short.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["short"])) ? "In First half" : "In Second half";
            }

            // if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
            if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
            {
                btn_approve.Text = "Approve cancellation";
                btn_backuser.Enabled = false;
                btn_cancel.Text = "Reject cancellation";
                btn_approve.CssClass = "button1";
                btn_cancel.CssClass = "button1";
            }
            if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
            {
                btn_approve.Text = "Approve modification";
                btn_backuser.Enabled = false;
                btn_cancel.Text = "Reject modification";
                btn_approve.CssClass = "button1";
                btn_cancel.CssClass = "button1";
            }
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
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
            adjustgrid.DataSource = ds.Tables[1];
            adjustgrid.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[2];
            approvergrid.DataBind();
        }
    }

    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = hidd_empcode.Value;
        // sqlparm.Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);


        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            //lbl_branch.Text = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
            {
                DateTime doj = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString());//.ToString("dd - MMM - yyyy")
                lbl_doj.Text = doj.ToString("dd-MMM-yyyy");
            }

            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            grdMyBalance.DataSource = ds.Tables[1];
            grdMyBalance.DataBind();
        }
        else
        {
            grdMyBalance.DataSource = null;
            grdMyBalance.DataBind();
        }
        //if (hidd_empcode.Value == "0")
        //    return;
        //SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        //sqlparm.Value = hidd_empcode.Value;
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
        //lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        //lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        //lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        //lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        //lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        //lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        //lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        //lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd - MMM - yyyy");
        //adjustgrid.DataSource = null;
        //adjustgrid.DataBind();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //updateleave(0);
        message.InnerHtml = "Leave updated successfully";
    }

    protected void approveleave(int leavestatus, int status)
    {
        int approverstatus;
        sqlstr = "select approverpriority from tbl_Employee_Hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;
        if (leavestatus == 4)
            approverstatus = 0;
        else
        {
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
        }
        if (leavestatus == 6)
        {
            if (status == 0)
            {
                leavestatus = 2;
                status = 1;
            }
        }
        sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,modifiedby=@modifiedby,approvel_status=@approvel_status,status=@status,modifieddate=getdate() where id=@applyleaveid";
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
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "approveleave", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void btn_approve_Click(object sender, EventArgs e)
    {
        int i, leave_status;

        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;
        i = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleavestatus", sqlparm));
        if (Session["leaveType"].ToString() == "Special Leave")
        {
            if (i == 0)
                leave_status = 1;
            else
                leave_status = 0;
        }
        else
            if (i == 0)
                leave_status = 6;
            else
                leave_status = 6;

        try
        {
            sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01":
                    if (!validate_staff_leave_balance())
                        break;
                    else
                    {
                        approveleave(leave_status, 1);
                        if (leave_status == 6)
                        {
                            UpdateBalance();
                            Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application approved sucessfully");
                        }
                        else

                            Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application approved sucessfully");
                        break;
                    }
                case "11": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "21": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application already cancelled");
                    break;
                case "31": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                    break;
                case "61": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "10":
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0);
                    Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave cancellation application approved sucessfully");
                    break;
                case "60": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0);
                    returnBalance();
                    Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave cancellation application approved sucessfully");
                    break;
                case "12":
                case "62":
                    if (!validate_staff_leave_balance())
                        break;
                    else
                    {
                        approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 2);
                        Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave modification application approved sucessfully");
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem in applying acrtion,try latter";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "btn_approve_Click", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void UpdateBalance()
    {
        DataSet ds4, ds5, ds6 = new DataSet();
        Decimal DAYS = 0;
        string str2 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str2);
        DAYS = Convert.ToDecimal(ds4.Tables[0].Rows[0]["no_of_days"]);

        string str3 = "update tbl_leave_employee_leave_master set Used_days=Used_days + '" + DAYS + "' where leaveid='" + Convert.ToInt32(ds4.Tables[0].Rows[0]["leaveid"]) + "' and empcode='" + ds4.Tables[0].Rows[0]["empcode"] + "'";
        ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str3);
        DataSet ds8;
        string leaveid = hidd_leaveapplyid.Value;
        string str4 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str4);
        string empcode = Convert.ToString(ds8.Tables[0].Rows[0]["empcode"]);
        string approvercode = Session["empcode"].ToString();
        if (DAYS != Convert.ToDecimal(0.5))
        {
            MailToApprover(leaveid, empcode);
        }
        else
        {
            MailToApproverHalfDay(leaveid, empcode);
        }
    }

    protected void returnBalance()
    {
        DataSet ds4, ds5, ds6 = new DataSet();
        Decimal DAYS = 0;
        string str2 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str2);
        DAYS = Convert.ToDecimal(ds4.Tables[0].Rows[0]["no_of_days"]);

        string str3 = "update tbl_leave_employee_leave_master set Used_days=Used_days - '" + DAYS + "' where leaveid='" + Convert.ToInt32(ds4.Tables[0].Rows[0]["leaveid"]) + "' and empcode='" + ds4.Tables[0].Rows[0]["empcode"] + "'";
        ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str3);
        DataSet ds8;
        string leaveid = hidd_leaveapplyid.Value;
        string str4 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str4);
        string empcode = Convert.ToString(ds8.Tables[0].Rows[0]["empcode"]);
        string approvercode = Session["empcode"].ToString();

        MailToApproveCancelation(leaveid, empcode);



    }
    //-----------------------------------Validate Staff Leave Balance before approval----------------------------
    protected Boolean validate_staff_leave_balance()
    {
        DataSet ds1, ds2, ds3 = new DataSet();
        string str2 = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str2);

        DateTime dt = new DateTime();
        if (divfull.Visible == true)
        {
            //    dt = Convert.ToDateTime(lbl_sdate.Text);
            //if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
            //{
            //    dt = DateTime.ParseExact(lbl_sdate.Text, "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //}
            //else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
            //{
            dt = DateTime.ParseExact(lbl_sdate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            // }
        }
        else if (divhalf.Visible == true)
        {   //dt = Convert.ToDateTime(lbl_select.Text);

            //if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
            //{
            //    dt = DateTime.ParseExact(lbl_select.Text, "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //}
            //   else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
            // {
            dt = DateTime.ParseExact(lbl_select.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            //}

        }
        else
        //   dt = Convert.ToDateTime(lbl_selectSh.Text);
        {
            //if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
            //{
            //    dt = DateTime.ParseExact(lbl_selectSh.Text, "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //}
            //else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
            //{
            dt = DateTime.ParseExact(lbl_selectSh.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            //  }
        }

        string str3 = @"select leaveid,days from tbl_leave_adjustment_apply where leaveid<>0 and apply_leave_id=" + hidd_leaveapplyid.Value;

        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str3);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] sqlparm = new SqlParameter[4];

                sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlparm[0].Value = hidd_empcode.Value;

                sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int);
                sqlparm[1].Value = ds3.Tables[0].Rows[i]["leaveid"].ToString();

                sqlparm[2] = new SqlParameter("@applieddays", SqlDbType.Decimal);
                sqlparm[2].Value = ds3.Tables[0].Rows[i]["days"].ToString();

                //sqlparm[3] = new SqlParameter("@currentyear", SqlDbType.Bit, 1);
                //if (dt.Year == DateTime.Now.Year)
                //    sqlparm[3].Value = 1;
                //else
                //    sqlparm[3].Value = 0;

                sqlparm[3] = new SqlParameter("@id", SqlDbType.Int);
                if (Convert.ToInt32(ds2.Tables[0].Rows[0]["leave_status"].ToString()) == 6)
                    sqlparm[3].Value = hidd_leaveapplyid.Value;
                else
                    sqlparm[3].Value = 0;

                ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_leavebalance_approver", sqlparm);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>", false);
                        Page.RegisterStartupScript("vv", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>");
                        return false;
                    }
                }
            }
        }
        return true;
    }

    protected void btn_backuser_Click(object sender, EventArgs e)
    {
        approveleave(4, 1);
        Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application sended back to employee");
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01": approveleave(3, 1);
                DataSet ds8;
                string leaveid = hidd_leaveapplyid.Value;
                string str2 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
                ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str2);
                Decimal DAY = 0;
                DAY = Convert.ToDecimal(ds8.Tables[0].Rows[0]["no_of_days"]);
                string empcode = Convert.ToString(ds8.Tables[0].Rows[0]["empcode"]);
                string approvercode = Session["empcode"].ToString();
                if (DAY != Convert.ToDecimal(0.5))
                {
                    MailToApproverRejection(leaveid, empcode);
                }
                else
                {
                    MailToApproverRejectionHalf(leaveid, empcode);
                }
                Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application rejected sucessfully");

                break;
            case "11": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "21": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already cancelled");
                break;
            case "31": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                break;
            case "61": Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "10": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                cancelmodification();
                Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave cancellation application rejected sucessfully");
                break;
            case "60": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Request for cancellation rejected");
                break;
            case "12": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                cancel_modified_leave();
                Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave modification application rejected sucessfully");
                break;
            case "62": approveleave(6, 1);
                cancelmodification();
                cancel_modified_leave();
                Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave modification application rejected sucessfully");
                //Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Activity not allowed");
                break;
        }
        //approveleave(3, 1);
        //Response.Redirect("leave_approval.aspx?leavestatus=0&hr=0&message=Leave applciation rejected sucessfully");
    }
    protected void cancelmodification()
    {
        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_modification_request", sqlparm);
    }

    //*********************************** Code to cancel modification request ************************************//
    protected void cancel_modified_leave()
    {
        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_reject_leave_modification_request", sqlparm);
    }
    protected void Binddata()
    {
        DataSet ds8;
        string leaveid = hidd_leaveapplyid.Value;
        string str2 = "select empcode,leaveid, leave_status,status,no_of_days from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str2);
        string empcode = Convert.ToString(ds8.Tables[0].Rows[0]["empcode"]);
        string approvercode = Session["empcode"].ToString();
    }
    protected void MailToApproverRejection(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
           

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected the leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " ";


                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                     "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                    " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["hdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["hdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                    "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                   "Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();
                    
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected the leave request of " + dr["EmpName"].ToString() + ". The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

                }
                String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected your leave request ";


                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailForSelf = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected your leave request. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);


            }
           
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Rejected Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverRejection", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApprover(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has approved the leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " ";


                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                     "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                    " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                    "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                   "Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();
                 
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved the leave request of " + dr["EmpName"].ToString() + ". The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

                }
                String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has approved your leave request ";


                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailForSelf = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved your leave request. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);

            }

        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Approved Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApprover", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproverHalfDay(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has approved the half day leave request of  " + dr["EmpName"].ToString() + " ";


                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                     "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                    " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                    "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                   "Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();
                  
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved half day leave request of "+dr["EmpName"]+". The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

                }
                String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has approved your half day leave request ";


                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailForSelf = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved your half day leave request. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);




            }
         
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Approved Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverHalfDay", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproverRejectionHalf(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected the half day leave request of  " + dr["EmpName"].ToString() + " ";


                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                     "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                    " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                    "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                   "Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();
                
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected half day leave request of " + dr["EmpName"] + ". The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

                }
                String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected your half day leave request ";


                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailForSelf = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected your half day leave request. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);


            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Rejected Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverRejectionHalf", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproveCancelation(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string ToEmail = ds.Tables[0].Rows[0]["EmailID"].ToString();
                    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                    string password = ConfigurationManager.AppSettings["Password"].ToString();
                    NetworkCredential basicCredential = new NetworkCredential(userName, password);

                    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 25;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    smtpClient.EnableSsl = true;
                    message.To.Add(ToEmail.ToString());

                    message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " Has Approved the Cancellation leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " ";
                    message.IsBodyHtml = true;
                    //  message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + Session["EmpName"].ToString() + " Has Approved the Cancellation leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " . The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br> Reason : " + ds.Tables[0].Rows[0]["reason"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                    message.Body = "<h4>Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " Has Approved the Cancellation leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "  .<br/><br/>. The leave details are:     <br />" +
             "<br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                "<tr><td>From Date(s)</td><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td></tr><tr><td>To Date</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr><tr><td>Leave type :</td><td> " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td> Remarks :</td><td> " + ds.Tables[0].Rows[0]["comments"].ToString() + "</td><tr><td> Reason :</td><td> " + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr></table>" +
                 "<br/>Thanks,<br />Acuminous Software<br /><br /></div>";

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
             System.Security.Cryptography.X509Certificates.X509Certificate certificate,
             System.Security.Cryptography.X509Certificates.X509Chain chain,
             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    smtpClient.Send(message);
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                string ToEmail = ds.Tables[1].Rows[0]["EmailID"].ToString();
                string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                NetworkCredential basicCredential = new NetworkCredential(userName, password);

                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 25;
                smtpClient.Credentials = basicCredential;
                message.From = fromAddress;
                smtpClient.EnableSsl = true;
                message.To.Add(ToEmail.ToString());

                message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " Has Approved Your Cancellation Leave Request";
                message.IsBodyHtml = true;
                //  message.Body = "Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " <br> " + Session["EmpName"].ToString() + " Has Approved Your Cancellation Leave Request . The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br> Remarks : " + ds.Tables[1].Rows[0]["comments"].ToString() + "<br> Reason: " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                message.Body = "<h4>Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " Has Approved Your Cancellation Leave Request.<br/><br/>. The leave details are:     <br />" +
              "<br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<tr><td>From Date(s)</td><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td></tr><tr><td>To Date</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr><tr><td>Leave type :</td><td> " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td> Remarks :</td><td> " + ds.Tables[1].Rows[0]["comments"].ToString() + "</td><tr><td> Reason :</td><td> " + ds.Tables[1].Rows[0]["reason"].ToString() + "</td></tr></table>" +
                  "<br/>Thanks,<br />Acuminous Software<br /><br /></div>";

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
             System.Security.Cryptography.X509Certificates.X509Certificate certificate,
             System.Security.Cryptography.X509Certificates.X509Chain chain,
             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Approved Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproveCancelation", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToRejectCancellation(string leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_mailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string ToEmail = ds.Tables[0].Rows[0]["EmailID"].ToString();
                    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                    string password = ConfigurationManager.AppSettings["Password"].ToString();
                    NetworkCredential basicCredential = new NetworkCredential(userName, password);

                    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 25;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    smtpClient.EnableSsl = true;
                    message.To.Add(ToEmail.ToString());

                    message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " has cancelled the Cancellation leave Request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " ";
                    message.IsBodyHtml = true;
                    //       message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has cancelled the Cancellation leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " . The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> Reason: " + ds.Tables[0].Rows[0]["reason"].ToString() + "<br> Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Rossell Techsys<br><br><br><br>This is an automated notification.<br>";
                    message.Body = "<h4>Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has cancelled the Cancellation leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + ".<br/><br/>. The leave details are:     <br />" +
                    "<br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       "<tr><td>From Date(s)</td><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td></tr><tr><td>To Date</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr><tr><td>Leave type :</td><td> " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td> Remarks :</td><td> " + ds.Tables[0].Rows[0]["comments"].ToString() + "</td><tr><td> Reason :</td><td> " + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr></table>" +
                        "<br/>Thanks,<br />Rossell Techsys<br /><br /></div>";

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    smtpClient.Send(message);
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                string ToEmail = ds.Tables[1].Rows[0]["EmailID"].ToString();
                string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                NetworkCredential basicCredential = new NetworkCredential(userName, password);

                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 25;
                smtpClient.Credentials = basicCredential;
                message.From = fromAddress;
                smtpClient.EnableSsl = true;
                message.To.Add(ToEmail.ToString());

                message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " has cancelled your Cancellation leave Request of " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " ";
                message.IsBodyHtml = true;
                // message.Body = "Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has cancelled your Cancellation leave request of " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " . The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br> Reason: " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br> Comments: " + ds.Tables[1].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Rossell Techsys<br><br><br><br>This is an automated notification.<br>";
                message.Body = "<h4>Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has cancelled the Cancellation leave request of  " + ds.Tables[1].Rows[0]["EmpName"].ToString() + ".<br/><br/>. The leave details are:     <br />" +
                     "<br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                        "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                        "<tr><td>From Date(s)</td><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td></tr><tr><td>To Date</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr><tr><td>Leave type :</td><td> " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td> Remarks :</td><td> " + ds.Tables[1].Rows[0]["comments"].ToString() + "</td><tr><td> Reason :</td><td> " + ds.Tables[1].Rows[0]["reason"].ToString() + "</td></tr></table>" +
                         "<br/>Thanks,<br />Rossell Techsys<br /><br /></div>";

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Rejected Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToRejectCancellation", PageName = "viewleave_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }
}