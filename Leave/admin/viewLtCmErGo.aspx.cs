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
using HRMS.BusinessLogic.Leave;
using System.Net.Mail;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Text;

public partial class View_late_Come_Early_Go : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
        bindGrid();
    }

    private void bindGrid()
    {
        CommonBAL balObj = new CommonBAL();
        DataTable dt_result = balObj.get_late_come_early_go();
        if (dt_result.Rows.Count > 0)
        {
            GrdLateCmEarlyGo.DataSource = dt_result;
            GrdLateCmEarlyGo.DataBind();
        }
        else
        {
            GrdLateCmEarlyGo.DataSource = null;
            GrdLateCmEarlyGo.DataBind();
        }
    }


    protected void GrdLateCmEarlyGo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_date = (Label)e.Row.FindControl("lbl_date");
            Label lbl_intime = (Label)e.Row.FindControl("lbl_intime");
            Label lbl_outtime = (Label)e.Row.FindControl("lbl_outtime");
            try
            {
                if (lbl_date != null && lbl_intime != null && lbl_outtime != null)
                {
                    DateTime date = Convert.ToDateTime(lbl_date.Text);
                    DateTime intime = Convert.ToDateTime(lbl_intime.Text);
                    DateTime outtime = Convert.ToDateTime(lbl_outtime.Text);
                    lbl_date.Text = date.ToString("dd-MMM-yyyy");
                    lbl_intime.Text = (intime.Hour < 10 ? "0" + intime.Hour : intime.Hour.ToString()) + ":" + (intime.Minute < 10 ? "0" + intime.Minute : intime.Minute.ToString()) + ":" + (intime.Second < 10 ? "0" + intime.Second : intime.Second.ToString()) + "";
                    lbl_outtime.Text = (outtime.Hour < 10 ? "0" + outtime.Hour : outtime.Hour.ToString()) + ":" + (outtime.Minute < 10 ? "0" + outtime.Minute : outtime.Minute.ToString()) + ":" + (outtime.Second < 10 ? "0" + outtime.Second : outtime.Second.ToString()) + "";
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
    protected void GrdLateCmEarlyGo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] splitString = e.CommandArgument.ToString().Split(',');
        DataSet ds_result = null;
        if (e.CommandName == "accept")
        {
            // Get ID,Empcode,Date

            if (splitString.Length == 3)
            {
                try
                {
                    CommonBAL balObj = new CommonBAL();
                  ds_result= balObj.update_late_come_early_going_status(Convert.ToInt32(splitString[0]), splitString[1], Session["empcode"].ToString(), true, Convert.ToDateTime(splitString[2]));

                 if (ds_result.Tables.Count > 0)
                 {
                     if(ds_result.Tables[0].Rows.Count>0)
                     ScriptManager.RegisterStartupScript(this, GetType(), "actiontaken", "alert('" + ds_result.Tables[0].Rows[0][0] + "')", true);
                 }
                 //if (ds_result.Tables[1] != null)
                 //{
                 //    if (ds_result.Tables[1].Rows.Count > 0)
                 //    {
                 //        MailToApprover(ds_result.Tables[1]);
                 //    }
                 //}
                    }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Some error occur,try again');", true);
                }
            }
        }
        else if (e.CommandName == "reject")
        {
            if (splitString.Length == 3)
            {
                try
                {
                    CommonBAL balObj = new CommonBAL();
                 ds_result=balObj.update_late_come_early_going_status(Convert.ToInt32(splitString[0]), splitString[1], Session["empcode"].ToString(), false, Convert.ToDateTime(splitString[2]));
                 ScriptManager.RegisterStartupScript(this, GetType(), "actiontaken", "alert('" + ds_result.Tables[0].Rows[0][0] + "')", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Some error occur,try again');", true);
                }
            }
        }
        bindGrid();
    }

    protected void GrdLateCmEarlyGo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLateCmEarlyGo.PageIndex = e.NewPageIndex;
        bindGrid();
    }


    protected void MailToApprover(DataTable dt_result)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();


            if (dt_result.Rows.Count > 0)
                {
                  
                    string subjectForSelf = "Leave Notification –Your leave has been applied and approved for 0.5 Day due to Late Coming/Early Going";
                    string subjectForHC = "Leave notification-" + dt_result.Rows[0]["empName"] + "'s leave has been applied and approved for 0.5 Day due to Late Coming/Early Going";


                    StringBuilder builder = new StringBuilder();
                    MailScript mail = new MailScript();
                    #region MailtoSelf
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dt_result.Rows[0]["empName"].ToString() + "</h4><br /> Your leave have applied and approved by " + Session["EmpName"].ToString() + " due to late coming/early going for date " + dt_result.Rows[0]["applyDate"].ToString() + ". </div> ");
                    //builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["employeeMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
                    #endregion

                    #region MailtoHC
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
             "<h4>Hi " + dt_result.Rows[0]["approverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["empName"].ToString() + "'s leave have applied and approved by " + Session["EmpName"].ToString() + " due to late coming/early going for date " + dt_result.Rows[0]["applyDate"].ToString() + ". </div> ");

                    mail.sendMailWithFormat(dt_result.Rows[0]["approverMailID"].ToString(), subjectForHC, builder.ToString(), null, null);
                    #endregion

                
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Leave Applied successfully,but there is some problem in sending mail.";
        }
    }


}
