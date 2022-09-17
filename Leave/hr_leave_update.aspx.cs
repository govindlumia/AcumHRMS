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
using System.Net.Mail;
using Utilities;

public partial class leave_hr_leave_update : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            //bindemployee_detail();
        }
    }

    //protected void bindemployee_detail()
    //{
    //    SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
    //    sqlparm.Value = txt_employee.Text.ToString();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
    //    lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
    //    lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
    //    lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //    HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //    lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
    //    lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
    //    lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
    //    lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
    //    lbl_doj.Text = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
    //    adjustgrid.DataSource = null;
    //    adjustgrid.DataBind();
    //}

    protected void dd_typeleave_DataBound(object sender, EventArgs e)
    {
        dd_typeleave.Items.Insert(0, new ListItem("Select leave", "100"));
    }

    protected void dd_typeleave_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!validate_gender())
        //    return;

        if (dd_typeleave.SelectedIndex == 0)
        {
            div.Visible = false;
            divhalf.Visible = false;
            divfull.Visible = true;
        }

        btn_submit.Enabled = false;
        txt_sdate.Text = "";
        txt_edate.Text = "";
        txt_nod.Text = "0";
        adjustgrid.DataSource = null;
        adjustgrid.DataBind();
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_employee.Text.ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = dd_typeleave.SelectedValue;

        //sqlstr = "select document_required,halfday_leave_applicable from tbl_leave_employee_customizerule where employeeid='" + txt_employee.Text.ToString() + "' and leaveid='" + dd_typeleave.SelectedValue + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);
        if (ds.Tables[0].Rows.Count < 1)
            return;

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]) != false)
        {
            //RequiredFieldValidator1.Enabled = true;
            //RegularExpressionValidator1.Enabled = true;
            upload_attach.Enabled = true;
        }
        else
        {
            //RequiredFieldValidator1.Enabled = false;
            //RegularExpressionValidator1.Enabled = false;
            upload_attach.Enabled = false;
        }

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["halfday_leave_applicable"]))
        {
            div.Visible = true;
            divhalf.Visible = false;
            divfull.Visible = true;
            rdofullday.Checked = true;
            rdohalfday.Checked = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = true;
        }
        else
        {
            div.Visible = false;
            divhalf.Visible = false;
            divfull.Visible = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = false;
        }
    }

    protected int insertapplyleave(int status)
    {
        SqlParameter[] sqlparm = new SqlParameter[17];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_employee.Text.ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = dd_typeleave.SelectedValue;

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
        //if (RegularExpressionValidator1.Enabled == true)
        //{
        //    string filename;

        //    filename = System.IO.Path.GetFileName(upload_attach.PostedFile.FileName.ToString());
        //    if (filename != "")
        //    {
        //        upload_attach.PostedFile.SaveAs(Server.MapPath(".") + "/upload/" + filename);
        //    }
        //    sqlparm[9].Value = filename;
        //}
        //else
        sqlparm[9].Value = "";

        sqlparm[10] = new SqlParameter("@leave_adjusted", SqlDbType.Bit, 1);
        sqlparm[10].Value = (adjustgrid.Rows.Count > 1) ? 1 : 0;

        sqlparm[11] = new SqlParameter("@approvel_status", SqlDbType.Int, 4);
        sqlparm[11].Value = 6;

        sqlparm[12] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[12].Value = status;
        if (txt_comment.Text != "")
        {
            txt_comment.Text = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        }

        sqlparm[13] = new SqlParameter("@comments", SqlDbType.VarChar, 2000);
        sqlparm[13].Value = txt_comment.Text;

        sqlparm[14] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparm[14].Value = Session["name"].ToString();

        sqlparm[15] = new SqlParameter("@createddate", SqlDbType.DateTime, 8);
        sqlparm[15].Value = DateTime.Now;

        sqlparm[16] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[16].Value = Session["name"].ToString();

        if (divfull.Visible == true)
        {
            sqlparm[2].Value = 1;
            sqlparm[3].Value = Utility.dataformat(txt_sdate.Text);
            sqlparm[4].Value = Utility.dataformat(txt_edate.Text);
            sqlparm[5].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[7].Value = System.Data.SqlTypes.SqlByte.Null;
        }
        else
        {
            sqlparm[2].Value = 0;
            sqlparm[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparm[5].Value = txt_select.Text;
            sqlparm[7].Value = opt_first.Checked;
        }
        return Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_applyleave", sqlparm));
    }

    protected void insertadjustment(int applyleaveid)
    {
        SqlParameter[] sqlparm;
        for (int i = 0; adjustgrid.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
            sqlparm[0].Value = applyleaveid;

            sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[1].Value = adjustgrid.DataKeys[i].Value;

            sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[2].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text;

            sqlparm[3] = new SqlParameter("@status", SqlDbType.Bit, 1);
            sqlparm[3].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text;

            sqlparm[4] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
            sqlparm[4].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text;

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_saveleaveadjustment", sqlparm);
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Page.Validate("calculate");
        Page.Validate("all");
        if (!Page.IsValid)
            return;
        if (!validateapplyleave())
            return;
        if (txt_nod.Text == "0")
            return;
        try
        {
            int leaveid = insertapplyleave(1);
            insertadjustment(leaveid);
            // mailtoapprover(leaveid, "l");
            //Response.Redirect("leave_status.aspx?leavestatus=0");
            //reset();
            updatependingleave(leaveid);
            updateleaveapplication(6, 1, leaveid);
            updatebackmonth(leaveid);
            message.InnerHtml = "Leave applied and updated by HR successfully";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem applying leave,try latter";
        }
    }

    protected void mailtoapprover(int leaveid, string type)
    {
        string url;
        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();

        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
        sqlparm[1] = new SqlParameter("@type", type);
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            query q = new query();
            string pairs = String.Format("leaveapplyid={0}&empcode={1}&approvercode={2}&hr={3}&type={4}", ds.Tables[0].Rows[0]["id"].ToString(), ds.Tables[0].Rows[0]["empcode"].ToString(), ds.Tables[0].Rows[0]["approvercode"].ToString(), ds.Tables[0].Rows[0]["hr"].ToString(), ds.Tables[0].Rows[0]["type"].ToString());
            string encoded;
            encoded = q.EncodePairs(pairs);

            //url = "<a href='http://192.168.1.8/ceb/leavedetail.aspx?q=" + encoded + "'>http://192.168.1.8/ceb/leavedetail.aspx</a>";

            url = "<a href='" + ConfigurationManager.AppSettings["url"].ToString() + "/leavedetail.aspx?q=" + encoded + "'>" + ConfigurationManager.AppSettings["url"].ToString() + "/leavedetail.aspx?q=" + encoded + "</a>";


            MailAddress fromadd = new MailAddress(Session["email"].ToString());
            smtpClient.Host = "localhost";
            smtpClient.Port = 25;
            message.To.Add(ds.Tables[0].Rows[0]["email_id"].ToString());
            message.From = fromadd;
            message.Subject = "Application submitted";
            message.IsBodyHtml = true;
            message.Body = "Dear " + ds.Tables[0].Rows[0]["a_name"].ToString() + "<br><br>Click link below to approve leave<br><br>" + url;
            smtpClient.Send(message);
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        //reset();
        ////upload_attach.PostedFile = "";
    }

    protected Boolean validateapplyleave()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_employee.Text.ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = dd_typeleave.SelectedValue;

        //sqlstr = "select days_before_leaveapply,minimum_no_days,maximum_no_days,document_required,backdate_leave_applicable,backdate_howmany_days,holidays_counted_asleave,halfday_leave_applicable from tbl_leave_employee_customizerule where employeeid='" + txt_employee.Text.ToString() + "' and leaveid='" + dd_typeleave.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);
        if (!valdiate_leave(ds))
        {
            txt_nod.Text = "0";
            btn_submit.Enabled = true;
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
            return false;
        }
        sqlparm = new SqlParameter[12];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_employee.Text.ToString();

        sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlparm[1].Value = dd_typeleave.SelectedValue;

        sqlparm[2] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[3] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);

        if (divfull.Visible == true)
        {
            sqlparm[2].Value = Utility.dataformat(txt_sdate.Text);
            sqlparm[3].Value = Utility.dataformat(txt_edate.Text);
        }
        else
        {
            sqlparm[2].Value = Utility.dataformat(txt_select.Text);
            sqlparm[3].Value = Utility.dataformat(txt_select.Text);
        }

        sqlparm[4] = new SqlParameter("@branch", SqlDbType.Int, 4);
        sqlparm[4].Value = Session["branch"].ToString();

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
        sqlparm[9].Value = dd_typeleave.SelectedItem.Text;

        sqlparm[10] = new SqlParameter("@weeklyoff", SqlDbType.Bit, 1);
        sqlparm[10].Value = ds.Tables[0].Rows[0]["weekly_off"].ToString();

        sqlparm[11] = new SqlParameter("@id", SqlDbType.Int);
        sqlparm[11].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validateleave", sqlparm);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            btn_submit.Enabled = false;
            txt_nod.Text = "0";
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds.Tables[0].Rows[0][1].ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + ds.Tables[0].Rows[0][1].ToString() + "')</script>");
            return false;
        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "1")
        {
            txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            hidden_leave.Value = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            adjustgrid.DataSource = ds.Tables[1];
            adjustgrid.DataBind();
        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "2")
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds.Tables[0].Rows[0]["message"].ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + ds.Tables[0].Rows[0]["message"].ToString() + "')</script>");
            txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            hidden_leave.Value = ds.Tables[0].Rows[0]["leave"].ToString();
            adjustgrid.DataSource = ds.Tables[1];
            adjustgrid.DataBind();
        }
        btn_submit.Enabled = true;
        return true;
    }

    protected void btn_calc_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (!validate_dutyroster())
                return;
            if (validate_applydate())
            {
                validateapplyleave();
            }
        }
    }

    //protected Boolean validate_gender()
    //{
    //    if (HiddenField_gender.Value == "Male" && Convert.ToInt32(dd_typeleave.SelectedValue) == 6)
    //    {
    //        message1 = "Please review the type of leave";
    //        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //        return false;
    //    }
    //    //else if (HiddenField_gender.Value == "Female" && Convert.ToInt32(dd_typeleave.SelectedValue) == 6)
    //    //{
    //    //    message1 = "Please review the type of leave";
    //    //    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //    //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //    //    return false;
    //    //}
    //    return true;
    //}


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
            sdate = Utility.dataformat(txt_sdate.Text);
        else
            sdate = Utility.dataformat(txt_select.Text);

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
                    message1 = "Back Date leave applying not allowed for " + dd_typeleave.SelectedItem.Text;
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

    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void opt_second_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void reset()
    {
        btn_submit.Enabled = false;
        
        //RequiredFieldValidator1.Enabled = true;
        //RegularExpressionValidator1.Enabled = true;
        divhalf.Visible = false;
        divfull.Visible = true;
        RequiredFieldValidator2.Enabled = true;
        RequiredFieldValidator3.Enabled = true;
        RequiredFieldValidator4.Enabled = false;

        //RequiredFieldValidator1.Enabled = false;
        //RegularExpressionValidator1.Enabled = false;
        upload_attach.Enabled = false;
        divfull.Visible = true;
        divhalf.Visible = false;

        adjustgrid.DataSource = null;
        adjustgrid.DataBind();

        txt_edate.Text = "";
        txt_sdate.Text = "";
        txt_select.Text = "";
        txt_reason.Text = "";
        txt_nod.Text = "0";
        txt_comment.Text = "";
        dd_typeleave.SelectedIndex = -1;
    }

    protected void btn_draftl_Click(object sender, EventArgs e)
    {
        //Page.Validate("calculate");
        //Page.Validate("all");
        //if (!Page.IsValid)
        //    return;
        //try
        //{
        //    insertadjustment(insertapplyleave(5));
        //    Response.Redirect("leave_status.aspx?leavestatus=5");
        //    //reset();
        //    //message.InnerHtml = "Leave saved as draft";
        //}
        //catch (Exception ex)
        //{
        //    message.InnerHtml = "Problem saving,try latter";
        //}
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

    //--------------------------Validation for LEAVE PERIOD & DUTY ROSTER--------------------------------

    protected Boolean validate_dutyroster()
    {
        if (divfull.Visible == true)
        {
            DateTime ts1 = Convert.ToDateTime(txt_edate.Text);
            DateTime ts2 = Convert.ToDateTime(txt_sdate.Text);

            TimeSpan ts = ts1 - ts2;

            if (ts.Days < 0)
            {
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
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

        ////-----------------validate---cant apply for next to next year---------------------

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
        sqlpar[0].Value = txt_employee.Text.ToString();

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
        SqlParameter[] sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlparam[1].Value = txt_sdate.Text;
            sqlparam[2].Value = txt_edate.Text;
        }
        else
        {
            sqlparam[1].Value = txt_select.Text;
            sqlparam[2].Value = txt_select.Text;
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_nod.Text = "0";
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
            message1 = "You have already applied leave during this span! Please check application status";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return false;
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_nod.Text = "0";
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
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
                    adjustgrid.DataSource = null;
                    adjustgrid.DataBind();
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

    /// <summary>
    /// This code is used to update leave by HR.
    /// </summary>
    /// <param name="leavestatus"></param>
    /// <param name="status"></param>
    /// <param name="leaveid"></param>
    protected void updateleaveapplication(int leavestatus, int status, int leaveid)
    {
        int approverstatus;
        sqlstr = "SELECT approverpriority FROM tbl_leave_employee_hierarchy WHERE hr=1 AND employeecode=@empcode ORDER BY 1 DESC";
        SqlParameter[] sqlparm;
        //if (leavestatus == 0)
        //    approverstatus = 0;
        //else
        //{
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = txt_employee.Text.Trim().ToString();
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
        sqlparm[2].Value = leaveid;

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

    protected void updatependingleave(int applyleaveid)
    {
        SqlParameter[] sqlparm;

        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + applyleaveid;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        for (int i = 0; adjustgrid.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[6];

            sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
            sqlparm[0].Value = applyleaveid;

            sqlparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
            sqlparm[1].Value = adjustgrid.DataKeys[i].Value;

            sqlparm[2] = new SqlParameter("@days", SqlDbType.Decimal);
            sqlparm[2].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text;

            sqlparm[3] = new SqlParameter("@status", SqlDbType.Bit, 1);
            sqlparm[3].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text;

            sqlparm[4] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
            sqlparm[4].Value = ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text;

            sqlparm[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[5].Value = txt_employee.Text.Trim().ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_saveleaveadjustment_pending]", sqlparm);
        }
    }


    protected void updatebackmonth(int leaveid1)
    {
        DateTime fromdate, todate;
        //int empshiftcode;
        string empcode;
        string displayleave;
        string displayleavename;
        int leavemode;
        int leaveid;
        DataSet ds2;
        string str1 = "SELECT empcode, leavemode, leaveid, fromdate, todate, hdate FROM tbl_leave_apply_leave WHERE id=" + leaveid1;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {            
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"]);
            leaveid = Convert.ToInt32(ds.Tables[0].Rows[0]["leaveid"]);
            if (leavemode == 0)
            {
                fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]);
                todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"]);
            }
            else
            {
                fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]);
                todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]);
            }
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();

            if (fromdate.Month != DateTime.Now.Month)
            {
                string str2 = "SELECT leaveid, displayleave FROM tbl_leave_createleave WHERE leaveid=" + leaveid;
                //string str2 = "SELECT empshiftcode FROM tbl_leave_dutyroster WHERE empcode='" + empcode + "' and date='" + fromdate + "'";
                ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    displayleave = ds2.Tables[0].Rows[0]["displayleave"].ToString();
                    if (leavemode == 0)
                    {
                        displayleavename = displayleave + "(HF)";
                    }
                    else
                    {
                        displayleavename = displayleave;
                    }

                    //string str3 = "SELECT starttime,endtime FROM tbl_leave_shift WHERE shiftid=" + empshiftcode;
                    //ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str3);

                    //if (ds3.Tables[0].Rows.Count > 0)
                    //{
                    //    intime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["starttime"]);
                    //    outtime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["endtime"]);

                    string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str4);
                    //}
                }
            }
        }
    }
}