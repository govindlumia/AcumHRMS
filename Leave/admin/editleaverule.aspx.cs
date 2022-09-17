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

public partial class Leave_admin_editleaverule : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    double a;
    double b;
    int c;
    public int d;
    public decimal f;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindleaverule();
            
        }
       bind_computed_Checked();
        //if (opt_prorata_no.Checked)
        //{
        //    txt_enforcement.Enabled = false;
        //    RequiredFieldValidator8.Enabled = false;
        //    RangeValidator8.Enabled = false;
        //}
        //else
        //{
        //    txt_enforcement.Enabled = true;
        //    RequiredFieldValidator8.Enabled = true;
        //    RangeValidator8.Enabled = true;
        //}
    }

 //--------------------- Code to bind fields in the revelent controls ------------------------// 

    protected void bindleaverule()
    {
        sqlstr = @"select def.carryforward_maximum_days,def.days_before_leaveapply,def.entitled_days,def.backdate_howmany_days,
       def.maximum_no_days,def.minimum_no_days,def.backdate_leave_applicable,def.id,def.leaveid,def.policyid,policy.policyname,leave.leavetype,
       def.carryforward_applicable,def.document_required,def.leave_modification,def.holidays_counted_asleave,def.halfday_leave_applicable,def.Short_leave_applicable,def.weekly_off,def.accumulated_days,def.CreditComputedType,def.Computed_Days,def.ComputedLeaveAlloted
       from tbl_leave_createdefaultrule def 
       inner join tbl_leave_createleavepolicy policy on def.policyid=policy.policyid
       inner join tbl_leave_createleave leave on leave.leaveid=def.leaveid 
       where id=" + Request.QueryString["id"] +"";
        SqlParameter sqlparm = new SqlParameter("@id", SqlDbType.Int);
        sqlparm.Value = Request.QueryString["id"].ToString();
        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr,sqlparm);
            txt_days_before_leave.Text = ds.Tables[0].Rows[0]["days_before_leaveapply"].ToString();
            txt_entitled.Text = ds.Tables[0].Rows[0]["entitled_days"].ToString();
            hidden_entitled.Value = ds.Tables[0].Rows[0]["entitled_days"].ToString();
            txt_how_many.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
            txt_maximum.Text = ds.Tables[0].Rows[0]["maximum_no_days"].ToString();
            txt_minimum.Text = ds.Tables[0].Rows[0]["minimum_no_days"].ToString();
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            lbl_policy_name.Text = ds.Tables[0].Rows[0]["policyname"].ToString();
            hidden_leaveid.Value = ds.Tables[0].Rows[0]["leaveid"].ToString();
            hidden_policyid.Value = ds.Tables[0].Rows[0]["policyid"].ToString();
            txtNo_of_days.Text = ds.Tables[0].Rows[0]["Computed_Days"].ToString();
            txt_balance.Text = ds.Tables[0].Rows[0]["ComputedLeaveAlloted"].ToString();
            if (ds.Tables[0].Rows[0]["CreditComputedType"].ToString() != "")
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["CreditComputedType"]) == 1)
                {
                    dvCompute.Visible = true;
                    rbtn.SelectedValue = "1";
                }
                else
                {
                    dvCompute.Visible = false;
                    rbtn.SelectedValue = "0";

                }

            }
            else 
            {
                dvCompute.Visible = false;
                rbtn.SelectedValue = "0";
            }
            

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["carryforward_applicable"]) == true)
            {
                opt_carryforward_yes.Checked = true;
                opt_carryforward_no.Checked = false;
                                
                if (Convert.ToDouble(ds.Tables[0].Rows[0]["carryforward_maximum_days"])!=0.0)
                {
                    opt_carry_days.Checked = true;
                    opt_carry_all.Checked = false;
                    txt_carry_maximumdays.Visible = true;
                    RangeValidator2.Enabled = true;
                    RequiredFieldValidator7.Enabled = true;
                    txt_carry_maximumdays.Text = ds.Tables[0].Rows[0]["carryforward_maximum_days"].ToString();
                }
                else
                {
                    opt_carry_all.Checked = true;
                    opt_carry_days.Checked = false;
                    txt_carry_maximumdays.Visible = false;
                    RangeValidator2.Enabled = false;
                    RequiredFieldValidator7.Enabled = false;
                }
                if (Convert.ToDouble(ds.Tables[0].Rows[0]["accumulated_days"])!= 0.0)
                {
                    opt_accumulation_days.Checked = true;
                    opt_accumulation_all.Checked = false;
                    txt_accumulation.Visible = true;
                    RangeValidator1.Enabled = true;
                    RequiredFieldValidator1.Enabled= true;
                    txt_accumulation.Text = ds.Tables[0].Rows[0]["accumulated_days"].ToString();
                }
                else
                {
                    opt_accumulation_all.Checked = true;
                    opt_accumulation_days.Checked = false;
                    txt_accumulation.Visible = false;
                    RangeValidator1.Enabled = false;
                    RequiredFieldValidator1.Enabled= false; ;
                    txt_accumulation.Visible = false;
                }
            }
            else
            {
                opt_carryforward_yes.Checked = false;
                opt_carryforward_no.Checked = true;
                opt_carry_all.Enabled = false;
                opt_carry_days.Enabled = false;
                opt_accumulation_all.Enabled = false;
                opt_accumulation_days.Enabled = false;
                txt_carry_maximumdays.Visible = false;
                txt_accumulation.Visible = false;
                RangeValidator1.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator7.Enabled = false;
                RangeValidator2.Enabled = false;
            }

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["backdate_leave_applicable"]) == true)
            {
                opt_backdate_yes.Checked = true;
                opt_backdate_no.Checked = false;
                txt_how_many.Enabled = true;
                RequiredFieldValidator6.Enabled = true;
                RangeValidator3.Enabled = true;
                txt_how_many.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
            }
            else
            {
                opt_backdate_no.Checked = true;
                opt_backdate_yes.Checked = false;
                RequiredFieldValidator6.Enabled = false;
                RangeValidator3.Enabled = false;
                txt_how_many.Enabled = false;
            }

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]) == true)
            {
                opt_document_yes.Checked = true;
            }
            else
            {
                opt_document_no.Checked = true;
            }

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leave_modification"]) == true)
            {
                opt_extension_yes.Checked = true;
            }
            else
            {
                opt_extension_no.Checked = true;
            }

            if(Convert.ToBoolean(ds.Tables[0].Rows[0]["holidays_counted_asleave"]) == true)
            {
                opt_holidays_yes.Checked=true;
            }
            else
            {
                opt_holidays_no.Checked = true;
            }

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["halfday_leave_applicable"]) == true)
            {
                opt_halfday_leave.Checked = true;
            }
            else
            {
                opt_halfday_no.Checked = true;
            }
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Short_leave_applicable"]) == true)
            {
                opt_short_yes.Checked = true;
            }
            else
            {
                opt_short_no.Checked = true;
            }

            if(Convert.ToBoolean(ds.Tables[0].Rows[0]["weekly_off"]) == true)
            {
                opt_weekly_yes.Checked = true;
            }
            else
            {
                opt_weekly_no.Checked = true;
            }

    }
        catch (Exception ex)
        {
           
        }
    }

    //--------------------- Code to update default rule ----------------------------------// 

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
       // bind_prorata_value();

        if (opt_carryforward_no.Checked)
        {
            a = 0.0;
            b = 0.0;
        }
        else
        {
            if (opt_carry_all.Checked)
            {
                a = 0.0;
            }
            else
                a = Convert.ToDouble(txt_carry_maximumdays.Text);
            if (opt_accumulation_all.Checked)
            {
                b = 0.0;
            }
            else
                b = Convert.ToDouble(txt_accumulation.Text);
        }
        if (opt_backdate_no.Checked)
        {
            c = 0;
        }
        else
        {
            c = Convert.ToInt32(txt_how_many.Text);
        }
        bind_computed_Checked();

        sqlstr = "Update tbl_leave_createdefaultrule set days_before_leaveapply='" + Convert.ToInt32(txt_days_before_leave.Text) + "',minimum_no_days='" + Convert.ToInt32(txt_minimum.Text) + "',entitled_days='" + Convert.ToDecimal(txt_entitled.Text) + "',maximum_no_days='" + Convert.ToInt32(txt_maximum.Text) + "',backdate_howmany_days='" + c + "',carryforward_maximum_days ='" + a + "',CreditComputedType='" + rbtn.SelectedValue + "',Computed_Days='" + d + "',ComputedLeaveAlloted='" + f + "', backdate_leave_applicable='" + opt_backdate_yes.Checked + "' , document_required ='" + opt_document_yes.Checked + "',holidays_counted_asleave='" + opt_holidays_yes.Checked + "',carryforward_applicable='" + opt_carryforward_yes.Checked + "',leave_modification='" + opt_extension_yes.Checked + "',halfday_leave_applicable='" + opt_halfday_leave.Checked + "',Short_leave_applicable='"+opt_short_yes.Checked +"',accumulated_days='" + b + "',weekly_off='" + opt_weekly_yes.Checked + "',modifiedby='" + Session["name"].ToString().Trim().ToString().Replace("'", "''") + "' where id=" + Request.QueryString["id"] + "";
       DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
     
       RegisterStartupScript("df", "<script language='javascript'>window.close()</script>");
      // Response.Redirect("<script language='javascript'><a href='overviewrule.aspx?updated=null' target='name123'>asdasdafddsf</a></script>;");

        Response.Redirect("overviewrule.aspx?updated=null");
    }

    //protected void bind_prorata_value()
    //{
    //    SqlParameter[] sqlparm;
    //    sqlparm = new SqlParameter[5];

    //    sqlparm[0] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
    //    sqlparm[0].Value = hidden_leaveid.Value;

    //    sqlparm[1] = new SqlParameter("@policyid", SqlDbType.Int, 4);
    //    sqlparm[1].Value = hidden_policyid.Value;

        
    //    if (opt_prorata_yes.Checked)
    //    {
    //        sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
    //        sqlparm[2].Value = 1;
    //    }
    //    else
    //    {
    //        sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
    //        sqlparm[2].Value = 0;
    //    }

    //    sqlparm[3] = new SqlParameter("@adjustamt", SqlDbType.Decimal);
    //    sqlparm[3].Value =Convert.ToDecimal(txt_entitled.Text) - Convert.ToDecimal(hidden_entitled.Value);

    //    if(opt_prorata_yes.Checked)
    //    {
    //        sqlparm[4] = new SqlParameter("@enforcementdate", SqlDbType.DateTime);
    //        sqlparm[4].Value = Convert.ToDateTime(txt_enforcement.Text);
    //    }
    //    else
    //    {
    //        sqlparm[4] = new SqlParameter("@enforcementdate", SqlDbType.DateTime);
    //        sqlparm[4].Value = System.DateTime.Now;
    //    }
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure,"sp_leave_change_customize_rule",sqlparm);

    //}
    protected void btnrst_Click(object sender, EventArgs e)
    {
        Response.Redirect("overviewrule.aspx");
    }

    //--------------------- Code to bind true or false how many days radio button ----------------------------------// 


    protected void enable_ddhowdays()
    {
        if (opt_backdate_no.Checked)
        {
            txt_how_many.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            RangeValidator3.Enabled = false;
        }
        else
        {
            txt_how_many.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RangeValidator3.Enabled = true;
        }
    }

    protected void opt_backdate_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }
    protected void opt_backdate_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }

