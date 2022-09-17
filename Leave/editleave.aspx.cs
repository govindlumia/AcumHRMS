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
public partial class leave_applyleave : System.Web.UI.Page
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
        
       if(!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            if (q["modify"] != null)
                img_f.Visible=false;
            bindemployee_detail();
            fetchleavedata();
            txt_sdate.Attributes.Add("readonly", "readonly");
            txt_edate.Attributes.Add("readonly", "readonly");
            txt_select.Attributes.Add("readonly", "readonly");
        }
    }

    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetching leave data,try latter";
            return;
        }
        SqlParameter [] sqlparm = new SqlParameter[2];
        sqlparm[0]=new SqlParameter("@applyleaveid",SqlDbType.Int,4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1]=new SqlParameter("@empcode",SqlDbType.VarChar,100);
        sqlparm[1].Value=Session["empcode"].ToString();

        //("@applyleaveid", Request.QueryString["leaveapplyid"].ToString());
        //@empcode
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            hidd_leaveid.Value = ds.Tables[0].Rows[0]["leaveid"].ToString();
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();

               if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
            {
                txt_cancel.Enabled = false;
                btn_submit.Enabled = false;
                btn_reset.Enabled = false;
            }
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
            {
                divfull.Visible = true;
                divhalf.Visible = false;
                divshort.Visible = false;
                txt_sdate.Text=Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("dd-MMM-yyyy");
                txt_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("dd-MMM-yyyy");
            }
            else if ((ds.Tables[0].Rows[0]["half"]).ToString()!= string.Empty)
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                divshort.Visible = false;
                txt_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]).ToString("dd-MMM-yyyy");
                opt_first.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["half"]);
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = false;
                divshort.Visible = true;
                txt_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]).ToString("MM/dd/yyyy");
                opt_inFirst.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["short"]);
            }
            txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            txt_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            hidd_leave_status.Value = ds.Tables[0].Rows[0]["leave_status"].ToString();
            lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/leavedata/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
            prvimg.Value = ds.Tables[0].Rows[0]["file_path"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            //adjustgrid.DataSource = ds.Tables[1];
            //adjustgrid.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[2];
            approvergrid.DataBind();
        }
        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            divshort.Visible = false;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
        }
        else if ((ds.Tables[0].Rows[0]["leavemode"]).ToString() == string.Empty)
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator7.Enabled = false;

        }
        else
        {
            divhalf.Visible = false;
            divfull.Visible = false;
            divshort.Visible = true;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator7.Enabled = true;

        }

        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = hidd_leaveid.Value;

        //sqlstr = "select document_required,halfday_leave_applicable from tbl_leave_employee_customizerule where employeeid='" + Session["empcode"].ToString() + "' and leaveid='" + dd_typeleave.SelectedValue + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);
        if (ds.Tables[0].Rows.Count < 1)
            return;

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]) != false)
        {
            RequiredFieldValidator1.Enabled = true;
            RegularExpressionValidator1.Enabled = true;
            upload_attach.Enabled = true;
        }
        else
        {
            RequiredFieldValidator1.Enabled = false;
            RegularExpressionValidator1.Enabled = false;
            upload_attach.Enabled = false;
        }
    }

    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
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

            //adjustgrid.DataSource = null;
            //adjustgrid.DataBind();
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

    protected void txt_cancel_Click(object sender, EventArgs e)
    {
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Page.Validate("calculate");
        Page.Validate("all");
        if (!Page.IsValid)
            return;
        if (!validateapplyleave())
            return;
        if (txt_nod.Text=="0")
            return;


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
                case 0: updateapplyleave(0, 1);
                    updateadjustment();
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Updated Successfully");
                    break;
                case 1: updateapplyleave(1, 2);
                    updateadjustment();
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave applied for modification successfully");
                    break;
                case 2: updateapplyleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be modified,its already in cancel status");
                    break;
                case 3: updateapplyleave(3, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be modified,its already in rejected status");
                    break;
                case 4: updateapplyleave(0, 1);
                    updateadjustment();
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Updated Successfully");
                    break;
                case 5: updateapplyleave(0, 1);
                    updateadjustment();
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Updated Successfully");
                    break;
                case 6: updateapplyleave(6, 2);
                    updateadjustment();
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave applied for modification successfully");
                    break;
            }
        }

        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling leave,try latter";
        }
    }


    protected int updateapplyleave(int leavestatus,int status)
    {
        query q = new query();
        if (q["modify"] != null)
        {
            sqlstr = "DELETE FROM tbl_leave_modify_applied_leave WHERE apply_leave_id=" + hidd_leaveapplyid.Value;
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            //sqlstr = "insert into tbl_leave_modify_leave select apply_leave_id,leaveid,leavename,days from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
            sqlstr = "insert into tbl_leave_modify_applied_leave select id,leaveid,leavemode,fromdate,todate,hdate,no_of_days,half,reason,file_path,leave_adjusted from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }

        SqlParameter[] sqlparm = new SqlParameter[17];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = hidd_leaveid.Value.ToString();

        sqlparm[2] = new SqlParameter("@leavemode", SqlDbType.Bit, 1);

        sqlparm[3] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);

        sqlparm[4] = new SqlParameter("@todate", SqlDbType.DateTime, 8);

        sqlparm[5] = new SqlParameter("@hdate", SqlDbType.DateTime, 8);

        sqlparm[6] = new SqlParameter("@no_of_days", SqlDbType.Decimal);
        sqlparm[6].Value = txt_nod.Text;

        sqlparm[7] = new SqlParameter("@half", SqlDbType.Bit, 1);

        sqlparm[8] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
        sqlparm[8].Value = txt_reason.Text;

        sqlparm[9] = new SqlParameter("@file_path", SqlDbType.VarChar, 100);
        if (RegularExpressionValidator1.Enabled == true)
        {
            string filename;
            filename = System.IO.Path.GetFileName(upload_attach.PostedFile.FileName.ToString());
            if (filename != "")
            {
                upload_attach.PostedFile.SaveAs(Server.MapPath(".") + "/upload/" + filename);
                if (prvimg.Value != "")
                    System.IO.File.Delete(Server.MapPath(".") + "/upload/" + prvimg.Value);
            }
            else
            {
                filename = prvimg.Value;
            }
            sqlparm[9].Value = filename;
        }
        else
            sqlparm[9].Value = "";

        sqlparm[10] = new SqlParameter("@leave_adjusted", SqlDbType.Bit, 1);
        sqlparm[10].Value = 1;

        sqlparm[11] = new SqlParameter("@approvel_status", SqlDbType.Int, 4);
        sqlparm[11].Value = 0;

        sqlparm[12] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[12].Value = leavestatus;

        sqlparm[13] = new SqlParameter("@comments", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[13].Value = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[13].Value = "";


        sqlparm[14] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[14].Value = Session["name"].ToString();

        sqlparm[15] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[15].Value = hidd_leaveapplyid.Value;

        sqlparm[16] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[16].Value = status;


        if (divfull.Visible == true)
        {
            sqlparm[2].Value = 1;
            sqlparm[3].Value = Utility.DateTimeForat(txt_sdate.Text);
            sqlparm[4].Value = Utility.DateTimeForat(txt_edate.Text);
            sqlparm[5].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[7].Value = System.Data.SqlTypes.SqlByte.Null;
        }
        else
        {
            sqlparm[2].Value = 0;
            sqlparm[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[5].Value = Utility.DateTimeForat(txt_select.Text);
            sqlparm[7].Value = opt_first.Checked;
        }
        return Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_updateapplyleave", sqlparm));
        
       
        
    }
    protected void updateadjustment()
    {
        query q = new query();
        if (q["modify"] != null)
        {
            sqlstr = "DELETE FROM tbl_leave_modify_leave where apply_leave_id=" + hidd_leaveapplyid.Value;
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            sqlstr = "insert into tbl_leave_modify_leave select apply_leave_id,leaveid,leavename,days from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }

        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //SqlParameter[] sqlparm;
        //for (int i = 0; adjustgrid.Rows.Count > i; i++)
        //{
        //    sqlparm = new SqlParameter[5];

        //    sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
        //    sqlparm[0].Value = hidd_leaveapplyid.Value;

        //    sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        //    sqlparm[1].Value = adjustgrid.DataKeys[i].Value;

        //    sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
        //    sqlparm[2].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text;

        //    sqlparm[3] = new SqlParameter("@status", SqlDbType.Bit, 1);
        //    sqlparm[3].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text;

        //    sqlparm[4] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
        //    sqlparm[4].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text;

        //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_saveleaveadjustment", sqlparm);
            int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
            string empcode = Session["empcode"].ToString();
            MailToApprover(leaveid, empcode);
        
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

                    message.Subject = "Leave Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " applied for " + ds.Tables[0].Rows[0]["no_of_days"].ToString() + " Day(s) of " + ds.Tables[0].Rows[0]["leavetype"].ToString() + " ";
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has applied for leave. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br>Remarks : <B>" + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                    //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                    //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    //System.Security.Cryptography.X509Certificates.X509Chain chain,
                    //System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    //{
                    //    return true;
                    //};
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

                message.Subject = "Leave Notification - You applied for " + ds.Tables[1].Rows[0]["no_of_days"].ToString() + " Day(s) of " + ds.Tables[1].Rows[0]["leavetype"].ToString() + " ";
                message.IsBodyHtml = true;
                message.Body = "Hi " + ds.Tables[1].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " has applied for leave. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br>Remarks : <B>" + ds.Tables[1].Rows[0]["comments"].ToString() + "<br> Reason : <B> " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                //System.Security.Cryptography.X509Certificates.X509Chain chain,
                //System.Net.Security.SslPolicyErrors sslPolicyErrors)
                //    {
                //        return true;
                //    };
                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bindemployee_detail();
        fetchleavedata();
        btn_submit.Enabled = true;
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        //updateleave(2);
        //message.InnerHtml = "Leave Cancelled Successfully";
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
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Cancelled Successfully");
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
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Cancelled Successfully");
                    break;
                case 5: cancelleave(2, 1);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave Cancelled Successfully");
                    break;
                case 6: cancelleave(6, 0);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave applied for cancellation successfully");
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
            sqlparm[0].Value = "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>";
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
            string empcode = Session["empcode"].ToString();
            MailToApprovercancellation(leaveid, empcode);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
            int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
            string empcode = Session["empcode"].ToString();
            MailToApprovercancellation(leaveid, empcode);
        }

    }


    protected void MailToApprovercancellation(int leaveid, string empcode)
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

                    message.Subject = "Leave Notification - " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request ";
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> <B>Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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

                message.Subject = "Leave Notification - Cancellation Leave Request ";
                message.IsBodyHtml = true;
                message.Body = "Hi " + ds.Tables[1].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " has Cancelled Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[1].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[1].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[1].Rows[0]["leavetype"].ToString() + "<br>Remarks : <B>" + ds.Tables[1].Rows[0]["comments"].ToString() + "<br> Reason : <B> " + ds.Tables[1].Rows[0]["reason"].ToString() + " <br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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
        }
    }
    protected Boolean validateapplyleave()
    {
        //sqlstr = "select days_before_leaveapply,minimum_no_days,maximum_no_days,document_required,backdate_leave_applicable,backdate_howmany_days,holidays_counted_asleave,halfday_leave_applicable from tbl_leave_employee_customizerule where employeeid='" + Session["empcode"].ToString() + "' and leaveid='" + hidd_leaveid.Value + "'";
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = hidd_leaveid.Value;

        //sqlstr = "select days_before_leaveapply,minimum_no_days,maximum_no_days,document_required,backdate_leave_applicable,backdate_howmany_days,holidays_counted_asleave,halfday_leave_applicable from tbl_leave_employee_customizerule where employeeid='" + Session["empcode"].ToString() + "' and leaveid='" + dd_typeleave.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);

        if (!valdiate_leave(ds))
        {
            txt_nod.Text = "0";
            btn_submit.Enabled = true;
            //adjustgrid.DataSource = null;
            //adjustgrid.DataBind();
            return false;
        }
        sqlparm = new SqlParameter[12];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = hidd_leaveid.Value.ToString();

        sqlparm[2] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[3] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);

        if (divfull.Visible == true)
        {
            sqlparm[2].Value = Utility.DateTimeForat(txt_sdate.Text);
            sqlparm[3].Value = Utility.DateTimeForat(txt_edate.Text);
        }
        else if (divhalf.Visible == true)
        {
            sqlparm[2].Value = Utility.DateTimeForat(txt_select.Text);
            sqlparm[3].Value = Utility.DateTimeForat(txt_select.Text);
        }
        else
        {
            sqlparm[2].Value = Utility.DateTimeForat(txt_selectSh.Text);
            sqlparm[3].Value = Utility.DateTimeForat(txt_selectSh.Text);
        }

        sqlparm[4] = new SqlParameter("@branch", SqlDbType.Int, 4);
        sqlparm[4].Value = Session["Category"].ToString();

        sqlparm[5] = new SqlParameter("@holidayallowed", SqlDbType.Bit, 1);
        sqlparm[5].Value = Convert.ToBoolean(ds.Tables[0].Rows[0]["holidays_counted_asleave"]);

        sqlparm[6] = new SqlParameter("@maxday", SqlDbType.Int, 4);
        sqlparm[6].Value = ds.Tables[0].Rows[0]["maximum_no_days"].ToString();

        sqlparm[7] = new SqlParameter("@minday", SqlDbType.Int, 4);
        sqlparm[7].Value = ds.Tables[0].Rows[0]["minimum_no_days"].ToString();

        sqlparm[8] = new SqlParameter("@halfday", SqlDbType.Bit, 1);

        if (divfull.Visible == true)
            sqlparm[8].Value = false;
        else
            sqlparm[8].Value = true;

        sqlparm[9] = new SqlParameter("@leave", SqlDbType.VarChar, 100);
        sqlparm[9].Value = lbl_leave.Text;

        sqlparm[10] = new SqlParameter("@weeklyoff", SqlDbType.Bit, 1);
        sqlparm[10].Value = ds.Tables[0].Rows[0]["weekly_off"].ToString();

        sqlparm[11] = new SqlParameter("@id", SqlDbType.Int);
        if (Convert.ToInt16(hidd_leave_status.Value) == 6)
            sqlparm[11].Value = hidd_leaveapplyid.Value;
        else
            sqlparm[11].Value = 0;
       // sqlparm[12] = new SqlParameter("@Shortday", SqlDbType.Bit, 1);

        //if (divfull.Visible == true)
        //    sqlparm[12].Value = false;
        //else if (divhalf.Visible == true)
        //    sqlparm[12].Value = false;
        //else
        //    sqlparm[12].Value = true;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleave", sqlparm);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {

            btn_submit.Enabled = false;
            txt_nod.Text = "0";
            //adjustgrid.DataSource = null;
            //adjustgrid.DataBind();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds.Tables[0].Rows[0][1].ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + ds.Tables[0].Rows[0][1].ToString() + "')</script>");
            return false;
        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "1")
        {
            txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            hidden_leave.Value = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            //adjustgrid.DataSource = ds.Tables[1];
            //adjustgrid.DataBind();

        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "2")
        {

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds.Tables[0].Rows[0]["message"].ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + ds.Tables[0].Rows[0]["message"].ToString() + "')</script>");
            txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            hidden_leave.Value = ds.Tables[0].Rows[0]["leave"].ToString();
            //adjustgrid.DataSource = ds.Tables[1];
            //adjustgrid.DataBind();


        }


        btn_submit.Enabled = true;
        return true;
    }

    protected void btn_calc_Click(object sender, EventArgs e)
    {
        if (!validate_dutyroster())
            return;

        if (validate_applydate())
        {
            validateapplyleave();
        }
        else
        {
        }   
        
    }

    protected void Calculate()
    {
        if (divfull.Visible == true)
        {
            if (!string.IsNullOrEmpty(txt_sdate.Text) && !string.IsNullOrEmpty(txt_edate.Text))
            {
                if (!validate_dutyroster())
                    return;

                 if (validate_applydate())
                    {
                        validateapplyleave();
                    }
               
                    else
                    {
                        return;
                    }
               
            }
        }
        else if (divhalf.Visible == true)
        {
            if (!string.IsNullOrEmpty(txt_select.Text))
            {
                if (!validate_dutyroster())
                    return;

              
                    if (validate_applydate())
                    {
                        validateapplyleave();
                    }
                    else
                    {
                        return;
                    }
                }
        }
        else
            if (!string.IsNullOrEmpty(txt_selectSh.Text))
            {
                if (!validate_dutyroster())
                    return;

               
                    if (validate_applydate())
                    {
                        validateapplyleave();
                    }
                    else
                    {
                        return;
                    }
               
            }

    }
    protected void txt_edate_TextChanged(object sender, EventArgs e)
    {
        Calculate();
    }
    protected Boolean valdiate_leave(DataSet ds)
    {


        //int i = 0;
        if (ds.Tables[0].Rows.Count < 1)
        {
            message1 = "Leave Rule not defined,contact administrator";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return false;
        }

        DateTime sdate;
        if (divfull.Visible == true)
            sdate = Utility.DateTimeForat(txt_sdate.Text.ToString());
        else
            sdate = Utility.DateTimeForat(txt_select.Text.ToString());

        TimeSpan ts = sdate - DateTime.Now;

        if (Convert.ToInt16(ts.TotalDays) >= 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0]["days_before_leaveapply"]) > Convert.ToInt16(Math.Abs(ts.TotalDays)))
            {
                message1 = "You can only apply leave before  " + ds.Tables[0].Rows[0]["days_before_leaveapply"].ToString() + " days";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                return false;
            }
        }
        else
        {

            if (!Convert.ToBoolean(ds.Tables[0].Rows[0]["backdate_leave_applicable"]))
            {
                if (sdate < DateTime.Today)
                {
                    message1 = "Back Date leave applying not allowed for " + lbl_leave.Text;
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                    return false;
                }
            }
            else
            {
                //ts = DateTime.Now - Convert.ToDateTime(txt_sdate.Text);
                if (Convert.ToInt16(ds.Tables[0].Rows[0]["backdate_howmany_days"]) < Convert.ToInt16(Math.Abs(ts.TotalDays)))
                {
                    message1 = "Maximum back day leave allowed is  " + ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                    return false;
                }
            }
        }
        //if (i == 1)
        //{
        //    Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
        //    return false;
        //}
        //else
        return true;
    }
    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = false;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = true;
        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdohalfday.Checked == true)
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = true;
        }
        else
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = false;
        }
    }
    protected void rdoShortday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoShortday.Checked == true)
        {
            divshort.Visible = true;
            divhalf.Visible = false;
            divfull.Visible = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator7.Enabled = true;
        }
        else
        {
            divshort.Visible = false;
            divhalf.Visible = true;
            divfull.Visible = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator7.Enabled = false;
        }
    }
    protected void opt_inFirst_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    protected void opt_inSecond_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    protected void reset()
    {
        btn_submit.Enabled = false;

        RequiredFieldValidator1.Enabled = true;
        RegularExpressionValidator1.Enabled = true;

        divfull.Visible = true;
        divhalf.Visible = false;

        //adjustgrid.DataSource = null;
        //adjustgrid.DataBind();

        txt_edate.Text = "";
        txt_sdate.Text = "";
        txt_select.Text = "";
        txt_reason.Text = "";
        txt_nod.Text = "0";
        txt_comment.Text = "";
    }

    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void opt_second_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void txt_selectSh_TextChanged(object sender, EventArgs e)
    {
        
    }

    //--------------------------Validation for LEAVE PERIOD & DUTY ROSTER--------------------------------

    protected Boolean validate_dutyroster()
    {
        if (divfull.Visible == true)
        {
            DateTime ts1 = Convert.ToDateTime(txt_edate.Text);
            DateTime ts2 = Convert.ToDateTime(txt_sdate.Text);

            TimeSpan ts = ts1 - ts2;
            txt_nod.Text = Convert.ToString(ts.Days);
            if (ts.Days < 0)
            {
                //adjustgrid.DataSource = null;
                //adjustgrid.DataBind();
                txt_nod.Text = "0";

                message1 = "End date should be greater than start date.";
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                return false;
            }
            ////-----------------validate---cant apply for different year leaves at a time,hv to submit separate application---------------------
            //if (ts1.Year != ts2.Year)
            //{
            //    message1 = "You can only apply for leave having leave period in a same year.";
            //    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //    return false;
            //}
        }

        //-----------------validate---cant apply for back year---------------------

        DateTime dt = new DateTime();

        if (divfull.Visible == true)
            dt = Convert.ToDateTime(txt_sdate.Text);
        else
            dt = Convert.ToDateTime(txt_select.Text);

        //if (dt.Year < DateTime.Now.Year)
        //{
        //    message1 = "You can not apply for back year leave.";
        //    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
        //    return false;
        //}

        //-----------------validate---cant apply for next to next year---------------------

        //else if (dt.Year > DateTime.Now.AddYears(1).Year)
        //{
        //    message1 = "You can not apply for next to next year leave.";
        //    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
        //    return false;
        //}

        //-----------------validate---work roster creation---------------------------------

        DataSet dsdr = new DataSet();

        SqlParameter[] sqlpar = new SqlParameter[3];

        sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlpar[0].Value = Session["empcode"].ToString();

        sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlpar[1].Value = txt_sdate.Text;
            sqlpar[2].Value = txt_edate.Text;
        }
        else
        {
            sqlpar[1].Value = txt_select.Text;
            sqlpar[2].Value = txt_select.Text;
        }

        dsdr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_leave_dutyroster", sqlpar);

        txt_nod.Text = dsdr.Tables[0].Rows[0]["drdays"].ToString();
        if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) > 0)
        {
            if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) != Convert.ToInt32(dsdr.Tables[1].Rows[0]["applieddays"].ToString()))
            {
                message1 = "Your work roster is not created for this date span.Please contact your Manager.";
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                return false;
            }
        }
        else
        {
            message1 = "Your work roster is not created for this date span.Please contact your Manager.";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return false;
        }
        return true;
    }

    protected Boolean validate_applydate()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlparam[1].Value = Utility.DateTimeForat(txt_sdate.Text);
            sqlparam[2].Value = Utility.DateTimeForat(txt_edate.Text);
        }
        else
        {
            sqlparam[1].Value = Utility.DateTimeForat(txt_select.Text);
            sqlparam[2].Value = Utility.DateTimeForat(txt_select.Text);
        }

        sqlparam[3] = new SqlParameter("@leaveid", SqlDbType.Int);
        sqlparam[3].Value = hidd_leaveapplyid.Value;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_modified_applied_date", sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_nod.Text = "0";
            //adjustgrid.DataSource = null;
            //adjustgrid.DataBind();
            message1 = "You have already applied for leave during this span! Please check application status";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return false;
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_nod.Text = "0";
                //adjustgrid.DataSource = null;
                //adjustgrid.DataBind();
                message1 = "You have already applied for Compoff during this span! Please check application status";
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                return false;
            }
            else
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_nod.Text = "0";
                    //adjustgrid.DataSource = null;
                    //adjustgrid.DataBind();
                    message1 = "You have already applied for OD during this span! Please check application status";
                    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                    return false;
                }
                else
                {
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        message1 = "Your leave profile is not created! Please contact your Manager";
                        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                        return false;
                    }
                }
            }
        }
    }
}