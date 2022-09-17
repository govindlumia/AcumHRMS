using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QueryStringEncryption;
using System.Data;
using System.IO;
using System.Text;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Recruitment_User_VacViewDetails : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    DataTable _dtEmpty = new DataTable();
    string Ebackground_color = "#0287bf";
    string Ecolor = "white";

    string Dbackground_color = "white";
    string Dcolor = "black";

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
            _PageInitialize();
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

    protected void _PageInitialize()
    {
        VacDetails();
        InterviewScheduleList();

        DivHR.Style["display"] = "block";
        DivUR.Style["display"] = "none";
        DivSR.Style["display"] = "none";

        lnkHR.Style["background-color"] = Ebackground_color;
        lnkHR.Style["color"] = Ecolor;
        lnkUR.Style["background-color"] = Dbackground_color;
        lnkUR.Style["color"] = Dcolor;
        lnkSR.Style["background-color"] = Dbackground_color;
        lnkSR.Style["color"] = Dcolor;

        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CreateCan.aspx?ID=" + writer.ToString() + "&Type=EMP";
        btnCanCreate.PostBackUrl = url;
    }

    protected void lnkHR_Click(object sender, EventArgs e)
    {
        DivHR.Style["display"] = "block";
        DivUR.Style["display"] = "none";
        DivSR.Style["display"] = "none";
        DivRR.Style["display"] = "none";

        lnkHR.Style["background-color"] = Ebackground_color;
        lnkHR.Style["color"] = Ecolor;
        lnkUR.Style["background-color"] = Dbackground_color;
        lnkUR.Style["color"] = Dcolor;
        lnkSR.Style["background-color"] = Dbackground_color;
        lnkSR.Style["color"] = Dcolor;
        lnkRR.Style["background-color"] = Dbackground_color;
        lnkRR.Style["color"] = Dcolor;
    }
    protected void lnkUR_Click(object sender, EventArgs e)
    {
        DivHR.Style["display"] = "none";
        DivUR.Style["display"] = "block";
        DivSR.Style["display"] = "none";
        DivRR.Style["display"] = "none";

        lnkHR.Style["background-color"] = Dbackground_color;
        lnkHR.Style["color"] = Dcolor;
        lnkUR.Style["background-color"] = Ebackground_color;
        lnkUR.Style["color"] = Ecolor;
        lnkSR.Style["background-color"] = Dbackground_color;
        lnkSR.Style["color"] = Dcolor;
        lnkRR.Style["background-color"] = Dbackground_color;
        lnkRR.Style["color"] = Dcolor;
    }
    protected void lnkSR_Click(object sender, EventArgs e)
    {
        DivHR.Style["display"] = "none";
        DivUR.Style["display"] = "none";
        DivSR.Style["display"] = "block";
        DivRR.Style["display"] = "none";

        lnkHR.Style["background-color"] = Dbackground_color;
        lnkHR.Style["color"] = Dcolor;
        lnkUR.Style["background-color"] = Dbackground_color;
        lnkUR.Style["color"] = Dcolor;
        lnkSR.Style["background-color"] = Ebackground_color;
        lnkSR.Style["color"] = Ecolor;
        lnkRR.Style["background-color"] = Dbackground_color;
        lnkRR.Style["color"] = Dcolor;
    }
    protected void lnkRR_Click(object sender, EventArgs e)
    {
        DivHR.Style["display"] = "none";
        DivUR.Style["display"] = "none";
        DivSR.Style["display"] = "none";
        DivRR.Style["display"] = "block";

        lnkHR.Style["background-color"] = Dbackground_color;
        lnkHR.Style["color"] = Dcolor;
        lnkUR.Style["background-color"] = Dbackground_color;
        lnkUR.Style["color"] = Dcolor;
        lnkSR.Style["background-color"] = Dbackground_color;
        lnkSR.Style["color"] = Dcolor;
        lnkRR.Style["background-color"] = Ebackground_color;
        lnkRR.Style["color"] = Ecolor;
    }

    protected void VacDetails()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

        ViewState["ds"] = ds;

        // Vaccancy Details
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblVacId.Text = _dt.Rows[0]["VAC_ID"].ToString();
            lblTitle.Text = _dt.Rows[0]["DESIGNATIONNAME"].ToString();
            lblVacName.Text = _dt.Rows[0]["Name"].ToString();
            lblLocation.Text = _dt.Rows[0]["BRANCH_NAME"].ToString();
            lblNoofVac.Text = _dt.Rows[0]["COUNT"].ToString();
            lblCreateDate.Text = Convert.ToDateTime(_dt.Rows[0]["CREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblCreateBy.Text = _dt.Rows[0]["CREATEDBY"].ToString();
            lbl_creName.Text = _dt.Rows[0]["CREATEDBYNAME"].ToString();
            lnkDownload.CommandArgument = _dt.Rows[0]["Path"].ToString();
            lnkDownload.ToolTip = _dt.Rows[0]["FileName"].ToString();
            lblVacStatus.Text = _dt.Rows[0]["VacStatus"].ToString();
            lblClosed.Text = _dt.Rows[0]["CLOSED"].ToString();

            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(_dt.Rows[0]["VAC_ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "VacHistory.aspx?ID=" + writer.ToString() + "";
            HyAppHistory.Attributes.Add("onClick", "javascript:popup('" + url.ToString() + "');");

        }
        // Vaccancy Approval Details
        if (ds.Tables[1].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[1];

            GvAppmaster.DataSource = ds.Tables[1];
            GvAppmaster.DataBind();

            lblAppStatus.Text = ds.Tables[0].Rows[0]["AppStatusName"].ToString();
        }

        // Vaccancy All Candidate list
        if (ds.Tables[2].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[2];

            GvUploadedResume.DataSource = _dt;
            GvUploadedResume.DataBind();
        }
        else
        {
            GvUploadedResume.DataSource = _dtEmpty;
            GvUploadedResume.DataBind();
        }

        // Vaccancy Shortlisted Candidate list
        if (ds.Tables[3].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[3];

            GvShortlistResume.DataSource = _dt;
            GvShortlistResume.DataBind();
        }
        else
        {
            GvShortlistResume.DataSource = _dtEmpty;
            GvShortlistResume.DataBind();
        }

        // Vaccancy Rejected Candidate list
        if (ds.Tables[4].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[4];

            GvRejectedResume.DataSource = _dt;
            GvRejectedResume.DataBind();
        }
        else
        {
            GvRejectedResume.DataSource = _dtEmpty;
            GvRejectedResume.DataBind();
        }

        if (ds.Tables[5].Rows.Count > 0) /// In case approved and publish and Assign HR not set
        {
            DataTable _dt = ds.Tables[5];

            GvHRExecutive.DataSource = _dt;
            GvHRExecutive.DataBind();
        }
        else
        {
            GvHRExecutive.DataSource = _dtEmpty;
            GvHRExecutive.DataBind();
        }

        EnableDisableButtons(ds);
    }

    protected void EnableDisableButtons(DataSet _ds)
    {
        DivCandidate.Visible = false;
        DivApproverAction.Visible = false;
        btnEdit.Visible = false;
        btnApprove.Visible = false;
        btnreject.Visible = false;
        btnClarification.Visible = false;
        btnPublish.Visible = false;
        DivEmployee.Visible = false;

        if (string.Compare(_ds.Tables[0].Rows[0]["AppStatus"].ToString(), "1") == 0) /// in case pending Only, rest 
        {
            /// If user is approver
            foreach (DataRow _dr in ds.Tables[1].Rows)
            {
                if (string.Compare(_dr["APPROVER"].ToString(), Session["EmpCode"].ToString()) == 0 && string.Compare(_dr["CurrLevel"].ToString(), "True") == 0)
                {
                    if (string.Compare(ds.Tables[0].Rows[0]["CreatedBy"].ToString(), Session["EmpCode"].ToString()) == 0) // If user initiator
                    {
                        DivApproverAction.Visible = true;
                        btnEdit.Visible = true;
                        btnApprove.Visible = true;
                        btnreject.Visible = true;
                        btnApprove.Text = "Submit";
                    }
                    else // If user is not initiator
                    {
                        DivApproverAction.Visible = true;
                        btnEdit.Visible = true;
                        btnApprove.Visible = true;
                        btnreject.Visible = true;
                        btnClarification.Visible = true;
                    }
                }
            }
        }
        if (string.Compare(_ds.Tables[0].Rows[0]["AppStatus"].ToString(), "2") == 0) /// in case Approved Only, rest 
        {
            if (string.Compare(Session["Role"].ToString(), "3") == 0) // HR Head
            {
                if (string.Compare(_ds.Tables[0].Rows[0]["VacStatusID"].ToString(), "3") == 0) /// In case approved and unpublish
                {
                    DivApproverAction.Visible = true;
                    btnPublish.Visible = true;
                }
            }
            if (string.Compare(_ds.Tables[0].Rows[0]["VacStatusID"].ToString(), "2") == 0 || string.Compare(_ds.Tables[0].Rows[0]["VacStatusID"].ToString(), "5") == 0) /// In case approved and publish and candidate uploads
            {
                DivCandidate.Visible = true;
            }
        }

        if (Request.QueryString["Type"] != null)
        {
            // If login user is Employee come from main page open vacancy link
            if (string.Compare(Request.QueryString["Type"].ToString(), "EMP") == 0)
            {
                ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("CPP1");
                LinkButton btnBack = (LinkButton)mpContentPlaceHolder.FindControl("btnBack");

                btnBack.PostBackUrl = "~/Main.aspx";

                DivEmployee.Visible = true;
                Vac_ApprovalInfo.Visible = false;
                DivApproverAction.Visible = false;
                DivCandidate.Visible = false;
            }
        }
    }

    protected void GvHRExecutive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());

        }
    }

    protected void InterviewScheduleList()
    {
        //ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, "usp_InterviewSchedule", ViewState["ID"].ToString());
        //GvinterviewSchedule.DataSource = ds;
        //GvinterviewSchedule.DataBind();
    }

    protected void GvUploadedResume_DownloadFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        filePath = "~/UploadedResume/" + filePath;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }

    protected void GvAppmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            if (!string.IsNullOrEmpty(lblDate.Text))
                lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());
        }
    }

    protected void GvUploadedResume_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            Label lbCAN_ID = (Label)e.Row.FindControl("lbCAN_ID");
            Label lblAppDate = (Label)e.Row.FindControl("lblAppDate");
            if (!string.IsNullOrEmpty(lblAppDate.Text))
                lblAppDate.Text = Convert.ToDateTime(lblAppDate.Text).ToString(General.DateFormatRecruitment());


            #region // Details
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lbCAN_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "";

            lnkView.PostBackUrl = url;
            #endregion
        }
    }

    protected void GvShortlistResume_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            Label lbCAN_ID = (Label)e.Row.FindControl("lbCAN_ID");
            Label lblAppDate = (Label)e.Row.FindControl("lblAppDate");
            if (!string.IsNullOrEmpty(lblAppDate.Text))
                lblAppDate.Text = Convert.ToDateTime(lblAppDate.Text).ToString(General.DateFormatRecruitment());

            #region // Details
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lbCAN_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "";

            lnkView.PostBackUrl = url;
            #endregion
        }
    }

    protected void GvRejectedResume_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            Label lbCAN_ID = (Label)e.Row.FindControl("lbCAN_ID");
            Label lblAppDate = (Label)e.Row.FindControl("lblAppDate");
            if (!string.IsNullOrEmpty(lblAppDate.Text))
                lblAppDate.Text = Convert.ToDateTime(lblAppDate.Text).ToString(General.DateFormatRecruitment());

            #region // Details
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lbCAN_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "";

            lnkView.PostBackUrl = url;
            #endregion
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        string fileName = (sender as LinkButton).ToolTip;
        Response.ContentType = "application/octet-stream ";
        Response.Clear();
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "\"" + fileName + "\""); //Response.AddHeader("Content-Disposition", "attachment;filename=9699Latin.docx");
        Response.TransmitFile(filePath);
        Response.End();
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.Vac_StatusID = 2;
        ObjVacENT.Remarks = txtComment.Text.Trim();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        SendMail("Approve");

        string _Result = ObjVacBusiness.Update_VacAppStatus(ObjVacENT);

        if (string.Compare(_Result, "1") == 0)
        {
            General.Alert("Vaccancy Approved Successfully", btnApprove);
            VacDetails();
        }
    }

    protected void btnreject_Click(object sender, EventArgs e)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.Vac_StatusID = 3;
        ObjVacENT.Remarks = txtComment.Text.Trim();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        SendMail("Reject");

        string _Result = ObjVacBusiness.Update_VacAppStatus(ObjVacENT);

        if (string.Compare(_Result, "1") == 0)
        {
            General.Alert("Vaccancy Rejected Successfully", btnreject);
            VacDetails();
        }
    }

    protected void btnClarification_Click(object sender, EventArgs e)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.Vac_StatusID = 4;
        ObjVacENT.Remarks = txtComment.Text.Trim();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        SendMail("SBC");

        string _Result = ObjVacBusiness.Update_VacAppStatus(ObjVacENT);

        if (string.Compare(_Result, "1") == 0)
        {
            General.Alert("Vaccancy sent back for clarification", btnClarification);
            VacDetails();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "VacEdit.aspx?ID=" + writer.ToString() + "";

        Response.Redirect(url);
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        DataSet _ds = (DataSet)ViewState["ds"];

        if (_ds.Tables[5].Rows.Count > 0)
        {
            VacENT ObjVacENT = new VacENT();
            VacBusiness ObjVacBusiness = new VacBusiness();

            ObjVacENT.Vac_ID = ViewState["ID"].ToString();
            ObjVacENT.Vac_StatusID = 2;
            ObjVacENT.Remarks = txtComment.Text.Trim();
            ObjVacENT.EmpCode = Session["EmpCode"].ToString();

            SendMail("Publish");

            string _Result = ObjVacBusiness.Update_VacStatus(ObjVacENT);

            if (string.Compare(_Result, "1") == 0)
            {
                General.Alert("Vaccancy publish Successfully", btnPublish);
                VacDetails();
            }
        }
        else
        {
            General.Alert("Please Assign HR first", this);
            return;
        }
    }

    protected void btnCanCreate_Click(object sender, EventArgs e)
    {

    }

    protected void SendMail(string Status)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

        DataTable dt = ds.Tables[1];

        string subInitator = string.Empty;
        string subRM = string.Empty;
        string subHC = string.Empty;
        string subCOO = string.Empty;
        string AppLevel = string.Empty;
        string vacID = string.Empty;
        string ApproverName = string.Empty;

        DataRow[] _dr = ds.Tables[1].Select(" CurrLevel = 1 ");

        if (_dr.Length > 0)
        {
            AppLevel = _dr[0]["AppLevel"].ToString();
            ApproverName = _dr[0]["APPROVERNAME"].ToString();
        }

        vacID = ViewState["ID"].ToString();

        StringBuilder builder = new StringBuilder();
        MailScript mail = new MailScript();

        string table = "<br/><br/><table width='100%'><tr><td width='20%'>Vacancy Code</td><td  width='80%'>" + vacID + "</td></tr><tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr>" +
            "<tr><td>Location</td><td>" + ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString() + "</td></tr><tr><td>No Of Positions</td><td>" + ds.Tables[0].Rows[0]["Count"].ToString() + "</td></tr>" +
            "<tr><td>Required Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Req_Date"]).ToString(General.DateFormatRecruitment()) + "</td></tr><tr><td>Remarks</td><td>" + ds.Tables[0].Rows[0]["Remarks"].ToString() + "<br /><br /><br /></td></tr></table>" +
            "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

        #region Approve
        if (Status == "Approve")
        {
            #region MailtoInitator
            subInitator = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been approved by " + ApproverName + ". The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[1].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            if (AppLevel == "1") /// approve by Initiator
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy for approval  ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> There is a new vacancy has been waiting for your approval. The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion
            }
            if (AppLevel == "2") /// approve by RM
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been approved. The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy for approval ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> There is a new vacancy has been waiting for your approval. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO

                    subCOO = "Vacancy Notification – Vacancy for approval ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> There is a new vacancy has been waiting for your approval. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
            if (AppLevel == "3") // approve by HC
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been approved by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been approved. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion

                    #region MailtoCOO

                    subCOO = "Vacancy Notification – Vacancy for approval ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> There is a new vacancy has been waiting for your approval. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[3]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO
                    subCOO = "Vacancy Notification – Vacancy approved ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been approved. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
            if (AppLevel == "4") // Approve by COO
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been approved by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy Approve ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been approved. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO
                    subCOO = "Vacancy Notification – Vacancy approved ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been approved. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
        }
        #endregion

        #region Reject
        if (Status == "Reject")
        {
            #region MailtoInitator
            subInitator = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been rejected by " + ApproverName + ". The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[1].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            if (AppLevel == "2") /// Rejected by RM
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been rejected. The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

            }
            if (AppLevel == "3") /// Rejected by HC
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been rejected by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                #region MailtoHC
                subHC = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been rejected. The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                #endregion

            }
            if (AppLevel == "4") // Rejected by COO
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been rejected by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been rejected. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO

                    subCOO = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been rejected. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
        }
        #endregion

        #region SBC
        if (Status == "SBC")
        {
            #region MailtoInitator
            subInitator = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been Sent back for clarification by " + ApproverName + ". The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[1].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            if (AppLevel == "2") /// Sent back for clarification by RM
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been Sent back for clarification. The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

            }
            if (AppLevel == "3") /// Sent back for clarification by HC
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been Sent back for clarification by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";

                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been Sent back for clarification. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO
                    subCOO = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been sent back for clarification. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
            if (AppLevel == "4") // Sent back for clarification by COO
            {
                #region MailtoRM
                subRM = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";

                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br /> Vacancy has been sent back for clarification by " + ApproverName + ". The details are below: ");
                builder.Append(table);

                mail.sendMailWithFormat(ds.Tables[1].Rows[1]["email_id"].ToString(), subRM, builder.ToString(), null, null);
                #endregion

                if (ds.Tables[1].Rows.Count == 4)
                {
                    #region MailtoHC
                    subHC = "Vacancy Notification – Vacancy Reject ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been sent back for clarification. The details are below: ");
                    builder.Append(table);

                    mail.sendMailWithFormat(dt.Rows[2]["email_id"].ToString(), subHC, builder.ToString(), null, null);
                    #endregion
                }
                else
                {
                    #region MailtoCOO
                    subCOO = "Vacancy Notification – Vacancy Sent back for clarification ( Reference Code : " + vacID + " ) ";
                    builder.Clear();
                    builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                    "Dear Approver,<br /><br /> Vacancy has been sent back for clarification. The details are below: ");
                    builder.Append(table);
                    mail.sendMailWithFormat(dt.Rows[3]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
                    #endregion
                }
            }
        }
        #endregion

        #region Publish
        if (Status == "Publish")
        {
            #region MailtoInitator
            subInitator = "Vacancy Notification – Vacancy publish ( Reference Code : " + vacID + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been publish. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[1].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            #region MailtoHRHead
            string subHRHead = "Vacancy Notification – Vacancy publish ( Reference Code : " + vacID + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been publish. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[6].Rows[0]["email_id"].ToString(), subHRHead, builder.ToString(), null, null);
            #endregion

            #region MailtoCOO
            subCOO = "Vacancy Notification – Vacancy publish ( Reference Code : " + vacID + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br /> Vacancy has been publish. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[7].Rows[0]["email_id"].ToString(), subCOO, builder.ToString(), null, null);
            #endregion

            #region MailtoHR  
            subRM = "Vacancy Notification – Vacancy publish ( Reference Code : " + vacID + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear Approver,<br /><br /> Vacancy has been publish. The details are below: ");
            builder.Append(table);
            foreach (DataRow _drow in ds.Tables[5].Rows)
            {
                mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
            }
            #endregion

        }
        #endregion
    }
}
