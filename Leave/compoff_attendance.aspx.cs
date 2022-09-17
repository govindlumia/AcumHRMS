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
using System.Data.SqlClient;
using Utilities;
using System.Net;
using System.Net.Mail;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity.Common;

public partial class leave_compoff_attendance : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    //string sqlstr;
    string comment;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
           
        }
        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("approval_status", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        helper.ApplyGroupSort();
        bind_empdetail();
    }
    protected void bind_empdetail()
    {

        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);

        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        //HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_department.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
        //lbl_branch.Text = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
        {
            lbl_doj.Text = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
        }
    }

    protected void clearfield()
    {
        txt_date.Text = "";
        ddl_extrahour.SelectedIndex = 0;
        txt_comment.Text = "";
    }
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        // Changed by Keerti Dwivedi on july 6 2018 for implementing apply compoff mail
        var a = insert_compoff_mark();
        clearfield();
        //if (validate_time_span())
        //{
        //    insert_approve_compoff_table();
        //}
        //else
        //{
        //    //message.InnerHtml = "Your logged in time is less than 6 hours ! You can not mark your compoff for";
        //}

        var emp_code = "";
        if(Session["empcode"] != null && Session["empcode"] != "")
        {
            emp_code = Session["empcode"].ToString();
        }
        else
        {
            emp_code = "";
        }
        if(a>0)
        {
            MailToApproverCompOff(a, emp_code);
        }
        else
        {

        }
        // upto here by keerti dwivedi
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }
    ////********************** Code to validate time span of 6 hrs *******************************************//

    //protected Boolean validate_time_span()
    //{
    //    sqlstr = "select empcode,date,empshiftcode from tbl_leave_dutyroster where empcode=" + Session["empcode"] + " and date='" + System.DateTime.Now.Date.ToShortDateString() + "' and empshiftcode in (0,1)";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["cebConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        Button1.Enabled = true;
    //        //lbl_time.Text = "Today's date:"+ System.DateTime.Now.Date.ToShortDateString()+"";

    //        sqlparam = new SqlParameter[2];

    //        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
    //        sqlparam[0].Value = Session["empcode"];

    //        sqlparam[1] = new SqlParameter("@date", SqlDbType.DateTime);
    //        sqlparam[1].Value = System.DateTime.Now.Date;

    //        sqlstr = " select empcode,time from tbl_leave_attendance where empcode=@empcode and date=@date";
    //        //sqlstr = " select empcode,in_time from tbl_leave_attendance where empcode=@empcode and date=@date";

    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["cebConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            TimeSpan dt = System.DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["time"]);
    //            //TimeSpan dt = System.DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["in_time"]);
    //            if (dt.Hours >= 6)
    //            {
    //                Button1.Enabled = true;
    //                //lbl_time.Text = "Today's date:" + System.DateTime.Now.Date.ToShortDateString() + "";
    //                return true;
    //            }
    //            else
    //            {
    //                Button1.Enabled = false;
    //                message.InnerHtml = "Your logged in time is less than 6 hours ! You can not mark your compoff for today";
    //                //lbl_time.Text = "Your logged in time is less than 6 hours ! You can not mark your compoff for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //                txt_reason.Text = "";
    //                return false;
    //            }
    //            return true;
    //        }
    //        else
    //        {
    //            Button1.Enabled = false;
    //            //string message1 = "You have not marked your attendance for today till ! You can not mark your compoff for " + System.DateTime.Now.Date.ToShortDateString() + "";//"Your shift is not created ! Please contact your TMT";               
    //            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //            message.InnerHtml = "You have not marked your attendance for today till ! You can not mark your compoff for today";
    //            txt_reason.Text = "";
    //            return false;
    //        }
    //        return true;
    //    }
    //    else
    //    {
    //        Button1.Enabled = false;
    //        message.InnerHtml = "Today is not your holiday or weekend ! You can not mark compoff for today";
    //        //lbl_time.Text = "Today is not your holiday or weekend ! You can not mark compoff for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //        txt_reason.Text = "";
    //        return false;
    //    }
    //    //System.DateTime.Now.ToString()
    //}
    ////********************** Code to validate button enablity *******************************************//

    //protected Boolean check_attendance_marked()
    //{
    //    sqlstr = "select count(empcode)as rows from tbl_ceb_approve_compoff where empcode='" + Session["empcode"] + "' and  date='" + System.DateTime.Now.ToShortDateString() + "'";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["cebConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    if ((int)ds.Tables[0].Rows[0][0] > 0)
    //    {
    //        Button1.Enabled = false;
    //        message.InnerHtml = "You had already marked your compoff attendance for today";
    //        //lbl_time.Text = "You had already marked your compoff attendance for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //        return false;
    //    }
    //    return true;
    //}

    ////-------------------------------------Code to mark comp off attendance For Approval in approve_compoff table ---------------------------------------
    //protected void insert_approve_compoff_table()
    //{
    //    sqlstr = "select count(empcode)as rows from tbl_ceb_approve_compoff where empcode='" + Session["empcode"] + "' and  date=" + System.DateTime.Now.ToShortDateString() + "";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["cebConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    if ((int)ds.Tables[0].Rows[0][0] > 0)
    //    {
    //        message.InnerHtml = "Your compoff attendance has been already marked for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //        //lbl_time.Text = "Your compoff attendance has been already marked for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //    }
    //    else
    //    {
    //        //bind_shift_time();
    //        try
    //        {
    //           SqlParameter sqlparam = new SqlParameter[8];

    //            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
    //            sqlparam[0].Value = Session["empcode"].ToString();

    //            sqlparam[1] = new SqlParameter("@date", SqlDbType.DateTime);
    //            sqlparam[1].Value = System.DateTime.Now.Date.ToShortDateString();

    //            sqlparam[2] = new SqlParameter("@day", SqlDbType.Int, 4);
    //            sqlparam[2].Value = 1;

    //            sqlparam[3] = new SqlParameter("@status", SqlDbType.Bit);
    //            sqlparam[3].Value = 0;

    //            sqlparam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
    //            sqlparam[4].Value = Convert.ToDateTime(DateTime.Now);

    //            sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
    //            sqlparam[5].Value = Session["name"].ToString();

    //            sqlparam[6] = new SqlParameter("@reason", SqlDbType.VarChar, 1500);
    //            sqlparam[6].Value = txt_reason.Text;

    //            sqlparam[7] = new SqlParameter("@approval_status", SqlDbType.Int);
    //            sqlparam[7].Value = 0;

    //            int a = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["cebConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_insert_marked_compoff_attendance]", sqlparam));

    //            if (a > 0)
    //            {
    //                message.InnerHtml = "Your compoff attendance request has been marked successfully for today";
    //                //lbl_time.Text = "Your compoff attendance request has been marked successfully for today";
    //                mailtoapprover(a);
    //                Button1.Enabled = false;
    //                txt_reason.Text = "";
    //            }
    //            else
    //            {
    //                message.InnerHtml = "There is some problem, please try later";
    //                //lbl_time.Text = "There is some problem, please try later";
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            message.InnerHtml = "There is some problem, please try later";
    //            //lbl_time.Text = "There is some problem, please try later";//Your compoff attendance has been already marked for " + System.DateTime.Now.Date.ToShortDateString() + "";
    //        }
    //    }
    //}

    protected int insert_compoff_mark()         // Changed void to int by Keerti Dwivedi on july 6 2018 for implementing apply compoff mail
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1]=new SqlParameter("@day",SqlDbType.Decimal);
        if (ddl_extrahour.SelectedIndex == 0)
            sqlparam[1].Value = 0.5;
        else
            sqlparam[1].Value = 1;

        sqlparam[2] = new SqlParameter("date", SqlDbType.DateTime);
        sqlparam[2].Value = Utilities.Utility.DateTimeForat(txt_date.Text.Trim().ToString());

        sqlparam[3] = new SqlParameter("@half", SqlDbType.Bit);

        if (ddl_extrahour.SelectedIndex == 0)
            sqlparam[3].Value =0;
        else
            sqlparam[3].Value = 1;


        sqlparam[4] = new SqlParameter("@approval_status", SqlDbType.Int, 3);
        sqlparam[4].Value = 0;

        sqlparam[5] = new SqlParameter("@reason", SqlDbType.VarChar, 1500);
        if (txt_comment.Text != "")
            comment = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now.ToString("dd/MMM/yyyy") + " :</b><br>" + txt_comment.Text + "</h6>";
            //comment = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now.ToString("dd-MMM-yyyy") + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            comment = "";
        // change here also by keerti dwived changed comment to txt_comment at 284 line numb
        sqlparam[5].Value = txt_comment.Text.ToString();

        sqlparam[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[6].Value = Session["name"].ToString();

        int a = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_insert_marked_compoff_attendance]", sqlparam));
        
        if (a > 0)
        {
            message.InnerHtml = "Records has been inserted successfully !";
            // Changed by Keerti Dwivedi on july 6 2018 for implementing apply compoff mail
            return a;
            // upto here
        }
        else
        {
            message.InnerHtml = "You have already marked for Comp-off";
            // Changed by Keerti Dwivedi on july 6 2018 for implementing apply compoff mail
            return a;
            // upto here

        }
    }

    protected void MailToApproverCompOff(int leaveid, string empcode)
    {
        // changed by keerti dwivedi on july 7 
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

                    message.Subject = "Comp-Off Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " marked for " + ds.Tables[0].Rows[0]["no_of_days"].ToString() + " Day(s) of Compensatory off ";
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has marked Compensatory off. The leave details are:<br><table><tr><td>Date(s)</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td></tr></table><br> Reason : " + ds.Tables[0].Rows[0]["reason"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br>";
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
            if (ds.Tables[0].Rows.Count > 0)
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

                message.Subject = "Comp-Off Notification - You Marked for " + ds.Tables[0].Rows[0]["no_of_days"].ToString() + " Day(s) of  Compensatory off ";
                message.IsBodyHtml = true;
                message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has Marked Compensatory off. The leave details are:<br><table><tr><td>Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td></tr></table><br> Reason : <B> " + ds.Tables[0].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApproverCompOff", PageName = "compoff_attendance.aspx.cs", StackTrace = ex.StackTrace });

        }
        // upto here //////////////
    }

    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "approval_status")
        {
            //row.CssClass = "txt02";
            //row.HorizontalAlign = HorizontalAlign.Left;
            //row.Cells[0].Text = "&nbsp;&nbsp; Status : " + row.Cells[0].Text;
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    } 
}
