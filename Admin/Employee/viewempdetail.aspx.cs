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
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using Utilities;
public partial class viewempdetail : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataTable dtable = new DataTable();
    public static DataTable dt = new DataTable();
    string sqlstr;
    DataRow dr;
    DataView dview;


    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            TabContainer1.ActiveTabIndex = 0;

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

            Session["app_underwriter"] = null;
            Session["app_rep_underwriter"] = null;

                string emp_code = Request.QueryString["empcode"].ToString();
                bind_job_detail(emp_code);
                bind_contactdetails(emp_code);
                bind_personalinfo(emp_code);
                bind_child(emp_code);
                bind_Education_Qualification(emp_code);
                bind_Professional_Qualification(emp_code);
                bind_Exp_detail(emp_code);
                bind_payrolldetails(emp_code);
                //bind_salarydetail(emp_code);
                BindAttachment(emp_code);
                bind_reporting_detail(emp_code);
                bind_reporting_underwriter_detail(emp_code);
                //bind_Insurancedetail(emp_code);
               // bind_Insurancedetail(emp_code);
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
                LblPassexpiryDate.BackColor = System.Drawing.Color.Red;
            }
        }
    }
    //------------- bind the Attachment Detail of the emp master ----------------------------------------
        private void BindAttachment(string empCode)
        {
            EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
            EmpJobDetailENT userentity = new EmpJobDetailENT();

            userentity.Empcode = empCode;
            ds = objSelectALL.SelectAttachmentDetails(userentity);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            grdTempClass.DataSource = ds;
            grdTempClass.DataBind();
        }

        //------------- bind the Reporting Detail of the emp master ----------------------------------------
        protected void bind_reporting_detail(string emp_code)
        {
            EmployeeViewBusiness objSelectAll = new EmployeeViewBusiness();
            EmpReportingENT userentity = new EmpReportingENT();
            userentity.EmpCode = emp_code;
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

                dtable = (DataTable)Session["app_underwriter"];

                dr = dtable.NewRow();
                dr["approverid"] = ds1.Tables[0].Rows[0]["EMPCODE"].ToString();
                dr["approvername"] = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
                dr["category"] = ds1.Tables[0].Rows[0]["CategoryName"].ToString();
                //dr["BU"] = ds1.Tables[0].Rows[0]["BussinessUnitName"].ToString();
                dr["designation"] = ds1.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
                dr["approverpriority"] = ds.Tables[0].Rows[0]["approverpriority"].ToString();
                dtable.Rows.Add(dr);
                Session["app_underwriter"] = dtable;
            }
            if (Session["app_underwriter"] == null)
            {
                dview = new DataView(null);
            }
            else
            {
                dtable = (DataTable)Session["app_underwriter"];
                dview = new DataView(dtable);
                dview.Sort = "approvername";
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

            Session["app_underwriter"] = dtable;
        }

        //------------- bind the Reporting Underwriter Detail of the emp master ----------------------------------------
        protected void bind_reporting_underwriter_detail(string emp_code)
        {
            EmployeeViewBusiness objSelectAll = new EmployeeViewBusiness();
            EmpReportingENT userentity = new EmpReportingENT();
            userentity.EmpCode = emp_code;
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
                dtable = (DataTable)Session["app_rep_underwriter"];

                dr = dtable.NewRow();
                dr["approverid"] = ds1.Tables[0].Rows[0]["EMPCODE"].ToString();
                dr["approvername"] = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
                dr["category"] = ds1.Tables[0].Rows[0]["CategoryName"].ToString();
                dr["BU"] = ds1.Tables[0].Rows[0]["BussinessUnitName"].ToString();
                dr["designation"] = ds1.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
                dr["approverpriority"] = ds.Tables[0].Rows[0]["approverpriority"].ToString();
                dtable.Rows.Add(dr);
                Session["app_rep_underwriter"] = dtable;
            }
            if (Session["app_rep_underwriter"] == null)
            {
                dview = new DataView(null);
            }
            else
            {
                dtable = (DataTable)Session["app_rep_underwriter"];
                dview = new DataView(dtable);
                dview.Sort = "approvername";
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

            Session["app_rep_underwriter"] = dtable;
        }
    //------------- bind the Job Detail of the emp master ----------------------------------------



    protected void bind_job_detail(string emp_code)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = emp_code;
        ds = objSelectALL.SelectJobDetails(userentity);
        dt = ds.Tables[0];

        if (dt.Rows.Count < 1)
            return;
        txtcompanyname.Text = dt.Rows[0]["companyname"].ToString();
        txtempcode.Text = dt.Rows[0]["empcode"].ToString();
        txt_card_no.Text = dt.Rows[0]["card_no"].ToString();
        lbl_gender.Text = (dt.Rows[0]["emp_gender"].ToString() == "0") ? "---" : dt.Rows[0]["emp_gender"].ToString();
        txtfirstname.Text = dt.Rows[0]["emp_fname"].ToString();
        txtmiddlename.Text = dt.Rows[0]["emp_m_name"].ToString();
        txtlastname.Text = dt.Rows[0]["emp_l_name"].ToString();
        drpempstatus.Text = dt.Rows[0]["employeestatus"].ToString();
        lbl_emp_role.Text = dt.Rows[0]["role"].ToString();
        lbl_category_name.Text = dt.Rows[0]["CategoryName"].ToString();
        lbl_desigination.Text = dt.Rows[0]["designationname"].ToString();
        //lbl_job_type.Text = dt.Rows[0]["DesgCode"].ToString();
       // lbl_bu.Text = dt.Rows[0]["HomeBUnit"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["emp_doj"].ToString()))
        {
            doj.Text = Convert.ToDateTime(dt.Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            doj.Text = dt.Rows[0]["emp_doj"].ToString();
        }
        //lbl_sbu.Text = dt.Rows[0]["SecondaryBUnit"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["emp_doleaving"].ToString()))
        {
            
            txtdol.Text = Convert.ToDateTime(dt.Rows[0]["emp_doleaving"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtdol.Text = dt.Rows[0]["emp_doleaving"].ToString();
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["emp_doreleiving"].ToString()))
        {
            lblrelieving.Text = Convert.ToDateTime(dt.Rows[0]["emp_doreleiving"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            lblrelieving.Text = dt.Rows[0]["emp_doreleiving"].ToString(); 
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["salary_cal_from"].ToString()))
        {
            txtsalary.Text = Convert.ToDateTime(dt.Rows[0]["salary_cal_from"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtsalary.Text = dt.Rows[0]["salary_cal_from"].ToString();
        }
        txt_login_id.Text = dt.Rows[0]["login_id"].ToString();
    }

    //------------Bind Payroll Details of Employee-----------------
    protected void bind_payrolldetails(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectpayrollDetails(userentity);
        dt = ds.Tables[0];
        if (dt.Rows.Count < 1)
            return;
        esino.Text = dt.Rows[0]["esi_no"].ToString();
        esidesp.Text = dt.Rows[0]["esi_disp"].ToString();
        pfno.Text = dt.Rows[0]["pf_no"].ToString();
        pfno_dept.Text = dt.Rows[0]["pf_no_dept"].ToString();
        panno.Text = dt.Rows[0]["pan_no"].ToString();
        ward.Text = dt.Rows[0]["ward"].ToString();
    }
    //------------Bind Contact Details of Employee-----------------
    protected void bind_contactdetails(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectContactDetails(userentity);
        dt = ds.Tables[0];
        if (dt.Rows.Count < 1)
            return;
        txt_pre_add1.Text = dt.Rows[0]["pre_add1"].ToString();
        txt_pre_add2.Text = dt.Rows[0]["pre_Add2"].ToString();
        txt_pre_city.Text = dt.Rows[0]["pre_city"].ToString();
        txt_pre_state.Text = dt.Rows[0]["pre_state"].ToString();
        txt_pre_country.Text = dt.Rows[0]["pre_country"].ToString();
        txt_pre_zip.Text = dt.Rows[0]["pre_zip"].ToString();
        txt_pre_phone.Text = dt.Rows[0]["pre_phone"].ToString();
        txt_per_add1.Text = dt.Rows[0]["per_add1"].ToString();
        txt_per_add2.Text = dt.Rows[0]["per_add2"].ToString();
        txt_per_city.Text = dt.Rows[0]["per_city"].ToString();
        txt_per_state.Text = dt.Rows[0]["per_state"].ToString();
        txt_per_country.Text = dt.Rows[0]["per_country"].ToString();
        txt_per_zip.Text = dt.Rows[0]["per_zip"].ToString();
        txt_per_phone.Text = dt.Rows[0]["per_phone"].ToString();
        Lbl_emg_name.Text = dt.Rows[0]["Emergencycontactname"].ToString();
        Lbl_phone_emg.Text = dt.Rows[0]["Emergencyphoneno"].ToString();
        if (dt.Rows[0]["mode"].ToString() == "1")
        {
            
            lblmodeoftransport.Text = "Company Vehicle";
        }
        else
        {
            lblmodeoftransport.Text = "Own Vehicle";
        }
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
    //    LblPolicyName.Text = dt.Rows[0]["policyname"].ToString();
    //    Lbl_InsCmpyName.Text = dt.Rows[0]["InscmpyName"].ToString();
    //    Lbl_CustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
    //    if (!string.IsNullOrEmpty(dt.Rows[0]["Validfrom"].ToString()))
    //    {
    //       LblValiddate.Text = Convert.ToDateTime(dt.Rows[0]["Validfrom"].ToString()).ToString("dd-MMM-yyyy");
    //    }
    //    else
    //    {
    //        LblValiddate.Text = dt.Rows[0]["Validfrom"].ToString();
    //    }
    //     Lbl_Limit.Text = dt.Rows[0]["PolicyLimit"].ToString();

    //}

    //------------Bind Personal Details of Employee-----------------
    protected void bind_personalinfo(string empcode)
    {

        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectPersonalDetails(userentity);
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count < 1)
        {
            paymentmode.Visible = false;
            return;
        }
        txt_f_f_name.Text = dt.Rows[0]["f_fname"].ToString() + ' ' + dt.Rows[0]["f_mname"].ToString() + ' ' + dt.Rows[0]["f_lname"].ToString();

        txt_m_fname.Text = dt.Rows[0]["m_fname"].ToString() + ' ' + dt.Rows[0]["m_lname"].ToString() + ' ' + dt.Rows[0]["m_mname"].ToString();

        txtbloodgrp.Text = dt.Rows[0]["bloodgrp"].ToString();
        txtaadharnumber.Text = dt.Rows[0]["AadhaarNumber"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["dob"].ToString()))
        {
            txt_DOB.Text = Convert.ToDateTime(dt.Rows[0]["dob"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txt_DOB.Text = dt.Rows[0]["dob"].ToString();
        }

        ddlpersonalstatus.Text = (dt.Rows[0]["maritalstatus"].ToString() == "0") ? "----" : dt.Rows[0]["maritalstatus"].ToString();

        txtrelg.Text = dt.Rows[0]["religion"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["doa"].ToString()))
        {
            txt_doa.Text = Convert.ToDateTime(dt.Rows[0]["doa"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txt_doa.Text = dt.Rows[0]["doa"].ToString();
        }
        txt_bank_emp.Text = dt.Rows[0]["NameINBank"].ToString();
        txt_sp_fname.Text = dt.Rows[0]["s_fname"].ToString() + ' ' + dt.Rows[0]["s_mname"].ToString() + ' ' + dt.Rows[0]["s_lname"].ToString();

        //txtmobileno.Text = dt.Rows[0]["mobile_no"].ToString();
        txt_email.Text = dt.Rows[0]["email_id"].ToString();
        txt_altemailid.Text = dt.Rows[0]["altemail_id"].ToString();
        txt_bank_name.Text = dt.Rows[0]["bank_name1"].ToString();
        txt_bank_ac.Text = dt.Rows[0]["ac_number"].ToString();
        txt_passportno.Text = dt.Rows[0]["passport_number"].ToString();
        if (ddlpersonalstatus.Text.ToString() == "Married")
        {
            tbl1.Visible = true;
        }
       if (ddlpersonalstatus.Text.ToString() == "Unmarried") 
        {
            tbl1.Visible = false;
        }
       lblpaymentmode.Text = dt.Rows[0]["paymentmode"].ToString();
       txt_bank_name_reimbursement.Text = dt.Rows[0]["bank_name_reimbursement1"].ToString();
       txt_bank_ac_reimbursement.Text = dt.Rows[0]["ac_number_reimbursement"].ToString();
       if (!string.IsNullOrEmpty(dt.Rows[0]["passportvalidDate"].ToString()))
       {
           LblPassexpiryDate.Text = Convert.ToDateTime(dt.Rows[0]["passportvalidDate"].ToString()).ToString("dd-MMM-yyyy");
       }
       else
       {
           LblPassexpiryDate.Text = dt.Rows[0]["passportvalidDate"].ToString();
       }
       if (!string.IsNullOrEmpty(dt.Rows[0]["s_dob"].ToString()))
       {
           LblSpouseDob.Text=Convert.ToDateTime(dt.Rows[0]["s_dob"].ToString()).ToString("dd-MMM-yyyy");
       }
       else
       {
           LblSpouseDob.Text = dt.Rows[0]["s_dob"].ToString();
       }
       if (Convert.ToInt32(dt.Rows[0]["pay"]) == 0)
        {
            paymentmode.Visible = true;
        }
        else
        {
            paymentmode.Visible = false;
        }
    }

    //------------Bind Child Details of Employee-----------------
    protected void bind_child(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectChildrenDetails(userentity);
        
       
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_child.DataSource = ds;
        grid_child.DataBind();
    }

    //------------Bind Education Details of Employee-----------------
    protected void bind_Education_Qualification(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectEducationalDetails(userentity);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_edu_education.DataSource = ds;
        grid_edu_education.DataBind();

    }

    //------------Bind Professional Details of Employee-----------------
    protected void bind_Professional_Qualification(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectProfessionalDetails(userentity);
        
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_Pro_education.DataSource = ds;
        grid_Pro_education.DataBind();

    }

    //------------Bind Experience Details of Employee-----------------
    
    //protected void bind_Exp_detail(string empcode)
    //{
    //    EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
    //    EmpJobDetailENT userentity = new EmpJobDetailENT();

    //    userentity.Empcode = empcode;
    //    ds = objSelectALL.SelectExperienceDetails(userentity);
        
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    grid_exp.DataSource = ds;
    //    grid_exp.DataBind();
    //}

    protected void bind_Exp_detail(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectExperienceDetails(userentity);
        Session["ExpDetail"] = ds;
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
            dr["from_date"] = ds.Tables[0].Rows[i]["datefrom"].ToString();
            try
            {
                if (dr["frm_date_tosort"]!=null)
                {
                    dr["frm_date_tosort"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["datefrom"]);
                }
            }
            catch (Exception ex)
            { 
            
            }
            dr["to_date"] = ds.Tables[0].Rows[i]["dateto"].ToString();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 100);
            sqlparm[0].Value = Utility.DateTimeForat(ds.Tables[0].Rows[i]["datefrom"].ToString());
            sqlparm[1] = new SqlParameter("@Todate", SqlDbType.DateTime, 100);
            if (ds.Tables[0].Rows[i]["dateto"].ToString() == "Till Now")
            {
                sqlparm[1].Value = System.DateTime.Now.ToString();
            }
            else
            {
                sqlparm[1].Value = Utility.DateTimeForat(ds.Tables[0].Rows[i]["dateto"].ToString());
            }
           
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifference", sqlparm);
            dr["duration"] = ds1.Tables[0].Rows[0]["result"].ToString();

            
            ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CalculateDateDifferenceNumeric", sqlparm);
            year = year + Convert.ToInt32(ds2.Tables[0].Rows[0]["years"].ToString());
            month = month + Convert.ToInt32(ds2.Tables[0].Rows[0]["months"].ToString());
            day = day + Convert.ToInt32(ds2.Tables[0].Rows[0]["days"].ToString());

            dtable.Rows.Add(dr);

        }

        ////if (day > 30)
        ////{
        ////    if (day % 30 != 0)
        ////    {
        //        day1 = day % 30;
        //    //    month1 = 1;
        //        month1 = day / 30;
        ////    }
        ////    else
        ////    {
        ////        day1 = day;
        ////    }
        ////}
        ////else
        ////{
        ////    day1 = day;
        ////}
        //if (month > 12)
        //{
        //    if (month % 12 != 0)
        //    {
        //        month1 = month1 + Convert.ToInt32(month % 12);
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
        DataView dview = (DataView)dtable.DefaultView;
        dview.Sort = "frm_date_tosort desc";
      Session["exp"]= (DataTable) dview.ToTable();
        //Session["exp"] = dtable;
        BindList_exp();

    }
    protected void BindList_exp()
    {
        if (Session["exp"] == null)
        {
            dtable = null;
        }
        else
        {
            dtable = (DataTable)Session["exp"];
            //dview = new DataView(dtable);
            //dview.Sort = "from_date";
        }
        grid_exp.DataSource = dtable;
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
        dtable.Columns.Add(new DataColumn("from_date", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_date", typeof(string)));
        dtable.Columns.Add(new DataColumn("duration", typeof(string)));
        dtable.Columns.Add(new DataColumn("frm_date_tosort", typeof(DateTime)));
        Session["exp"] = dtable;
    }
    protected void grdTempClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gRow = grdTempClass.Rows[index];
            string lblName = ((LinkButton)(gRow.FindControl("lblUploadedDoc"))).Text;
            string path = MapPath(@"~\\UploadDocs\\" + txt_card_no.Text.Trim() + "-" + lblName);
            byte[] bts = System.IO.File.ReadAllBytes(path);
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Type", "Application/octet-stream");
            Response.AddHeader("Content-Length", bts.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblName);
            Response.BinaryWrite(bts);
            Response.Flush();
            Response.End();
        }
    }
    
}
