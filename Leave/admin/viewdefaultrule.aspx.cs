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


public partial class Leave_admin_viewdefaultrule : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
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
    }


protected void bindleaverule()
    {
        
    
        SqlParameter sqlparm = new SqlParameter("@id", SqlDbType.Int);
        sqlparm.Value = Request.QueryString["id"].ToString();
        try
        {
             ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewrule", sqlparm);
             lbl_policy_name.Text = ds.Tables[0].Rows[0]["policyname"].ToString();
             Label1.Text = ds.Tables[0].Rows[0]["backdate_leave_applicable1"].ToString();
             Label2.Text = ds.Tables[0].Rows[0]["document_required1"].ToString();
             Label3.Text = ds.Tables[0].Rows[0]["carryforward_applicable1"].ToString();
             Label4.Text = ds.Tables[0].Rows[0]["holidays_counted_asleave1"].ToString();
             lbl_modification.Text = ds.Tables[0].Rows[0]["leave_modification1"].ToString();
             lbl_halfdays_leave.Text = ds.Tables[0].Rows[0]["halfday_leave_applicable1"].ToString();
             lbl_short.Text = ds.Tables[0].Rows[0]["Short_leave_applicable"].ToString();
             lblleave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
             lbl_days_before_leave.Text = ds.Tables[0].Rows[0]["days_before_leaveapply"].ToString();
             lbl_entitled_days.Text = ds.Tables[0].Rows[0]["entitled_days"].ToString();
             lbl_how_many_days.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
             lbl_minimum_days.Text = ds.Tables[0].Rows[0]["minimum_no_days"].ToString();
             lbl_carryforward.Text = ds.Tables[0].Rows[0]["carryforward_maximum_days"].ToString();
             lbl_entitled_maxdays.Text = ds.Tables[0].Rows[0]["maximum_no_days"].ToString();
             lbl_weekly.Text = ds.Tables[0].Rows[0]["weekly_off1"].ToString();
             lbl_accumulation_days.Text = ds.Tables[0].Rows[0]["accumulated_days"].ToString();
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
    }
        catch (Exception ex)
        {
            //message.InnerHtml = "";
            //Utilities.LogError(ex);
        }
    }
}
