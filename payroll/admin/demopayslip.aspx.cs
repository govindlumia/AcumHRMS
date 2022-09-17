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

public partial class payroll_admin_demopayslip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dtable;
    string sqlstr;
    string strempcode, strmonth, stryear, strmonthn;
    DateTime a;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //if (Session["role"] != null)
            //{
            //    if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //        Response.Redirect("~/Authenticate.aspx");
            //}
            //else Response.Redirect("~/notlogged.aspx");
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

        lbl_month.Text = strmonth.ToString(); //Commented by Anuj on 3-June-14 
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
            // lbl_companyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
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
            //grdSalaryStructure.DataSource = ds.Tables[4];
            //grdSalaryStructure.DataBind();

            decimal totalCTC = 0;
            decimal totalEarning = 0;
            decimal totalDeduction = 0;
            for (int a = 0; a < ds.Tables[4].Rows.Count; a++)
            {
                //===================Earnings===================================
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Basic")
                {
                    lblbasic.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalEarning += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "HRA")
                {
                    Lblhra.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalEarning += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Special Allowance")
                {
                    lblspclallownace.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalEarning += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Transport Allowance")
                {
                    Lblconvynceallowance.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalEarning += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
               
                //==================================================================
                //===============Deductions=========================================
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Provident Fund")
                {
                    lblpfund.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalDeduction += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "ESI")
                {
                    Lblesifund.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalDeduction += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Medical Allowance")
                {
                    Lblmedicalallowance.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                    totalDeduction += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() == "Transport facility")
                {
                    lbltransportfacility.Text = ds.Tables[4].Rows[a]["amount"].ToString();
                   
                }
                if (ds.Tables[4].Rows[a]["payhead_name"].ToString() != "Transport facility")
                {
                    totalCTC += Convert.ToDecimal(ds.Tables[4].Rows[a]["amount"]);
                }
                //==================================================================
            }
            Lblotherincentives.Text=totalDeduction.ToString();
            lblsubtotal.Text = totalEarning.ToString();
            lblCTC.Text = totalCTC.ToString();
            lblnetearnings.Text = (totalCTC - totalDeduction).ToString();
        }
        //Table 5
        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
        {
            lblworkingdays.Text = ds.Tables[5].Rows[0]["TotWorkingDays"].ToString();
            lblHolidays.Text = ds.Tables[5].Rows[0]["Holiday"].ToString();
            lblDays.Text = ds.Tables[5].Rows[0]["WorkingDays"].ToString();
            decimal tempworkedcal = 0;
            tempworkedcal=(Convert.ToDecimal(lblDays.Text) - (Convert.ToDecimal(lblLeaveTaken.Text) + Convert.ToDecimal(lbllwp.Text)));
            if(tempworkedcal<0)
            {
               lblDayWorked.Text ="0";
            }
            else{
                lblDayWorked.Text = tempworkedcal.ToString();
            }
            
            
            lbl_total_deductions.Text = Convert.ToString(Convert.ToDecimal(ds.Tables[2].Rows[0]["dtotal"].ToString()) + (PayrollUtility.Canteenprice * (Convert.ToDecimal(lblDayWorked.Text))));
            lbl_amount.Text = (Convert.ToDecimal(lbl_amount.Text) - (PayrollUtility.Canteenprice * (Convert.ToDecimal(lblDayWorked.Text)))).ToString();
        }
        //TAble 6 
        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
        {
           // lblAbsentPrevious.Text = ds.Tables[6].Rows[0]["PreviousMonth"].ToString();
        }
        if (ds.Tables[7] != null && ds.Tables[7].Rows.Count > 0)
        {
            lbl_reimbursement.Text = ds.Tables[7].Rows[0]["amount"].ToString();
            if (lbl_reimbursement.Text=="")
            {
                lbl_reimbursement.Text = "0";
            }
            lbl_tot_grandtotal.Text = (Convert.ToDecimal(lbl_amount.Text) + Convert.ToDecimal(lbl_reimbursement.Text)).ToString();
        }
        
        NumberToEnglish.NumberToEnglish abc = new NumberToEnglish.NumberToEnglish();


       // lblwords.Text = abc.changeNumericToWords(Convert.ToDouble(lbl_amount.Text));
        //if (lbl_amount.Text.Contains("-"))
        //    lblwords.Style["color"] = "red";

    }
    
    protected void bind_earnings()
    {
        bool flag= false;
        sqlstr = @"SELECT distinct tbl_payroll_employee_salarydetail.payheadid,tbl_payroll_employee_salarydetail.id,
        tbl_payroll_employee_salarydetail.month,case tbl_payroll_employee_salarydetail.payhead
        when 'Transport Allowance' then 'Conveyance Allowance'
        ELSE tbl_payroll_employee_salarydetail.payhead
        END as payhead,
        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type
        from tbl_payroll_employee_salarydetail 
        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
        INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
        tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid        
        where HEAD_TYPE=0 and year='" + stryear.ToString() + "' and tbl_payroll_employee_salary.month ='" + strmonth.ToString() + "' and tbl_payroll_employee_salarydetail.empcode='" + strempcode.ToString() + "' and tbl_payroll_employee_salarydetail.APPEAR_INPAYSLIP=1 and tbl_payroll_employee_salarydetail.type!=3 and tbl_payroll_employee_salarydetail.PAYHEADID!=10 order by tbl_payroll_employee_salarydetail.type,tbl_payroll_employee_salarydetail.payheadid";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
        {
            //===================Earnings===================================
            if (ds.Tables[0].Rows[a]["payhead"].ToString() == "Conveyance Allowance")
            {
                flag = true;
                break;
            }
        }
        if(!flag)
        {
            DataRow convyenceallowance = ds.Tables[0].NewRow();
            convyenceallowance["payheadid"] = 11;
            convyenceallowance["Id"]=1;
            convyenceallowance["Month"] = strmonth.ToString();
            convyenceallowance["Payhead"]="Conveyance Allowance";
            convyenceallowance["HEAD_TYPE"] = 0;
            convyenceallowance["Amount"]="0.00";
            convyenceallowance["Type"]=2;
            ds.Tables[0].Rows.Add(convyenceallowance);
            ds.Tables[0].DefaultView.Sort = "[payheadid] ASC";
        }
        earning_grid.DataSource = ds;
        earning_grid.DataBind();
    }

    protected void bind_deduction()
    {
        bool flag = false;
        sqlstr = @"SELECT distinct tbl_payroll_employee_salarydetail.payhead,tbl_payroll_employee_salarydetail.id,
        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type
        from tbl_payroll_employee_salarydetail
        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
        INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
        tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid        
        where HEAD_TYPE=1 and year='" + stryear.ToString() + "' and tbl_payroll_employee_salary.month ='" + strmonth.ToString() + "'and tbl_payroll_employee_salarydetail.empcode='" + strempcode.ToString() + "' and tbl_payroll_employee_salarydetail.APPEAR_INPAYSLIP=1 order by tbl_payroll_employee_salarydetail.type"; 
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
        {
            //===================Earnings===================================
            if (ds.Tables[0].Rows[a]["payhead"].ToString() == "Transport facility")
            {
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            DataRow transportfacility = ds.Tables[0].NewRow();
            transportfacility["Id"] = 47;
            transportfacility["Payhead"] = "Transport facility";
            transportfacility["HEAD_TYPE"] = 1;
            transportfacility["Amount"] = "0.00";
            transportfacility["Type"] = 2;
            ds.Tables[0].Rows.Add(transportfacility);
            ds.Tables[0].DefaultView.Sort = "[Payhead] ASC";
        }
        DataRow dr = ds.Tables[0].NewRow();
        dr["payhead"] = "Canteen";
        dr["id"] = "888";
        dr["head_type"] = "1";
        dr["amount"] = Convert.ToString(PayrollUtility.Canteenprice * (Convert.ToDecimal(lblDayWorked.Text)));
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
        lbl_tot_reimbursement.Text = ds.Tables[0].Rows[0]["ReimbursementTotal"].ToString();       
    }

    
}
