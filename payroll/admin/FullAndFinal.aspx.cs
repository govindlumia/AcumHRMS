using System;
using System.Collections;
using System.Configuration;
using System.Data;
 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
 

public partial class payroll_admin_FullAndFinal : System.Web.UI.Page
{
  
    DataSet ds=new DataSet();
    DataSet dsEarnings = new DataSet();
    DataTable dtearning = new DataTable();
    DataTable dtdeduction = new DataTable();
    DataSet dsOtherEarningDeduction = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    string connStr = string.Empty;
    string fyear = "2010-2011";
    decimal totalEarning = 0;
    decimal totalDeduction = 0;
    decimal A = 0;
    decimal B = 0;
    decimal C = 0;

    int flag = 0;
    string month = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       connStr = ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString();       
        if (Request.QueryString.HasKeys())
        {

            lblEmpCode.Text = Request.QueryString["empfullname"].ToString();
            lblDesignation.Text = Request.QueryString["Designation"].ToString();
            lblTotalDays.Text = Request.QueryString["totalworkingdays"].ToString();
            lblDOJ.Text = Request.QueryString["doj"].ToString();
            lblStatementasOn.Text = Request.QueryString["fnfdate"].ToString();
            lblpaytype.Text = Request.QueryString["paytype"].ToString();
            lblLastWorkingday.Text = Request.QueryString["lastworkingdate"].ToString();
            lblAccountName.Text = Request.QueryString["Accountno"].ToString();
            lblWorkedDays.Text = "0";
            Labelbnkname.Text = Request.QueryString["bankname"].ToString();
            lblMonths.Text = Convert.ToDateTime(Request.QueryString["fnfdate"].ToString()).ToString("MMM");
            ds = (DataSet)(Session["Fnfgenerationdata"]);
            dtearning=ds.Tables[1];
            dtdeduction=ds.Tables[2];
            BindTotalEarnings(dtearning);
            BindTotalDeductions(dtdeduction);
            lbltotalFinalEarnings.Text = totalearning();
            lbltotalFinalDeduction.Text = totaldeduction();
            lblFinalDues.Text = totalnetpay();
            lblFinalTMsg.Text = totalnetpay();
            lblCompanyName.Text = Request.QueryString["companynamefnf"].ToString();

        }
    }
   
    public string totalearning()
    {
        return Request.QueryString["totalearning"].ToString();
    }
    public string totaldeduction()
    {
        return Request.QueryString["totaldeduction"].ToString();
    }
    public string totalnetpay()
    {
        return String.Format("{0:#,##0.##}", Convert.ToDouble(Request.QueryString["netpay"].ToString()));
    }
    protected void BindTotalEarnings(DataTable dt)
    {
        grdItComputation.DataSource = dt;
        grdItComputation.DataBind();
    }
    protected void BindTotalDeductions(DataTable dt)
    {
         grdItComputation1.DataSource = dt;
         grdItComputation1.DataBind();
    }
    protected void grdItComputation_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FinalTotal = (Label)e.Row.FindControl("totalE");
            FinalTotal.Text = totalearning();
        }
    }

    protected void grdItComputation1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FinalTotal = (Label)e.Row.FindControl("totalD");
            FinalTotal.Text = totaldeduction();
        }
    }
}
