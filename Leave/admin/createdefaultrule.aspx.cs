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

public partial class Leave_admin_createdefaultrule : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    string sqlstr;
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString());
    SqlCommand cm = new SqlCommand();
    DataSet ds = new DataSet();
    public int i;
    public decimal b;
    public decimal c;
    public int d;
    public decimal f;
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

            enable_ddhowdays();
            enable_carryforward();
            carryforwar_days();

        }
    }


    protected void bind_carryforward_checked()
    {

        if (opt_carryforward_yes.Checked && opt_carry_all.Checked)
        {
            b = 0;
        }
        else if (opt_carryforward_yes.Checked && !opt_carry_all.Checked)
        {
            b = Convert.ToDecimal(txt_carry_maximumdays.Text);

        }
        else
        {
            b = 0;
        }
    }
    protected void bind_accumulation_checked()
    {
        if (opt_accumulation_all.Checked)
        {
            c = 0;
        }
        else
        {
            c = Convert.ToDecimal(txt_accumulation.Text);
        }
    }

    protected void bind_computed_Checked()    // for credited & computed leaves
    {
        if (rbtn.SelectedValue == "1")
        {
            d = Convert.ToInt32(txtNo_of_days.Text);
            f = Convert.ToDecimal(txt_balance.Text);
        }
        else 
        {
            d = 0;
            f = 0;

        }

    }


    public void btnsbmit_Click(object sender, EventArgs e)
    {
        bind_carryforward_checked();
        bind_accumulation_checked();
        bind_computed_Checked();

        bl_navigation.create_default_rule_master(Convert.ToInt32(ddleave.SelectedValue), Convert.ToInt32(dd_policy.SelectedValue), Convert.ToDecimal(txt_entitled.Text), Convert.ToInt32(txt_days_before_leave.Text), Convert.ToInt32(txt_minimum.Text), Convert.ToInt32(txt_maximum.Text), opt_document_yes.Checked, opt_backdate_yes.Checked, Convert.ToInt32(txt_how_many.Text), opt_holidays_yes.Checked, opt_weekly_yes.Checked, opt_carryforward_yes.Checked, Convert.ToDecimal(b), Convert.ToDecimal(c), opt_modification_yes.Checked, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), opt_halfdays_yes.Checked,opt_short_yes.Checked, ref i, Convert.ToInt32(rbtn.SelectedValue.ToString()),Convert.ToInt32(txtNo_of_days.Text),Convert.ToDecimal(txt_balance.Text));

        if (i <= 0)
        {
            message.InnerHtml = "Leave rule already exists, try again";
        }
        else
        {
            message.InnerHtml = "Leave rule created successfully";
        }

        SqlParameter[] sqlgridparm;

        sqlgridparm = new SqlParameter[5];

        sqlgridparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
        sqlgridparm[0].Value = dd_policy.SelectedValue;

        sqlgridparm[1] = new SqlParameter("@Entitled_days", SqlDbType.Decimal);
        sqlgridparm[1].Value = Convert.ToDecimal(txt_entitled.Text);

        sqlgridparm[2] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        sqlgridparm[2].Value = ddleave.SelectedValue;

        sqlgridparm[3] = new SqlParameter("@username", SqlDbType.VarChar, 100);
        sqlgridparm[3].Value = Session["name"].ToString();

        sqlgridparm[4] = new SqlParameter("@flag", SqlDbType.Int, 100);
        sqlgridparm[4].Value = Convert.ToInt32(rbtn.SelectedValue.ToString());


        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_setupdatedrule", sqlgridparm);

        clear();
    }
    protected void ddleave_DataBound(object sender, EventArgs e)
    {
        ddleave.Items.Insert(0, new ListItem("Select Leave", "100"));
    }

    protected void clear()
    {
        txt_accumulation.Text = "0";
        txt_carry_maximumdays.Text = "0";
        txt_days_before_leave.Text = "0";
        txt_entitled.Text = "0";

        txt_how_many.Text = "0";
        txt_maximum.Text = "0";
        txt_minimum.Text = "0";
        dd_policy.SelectedIndex = 0;
        ddleave.SelectedIndex = 0;
        opt_carryforward_yes.Checked = true;
        opt_carryforward_no.Checked = false;
        opt_accumulation_all.Checked = true;
        opt_accumulation_days.Checked = false;
        opt_backdate_yes.Checked = true;
        opt_backdate_no.Checked = false;
        opt_carry_all.Checked = true;
        opt_carry_days.Checked = false;
        opt_document_yes.Checked = true;
        RadioButton6.Checked = false;
        opt_backdate_no.Checked = false;
        opt_halfdays_yes.Checked = true;
        opt_short_yes.Checked = true;
        opt_halfday_no.Checked = false;
        opt_short_no.Checked = false;
        opt_holidays_yes.Checked = true;
        RadioButton2.Checked = false;
        opt_modification_yes.Checked = true;
        opt_modification_no.Checked = false;
        opt_weekly_yes.Checked = true;
        opt_weekly_no.Checked = false;
        enable_carryforward();
        enable_ddhowdays();
        txtNo_of_days.Text = "";
        txt_balance.Text = "";
    }

    //--------------------- Code to bind true or false how many days radio button ----------------------------------// 
    protected void enable_ddhowdays()
    {
        if (opt_backdate_no.Checked)
        {
            txt_how_many.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
        }
        else
        {
            txt_how_many.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
        }
    }

    protected void opt_backdate_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }

    //--------------------- Code to bind true or false carryforward days radio button ----------------------------------// 

    protected void enable_carryforward()
    {
        if (opt_carryforward_no.Checked)
        {

            txt_carry_maximumdays.Visible = false;
            RequiredFieldValidator7.Enabled = false;
            opt_carry_all.Enabled = false;
            opt_carry_days.Enabled = false;
            opt_accumulation_all.Enabled = false;
            opt_accumulation_days.Enabled = false;
            txt_accumulation.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RangeValidator2.Enabled = false;
        }
        else
        {
            txt_carry_maximumdays.Visible = true;
            RequiredFieldValidator7.Enabled = true;
            opt_carry_days.Enabled = true;
            opt_carry_all.Enabled = true;
            opt_accumulation_days.Enabled = true;
            opt_accumulation_all.Enabled = true;
            txt_accumulation.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            RangeValidator2.Enabled = true;
            carryforwar_days();
            accumulation_days();
        }
    }
    protected void opt_carryforward_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carryforward_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }

    protected void dd_policy_DataBound(object sender, EventArgs e)
    {
        dd_policy.Items.Insert(0, new ListItem("Select Policy", "0"));
    }

    protected void carryforwar_days()
    {
        if (opt_carry_all.Checked)
        {
            txt_carry_maximumdays.Visible = false;
            RequiredFieldValidator7.Enabled = false;
            RangeValidator2.Enabled = false;
        }
        else
        {
            txt_carry_maximumdays.Visible = true;
            RequiredFieldValidator7.Enabled = true;
            RangeValidator2.Enabled = true;
        }
    }


    protected void opt_carry_all_CheckedChanged(object sender, EventArgs e)
    {
        carryforwar_days();
    }

    protected void opt_carry_days_CheckedChanged(object sender, EventArgs e)
    {
        carryforwar_days();
    }
    protected void accumulation_days()
    {
        if (opt_accumulation_all.Checked)
        {
            txt_accumulation.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RangeValidator1.Enabled = false;
        }
        else
        {
            txt_accumulation.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            RangeValidator1.Enabled = true;
        }
    }
    protected void opt_accumulation_all_CheckedChanged(object sender, EventArgs e)
    {
        accumulation_days();
    }
    protected void opt_accumulation_days_CheckedChanged(object sender, EventArgs e)
    {
        accumulation_days();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void rbtn_onSelectedIndexChanges(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator9.Enabled = false;
            dvCompute.Disabled=true;
        }
        else
        {
            dvCompute.Visible = true;
        dvCompute.Disabled=false;
        RequiredFieldValidator8.Enabled = true;
        RequiredFieldValidator9.Enabled = true;
        //d = Convert.ToDecimal(txtNo_of_days.Text);
        //f = Convert.ToDecimal(txt_balance.Text);
        }
    }
}
