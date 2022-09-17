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
using System.Globalization;
using System.Net.Mail;
using System.Text;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity.Common;

public partial class leave_applyod : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string comment;
    string message1;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            // bind_empdetail();
            ViewState["UserExist"] = false;
            if (Convert.ToInt32(Session["ApplyLeaveStatus"]) == 1)
            {
                bind_empdetailByEmpCode();
            }
            else
            {
                Session["ApplyLeaveStatus"] = null;
                txt_employee.Attributes.Remove("readonly");
            }
        }
        //this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txt_time'))");
        //this.imgouttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtouttime'))");
    }
    public void bind_empdetailByEmpCode()
    {
        SqlParameter sqlparm = new SqlParameter("@empCode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
        //sqlparm.Value = txt_employee.Text.Trim();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail_forODByEmpcode", sqlparm);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_employee.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txt_employee.Attributes.Add("readonly", "readonly");
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            //HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_category.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            // lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
            {
                lbl_doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();//DateTime.Parse(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            }
            ViewState["UserExist"] = true;
        }
    }

    public void bind_empdetail()
    {
        SqlParameter sqlparm = new SqlParameter("@empName", SqlDbType.VarChar, 100);
        // sqlparm.Value = Session["empcode"].ToString();
        sqlparm.Value = txt_employee.Text.Trim();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail_forOD", sqlparm);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            //HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_category.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            // lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
            {
                lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd-MMM-yyyy");
            }
            ViewState["UserExist"] = true;

        }


    }
    protected void txt_employee_changed(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["ApplyLeaveStatus"]) != 1)
        {
            bind_empdetail();
        }
    }

    protected void btn_sbmit_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(lbl_emp_code.Text))
        {
            if (!validate_dutyroster())
                return;
            if (txt_comment.Text != "")
                comment = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
            else
                comment = "";
            int leavemode;
            DateTime fromdate = new DateTime();
            DateTime todate = new DateTime();
            //DateTime fromtime = new DateTime();
            //DateTime totime = new DateTime();
            DateTime hdate = new DateTime();
            bool half;
            int odid = 0;
            if (divfull.Visible == true)
            {
                divfull.Visible = true;
                divhalf.Visible = false;
                leavemode = 1;
                // fromdate = Utilities.Utility.dataformat(txt_date.Text);
                //   todate = Utilities.Utility.dataformat(txt_ftime.Text);
                fromdate = Convert.ToDateTime(txt_date.Text);
                todate = Convert.ToDateTime(txt_ftime.Text);
                //string StrInTime = txt_time.Text.ToString();


                //fromtime = Convert.ToDateTime(txt_time.Text);
                //totime = Convert.ToDateTime(txtouttime.Text);
                hdate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                half = false;
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                leavemode = 0;
                fromdate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                todate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                //fromtime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                //totime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                hdate = Convert.ToDateTime(txt_select.Text);
                half = opt_first.Checked;
                HiddenField1.Value = Convert.ToString("0.5");
            }
            //Condition for Come from Ess Section or Admin section(Leave or Attandence Section)  
            if (Convert.ToInt32(Session["ApplyLeaveStatus"]) == 1)
            {
                odid = bl_navigation.apply_od(lbl_emp_code.Text, Convert.ToDecimal(HiddenField1.Value), txt_reason.Text, 0, 1, true, true, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), comment.ToString(), leavemode, fromdate, todate, hdate, half, ref i);
            }
            else
            {
                odid= bl_navigation.apply_od(lbl_emp_code.Text, Convert.ToDecimal(HiddenField1.Value), txt_reason.Text, 1, 1, true, true, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), comment.ToString(), leavemode, fromdate, todate, hdate, half, ref i);

            }
            if (i <= 0)
            {
                message.InnerHtml = "Problem applying OD, try again";
            }
            else
            {
                message.InnerHtml = "OD applied successfully";
                MailToApprover(odid, lbl_emp_code.Text);
            }
            clearfield();
        }
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

                    string subjectForSelf = "Leave Notification –You have applied for Out Duty";
                    string subjectForRM = "Leave Notification – " + dt_result.Rows[0]["EmpName"].ToString() + " has applied for Out Duty";
                    string subjectForHC = subjectForRM;
                    string table = "<br/><br/><table><colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 13px verdana, Helvetica, sans-serif; color: #013366;' />" +
                        "<col style='width:65%;background: #f8fbff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />" +
                       " </colgroup><tr><td>From Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr><tr><td>To Date</td><td>" + Convert.ToDateTime(dt_result.Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy") + "</td></tr>" +
                       "<tr><td>Reason</td><td>" + dt_result.Rows[0]["reason"].ToString() + "</td></tr><tr><td>Remark</td><td>" + System.Text.RegularExpressions.Regex.Replace(dt_result.Rows[0]["comments"].ToString(), "<.*?>", string.Empty) + "</td></tr></table>" +
                      "Thanks,<br />Acuminous Software Pvt. Ltd<br /><br /></div>";


                    StringBuilder builder = new StringBuilder();
                    MailScript mail = new MailScript();
                    #region MailtoSelf
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
               "<h4>Hi " + dt_result.Rows[0]["EmpName"].ToString() + "</h4><br /> You have applied for OD Leave. The Leave details are:  <br /> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmpMailID"].ToString(), subjectForSelf, builder.ToString(), null, null);
                    #endregion
                    #region MailtoRM
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:400px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
             "<h4>Hi " + dt_result.Rows[0]["ApproverName"].ToString() + "</h4><br /> " + dt_result.Rows[0]["EmpName"].ToString() + "  has applied for OD Leave<br/>Login to HRMS Portal for Approving/Rejecting the  leave application. The Leave details are:   <br/> <br/> ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt_result.Rows[0]["EmailID"].ToString(), subjectForRM, builder.ToString(), null, null);
                    #endregion
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
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "MailToApprover", PageName = "applyod.aspx.cs", StackTrace = ex.StackTrace });
        }
    }

    protected void clearfield()
    {
        txt_date.Text = "";
        txt_ftime.Text = "";
        txt_reason.Text = "";
        txt_comment.Text = "";
        //txt_time.Text = "";
        //txtouttime.Text = "";
        txt_select.Text = "";
        opt_first.Checked = true;
        opt_second.Checked = false;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }

    protected Boolean validate_dutyroster()
    {
        TimeSpan d1 = new TimeSpan();
        if (divfull.Visible == true)
        {
            DateTime dt1 = DateTime.ParseExact(txt_date.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            //   DateTime dt2 = Convert.ToDateTime(txt_ftime.Text);
            DateTime dt2 = DateTime.ParseExact(txt_ftime.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

        }
        else
        {
            DateTime dt1 = new DateTime();
            dt1 = DateTime.ParseExact(txt_select.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

            d1 = dt1 - dt1;
        }


        //DateTime dt1 = Convert.ToDateTime(txt_date.Text);
        //DateTime dt2 = Convert.ToDateTime(txt_ftime.Text);
        //TimeSpan d1 = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
        if (d1.Days < 0)
        {
            message1 = "End date should be greater than start date.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        //-----------------validate---work roster creation---------------------------------
        DataSet dsdr = new DataSet();

        SqlParameter[] sqlpar = new SqlParameter[3];

        sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlpar[0].Value = Session["empcode"].ToString();

        sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            // sqlpar[1].Value = txt_date.Text;
            // sqlpar[2].Value = txt_ftime.Text;
            sqlpar[1].Value = DateTime.ParseExact(txt_date.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            sqlpar[2].Value = DateTime.ParseExact(txt_ftime.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }
        else
        {
            //  sqlpar[1].Value = txt_select.Text;
            sqlpar[1].Value = DateTime.ParseExact(txt_select.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            sqlpar[2].Value = sqlpar[1].Value;
        }

        dsdr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_leave_dutyroster", sqlpar);

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

    protected void txt_ftime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }

    protected void txt_date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }

    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void opt_second_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            //RequiredFieldValidator2.Enabled = true;
            //RequiredFieldValidator3.Enabled = true;
            //RequiredFieldValidator4.Enabled = false;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            //RequiredFieldValidator2.Enabled = false;
            //RequiredFieldValidator3.Enabled = false;
            //RequiredFieldValidator4.Enabled = true;
        }
    }

    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdohalfday.Checked == true)
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            //RequiredFieldValidator2.Enabled = false;
            //RequiredFieldValidator3.Enabled = false;
            //RequiredFieldValidator4.Enabled = true;
        }
        else
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            //RequiredFieldValidator2.Enabled = true;
            //RequiredFieldValidator3.Enabled = true;
            //RequiredFieldValidator4.Enabled = false;
        }
    }

}
