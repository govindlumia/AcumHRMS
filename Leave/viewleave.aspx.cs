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
        //dd_typeleave.Attributes.Add("onchange", "disablesubmit();");
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            bindemployee_detail();
            fetchleavedata();
        }

    }

    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetching leave data,try latter";
            return;
        }
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["empcode"].ToString();

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

                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).Date < DateTime.Now.Date)
                {
                    txt_cancel.Visible = false;
                }
                else
                {
                    txt_cancel.Visible = true;
                }
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");
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
            }

            if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
            {
                txt_cancel.Visible = false;
                btn_modify.Visible = false;
                Comments.Visible = false;
            }
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/leavedata/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
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
        sqlparm.Value = Session["empcode"].ToString();
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

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //updateleave(0);
        message.InnerHtml = "Leave updated successfully";
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
                case 0: cancelleave(2, 1, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 1: cancelleave(1, 0, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave applied for cancellation successfully");
                    break;
                case 2: cancelleave(2, 1, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave already cancelled");
                    break;
                case 3: cancelleave(3, 1, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                    break;
                case 4: cancelleave(2, 1, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 5: cancelleave(2, 1, status);
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cancelled successfully");
                    break;
                case 6: cancelleave(2, 1, status);
                    Response.Redirect("LeaveapprovalHistory.aspx?leavestatus=0&hr=0&message=Leave cancelled successfully");
                    break;
            }
        }

        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling leave,try latter";
        }
    }
    protected void cancelleave(int leave_status, int status, int leavestatus)
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
            string empcode = Session["empcode"].ToString();
            MailToApprover(leaveid, empcode);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
            int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
            string empcode = Session["empcode"].ToString();
            MailToApprover(leaveid, empcode);
        }


        if (leavestatus.ToString() == "6")
        {
            LeaveBAL balObj = new LeaveBAL();
            string result = balObj.revertCancelLeaveCredit(hidd_leaveapplyid.Value, Session["EmpCode"].ToString());
            if (result.Equals("Error"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Some error occur,try again');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "cancelupdated", "alert(" + result + ");", true);
            }
        }

    }

    protected void btn_modify_Click(object sender, EventArgs e)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("editleave.aspx?q=" + encoded);
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
                    string Subject = "Leave Notification - " + dr["EmpName"].ToString() + " has cancelled the leave request ";
                    message.IsBodyHtml = true;
                    //   message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> <B>Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";

                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                      " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dr["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dr["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                      "<tr><td>Leave Type</td><td>" + dr["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + dr["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + dr["comments"].ToString() + "</td></tr></table>" +
                     "<br/>Thanks,<br />Acuminous Software<br /><br /></div>";


                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    MailScript mail = new MailScript();

                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dr["EmpName"].ToString() + " have cancelled leave. The leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dr["EmailID"].ToString(), Subject, builder.ToString(), null, null);

                }

                string SubjectForSelf = "Leave Notification - you have cancelled the leave ";
                message.IsBodyHtml = true;
                //   message.Body = "Hi " + ds.Tables[0].Rows[0]["ApproverName"].ToString() + " <br> " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " has cancellation their Leave Request. The leave details are:<br><table><tr><td>From Date(s)</td><td>To Date</td></tr><tr><td>" + ds.Tables[0].Rows[0]["fromdate"].ToString() + "</td><td>" + ds.Tables[0].Rows[0]["todate"].ToString() + "</td></tr></table><br>Leave type : " + ds.Tables[0].Rows[0]["leavetype"].ToString() + "<br> <B>Remarks : " + ds.Tables[0].Rows[0]["comments"].ToString() + "<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";

                string tableForSelf = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                   "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                  " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                  "<tr><td>Leave Type</td><td>" + ds.Tables[0].Rows[0]["leavetype"].ToString() + "</td></tr><tr><td>Reason</td><td>" + ds.Tables[0].Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + ds.Tables[0].Rows[0]["comments"].ToString() + "</td></tr></table>" +
                 "<br/>Thanks,<br />Acuminous Software<br /><br /></div>";


                System.Text.StringBuilder builderForSelf = new System.Text.StringBuilder();
                MailScript mailScript = new MailScript();

                builderForSelf.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
           "<h4>Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + "</h4><br />  You have cancelled the leave. The leave details are:     <br /> ");
                builderForSelf.Append(tableForSelf);
                mailScript.sendMailWithFormat(ds.Tables[0].Rows[0]["EmpMailID"].ToString(), SubjectForSelf, builderForSelf.ToString(), null, null);

            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
        }
    }
}
