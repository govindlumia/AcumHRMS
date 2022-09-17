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
using DataAccessLayer;

public partial class payroll_Onlyviewfnf : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet dsEarnings = new DataSet();
    DataTable dtearning = new DataTable();
    DataTable dtdeduction = new DataTable();
    DataTable dt = new DataTable();
    DataSet dsallowance = new DataSet();
    DataTable dtallowance = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          createdatatable();
          EmployeeDetails();
        }

    }
    public void createdatatable()
    {
        dtallowance.Columns.Add("empcode", typeof(string));
        dtallowance.Columns.Add("Allowance_id", typeof(string));
        dtallowance.Columns.Add("AllowanceName", typeof(string));
        dtallowance.Columns.Add("Amount", typeof(string));
        Session["EmployeePayStructure"] = dtallowance;
        //string sqlstr1 = @"select * from Tbl_FNF_ALLOWANCE where EMPCODE='" + Request.QueryString["Empcodeviewfnf"].ToString() + "'";
        //dsallowance = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
        //if (dsallowance.Tables[0].Rows.Count != 0)
        //{
        //    foreach (DataRow dr in dsallowance.Tables[0].Rows)
        //    {
        //        DataRow _dr;
        //        _dr = dt.NewRow();
        //        _dr["empcode"] = Request.QueryString["Empcodeviewfnf"].ToString();
        //        _dr["Allowance_id"] = dr["Allowance_id"].ToString();
        //        _dr["AllowanceName"] = dr["AllowanceName"].ToString();
        //        _dr["Amount"] = dr["Amount"].ToString();
        //        dtallowance.Rows.Add(_dr);
        //    }
        //}
    }
    private void EmployeeDetails()
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@Empcode", SqlDbType.Int, 50);
        sqlparam[0].Value = Convert.ToInt32(Request.QueryString["Empcodeviewfnf"].ToString()); //20120065;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "GET_EMPDETAILS_FNF", sqlparam);
        if (ds.Tables[0].Rows.Count != 0 && ds.Tables[1].Rows.Count != 0)
        {
            ViewState["dateofleavingonlyviewfnf"] = ds.Tables[1].Rows[0]["dateofleaving"].ToString();
            ViewState["empfullnameonlyviewfnf"] = ds.Tables[1].Rows[0]["empfullname"].ToString();
            ViewState["lastsalarydateonlyviewfnf"] = ds.Tables[0].Rows[0]["lastsaldate"].ToString() == "" || ds.Tables[0].Rows[0]["lastsaldate"].ToString() == null ? "N.A" : ds.Tables[0].Rows[0]["lastsaldate"].ToString();
            ViewState["designationnameonlyviewfnf"] = ds.Tables[0].Rows[0]["designationname"].ToString();
            ViewState["dateofjoiningonlyviewfnf"] = ds.Tables[0].Rows[0]["joindate"].ToString();
            ViewState["companynameemponlyviewfnf"] = ds.Tables[4].Rows[0]["companyname"].ToString();
        }
        if (ds.Tables[2].Rows.Count != 0)
        {

            ViewState["EmpAccountNoonlyviewfnf"] = ds.Tables[3].Rows[0]["EmpAccountNo"].ToString() == "" || ds.Tables[3].Rows[0]["EmpAccountNo"].ToString() == null ? "N.A" : ds.Tables[3].Rows[0]["EmpAccountNo"].ToString();
        }
        bindemployeedetails();

    }
    private void bindemployeedetails()
    {
        dtallowance = (DataTable)Session["EmployeePayStructure"];
        string fnfdate = Convert.ToDateTime(Request.QueryString["DATE_OF_FNF"]).ToString("MM/dd/yyyy");
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[7];
        sqlparam[0] = new SqlParameter("@EMPCODE", SqlDbType.Int, 50);
        sqlparam[0].Value = Convert.ToInt32(Request.QueryString["Empcodeviewfnf"].ToString()); //20120065;
        sqlparam[1] = new SqlParameter("@USERID", SqlDbType.Int, 50);
        sqlparam[1].Value = Convert.ToInt32(Session["empcode"].ToString());
        sqlparam[2] = new SqlParameter("@INCLUDE_ONHOLD_SALARY", SqlDbType.Bit, 50);
        sqlparam[2].Value = Convert.ToBoolean(Request.QueryString["onholdsalary"].ToString());
        sqlparam[3] = new SqlParameter("@TBLFNFALLOWANCE", SqlDbType.Structured, 50);
        sqlparam[3].Value = dtallowance;
        sqlparam[4] = new SqlParameter("@PAIDWORKING_DAYS", SqlDbType.Int, 50);
        sqlparam[4].Value = Convert.ToInt32(Request.QueryString["workingdays"].ToString());
        sqlparam[5] = new SqlParameter("@LASTSALARYDATE", SqlDbType.DateTime, 50);
        sqlparam[5].Value = Convert.ToDateTime(ViewState["lastsalarydateonlyviewfnf"]).ToString("yyyy-MM-dd");
        sqlparam[6] = new SqlParameter("@FNF_TYPE", SqlDbType.Bit, 50);
        sqlparam[6].Value = 0;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[dbo].[TO_GENERATE_FNF]", sqlparam);
        dtearning=ds.Tables[1];
        dtdeduction=ds.Tables[2];
        BindTotalEarnings(dtearning);
        BindTotalDeductions(dtdeduction);
        //==================================================
        lblEmpCode.Text = ViewState["empfullnameonlyviewfnf"].ToString();
        lblDesignation.Text = ViewState["designationnameonlyviewfnf"].ToString();
        lblTotalDays.Text = Request.QueryString["workingdays"].ToString();
        lblDOJ.Text = Convert.ToDateTime(ViewState["dateofjoiningonlyviewfnf"].ToString()).ToString("MM/dd/yyyy");
        lblStatementasOn.Text = Convert.ToDateTime(Request.QueryString["DATE_OF_FNF"]).ToString("MM/dd/yyyy");
        lblpaytype.Text = Request.QueryString["REIMBURSEMENT_TYPE"].ToString();
        lblLastWorkingday.Text = Convert.ToDateTime(ViewState["dateofleavingonlyviewfnf"].ToString()).ToString("MM/dd/yyyy");
        lblAccountName.Text = ViewState["EmpAccountNoonlyviewfnf"].ToString();
        lblWorkedDays.Text = "0";
        Labelbnkname.Text = Request.QueryString["bankname"].ToString();
        lblMonths.Text = Convert.ToDateTime(Request.QueryString["DATE_OF_FNF"].ToString()).ToString("MMM");
        lbltotalFinalEarnings.Text = Request.QueryString["TOTAL_EARNINGS"].ToString();
        lbltotalFinalDeduction.Text = Request.QueryString["TOTAL_DEDUCTIONS"].ToString();
        lblFinalDues.Text = Request.QueryString["TOTAL_PAY"].ToString();
        lblFinalTMsg.Text = Request.QueryString["TOTAL_PAY"].ToString();
        lblCompanyName.Text = ViewState["companynameemponlyviewfnf"].ToString();
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
               FinalTotal.Text = String.Format("{0:#,##0.##}", Request.QueryString["TOTAL_EARNINGS"].ToString());
           }
       }

       protected void grdItComputation1_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.Footer)
           {
               Label FinalTotal = (Label)e.Row.FindControl("totalD");
               FinalTotal.Text = String.Format("{0:#,##0.##}", Request.QueryString["TOTAL_DEDUCTIONS"].ToString());
           }
       }
    }
