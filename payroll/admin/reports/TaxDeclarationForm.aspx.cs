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
using System.IO;

//using iTextSharp.text.pdf;

//using iTextSharp.text.html;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;

public partial class payroll_admin_reports_TaxDeclarationForm : System.Web.UI.Page
{
    string financilYear = string.Empty;
    string empCode = string.Empty;
    string connStr = string.Empty;
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet dsMonths = new DataSet();
    DataSet dsPayhead = new DataSet();
    DataSet dsItComputation = new DataSet();
    DataSet dsTaxDed = new DataSet();
    DataSet dsTTPaid = new DataSet();
    DataSet dsRem = new DataSet();
    int flag = 1;
    decimal taxDedTot = 0;
    decimal AprGTotal, MayGTotal, JunGTotal, JulGTotal, AugGTotal, SepGTotal, OctGTotal, NovGTotal, DecGTotal, JanGTotal, FebGTotal, MarGTotal, tot, fTotal;
    decimal AprGTotalPF, MayGTotalPF, JunGTotalPF, JulGTotalPF, AugGTotalPF, SepGTotalPF, OctGTotalPF, NovGTotalPF, DecGTotalPF, JanGTotalPF, FebGTotalPF, MarGTotalPF, totPF;
    decimal AprGTotalPI, MayGTotalPI, JunGTotalPI, JulGTotalPI, AugGTotalPI, SepGTotalPI, OctGTotalPI, NovGTotalPI, DecGTotalPI, JanGTotalPI, FebGTotalPI, MarGTotalPI, totPI, fTotalPI;
    decimal totalHraRec = 0;
    decimal totalBasic = 0;
    decimal convAss = 0;
    decimal medAss = 0;
    decimal lta = 0;
    decimal A = 0;
    decimal A1 = 0;
    decimal B = 0;
    decimal C = 0;
    decimal D = 0;
    decimal E = 0;
    decimal F = 0;
    decimal G = 0;
    decimal H = 0;
    decimal I = 0;
    decimal J = 0;
    decimal K = 0;
    decimal L = 0;
    decimal M = 0;
    decimal N = 0;
    decimal O = 0;
    decimal P = 0;
    decimal Q = 0;
    decimal R = 0;
    decimal S = 0;
    decimal basic833 = 0;
    decimal Professional_Tax = 0;
    decimal PFTotal = 0;
    decimal helperAss = 0;
    decimal uniformAss = 0;
    decimal taxFreeAll = 0;



    DataSet dsChanges = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString();


