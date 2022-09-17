using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;
using System.IO;
using QueryStringEncryption;
using InfoSoftGlobal;
using Utilities;
using System.Transactions;

public partial class Recruitment_User_CreateVac : System.Web.UI.Page
{
    string FilePath = string.Empty;
    string VacID = string.Empty;
    string finalVac_Id = string.Empty;
    string Vac_Id = string.Empty;
    string Vacid = string.Empty;
    string fileName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();
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

        BindDropDowns(ddl_jobtitle, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Designation"), "id", "designationname");
        BindDropDowns(ddl_joblocation, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Branch"), "branch_id", "branch_name");

        txt_reqdate.Attributes.Add("readonly", "readonly");
        txt_position.Attributes.Add("onkeypress", "return numberonly(event);");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    #region // DDl Databound
    protected void ddljobtitle_DataBound(object sender, EventArgs e)
    {
        ddl_jobtitle.Items.Insert(0, new ListItem("---Select Job Title---", "0"));
    }
    protected void ddljoblocation_DataBound(object sender, EventArgs e)
    {
        ddl_joblocation.Items.Insert(0, new ListItem("---Select Job Location---", "0"));
    }
    #endregion

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string _Result = string.Empty;
        using (TransactionScope scope = new TransactionScope())
        {
            try
            {
                VacENT ObjVacENT = new VacENT();
                VacBusiness ObjVacBusiness = new VacBusiness();

                ObjVacENT.Title_ID = Convert.ToInt32(ddl_jobtitle.SelectedItem.Value);
                ObjVacENT.Name = txt_jobname.Text;
                ObjVacENT.Location_ID = Convert.ToInt32(ddl_joblocation.SelectedItem.Value);
                ObjVacENT.Count = Convert.ToInt32(txt_position.Text);
                ObjVacENT.EmpCode = Session["EmpCode"].ToString();
                ObjVacENT.RequiredDate = Utility.DateTimeForat(txt_reqdate.Text.ToString()).ToString("yyyy.MM.dd");
                ObjVacENT.Remarks = txt_Desc.Text;
                if (txtflUpload.HasFile)
                {
                    Random nxt = new Random();
                    string fileName = nxt.Next(0, 10000).ToString() + txtflUpload.PostedFile.FileName.Replace(" ", "_");
                    string files = Server.MapPath("~") + "\\Recruitment\\UploadJobDesc\\";
                    string FilePath = files + fileName;

                    ObjVacENT.FileName = fileName;
                    ObjVacENT.FilePath = FilePath;

                    txtflUpload.SaveAs(Server.MapPath("~") + "\\Recruitment\\UploadJobDesc\\" + fileName);
                }

                ViewState["VacID"] = ObjVacBusiness.Create_VacMaster(ObjVacENT);

                scope.Complete();
            }
            catch
            {
                scope.Dispose();
                General.Alert("Record(s) not submitted.", btnsubmit);
            }
        }
        if (ViewState["VacID"].ToString() == "Already Exists")
        {
            General.Alert("Vacancy code already exists. Kindly contact administrator", btnsubmit);
            return;
        }
        if (ViewState["VacID"].ToString() != "")
        {
            SendMail();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "Record(s) submitted", true);
            string Url = "ViewVacRequest.aspx?Type=C";
            Response.Redirect(Url);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "Record(s) not submitted", true);
        }
        Clear();
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Clear()
    {
        txt_jobname.Text = "";
        txt_reqdate.Text = "";
        txt_position.Text = "";
        txt_Desc.Text = "";
        ddl_joblocation.SelectedIndex = 0;
        ddl_jobtitle.SelectedIndex = 0;
    }

    protected void UplodeResum(string fileName, string FilePath)
    {
        if (txtflUpload.HasFile)
        {

            Random nxt = new Random();
            fileName = txtflUpload.PostedFile.FileName.Replace(" ", "_") + nxt.Next(0, 10000).ToString();
            string files = Server.MapPath("~") + "\\UplodeJobDesc\\";
            FilePath = files + fileName;

            txtflUpload.SaveAs(FilePath);
        }
    }

    protected void SendMail()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["VacID"].ToString();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[1];

                string subInitiator= "Vacancy Notification – New Vacancy ( Reference Code : " + ds.Tables[1].Rows[0]["VAC_ID"].ToString() + " ) ";
                string subRM = "Vacancy Notification – Vacancy for approval ( Reference Code : " + ds.Tables[1].Rows[0]["VAC_ID"].ToString() + " ) ";
                string subHC = subRM;
                string table = "<br/><br/><table width='100%'><tr><td width='20%'>Vacancy Code</td><td  width='80%'>" + ds.Tables[1].Rows[0]["VAC_ID"].ToString() + "</td></tr><tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr>" +
                    "<tr><td>Location</td><td>" + ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString() + "</td></tr><tr><td>No Of Positions</td><td>" + ds.Tables[0].Rows[0]["Count"].ToString() + "</td></tr>" +
                    "<tr><td>Required Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Req_Date"]).ToString(General.DateFormatRecruitment()) + "</td></tr><tr><td>Remarks</td><td>" + ds.Tables[0].Rows[0]["Remarks"].ToString() + "<br /><br /><br /></td></tr></table>" +
                    "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

                StringBuilder builder = new StringBuilder();
                MailScript mail = new MailScript();
                #region MailtoSelf
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear User,<br /><br /> You have created new vacancy. The details are below: ");
                builder.Append(table);
                mail.sendMailWithFormat(ds.Tables[1].Rows[0]["email_id"].ToString(), subInitiator, builder.ToString(), null, null);
                #endregion
                #region MailtoRM
                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> There is a new vacancy has been waiting for your approval. The details are below: ");
                builder.Append(table);
                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion
            }
        }
    }
}