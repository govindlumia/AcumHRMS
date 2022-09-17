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
using HRMS.BusinessLogic;
using HRMS.BusinessEntity;
using Utilities;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class Admin_company_empmaster : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    DataSet ds2 = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    //string filepath1 = "";
    //string filepath2 = "";
    //string filepath3 = "";
    //string filepath4 = "";
    //string filepath5 = "";
    //string filepath6 = "";

    DataTable Bucket = new DataTable();
    DataRow dr;
    static int counter = 0;


    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {

        txtempcode.ReadOnly = true;
        //doj.Attributes.Add("ReadOnly", "ReadOnly");
        //txtdoleaving.Attributes.Add("ReadOnly", "ReadOnly");
        //txtdorelieving.Attributes.Add("ReadOnly", "ReadOnly");
        //txtsalary.Attributes.Add("ReadOnly", "ReadOnly");
        //txt_DOB.Attributes.Add("ReadOnly", "ReadOnly");
        txt_doa.Attributes.Add("ReadOnly", "ReadOnly");
        //txt_child_Dob.Attributes.Add("Readonly", "ReadOnly");
        Ttxtunderwriter.Attributes.Add("ReadOnly", "ReadOnly");
        Txt_rep_underwriter.Attributes.Add("ReadOnly", "ReadOnly");
        //TxtSpouseDOb.Attributes.Add("ReadOnly", "ReadOnly");
        TxtPassportexpdate.Attributes.Add("ReadOnly", "ReadOnly");
       // TxtValidFrm.Attributes.Add("ReadOnly", "ReadOnly");

        if (!IsPostBack)
        {
            tbl1.Visible = false;
            tblCHD.Visible = false;
            tblDOB.Visible = false;
            FillControl();
            lbl_msg.Text = "";
            txt_card_no.Text = "";
            txtpwd.Text = "";
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
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
            if (Session["attachment"] != null)
            {
                Session.Remove("attachment");
            }
            if (Session["app_underwriter"] != null)
            {
                Session.Remove("app_underwriter");
            }
            if (Session["app_rep_underwriter"] != null)
            {
                Session.Remove("app_rep_underwriter");
            }
            Session["Bucket"] = null;
            Session["counter"] = null;

            //doj.Text = System.DateTime.Now.ToShortDateString();

        }
    }

    protected void drp_comp_name_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(drpcategory, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Category"), "ID", "CategoryName");
        //BindDropDowns(drpjobtype, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "JobType"), "ID", "DesgCode");
        BindDropDowns(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Designation"), "id", "designationname");
        //BindDropDowns(drphbu, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "BusinessUnit"), "ID", "BussinessUnitName");
        //BindDropDowns(drp_sbu, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "BusinessUnit"), "ID", "BussinessUnitName");

    }

    private void BindDropDowns1(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void GenerateEmpCode()
    {
        try
        {
            EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            txtempcode.Text = empBusiness.GenerateEmpCode(Convert.ToInt32(drp_comp_name.SelectedValue));
        }
        catch
        {

        }
    }

    //--------------------insert Insurance detail -----------------------

    //protected void insert_Insurance_Detail(string empcode)
    //{
    //    EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
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

    //    int result = empBusiness.CreateInsuranceDetail(userentity);

    //}
    //--------------------insert job detail and login details -----------------------
    protected void insert_Job_detail()
    {

        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();
        ///  SqlParameter[] arrParam = new SqlParameter[1];
        // int gradeeid = Convert.ToInt32(drpgrade.SelectedValue);
        //  arrParam[0] = new SqlParameter("@ID", Convert.ToInt32(drpgrade.SelectedValue));
        ///  sqlstr = "select GradeCode from tbl_Designation_Grade_Mapping where ID='" + gradeeid + "' ";
        /// count = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr));

        userentity.Empcode = txtempcode.Text.Trim().ToString();
        userentity.Card_no = txt_card_no.Text;
        userentity.Emp_gender = drpgender.SelectedItem.ToString();
        userentity.Emp_fname =  txtfirstname.Text;
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

        //if (txtdorelieving.Text == "")
        //{
        //    userentity.Emp_doreleiving = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        //}
        //else
        //{
        //    userentity.Emp_doreleiving = Utilities.Utility.dataformat(txtdorelieving.Text.ToString());
        //}
        //if (txtdoleaving.Text == "")
        //{
        //    userentity.Emp_doleaving = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        //}
        //else
        //{
        //    userentity.Emp_doleaving = Utilities.Utility.dataformat(txtdoleaving.Text.ToString());
        //}
        if (txtsalary.Text != "")
        {
            userentity.Salary_cal_from = Utilities.Utility.DateTimeForat(txtsalary.Text.ToString());
        }




        userentity.Photo = lblphoto.Text;


        userentity.EmployeeCode = Session["EmpCode"].ToString();

        int result = empBusiness.CreateJobDetails(userentity);

    }

    protected void insert_Log_in_detail()
    {
        int saltSize = 5;
        string salt = CreateSalt(saltSize);
        string passwordHash = CreatePasswordHash(txtpwd.Text.Trim(), salt);

        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        LoginENT userentity = new LoginENT();


        userentity.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
        userentity.Login_id = txtpwd.Text.Trim().ToString();
        userentity.Empcode = txtempcode.Text.Trim().ToString();
        userentity.Pwd = passwordHash.Trim().ToString();
        userentity.Role = Convert.ToInt32(drprole.SelectedValue);
        userentity.EmailId = txt_email.Text.Trim().ToString();
        userentity.EmployeeCode = Session["EmpCode"].ToString();

        int result = empBusiness.CreateLogin(userentity);


    }

    //--------------------Insert Payroll Details-----------------------

    protected void insert_Payroll_Detail(string empcode)
    {

        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        EmpPayrollENT userentity = new EmpPayrollENT();
        userentity.Empcode = empcode;
        userentity.Esi_no = esino.Text.Trim().ToString();
        userentity.Pf_no = pfno.Text.Trim().ToString();
        userentity.Pan_no = panno.Text.Trim().ToString();
        userentity.Esi_disp = esidesp.Text.Trim().ToString();
        userentity.Pf_no_dept = pfno_dept.Text.Trim().ToString();
        userentity.Ward = ward.Text.Trim().ToString();
        userentity.EmployeeCode = Session["EmpCode"].ToString();

        int result = empBusiness.CreatePayroll(userentity);

    }





    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Emp_fname = txtfirstname.Text;
        userentity.Category_id = Convert.ToInt32(drpcategory.SelectedValue);
        userentity.Degination_id = Convert.ToInt32(drpdegination.SelectedValue);
        //userentity.Home_Bussiness_unit = Convert.ToInt32(drphbu.SelectedValue);
        userentity.Emp_doj = Utilities.Utility.DateTimeForat(doj.Text.ToString());
        int result = empBusiness.ValidateEmployee(userentity);

        if (result == 1)
        {
            General.Alert("Employee already exist", btngeneralsubmit);
            resetPayroll();
            resetcontact();
            resetPersonalDetails();
            reset_professional_detail();
            resetjobdetails();
            //resetInsurance();
            reset_reporting_detail();
            resetdocument();
        }
        else
        {
            if (Grid_approval.Rows.Count < 1)
            {
                General.Alert("Please add atleast one reporting manager", btngeneralsubmit);
                return;
            }
            int span = DateTime.Now.Year - Convert.ToDateTime(txt_DOB.Text).Year;
            if (span < 18)
            {
                General.Alert("Age must be more than 18 years", btngeneralsubmit);
                return;
            }
            GenerateEmpCode();
            // We need to add excel code here later
            if (flUpload.HasFile)
                ViewState["DocName"] = flUpload.FileName;

            if (FileUpload1.HasFile)
            {
                UploadPhoto();
            }

            if (duplicate_emp_code() && duplicate_loginID())
            {
                insert_Job_detail();
                insert_Log_in_detail();



                Session.Add("Inserted_Emp_code", txtempcode.Text);
                LoginENT entity = new LoginENT();
                LoginBusiness objBAL = new LoginBusiness();
                entity.EmployeeCode = txtempcode.Text.Trim();

                var datas = objBAL.SelectEmailId(entity);
                if (datas.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(datas.Rows[0]["EmailId"].ToString()))
                    {

                        string m = Mail(txt_email.Text.ToString(), datas.Rows[0][1].ToString(), txtpwd.Text.Trim().ToString());


                    }
                    else
                    {


                    }
                }
                else
                {
                    //lbl_message.Visible = true;
                    //lbl_message.InnerText = "Employee code not present in the database.";
                    //General.Alert("Employee code not present in the database.", btnSendMail);
                    //General.CloseAlertWindow(, "");
                }

                if (Session["Inserted_Emp_code"] != null)
                {
                    string emplyee_Code = Session["Inserted_Emp_code"].ToString();

                    Insert_Educational_Qualification(emplyee_Code);
                    Insert_Professional_Qualification(emplyee_Code);
                    Insert_Expriece_detail(emplyee_Code);
                    insert_personal_detail(emplyee_Code);
                    Insert_Children_detail(emplyee_Code);
                    insert_contact_detail(emplyee_Code);
                    insert_Payroll_Detail(emplyee_Code);
                    Insert_underwriter(emplyee_Code);
                    Insert_rep_underwriter(emplyee_Code);
                    InsertDocuments(emplyee_Code);
                   // insert_Insurance_Detail(emplyee_Code);
                    //insert_salary_Detail(emplyee_Code);
                    //AdditionalFileUploading();
                    //Attachments(emplyee_Code);
                    resetPayroll();
                    resetcontact();
                    resetPersonalDetails();
                    reset_professional_detail();
                    resetjobdetails();
                    //resetInsurance();
                    reset_reporting_detail();
                    resetdocument();


                    //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                    string str = "<script> alert('Employee Detail has been successfully inserted')</script>";
                    Page.RegisterStartupScript("Employee", str.ToString());
                    TabContainer1.ActiveTabIndex = 0;
                }

                else
                {
                    string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
                    Page.RegisterStartupScript("Employee", str.ToString());

                    //lbl_msg.Text = "Error : Please Enter Employee Code in Job Detail Tab of Employee Master.";

                }

            }
        }
    }

    private void UploadPhoto()
    {
        Random nxt = new Random();
        string fileName = txtempcode.Text + "_" + nxt.Next().ToString() + FileUpload1.PostedFile.FileName.Replace(" ", "_").ToString();

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
    //------------------- Start insertion of attached documents---------------------------


    private void InsertDocuments(string empCode)
    {
        string docType = string.Empty;
        string uploadDoc = string.Empty;
        string desc = string.Empty;
        foreach (GridViewRow gvrow in grdTempClass.Rows)
        {
            docType = ((Label)gvrow.FindControl("lblDocType")).Text;
            uploadDoc = ((Label)gvrow.FindControl("lblUploadedDoc")).Text;
            desc = ((Label)gvrow.FindControl("lblDesc")).Text;

            EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            EmpAttachmentENT userentity = new EmpAttachmentENT();

            userentity.Empcode = empCode;
            userentity.DocType = Convert.ToInt32(docType);
            userentity.Attachment = uploadDoc;
            userentity.AttachmentName = uploadDoc;
            userentity.DocDescription = desc;
            userentity.EmployeeCode = Session["EmpCode"].ToString();

            int result = empBusiness.CreateAttachments(userentity);

        }
    }

    //------------------- end insertion of attached documents---------------------------

    //------------------- end of the insertion of job detail---------------------------

    //==========================================================================================================================
    public Boolean duplicate_loginID()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@login_ID", txtempcode.Text.Trim());

        sqlstr = "select count(Login_ID) from tbl_login where Login_ID= @login_ID";
        count = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            // lbl_msg.Text = "Employee Loging ID allready existes Please change Login ID.";

            string str = "<script> alert('Employee Loging ID already exists, Please change Login ID.')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());
            return false;

        }
        else
        {
            return true;
        }
    }

    public Boolean duplicate_emp_code()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@emp_code", txtempcode.Text.Trim());

        sqlstr = "select count(empcode) from tbl_intranet_employee_jobDetails where empcode= @emp_code";
        count = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            //  lbl_msg.Text = "Employee Code allready existes Please change Emplyee Code.";

            string str = "<script> alert('Employee Code already exists, Please change Employee Code.')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());
            return false;
        }
        else
        {
            return true;
        }
    }

    //========================================================================================================================================
    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    //========================================================================================================================================
    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
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
    //=========================================================================================================================================

    //protected void resetInsurance()
    //{
    //    TxtPolicyName.Text = "";
    //    TxtInsurance.Text = "";
    //    TxtCustID.Text = "";
    //    TxtValidFrm.Text = "";
    //    TxtPolicyLimit.Text = "";
    //}
    //===================================================================================================================================
    protected void btnpersonalsubmit_Click(object sender, EventArgs e)
    {






    }

    //=====================================================================================================================================
    protected void resetPersonalDetails()
    {

        txt_DOB.Text = "";
        txt_passportno.Text = "";
        txt_bank_name.Text = "";
        txt_email.Text = "";
        //txt_bank_name.Text = "";
        ddl_bank_name.SelectedIndex = -1;
        ddl_bank_name_reimbursement.SelectedIndex = -1;
        rbtncheque.Checked = true;
        txt_bank_ac_reimbursement.Text = "";
        txt_bank_ac.Text = "";
        drpBloodGroup.SelectedIndex = -1;
        txtrelg.Text = "";
        //txtmobileno.Text = "";
        txt_f_f_name.Text = "";
        txt_m_fname.Text = "";
        ddlpersonalstatus.SelectedValue = "Unmarried";
        txt_sp_fname.Text = "";
        txt_doa.Text = "";
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
        Session.Remove("Child");
        grid_child.DataSource = "";
        grid_child.DataBind();
        TxtPassportexpdate.Text = "";
        TxtSpouseDOb.Text = "";
        txtAltEmailId.Text = "";
        txtaadharnumber.Text = "";

    }
    protected void resetjobdetails()
    {
        txt_card_no.Text = "";
        //txt_login_id.Text = "";
        txtpwd.Text = "";
        drpgender.SelectedValue = "0";
        txtfirstname.Text = "";
        txtlastname.Text = "";
        drpempstatus.SelectedValue = "0";
        drprole.SelectedValue = "0";
        drpcategory.SelectedValue = "0";
        drpdegination.SelectedValue = "0";
        //drphbu.SelectedValue = "0";
        //drpjobtype.SelectedValue = "0";
        //drp_sbu.SelectedValue = "0";
        doj.Text = "";
        txtempcode.Text = "";
        txtsalary.Text = "";
        drp_comp_name.SelectedValue = "0";



    }

    //=======================================insert Professional details ==================================================================
    protected void btnprofessionaldetailssubmit_Click(object sender, EventArgs e)
    {






    }




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
    protected void reset_reporting_detail()
    {
        Session.Remove("app_underwriter");
        Session.Remove("app_rep_underwriter");

        Grid_approval.DataSource = "";
        Grid_approval.DataBind();

        Grid_rep_approval.DataSource = "";
        Grid_rep_approval.DataBind();


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

    //====================================================================================================================================
    protected void resetPayroll()
    {
        esino.Text = "";
        pfno.Text = "";
        panno.Text = "";
        esidesp.Text = "";
        pfno_dept.Text = "";
        ward.Text = "";

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

    protected void resetdocument()
    {

        ddlDocumentType.SelectedValue = "0";
        txtDesc.Text = "";
        grdTempClass.DataSource = "";
        grdTempClass.DataBind();


    }

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
            drfind_child.Delete();
            Session["child"] = dtable;
            BindList_child();
        }
    }



    //---------------------end insert child detail-------------------------

    protected void btn_pro_qual_add_Click(object sender, EventArgs e)
    {
        Ins_Pro_edu();
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        ddlMonthfrom.SelectedValue = "Jan";
        txtfrm1.Text = "";
        ddlMonthto.SelectedValue = "Jan";
        txtto1.Text = "";
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
        BindList_pro_edu();
    }
    protected void Bindattachemnt()
    {
        if (Session["attachment"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["attachment"];
            dview = new DataView(dtable);
            dview.Sort = "attachment";
        }
        //GridView5.DataSource = dview;
        //GridView5.DataBind();

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
    protected void create_Pro_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("month_from", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("month_to", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));


        Session["Pro_education"] = dtable;
    }

    protected void grid_Pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        DataRow drfind_pro_edu = dtable.Rows.Find(Convert.ToString(grid_Pro_education.DataKeys[e.RowIndex].Value));
        if (drfind_pro_edu != null)
        {
            drfind_pro_edu.Delete();
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }

    }

    protected void grid_attachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //dtable = (DataTable)Session["attachment"];
        //DataRow attachment1 = dtable.Rows.Find(Convert.ToString(GridView5.DataKeys[e.RowIndex].Value));
        //if (attachment1 != null)
        //{
        //    attachment1.Delete();
        //    Session["attachment"] = dtable;
        //    Bindattachemnt();
        //}
    }

    //------------------------------ End of Insertion of professional qualification ---------------------



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
        int year = 0, month = 0, day = 0;
        int year1 = 0, month1 = 0, day1 = 0;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        dtable = (DataTable)Session["exp"];

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
            dr["from_date"] = txt_from_exp.Text;
            dr["date_to_sort"] = Convert.ToDateTime(txt_from_exp.Text);
            dr["to_date"] = txt_to_exp.Text;
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

            dtable.Rows.Add(dr);
        }

        //if (day > 30)
        //{
        //    if (day % 30 != 0)
        //    {
        //        month += day / 30;
        //        day = day % 30;
        //       // month1 = 1;

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
        //        year += month / 12;
        //        month =  Convert.ToInt32(month % 12);
        //        //year1 = 1;

        //    }
        //    else
        //    {
        //       // month1 = month1 + month;
        //        month1 = month;
        //    }
        //}
        //else
        //{
        //    //month1 = month1 + month;
        //    month1 = month;
        //}

        //year1 = year1 + year;

        //  else
        //{ 
        //     Txttotal.Text = Convert.ToString(year1).ToString() + ' ' + "years" + ' ' + Convert.ToString(month1).ToString() + ' ' + "months" + ' ' + Convert.ToString(day1).ToString() + ' ' + "days";

        if (day > 30)
        {
            if (day % 30 != 0)
            {
                day1 = day % 30;
                month1 = 1;
            }
            else
            {
                day1 = day;
            }
        }
        else
        {
            day1 = day;
        }
        if (month > 12)
        {
            if (month % 12 != 0)
            {
                month1 = month1 + Convert.ToInt32(month % 12);
                year1 = 1;
            }
            else
            {
                month1 = month1 + month;
            }
        }
        else
        {
            month1 = month1 + month;
        }

        year1 = year1 + year;


        Txttotal.Text = Convert.ToString(year1).ToString() + ' ' + "years" + ' ' + Convert.ToString(month1).ToString() + ' ' + "months" + ' ' + Convert.ToString(day1).ToString() + ' ' + "days";
        // }
        Session["exp"] = dtable;
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
        dtable.Columns.Add(new DataColumn("date_to_sort", typeof(DateTime)));
        Session["exp"] = dtable;
    }
    protected void grid_exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["exp"];
        DataRow drfind_exp = dtable.Rows.Find(Convert.ToString(grid_exp.DataKeys[e.RowIndex].Value));
        if (drfind_exp != null)
        {
            drfind_exp.Delete();
            Session["exp"] = dtable;
            BindList_exp();
        }
    }
    //--------------------------------- End Insetion of Experience Detail--------------------------
    // ----------------------- Insert the UnderWriter Data---------------------------------
    protected void Ins_app_underwriter()
    {
        DataRow dr;
        if (Session["app_underwriter"] == null)
        {
            create_app_underwriter();
        }
        dtable = (DataTable)Session["app_underwriter"];
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
            //dr["BU"] = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            dr["designation"] = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
            dr["approverpriority"] = "1";
            dtable.Rows.Add(dr);
        }
        Session["app_underwriter"] = dtable;
        BindList_app_underwriter();
    }
    protected void BindList_app_underwriter()
    {
        if (Session["app_underwriter"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["app_underwriter"];
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

        Session["app_underwriter"] = dtable;
    }
    protected void Grid_approval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["app_underwriter"];
        DataRow drfind_app_underwriter = dtable.Rows.Find(Convert.ToString(Grid_approval.DataKeys[e.RowIndex].Value));
        if (drfind_app_underwriter != null)
        {
            drfind_app_underwriter.Delete();
            Session["app_underwriter"] = dtable;
            BindList_app_underwriter();
        }
    }
    protected void Btn_app_underwriter_Click(object sender, EventArgs e)
    {
        if (Ttxtunderwriter.Text == "")
        {
            General.Alert("Please pick Employee First", Btn_app_underwriter);
        }

        else
        {
            if (Grid_approval.Rows.Count > 0)
            {
                General.Alert("Only one reporting manager one can be added", Btn_app_underwriter);
            }
            else
            {
                Ins_app_underwriter();
                Ttxtunderwriter.Text = "";
            }
        }
    }


    //--------------------------------- End Insetion of UnderWriter Data--------------------------



    // ----------------------- Insert the Reporting UnderWriter Data---------------------------------
    protected void Ins_app_rep_underwriter()
    {
        DataRow dr;
        if (Session["app_rep_underwriter"] == null)
        {
            create_app_rep_underwriter();
        }
        dtable = (DataTable)Session["app_rep_underwriter"];
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
        Session["app_rep_underwriter"] = dtable;
        BindList_app_rep_underwriter();
    }
    protected void BindList_app_rep_underwriter()
    {
        if (Session["app_rep_underwriter"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["app_rep_underwriter"];
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

        Session["app_rep_underwriter"] = dtable;
    }
    protected void Grid_rep_approval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["app_rep_underwriter"];
        DataRow drfind_app_rep_underwriter = dtable.Rows.Find(Convert.ToString(Grid_rep_approval.DataKeys[e.RowIndex].Value));
        if (drfind_app_rep_underwriter != null)
        {
            drfind_app_rep_underwriter.Delete();
            Session["app_rep_underwriter"] = dtable;
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
                General.Alert("Only one reporting manager two can be added", Btn_app_rep_underwriter);
            }
            else
            {
                Ins_app_rep_underwriter();
                Txt_rep_underwriter.Text = "";
            }
        }
    }


    //--------------------------------- End Insetion of Reporting UnderWriter Data--------------------------

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
            dr["education"] = drp_edu_qualification.SelectedItem.ToString();
            dr["school"] = txtedush.Text;
            dr["percentage"] = txteduper.Text;
            dr["from_year"] = txtedufrom.Text;
            dr["to_year"] = txteduto.Text;
            dtable.Rows.Add(dr);
        }
        Session["acc_education"] = dtable;
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
    protected void create_acc_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));


        Session["acc_education"] = dtable;
    }

    protected void grid_edu_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        DataRow drfind_acc_edu = dtable.Rows.Find(Convert.ToString(grid_edu_education.DataKeys[e.RowIndex].Value));
        if (drfind_acc_edu != null)
        {
            drfind_acc_edu.Delete();
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }

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
        BindDropDowns(drp_comp_name, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(drpempstatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
        BindDropDowns(drprole, binddrop.BindDropDowns("", "Role"), "id", "role");
        BindDropDowns(drp_edu_qualification, binddrop.BindDropDowns("", "Education"), "ID", "EducationName");
        BindDropDowns(ddl_bank_name, binddrop.BindDropDowns("", "Bank"), "ID", "BankName");
        BindDropDowns(ddl_bank_name_reimbursement, binddrop.BindDropDowns("", "Bank"), "ID", "BankName");
        BindDropDowns(ddlDocumentType, binddrop.BindDropDowns("", "Document"), "ID", "DocumentName");


        BindDropDowns(drpcategory, binddrop.BindDropDowns("", "Category"), "ID", "CategoryName");
       // BindDropDowns(drpjobtype, binddrop.BindDropDowns("", "JobType"), "ID", "DesgCode");
        BindDropDowns(drpdegination, binddrop.BindDropDowns("", "Designation"), "id", "designationname");
        //BindDropDowns(drphbu, binddrop.BindDropDowns("", "BusinessUnit"), "ID", "BussinessUnitName");
        //BindDropDowns(drp_sbu, binddrop.BindDropDowns("", "BusinessUnit"), "ID", "BussinessUnitName");


    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }
    //----------------- End ------------------------------------------------------------

    //------------------------------- Insert the Photo --------------------


    //----------------- End ------------------------------------------------------------
    //------------------------------- Insert the underwriter data --------------------
    protected void Insert_underwriter(string emp_code)
    {
        if (Session["app_underwriter"] != null)
        {
            dtable = (DataTable)Session["app_underwriter"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpReportingENT userentity = new EmpReportingENT();
                userentity.EmpCode = emp_code;
                userentity.Approverid = dtable.Rows[i]["approverid"].ToString();
                userentity.Approverpriority = Convert.ToInt32(dtable.Rows[i]["approverpriority"].ToString());
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateReporting(userentity);
            }
        }
    }
    //------------------------------- End-----------------------------------------
    protected void Insert_rep_underwriter(string emp_code)
    {
        if (Session["app_rep_underwriter"] != null)
        {
            dtable = (DataTable)Session["app_rep_underwriter"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpReportingENT userentity = new EmpReportingENT();
                userentity.EmpCode = emp_code;
                userentity.Approverid = dtable.Rows[i]["approverid"].ToString();
                userentity.Approverpriority = Convert.ToInt32(dtable.Rows[i]["approverpriority"].ToString());
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateReporting(userentity);
            }
        }
    }

    //------------------------------- Insert the Educational qualification --------------------
    protected void Insert_Educational_Qualification(string emp_code)
    {
        if (Session["acc_education"] != null)
        {
            dtable = (DataTable)Session["acc_education"];
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
    protected void Insert_Professional_Qualification(string emp_code)
    {
        if (Session["Pro_education"] != null)
        {
            dtable = (DataTable)Session["Pro_education"];
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
    //------------------------------ insert Experience Detail in the database---------------------
    protected void Insert_Expriece_detail(string emp_code)
    {
        if (Session["exp"] != null)
        {
            dtable = (DataTable)Session["exp"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
                EmpExperianceENT userentity = new EmpExperianceENT();
                userentity.Empcode = emp_code;
                userentity.Companyname = dtable.Rows[i]["comp_name"].ToString();
                userentity.Location = dtable.Rows[i]["location"].ToString();
                userentity.Totalexperience = dtable.Rows[i]["Designation"].ToString();
                userentity.Yearfrom = dtable.Rows[i]["from_date"].ToString();
                userentity.Yearto = dtable.Rows[i]["to_date"].ToString();
                userentity.EmployeeCode = Session["EmpCode"].ToString();

                int result = empBusiness.CreateExperienceDetail(userentity);


            }
        }
    }
    //--------------------------------------- end ----------------------------
    //------------------------------ insert children Detail in the database---------------------
    protected void Insert_Children_detail(string emp_code)
    {

        if (Session["child"] != null)
        {
            dtable = (DataTable)Session["child"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DateTime dob;
                if (dtable.Rows[i]["child_dob"].ToString() != "")
                {
                    dob = Convert.ToDateTime(dtable.Rows[i]["child_dob"]);
                }
                else
                    dob = Convert.ToDateTime("01/01/1990");

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
    //--------------------------------------- Insert Personal Details ----------------------------------
    protected void insert_personal_detail(string empcode)
    {
        int paymentmode = 0;
        if (rbtnbank.Checked)
            paymentmode = 0;

        if (rbtncheque.Checked)
            paymentmode = 1;

        if (rbtncash.Checked)
            paymentmode = 2;

        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        EmpPersonalENT userentity = new EmpPersonalENT();
        userentity.Empcode = empcode;
        userentity.F_fname = txt_f_f_name.Text;
        userentity.M_fname = txt_m_fname.Text;
        userentity.Bloodgrp = drpBloodGroup.SelectedItem.ToString();
        userentity.Maritalstatus = ddlpersonalstatus.SelectedItem.ToString();
        userentity.Religion = txtrelg.Text;
        userentity.Dlno = txt_bank_name.Text;
        userentity.S_fname = txt_sp_fname.Text;
        userentity.Aadharnumber = txtaadharnumber.Text;
        if (txt_doa.Text != "")
        {
            userentity.Doa = Utilities.Utility.DateTimeForat(txt_doa.Text.ToString());
        }


        userentity.S_gender = "Male";
        userentity.No_child = 0;
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
            userentity.Dob = Convert.ToDateTime(txt_DOB.Text.ToString());
        }
        if (TxtPassportexpdate.Text != "")
        {
            userentity.PassportValidDate = Convert.ToDateTime(TxtPassportexpdate.Text.ToString());
        }

        if (TxtSpouseDOb.Text != "")
        {
            userentity.S_dob = Convert.ToDateTime(TxtSpouseDOb.Text.ToString());
        }
        userentity.Paymentmode = paymentmode;
        userentity.EmployeeCode = Session["EmpCode"].ToString();
        int result = empBusiness.CreatePersonalDetails(userentity);

    }
    //----------------------------- insert contact detail------------------------------

    protected void insert_contact_detail(string empcode)
    {
        int modeh = int.MinValue;
        if (optcompany.Checked)
        {
            modeh = 1;
        }

        if (optown.Checked)
        {
            modeh = 0;
        }
        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
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
        int result = empBusiness.CreateContactDetails(userentity);

    }
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



    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void ddl_bank_name_reimbursement_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name_reimbursement.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void resetsalary()
    //{
    //    txt_basic.Text = "";
    //    txt_mobile.Text = "";
    //    txt_conve.Text = "";
    //    txt_total.Text = "";

    //}


    //---------------------------------------

    protected void btnAddDoc_Click(object sender, EventArgs e)
    {
        string filePath = string.Empty;
        if (ddlDocumentType.SelectedIndex > 0 && txtDesc.Text.Length > 0 && flUpload.HasFile)
        {
            if (Session["counter"] == null) createBucket();
            Bind1();
        }
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
                    //filePath = "..\\UploadDocs\\" + txtempcode.Text.Trim() + "-" + flUpload.FileName.ToString();
                    //if (System.IO.File.Exists(Server.MapPath(filePath)))
                    //    System.IO.File.Delete(Server.MapPath(filePath));
                    //flUpload.SaveAs(filePath);
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

        txtDesc.Text = string.Empty;
        ddlDocumentType.SelectedIndex = 0;
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
        Session["Bucket"] = Bucket;
    }
    public void Bind1()
    {
        string docName = string.Empty;
        try
        {
            counter++;
            Bucket = (DataTable)Session["Bucket"];
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
            Session["Bucket"] = Bucket;
            int i = Convert.ToInt32(Session["counter"].ToString());
            i = i + 1;
            Session["BucketCount"] = i.ToString();
            Session["pid"] = Convert.ToInt32(Session["pid"]) + 1;
            grdTempClass.DataSource = (DataTable)Session["Bucket"];
            grdTempClass.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void bindTemp()
    {
        grdTempClass.DataSource = (DataTable)Session["Bucket"];
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

    //----------------------------------------


    //protected void SaveAdditionalAttachments()
    //{
    //    try
    //    {

    //            string fileNames = string.Empty;

    //            if (!string.IsNullOrEmpty(lnkBtn1.Text))
    //                fileNames += lnkBtn1.Text + ",";
    //            if (!string.IsNullOrEmpty(LinkButton3.Text))
    //                fileNames += LinkButton3.Text + ",";
    //            if (!string.IsNullOrEmpty(LinkButton4.Text))
    //                fileNames += LinkButton4.Text + ",";
    //            if (!string.IsNullOrEmpty(LinkButton5.Text))
    //                fileNames += LinkButton5.Text + ",";
    //            if (!string.IsNullOrEmpty(LinkButton6.Text))
    //                fileNames += LinkButton6.Text + ",";
    //            if (!string.IsNullOrEmpty(LinkButton7.Text))
    //                fileNames += LinkButton7.Text + ",";

    //            if (fileNames.EndsWith(",") == true)
    //            {
    //                fileNames = fileNames.Substring(0, fileNames.LastIndexOf(","));

    //                int result = Attachments(empcode, fileNames);
    //                if (result == 0)
    //                {
    //                    lblAddMessage.Text = "Documents Saved.";
    //                }
    //                else
    //                {
    //                    lblAddMessage.Text = "Couldn't Save Document.";
    //                }
    //            }

    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Main.aspx");
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

    protected void Grid_approval_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    private string Mail(string toEmail, string username,string passwordlogin) // Reset Password
    {
        string result = string.Empty;
        SmtpClient smtpClient = new SmtpClient();
        string userName = ConfigurationManager.AppSettings["UserName"].ToString();
        string password = ConfigurationManager.AppSettings["Password"].ToString();

        NetworkCredential basicCredential = new NetworkCredential(userName, password);
        MailMessage message = new MailMessage();
        MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
        smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
        smtpClient.UseDefaultCredentials = true;
        smtpClient.Credentials = basicCredential;
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        message.From = fromAddress;
        message.To.Add(toEmail.ToString());
        message.Subject = "Employee Login Password";

        //Set IsBodyHtml to true means you can send HTML email.
        message.IsBodyHtml = true;


        StringBuilder ObjStringBuilder = new StringBuilder();

        ObjStringBuilder = ObjStringBuilder.Append("<html><Body>Dear " + username + ", <br><br> Employee Added Successfully. <br><br>Please use this Password "+ passwordlogin + " to login .<br>");
        ObjStringBuilder = ObjStringBuilder.Append(" Also Please change your password once you access site.<br>");
        ObjStringBuilder = ObjStringBuilder.Append("<br><br>- Administrator, Acuminous Software Pvt. Ltd<br></Body></html>");
        message.Body = ObjStringBuilder.ToString();
        try
        {
            smtpClient.Send(message);
            result = "A mail has been sent on your email id. Follow the instructions in the mail.";
        }
        catch (Exception ex)
        {
            //Error, could not send the message
            Response.Write(ex.Message);
            result = "Mail has not been sent";
        }
        return result;
    }
}
