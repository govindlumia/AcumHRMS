using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using Utilities;

public partial class leave_apply_compoff : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    //string sqlstr;
    //string comment;
    string message1;
    DataTable dtable = new DataTable();
    int flag = 0;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            Session.Remove("aleave");
            bind_empdetail();
            bindcompoffentitled();
        }
    }

    protected void bindcompoffentitled()
    {
        SqlParameter sqlparm1 = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm1.Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_entitledcompoff]", sqlparm1);


        lblentitled.Text = ds.Tables[0].Rows[0]["allowcompoff"].ToString();
        lblused.Text = ds.Tables[0].Rows[0]["approvedays"].ToString();
    }
    // code to bind employee information...............................................
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
        lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
        {
            lbl_doj.Text = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
        }
    }



    protected int insertapplycompoff(int status)
    {
        SqlParameter[] sqlparm = new SqlParameter[12];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();


        sqlparm[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparm[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlparm[1].Value = Utility.dataformat(txt_fromdate.Text.Trim().ToString());
            sqlparm[2].Value = Utility.dataformat(txt_todate.Text.Trim().ToString());
        }
        else
        {
            sqlparm[1].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
            sqlparm[2].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
        }

        sqlparm[3] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[3].Value = 0;

        sqlparm[4] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[4].Value = status;
        HiddenField1.Value = status.ToString();

        sqlparm[5] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
        sqlparm[5].Value = txt_reason.Text.Trim().ToString().Replace("'", "''");

        if (txt_comment.Text != "")
        {
            txt_comment.Text = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        }

        sqlparm[6] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        sqlparm[6].Value = txt_comment.Text.Trim().ToString().Replace("'", "''");

        sqlparm[7] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparm[7].Value = Session["name"].ToString();

        sqlparm[8] = new SqlParameter("@createddate", SqlDbType.DateTime, 8);
        sqlparm[8].Value = DateTime.Now;

        sqlparm[9] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[9].Value = Session["name"].ToString();

        sqlparm[10] = new SqlParameter("@no_of_days", SqlDbType.Decimal);
        sqlparm[10].Value = lbl_no_of_days.Text;

        sqlparm[11] = new SqlParameter("@half", SqlDbType.Bit);
        sqlparm[11].Value = Convert.ToBoolean(rdofullday.Checked);

        return Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_applycompoff", sqlparm));
    }





    protected void btn_submit_Click1(object sender, EventArgs e)
    {
        Page.Validate("calculate");
        Page.Validate("v");

        insertapplycompoff(0);
        if (HiddenField1.Value == "0")
        {
            message.InnerHtml = "Compoff leave applied successfully";
        }
        else if (HiddenField1.Value == "5")
            message.InnerHtml = "Compoff leave save as draft";

        if (flag == 0)
            clear();
    }

    // code to insert clear form fields.........................................................
    protected void clear()
    {
        txt_comment.Text = "";
        txt_fromdate.Text = "";
        lbl_no_of_days.Text = "";
        txt_reason.Text = "";
        txt_todate.Text = "";
        txtdateone.Text = "";
        //txt_workedon.Text = "";
        //grid_workedon.DataSource = null;
        //grid_workedon.DataBind();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //if (!isValidate())
        //    return;
        //insert_adjustcompoff(insertapplycompoff(5));
        insertapplycompoff(5);
        if (HiddenField1.Value == "0")
        {
            message.InnerHtml = "Compoff leave applied successfully";
        }
        else if (HiddenField1.Value == "5")
            message.InnerHtml = "Compoff leave save as draft";
        if (flag == 0)
            clear();
    }

    //--------------------------Validation for LEAVE PERIOD & DUTY ROSTER--------------------------------

    protected Boolean validate_dutyroster()
    {
        if (divfull.Visible == true)
        {
            DateTime dt1 = Convert.ToDateTime(txt_fromdate.Text);
            DateTime dt2 = Convert.ToDateTime(txt_todate.Text);
            TimeSpan d1 = Convert.ToDateTime(txt_todate.Text) - Convert.ToDateTime(txt_fromdate.Text);

            if (d1.Days < 0)
            {
                message1 = "End date should be greater than start date.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                lbl_no_of_days.Text = "0.0";
                return false;
            }
        }


        DataSet dsdr = new DataSet();

        SqlParameter[] sqlpar = new SqlParameter[3];

        sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlpar[0].Value = Session["empcode"].ToString();

        sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlpar[1].Value = txt_fromdate.Text;
            sqlpar[2].Value = txt_todate.Text;
        }
        else
        {
            sqlpar[1].Value = txtdateone.Text;
            sqlpar[2].Value = txtdateone.Text;
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
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@startdate", SqlDbType.DateTime);

        sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);


        if (divfull.Visible == true)
        {
            sqlparam[1].Value = Utility.dataformat(txt_fromdate.Text);
            sqlparam[2].Value = Utility.dataformat(txt_todate.Text);
        }
        else
        {
            sqlparam[1].Value = Utility.dataformat(txtdateone.Text);
            sqlparam[2].Value = Utility.dataformat(txtdateone.Text);
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_no_of_days.Text = "0";
            message1 = "You have already applied for Leave/OD/Comp-Off during this span! Please check application status";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return false;
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                lbl_no_of_days.Text = "0";
                message1 = "You have already applied for Comp-Off during this span! Please check application status";
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                return false;
            }
            else
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lbl_no_of_days.Text = "0";
                    message1 = "You have already applied for OD during this span! Please check application status";
                    //Page.RegisterStartupScript("vv", "<script> alert('" + message.ToString() + "')</script>");
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
                        lbl_no_of_days.Text = "0";
                        message1 = "Your leave profile is not created! Please contact to Manager";
                        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                        return false;
                    }
                }
            }
        }
    }
    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = false;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = true;
        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = false;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = true;
        }
    }
    protected void btn_calc_Click(object sender, EventArgs e)
    {
        if (!validate_dutyroster())
            return;
        if (validate_applydate())
        {
            validateapplycompoff();
        }
        else
        {
            return;
        }
    }

    protected void validateapplycompoff()
    {
        SqlParameter[] sqlparm = new SqlParameter[6];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@halfday", SqlDbType.Bit);
        sqlparm[1].Value = Convert.ToBoolean(rdohalfday.Checked);

        sqlparm[2] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[3] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);

        if (divfull.Visible == true)
        {
            sqlparm[2].Value = Utility.dataformat(txt_fromdate.Text.Trim().ToString());
            sqlparm[3].Value = Utility.dataformat(txt_todate.Text.Trim().ToString());
        }
        else
        {
            sqlparm[2].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
            sqlparm[3].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
        }

        sqlparm[4] = new SqlParameter("@branch_id", SqlDbType.Int, 4);
        sqlparm[4].Value = Convert.ToInt32(Session["branch"]);

        sqlparm[5] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_validatecompoff]", sqlparm);

        lbl_no_of_days.Text = ds.Tables[0].Rows[0]["noofdays"].ToString();

        if (lbl_no_of_days.Text == "0.0")
        {
            message1 = "Either you are applying for Compoff on Weekoff/Holiday or There is no balance Comp-Off";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            //txt_nod.Text = "0.0";
            //return false;
        }
        else
        {
            btn_submit.Enabled = true;
            Button1.Enabled = true;
        }
    }

}
