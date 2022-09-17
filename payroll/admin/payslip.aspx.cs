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
using querystring;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NumberToEnglish;
using System.Globalization;
public partial class payroll_admin_payroll : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strempcode, strmonth, stryear, strmonthn;
    DateTime a;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
        query q = new query();
        strempcode = (q["empcode"] != null) ? q["empcode"] : "0";
        strmonth = (q["month"] != null) ? q["month"] : "0";
        stryear = (q["year"] != null) ? q["year"] : "0";
        bind_employee_salary_detail();
        bind_earnings();
        bind_deduction();
        bind_reimbursement();
        bind_total();
    }
    private string GetMonthNumberFromAbbreviation(string mmm)
    {
        string[] monthAbbrev =
           CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
        int index = Array.IndexOf(monthAbbrev, mmm) + 1;
        return index.ToString("0#");
    }
    protected void bind_employee_salary_detail()
    {
        // a = new DateTime(1900,Convert.ToInt16(strmonth.ToString()), 1);
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = strempcode.ToString();
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = strmonth.ToString();

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = stryear.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip", sqlparam);


        //----Added by Anuj on 3-June-14 for convert month to specific salary cycle period.

        //lbl_month.Text = strmonth.ToString(); //Commented by Anuj on 3-June-14 
        int i = DateTime.ParseExact(strmonth, "MMM", CultureInfo.CurrentCulture).Month;
        int pMonth = 0;
        if (i == 1)
            pMonth = 12;
        else
            pMonth = i - 1;
        string strPreviousMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
        string strCurrentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);


        //Table 0
        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            lbl_companyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        }
        //Table 1
        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {//----EOC by Anuj on 3-June-14 for convert month to specific salary cycle period.

            lbl_empname.Text = ds.Tables[1].Rows[0]["name"].ToString();
            lbl_desg.Text = ds.Tables[1].Rows[0]["designationname"].ToString();
            lbl_empcode.Text = ds.Tables[1].Rows[0]["empcode"].ToString();
            lbldoj.Text = ds.Tables[1].Rows[0]["emp_doj"].ToString();
            lblacno.Text = ds.Tables[1].Rows[0]["ac_number"].ToString();
            lblCategory.Text = ds.Tables[1].Rows[0]["CategoryName"].ToString();
            lbl_bank_details.Text = ds.Tables[1].Rows[0]["bank_name"].ToString();

            if (ds.Tables[1].Rows[0]["esi_no"].ToString() == "")
            {
                lblESI.Text = "N/A";
            }
            else
            {
                lblESI.Text = ds.Tables[1].Rows[0]["esi_no"].ToString();
            }
            if (ds.Tables[1].Rows[0]["pan_no"].ToString() == "")
            {
                lblPAN.Text = "N/A";
            }
            else
            {
                lblPAN.Text = ds.Tables[1].Rows[0]["pan_no"].ToString();
            }
            if (ds.Tables[1].Rows[0]["pf_no"].ToString() == "")
            {
                lblPF.Text = "N/A";
            }
            else
            {
                lblPF.Text = ds.Tables[1].Rows[0]["pf_no"].ToString();
            }
        }
        //Table 2
        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {
            lbl_month.Text = 1 + " " + strCurrentMonth + " to " + DateTime.DaysInMonth(Convert.ToInt32(ds.Tables[2].Rows[0]["Year"].ToString()), i).ToString() + " " + strCurrentMonth;           
            lbl_total_earning.Text = ds.Tables[2].Rows[0]["gtotal"].ToString();
            lbl_amount.Text = ds.Tables[2].Rows[0]["ntotal"].ToString();
            lbl_reimbursement.Text = ds.Tables[2].Rows[0]["REIMNTOTAL"].ToString();

            //lblworkingdays.Text = ds.Tables[2].Rows[0]["working_days"].ToString();
            //lblDays.Text = ds.Tables[2].Rows[0]["working_days"].ToString();
            //lblDayWorked.Text = ds.Tables[2].Rows[0]["working_days"].ToString();
            lbllwp.Text = ds.Tables[2].Rows[0]["lwp"].ToString();

            lbl_year.Text = ds.Tables[2].Rows[0]["year"].ToString();
        }

        //Table 3
        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
        {
            lblLeaveTaken.Text = ds.Tables[3].Rows[0][0].ToString();
        }

        //Table 4
        if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
        {
            grdSalaryStructure.DataSource = ds.Tables[4];
            grdSalaryStructure.DataBind();

            decimal totalCTC = 0;
            for (int a = 0; a < ds.Tables[4].Rows.Count; a++)
            {
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() != "Transport facility")
                {
                    totalCTC += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
            }
            lblCTC.Text = totalCTC.ToString();
        }
        //Table 5
        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
        {
            lblworkingdays.Text = ds.Tables[5].Rows[0]["TotWorkingDays"].ToString();
            lblHolidays.Text = ds.Tables[5].Rows[0]["Holiday"].ToString();
            lblDays.Text = ds.Tables[5].Rows[0]["WorkingDays"].ToString();
            lblDayWorked.Text = (Convert.ToDecimal(lblDays.Text) - (Convert.ToDecimal(lblLeaveTaken.Text) + Convert.ToDecimal(lbllwp.Text))).ToString();
            lbl_total_deductions.Text = Convert.ToString(Convert.ToDecimal(ds.Tables[2].Rows[0]["dtotal"].ToString()) + (PayrollUtility.Canteenprice * (Convert.ToDecimal(lblDayWorked.Text))));
        }
        //TAble 6 
        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
        {
            lblAbsentPrevious.Text = ds.Tables[6].Rows[0]["PreviousMonth"].ToString();           
        }
        if (ds.Tables[7] != null && ds.Tables[7].Rows.Count > 0)
        {
            lbl_reimbursement.Text = ds.Tables[7].Rows[0]["amount"].ToString();
        }
      
        NumberToEnglish.NumberToEnglish abc = new NumberToEnglish.NumberToEnglish();

        lblwords.Text = abc.changeNumericToWords(Convert.ToDouble(lbl_amount.Text));
        if (lbl_amount.Text.Contains("-"))
            lblwords.Style["color"] = "red";

    }

    protected void bind_earnings()
    {
        sqlstr = @"SELECT distinct tbl_payroll_employee_salarydetail.payheadid,tbl_payroll_employee_salarydetail.id,
        tbl_payroll_employee_salarydetail.month,tbl_payroll_employee_salarydetail.payhead,
        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type
        from tbl_payroll_employee_salarydetail 
        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid        
where HEAD_TYPE=0 and year='" + stryear.ToString() + "' and tbl_payroll_employee_salary.month ='" + strmonth.ToString() + "' and tbl_payroll_employee_salarydetail.empcode='" + strempcode.ToString() + "' and tbl_payroll_employee_salarydetail.APPEAR_INPAYSLIP=1 and tbl_payroll_employee_salarydetail.type!=3 and tbl_payroll_employee_salarydetail.PAYHEADID!=10 order by tbl_payroll_employee_salarydetail.type,tbl_payroll_employee_salarydetail.payheadid";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        earning_grid.DataSource = ds;
        earning_grid.DataBind();
    }

    protected void bind_deduction()
    {
        sqlstr = @"SELECT distinct tbl_payroll_employee_salarydetail.payhead,tbl_payroll_employee_salarydetail.id,
        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type
        from tbl_payroll_employee_salarydetail
        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid        
where HEAD_TYPE=1 and year='" + stryear.ToString() + "' and tbl_payroll_employee_salary.month ='" + strmonth.ToString() + "'and tbl_payroll_employee_salarydetail.empcode='" + strempcode.ToString() + "' and tbl_payroll_employee_salarydetail.APPEAR_INPAYSLIP=1 order by tbl_payroll_employee_salarydetail.type";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        DataRow dr = ds.Tables[0].NewRow();
        dr["payhead"] = "Canteen";
        dr["id"] = "888";
        dr["head_type"] = "1";
        dr["amount"] =Convert.ToString(PayrollUtility.Canteenprice * (Convert.ToDecimal(lblDayWorked.Text))) ;
        dr["type"] = "3";
        ds.Tables[0].Rows.Add(dr);
        deduction_grid.DataSource = ds;
        deduction_grid.DataBind();
    }

    protected void bind_reimbursement()
    {
        sqlstr = @"select s.empcode,s.month,payhead,sd.amount,sd.id 
                    from tbl_payroll_employee_salarydetail sd
                    INNER JOIN  tbl_payroll_employee_salary s ON sd.empcode=s.empcode and 
                    sd.month=s.month and 
                    sd.salaryid=s.salaryid
                    where TYPE=3 and s.month ='" + strmonth.ToString() + "'and sd.empcode='" + strempcode.ToString() + "' and sd.APPEAR_INPAYSLIP=1 order by sd.type";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        reimbursement_grid.DataSource = ds;
        reimbursement_grid.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
        {
            reimdiv.Visible = true;

        }
        else
        {
            reimdiv.Visible = false;
        }
    }

    protected void bind_total()
    {
        int currentyear, currentmonth = 0;
        if (strmonth.ToLower() == "jan")
        {
            currentmonth = 1;
        }
        if (strmonth.ToLower() == "feb")
        {
            currentmonth = 2;
        }
        if (strmonth.ToLower() == "mar")
        {
            currentmonth = 3;
        }
        if (strmonth.ToLower() == "apr")
        {
            currentmonth = 4;
        }
        if (strmonth.ToLower() == "may")
        {
            currentmonth = 5;
        }
        if (strmonth.ToLower() == "jun")
        {
            currentmonth = 6;
        }
        if (strmonth.ToLower() == "jul")
        {
            currentmonth = 7;
        }
        if (strmonth.ToLower() == "aug")
        {
            currentmonth = 8;
        }
        if (strmonth.ToLower() == "sep")
        {
            currentmonth = 9;
        }
        if (strmonth.ToLower() == "oct")
        {
            currentmonth = 10;
        }
        if (strmonth.ToLower() == "nov")
        {
            currentmonth = 11;
        }
        if (strmonth.ToLower() == "dec")
        {
            currentmonth = 12;
        }
        //currentmonth = Convert.ToInt32(strmonthn);
        currentyear = Convert.ToInt32(stryear.Substring(0, 4));

        if ((currentmonth == 1) || (currentmonth == 2) || (currentmonth == 3))
        {
            currentyear = currentyear + 1;
        }
        DateTime todate;
        //fromdate = Convert.ToDateTime("04/24/" + currentyear);
        //todate = Convert.ToDateTime(currentmonth + "/25/" + currentyear);
        todate = Utilities.Utility.dataformat(currentmonth + "/01/" + currentyear);

        query q = new query();
        stryear = (q["year"] != null) ? q["year"] : "0";
        sqlstr = @"select isnull(sum(gtotal),0.00) GrandTotal,
                    isnull(sum(dtotal),0.00) DeductionTotal,
                    isnull(sum(REIMNTOTAL),0.00) ReimbursementTotal 
                    from tbl_payroll_employee_salary

                    where year='" + stryear + "' and empcode='" + strempcode.ToString() + "' and todate<='" + todate.ToString() + "'";//  between '" + fromdate + "' and '" + todate + "' and empcode='" + strempcode.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        lbl_tot_deduction.Text = ds.Tables[0].Rows[0]["DeductionTotal"].ToString();
        lbl_tot_grandtotal.Text = ds.Tables[0].Rows[0]["GrandTotal"].ToString();
        lbl_tot_reimbursement.Text = ds.Tables[0].Rows[0]["ReimbursementTotal"].ToString();
    }

    protected void lnkprint_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = strempcode;
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = strmonth;

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = stryear;

        //----Added by Anuj on 3-June-14 for convert month to specific salary cycle period.

        //lbl_month.Text = strmonth.ToString(); //Commented by Anuj on 3-June-14 
        int i = DateTime.ParseExact(strmonth, "MMM", CultureInfo.CurrentCulture).Month;
        int pMonth = 0;
        if (i == 1)
            pMonth = 12;
        else
            pMonth = i - 1;
        string strPreviousMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
        string strCurrentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

        string pdfSalCycle = 26 + " " + strPreviousMonth + " to " + 25 + " " + strCurrentMonth + " - ";

        //----EOC by Anuj on 3-June-14 for convert month to specific salary cycle period.

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip_printing", sqlparam);
        ds.Tables[0].TableName = "payslip_emp";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
        ds1.Tables[0].TableName = "payslip_emp_deduction";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
        ds2.Tables[0].TableName = "payslip_emp_earning";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
        ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail", sqlparam);
        ds4.Tables[0].TableName = "companydetail";

        string companyname = (ds4.Tables[0].Rows[0]["companyname"].ToString()).Replace(" ", string.Empty);

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath(".") + "\\reports\\payslip.rpt");
        myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

        myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
        myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
        myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
        myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
        // myReportDocument.SetParameterValue("month", strmonth);
        myReportDocument.SetParameterValue("month", pdfSalCycle);
        //myReportDocument.SetParameterValue("year", stryear);
        myReportDocument.SetParameterValue("year", DateTime.Now.Year);
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

        // Stop buffering the response
        Response.Buffer = false;
        // Clear the response content and headers
        Response.ClearContent();
        Response.ClearHeaders();
        try
        {
            // Export the Report to Response stream in PDF format and file name Customers
            myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "'" + strempcode.ToString() + "'" + companyname);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ex = null;
        }
    }
}
