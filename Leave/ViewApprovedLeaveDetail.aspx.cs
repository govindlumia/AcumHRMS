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

public partial class Leave_ViewApprovedLeaveDetail : System.Web.UI.Page
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
        DateTime endDate =new DateTime();
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetching leave data,try latter";
            return;
        }
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;

        //("@applyleaveid", Request.QueryString["leaveapplyid"].ToString());
        //@empcode

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
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
                DateTime lblsdate, lbledate;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");
                endDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString());
            
            
            
            }
            else if ((ds.Tables[0].Rows[0]["half"]).ToString() != string.Empty)
            {
                divfull.Visible = false;
                divshort.Visible = false;
                divhalf.Visible = true;
                //commented
                //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
                endDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString());
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = false;
                divshort.Visible = true;
                //commented
                //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                lbl_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_short.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["short"])) ? "In First half" : "In Second half";
                endDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString());
            }




            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/leavedata/" +
                ds.Tables[0].Rows[0]["file_path"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["isCancelAllow"]))
                txt_cancel.Visible = false;
            else
                txt_cancel.Visible = true;
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





        //if (endDate < DateTime.Now)
        //{
        //    txt_cancel.Visible = false;
        //}
        //else
        //    txt_cancel.Visible = true;
    }

    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = hidd_empcode.Value;
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
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        int status;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;
        try
        {

            status = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_confirm_hr", sqlparm));
            switch (status)
            {
                case 0: cancelleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 1: cancelleave(1, 0);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave applied for cancellation successfully");
                    break;
                case 2: cancelleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave already cancelled");
                    break;
                case 3: cancelleave(3, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                    break;
                case 4: cancelleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 5: cancelleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 6: cancelleave(2, 1);
                    Response.Redirect("HRleavehistory.aspx?leavestatus=0&hr=1&message=Leave applied for cancellation successfully");
                    break;
            }
        }

        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling leave,try latter";
        }
    }
    protected void cancelleave(int leave_status, int status)
    {

        SqlParameter[] sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@comments", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<b>Comments added by " + Session["name"].ToString() + " on " + Convert.ToDateTime(DateTime.Now.ToString()).ToString("dd-MMM-yyyy") + " :</b><br>" + txt_comment.Text + "<br>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leave_status;

        sqlparm[4] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[4].Value = status;

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,approvel_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
            int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
            string empcode = hidd_empcode.Value;
            MailToApprover(leaveid, empcode);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
            int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
            string empcode = hidd_empcode.Value;
            returnBalance();
            MailToApprover(leaveid, empcode);
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


    }

    protected void MailToApprover(int leaveid, string empcode)
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

            //if (ds.Tables[0].Rows.Count > 0)
            //{
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

            //        message.Subject = "Leave Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request ";
            //        message.IsBodyHtml = true;
            //        message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> <B>Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                //System.Security.Cryptography.X509Certificates.X509Chain chain,
                //System.Net.Security.SslPolicyErrors sslPolicyErrors)
                //    {
                //        return true;
                //    };
                //    smtpClient.Send(message);
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

            //    message.Subject = "Leave Notification - Cancellation Leave Request ";
            //    message.IsBodyHtml = true;
            //    message.Body = "Hi " + ds.Tables[1].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " has Cancelled Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br>Remarks : <B>" + ds.Tables[1].Rows[0]["comments"].ToString() + "<br> Reason : <B> " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
            //   System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            //System.Security.Cryptography.X509Certificates.X509Chain chain,
            //System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //    {
            //        return true;
            //    };
            //    smtpClient.Send(message);
            //}
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
        }
    }
}