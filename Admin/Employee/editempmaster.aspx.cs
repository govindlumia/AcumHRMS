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
using DataAccessLayer;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Utilities;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Globalization;

public partial class editempmaster : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    DataTable Bucket = new DataTable();
    DataRow dr;
    static int counter = 0;
    int clickCount = 0;
    static int checkForSession = 0;
    public static DataTable dt = new DataTable();
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    int isUpdate = 0;

    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        string emp_code = string.Empty;
        string companyid = string.Empty;
        lbl_msg.Text = "";
        //doj.Attributes.Add("ReadOnly", "ReadOnly");
        //txtsalary.Attributes.Add("ReadOnly", "ReadOnly");
        //txt_DOB.Attributes.Add("ReadOnly", "ReadOnly");
        txt_doa.Attributes.Add("ReadOnly", "ReadOnly");
        //txtdoleaving.Attributes.Add("ReadOnly", "ReadOnly");
        //txtdorelieving.Attributes.Add("ReadOnly", "ReadOnly");
        Ttxtunderwriter.Attributes.Add("ReadOnly", "ReadOnly");
        Txt_rep_underwriter.Attributes.Add("ReadOnly", "ReadOnly");
        //TxtPassportexpdate.Attributes.Add("ReadOnly", "ReadOnly");
        //TxtSpouseDOb.Attributes.Add("ReadOnly", "ReadOnly");
       // TxtValidFrm.Attributes.Add("ReadOnly", "ReadOnly");
        lblphoto.Visible = true;
        if(Session["Role"] != null && Session["Role"].ToString() !="")
        {
            if (Session["Role"].ToString() == "4")
            {
                emp_code = Session["EmpCode"].ToString();
            }
            else
            {
                emp_code = Request.QueryString["empcode"].ToString();
                ViewState["EmpCode1"] = emp_code;

                companyid = Request.QueryString["companyid"].ToString();
                ViewState["Companyid"] = companyid;
            }
        }
        

        if (!IsPostBack)
        {
            checkForSession = 0;
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                { }
                //Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            if (Session["Child"] != null)
            {
                Session.Remove("Child");
            }
            if (Session["acc_education"] != null)
            {
                Session.Remove("acc_education");
            }
            if (Session["Pro_education"] != null)
            {
                Session.Remove("Pro_education");
            }
            if (Session["exp"] != null)
            {
                Session.Remove("exp");
            }
            if (Session["Attachment"] != null)
            {
                Session.Remove("Attachment");
            }
            if (Session["Pro_reporting"] != null)
            {
                Session.Remove("Pro_reporting");
            }
            if (Session["Pro_reporting_underwriter"] != null)
            {
                Session.Remove("Pro_reporting_underwriter");
            }

            FillControl();
            TabContainer1.ActiveTabIndex = 0;
            //doj.Text = System.DateTime.Now.ToShortDateString();
            bind_job_detail(emp_code);
            bind_contactdetails(emp_code);
            bind_personalinfo(emp_code);
            bind_child(emp_code);
            bind_Education_Qualification(emp_code);
            bind_Professional_Qualification(emp_code);
            bind_Exp_detail(emp_code);
            bind_payrolldetails(emp_code);
            //bind_Insurancedetail(emp_code);
            //bind_salarydetail(emp_code);
            //bind_Attachment(emp_code);
            BindAttachment(emp_code);
            Bind_reporting_detail(emp_code);
            Bind_reporting_underwriter_detail(emp_code);
            CheckPermission();
            ValidatepassportExpiryDate(emp_code);


        }
    }

    //----Passport valid validation-------
    protected void ValidatepassportExpiryDate(string empcode)
    {
        DateTime CurrentDate = System.DateTime.Now;
        DateTime PassportDate;
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();
        userentity.Empcode = empcode;
        ds = objSelectALL.SelectPersonalDetails(userentity);
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["passportvalidDate"].ToString()))
        {
            PassportDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportvalidDate"].ToString());
            if (PassportDate <= CurrentDate)
            {

                TxtPassportexpdate.BackColor = System.Drawing.Color.Red;
            }
        }
    }

    private void BindAttachment(string empCode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empCode;
        ds = objSelectALL.SelectAttachmentDetails(userentity);
        grdDocument.DataSource = ds;
        grdDocument.DataBind();
    }
    //------------- bind the Job Detail of the emp master ----------------------------------------

    protected void bind_job_detail(string emp_code)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = emp_code;
        ds = objSelectALL.SelectJobDetails(userentity);
        Session["JobDetail"] = ds;
        if (ds.Tables[0].Rows.Count < 1)
            return;
        txtcompanyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
        drpgender.SelectedValue = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
        txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
        txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
        drpempstatus.SelectedValue = ds.Tables[0].Rows[0]["emp_status"].ToString();
        drpcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        //drpjobtype.SelectedValue = ds.Tables[0].Rows[0]["Job_type"].ToString();
        drprole.SelectedValue = ds.Tables[0].Rows[0]["role1"].ToString();
        drpdegination.SelectedValue = ds.Tables[0].Rows[0]["degination_id"].ToString();
       // drphbu.SelectedValue = ds.Tables[0].Rows[0]["HomeBU"].ToString();
        //drp_sbu.SelectedValue = ds.Tables[0].Rows[0]["SecondaryBU"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
        {
            doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();
        }

        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doleaving"].ToString()))
        {

            txtdoleaving.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doleaving"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtdoleaving.Text = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
        }
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["salary_cal_from"].ToString()))
        {
            txtsalary.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["salary_cal_from"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtsalary.Text = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();
        }
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doreleiving"].ToString()))
        {
            txtdorelieving.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doreleiving"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtdorelieving.Text = ds.Tables[0].Rows[0]["emp_doreleiving"].ToString();
        }
        txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();
        lblphoto.Text = ds.Tables[0].Rows[0]["photo"].ToString();
        //ViewState.Add("Photo", ds.Tables[0].Rows[0]["branch_id"].ToString());
        ViewState["PhotoName"] = lblphoto.Text;
        //if (Session["empcode"].ToString() != "AEC-895")
        //drprole.Enabled = false;


    }

    //------------Bind Insurance Details of Employee-----------------
    //protected void bind_Insurancedetail(string empcode)
    //{
    //    EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
    //    EmpInsuranceENT userentity = new EmpInsuranceENT();

    //    userentity.Empcode = empcode;
    //    ds = objSelectALL.SelectInsuranceDetail(userentity);
    //    dt = ds.Tables[0];
    //    if (dt.Rows.Count < 1)
    //        return;
    //    TxtPolicyName.Text = dt.Rows[0]["policyname"].ToString();
    //    TxtInsurance.Text = dt.Rows[0]["InscmpyName"].ToString();
    //    TxtCustID.Text = dt.Rows[0]["CustomerID"].ToString();
    //    if (!string.IsNullOrEmpty(dt.Rows[0]["Validfrom"].ToString()))
    //    {
    //        TxtValidFrm.Text = Convert.ToDateTime(dt.Rows[0]["Validfrom"].ToString()).ToString("dd-MMM-yyyy");
    //    }
    //    else
    //    {
    //        TxtValidFrm.Text = dt.Rows[0]["Validfrom"].ToString();
    //    }
    //    TxtPolicyLimit.Text = dt.Rows[0]["PolicyLimit"].ToString();

    //}

    //------------Bind Payroll Details of Employee-----------------
    protected void bind_payrolldetails(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectpayrollDetails(userentity);
        Session["PayRollDetail"] = ds;
        if (ds.Tables[0].Rows.Count < 1)
            return;
        esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
        esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
        pfno.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
        pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
        panno.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
        ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
    }

    //------------Bind Contact Details of Employee-----------------
    protected void bind_contactdetails(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectContactDetails(userentity);
        Session["ContactDetail"] = ds;
        if (ds.Tables[0].Rows.Count < 1)
            return;

        txt_pre_add1.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();
        txt_pre_Add2.Text = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
        txt_pre_city.Text = ds.Tables[0].Rows[0]["pre_city"].ToString();
        txt_pre_state.Text = ds.Tables[0].Rows[0]["pre_state"].ToString();
        txt_pre_country.Text = ds.Tables[0].Rows[0]["pre_country"].ToString();
        txt_pre_zip.Text = ds.Tables[0].Rows[0]["pre_zip"].ToString();
        txt_pre_phone.Text = ds.Tables[0].Rows[0]["pre_phone"].ToString();
        txt_per_add1.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();
        txt_per_add2.Text = ds.Tables[0].Rows[0]["per_add2"].ToString();
        txt_per_city.Text = ds.Tables[0].Rows[0]["per_city"].ToString();
        txt_per_state.Text = ds.Tables[0].Rows[0]["per_state"].ToString();
        txt_per_country.Text = ds.Tables[0].Rows[0]["per_country"].ToString();
        txt_per_zip.Text = ds.Tables[0].Rows[0]["per_zip"].ToString();
        txt_per_phone.Text = ds.Tables[0].Rows[0]["per_phone"].ToString();
        Txt_emr_name.Text = ds.Tables[0].Rows[0]["Emergencycontactname"].ToString();
        txt_emr_no.Text = ds.Tables[0].Rows[0]["Emergencyphoneno"].ToString();

        if (ds.Tables[0].Rows[0]["mode"].ToString() == "1")
        {
            optcompany.Checked = true;
            txtmodeoftransport.Text = "";
            txtmodeoftransport.Visible = true;
        }
        else
        {
            optown.Checked = true;
            txtmodeoftransport.Text = "";
            txtmodeoftransport.Visible = false;
        }
    }



    //------------Bind Personal Details of Employee-----------------
    protected void bind_personalinfo(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectPersonalDetails(userentity);
        Session["PersonalDetail"] = ds;
        if (ds.Tables[0].Rows.Count < 1)
            return;

        txt_f_f_name.Text = ds.Tables[0].Rows[0]["f_fname"].ToString();
        txt_m_fname.Text = ds.Tables[0].Rows[0]["m_fname"].ToString();
        txtaadharnumber.Text = ds.Tables[0].Rows[0]["AadhaarNumber"].ToString();
        drpBloodGroup.SelectedValue = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
        ddlpersonalstatus.SelectedValue = ds.Tables[0].Rows[0]["maritalstatus"].ToString();
        txtrelg.Text = ds.Tables[0].Rows[0]["religion"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["doa"].ToString()))
        {
            txt_doa.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["doa"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txt_doa.Text = ds.Tables[0].Rows[0]["doa"].ToString();
        }

        txt_dl_no.Text = ds.Tables[0].Rows[0]["NameINBank"].ToString();
        txt_sp_fname.Text = ds.Tables[0].Rows[0]["s_fname"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["dob"].ToString()))
        {
            txt_DOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txt_DOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
        }

        //txtmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
        txt_email.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
        txtAltEmailId.Text = ds.Tables[0].Rows[0]["altemail_id"].ToString();
        //txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
        //txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["passportvalidDate"].ToString()))
        {
            TxtPassportexpdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportvalidDate"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            TxtPassportexpdate.Text = ds.Tables[0].Rows[0]["passportvalidDate"].ToString();
        }
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["s_dob"].ToString()))
        {
            TxtSpouseDOb.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["s_dob"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            TxtSpouseDOb.Text = ds.Tables[0].Rows[0]["s_dob"].ToString();
        }
        txt_passportno.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
        if (ddlpersonalstatus.SelectedValue.ToString() == "Married")
        {
            tbl1.Visible = true;
        }
        if (ddlpersonalstatus.SelectedValue.ToString() == "Unmarried")
        {
            tbl1.Visible = false;
        }

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["pay"]) == 0)
        {
            rbtnbank.Checked = true;
            rbtncheque.Checked = false;
            rbtncash.Checked = false;

            paymentmode.Visible = true;

            ddl_bank_name.SelectedValue = ds.Tables[0].Rows[0]["bank_name"].ToString();
            txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();

            ddl_bank_name_reimbursement.SelectedValue = ds.Tables[0].Rows[0]["bank_name_reimbursement"].ToString();
            txt_bank_ac_reimbursement.Text = ds.Tables[0].Rows[0]["ac_number_reimbursement"].ToString();
        }
        else
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["pay"]) == 1)
            {
                rbtnbank.Checked = false;
                rbtncheque.Checked = true;
                rbtncash.Checked = false;
                paymentmode.Visible = false;
            }
            else
            {
                rbtnbank.Checked = false;
                rbtncheque.Checked = false;
                rbtncash.Checked = true;
                paymentmode.Visible = false;
            }
        }
    }
    //------------Bind Child Details of Employee-----------------
    protected void bind_child(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectChildrenDetails(userentity);
        Session["ChildDetail"] = ds;
        if (ds.Tables[0].Rows.Count < 1)
            return;
        if (Session["acc_education"] == null)
        {
            create_child_table();
        }
        DataRow dr;
        DataTable dtable;

        dtable = (DataTable)Session["child"];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            dr = dtable.NewRow();


            dr["child_name"] = ds.Tables[0].Rows[i]["child_name"].ToString();
            dr["child_dob"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["child_dob"].ToString()).ToString("dd-MMM-yyyy");



            //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
            //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



            dtable.Rows.Add(dr);
        }
        Session["child"] = dtable;
        BindList_child();


    }
    //------------Bind Professional Details of Employee-----------------
    protected void bind_Professional_Qualification(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectProfessionalDetails(userentity);
        Session["ProfessionalDetail"] = ds;
        ViewState["Prosessional"] = ds.Tables[0];
        if (isUpdate == 1)
        {
            BindList_pro_edu_update();
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (Session["Pro_education"] == null)
            {
                create_Pro_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dr["id"] = ds.Tables[0].Rows[i]["id"].ToString();
                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["month_from"] = ds.Tables[0].Rows[i]["month_from"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["month_to"] = ds.Tables[0].Rows[i]["month_to"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["Pro_education"] = dtable;
            BindList_pro_edu();

        }
    }
    //------------Bind Experience Details of Employee-----------------
    protected void bind_Exp_detail(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectExperienceDetails(userentity);
        Session["ExpDetail"] = ds;

        ViewState["ExpDetail"] = ds.Tables[0];
        if (isUpdate == 1)
        {
            UpdateExpereience();
            BindList_exp_update();
            return;
        }
        if (ds.Tables[0].Rows.Count < 1)
            return;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        DataRow dr;

        int year = 0, month = 0, day = 0;
        int year1 = 0, month1 = 0, day1 = 0;
        DataTable dtable;
        dtable = (DataTable)Session["exp"];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            dr = dtable.NewRow();
            dr["id"] = ds.Tables[0].Rows[i]["id"].ToString();
            dr["comp_name"] = ds.Tables[0].Rows[i]["comp_name"].ToString();
            dr["location"] = ds.Tables[0].Rows[i]["location"].ToString();
            dr["Designation"] = ds.Tables[0].Rows[i]["designation"].ToString();
            dr["datefrom"] = ds.Tables[0].Rows[i]["datefrom"].ToString();
            dr["date_to_sort"] = ds.Tables[0].Rows[i]["datefrom"].ToString();
            dr["dateto"] = ds.Tables[0].Rows[i]["dateto"].ToString();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 100);
            sqlparm[0].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["datefrom"].ToString());
            sqlparm[1] = new SqlParameter("@Todate", SqlDbType.DateTime, 100);
            if (ds.Tables[0].Rows[i]["dateto"].ToString() == "Till Now")
            {
                sqlparm[1].Value = System.DateTime.Now.ToString();
            }
            else
            {
                sqlparm[1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["dateto"].ToString());
            }
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifference", sqlparm);
            dr["duration"] = ds1.Tables[0].Rows[0]["result"].ToString();

            //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
            //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";
            ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifferenceNumeric", sqlparm);
            year = year + Convert.ToInt32(ds2.Tables[0].Rows[0]["years"].ToString());
            month = month + Convert.ToInt32(ds2.Tables[0].Rows[0]["months"].ToString());
            day = day + Convert.ToInt32(ds2.Tables[0].Rows[0]["days"].ToString());

            dtable.Rows.Add(dr);

        }

        //if (day > 30)
        //{
        //    if (day % 30 != 0)
        //    {
        //        day1 = day % 30;
        //        month1 = 1;
        //        month = month + month1;
        //    }
        //    else
        //    {
        //        day1 = day;
        //    }
        //}
        //else
        //{
        //    day1 = day;
        //}
        //if (month >= 12)
        //{
        //    if (month % 12 != 0)
        //    {
        //        month1 = Convert.ToInt32(month % 12);
        //        year1 = 1;
        //    }
        //    else
        //    {
        //        month1 = month1 + month;
        //    }
        //}
        //else
        //{
        //    month1 = month1 + month;
        //}

        //year1 = year1 + year;

        day1 = day % 30;
        month1 = day / 30;


        month += month1;
        year1 = month / 12;
        month1 = month % 12;

        year1 += year;


        Txttotal.Text = Convert.ToString(year1).ToString() + " " + "years" + ' ' + Convert.ToString(month1).ToString() + " " + "months" + " " + Convert.ToString(day1).ToString() + " " + "days";

        Session["exp"] = dtable;
        BindList_exp();

    }

    protected void UpdateExpereience()
    {
        dtable = (DataTable)ViewState["ExpDetail"];
        dtable.Columns.Add(new DataColumn("duration"));

        foreach (DataRow dr in dtable.Rows)
        {
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 100);
            sqlparm[0].Value = Utility.DateTimeForat(dr["datefrom"].ToString());
            sqlparm[1] = new SqlParameter("@Todate", SqlDbType.DateTime, 100);
            if (dr["dateto"].ToString() == "Till Now")
            {
                sqlparm[1].Value = System.DateTime.Now.ToString();
            }
            else
            {
                sqlparm[1].Value = Utility.DateTimeForat(dr["dateto"].ToString());
            }
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifference", sqlparm);
            dr["duration"] = ds1.Tables[0].Rows[0]["result"].ToString();


        }
        Session["Experience1"] = dtable;


    }
    //------------- bind the Reporting Detail of the emp master ----------------------------------------
    protected void Bind_reporting_detail(string empcode)
    {
        EmployeeViewBusiness objSelectAll = new EmployeeViewBusiness();
        EmpReportingENT userentity = new EmpReportingENT();
        userentity.EmpCode = empcode;
        userentity.Approverpriority = 1;
        ds = objSelectAll.SelectReportingDetails(userentity);

        if (ds.Tables[0].Rows.Count > 0)
        {
            EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
            ObjEmpJobDetailENT.Empcode = ds.Tables[0].Rows[0]["approverid"].ToString();
            ObjEmpJobDetailENT.Degination_id = 0;
            ObjEmpJobDetailENT.Category_id = 0;
            ObjEmpJobDetailENT.Status = false;
            ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
            ObjEmpJobDetailENT.EmployeeCode = "0";
            ObjEmpJobDetailENT.Emp_fname = "";
            EmpJobDetailBusiness ObjEmpJobDetail = new EmpJobDetailBusiness();
            ds1 = ObjEmpJobDetail.SelectEmployeeJobDetail(ObjEmpJobDetailENT);
            create_app_underwriter();
            DataTable dtable = new DataTable();
            DataRow dr;
            dtable = (DataTable)Session["Pro_reporting"];

            dr = dtable.NewRow();
            dr["approverid"] = ds1.Tables[0].Rows[0]["EMPCODE"].ToString();
            dr["approvername"] = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
            dr["category"] = ds1.Tables[0].Rows[0]["CategoryName"].ToString();
            //dr["BU"] = ds1.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            dr["designation"] = ds1.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
            dr["approverpriority"] = ds.Tables[0].Rows[0]["approverpriority"].ToString();
            dtable.Rows.Add(dr);
            Session["Pro_reporting"] = dtable;
        }
        if (Session["Pro_reporting"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            DataTable dtable = new DataTable();
            dtable = (DataTable)Session["Pro_reporting"];
            dview = new DataView(dtable);
            dview.Sort = "approvername";
        }

        Grid_approval.DataSource = dview;
        Grid_approval.DataBind();


    }

    //------------- bind the Reporting Underwriter Detail of the emp master ----------------------------------------
    protected void Bind_reporting_underwriter_detail(string empcode)
    {
        EmployeeViewBusiness objSelectAll = new EmployeeViewBusiness();
        EmpReportingENT userentity = new EmpReportingENT();
        userentity.EmpCode = empcode;
        userentity.Approverpriority = 2;
        ds = objSelectAll.SelectReportingDetails(userentity);

        if (ds.Tables[0].Rows.Count > 0)
        {
            EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
            ObjEmpJobDetailENT.Empcode = ds.Tables[0].Rows[0]["approverid"].ToString();
            ObjEmpJobDetailENT.Degination_id = 0;
            ObjEmpJobDetailENT.Category_id = 0;
            ObjEmpJobDetailENT.Status = false;
            ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
            ObjEmpJobDetailENT.EmployeeCode = "0";
            ObjEmpJobDetailENT.Emp_fname = "";
            EmpJobDetailBusiness ObjEmpJobDetail = new EmpJobDetailBusiness();
            ds1 = ObjEmpJobDetail.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

            create_app_rep_underwriter();
            dtable = (DataTable)Session["Pro_reporting_underwriter"];

            dr = dtable.NewRow();
            dr["approverid"] = ds1.Tables[0].Rows[0]["EMPCODE"].ToString();
            dr["approvername"] = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
            dr["category"] = ds1.Tables[0].Rows[0]["CategoryName"].ToString();
            //dr["BU"] = ds1.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            dr["designation"] = ds1.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
            dr["approverpriority"] = ds.Tables[0].Rows[0]["approverpriority"].ToString();
            dtable.Rows.Add(dr);
            Session["Pro_reporting_underwriter"] = dtable;
        }
        if (Session["Pro_reporting_underwriter"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_reporting_underwriter"];
            dview = new DataView(dtable);
            dview.Sort = "approvername";
        }


        Grid_rep_approval.DataSource = dview;
        Grid_rep_approval.DataBind();

    }
    //------------------------------------- Bind Education Qualifications-------------------------------
    protected void bind_Education_Qualification(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectEducationalDetails(userentity);
        Session["EducationDetail"] = ds;
        ViewState["Education"] = ds.Tables[0];
        if (isUpdate == 1)
        {
            BindList_acc_edu_Update();
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["acc_education"] == null)
            {
                create_acc_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            //dtable = (DataTable)Session["EducationDetail"];
            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dr["id"] = ds.Tables[0].Rows[i]["id"].ToString();
                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }

            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }

    }



    //--------------------insert the job detail and login details -----------------------

    protected int edit_Job_detail(string emp_code)
    {
        //edit_Job_detail_Audit();

        EmployeeEditBussiness empBusiness = new EmployeeEditBussiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();
        LoginENT userEntity1 = new LoginENT();
        userentity.Empcode = txtempcode.Text;
        userentity.Card_no = txt_card_no.Text;
        userentity.Emp_gender = drpgender.SelectedItem.ToString();
        userentity.Emp_fname = txtfirstname.Text;
        userentity.Emp_m_name = txtmiddlename.Text;
        userentity.Emp_l_name = txtlastname.Text;
        userentity.Emp_status = Convert.ToInt32(drpempstatus.SelectedValue);
        userentity.Category_id = Convert.ToInt32(drpcategory.SelectedValue);
        userentity.Degination_id = Convert.ToInt32(drpdegination.SelectedValue);
        //userentity.Home_Bussiness_unit = Convert.ToInt32(drphbu.SelectedValue);
        //userentity.Secondary_Bussiness_Unit = Convert.ToInt32(drp_sbu.SelectedValue);
        //userentity.JobType = Convert.ToInt32(drpjobtype.SelectedValue);
        if (doj.Text != "")
        {
            userentity.Emp_doj = Utilities.Utility.DateTimeForat(doj.Text.ToString());
        }

        if (txtdorelieving.Text != "")
        {
            userentity.Emp_doreleiving = Utilities.Utility.DateTimeForat(txtdorelieving.Text.ToString());
        }

        if (txtdoleaving.Text != "")
        {
            userentity.Emp_doleaving = Utilities.Utility.DateTimeForat(txtdoleaving.Text.ToString());
        }

        if (txtsalary.Text != "")
        {
            userentity.Salary_cal_from = Utilities.Utility.DateTimeForat(txtsalary.Text.ToString());
        }

        userentity.Photo = lblphoto.Text;
        userentity.EmployeeCode = Session["EmpCode"].ToString();
        userEntity1.Login_id = txt_login_id.Text;
        userEntity1.Role = Convert.ToInt32(drprole.SelectedValue);
        int result = empBusiness.EditJobDetails(userentity, userEntity1);
        return result;

    }
    //private void edit_Job_detail_Audit()
    //{
    //    DataSet ds = (DataSet)Session["JobDetail"];
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (txtfirstname.Text != ds.Tables[0].Rows[0]["emp_fname"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "First Name";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["emp_fname"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txtfirstname.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }

    //        if (txtlastname.Text != ds.Tables[0].Rows[0]["emp_l_name"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Last Name";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txtlastname.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (drpempstatus.SelectedValue != ds.Tables[0].Rows[0]["emp_status"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Status";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["employeestatus"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = drpempstatus.SelectedItem.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (drpcategory.SelectedValue != ds.Tables[0].Rows[0]["category"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Category";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["CategoryName"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = drpcategory.SelectedItem.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        //if (drpjobtype.SelectedValue != ds.Tables[0].Rows[0]["degination_id"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Job Type";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["DesgCode"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = drpjobtype.SelectedItem.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        //if (drpdivision.SelectedValue != ds.Tables[0].Rows[0]["division_id"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Division";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["division_name"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = drpdivision.SelectedItem.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        if (drpdegination.SelectedValue != ds.Tables[0].Rows[0]["degination_id"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Designation";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["designationname"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = drpdegination.SelectedItem.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        //if (drphbu.SelectedValue != ds.Tables[0].Rows[0]["HomeBU"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Home Bussiness Unit";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = drphbu.SelectedItem.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        if (drpgender.SelectedValue != ds.Tables[0].Rows[0]["emp_gender"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Gender";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = drpgender.SelectedItem.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        //if (txtext.Text != ds.Tables[0].Rows[0]["ext_number"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Extension No";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["ext_number"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txtext.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        if (txt_login_id.Text != ds.Tables[0].Rows[0]["login_id"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Login Id";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["login_id"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_login_id.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (drprole.SelectedValue != ds.Tables[0].Rows[0]["role"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Role";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["role"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = drprole.SelectedItem.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        //if (txtreason.Text != ds.Tables[0].Rows[0]["reason_leaving"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Reason of Leaving";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["reason_leaving"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txtreason.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        //if (doj.Text != ds.Tables[0].Rows[0]["emp_doj"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Date of Joining";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["emp_doj"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = doj.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        //if (txtdol.Text != ds.Tables[0].Rows[0]["emp_doleaving"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Date of Leaving";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txtdol.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        //if (txtsalary.Text != ds.Tables[0].Rows[0]["salary_cal_from"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Salary Calculate From";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txtsalary.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //    }
    //}
    protected void edit_login_role(string emp_code)
    {

        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.NChar, 20);
        sqlparam[0].Value = emp_code;

        sqlparam[1] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam[1].Value = drprole.SelectedValue;

        string sqlstr = "UPDATE tbl_login SET role=@role WHERE empcode=@emp_code";
        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparam);
    }


    protected void InsertPhoto()
    {
        Random nxt = new Random();
        string fileName = ViewState["EmpCode1"].ToString() + "_" + nxt.Next().ToString() + FileUpload1.PostedFile.FileName.Replace(" ", "_").ToString();

        if ((System.IO.Path.GetExtension(fileName) == ".jpg") || (System.IO.Path.GetExtension(fileName) == ".jpeg")
             || (System.IO.Path.GetExtension(fileName) == ".gip") || (System.IO.Path.GetExtension(fileName) == ".png"))
        {
            if (System.IO.File.Exists(Server.MapPath("~") + "\\UploadPhoto\\" + fileName))
                System.IO.File.Delete(Server.MapPath("~") + "\\UploadPhoto\\" + fileName);

            string files = Server.MapPath("~") + "\\UploadPhoto\\";
            string FilePath = files + fileName;

            lblphoto.Text = fileName;
            FileUpload1.SaveAs(FilePath);
        }
    }
    //--------------------insert the Payroll Detail-----------------------

    protected void edit_payroll_detail(string empcode)
    {
        //edit_payroll_detail_Audit();
        EmployeeEditBussiness empBusiness = new EmployeeEditBussiness();
        EmpPayrollENT userentity = new EmpPayrollENT();
        userentity.Empcode = empcode;
        userentity.Esi_no = esino.Text.Trim().ToString();
        userentity.Pf_no = pfno.Text.Trim().ToString();
        userentity.Pan_no = panno.Text.Trim().ToString();
        userentity.Esi_disp = esidesp.Text.Trim().ToString();
        userentity.Pf_no_dept = pfno_dept.Text.Trim().ToString();
        userentity.Ward = ward.Text.Trim().ToString();
        userentity.EmployeeCode = Session["EmpCode"].ToString();

        int result = empBusiness.EditPayrollDetails(userentity);

    }
    //private void edit_payroll_detail_Audit()
    //{
    //    DataSet ds = (DataSet)Session["PayRollDetail"];
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (esino.Text != ds.Tables[0].Rows[0]["esi_no"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "ESI No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["esi_no"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = esino.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (esidesp.Text != ds.Tables[0].Rows[0]["esi_disp"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "ESI DISP";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["esi_disp"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = esidesp.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (pfno.Text != ds.Tables[0].Rows[0]["pf_no"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "PF No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pf_no"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = pfno.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (pfno_dept.Text != ds.Tables[0].Rows[0]["pf_no_dept"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Dept PF No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = pfno_dept.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (panno.Text != ds.Tables[0].Rows[0]["pan_no"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "PAN No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pan_no"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = panno.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (ward.Text != ds.Tables[0].Rows[0]["ward"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "WARD";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["ward"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = ward.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //    }
    //}

    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {

        if ((drpempstatus.SelectedValue.Equals("10") || drpempstatus.SelectedValue.Equals("11") || drpempstatus.SelectedValue.Equals("12") || drpempstatus.SelectedValue.Equals("13")) && (txtdoleaving.Text=="" || txtdorelieving.Text==""))
        {
            General.Alert("please assign date of resign & date of relieving",btngeneralsubmit);
            return;
        }


        if (Grid_approval.Rows.Count < 1)
        {
            General.Alert("Please add atleast one reporting manager", btngeneralsubmit);
            return;
        }

        if (flUpload.HasFile)
            ViewState["DocName"] = flUpload.FileName;


        string emp_code = Request.QueryString["empcode"].ToString();
        if (FileUpload1.HasFile)
        {
            InsertPhoto();
        }

        int result = edit_Job_detail(emp_code);

        if (result > 0)
        {
            //  insert_Log_in_detail();
            Session.Add("Inserted_Emp_code", txtempcode.Text);
            Session["cardNo"] = txt_card_no.Text;
            // InsertPhoto(Session["cardNo"].ToString());
            Edit_Educational_Qualification(emp_code);
            edit_Professional_Qualification(emp_code);
            edit_Expriece_detail(emp_code);
            edit_personal_detail(emp_code);
            edit_Children_detail(emp_code);
            edit_contact_detail(emp_code);
            edit_payroll_detail(emp_code);
            //edit_salary_detail(emp_code);
            Edit_Reporting_detail(emp_code);
            Edit_Reporting_underwriter_detail(emp_code);
           // edit_insurance_detail(emp_code);
            InsertDocuments(emp_code);
            if (Session["Role"].ToString() == "4")
            {
                Response.Redirect("viewempprofile.aspx?updated=true");
            }
            resetcontact();
            resetPersonalDetails();
            reset_professional_detail();
            resetjobdetails();
            //resetsalary();
            reset_reporting_detail();
            Reset_reporting_underwriter_detail();
            Reset_attachments();
            //resetinsurance();
            checkForSession = 1;
            Session["Free"] = Session["Bucket"];
            DataTable dt = (DataTable)Session["Free"];
            // dt.Clear();
            dt = null;
            Session["Free"] = dt;
            Session["counter"] = dt;

            //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
            string str = "<script> alert('Employee Detail has sucessfully Updated')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());


            Response.Redirect("empview.aspx?updated=true");
        }
        else
            General.Alert("Record Not Updated", btngeneralsubmit);


    }
    //--------------------insert the Attachment Detail-----------------------
    private void InsertDocuments(string empCode)
    {
        int doctypeid = int.MinValue;
        string docType = string.Empty;
        string uploadDoc = string.Empty;
        string desc = string.Empty;
        foreach (GridViewRow gvrow in grdTempClass.Rows)
        {
            doctypeid = Convert.ToInt32(((Label)gvrow.FindControl("lblDocTypeid1")).Text);
            docType = ((Label)gvrow.FindControl("lblDocTypeName1")).Text;
            uploadDoc = ((Label)gvrow.FindControl("lblUploadedDoc1")).Text;
            desc = ((Label)gvrow.FindControl("lblDesc1")).Text;

            EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            EmpAttachmentENT userentity = new EmpAttachmentENT();

            userentity.Empcode = empCode;
            userentity.DocType = Convert.ToInt32(doctypeid);
            userentity.Attachment = uploadDoc;
            userentity.AttachmentName = uploadDoc;
            userentity.DocDescription = desc;
            userentity.EmployeeCode = Session["EmpCode"].ToString();

            int result = empBusiness.CreateAttachments(userentity);
        }
    }

    //=========================================================================================================================================
    protected void resetcontact()
    {
        txt_pre_add1.Text = "";
        txt_pre_Add2.Text = "";
        txt_pre_city.Text = "";
        txt_pre_state.Text = "";
        txt_pre_country.Text = "";
        txt_pre_zip.Text = "";
        txt_pre_phone.Text = "";
        txt_per_add1.Text = "";
        txt_per_add2.Text = "";
        txt_per_city.Text = "";
        txt_per_state.Text = "";
        txt_per_country.Text = "";
        txt_per_zip.Text = "";
        txt_per_phone.Text = "";
        Txt_emr_name.Text = "";
        txt_emr_no.Text = "";

    }

    //===================================================================================================================================
    //protected void resetinsurance()
    //{
    //    TxtPolicyName.Text = "";
    //    TxtInsurance.Text = "";
    //    TxtCustID.Text = "";
    //    TxtValidFrm.Text = "";
    //    TxtPolicyLimit.Text = "";
    //}

    protected void CheckPermission()
    {
        if (Session["Role"].ToString() == "4")
        {
            txtfirstname.Enabled = false;
            txtlastname.Enabled = false;
            txtempcode.Enabled = false;
            txt_card_no.Enabled = false;
            drpgender.Enabled = false;
            drpcategory.Enabled = false;
            //drpjobtype.Enabled = false;
            drpdegination.Enabled = false;
           // drphbu.Enabled = false;
            drpempstatus.Enabled = false;
            drprole.Enabled = false;
            doj.Enabled = false;
            txtdoleaving.Enabled = false;
            txtsalary.Enabled = false;
            //drp_sbu.Enabled = false;
            txtdorelieving.Enabled = false;
            Ttxtunderwriter.Enabled = false;
            Txt_rep_underwriter.Enabled = false;
            Btn_app_underwriter.Visible = false;
            Btn_app_rep_underwriter.Visible = false;
            esino.Enabled = false;
            pfno.Enabled = false;
            panno.Enabled = false;
            esidesp.Enabled = false;
            pfno_dept.Enabled = false;
            ward.Enabled = false;
            txt_DOB.Enabled = false;
            ddl_bank_name.Enabled = false;
            txt_bank_ac.Enabled = false;
            ddl_bank_name_reimbursement.Enabled = false;
            txt_bank_ac_reimbursement.Enabled = false;
            txt_email.Enabled = false;
            optown.Enabled = false;
            optcompany.Enabled = false;
            lblpickuppoint.Enabled = false;
            txtmodeoftransport.Enabled = false;
            //txt_basic.Enabled = false;
            //txt_mobile.Enabled = false;
            //txt_conve.Enabled = false;
            //txt_total.Enabled = false;
            document.Visible = false;
            pick1.Visible = false;
            pick2.Visible = false;
            CalendarExtender7.Enabled = false;
            CalendarExtender8.Enabled = false;
            CalendarExtender5.Enabled = false;
            CalendarExtender6.Enabled = false;



        }
    }

    //=====================================================================================================================================
    protected void resetPersonalDetails()
    {

        txt_DOB.Text = "";
        txt_passportno.Text = "";
        txt_dl_no.Text = "";
        txt_email.Text = "";
        //txt_bank_name.Text = "";
        txt_bank_ac.Text = "";
        drpBloodGroup.SelectedValue = "Null";
        txtrelg.Text = "";
        //txtmobileno.Text = "";
        txt_f_f_name.Text = "";
        txt_m_fname.Text = "";
        ddlpersonalstatus.SelectedValue = "Unmarried";
        txt_sp_fname.Text = "";
        txt_doa.Text = "";
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
        txtAltEmailId.Text = "";
        Session.Remove("Child");
        grid_child.DataSource = "";
        grid_child.DataBind();
    }

    protected void resetjobdetails()
    {
        txt_card_no.Text = "";
        txt_login_id.Text = "";
        txtcompanyname.Text = "";
        drpgender.SelectedValue = "0";
        txtfirstname.Text = "";
        txtmiddlename.Text = "";
        txtlastname.Text = "";
        drpempstatus.SelectedValue = "0";
        drprole.SelectedValue = "0";
        drpcategory.SelectedValue = "0";
        drpdegination.SelectedValue = "0";
       // drpjobtype.SelectedValue = "0";
        //drphbu.SelectedValue = "0";
        //drp_sbu.SelectedValue = "0";
        doj.Text = "";
        txtdoleaving.Text = "";
        txtdorelieving.Text = "";
        txtsalary.Text = "";
        txtempcode.Text = "";
        lblphoto.Text = "";

    }

    protected void reset_reporting_detail()
    {
        Session.Remove("Pro_reporting");
        Grid_approval.DataSource = "";
        Grid_approval.DataBind();
    }
    protected void Reset_reporting_underwriter_detail()
    {
        Session.Remove("Pro_reporting_underwriter");
        Grid_rep_approval.DataSource = "";
        Grid_rep_approval.DataBind();
    }
    protected void Reset_attachments()
    {
        Session.Remove("Attachment");
        grdTempClass.DataSource = "";
        grdTempClass.DataBind();

    }

    //=======================================insert Professional details ==================================================================

    //=====================================================================================================================================
    protected void reset_professional_detail()
    {
        Session.Remove("acc_education");
        Session.Remove("Pro_education");
        Session.Remove("exp");

        grid_edu_education.DataSource = "";
        grid_edu_education.DataBind();

        grid_Pro_education.DataSource = "";
        grid_Pro_education.DataBind();

        grid_exp.DataSource = "";
        grid_exp.DataBind();
    }

    //=====================================================================================================================================
    protected void resetprofessionaldetails()
    {
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
    }

    //=====================================================================================================================================
    protected void resetexperiencedetails()
    {
        txtcomp1.Text = "";
        txt_com_local.Text = "";
        Txtdesg.Text = "";
        txt_from_exp.Text = "";
        txt_to_exp.Text = "";
    }

    //====================================================================================================================================


    protected void ddlpersonalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpersonalstatus.SelectedItem.ToString() == "Unmarried")
        {
            tbl1.Visible = false;
            tblCHD.Visible = false;
            tblDOB.Visible = false;
        }
        else
        {
            tbl1.Visible = true;
            tblCHD.Visible = true;
            tblDOB.Visible = true;
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            txt_per_add1.Text = txt_pre_add1.Text;
            txt_per_add2.Text = txt_pre_Add2.Text;
            txt_per_city.Text = txt_pre_city.Text;
            txt_per_state.Text = txt_pre_state.Text;
            txt_per_country.Text = txt_pre_country.Text;
            txt_per_zip.Text = txt_pre_zip.Text;
            txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            txt_per_city.Enabled = false;
            txt_per_state.Enabled = false;
            txt_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            txt_per_city.Enabled = true;
            txt_per_state.Enabled = true;
            txt_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            txt_per_city.Text = "";
            txt_per_state.Text = "";
            txt_per_country.Text = "";
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }

    protected void btn_child_Add_Click(object sender, EventArgs e)
    {
        Child_grid();
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
    }
    //------------------insert the children detail-----------------------------
    protected void Child_grid()
    {
        DataRow dr;
        if (Session["child"] == null)
        {
            create_child_table();
        }
        dtable = (DataTable)Session["child"];

        DataRow drfind = dtable.Rows.Find(txt_child_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["child_name"] = txt_child_name.Text;
            dr["child_dob"] = txt_child_Dob.Text;

            dtable.Rows.Add(dr);
        }
        Session["child"] = dtable;
        BindList_child();
    }
    protected void BindList_child()
    {
        if (Session["child"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["child"];
            dview = new DataView(dtable);
            dview.Sort = "Child_name";
        }
        grid_child.DataSource = dview;
        grid_child.DataBind();
    }
    protected void create_child_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("child_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["child_name"] };
        dtable.Columns.Add(new DataColumn("child_DOB", typeof(string)));
        Session["child"] = dtable;
    }
    //................. delete item from children detail---------------------------
    protected void grid_child_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["child"];
        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(grid_child.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {

            ////////////----------------------------------------

            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam[0].Value = "Children Detail - Child_Name";
            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dtable.Rows[e.RowIndex]["child_name"].ToString();
            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam[2].Value = string.Empty;
            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["empcode"].ToString();
            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);

            SqlParameter[] sqlparam1 = new SqlParameter[5];
            sqlparam1[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam1[0].Value = "Children Detail - Date of Birth";
            sqlparam1[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dtable.Rows[e.RowIndex]["child_dob"].ToString();
            sqlparam1[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = string.Empty;
            sqlparam1[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam1[3].Value = Session["empcode"].ToString();
            sqlparam1[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam1[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam1);

            ////////////--------------------

            drfind_child.Delete();
            Session["child"] = dtable;
            BindList_child();
        }
    }

    //---------------------end insert child detail-------------------------

    //------------------------ Insert the Reporting Detail---------------------------
    protected void Ins_app_underwriter()
    {
        DataRow dr;
        if (Session["Pro_reporting"] == null)
        {
            create_app_underwriter();
        }
        dtable = (DataTable)Session["Pro_reporting"];
        DataRow drfind = dtable.Rows.Find(Ttxtunderwriter.Text);
        if (drfind != null)
        {
        }
        else
        {
            EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
            ObjEmpJobDetailENT.Empcode = Ttxtunderwriter.Text;
            ObjEmpJobDetailENT.Degination_id = 0;
            ObjEmpJobDetailENT.Category_id = 0;
            ObjEmpJobDetailENT.Status = false;
            ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
            ObjEmpJobDetailENT.EmployeeCode = "0";
            ObjEmpJobDetailENT.Emp_fname = "";

            EmpJobDetailBusiness ObjEmpJobDetail = new EmpJobDetailBusiness();
            ds = ObjEmpJobDetail.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

            dr = dtable.NewRow();
            dr["approverid"] = Ttxtunderwriter.Text;
            dr["approvername"] = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            dr["category"] = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            dr["BU"] = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            dr["designation"] = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
            dr["approverpriority"] = "1";
            dtable.Rows.Add(dr);
        }
        Session["Pro_reporting"] = dtable;
        BindList_app_underwriter();
    }
    protected void BindList_app_underwriter()
    {
        if (Session["Pro_reporting"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_reporting"];
            dview = new DataView(dtable);
            dview.Sort = "approverid";
        }
        Grid_approval.DataSource = dview;
        Grid_approval.DataBind();
    }
    protected void create_app_underwriter()
    {
        dtable = new DataTable();
        dtable.Columns.Add("approverid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["approverid"] };
        dtable.Columns.Add(new DataColumn("approvername", typeof(string)));
        dtable.Columns.Add(new DataColumn("category", typeof(string)));
        dtable.Columns.Add(new DataColumn("BU", typeof(string)));
        dtable.Columns.Add(new DataColumn("designation", typeof(string)));
        dtable.Columns.Add(new DataColumn("approverpriority", typeof(string)));

        Session["Pro_reporting"] = dtable;
    }
    protected void Grid_approval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_reporting"];
        DataRow drfind_app_underwriter = dtable.Rows.Find(Convert.ToString(Grid_approval.DataKeys[e.RowIndex].Value));
        if (drfind_app_underwriter != null)
        {
            drfind_app_underwriter.Delete();
            Session["Pro_reporting"] = dtable;

            //EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            //string emp_code = Request.QueryString["empcode"].ToString();
            //EmpReportingENT userentity = new EmpReportingENT();
            //userentity.EmpCode = emp_code;
            //userentity.Approverid = Grid_approval.DataKeys[e.RowIndex].Value.ToString();
            //userentity.Approverpriority = 100;
            //userentity.EmployeeCode = Session["EmpCode"].ToString();

            //int result = empBusiness.CreateReporting(userentity);

            BindList_app_underwriter();
        }
    }
    protected void Btn_app_underwriter_Click(object sender, EventArgs e)
    {

        if (Ttxtunderwriter.Text == "")
        {
            General.Alert("Please Pick Employee First", Btn_app_underwriter);
        }
        else
        {
            if (Grid_approval.Rows.Count > 0)
            {
                General.Alert("Only one reporting manager 1 can be added", Btn_app_underwriter);
                return;
            }
            else
            {
                Ins_app_underwriter();
                Ttxtunderwriter.Text = "";
            }
        }

    }
    //------------------------------ End of Reporting Detail ---------------------

    //------------------------ Insert the Reporting Underwriter Detail---------------------------
    protected void Ins_app_rep_underwriter()
    {
        DataRow dr;
        if (Session["Pro_reporting_underwriter"] == null)
        {
            create_app_rep_underwriter();
        }
        dtable = (DataTable)Session["Pro_reporting_underwriter"];
        DataRow drfind = dtable.Rows.Find(Txt_rep_underwriter.Text);
        if (drfind != null)
        {
        }
        else
        {
            EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
            ObjEmpJobDetailENT.Empcode = Txt_rep_underwriter.Text;
            ObjEmpJobDetailENT.Degination_id = 0;
            ObjEmpJobDetailENT.Category_id = 0;
            ObjEmpJobDetailENT.Status = false;
            ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
            ObjEmpJobDetailENT.EmployeeCode = "0";
            ObjEmpJobDetailENT.Emp_fname = "";

            EmpJobDetailBusiness ObjEmpJobDetail = new EmpJobDetailBusiness();
            ds = ObjEmpJobDetail.SelectEmployeeJobDetail(ObjEmpJobDetailENT);
            dr = dtable.NewRow();
            dr["approverid"] = Txt_rep_underwriter.Text;
            dr["approvername"] = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            dr["category"] = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            dr["BU"] = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            dr["designation"] = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
            dr["approverpriority"] = "2";
            dtable.Rows.Add(dr);
        }
        Session["Pro_reporting_underwriter"] = dtable;
        BindList_app_rep_underwriter();
    }
    protected void BindList_app_rep_underwriter()
    {
        if (Session["Pro_reporting_underwriter"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_reporting_underwriter"];
            dview = new DataView(dtable);
            dview.Sort = "approverid";
        }
        Grid_rep_approval.DataSource = dview;
        Grid_rep_approval.DataBind();
    }
    protected void create_app_rep_underwriter()
    {
        dtable = new DataTable();
        dtable.Columns.Add("approverid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["approverid"] };
        dtable.Columns.Add(new DataColumn("approvername", typeof(string)));
        dtable.Columns.Add(new DataColumn("category", typeof(string)));
        dtable.Columns.Add(new DataColumn("BU", typeof(string)));
        dtable.Columns.Add(new DataColumn("designation", typeof(string)));
        dtable.Columns.Add(new DataColumn("approverpriority", typeof(string)));

        //Session["app_rep_underwriter"] = dtable;
        Session["Pro_reporting_underwriter"] = dtable; // Added on 24-Dec-13 by ANUJ

    }
    protected void Grid_rep_approval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_reporting_underwriter"];
        DataRow drfind_app_rep_underwriter = dtable.Rows.Find(Convert.ToString(Grid_rep_approval.DataKeys[e.RowIndex].Value));
        if (drfind_app_rep_underwriter != null)
        {
            drfind_app_rep_underwriter.Delete();
            Session["Pro_reporting_underwriter"] = dtable;

            //string emp_code = Request.QueryString["empcode"].ToString();
            //EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            //EmpReportingENT userentity = new EmpReportingENT();
            //userentity.EmpCode = emp_code;
            //userentity.Approverid = Grid_rep_approval.DataKeys[e.RowIndex].Value.ToString();
            //userentity.Approverpriority = 100;
            //userentity.EmployeeCode = Session["EmpCode"].ToString();

            // int result = empBusiness.CreateReporting(userentity);

            BindList_app_rep_underwriter();
        }
    }
    protected void Btn_app_rep_underwriter_Click(object sender, EventArgs e)
    {
        if (Txt_rep_underwriter.Text == "")
        {
            General.Alert("Please Pick Employee First", Btn_app_rep_underwriter);
        }
        else
        {
            if (Grid_rep_approval.Rows.Count > 0)
            {
                General.Alert("Only one reporting manager 2 can be added", Btn_app_underwriter);
                return;
            }
            else
            {
                Ins_app_rep_underwriter();
                Txt_rep_underwriter.Text = "";
            }
        }
    }
    //------------------------------ End of Reporting Underwriter Detail ---------------------

    protected void btn_pro_qual_add_Click(object sender, EventArgs e)
    {
        Ins_Pro_edu();
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
        ddlMonthfrom.SelectedValue = "Jan";
        ddlMonthto.SelectedValue = "Jan";
    }
    //------------------------ Insert the Professional Qualification Data---------------------------
    protected void Ins_Pro_edu()
    {
        DataRow dr;
        if (Session["Pro_education"] == null)
        {
            create_Pro_edu_table();
        }
        dtable = (DataTable)Session["Pro_education"];

        DataRow drfind = dtable.Rows.Find(txteduc1.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["id"] = Guid.NewGuid();
            dr["education"] = txteduc1.Text;
            dr["school"] = txtsch1.Text;
            dr["percentage"] = txtper1.Text;
            dr["month_from"] = ddlMonthfrom.SelectedItem.ToString();
            dr["from_year"] = txtfrm1.Text;
            dr["month_to"] = ddlMonthto.SelectedItem.ToString();
            dr["to_year"] = txtto1.Text;

            dtable.Rows.Add(dr);
        }
        Session["Pro_education"] = dtable;
        ViewState["Prosessional"] = dtable;
        BindList_pro_edu();
    }
    protected void BindList_pro_edu()
    {
        if (Session["Pro_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_Pro_education.DataSource = dview;
        grid_Pro_education.DataBind();
    }

    protected void BindList_pro_edu_update()
    {
        if (Session["Pro_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)ViewState["Prosessional"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_Pro_education.DataSource = dview;
        grid_Pro_education.DataBind();
    }
    protected void create_Pro_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("id", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["id"] };
        dtable.Columns.Add(new DataColumn("education", typeof(string)));
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("month_from", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("month_to", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));

        Session["Pro_education"] = dtable;
    }



    //------------------------------ End of Insertion of professiona qualification ---------------------

    protected void btn_exp_add_Click(object sender, EventArgs e)
    {
        Ins_exp();
        txtcomp1.Text = "";
        txt_com_local.Text = "";
        Txtdesg.Text = "";
        txt_from_exp.Text = "";
        txt_to_exp.Text = "";

    }
    //--------------- Insert the  exprience detail------------------------------
    protected void Ins_exp()
    {
        DataRow dr;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        dtable = (DataTable)Session["exp"];
        int year = 0, month = 0, day = 0;
        DataRow drfind = dtable.Rows.Find(txtcomp1.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["id"] = Guid.NewGuid();
            dr["comp_name"] = txtcomp1.Text;
            dr["location"] = txt_com_local.Text;
            dr["Designation"] = Txtdesg.Text;
            dr["datefrom"] = txt_from_exp.Text;
            dr["dateto"] = txt_to_exp.Text;
            dr["date_to_sort"] = Convert.ToDateTime(txt_from_exp.Text);
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 100);
            sqlparm[0].Value = Utility.DateTimeForat(txt_from_exp.Text);
            sqlparm[1] = new SqlParameter("@Todate", SqlDbType.DateTime, 100);
            if (txt_to_exp.Text == "Till Now")
            {
                sqlparm[1].Value = System.DateTime.Now.ToString();
            }
            else
            {
                sqlparm[1].Value = Utility.DateTimeForat(txt_to_exp.Text);
            }
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifference", sqlparm);
            dr["duration"] = ds.Tables[0].Rows[0]["result"].ToString();
            dtable.Rows.Add(dr);

            ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifferenceNumeric", sqlparm);

            if (!string.IsNullOrEmpty(Txttotal.Text))
            {
                string[] split_workexp = Txttotal.Text.Split(' ');
                if (split_workexp.Length == 6)
                {
                    try
                    {
                        year = Convert.ToInt32(split_workexp[0]);
                        month = Convert.ToInt32(split_workexp[2]);
                        day = Convert.ToInt32(split_workexp[4]);
                    }
                    catch (FormatException ex)
                    {
                        //   Txttotal.Text = Convert.ToString(year1).ToString() + ' ' + "years" + ' ' + Convert.ToString(month1).ToString() + ' ' + "months" + ' ' + Convert.ToString(day1).ToString() + ' ' + "days";
                    }
                }

            }
            year = year + Convert.ToInt32(ds2.Tables[0].Rows[0]["years"].ToString());
            month = month + Convert.ToInt32(ds2.Tables[0].Rows[0]["months"].ToString());
            day = day + Convert.ToInt32(ds2.Tables[0].Rows[0]["days"].ToString());
            if (day > 30)
            {
                if (day % 30 != 0)
                {
                    month += day / 30;
                    day = day % 30;
                    // month1 = 1;

                }
                else
                {

                }
            }
            else
            {

            }
            if (month >= 12)
            {
                if (month % 12 != 0)
                {
                    year += month / 12;
                    month = Convert.ToInt32(month % 12);
                    //year1 = 1;

                }
                else
                {
                    // month1 = month1 + month;

                }
            }
            else
            {

            }


        }
        Txttotal.Text = Convert.ToString(year).ToString() + ' ' + "years" + ' ' + Convert.ToString(month).ToString() + ' ' + "months" + ' ' + Convert.ToString(day).ToString() + ' ' + "days";
        Session["exp"] = dtable;
        ViewState["exp"] = dtable;
        BindList_exp();
    }
    protected void BindList_exp()
    {
        if (Session["exp"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["exp"];
            dview = new DataView(dtable);
            dview.Sort = "date_to_sort desc";
        }
        grid_exp.DataSource = dview;
        grid_exp.DataBind();
    }
    protected void BindList_exp_update()
    {
        if (Session["exp"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Experience1"];
            dview = new DataView(dtable);
            dview.Sort = "datefrom";
        }
        grid_exp.DataSource = dview;
        grid_exp.DataBind();

    }
    protected void create_exp_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("id", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["id"] };
        dtable.Columns.Add(new DataColumn("comp_name", typeof(string)));
        dtable.Columns.Add(new DataColumn("location", typeof(string)));
        dtable.Columns.Add(new DataColumn("Designation", typeof(string)));
        dtable.Columns.Add(new DataColumn("datefrom", typeof(string)));
        dtable.Columns.Add(new DataColumn("dateto", typeof(string)));
        dtable.Columns.Add(new DataColumn("duration", typeof(string)));
        dtable.Columns.Add(new DataColumn("date_to_sort", typeof(DateTime)));
        Session["exp"] = dtable;
    }

    //--------------------------------- End Insetion of Experience Detail--------------------------
    //------------------------ Insert the Educational Qualification Data---------------------------
    protected void Ins_acc_edu()
    {
        DataRow dr;
        if (Session["acc_education"] == null)
        {
            create_acc_edu_table();
        }
        dtable = (DataTable)Session["acc_education"];

        DataRow drfind = dtable.Rows.Find(drp_edu_qualification.SelectedItem.ToString());
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["id"] = Guid.NewGuid();
            dr["education"] = drp_edu_qualification.SelectedItem.ToString();
            dr["school"] = txtedush.Text;
            dr["percentage"] = txteduper.Text;
            dr["from_year"] = txtedufrom.Text;
            dr["to_year"] = txteduto.Text;
            dtable.Rows.Add(dr);
        }
        Session["acc_education"] = dtable;
        ViewState["Education"] = dtable;
        BindList_acc_edu();
    }
    protected void BindList_acc_edu()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }

    protected void BindList_acc_edu_Update()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)ViewState["Education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }
    protected void create_acc_edu_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("id", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["id"] };
        dtable.Columns.Add(new DataColumn("education", typeof(string)));
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));

        Session["acc_education"] = dtable;
    }

    protected void btn_quali_add_Click(object sender, EventArgs e)
    {
        Ins_acc_edu();
        drp_edu_qualification.SelectedValue = "0";
        txtedush.Text = "";
        txteduper.Text = "";
        txtedufrom.Text = "";
        txteduto.Text = "";
    }
    //------------------------------ End of Insertion of Educational qualification ---------------------

    //------------------------------ set the by default values in the drop down list-----------
    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(drpempstatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
        BindDropDowns(drprole, binddrop.BindDropDowns("", "Role"), "id", "role");
        BindDropDowns(drp_edu_qualification, binddrop.BindDropDowns("", "Education"), "ID", "EducationName");
        BindDropDowns(ddl_bank_name, binddrop.BindDropDowns("", "Bank"), "ID", "BankName");
        BindDropDowns(ddl_bank_name_reimbursement, binddrop.BindDropDowns("", "Bank"), "ID", "BankName");
        BindDropDowns(ddlDocumentType, binddrop.BindDropDowns("", "Document"), "ID", "DocumentName");
        BindDropDowns(drpcategory, binddrop.BindDropDowns(ViewState["Companyid"].ToString(), "Category"), "ID", "CategoryName");
        //BindDropDowns(drpjobtype, binddrop.BindDropDowns(ViewState["Companyid"].ToString(), "JobType"), "ID", "DesgCode");
        BindDropDowns(drpdegination, binddrop.BindDropDowns(ViewState["Companyid"].ToString(), "Designation"), "id", "designationname");
       // BindDropDowns(drphbu, binddrop.BindDropDowns(ViewState["Companyid"].ToString(), "BusinessUnit"), "ID", "BussinessUnitName");
        //BindDropDowns(drp_sbu, binddrop.BindDropDowns(ViewState["Companyid"].ToString(), "BusinessUnit"), "ID", "BussinessUnitName");

    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //------------------------------- Insert the Educational qualification --------------------
    protected void Edit_Educational_Qualification(string emp_code)
    {
        if (Session["acc_education"] != null)
        {

            dtable = (DataTable)ViewState["Education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpEducationENT userentity = new EmpEducationENT();
                userentity.Empcode = emp_code;
                userentity.Education = dtable.Rows[i]["education"].ToString();
                userentity.School = dtable.Rows[i]["school"].ToString();
                userentity.Percentage = dtable.Rows[i]["percentage"].ToString();
                userentity.Yearfrom = dtable.Rows[i]["from_year"].ToString();
                userentity.Yearto = dtable.Rows[i]["to_year"].ToString();
                userentity.EmployeeCode = Session["EmpCode"].ToString();
                int result = empBusiness.CreateEduQualification(userentity);
            }
        }
    }
    //------------------------------- End-----------------------------------------
    //------------------------------ insert Professional Qualification in the data base---------------------
    protected void edit_Professional_Qualification(string emp_code)
    {
        if (Session["Pro_education"] != null)
        {
            //sqlstr = "delete from tbl_employee_professionalqualifications where empcode ='" + emp_code + "'";
            //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            dtable = (DataTable)ViewState["Prosessional"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpProfQualificationENT userentity = new EmpProfQualificationENT();
                userentity.Empcode = emp_code;
                userentity.Education = dtable.Rows[i]["education"].ToString();
                userentity.School = dtable.Rows[i]["school"].ToString();
                userentity.Percentage = dtable.Rows[i]["percentage"].ToString();
                userentity.MonthFrom = dtable.Rows[i]["month_from"].ToString();
                userentity.Yearfrom = dtable.Rows[i]["from_year"].ToString();
                userentity.MonthTo = dtable.Rows[i]["month_to"].ToString();
                userentity.Yearto = dtable.Rows[i]["to_year"].ToString();
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateProQualification(userentity);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //------------------------------ insert Exprience Detail in the data base---------------------
    protected void edit_Expriece_detail(string emp_code)
    {
        if (Session["exp"] != null)
        {
            //sqlstr = "delete from tbl_employee_experiencedetails where empcode ='"+ emp_code +"'";
            //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            dtable = (DataTable)Session["exp"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpExperianceENT userentity = new EmpExperianceENT();
                userentity.Empcode = emp_code;
                userentity.Companyname = dtable.Rows[i]["comp_name"].ToString();
                userentity.Location = dtable.Rows[i]["location"].ToString();
                userentity.Totalexperience = dtable.Rows[i]["Designation"].ToString();
                userentity.Yearfrom = dtable.Rows[i]["datefrom"].ToString();
                userentity.Yearto = dtable.Rows[i]["dateto"].ToString();
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateExperienceDetail(userentity);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //------------------------------ insert children Detail in the data base---------------------
    protected void edit_Children_detail(string emp_code)
    {

        //sqlstr = "delete from tbl_intranet_employee_childrendetail where empcode ='" + emp_code + "'";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (Session["child"] != null)
        {
            dtable = (DataTable)Session["child"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DateTime dob;
                if (dtable.Rows[i]["child_dob"].ToString() != "")
                {
                    dob = Utility.DateTimeForat(dtable.Rows[i]["child_dob"].ToString());
                }
                else
                    dob = Convert.ToDateTime("01/01/1900");
                //System.Data.SqlTypes.SqlDateTime.Null;

                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpChildrenENT userentity = new EmpChildrenENT();

                userentity.Empcode = emp_code;
                userentity.Child_name = dtable.Rows[i]["child_name"].ToString();
                userentity.Dob = dob;
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateChildrenDetail(userentity);
            }
        }
    }
    //--------------------------------------- end ----------------------------

    //------------------------------ insert Reporting Deatil in the data base---------------------

    protected void Edit_Reporting_detail(string emp_code)
    {
        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        if (Session["Pro_reporting"] != null)
        {
            dtable = (DataTable)Session["Pro_reporting"];
            EmpReportingENT userentity = new EmpReportingENT();
            userentity.EmpCode = emp_code;
            if (dtable.Rows.Count > 0)
            {
                for (int i = 0; i < dtable.Rows.Count; i++)
                {


                    userentity.Approverid = dtable.Rows[i]["approverid"].ToString();
                    userentity.Approverpriority = Convert.ToInt32(dtable.Rows[i]["approverpriority"].ToString());
                    userentity.EmployeeCode = Session["EmpCode"].ToString();

                    int result = empBusiness.CreateReporting(userentity);
                }
            }
            else
            {
                userentity.Approverpriority = 1;
                string result = empBusiness.deleteRMForEmp(userentity);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //------------------------------ insert Reporting Deatil in the data base---------------------

    protected void Edit_Reporting_underwriter_detail(string emp_code)
    {
        if (Session["Pro_reporting_underwriter"] != null)
        {
            dtable = (DataTable)Session["Pro_reporting_underwriter"];
            EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            EmpReportingENT userentity = new EmpReportingENT();
            userentity.EmpCode = emp_code;

            userentity.EmployeeCode = Session["EmpCode"].ToString();
            if (dtable.Rows.Count > 0)
            {
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    userentity.Approverid = dtable.Rows[i]["approverid"].ToString();
                    userentity.Approverpriority = Convert.ToInt32(dtable.Rows[i]["approverpriority"].ToString());
                    int result = empBusiness.CreateReporting(userentity);
                }
            }
            else
            {
                userentity.Approverpriority = 2;
                string result = empBusiness.deleteRMForEmp(userentity);
            }
        }
    }


    //  -------------------------- Insert Insurance Detail by garima ----------------------------------
    //protected void edit_insurance_detail(string empcode)
    //{
    //    EmployeeEditBussiness empBusiness = new EmployeeEditBussiness();
    //    EmpInsuranceENT userentity = new EmpInsuranceENT();
    //    userentity.Empcode = empcode;
    //    userentity.PolicyName = TxtPolicyName.Text;
    //    userentity.InsCmpyName = TxtInsurance.Text;
    //    userentity.CustomerID = TxtCustID.Text;
    //    if (TxtValidFrm.Text != "")
    //    {
    //        userentity.ValidFrom = Utilities.Utility.DateTimeForat(TxtValidFrm.Text.ToString());
    //    }
    //    userentity.PolicyLimit = TxtPolicyLimit.Text;
    //    userentity.EmployeeCode = Session["EmpCode"].ToString();
    //    int result = empBusiness.EditInsuranceDetail(userentity);


    //}

    //--------------------------------------- Insert the Personal Details ----------------------------------
    protected void edit_personal_detail(string empcode)
    {
        //edit_personal_detail_Audit();
        int paymentmode = 0;
        if (rbtnbank.Checked)
            paymentmode = 0;

        if (rbtncheque.Checked)
            paymentmode = 1;

        if (rbtncash.Checked)
            paymentmode = 2;

        EmployeeEditBussiness empBusiness = new EmployeeEditBussiness();
        EmpPersonalENT userentity = new EmpPersonalENT();
        userentity.Empcode = empcode;
        userentity.F_fname = txt_f_f_name.Text;
        userentity.M_fname = txt_m_fname.Text;
        userentity.Aadharnumber = txtaadharnumber.Text;
        userentity.Bloodgrp = drpBloodGroup.SelectedValue;
        userentity.Maritalstatus = ddlpersonalstatus.SelectedItem.ToString();
        userentity.Religion = txtrelg.Text;
        if (txt_doa.Text != "")
        {
            userentity.Doa = Utilities.Utility.DateTimeForat(txt_doa.Text.ToString());
        }
        userentity.Dlno = txt_dl_no.Text;
        userentity.S_fname = txt_sp_fname.Text;
        userentity.S_gender = "Male";
        userentity.No_child = 3;
        //userentity.Mobile_no = txtmobileno.Text;
        userentity.Email_id = txt_email.Text;
        userentity.AltEmail_Id = txtAltEmailId.Text;
        userentity.Bank_name = ddl_bank_name.SelectedValue;
        userentity.Ac_number = txt_bank_ac.Text.Trim();
        userentity.Bank_name_reimbursement = ddl_bank_name_reimbursement.SelectedValue;
        userentity.Ac_number_reimbursement = txt_bank_ac_reimbursement.Text.Trim();
        userentity.Passport_number = txt_passportno.Text;
        if (txt_DOB.Text != "")
        {
            userentity.Dob = Utilities.Utility.DateTimeForat(txt_DOB.Text.ToString());
        }
        userentity.Paymentmode = paymentmode;
        userentity.EmployeeCode = Session["EmpCode"].ToString();
        if (TxtSpouseDOb.Text != "")
        {
            userentity.S_dob = Utilities.Utility.DateTimeForat(TxtSpouseDOb.Text.ToString());
        }
        if (TxtPassportexpdate.Text != "")
        {
            userentity.PassportValidDate = Utilities.Utility.DateTimeForat(TxtPassportexpdate.Text.ToString());
        }
        int result = empBusiness.EditPersonalDetails(userentity);

    }

    //private void edit_personal_detail_Audit()
    //{
    //    DataSet ds = (DataSet)Session["PersonalDetail"];
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (txt_f_f_name.Text != ds.Tables[0].Rows[0]["f_fname"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Father First Name";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["f_fname"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_f_f_name.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }


    //        if (txt_m_fname.Text != ds.Tables[0].Rows[0]["m_fname"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Mother First Name";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["m_fname"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_m_fname.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }


    //        //if (txtbloodgrp.Text != ds.Tables[0].Rows[0]["bloodgrp"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Blood Group";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txtbloodgrp.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        if (txtrelg.Text != ds.Tables[0].Rows[0]["religion"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Religion";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["religion"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txtrelg.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (ddlpersonalstatus.SelectedValue != ds.Tables[0].Rows[0]["maritalstatus"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Marital Status";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["maritalstatus"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = ddlpersonalstatus.SelectedValue;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        //if (txt_doa.Text != ds.Tables[0].Rows[0]["doa"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Date of Anniversary";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["doa"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txt_doa.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}


    //        if (txt_sp_fname.Text != ds.Tables[0].Rows[0]["s_fname"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Spouse First Name";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["s_fname"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_sp_fname.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }



    //        //if (txt_DOB.Text != ds.Tables[0].Rows[0]["dob"].ToString())
    //        //{
    //        //    SqlParameter[] sqlparam = new SqlParameter[5];
    //        //    sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //        //    sqlparam[0].Value = "Date of Birth";
    //        //    sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //        //    sqlparam[1].Value = ds.Tables[0].Rows[0]["dob"].ToString();
    //        //    sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //        //    sqlparam[2].Value = txt_DOB.Text;
    //        //    sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //        //    sqlparam[3].Value = Session["empcode"].ToString();
    //        //    sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //        //    sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //        //    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        //}
    //        if (txtmobileno.Text != ds.Tables[0].Rows[0]["mobile_no"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Mobile No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["mobile_no"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txtmobileno.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_email.Text != ds.Tables[0].Rows[0]["email_id"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Email Id";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["email_id"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_email.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_passportno.Text != ds.Tables[0].Rows[0]["passport_number"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Passport No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["passport_number"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_passportno.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //    }
    //}

    //----------------------------- insert the contact detail------------------------------

    protected void edit_contact_detail(string empcode)
    {
        //edit_contact_detail_Audit();

        int modeh = int.MinValue;
        if (optcompany.Checked)
        {
            modeh = 1;
        }

        if (optown.Checked)
        {
            modeh = 0;
        }
        EmployeeEditBussiness empBusiness = new EmployeeEditBussiness();
        EmpContactENT userentity = new EmpContactENT();
        userentity.Empcode = empcode;
        userentity.Pre_add1 = txt_pre_add1.Text;
        userentity.Pre_Add2 = txt_pre_Add2.Text;
        userentity.Pre_city = txt_pre_city.Text;
        userentity.Pre_state = txt_pre_state.Text;
        userentity.Pre_country = txt_pre_country.Text;
        userentity.Pre_zip = txt_pre_zip.Text;
        userentity.Pre_phone = txt_pre_phone.Text;
        userentity.Per_add1 = txt_per_add1.Text;
        userentity.Per_add2 = txt_per_add2.Text;
        userentity.Per_city = txt_per_city.Text;
        userentity.Per_state = txt_per_state.Text;
        userentity.Per_country = txt_per_country.Text;
        userentity.Per_zip = txt_per_zip.Text;
        userentity.Per_phone = txt_per_phone.Text;
        userentity.Mode = modeh;
        userentity.EmergencyContactName = Txt_emr_name.Text;
        userentity.EmergencyContactNo = txt_emr_no.Text;
        userentity.EmployeeCode = Session["EmpCode"].ToString();
        int result = empBusiness.EDitContactDetails(userentity);


    }

    //private void edit_contact_detail_Audit()
    //{
    //    DataSet ds = (DataSet)Session["ContactDetail"];
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (txt_pre_add1.Text != ds.Tables[0].Rows[0]["pre_add1"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Address1";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_add1"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_add1.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_Add2.Text != ds.Tables[0].Rows[0]["pre_Add2"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Address2";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_Add2.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_city.Text != ds.Tables[0].Rows[0]["pre_city"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "City";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_city"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_city.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_state.Text != ds.Tables[0].Rows[0]["pre_state"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "State";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_state"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_state.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_country.Text != ds.Tables[0].Rows[0]["pre_country"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Country";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_country"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_country.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_zip.Text != ds.Tables[0].Rows[0]["pre_zip"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Zip Code";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_zip"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_zip.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_pre_phone.Text != ds.Tables[0].Rows[0]["pre_phone"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Phone No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["pre_phone"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_pre_phone.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_add1.Text != ds.Tables[0].Rows[0]["per_add1"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent Address1";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_add1"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_add1.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_add2.Text != ds.Tables[0].Rows[0]["per_add2"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent Address2";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_add2"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_add2.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_city.Text != ds.Tables[0].Rows[0]["per_city"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent City";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_city"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_city.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_state.Text != ds.Tables[0].Rows[0]["per_state"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent State";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_state"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_state.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_country.Text != ds.Tables[0].Rows[0]["per_country"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent Country";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_country"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_country.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_zip.Text != ds.Tables[0].Rows[0]["per_zip"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent Zip";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_zip"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_zip.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //        if (txt_per_phone.Text != ds.Tables[0].Rows[0]["per_phone"].ToString())
    //        {
    //            SqlParameter[] sqlparam = new SqlParameter[5];
    //            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
    //            sqlparam[0].Value = "Permanent Phone No";
    //            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = ds.Tables[0].Rows[0]["per_phone"].ToString();
    //            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
    //            sqlparam[2].Value = txt_per_phone.Text;
    //            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
    //            sqlparam[3].Value = Session["empcode"].ToString();
    //            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
    //            sqlparam[4].Value = ds.Tables[0].Rows[0]["empcode"].ToString();
    //            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);
    //        }
    //    }
    //}
    //---------------------------------End-----------------------------------------------


    protected void optown_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = false;
        lblpickuppoint.Visible = false;
    }
    protected void optcompany_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = true;
        lblpickuppoint.Visible = true;
    }

    protected void rbtnbank_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = true;
    }

    protected void rbtncheque_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }

    protected void rbtncash_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }


    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void BindList_attachment()
    {
        if (Session["attachment"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["attachment"];
            dview = new DataView(dtable);
            dview.Sort = "Attachment";
        }
        //GridView5.DataSource=dview;
        //GridView5.DataBind();
    }

    protected void grid_attachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //dtable = (DataTable)Session["attachment"];
        //DataRow attachment1 = dtable.Rows.Find(Convert.ToString(GridView5.DataKeys[e.RowIndex].Value));
        //if (attachment1 != null)
        //{
        //    attachment1.Delete();
        //    Session["attachment"] = dtable;
        //    BindList_attachment();
        //}
    }


    protected void btnAddDoc_Click(object sender, EventArgs e)
    {
        string filePath = string.Empty;
        if (ddlDocumentType.SelectedIndex > 0 && txtDesc.Text.Length > 0 && flUpload.HasFile)
        {
            if (Session["counter"] == null)
                createBucket();
            Bind1();
        }
        txtDesc.Text = string.Empty;
        ddlDocumentType.SelectedIndex = 0;
        if (flUpload.HasFile)
        {
            try
            {
                if (flUpload.PostedFile.ContentLength < 2097152)
                {
                    filePath = flUpload.FileName;
                    string Files = Server.MapPath("~") + "\\UploadDocs\\";
                    filePath = Files + txt_card_no.Text.Trim() + "-" + filePath;
                    flUpload.SaveAs(filePath);
                }
                else
                {
                    lblMsg.Text = "File size of " + Convert.ToString(flUpload.PostedFile.ContentLength / 1024 / 1024) + " MB is exceeding the uploading limit.";
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some problem occurred while uploading the file. Please try after some time.";
            }

        }
    }
    public void createBucket()
    {
        Bucket.Columns.Add("pid", typeof(int));
        Bucket.PrimaryKey = new DataColumn[] { Bucket.Columns["pid"] };
        Bucket.Columns.Add(new DataColumn("DocType", typeof(int)));
        Bucket.Columns.Add(new DataColumn("DocTypeName", typeof(string)));
        Bucket.Columns.Add(new DataColumn("UploadedDoc", typeof(string)));
        Bucket.Columns.Add(new DataColumn("Desc", typeof(string)));

        Session["pid"] = 1;
        if (checkForSession == 0)
        {
            Session["Bucket"] = Bucket;
        }
        else
        {
            Session["Free"] = Bucket;
        }
        //Session["Bucket"] = Bucket;
    }
    public void Bind1()
    {
        string docName = string.Empty;
        try
        {

            if (checkForSession == 0)
            {
                Bucket = (DataTable)Session["Bucket"];
            }
            else
            {
                Bucket = (DataTable)Session["Free"];
            }

            counter++;
            //Bucket = (DataTable)Session["Bucket"];
            dr = Bucket.NewRow();
            dr["pid"] = counter;
            dr["DocType"] = Convert.ToInt32(ddlDocumentType.SelectedValue.ToString());

            if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 2)
                dr["DocTypeName"] = "Covering Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 3)
                dr["DocTypeName"] = "Bussiness Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 4)
                dr["DocTypeName"] = "Offer Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 5)
                dr["DocTypeName"] = "Experience Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 6)
                dr["DocTypeName"] = "Appointment Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 7)
                dr["DocTypeName"] = "Increment Letter";
            else if (Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()) == 8)
                dr["DocTypeName"] = "Relieving Letter";
            else
                dr["DocTypeName"] = "Insurance Policy";

            dr["UploadedDoc"] = flUpload.FileName;
            dr["Desc"] = txtDesc.Text.Trim();
            Bucket.Rows.Add(dr);
            Session["counter"] = Bucket.Rows.Count;
            if (checkForSession == 0)
            {
                Session["Bucket"] = Bucket;
            }
            else
            {
                Session["Free"] = Bucket;
            }
            //Session["Bucket"] = Bucket;
            int i = Convert.ToInt32(Session["counter"].ToString());
            i = i + 1;
            Session["BucketCount"] = i.ToString();
            Session["pid"] = Convert.ToInt32(Session["pid"]) + 1;
            if (checkForSession == 0)
            {
                grdTempClass.DataSource = (DataTable)Session["Bucket"];
            }
            else
            {
                grdTempClass.DataSource = (DataTable)Session["Free"];
            }
            //grdTempClass.DataSource = (DataTable)Session["Bucket"];
            grdTempClass.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void bindTemp()
    {
        if (checkForSession == 0)
        {
            grdTempClass.DataSource = (DataTable)Session["Bucket"];
        }
        else
        {
            grdTempClass.DataSource = (DataTable)Session["Free"];
        }
        grdTempClass.DataBind();
    }
    protected void grdTempClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int i = Convert.ToInt32(Session["BucketCount"].ToString());
            if (i > 0)
            {
                i = i - 1;
                Session["BucketCount"] = i.ToString();
            }
            Bucket = (DataTable)Session["Bucket"];
            DataRow drfind = Bucket.Rows.Find(Convert.ToString(grdTempClass.DataKeys[e.RowIndex].Value));
            if (drfind != null)
            {
                drfind.Delete();
                Session["Bucket"] = Bucket;
                grdTempClass.EditIndex = -1;
                bindTemp();
            }
        }
        catch (Exception Ex)
        {
        }
    }
    protected void grdDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataKey id = grdDocument.DataKeys[e.RowIndex];
            SqlParameter[] sqlParam = new SqlParameter[1];
            sqlParam[0] = new SqlParameter("@IN_Id", SqlDbType.Int, 5);
            sqlParam[0].Value = Convert.ToInt32(id.Value);
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[procDeleteAttachmentDocuments]", sqlParam);
            BindAttachment(ViewState["EmpCode1"].ToString());
        }
        catch (Exception Ex)
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Main.aspx");
    }

    //---------EOC-----------------
    protected void photo_Click(object sender, EventArgs e)
    {
        lblphoto.Text = FileUpload1.PostedFile.FileName;
        lblphoto.Visible = true;
        //if ((System.IO.Path.GetExtension(lblphoto.Text) == ".jpg") || (System.IO.Path.GetExtension(lblphoto.Text) == ".jpeg")
        //       || (System.IO.Path.GetExtension(lblphoto.Text) == ".gip") || (System.IO.Path.GetExtension(lblphoto.Text) == ".png"))
        //{
        //    string FilePath = lblphoto.Text;
        //    string files = Server.MapPath("~") + "\\UploadPhoto\\";
        //    FilePath = files + txt_card_no.Text.Trim() + "-" + FilePath;
        //    FileUpload1.SaveAs(FilePath);
        //    //ViewState["Photo"] = FileUpload1.FileName;
        //}

    }

    ///--------------------Edit education Grid-------------

    protected void grid_edu_education_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_edu_education.PageIndex = e.NewPageIndex;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Education_Qualification(emp_code);
    }

    protected void grid_edu_education_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_edu_education.EditIndex = -1;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Education_Qualification(emp_code);
    }
    protected void grid_edu_education_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String key = grid_edu_education.DataKeys[e.Row.RowIndex].Value.ToString();
            try
            {
                Convert.ToInt32(key);
            }
            catch (Exception err)
            {
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkbtnedit");
                if (btn != null)
                {
                    btn.Visible = false;
                }
            }
        }


    }
    protected void grid_edu_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        GridViewRow gvRows = (GridViewRow)grid_edu_education.Rows[e.RowIndex];




        DataRow drfind_acc_edu = dtable.Rows.Find(Convert.ToString(grid_edu_education.DataKeys[e.RowIndex].Value));

        if (drfind_acc_edu != null)
        {

            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam[0].Value = "Education Qualification - Class";
            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dtable.Rows[e.RowIndex]["education"].ToString();
            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam[2].Value = string.Empty;
            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["empcode"].ToString();
            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);


            SqlParameter[] sqlparam1 = new SqlParameter[5];
            sqlparam1[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam1[0].Value = "Education Qualification - School";
            sqlparam1[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dtable.Rows[e.RowIndex]["school"].ToString();
            sqlparam1[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = string.Empty;
            sqlparam1[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam1[3].Value = Session["empcode"].ToString();
            sqlparam1[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam1[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam1);

            SqlParameter[] sqlparam2 = new SqlParameter[5];
            sqlparam2[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam2[0].Value = "Education Qualification - Percentage";
            sqlparam2[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam2[1].Value = dtable.Rows[e.RowIndex]["percentage"].ToString();
            sqlparam2[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam2[2].Value = string.Empty;
            sqlparam2[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam2[3].Value = Session["empcode"].ToString();
            sqlparam2[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam2[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam2);

            SqlParameter[] sqlparam3 = new SqlParameter[5];
            sqlparam3[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam3[0].Value = "Education Qualification - From_Year";
            sqlparam3[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam3[1].Value = dtable.Rows[e.RowIndex]["from_year"].ToString();
            sqlparam3[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam3[2].Value = string.Empty;
            sqlparam3[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam3[3].Value = Session["empcode"].ToString();
            sqlparam3[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam3[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam3);

            SqlParameter[] sqlparam4 = new SqlParameter[5];
            sqlparam4[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam4[0].Value = "Education Qualification - To_Year";
            sqlparam4[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam4[1].Value = dtable.Rows[e.RowIndex]["to_year"].ToString();
            sqlparam4[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam4[2].Value = string.Empty;
            sqlparam4[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam4[3].Value = Session["empcode"].ToString();
            sqlparam4[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam4[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam4);

            try
            {
                int id = Convert.ToInt32(((Label)gvRows.FindControl("lblID")).Text);
                EmployeeViewBusiness objBal = new EmployeeViewBusiness();
                int res = objBal.DeleteEducation(id);
            }

            catch (Exception err)
            {


            }

            drfind_acc_edu.Delete();
            ViewState["Education"] = dtable;
            BindList_acc_edu_Update();
            ////////////--------------------


        }
    }

    protected void grid_edu_education_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_edu_education.EditIndex = e.NewEditIndex;
        DataTable dt = (DataTable)ViewState["Education"];
        grid_edu_education.DataSource = dt;
        grid_edu_education.DataBind();
        GridViewRow row = (GridViewRow)grid_edu_education.Rows[e.NewEditIndex];
        TextBox DrpEducation = (TextBox)row.FindControl("DrpEducation");
        TextBox TxtSchool = (TextBox)row.FindControl("TxtSchool");
        TextBox txtGrade = (TextBox)row.FindControl("txtGrade");
        TextBox Txtfrom = (TextBox)row.FindControl("Txtfrom");
        TextBox txtto = (TextBox)row.FindControl("txtto");
        DrpEducation.Enabled = true;
        TxtSchool.Enabled = true;
        txtGrade.Enabled = true;
        Txtfrom.Enabled = true;
        txtto.Enabled = true;
    }
    protected void grid_edu_education_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox DrpEducation = ((TextBox)grid_edu_education.Rows[e.RowIndex].FindControl("DrpEducation"));
        TextBox TxtSchool = ((TextBox)grid_edu_education.Rows[e.RowIndex].FindControl("TxtSchool"));
        TextBox txtGrade = ((TextBox)grid_edu_education.Rows[e.RowIndex].FindControl("txtGrade"));
        TextBox Txtfrom = ((TextBox)grid_edu_education.Rows[e.RowIndex].FindControl("Txtfrom"));
        TextBox txtto = ((TextBox)grid_edu_education.Rows[e.RowIndex].FindControl("txtto"));
        int code = Convert.ToInt32(grid_edu_education.DataKeys[e.RowIndex].Value.ToString());
        grid_edu_education.EditIndex = -1;
        sqlstr = "Update tbl_employee_edcationalqualifications set education= '" + DrpEducation.Text + "' , school= ' " + TxtSchool.Text + "' , percentage = '" + txtGrade.Text + "', yearfrom = '" + Txtfrom.Text + "', yearto = '" + txtto.Text + "' where id= " + code + "";
        //sqlstr = "UPDATE links SET category='Helpful Link', linktitle='" + txtheadingg.Replace("'", "''") + "',url='" + txtdescriptiong.Replace("'", "''") + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        isUpdate = 1;
        bind_Education_Qualification(emp_code);



    }

    //// -----------------Edit Professional Grid-------------------------

    protected void grid_Pro_education_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_Pro_education.PageIndex = e.NewPageIndex;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Professional_Qualification(emp_code);
    }

    protected void grid_Pro_education_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_Pro_education.EditIndex = -1;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Professional_Qualification(emp_code);
    }
    protected void grid_Pro_education_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String key = grid_Pro_education.DataKeys[e.Row.RowIndex].Value.ToString();
            try
            {
                Convert.ToInt32(key);
            }
            catch (Exception err)
            {
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkbtnedit");
                if (btn != null)
                {
                    btn.Visible = false;
                }
            }
        }
    }
    protected void grid_Pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        GridViewRow gvRows = (GridViewRow)grid_Pro_education.Rows[e.RowIndex];

        DataRow drfind_pro_edu = dtable.Rows.Find(Convert.ToString(grid_Pro_education.DataKeys[e.RowIndex].Value));
        if (drfind_pro_edu != null)
        {

            ////////////----------------------------------------

            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam[0].Value = "Professional Qualification - Class";
            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dtable.Rows[e.RowIndex]["education"].ToString();
            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam[2].Value = string.Empty;
            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["empcode"].ToString();
            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);


            SqlParameter[] sqlparam1 = new SqlParameter[5];
            sqlparam1[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam1[0].Value = "Professional Qualification - Institute/University";
            sqlparam1[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dtable.Rows[e.RowIndex]["school"].ToString();
            sqlparam1[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = string.Empty;
            sqlparam1[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam1[3].Value = Session["empcode"].ToString();
            sqlparam1[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam1[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam1);

            SqlParameter[] sqlparam2 = new SqlParameter[5];
            sqlparam2[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam2[0].Value = "Professional Qualification - Percentage";
            sqlparam2[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam2[1].Value = dtable.Rows[e.RowIndex]["percentage"].ToString();
            sqlparam2[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam2[2].Value = string.Empty;
            sqlparam2[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam2[3].Value = Session["empcode"].ToString();
            sqlparam2[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam2[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam2);

            SqlParameter[] sqlparam3 = new SqlParameter[5];
            sqlparam3[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam3[0].Value = "Professional Qualification - From_Year";
            sqlparam3[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam3[1].Value = dtable.Rows[e.RowIndex]["from_year"].ToString();
            sqlparam3[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam3[2].Value = string.Empty;
            sqlparam3[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam3[3].Value = Session["empcode"].ToString();
            sqlparam3[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam3[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam3);

            SqlParameter[] sqlparam4 = new SqlParameter[5];
            sqlparam4[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam4[0].Value = "Professional Qualification - To_Year";
            sqlparam4[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam4[1].Value = dtable.Rows[e.RowIndex]["to_year"].ToString();
            sqlparam4[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam4[2].Value = string.Empty;
            sqlparam4[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam4[3].Value = Session["empcode"].ToString();
            sqlparam4[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam4[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam4);

            ////////////--------------------
            try
            {
                int id = Convert.ToInt32(((Label)gvRows.FindControl("lblID")).Text);
                EmployeeViewBusiness objBal = new EmployeeViewBusiness();
                int res = objBal.DeleteProfession(id);
            }

            catch (Exception err)
            {


            }



            drfind_pro_edu.Delete();

            ViewState["Prosessional"] = dtable;
            BindList_pro_edu_update();
        }
    }

    protected void grid_Pro_education_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_Pro_education.EditIndex = e.NewEditIndex;
        DataTable dt = (DataTable)ViewState["Prosessional"];
        grid_Pro_education.DataSource = dt;
        grid_Pro_education.DataBind();
        GridViewRow row = (GridViewRow)grid_Pro_education.Rows[e.NewEditIndex];
        TextBox TxtProEducation = (TextBox)row.FindControl("TxtProEducation");
        TextBox TxtUniName = (TextBox)row.FindControl("TxtUniName");
        TextBox txPer = (TextBox)row.FindControl("txPer");
        TextBox TxtyearFrom = (TextBox)row.FindControl("TxtyearFrom");
        TextBox Txtyearto = (TextBox)row.FindControl("Txtyearto");
        TxtProEducation.Enabled = true;
        TxtUniName.Enabled = true;
        txPer.Enabled = true;
        TxtyearFrom.Enabled = true;
        Txtyearto.Enabled = true;
    }
    protected void grid_Pro_education_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int code = Convert.ToInt32(grid_Pro_education.DataKeys[e.RowIndex].Value.ToString());
        TextBox TxtProEducation = ((TextBox)grid_Pro_education.Rows[e.RowIndex].FindControl("TxtProEducation"));
        TextBox TxtUniName = ((TextBox)grid_Pro_education.Rows[e.RowIndex].FindControl("TxtUniName"));
        TextBox txPer = ((TextBox)grid_Pro_education.Rows[e.RowIndex].FindControl("txPer"));
        DropDownList DrpMonthfrom = ((DropDownList)grid_Pro_education.Rows[e.RowIndex].FindControl("DropMonthfrom"));
        TextBox TxtyearFrom = ((TextBox)grid_Pro_education.Rows[e.RowIndex].FindControl("TxtyearFrom"));
        DropDownList DropMonthto = ((DropDownList)grid_Pro_education.Rows[e.RowIndex].FindControl("DropMonthto"));
        TextBox Txtyearto = ((TextBox)grid_Pro_education.Rows[e.RowIndex].FindControl("Txtyearto"));

        grid_Pro_education.EditIndex = -1;
        sqlstr = "Update tbl_employee_professionalqualifications set education= '" + TxtProEducation.Text + "' , school= ' " + TxtUniName.Text + "' ,  percentage = '" + txPer.Text + "',monthfrom= ' " + DrpMonthfrom.SelectedValue + "', yearfrom = '" + TxtyearFrom.Text + "',monthto = ' " + DropMonthto.SelectedValue + "', yearto = '" + Txtyearto.Text + "' where id= " + code + "";

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        isUpdate = 1;
        bind_Professional_Qualification(emp_code);



    }
    protected void ChkExp_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkExp.Checked == true)
        {
            divTodate.Visible = false;
            string text;
            text = "Till Now";
            txt_to_exp.Text = text;
        }
        else
        {
            divTodate.Visible = true;
            txt_to_exp.Text = "";
        }
    }

    //// -----------------Edit Experience Grid-------------------------

    protected void grid_exp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_exp.PageIndex = e.NewPageIndex;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Exp_detail(emp_code);
    }

    protected void grid_exp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_exp.EditIndex = -1;
        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        bind_Exp_detail(emp_code);
    }
    protected void grid_exp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String key = grid_exp.DataKeys[e.Row.RowIndex].Value.ToString();
            try
            {
                Convert.ToInt32(key);
            }
            catch (Exception err)
            {
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkbtnedit");
                if (btn != null)
                {
                    btn.Visible = false;
                }
            }
        }
    }
    protected void grid_exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["exp"];
        GridViewRow gvRows = (GridViewRow)grid_exp.Rows[e.RowIndex];

        DataRow drfind_exp = dtable.Rows.Find(Convert.ToString(grid_exp.DataKeys[e.RowIndex].Value));
        if (drfind_exp != null)
        {

            ////////////----------------------------------------

            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam[0].Value = "Experience Details - Company Name";
            sqlparam[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dtable.Rows[e.RowIndex]["comp_name"].ToString();
            sqlparam[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam[2].Value = string.Empty;
            sqlparam[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["empcode"].ToString();
            sqlparam[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam);


            SqlParameter[] sqlparam1 = new SqlParameter[5];
            sqlparam1[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            sqlparam1[0].Value = "Experience Details - Location";
            sqlparam1[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dtable.Rows[e.RowIndex]["location"].ToString();
            sqlparam1[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = string.Empty;
            sqlparam1[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            sqlparam1[3].Value = Session["empcode"].ToString();
            sqlparam1[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            sqlparam1[4].Value = txtempcode.Text;

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam1);

            //SqlParameter[] sqlparam2 = new SqlParameter[5];
            //sqlparam2[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            //sqlparam2[0].Value = "Experience Details - Total Experience";
            //sqlparam2[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            //sqlparam2[1].Value = dtable.Rows[e.RowIndex]["total_exp"].ToString();
            //sqlparam2[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            //sqlparam2[2].Value = string.Empty;
            //sqlparam2[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            //sqlparam2[3].Value = Session["empcode"].ToString();
            //sqlparam2[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            //sqlparam2[4].Value = txtempcode.Text;

            //DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam2);

            //SqlParameter[] sqlparam3 = new SqlParameter[5];
            //sqlparam3[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            //sqlparam3[0].Value = "Experience Details - From_Year";
            //sqlparam3[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            //sqlparam3[1].Value = dtable.Rows[e.RowIndex]["from_year"].ToString();
            //sqlparam3[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            //sqlparam3[2].Value = string.Empty;
            //sqlparam3[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            //sqlparam3[3].Value = Session["empcode"].ToString();
            //sqlparam3[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            //sqlparam3[4].Value = txtempcode.Text;

            //DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam3);

            //SqlParameter[] sqlparam4 = new SqlParameter[5];
            //sqlparam4[0] = new SqlParameter("@IN_Field_Name", SqlDbType.VarChar, 100);
            //sqlparam4[0].Value = "Experience Details - To_Year";
            //sqlparam4[1] = new SqlParameter("@IN_Previous", SqlDbType.VarChar, 50);
            //sqlparam4[1].Value = dtable.Rows[e.RowIndex]["to_year"].ToString();
            //sqlparam4[2] = new SqlParameter("@IN_Modified", SqlDbType.VarChar, 50);
            //sqlparam4[2].Value = string.Empty;
            //sqlparam4[3] = new SqlParameter("@IN_Created_By", SqlDbType.VarChar, 50);
            //sqlparam4[3].Value = Session["empcode"].ToString();
            //sqlparam4[4] = new SqlParameter("@IN_EmpCode", SqlDbType.VarChar, 50);
            //sqlparam4[4].Value = txtempcode.Text;

            //DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Audit_Job_Details", sqlparam4);

            ////////////--------------------
            try
            {
                int id = Convert.ToInt32(((Label)gvRows.FindControl("lblID")).Text);
                EmployeeViewBusiness objBal = new EmployeeViewBusiness();
                int res = objBal.DeleteExperience(id);
            }

            catch (Exception err)
            {


            }



            drfind_exp.Delete();
            Session["exp"] = dtable;
            BindList_exp();
        }
    }

    protected void grid_exp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_exp.EditIndex = e.NewEditIndex;
        DataTable dt = (DataTable)Session["exp"];
        grid_exp.DataSource = dt;
        grid_exp.DataBind();
        GridViewRow row = (GridViewRow)grid_exp.Rows[e.NewEditIndex];
        TextBox TxtCompany = (TextBox)row.FindControl("TxtCompany");
        TextBox TxtLocation = (TextBox)row.FindControl("TxtLocation");
        TextBox TxtDesg = (TextBox)row.FindControl("TxtDesg");
        TextBox txtFromdate = (TextBox)row.FindControl("txtFromdate");
        TextBox TxtTodate = (TextBox)row.FindControl("TxtTodate");
        TxtCompany.Enabled = true;
        TxtLocation.Enabled = true;
        TxtDesg.Enabled = true;
        txtFromdate.Enabled = true;
        TxtTodate.Enabled = true;
    }
    protected void grid_exp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int code = Convert.ToInt32(grid_exp.DataKeys[e.RowIndex].Value.ToString());
        TextBox TxtCompany = ((TextBox)grid_exp.Rows[e.RowIndex].FindControl("TxtCompany"));
        TextBox TxtLocation = ((TextBox)grid_exp.Rows[e.RowIndex].FindControl("TxtLocation"));
        TextBox TxtDesg = ((TextBox)grid_exp.Rows[e.RowIndex].FindControl("TxtDesg"));
        TextBox txtFromdate = ((TextBox)grid_exp.Rows[e.RowIndex].FindControl("txtFromdate"));
        TextBox TxtTodate = ((TextBox)grid_exp.Rows[e.RowIndex].FindControl("TxtTodate"));

        grid_exp.EditIndex = -1;
        sqlstr = "Update tbl_employee_experiencedetails set companyname= '" + TxtCompany.Text + "' , location= ' " + TxtLocation.Text + "' ,  designation = '" + TxtDesg.Text + "', datefrom = '" + txtFromdate.Text + "', dateto = '" + TxtTodate.Text + "' where id= " + code + "";

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        string emp_code = string.Empty;
        emp_code = ViewState["EmpCode1"].ToString();
        isUpdate = 1;
        bind_Exp_detail(emp_code); ;



    }
}
