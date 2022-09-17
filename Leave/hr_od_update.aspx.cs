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


public partial class leave_hr_od_update : System.Web.UI.Page
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
            //bind_empdetail();
        }
        this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txt_time'))");
        this.imgouttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtouttime'))");
    }

    //protected void bind_empdetail()
    //{
    //    SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
    //    sqlparm.Value = Session["empcode"].ToString();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);

    //    lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
    //    lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
    //    lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
    //    lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //    lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
    //    lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
    //    lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
    //    lbl_doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();
    //}

    protected void btn_sbmit_Click(object sender, EventArgs e)
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
        DateTime fromtime = new DateTime();
        DateTime totime = new DateTime();
        DateTime hdate = new DateTime();
        bool half;

        if (divfull.Visible == true)
        {
            divfull.Visible = true;
            divhalf.Visible = false;
            leavemode = 1;
            fromdate = Utilities.Utility.dataformat(txt_date.Text);
            todate = Utilities.Utility.dataformat(txt_ftime.Text);
            fromtime = Convert.ToDateTime(txt_time.Text);
            totime = Convert.ToDateTime(txtouttime.Text);
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
            fromtime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
            totime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
            hdate = Convert.ToDateTime(txt_select.Text);
            half = opt_first.Checked;
            HiddenField1.Value = Convert.ToString("0.5");
        }

        SqlParameter[] sqlparam = new SqlParameter[18];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@working_hour", SqlDbType.Decimal);
        sqlparam[1].Value = Convert.ToDecimal(HiddenField1.Value);

        sqlparam[2] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
        sqlparam[2].Value = txt_reason.Text;

        sqlparam[3] = new SqlParameter("@Approval_status", SqlDbType.Int);
        sqlparam[3].Value = 1;

        sqlparam[4] = new SqlParameter("@Leave_status", SqlDbType.Int);
        sqlparam[4].Value = 1;

        sqlparam[5] = new SqlParameter("@flag", SqlDbType.Bit);
        sqlparam[5].Value = true;

        sqlparam[6] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam[6].Value = true;

        sqlparam[7] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[7].Value = System.DateTime.Now;

        sqlparam[8] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[8].Value = Session["name"].ToString();

        sqlparam[9] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 50);
        sqlparam[9].Value = Session["name"].ToString();

        sqlparam[10] = new SqlParameter("@comment", SqlDbType.VarChar, 500);
        sqlparam[10].Value = comment.ToString();

        sqlparam[11] = new SqlParameter("@leavemode", SqlDbType.Int);
        sqlparam[11].Value = leavemode;

        sqlparam[12] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[12].Value = fromdate;

        sqlparam[13] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[13].Value = todate;

        sqlparam[14] = new SqlParameter("@fromtime", SqlDbType.DateTime);
        sqlparam[14].Value = fromtime;

        sqlparam[15] = new SqlParameter("@totime", SqlDbType.DateTime);
        sqlparam[15].Value = totime;

        sqlparam[16] = new SqlParameter("@hdate", SqlDbType.DateTime);
        sqlparam[16].Value = hdate;

        sqlparam[17] = new SqlParameter("@half", SqlDbType.Bit);
        sqlparam[17].Value = half;

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_applyod_hr", sqlparam);
        //bl_navigation.apply_od(txt_employee.Text.Trim().ToString(), Convert.ToDecimal(HiddenField1.Value), txt_reason.Text, 0, 0, true, true, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), comment.ToString(), leavemode, fromdate, todate, fromtime, totime, hdate, half, ref i);

        if (Convert.ToInt32(ds1.Tables[0].Rows[0][0]) == 0)
        {
            message.InnerHtml = "You have already applied OD during this time span";
            return;
        }
        else
        {
            message.InnerHtml = "OD applied and approved successfully";
        }
        updatebackmonth(Convert.ToInt32(ds1.Tables[0].Rows[0][0]));
        clearfield();
    }

    protected void updatebackmonth(int id)
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode;
        string empcode;
        DataSet ds2, ds3;
        string str1 = "SELECT empcode, date, fromtime FROM tbl_leave_apply_od WHERE id=" + id.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromtime"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();

            if (fromdate.Month != DateTime.Now.Month)
            {
                string str2 = "SELECT empshiftcode FROM tbl_leave_dutyroster WHERE empcode='" + empcode + "' and date='" + fromdate + "'";
                ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    empshiftcode = Convert.ToInt32(ds2.Tables[0].Rows[0]["empshiftcode"]);

                    string str3 = "SELECT starttime,endtime FROM tbl_leave_shift WHERE shiftid=" + empshiftcode;
                    ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str3);

                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        intime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["starttime"]);
                        outtime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["endtime"]);

                        string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='P', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str4);
                    }
                }
            }
        }
    }

    protected void clearfield()
    {
        txt_employee.Text = "";
        txt_date.Text = "";
        txt_ftime.Text = "";
        txt_reason.Text = "";
        txt_comment.Text = "";
        txt_time.Text = "";
        txtouttime.Text = "";
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
        TimeSpan d1;
        if (divfull.Visible == true)
        {
            DateTime dt1 = Convert.ToDateTime(txt_date.Text);
            DateTime dt2 = Convert.ToDateTime(txt_ftime.Text);
            d1 = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
        }
        else
        {
            DateTime dt1 = Convert.ToDateTime(txt_select.Text);
            DateTime dt2 = Convert.ToDateTime(txt_select.Text);
            d1 = Convert.ToDateTime(txt_select.Text) - Convert.ToDateTime(txt_select.Text);
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
        sqlpar[0].Value = txt_employee.Text.ToString();

        sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlpar[1].Value = txt_date.Text;
            sqlpar[2].Value = txt_ftime.Text;
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
