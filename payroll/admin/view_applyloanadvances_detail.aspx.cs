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

public partial class payroll_admin_viewapplyloanadvances_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");

        binddetail();   
    }

    protected void binddetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["loan_id"].ToString();
       
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_viewapplyloan", sqlparam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_loanref.Text = ds.Tables[0].Rows[0]["loan_ref_id"].ToString();
                lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
                lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
                lbl_loanname.Text = ds.Tables[0].Rows[0]["loan_name"].ToString();
                lbl_loanacno.Text = ds.Tables[0].Rows[0]["loan_acno"].ToString();
                lbl_loanamnt.Text = ds.Tables[0].Rows[0]["loan_amount"].ToString();
                //  lbl_sdate.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();

                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["sanction_date"]).ToString("dd-MMM-yyyy");

                lbl_recover_month.Text = ds.Tables[0].Rows[0]["recover_month_name"].ToString();
                lbl_recover_year.Text = ds.Tables[0].Rows[0]["recover_year"].ToString();
                lbl_intamnt.Text = ds.Tables[0].Rows[0]["interest_amount"].ToString();
                lbl_instal_no.Text = ds.Tables[0].Rows[0]["no_installments"].ToString();

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status"]))
                    lbl_status.Text = "No Installment had been paid";
                else
                    lbl_status.Text = "All Installments had been paid";

                lbl_totalintamnt.Text = ds.Tables[0].Rows[0]["tamnt"].ToString();

                griddetail.DataSource = ds.Tables[0];
                griddetail.DataBind();
            }
        }
       
    }
}
