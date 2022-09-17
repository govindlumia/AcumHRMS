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
using HRMS.BusinessLogic;
using HRMS.BusinessEntity.Common;

public partial class leave_viewcompoff_approver : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
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
            bindemployee_detail();
            fetchleavedata();
        }
    }



    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetchin comp-off leave data,try latter";
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

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"]))
            {
                divfull.Visible = true;

                divhalf.Visible = false;
                divshort.Visible = false;
                DateTime lblsdate, lbledate;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");


            }
            else
            {
                if ((ds.Tables[0].Rows[0]["halfMode"]).ToString() != string.Empty)
                {
                    divfull.Visible = false;
                    divshort.Visible = false;
                    divhalf.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                    lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["halfMode"])) ? "First half" : "Second half";
                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = false;
                    divshort.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");

                }
            }

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
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comment"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_file.Text = (ds.Tables[0].Rows[0]["filepath"].ToString() != "") ? "<a href='upload/" + ds.Tables[0].Rows[0]["filepath"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["filepath"].ToString() + "</a>" : "No exisitng file found";
        }
        else
        {
            message.InnerHtml = "No data available";
            return;
        }

        adjustgrid.DataSource = null;
        adjustgrid.DataBind();
        if (ds.Tables[1].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[1];
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
            lbl_branch.Text = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
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
                message.InnerHtml = "Problem updating comp-off leave,try latter";
                return;
            }
        }


        // Approve Comp Off

        sqlstr = "update tbl_leave_apply_compoff set comment=comment + @comment,leave_status=@leave_status,modifiedby=@modifiedby,approval_status=@approval_status,status=@status,modifieddate=getdate() where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
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

        sqlparm[4] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[4].Value = approverstatus;

        sqlparm[5] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[5].Value = status;

        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_approvecompoff", sqlparm);
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling comp-off leave,try latter";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "approveleave", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
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
        i = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validatecompoffstatus", sqlparm));

        if (i == 0)
            leave_status = 6;
        else
            leave_status = 6;

        try
        {
            sqlstr = "select leave_status,status from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01":
                    //if (!validate_staff_leave_balance())
                    //    break;
                    //else
                    //{
                    approveleave(leave_status, 1);
                    if (leave_status == 6)
                    {
                        string empcode = lbl_emp_code.Text.Trim();
                        int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
                        MailToApproverCompOff(leaveid, empcode);
                        Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application approved Sucessfully");
                    }
                    else
                    Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application approved Sucessfully");
                    break;
                //}
                case "11": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already approved");
                    break;
                case "21": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already cancelled");
                    break;
                case "31": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already rejected");
                    break;
                case "61": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already approved");
                    break;
                case "10":
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave cancellation application approved sucessfully");
                    break;

                case "60": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave cancellation application approved sucessfully");
                    break;
                case "12":
                case "62":
                    //if (!validate_staff_leave_balance())
                    //    break;
                    //else
                    //{
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 2);
                    Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave modification application approved sucessfully");
                    break;
                //}
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling comp-off leave,try latter";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "btn_approve_Click", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    

    protected void btn_backuser_Click(object sender, EventArgs e)
    {
        approveleave(4, 1);
        Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application sended back to employee");
    }


    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        sqlstr = "select leave_status,status from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01": approveleave(3, 1);
                MailToApproverRejection(hidd_leaveapplyid.Value, lbl_emp_code.Text, Session["empcode"].ToString());
                Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application rejected Sucessfully");
                break;
            case "11": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already approved");
                break;
            case "21": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already cancelled");
                break;
            case "31": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already rejected");
                break;
            case "61": Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already approved");
                break;
            case "10": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                cancelmodification();
                //cancel_modified_leave();
                Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave cancellation application rejected sucessfully");
                break;
            case "60":
                approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                //cancelmodification();
                Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Request for cancellation rejected");
                break;
            case "12": approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1);
                cancel_modified_leave();
                Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off leave modification application rejected sucessfully");
                break;
            case "62":
                approveleave(6, 1);
                cancelmodification();
                cancel_modified_leave();
                Response.Redirect("compoff_approval.aspx?compoffstatus=0&hr=0&message=Comp-off Leave modification application rejected sucessfully");
                break;
        }
    }

    protected void cancelmodification()
    {
        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_compoffmodification_request", sqlparm);
    }
    ////-----------------------------------Validate Staff Leave Balance before approval----------------------------
    //protected Boolean validate_staff_leave_balance()
    //{
    //    sqlstr = "select leave_status,status from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
    //    DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //    DataSet ds1 = new DataSet();

    //    SqlParameter[] sqlparm = new SqlParameter[3];

    //    sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
    //    sqlparm[0].Value = hidd_empcode.Value;

    //    sqlparm[1] = new SqlParameter("@applieddays", SqlDbType.Decimal);
    //    sqlparm[1].Value = lbl_nodays.Text;

    //    sqlparm[2] = new SqlParameter("@leaveid", SqlDbType.Int);
    //    if (Convert.ToInt16(ds2.Tables[0].Rows[0]["leave_status"].ToString()) == 6)
    //        sqlparm[2].Value = hidd_leaveapplyid.Value;
    //    else
    //        sqlparm[2].Value = 0;

    //    ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_compoffbalance_approver", sqlparm);
    //    if (ds1.Tables[0].Rows.Count > 0)
    //    {
    //        if (ds1.Tables[0].Rows[0][0].ToString() == "0")
    //        {
    //            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>", false);
    //            //Page.RegisterStartupScript("vv", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>");
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    protected void cancel_modified_leave()
    {
        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_reject_compoff_modification_request", sqlparm);
    }

    protected void MailToApproverRejection(string leaveid, string empcode, string approvercode)
    {
        try
        {
            //string url;
            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);
         //   sqlparm[2] = new SqlParameter("@approvercode", approvercode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[Sp_leave_CompOffmailer]", sqlparm);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected the compensatory leave request of  " + dr["EmpName"].ToString() + " ";


                string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comment"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                MailScript mail = new MailScript();

                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected the compensatory leave request of " + dr["EmpName"].ToString() + ". The leave details are:     <br /> ");
                builder.Append(table);
                mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

            }
            String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has rejected your compensatory leave request ";


            string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
             "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
            " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
            "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comment"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
           "Thanks,<br />Acuminous Software<br /><br /></div>";


            System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
            MailScript mailForSelf = new MailScript();

            builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
       "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has rejected your compensatory leave request. The leave details are:     <br /> ");
            builderForSelf.Append(tableForSelf);
            mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);


            
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Rejected Successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverRejection", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproverCompOff(int leaveid, string empcode)
    {
        try
        {
            //string url;
            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_CompOffmailer", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {

            //        string ToEmail = ds.Tables[0].Rows[0]["EmailID"].ToString();
            //        string userName = ConfigurationManager.AppSettings["UserName"].ToString();
            //        string password = ConfigurationManager.AppSettings["Password"].ToString();
            //        NetworkCredential basicCredential = new NetworkCredential(userName, password);

            //        MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
            //        smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
            //        smtpClient.UseDefaultCredentials = false;
            //        smtpClient.Port = 25;
            //        smtpClient.Credentials = basicCredential;
            //        message.From = fromAddress;
            //        smtpClient.EnableSsl = true;
            //        message.To.Add(ToEmail.ToString());

            //        message.Subject = "Leave Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " applied for " + ds.Tables[0].Rows[0]["no_of_days"].ToString() + " Day(s) of Compensatory leave ";
            //        message.IsBodyHtml = true;
            //        message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has applied for leave. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : Compensatory leave <br>Remarks : <B>" + ds.Tables[0].Rows[0]["comment"].ToString() + "<br> Reason : " + ds.Tables[0].Rows[0]["reason"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
            //        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            //    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            //    System.Security.Cryptography.X509Certificates.X509Chain chain,
            //    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //        {
            //            return true;
            //        };
            //        smtpClient.Send(message);
            //    }
            //}
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    string ToEmail = ds.Tables[1].Rows[0]["EmailID"].ToString();
            //    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
            //    string password = ConfigurationManager.AppSettings["Password"].ToString();
            //    NetworkCredential basicCredential = new NetworkCredential(userName, password);

            //    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
            //    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Port = 25;
            //    smtpClient.Credentials = basicCredential;
            //    message.From = fromAddress;
            //    smtpClient.EnableSsl = true;
            //    message.To.Add(ToEmail.ToString());

            //    message.Subject = "Leave Notification - You applied for " + ds.Tables[1].Rows[0]["no_of_days"].ToString() + " Day(s) of  Compensatory leave ";
            //    message.IsBodyHtml = true;
            //    message.Body = "Hi " + ds.Tables[1].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " has applied for leave. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : Compensatory leave <br>Remarks : <B>" + ds.Tables[1].Rows[0]["comment"].ToString() + "<br> Reason : <B> " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
            //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            //System.Security.Cryptography.X509Certificates.X509Chain chain,
            //System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //    {
            //        return true;
            //    };
            //    smtpClient.Send(message);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    String subject = "Leave Notification - " + Session["EmpName"].ToString() + " has approved the compensatory leave request of  " + dr["EmpName"].ToString() + " ";


                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                     "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                    " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                    "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dr["comment"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                   "Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();

                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dr["ApproverName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved the compensatory leave request of " + dr["EmpName"].ToString() + ". The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), subject, builder.ToString(), null, null);

                }
                String subjectForSelf = "Leave Notification - " + Session["EmpName"].ToString() + " has approved your compensatory leave request ";


                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                 "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(ds.Tables[0].Rows[0]["comment"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
               "Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailForSelf = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br /> " + Session["EmpName"].ToString() + " has approved your compensatory leave request. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailForSelf.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), subjectForSelf, builderForSelf.ToString(), null, null);



            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverCompOff", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproverhalfdaycompOff(int leaveid, string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_leave_CompOffmailer", sqlparm);

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

                    message.Subject = "Leave Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " applied for half Day of  Compensatory leave ";
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has applied for Half Day leave. The leave details are:<br><table><tr><td> Date(s)</td><td> Duration</td></tr><tr><td>" + ds.Tables[0].Rows[0]["hdate"].ToString() + "</td><td> " + ds.Tables[0].Rows[0]["half"].ToString() + "</td></tr></table><br>Leave type :  Compensatory leave <br>Remarks : <B>" + ds.Tables[0].Rows[0]["comment"].ToString() + "<br> Reason : <B> " + ds.Tables[0].Rows[0]["reason"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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

                message.Subject = "Leave Notification - You applied for half Day of Compensatory leave ";
                message.IsBodyHtml = true;
                message.Body = "Hi " + ds.Tables[1].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " has applied for Half Day leave. The leave details are:<br><table><tr><td> Date(s)</td><td> Duration</td></tr><tr><td>" + ds.Tables[1].Rows[0]["hdate"].ToString() + "</td><td> " + ds.Tables[1].Rows[0]["half"].ToString() + "</td></tr></table><br>Leave type : Compensatory leave <br>Remarks : <B>" + ds.Tables[1].Rows[0]["comment"].ToString() + "<br> Reason : <B>" + ds.Tables[1].Rows[0]["reason"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverhalfdaycompOff", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void MailToApproverRejectionHalf(string leaveid, string empcode, string approvercode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[3];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);
            sqlparm[2] = new SqlParameter("@approvercode", approvercode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetchmaildetail_approver", sqlparm);

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

                    message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " has cancelled leave Request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " ";
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has cancelled leave request of  " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " . The leave details are:<br><table><tr><td> Date</td><td>Duration</td></tr><tr><td>" + ds.Tables[0].Rows[0]["hdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["half"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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

                message.Subject = "Leave Notification - " + Session["EmpName"].ToString() + " has cancelled leave Request of " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " ";
                message.IsBodyHtml = true;
                message.Body = "Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has cancelled leave request of " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " . The leave details are:<br><table><tr><td>Date</td><td>Duration</td></tr><tr><td>" + ds.Tables[1].Rows[0]["hdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["half"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverRejectionHalf", PageName = "viewcompoff_approver.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

}
