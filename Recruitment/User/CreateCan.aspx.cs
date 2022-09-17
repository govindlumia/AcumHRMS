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
using System.Text;

public partial class Recruitment_User_UploadResume : System.Web.UI.Page
{
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

        BindDropDowns(ddlEmp_Ref, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Employees"), "Empcode", "EmpName");

        txtDOB.Attributes.Add("readonly", "readonly");
        txtapplicationdate.Attributes.Add("readonly", "readonly");
        txtcontactno.Attributes.Add("onkeypress", "return numberonly(event);");

        txtDOB.Text = DateTime.Now.AddYears(-18).ToString("dd-MMM-yyyy");
        txtapplicationdate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

        if (Request.QueryString["ID"] != null)
        {
            BindDropDowns(ddlvacancy, _ObjCommonBAL.BindDropDowns_Recruitment("Open", "OpenVaccancy"), "Vac_ID", "Name");
            ddlvacancy.SelectedValue = ViewState["ID"].ToString();
            ddlvacancy.Enabled = false;
        }
        else
        {
            BindDropDowns(ddlvacancy, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "OpenVaccancyEmp"), "Vac_ID", "Name");
        }

        if (Request.QueryString["Type"] != null)
        {
            if (string.Compare(Request.QueryString["Type"].ToString(), "EMP") == 0)
            {
                ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("CPP1");
                LinkButton btnBack = (LinkButton)mpContentPlaceHolder.FindControl("btnBack");

                btnBack.PostBackUrl = "~/Main.aspx";    

                ddlEmp_Ref.SelectedValue = Session["EmpCode"].ToString();
                ddlEmp_Ref.Enabled = false;

                btndraft.Visible = false;
                btnreset.Visible = false;
            }
        }
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
        if (ValidateAge() && ValidateFile())
        {
            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Vac_ID = ddlvacancy.SelectedItem.Value.ToString();
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

            if (txtflUpload.HasFile)
            {
                Random nxt = new Random();
                string fileName = nxt.Next(0, 10000).ToString() + txtflUpload.PostedFile.FileName.Replace(" ", "_");
                string files = Server.MapPath("~") + "\\Recruitment\\UploadResume\\";
                string FilePath = files + fileName;

                txtflUpload.SaveAs(Server.MapPath("~") + "\\Recruitment\\UploadResume\\" + fileName);

                ObjCanENT.FilePath = FilePath;
                ObjCanENT.FileName = fileName;
            }

            ViewState["CANID"] = ObjCanBusiness.Create_CanMaster(ObjCanENT);

            if (!string.IsNullOrEmpty(ViewState["CANID"].ToString()))
            {
                //SendMail();

                string url = "ViewCanRequest.aspx?Type=HRE";
                if (ViewState["ID"] != null)
                {
                    Cryptography objEnc = new Cryptography();
                    string key = objEnc.Encrypt(ViewState["ID"].ToString());
                    StringWriter writer = new StringWriter();
                    HttpContext.Current.Server.UrlEncode(key, writer);

                    if (Request.QueryString["Type"] != null)
                    {
                        if (string.Compare(Request.QueryString["Type"].ToString(), "EMP") == 0)
                        {
                            url = "CreateCan.aspx?ID=" + writer.ToString() + "&Type=EMP";
                        }
                    }
                    else
                    {
                        url = "ViewCanRequest.aspx?Type=HRE";
                    }
                }
                General.Alert("Record(s) save successfully", btnsubmit, url);
            }
            else
            {
                General.Alert("Record(s) not save successfully", this);
                return;
            }
        }
        else
        {
            return;
        }
    }

    protected void btndraft_Click(object sender, EventArgs e)
    {
       SaveResumeData("True");
    }

    protected void SendMail()
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["CANID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        string subInitator = string.Empty;
        string subRM = string.Empty;
        string subHC = string.Empty;
        string subCOO = string.Empty;

        StringBuilder builder = new StringBuilder();
        MailScript mail = new MailScript();

        string table = "<br/><br/><table width='100%'><tr><td width='20%'>Candidate Code</td><td  width='80%'>" + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + "</td></tr><tr><td>Vacancy Code</td><td>" + ds.Tables[0].Rows[0]["VAC_ID"].ToString() + "</td></tr>" +
            "<tr><td>Candidate Name</td><td>" + ds.Tables[0].Rows[0]["CANDIDATENAME"].ToString() + "</td></tr><tr><td>Date Of Birth</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString(General.DateFormatRecruitment()) + "</td></tr>" +
            "<tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr><tr><td>Remarks</td><td>" + ds.Tables[0].Rows[0]["REMARKS"].ToString() + "<br /><br /><br /></td></tr></table>" +
            "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

        #region MailtoInitator
        subInitator = "Candidate Notification – Candidate for shotlist ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";

        builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
        "Dear User,<br /><br />There is a new Candidate has been waiting for your shortlisting. The details are below: ");
        builder.Append(table);
        mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
        #endregion

        #region MailtoHR
        subRM = "Candidate Notification – Candidate Created ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";
        builder.Clear();
        builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
        "Dear Approver,<br /><br />Candidate has been created. The details are below: ");
        builder.Append(table);
        foreach (DataRow _drow in ds.Tables[4].Rows)
        {
            mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
        }
        #endregion
    }
}