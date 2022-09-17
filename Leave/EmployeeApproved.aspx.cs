using DataAccessLayer;
using HRMS.BusinessEntity.Common;
using HRMS.BusinessEntity.Leave;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Leave;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_EmployeeApproved : System.Web.UI.Page
{
    EmployeeLeaveStatusBAL employeeLeaveStatusBAL = new EmployeeLeaveStatusBAL();
    EmployeeLeaveStatus employeeLeaveStatus = new EmployeeLeaveStatus();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(',');
        string empcode = arg[0].ToString();
        int leaveid = Convert.ToInt32(arg[1]);
        int btnval = Convert.ToInt32(arg[2]);
        if(btnval==1)
        {
            var updatestatus = employeeLeaveStatusBAL.UpdateUnapprovedEmployee(empcode, leaveid, btnval);
            if (updatestatus == 1)
            {
                MailToApprover(leaveid, empcode);

            }
        }
       
        else
        {
            var updatestatus = employeeLeaveStatusBAL.UpdateUnapprovedEmployee(empcode, leaveid, btnval);
            if (updatestatus == 1)
            {
                MailToReject(leaveid, empcode);
            }
                
           
        }
        BindGrid();
    }

    protected void MailToApprover(int leaveid, string empcode)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "MailDetailOnLeaveSubmit_OD", sqlparm);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_result = ds.Tables[0];

                    string subjectForSelf = "Leave Notification –Your Leave has been approved for OD Leave";
                    // string subjectForSelf = "Leave Notification –You have applied for Out Duty";
                    string subjectForRM = "Leave Notification – " + dt_result.Rows[0]["EmpName"].ToString() + " has approved for OD Leave"; 
                    // subjectForRM = "Leave Notification – " + dt_result.Rows[0]["EmpName"].ToString() + " has applied for Out Duty";
                    string subjectForHC = subjectForRM;
                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                        "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                       "<tr><td>Reason</td><td>" + dt_result.Rows[0]["reason"].ToString() + "</td></tr></table>" +
                      "Thanks,<br />Acuminous Software Pvt. Ltd<br /><br /></div>";


                    StringBuilder builder = new StringBuilder();
                    MailScript mail = new MailScript();
               //     #region MailtoSelf
               //     builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               //"<h4>Hi " + dt_result.Rows[0]["EmpName"].ToString() + "</h4><br /> You have applied for leave. The leave details are:     <br /> ");
               //     builder.Append(table);
               //     mail.sendMailWithFormat(dt_result.Rows[0]["EmpMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
               //     #endregion

                    #region MailtoSelf
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dt_result.Rows[0]["EmpName"].ToString() + "</h4><br /> Your OD Leave have appproved by " + Session["EmpName"].ToString() + ". The Leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmpMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
                    #endregion
                    #region MailtoRM
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
             "<h4>Hi " + dt_result.Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["EmpName"].ToString() + "  has approved for OD Leave<br/>The Leave details are:   <br/> <br/> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmailID"].ToString(), subjectForRM, builder.ToString(), null, null);
                    #endregion

                   //Commented by Keerti Dwivedi Because currently there is No requirement of this Mail
             //       #region MailtoHC
             //       builder.Clear();
             //       builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
             //"<h4>Hi " + dt_result.Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["EmpName"].ToString() + "  has applied for leave. The leave details are:    <br/> ");
             //       builder.Append(table);
             //       mail.sendMailWithFormat(dt_result.Rows[0]["EmailID"].ToString(), subjectForHC, builder.ToString(), null, null);
             //       #endregion

                }
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApprover", PageName = "EmployeeApproved.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    //Added for Reject the WFH by Keerti Dwivedi
    protected void MailToReject(int leaveid, string empcode)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
            sqlparm[1] = new SqlParameter("@empcode", empcode);

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "MailDetailOnLeaveSubmit_OD", sqlparm);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_result = ds.Tables[0];

                    string subjectForSelf = "Leave Notification –Your Leave has been Rejected for OD/WFH Leave";
                    // string subjectForSelf = "Leave Notification –You have applied for Out Duty";
                    string subjectForRM = "Leave Notification – " + dt_result.Rows[0]["EmpName"].ToString() + " has Rejected for OD/WFH Leave";
                    // subjectForRM = "Leave Notification – " + dt_result.Rows[0]["EmpName"].ToString() + " has applied for Out Duty";
                    string subjectForHC = subjectForRM;
                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                        "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                       "<tr><td>Reason</td><td>" + dt_result.Rows[0]["reason"].ToString() + "</td></tr></table>" +
                      "Thanks,<br />Acuminous Software Pvt. Ltd<br /><br /></div>";


                    StringBuilder builder = new StringBuilder();
                    MailScript mail = new MailScript();
                    //     #region MailtoSelf
                    //     builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    //"<h4>Hi " + dt_result.Rows[0]["EmpName"].ToString() + "</h4><br /> You have applied for leave. The leave details are:     <br /> ");
                    //     builder.Append(table);
                    //     mail.sendMailWithFormat(dt_result.Rows[0]["EmpMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
                    //     #endregion

                    #region MailtoSelf
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dt_result.Rows[0]["EmpName"].ToString() + "</h4><br /> Your OD/WFH Leave have Rejected by " + Session["EmpName"].ToString() + ". The Leave details are:     <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmpMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
                    #endregion
                    #region MailtoRM
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
             "<h4>Hi " + dt_result.Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["EmpName"].ToString() + "  has Rejected for OD/WFH Leave<br/>The Leave details are:   <br/> <br/> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmailID"].ToString(), subjectForRM, builder.ToString(), null, null);
                    #endregion

                    //Commented by Keerti Dwivedi Because currently there is No requirement of this Mail
                    //       #region MailtoHC
                    //       builder.Clear();
                    //       builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    //"<h4>Hi " + dt_result.Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["EmpName"].ToString() + "  has applied for leave. The leave details are:    <br/> ");
                    //       builder.Append(table);
                    //       mail.sendMailWithFormat(dt_result.Rows[0]["EmailID"].ToString(), subjectForHC, builder.ToString(), null, null);
                    //       #endregion

                }
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToReject", PageName = "EmployeeApproved.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    
    protected void BindGrid()
    {
        var empcode = Session["empcode"].ToString();
        List<EmployeeLeaveStatus> lst = employeeLeaveStatusBAL.readUnApprovedEmployee(empcode);
        GridView1.DataSource = lst;
        GridView1.DataBind();
    }
}