//----------------------------------------------------------------------------------------------------------//


//--------------------- Code to bind true or false carryforward days radio button ----------------------------------// 

    protected void enable_carryforward()
    {
        if (opt_carryforward_no.Checked)
        {
            opt_carry_all.Enabled=false;
            opt_carry_days.Enabled=false;
            opt_accumulation_all.Enabled = false;
            opt_accumulation_days.Enabled = false;
            txt_accumulation.Visible = false;
            txt_carry_maximumdays.Visible = false;
            RangeValidator2.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
            RangeValidator1.Enabled = false;
            RequiredFieldValidator1.Enabled = false;
  
        }
        else
        {
            opt_carry_all.Enabled = true;
            opt_carry_days.Enabled = true;
            opt_accumulation_days.Enabled = true;
            opt_accumulation_all.Enabled = true;

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
    }

    //protected void carryforwar_days()
    //{
    //    if (opt_carry_all.Checked)
    //    {
    //        txt_carry_maximumdays.Visible = false;
    //        RequiredFieldValidator7.Enabled = false;
    //        RangeValidator2.Enabled = false;
    //    }
    //    else
    //    {
    //        txt_carry_maximumdays.Visible = true;
    //        RequiredFieldValidator7.Enabled = true;
    //        RangeValidator2.Enabled = true;
    //    }
    //}
    protected void opt_carry_all_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carry_days_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }



//----------------------------------------------------------------------------------------------------------//

    //--------------------- Code to bind true or false accumulation days radio button ----------------------------------// 

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

 //----------------------------------------------------------------------------------------------------------//
    
    protected void opt_holidays_yes_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void opt_holidays_no_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void opt_carryforward_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carryforward_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void rbtn_onSelectedIndexChanges(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator9.Enabled = false;
            dvCompute.Disabled = true;
        }
        else
        {
            dvCompute.Visible = true;
            dvCompute.Disabled = false;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            //d = Convert.ToDecimal(txtNo_of_days.Text);
            //f = Convert.ToDecimal(txt_balance.Text);
        }
    }
    protected void bind_computed_Checked()
    {
        if (rbtn.SelectedValue == "1")
        {
            if (txtNo_of_days.Text!= "")
            {
                d = Convert.ToInt32(txtNo_of_days.Text);
                f = Convert.ToDecimal(txt_balance.Text);
            }
            
            
        }
        else
        {
            d = 0;
            f = 0;
            dvCompute.Visible = false;
            dvCompute.Disabled = true;
        }

    }
}
