using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QueryStringEncryption;
using System.Web.UI.HtmlControls;
using System.Configuration;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.IO;
using System.Text;

public partial class Recruitment_User_CandidateEvaluation : System.Web.UI.Page
{
    int Result = 0;
    DataSet ds = new DataSet();

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
            if (Request.QueryString["RID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["RID"] = objDec.Decrypt(Request.QueryString["RID"].Replace(" ", "+").ToString());
            }

            _PageInitialise();
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

    protected void _PageInitialise()
    {
        _ShowCanDetails();
        _ShowRoundDetails();

        /// Both Methods below sequence matters // Dont change calling sequence
        BindEvalParaMaster();
        BindEvalSkillPara();
    }

    protected void _ShowCanDetails()
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        ViewState["DsCanDetails"] = ds;

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblvacID.Text = _dt.Rows[0]["VAC_ID"].ToString();
            lblvacName.Text = _dt.Rows[0]["DESIGNATIONNAME"].ToString();
            lblCanId.Text = _dt.Rows[0]["Can_ID"].ToString();
            lblName.Text = _dt.Rows[0]["CandidateName"].ToString();
            lblEmail.Text = _dt.Rows[0]["Email_Id"].ToString();
            lblContactno.Text = _dt.Rows[0]["Contact_No"].ToString();
            lblapplicationdate.Text = Convert.ToDateTime(_dt.Rows[0]["ApplicationDate"].ToString()).ToString(General.DateFormatRecruitment());
            lblCCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblRemarks.Text = _dt.Rows[0]["Remarks"].ToString();
        }
    }

    protected void _ShowRoundDetails()
    {
        lblRoundCode.Text = ViewState["RID"].ToString();
    }

    private void BindEvalSkillPara()
    {
        EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjEvalSkillParaENT.ID = "";
        ObjEvalSkillParaENT.Dsca = "";
        ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjRoundBusiness.Select_EvalSkillMaster(ObjEvalSkillParaENT);
        GvCanEvalSkills.DataSource = ds;
        GvCanEvalSkills.DataBind();
    }

    private void BindEvalParaMaster()
    {
        EvalParaENT ObjEvalParaENT = new EvalParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjEvalParaENT.ID = "";
        ObjEvalParaENT.Dsca = "";
        ObjEvalParaENT.EmpCode = Session["EmpCode"].ToString();

        ViewState["EvalPara"] = ObjRoundBusiness.Select_EvalParaMaster(ObjEvalParaENT);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _Result = "";
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        foreach (GridViewRow _Grv in GvCanEvalSkills.Rows)
        {
            Label lblEvalSkillsID = (Label)_Grv.FindControl("lblEvalSkillsID");
            RadioButtonList rdList = (RadioButtonList)_Grv.FindControl("rdList");
            TextBox txtRemarks = (TextBox)_Grv.FindControl("txtRemarks");

            CanEvalDetailsENT ObjCanEvalDetailsENT = new CanEvalDetailsENT();

            ObjCanEvalDetailsENT.Can_ID = ViewState["ID"].ToString();
            ObjCanEvalDetailsENT.RoundCode = ViewState["RID"].ToString();
            ObjCanEvalDetailsENT.EmpCode = Session["EmpCode"].ToString();
            ObjCanEvalDetailsENT.ESkill = lblEvalSkillsID.Text;
            ObjCanEvalDetailsENT.EPara = rdList.SelectedValue.ToString();
            ObjCanEvalDetailsENT.Remarks = txtRemarks.Text.Trim();

            _Result = ObjRoundBusiness.Create_CanEvalDetails(ObjCanEvalDetailsENT);
        }

        RoundENT ObjRoundENT = new RoundENT();

        ObjRoundENT.RoundCode = lblRoundCode.Text;
        ObjRoundENT.IsFeedback = "0";
        ObjRoundENT.Feedback = "1";
        ObjRoundENT.CanStatus = ddlCanStatus.SelectedValue.ToString();
        ObjRoundENT.EmpCode = Session["EmpCode"].ToString();
        ObjRoundENT.ModifiedBy = Session["EmpCode"].ToString();

        _Result = ObjRoundBusiness.Update_CanRoundEmpMapping(ObjRoundENT);

        SendMail();

        General.Alert("Record(s) Submitted Successfully", btnSubmit);

        Cryptography objEnc = new Cryptography();
        /// Candidate ID
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanViewDetails.aspx?ID=" + writer.ToString();

        Response.Redirect(url, true);

    }

    protected void GvCanEvalSkills_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList rdList = (RadioButtonList)e.Row.FindControl("rdList");
            rdList.DataSource = (DataSet)ViewState["EvalPara"];
            rdList.DataValueField = "ID";
            rdList.DataTextField = "Dsca";
            rdList.DataBind();

            rdList.SelectedIndex = 0;

            TextBox TB = (TextBox)e.Row.FindControl("txtRemarks");
            TB.MaxLength = 5;
        }
    }

    protected void SendMail()
    {
        ds = (DataSet)ViewState["DsCanDetails"];

        DataTable _dt = ds.Tables[2];
        DataRow[] result = _dt.Select("RoundCode = '" + ViewState["RID"].ToString() + "'");

        if (result.Length > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                string subInitator = string.Empty;
                string subInterviewer = string.Empty;
                string subRM = string.Empty;
                string subHC = string.Empty;
                string subCOO = string.Empty;

                StringBuilder builder = new StringBuilder();
                MailScript mail = new MailScript();

                string table = "<br/><br/><table width='100%'><tr><td width='20%'>Vacancy Code</td><td  width='80%'>" + ds.Tables[0].Rows[0]["VAC_ID"].ToString() + "</td></tr><tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr>" +
                            "<tr><td>Candidate Name</td><td>" + ds.Tables[0].Rows[0]["CANDIDATENAME"].ToString() + "</td></tr><tr><td>Interview Date</td><td>" + Convert.ToDateTime(result[0]["SCHDATE"]).ToString(General.DateFormatRecruitment()) + "</td></tr>" +
                            "<tr><td>Interview Time</td><td>" + Convert.ToDateTime(result[0]["SCHDATE"]).ToString("t") + "</td></tr>" +
                            "<tr><td>Round Name</td><td>" + result[0]["RoundName"].ToString() + "</td></tr><tr><td><br /><br /><br /></td></tr></table>" +
                            "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

                #region MailtoInitator
                subInitator = "Interview Notification – Interview Evaluation Filled( Reference Code : " + ViewState["RID"].ToString() + " ) ";
                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear User,<br /><br />Interview evaluation  has been filled with following details : ");
                builder.Append(table);
                mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
                #endregion

                #region MailtoHR
                subRM = "Interview Notification – Interview Evaluation Filled( Reference Code : " + ViewState["RID"].ToString() + " ) ";
                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br />Interview evaluation  has been filled with following details : ");
                builder.Append(table);
                foreach (DataRow _drow in ds.Tables[4].Rows)
                {
                    mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
                }
                #endregion

                #region MailtoInterviewer
                subInitator = "Interview Notification – Interview Evaluation Filled( Reference Code : " + ViewState["RID"].ToString() + " ) ";
                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear User,<br /><br />Interview evaluation  has been filled with following details : ");
                builder.Append(table);

                CommonBusiness _ObjCommonBAL = new CommonBusiness();

                DataTable _DtEmail = _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "GetEmail");

                mail.sendMailWithFormat(_DtEmail.Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
                #endregion
            }
        }
    }
}