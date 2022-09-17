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
using System.Data.SqlClient;
using DataAccessLayer;


public partial class payroll_admin_edit_bonus_master : System.Web.UI.Page
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
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            binddata();
        }
    }

    protected void binddata()
    {

        sqlstr = @"SELECT payhead_name,alias_name,payhead_type,name_inpayslip FROM tbl_payroll_bonus where id =" + Request.QueryString["id"].ToString() + "";


        //sqlstr = "SELECT distinct * FROM tbl_payroll_payhead WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
        txt_name.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        txt_payslip.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
        dd_payheadtype.SelectedValue = ds.Tables[0].Rows[0]["payhead_type"].ToString();
        HiddenField1.Value = ds.Tables[0].Rows[0]["payhead_name"].ToString();
    }


    protected void submit()
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@payhead_type", SqlDbType.Int);
        sqlparam[2].Value = dd_payheadtype.SelectedValue;

        sqlparam[3] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        sqlparam[3].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[4].Value = Session["name"].ToString();

        sqlparam[5] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
        sqlparam[5].Value = System.DateTime.Now;

        sqlparam[6] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[6].Value = Request.QueryString["id"].ToString();

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_update_bonus_master", sqlparam);

        Response.Redirect("view_bonusmaster_list.aspx?message=Bonus updated successfully");
   
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (txt_name.Text == HiddenField1.Value)
            submit();
        else
        {
            if (validate_name())
                submit();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        binddata();
    }

    //------------------------------------------- Check for Bonus Name ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_bonus WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Bonus name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
            return false;
        }
        return true;
    }
}