        if (!IsPostBack)
        {
            if (Request.QueryString.HasKeys())
            {
                financilYear = Request.QueryString["fyear"].ToString();
                empCode = Request.QueryString["empcode"].ToString();

                SelectCompanyDetails();
                BindItComputation();
                BindPerQuest();
                BindExemptionSec10();
                BindIncomeFromPrevEmp();
                IncomeAfterExemption();
                BindLessDeuUndr16();
                BindIncomeUnderHeadSalaries();
                BindAddAnyOtherIncdecByEmployee();
                BindGrosstotalIncome();
                BindDeductionUnderChapter6a();
                BindTotalDed();
                BindTaxableIncome();
                BindRoundOff10();

                BindTotalTaxPaid();
                BindDueTax();
            }
        }
    }

    protected void BindPerQuest()
    {
        //lblGrossSalary.Text = (fTotal + fTotalPI+Convert.ToDecimal(lblPerquisite.Text.Trim())).ToString(); with performance incentive
        lblGrossSalary.Text = (fTotal + Convert.ToDecimal(lblPerquisite.Text.Trim())).ToString();
        D = Convert.ToDecimal(lblGrossSalary.Text);
    }

    protected void BindExemptionSec10()
    {
        //lblHRARec.Text = totalHraRec.ToString();
        lblHRARecL.Text = totalHraRec.ToString();
        lblPerBasic.Text = ((totalBasic * 40) / 100).ToString();
        lblConvAss.Text = convAss.ToString();
        lblMedAss.Text = medAss.ToString();
        lblhelperAll.Text = helperAss.ToString();
        lblUniform.Text = uniformAss.ToString();
        lblTaxFreeAll.Text = taxFreeAll.ToString();
        lblLTA.Text = lta.ToString();

        if (Convert.ToDecimal(lblTotRentPaid.Text) > (totalBasic * 10 / 100))
        {
            lblRentPaidBasic.Text = (Convert.ToDecimal(lblTotRentPaid.Text) - (totalBasic * 10 / 100)).ToString();
        }
        else
        {
            lblRentPaidBasic.Text = "0";
        }

        //lblRentPaidBasic.Text = (Convert.ToDecimal(lblTotRentPaid.Text) - (totalBasic * 10 / 100)).ToString();

        CalRemForSec10();
        decimal minimum1 = Math.Min(Convert.ToDecimal(lblTotRentPaid.Text), totalHraRec);
        decimal minimum2 = Math.Min(Convert.ToDecimal(lblPerBasic.Text), Convert.ToDecimal(lblRentPaidBasic.Text));
        lblHRARec.Text = Math.Min(minimum1, minimum2).ToString();

        //lblTotalexmption.Text = (Convert.ToDecimal(lblHRARec.Text) + convAss + medAss + Convert.ToDecimal(lblLTA.Text)).ToString();
        lblTotalexmption.Text = (Convert.ToDecimal(lblHRARec.Text) + convAss + medAss + helperAss + uniformAss + taxFreeAll + Convert.ToDecimal(lblLTA.Text) + Convert.ToDecimal(lblTelRem.Text.Trim()) + Convert.ToDecimal(lblMedRem.Text.Trim())).ToString();

        E = Convert.ToDecimal(lblTotalexmption.Text.Trim());
    }

    protected void CalRemForSec10()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_cal_remb", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsRem);
                if (dsRem.Tables[0].Rows.Count > 0)
                {
                    lblMedRem.Text = dsRem.Tables[0].Rows[0]["medRem"].ToString();
                    lblTelRem.Text = dsRem.Tables[0].Rows[0]["telRem"].ToString();


                }
                else
                {
                    lblMedRem.Text = "0";
                    lblTelRem.Text = "0";

                }
            }



        }
    }

    protected void BindIncomeFromPrevEmp()
    {
        lblIncomeFromPrevEmp.Text = "0.0";
        F = Convert.ToDecimal(lblIncomeFromPrevEmp.Text.Trim());
    }
    protected void BindLessDeuUndr16()
    {
        lblDedUndr16.Text = "0.0";
        H = Convert.ToDecimal(lblDedUndr16.Text.Trim());
    }
    protected void BindRoundOff10()
    {
        lblRoundOff.Text = Math.Round(M).ToString();
        N = Convert.ToDecimal(lblRoundOff.Text.Trim());
    }

    protected void BindTaxableIncome()
    {
        lblTaxableIncome.Text = (K - L).ToString();
        M = Convert.ToDecimal(lblTaxableIncome.Text.Trim());
    }

    protected void BindIncomeUnderHeadSalaries()
    {
        lblIncomeChraUnHdSalar.Text = (G - H).ToString();
        I = Convert.ToDecimal(lblIncomeChraUnHdSalar.Text.Trim());
    }

    public void BindItComputation()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_select_it_computation", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@fyear", financilYear);
            cmd.Parameters.AddWithValue("@empcode", empCode);


            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsItComputation);
                grdItComputation.DataSource = dsItComputation;
                grdItComputation.DataBind();
                grdItComputationPF.DataSource = dsItComputation.Tables[1];
                grdItComputationPF.DataBind();
                //lblPerquisite.Text = dsItComputation.Tables[2].Rows[0]["amount"].ToString();
                //lblTotRentPaid.Text = dsItComputation.Tables[3].Rows[0]["rent"].ToString();
                grdItComputationPerformance.DataSource = dsItComputation.Tables[2];
                grdItComputationPerformance.DataBind();
                lblPerquisite.Text = dsItComputation.Tables[3].Rows[0]["amount"].ToString();
                lblTotRentPaid.Text = dsItComputation.Tables[4].Rows[0]["rent"].ToString();
                if (dsItComputation.Tables[4].Rows[0]["interest_house"].ToString() != "")
                {
                    lblLTA.Text = dsItComputation.Tables[4].Rows[0]["interest_house"].ToString();
                }
                else
                {
                    lblLTA.Text = "0";
                }


            }



        }
    }


    public void BindDeductionUnderChapter6a()
    {


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_dedu_under_chapter_6a", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);


            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsTaxDed);
                if (dsTaxDed.Tables[0].Rows.Count > 0)
                {

                    grdTaxDedundCh6A.DataSource = dsTaxDed;
                    grdTaxDedundCh6A.DataBind();


                }
                else
                {
                    grdTaxDedundCh6A.DataSource = dsTaxDed;
                    grdTaxDedundCh6A.DataBind();
                    L = 0;

                }
            }



        }
    }

    public void BindTotalTaxPaid()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_total_tax_to_be_paid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);


            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsTTPaid);
                if (dsTTPaid.Tables[0].Rows.Count > 0)
                {
                    lblPaidTill.Text = dsTTPaid.Tables[1].Rows[0]["month"].ToString();
                    lblRawTax.Text = dsTTPaid.Tables[0].Rows[0]["rawTax"].ToString();
                    lblsurcharge.Text = dsTTPaid.Tables[0].Rows[0]["surcharge"].ToString();
                    lblEducess.Text = dsTTPaid.Tables[0].Rows[0]["edu_cess"].ToString();
                    lblTTPaid.Text = dsTTPaid.Tables[0].Rows[0]["tot"].ToString();
                    O = Convert.ToDecimal(lblTTPaid.Text);
                }


                else
                {

                    lblPaidTill.Text = "0";
                    lblRawTax.Text = "0";
                    lblsurcharge.Text = "0";
                    lblEducess.Text = "0";
                    lblTTPaid.Text = "0";
                    O = 0;
                }
            }



        }
    }




    public void SelectCompanyDetails()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_fetch_company_and_emp_details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@fyear", financilYear);
            cmd.Parameters.AddWithValue("@empcode", empCode);


            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(ds);
                lblCompanyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["corp_add1"].ToString() + "," + ds.Tables[0].Rows[0]["corp_add2"].ToString() + "," + ds.Tables[0].Rows[0]["corp_state"].ToString() + " - " + ds.Tables[0].Rows[0]["corp_zip"].ToString();
                lblFinancialYear.Text = "Financial Year : " + financilYear;
                lblEmpName.Text = ds.Tables[1].Rows[0]["emp_name"].ToString();
                lblPanNo.Text = ds.Tables[1].Rows[0]["pan_no"].ToString();
                lblDOJ.Text = ds.Tables[1].Rows[0]["doj"].ToString();
                lblGender.Text = ds.Tables[1].Rows[0]["emp_gender"].ToString();


            }



        }
    }

    protected void IncomeAfterExemption()
    {

        lblIncomeInoneAfterExmp.Text = (D - E + F).ToString();
        G = Convert.ToDecimal(lblIncomeInoneAfterExmp.Text.Trim());
    }

    //
    protected void BindAddAnyOtherIncdecByEmployee()
    {
        lblAddAnIncdecByEmp.Text = "0.0";
        J = Convert.ToDecimal(lblAddAnIncdecByEmp.Text.Trim());
    }
    protected void BindGrosstotalIncome()
    {
        lblGrossTotalIncome.Text = (I + J - Professional_Tax).ToString();
        K = Convert.ToDecimal(lblGrossTotalIncome.Text.Trim());
    }






    protected void grdItComputation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label payheadId = (Label)e.Row.FindControl("lblPayheadid");
            Label payhead = (Label)e.Row.FindControl("lblPayhead");
            Label Apr = (Label)e.Row.FindControl("lblApr");
            Label May = (Label)e.Row.FindControl("lblMay");
            Label Jun = (Label)e.Row.FindControl("lblJun");
            Label Jul = (Label)e.Row.FindControl("lblJul");
            Label Aug = (Label)e.Row.FindControl("lblAug");
            Label Sep = (Label)e.Row.FindControl("lblSep");
            Label Oct = (Label)e.Row.FindControl("lblOct");
            Label Nov = (Label)e.Row.FindControl("lblNov");
            Label Dec = (Label)e.Row.FindControl("lblDec");
            Label Jan = (Label)e.Row.FindControl("lblJan");
            Label Feb = (Label)e.Row.FindControl("lblFeb");
            Label Mar = (Label)e.Row.FindControl("lblMar");

            Label Total = (Label)e.Row.FindControl("lblTotal");

            Apr.ToolTip = "Apr";
            Apr.Text = BindMonthWise(Apr, payheadId.Text, payhead.Text);




            May.ToolTip = "May";
            May.Text = BindMonthWise(May, payheadId.Text, payhead.Text);


            Jun.ToolTip = "Jun";
            Jun.Text = BindMonthWise(Jun, payheadId.Text, payhead.Text);

            Jul.ToolTip = "Jul";
            Jul.Text = BindMonthWise(Jul, payheadId.Text, payhead.Text);

            Aug.ToolTip = "Aug";
            Aug.Text = BindMonthWise(Aug, payheadId.Text, payhead.Text);

            Sep.ToolTip = "Sep";
            Sep.Text = BindMonthWise(Sep, payheadId.Text, payhead.Text);

            Oct.ToolTip = "Oct";
            Oct.Text = BindMonthWise(Oct, payheadId.Text, payhead.Text);

            Nov.ToolTip = "Nov";
            Nov.Text = BindMonthWise(Nov, payheadId.Text, payhead.Text);

            Dec.ToolTip = "Dec";
            Dec.Text = BindMonthWise(Dec, payheadId.Text, payhead.Text);

            Jan.ToolTip = "Jan";
            Jan.Text = BindMonthWise(Jan, payheadId.Text, payhead.Text);


            Feb.ToolTip = "Feb";
            Feb.Text = BindMonthWise(Feb, payheadId.Text, payhead.Text);

            Mar.ToolTip = "Mar";
            Mar.Text = BindMonthWise(Mar, payheadId.Text, payhead.Text);
            tot = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
            Total.Text = tot.ToString();
            //TotalHRA Received

            //HRA Arrears 
            if (payhead.Text.Trim().Equals("HRA"))
            {
                totalHraRec = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("HRA(A)"))
            {
                // totalHraRec = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
                totalHraRec = totalHraRec + Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
            }

            if (payhead.Text.Trim().Equals("Basic"))
            {
                totalBasic = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("Basic(A)"))
            {
                totalBasic = totalBasic + Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }



            if (payhead.Text.Trim().Equals("Medical Allowance"))
            {
                medAss = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("Transport Allowance"))
            {
                convAss = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("LTA NON TAXABLE"))
            {
                lta = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("Helper Allowance"))
            {
                helperAss = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("Uniform Allowance"))
            {
                uniformAss = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("Tax free allowance"))
            {
                taxFreeAll = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }




            AprGTotal = AprGTotal + Convert.ToDecimal(Apr.Text.Trim());
            MayGTotal = MayGTotal + Convert.ToDecimal(May.Text.Trim());
            JunGTotal = JunGTotal + Convert.ToDecimal(Jun.Text.Trim());
            JulGTotal = JulGTotal + Convert.ToDecimal(Jul.Text.Trim());
            AugGTotal = AugGTotal + Convert.ToDecimal(Aug.Text.Trim());
            SepGTotal = SepGTotal + Convert.ToDecimal(Sep.Text.Trim());
            OctGTotal = OctGTotal + Convert.ToDecimal(Oct.Text.Trim());
            NovGTotal = NovGTotal + Convert.ToDecimal(Nov.Text.Trim());
            DecGTotal = DecGTotal + Convert.ToDecimal(Dec.Text.Trim());
            JanGTotal = JanGTotal + Convert.ToDecimal(Jan.Text.Trim());
            FebGTotal = FebGTotal + Convert.ToDecimal(Feb.Text.Trim());
            MarGTotal = MarGTotal + Convert.ToDecimal(Mar.Text.Trim());




        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label AprT = (Label)e.Row.FindControl("lblAprT");
            Label MayT = (Label)e.Row.FindControl("lblMayT");
            Label JunT = (Label)e.Row.FindControl("lblJunT");
            Label JulT = (Label)e.Row.FindControl("lblJulT");
            Label AugT = (Label)e.Row.FindControl("lblAugT");
            Label SepT = (Label)e.Row.FindControl("lblSepT");
            Label OctT = (Label)e.Row.FindControl("lblOctT");
            Label NovT = (Label)e.Row.FindControl("lblNovT");
            Label DecT = (Label)e.Row.FindControl("lblDecT");
            Label JanT = (Label)e.Row.FindControl("lblJanT");
            Label FebT = (Label)e.Row.FindControl("lblFebT");
            Label MarT = (Label)e.Row.FindControl("lblMarT");
            Label FinalTotal = (Label)e.Row.FindControl("lblFTotal");
            AprT.Text = AprGTotal.ToString();
            MayT.Text = MayGTotal.ToString();
            JunT.Text = JunGTotal.ToString();
            JulT.Text = JulGTotal.ToString();
            AugT.Text = AugGTotal.ToString();
            SepT.Text = SepGTotal.ToString();
            OctT.Text = OctGTotal.ToString();
            NovT.Text = NovGTotal.ToString();
            DecT.Text = DecGTotal.ToString();
            JanT.Text = JanGTotal.ToString();
            FebT.Text = FebGTotal.ToString();
            MarT.Text = MarGTotal.ToString();

            fTotal = AprGTotal + MayGTotal + JunGTotal + JulGTotal + AugGTotal + SepGTotal + OctGTotal + NovGTotal + DecGTotal + JanGTotal + FebGTotal + MarGTotal;

            FinalTotal.Text = fTotal.ToString();
            A = fTotal;
        }

    }

    protected string BindMonthWise(Label month, string payheadid, string payhead)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_calculate_payheadamount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);
            cmd.Parameters.AddWithValue("@month", month.ToolTip);
            cmd.Parameters.AddWithValue("@payheadid", payheadid);
            cmd.Parameters.AddWithValue("@payhead", payhead);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    month.Text = cmd.ExecuteScalar().ToString();

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            } return month.Text;

        }
    }



    protected string BindMonthWisePF(Label month, string payheadid, string payhead)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_calculate_payheadamount_pf", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);
            cmd.Parameters.AddWithValue("@month", month.ToolTip);
            cmd.Parameters.AddWithValue("@payheadid", payheadid);
            cmd.Parameters.AddWithValue("@payhead", payhead);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    month.Text = cmd.ExecuteScalar().ToString();

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            } return month.Text;

        }
    }


    protected string BindMonthWisePer(Label month, string payheadid, string payhead)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_calculate_payheadamount_per_ins", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@fyear", financilYear);
            cmd.Parameters.AddWithValue("@month", month.ToolTip);
            cmd.Parameters.AddWithValue("@payheadid", payheadid);
            cmd.Parameters.AddWithValue("@payhead", payhead);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    month.Text = cmd.ExecuteScalar().ToString();

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            } return month.Text;

        }
    }
    protected void grdItComputationPF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                    }
                }
            }
            Label payheadId = (Label)e.Row.FindControl("lblPayheadid");
            Label payhead = (Label)e.Row.FindControl("lblPayhead0");
            Label Apr = (Label)e.Row.FindControl("lblApr");
            Label May = (Label)e.Row.FindControl("lblMay");
            Label Jun = (Label)e.Row.FindControl("lblJun");
            Label Jul = (Label)e.Row.FindControl("lblJul");
            Label Aug = (Label)e.Row.FindControl("lblAug");
            Label Sep = (Label)e.Row.FindControl("lblSep");
            Label Oct = (Label)e.Row.FindControl("lblOct");
            Label Nov = (Label)e.Row.FindControl("lblNov");
            Label Dec = (Label)e.Row.FindControl("lblDec");
            Label Jan = (Label)e.Row.FindControl("lblJan");
            Label Feb = (Label)e.Row.FindControl("lblFeb");
            Label Mar = (Label)e.Row.FindControl("lblMar");

            Label Total = (Label)e.Row.FindControl("lblTotal");

            Apr.ToolTip = "Apr";
            Apr.Text = BindMonthWisePF(Apr, payheadId.Text, payhead.Text);



            May.ToolTip = "May";
            May.Text = BindMonthWisePF(May, payheadId.Text, payhead.Text);

            Jun.ToolTip = "Jun";
            Jun.Text = BindMonthWisePF(Jun, payheadId.Text, payhead.Text);

            Jul.ToolTip = "Jul";
            Jul.Text = BindMonthWisePF(Jul, payheadId.Text, payhead.Text);

            Aug.ToolTip = "Aug";
            Aug.Text = BindMonthWisePF(Aug, payheadId.Text, payhead.Text);

            Sep.ToolTip = "Sep";
            Sep.Text = BindMonthWisePF(Sep, payheadId.Text, payhead.Text);

            Oct.ToolTip = "Oct";
            Oct.Text = BindMonthWisePF(Oct, payheadId.Text, payhead.Text);

            Nov.ToolTip = "Nov";
            Nov.Text = BindMonthWisePF(Nov, payheadId.Text, payhead.Text);

            Dec.ToolTip = "Dec";
            Dec.Text = BindMonthWisePF(Dec, payheadId.Text, payhead.Text);

            Jan.ToolTip = "Jan";
            Jan.Text = BindMonthWisePF(Jan, payheadId.Text, payhead.Text);

            Feb.ToolTip = "Feb";
            Feb.Text = BindMonthWisePF(Feb, payheadId.Text, payhead.Text);

            Mar.ToolTip = "Mar";
            Mar.Text = BindMonthWisePF(Mar, payheadId.Text, payhead.Text);
            totPF = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
            Total.Text = totPF.ToString();

            AprGTotalPF = AprGTotalPF + Convert.ToDecimal(Apr.Text.Trim());
            MayGTotalPF = MayGTotalPF + Convert.ToDecimal(May.Text.Trim());
            JunGTotalPF = JunGTotalPF + Convert.ToDecimal(Jun.Text.Trim());
            JulGTotalPF = JulGTotalPF + Convert.ToDecimal(Jul.Text.Trim());
            AugGTotalPF = AugGTotalPF + Convert.ToDecimal(Aug.Text.Trim());
            SepGTotalPF = SepGTotalPF + Convert.ToDecimal(Sep.Text.Trim());
            OctGTotalPF = OctGTotalPF + Convert.ToDecimal(Oct.Text.Trim());
            NovGTotalPF = NovGTotalPF + Convert.ToDecimal(Nov.Text.Trim());
            DecGTotalPF = DecGTotalPF + Convert.ToDecimal(Dec.Text.Trim());
            JanGTotalPF = JanGTotalPF + Convert.ToDecimal(Jan.Text.Trim());
            FebGTotalPF = FebGTotalPF + Convert.ToDecimal(Feb.Text.Trim());
            MarGTotalPF = MarGTotalPF + Convert.ToDecimal(Mar.Text.Trim());


            if (payhead.Text.Trim().Equals("Professional Tax"))
            {
                Professional_Tax = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());

            }

            if (payhead.Text.Trim().Equals("PF"))
            {
                PFTotal = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
                lblPfTotal.Text = PFTotal.ToString();
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label AprT = (Label)e.Row.FindControl("lblAprT");
            Label MayT = (Label)e.Row.FindControl("lblMayT");
            Label JunT = (Label)e.Row.FindControl("lblJunT");
            Label JulT = (Label)e.Row.FindControl("lblJulT");
            Label AugT = (Label)e.Row.FindControl("lblAugT");
            Label SepT = (Label)e.Row.FindControl("lblSepT");
            Label OctT = (Label)e.Row.FindControl("lblOctT");
            Label NovT = (Label)e.Row.FindControl("lblNovT");
            Label DecT = (Label)e.Row.FindControl("lblDecT");
            Label JanT = (Label)e.Row.FindControl("lblJanT");
            Label FebT = (Label)e.Row.FindControl("lblFebT");
            Label MarT = (Label)e.Row.FindControl("lblMarT");
            Label FinalTotal = (Label)e.Row.FindControl("lblFTotal");
            AprT.Text = AprGTotalPF.ToString();
            MayT.Text = MayGTotalPF.ToString();
            JunT.Text = JunGTotalPF.ToString();
            JulT.Text = JulGTotalPF.ToString();
            AugT.Text = AugGTotalPF.ToString();
            SepT.Text = SepGTotalPF.ToString();
            OctT.Text = OctGTotalPF.ToString();
            NovT.Text = NovGTotalPF.ToString();
            DecT.Text = DecGTotalPF.ToString();
            JanT.Text = JanGTotalPF.ToString();
            FebT.Text = FebGTotalPF.ToString();
            MarT.Text = MarGTotalPF.ToString();

            decimal fTotal = AprGTotalPF + MayGTotalPF + JunGTotalPF + JulGTotalPF + AugGTotalPF + SepGTotalPF + OctGTotalPF + NovGTotalPF + DecGTotalPF + JanGTotalPF + FebGTotalPF + MarGTotalPF;

            FinalTotal.Text = fTotal.ToString();
            B = fTotal;
        }
    }

    protected void TaxDedu(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label dedu = (Label)e.Row.FindControl("lblAmount");
            Label secName = (Label)e.Row.FindControl("lblSN");

            if (secName.Text.Trim().Equals("LTA"))
            {
                //lblAmountT.Text = minLTA.ToString();

                decimal minLTA = Math.Min(Convert.ToDecimal(dedu.Text), ((totalBasic * Convert.ToDecimal(8.33)) / 100));
                dedu.Text = Math.Round(minLTA, 2).ToString();
            }
            taxDedTot = taxDedTot + Convert.ToDecimal(dedu.Text.Trim());
            lblAmountT.Text = taxDedTot.ToString();
            L = Convert.ToDecimal(lblAmountT.Text.Trim());

        }
        //else
        //{
        //    lblAmountT.Text = (Convert.ToDecimal(lblAmountT.Text.Trim()) + Convert.ToDecimal(lblPfTotal.Text.Trim())).ToString();
        //    L = Convert.ToDecimal(lblAmountT.Text.Trim());
        //}
        // lblAmountT.Text=(Convert.ToDecimal(lblAmountT.Text.Trim())+ Convert.ToDecimal(lblPfTotal.Text.Trim())).ToString();

    }

    protected void BindTotalDed()
    {
        lblAmountT.Text = (L + Convert.ToDecimal(lblPfTotal.Text.Trim())).ToString();

        L = Convert.ToDecimal(lblAmountT.Text.Trim());
    }




    protected void BindDueTax()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("sp_payroll_computetax_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empCode);
            cmd.Parameters.AddWithValue("@financial_year", financilYear);
            cmd.Parameters.AddWithValue("@taxable_amount", N);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    lblTTDue.Text = cmd.ExecuteScalar().ToString();
                    P = Convert.ToDecimal(lblTTDue.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }

    protected void grdItComputationPerformance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label payheadId = (Label)e.Row.FindControl("lblPayheadidPI");
            Label payhead = (Label)e.Row.FindControl("lblPayheadPI");
            Label Apr = (Label)e.Row.FindControl("lblAprPI");
            Label May = (Label)e.Row.FindControl("lblMayPI");
            Label Jun = (Label)e.Row.FindControl("lblJunPI");
            Label Jul = (Label)e.Row.FindControl("lblJulPI");
            Label Aug = (Label)e.Row.FindControl("lblAugPI");
            Label Sep = (Label)e.Row.FindControl("lblSepPI");
            Label Oct = (Label)e.Row.FindControl("lblOctPI");
            Label Nov = (Label)e.Row.FindControl("lblNovPI");
            Label Dec = (Label)e.Row.FindControl("lblDecPI");
            Label Jan = (Label)e.Row.FindControl("lblJanPI");
            Label Feb = (Label)e.Row.FindControl("lblFebPI");
            Label Mar = (Label)e.Row.FindControl("lblMarPI");

            Label Total = (Label)e.Row.FindControl("lblTotalPI");

            Apr.ToolTip = "Apr";
            Apr.Text = BindMonthWisePer(Apr, payheadId.Text, payhead.Text);

            May.ToolTip = "May";
            May.Text = BindMonthWisePer(May, payheadId.Text, payhead.Text);

            Jun.ToolTip = "Jun";
            Jun.Text = BindMonthWisePer(Jun, payheadId.Text, payhead.Text);

            Jul.ToolTip = "Jul";
            Jul.Text = BindMonthWisePer(Jul, payheadId.Text, payhead.Text);

            Aug.ToolTip = "Aug";
            Aug.Text = BindMonthWisePer(Aug, payheadId.Text, payhead.Text);

            Sep.ToolTip = "Sep";
            Sep.Text = BindMonthWisePer(Sep, payheadId.Text, payhead.Text);

            Oct.ToolTip = "Oct";
            Oct.Text = BindMonthWisePer(Oct, payheadId.Text, payhead.Text);

            Nov.ToolTip = "Nov";
            Nov.Text = BindMonthWisePer(Nov, payheadId.Text, payhead.Text);

            Dec.ToolTip = "Dec";
            Dec.Text = BindMonthWisePer(Dec, payheadId.Text, payhead.Text);

            Jan.ToolTip = "Jan";
            Jan.Text = BindMonthWisePer(Jan, payheadId.Text, payhead.Text);

            Feb.ToolTip = "Feb";
            Feb.Text = BindMonthWisePer(Feb, payheadId.Text, payhead.Text);

            Mar.ToolTip = "Mar";
            Mar.Text = BindMonthWisePer(Mar, payheadId.Text, payhead.Text);
            totPI = Convert.ToDecimal(Apr.Text.Trim()) + Convert.ToDecimal(May.Text.Trim()) + Convert.ToDecimal(Jun.Text.Trim()) + Convert.ToDecimal(Jul.Text.Trim()) + Convert.ToDecimal(Aug.Text.Trim()) + Convert.ToDecimal(Sep.Text.Trim()) + Convert.ToDecimal(Oct.Text.Trim()) + Convert.ToDecimal(Nov.Text.Trim()) + Convert.ToDecimal(Dec.Text.Trim()) + Convert.ToDecimal(Jan.Text.Trim()) + Convert.ToDecimal(Feb.Text.Trim()) + Convert.ToDecimal(Mar.Text.Trim());
            Total.Text = totPI.ToString();

            AprGTotalPI = AprGTotalPI + Convert.ToDecimal(Apr.Text.Trim());
            MayGTotalPI = MayGTotalPI + Convert.ToDecimal(May.Text.Trim());
            JunGTotalPI = JunGTotalPI + Convert.ToDecimal(Jun.Text.Trim());
            JulGTotalPI = JulGTotalPI + Convert.ToDecimal(Jul.Text.Trim());
            AugGTotalPI = AugGTotalPI + Convert.ToDecimal(Aug.Text.Trim());
            SepGTotalPI = SepGTotalPI + Convert.ToDecimal(Sep.Text.Trim());
            OctGTotalPI = OctGTotalPI + Convert.ToDecimal(Oct.Text.Trim());
            NovGTotalPI = NovGTotalPI + Convert.ToDecimal(Nov.Text.Trim());
            DecGTotalPI = DecGTotalPI + Convert.ToDecimal(Dec.Text.Trim());
            JanGTotalPI = JanGTotalPI + Convert.ToDecimal(Jan.Text.Trim());
            FebGTotalPI = FebGTotalPI + Convert.ToDecimal(Feb.Text.Trim());
            MarGTotalPI = MarGTotalPI + Convert.ToDecimal(Mar.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label AprT = (Label)e.Row.FindControl("lblAprPI");
            Label MayT = (Label)e.Row.FindControl("lblMayPI");
            Label JunT = (Label)e.Row.FindControl("lblJunPI");
            Label JulT = (Label)e.Row.FindControl("lblJulPI");
            Label AugT = (Label)e.Row.FindControl("lblAugPI");
            Label SepT = (Label)e.Row.FindControl("lblSepPI");
            Label OctT = (Label)e.Row.FindControl("lblOctPI");
            Label NovT = (Label)e.Row.FindControl("lblNovPI");
            Label DecT = (Label)e.Row.FindControl("lblDecPI");
            Label JanT = (Label)e.Row.FindControl("lblJanPI");
            Label FebT = (Label)e.Row.FindControl("lblFebPI");
            Label MarT = (Label)e.Row.FindControl("lblMarPI");
            Label FinalTotal = (Label)e.Row.FindControl("lblFTotalPI");
            AprT.Text = AprGTotalPI.ToString();
            MayT.Text = MayGTotalPI.ToString();
            JunT.Text = JunGTotalPI.ToString();
            JulT.Text = JulGTotalPI.ToString();
            AugT.Text = AugGTotalPI.ToString();
            SepT.Text = SepGTotalPI.ToString();
            OctT.Text = OctGTotalPI.ToString();
            NovT.Text = NovGTotalPI.ToString();
            DecT.Text = DecGTotalPI.ToString();
            JanT.Text = JanGTotalPI.ToString();
            FebT.Text = FebGTotalPI.ToString();
            MarT.Text = MarGTotalPI.ToString();

            fTotalPI = AprGTotalPI + MayGTotalPI + JunGTotalPI + JulGTotalPI + AugGTotalPI + SepGTotalPI + OctGTotalPI + NovGTotalPI + DecGTotalPI + JanGTotalPI + FebGTotalPI + MarGTotalPI;

            FinalTotal.Text = fTotalPI.ToString();
            A1 = fTotalPI;
        }
    }

    protected void btnGenPDF_Click(object sender, EventArgs e)
    {
        //string attachment = "attachment; filename=Article.pdf";

        //Response.ClearContent();

        //Response.AddHeader("content-disposition", attachment);

        //Response.ContentType = "application/pdf";

        //StringWriter stw = new StringWriter();

        //HtmlTextWriter htextw = new HtmlTextWriter(stw);

        //dvText.RenderControl(htextw);

        //Document document = new Document();

        //PdfWriter.GetInstance(document, Response.OutputStream);

        //document.Open();

        //StringReader str = new StringReader(stw.ToString());

        //HTMLWorker htmlworker = new HTMLWorker(document);

        //htmlworker.Parse(str);

        //document.Close();

        //Response.Write(document);

        //Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}
