using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QueryStringEncryption;
using System.Data;
using System.IO;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Recruitment_User_UploadResume : System.Web.UI.Page
{
    static DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();

            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }

            _FillControls();
            _BindData();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();

        BindDropDowns(ddlvacancy, _ObjCommonBAL.BindDropDowns_Recruitment("Open", "OpenVaccancy"), "Vac_ID", "Name");
        BindDropDowns(ddlEmp_Ref, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Employees"), "Empcode", "EmpName");

        txtDOB.Attributes.Add("readonly", "readonly");
        txtapplicationdate.Attributes.Add("readonly", "readonly");
        txtcontactno.Attributes.Add("onkeypress", "return numberonly(event);");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SaveResumeData("False");
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Clear()
    {
        txtfirstname.Text = "";
        txtmidname.Text = "";
        txtlastname.Text = "";
        txtemail.Text = "";
        txtcontactno.Text = "";
        txtSearch.Text = "";
        txtapplicationdate.Text = "";
        txtcomment.Text = "";
        ddlvacancy.SelectedIndex = 0;
        ddlEmp_Ref.SelectedIndex = 0;
    }

    #region //// dropdown events
    protected void ddlvacancy_DataBound(object sender, EventArgs e)
    {
        ddlvacancy.Items.Insert(0, new ListItem("---Select Vacancy---", "0"));


    }
    protected void ddlEmp_Ref_DataBound(object sender, EventArgs e)
    {

        ddlEmp_Ref.Items.Insert(0, new ListItem("--Select Employee--", "0"));

    }
    #endregion

    protected bool ValidateFile()
    {
        bool _flag = false;

        if (System.IO.Path.GetExtension(txtflUpload.FileName) == ".pdf" || System.IO.Path.GetExtension(txtflUpload.FileName) == ".doc" || System.IO.Path.GetExtension(txtflUpload.FileName) == ".docx")
        {
            _flag = true;
        }
        else
        {
            General.Alert("In Valid File Extensation", this);
            _flag = false;
        }
        return _flag;
    }

    protected bool ValidateAge()
    {
        bool _flag = false;

        int Age = GetAge(Convert.ToDateTime(txtDOB.Text));
        if (Age < 18)
        {
            General.Alert("Invalid Date", this);
            txtDOB.Text = "";
            RequiredFieldValidator7.Enabled = true;
            _flag = false;
        }
        else
            _flag = true;

        return _flag;
    }

    protected int GetAge(DateTime bornDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - bornDate.Year;
        if (bornDate > today.AddYears(-age))
            age--;
        return age;
    }

    protected void SaveResumeData(string Isdraft)
    {
        if (ValidateAge())
        {
            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Vac_ID = ddlvacancy.SelectedItem.Value.ToString();
            ObjCanENT.Can_ID = ViewState["ID"].ToString();
            ObjCanENT.F_name = txtfirstname.Text.Trim();
            ObjCanENT.M_name = "";
            ObjCanENT.L_name = txtlastname.Text.Trim();
            ObjCanENT.Email_Id = txtemail.Text.Trim();
            ObjCanENT.Contact_No = txtcontactno.Text.Trim();
            ObjCanENT.Remarks = txtcomment.Text.Trim();
            ObjCanENT.ApplicationDate = Convert.ToDateTime(txtapplicationdate.Text).ToString("MM-dd-yyyy");
            ObjCanENT.Keywords = txtSearch.Text.Trim();
            ObjCanENT.Isdraft = Isdraft;
            ObjCanENT.EmpRef = ddlEmp_Ref.SelectedItem.Value.ToString();
            ObjCanENT.EmpCode = Session["EmpCode"].ToString();
            ObjCanENT.FatherName = txtFatherName.Text.Trim();
            ObjCanENT.DOB = Convert.ToDateTime(txtDOB.Text).ToString("MM-dd-yyyy");

            ObjCanENT.FilePath = "";
            ObjCanENT.FileName = "";

            if (txtflUpload.HasFile)
            {
                if (ValidateFile())
                {
                    Random nxt = new Random();
                    string fileName = txtflUpload.PostedFile.FileName.Replace(" ", "_") + nxt.Next(0, 10000).ToString();
                    string files = Server.MapPath("~") + "\\UploadedResume\\";
                    string FilePath = files + fileName;

                    ObjCanENT.FilePath = FilePath;
                    ObjCanENT.FileName = fileName;

                    txtflUpload.SaveAs(Server.MapPath("~") + "\\Recruitment\\UploadedResume\\" + fileName);
                }
                else
                { return; }
            }

            if (string.Compare(ObjCanBusiness.Update_CanMaster(ObjCanENT), "1") == 0)
            {
                string url = "";
                Cryptography objEnc = new Cryptography();
                string key = objEnc.Encrypt(ViewState["ID"].ToString());
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.UrlEncode(key, writer);

                url = "CanViewDetails.aspx?ID=" + writer.ToString() + "";

                General.Alert("Record(s) save successfully", btnsubmit, url);
            }
            else
            {
                General.Alert("Record(s) not save successfully", this);
                return;
            }
        }
        else
        { return; }
    }

    protected void btndraft_Click(object sender, EventArgs e)
    {
        SaveResumeData("True");
    }

    protected void _BindData()
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblCanID.Text = _dt.Rows[0]["CAN_ID"].ToString();
            lblCreatedBy.Text = _dt.Rows[0]["CCREATEDBYNAME"].ToString();
            lblCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());

            txtfirstname.Text = _dt.Rows[0]["F_Name"].ToString();
            txtmidname.Text = _dt.Rows[0]["M_name"].ToString();
            txtlastname.Text = _dt.Rows[0]["L_name"].ToString();
            txtFatherName.Text = _dt.Rows[0]["FatherName"].ToString();
            txtemail.Text = _dt.Rows[0]["EMAIL_ID"].ToString();
            txtcontactno.Text = _dt.Rows[0]["CONTACT_NO"].ToString();
            txtcomment.Text = _dt.Rows[0]["REMARKS"].ToString();
            txtSearch.Text = _dt.Rows[0]["METAKEYWORD"].ToString();
            txtapplicationdate.Text = Convert.ToDateTime(_dt.Rows[0]["APPLICATIONDATE"].ToString()).ToString(General.DateFormatRecruitment());
            txtDOB.Text = Convert.ToDateTime(_dt.Rows[0]["DOB"].ToString()).ToString(General.DateFormatRecruitment());
            ddlvacancy.Items.FindByValue(_dt.Rows[0]["VAC_ID"].ToString()).Selected = true;
            ddlEmp_Ref.Items.FindByValue(_dt.Rows[0]["CCREATEDBY"].ToString()).Selected = true;

            if (string.Compare(_dt.Rows[0]["Can_StatusID"].ToString(), "1") == 0)
            {
                btndraft.Visible = false;
                btnreset.Visible = false;
            }
        }
    }
}