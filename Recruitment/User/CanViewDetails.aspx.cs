using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QueryStringEncryption;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;

public partial class Recruitment_User_ViewCanAdvanceDetail : System.Web.UI.Page
{
    static DataSet ds = new DataSet();
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
            if (Request.QueryString["Type"] != null)
            {
                ViewState["Type"] = Request.QueryString["Type"].ToString();
            }
            else
                ViewState["Type"] = "";

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
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblVacId.Text = _dt.Rows[0]["VAC_ID"].ToString();
            lblTitle.Text = _dt.Rows[0]["DESIGNATIONNAME"].ToString();
            lblVacName.Text = _dt.Rows[0]["Name"].ToString();
            lblLocation.Text = _dt.Rows[0]["BRANCH_NAME"].ToString();
            lblNoofVac.Text = _dt.Rows[0]["COUNT"].ToString();
            lblCreateDate.Text = Convert.ToDateTime(_dt.Rows[0]["VCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblCreateBy.Text = _dt.Rows[0]["VCREATEDBY"].ToString();
            lbl_creName.Text = _dt.Rows[0]["VCREATEDBYNAME"].ToString();
            lblVacStatus.Text = _dt.Rows[0]["VacStatus"].ToString();
            lblClosed.Text = _dt.Rows[0]["CLOSED"].ToString();
            lnkDownloadVac.CommandArgument = _dt.Rows[0]["VPath"].ToString();
            lnkDownloadVac.ToolTip = _dt.Rows[0]["VFileName"].ToString();

            lblCanId.Text = _dt.Rows[0]["Can_ID"].ToString();
            lblName.Text = _dt.Rows[0]["CandidateName"].ToString();
            lblEmail.Text = _dt.Rows[0]["Email_Id"].ToString();
            lblContactno.Text = _dt.Rows[0]["Contact_No"].ToString();
            lblapplicationdate.Text = Convert.ToDateTime(_dt.Rows[0]["ApplicationDate"].ToString()).ToString(General.DateFormatRecruitment());
            lblkeywords.Text = _dt.Rows[0]["MetaKeyWord"].ToString();
            lblCCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblRemarks.Text = _dt.Rows[0]["Remarks"].ToString();
            lblCCreatedBy.Text = _dt.Rows[0]["CCREATEDBYNAME"].ToString();
            lblCanStatus.Text = _dt.Rows[0]["CStatusName"].ToString();
            lnkDownloadCan.CommandArgument = _dt.Rows[0]["CPath"].ToString();
            lnkDownloadCan.ToolTip = _dt.Rows[0]["CFileName"].ToString();

            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(ViewState["ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanHistory.aspx?ID=" + writer.ToString() + "";
            HyAppHistory.Attributes.Add("onClick", "javascript:popup('" + url.ToString() + "');");

            CommonBusiness _ObjCommonBAL = new CommonBusiness();
            BindDropDowns(ddlAction, _ObjCommonBAL.BindDropDowns_Recruitment(_dt.Rows[0]["Can_ID"].ToString(), "CanAction"), "ID", "Dsca");

            if (string.Compare(_dt.Rows[0]["Can_StatusID"].ToString(), "10") == 0) // Offer 
            {
                ddlAction.Items[1].Text = "Offer Rejected";
            }

            if (string.Compare(_dt.Rows[0]["Can_StatusID"].ToString(), "11") == 0) // Offer 
            {
                ddlAction.Items[1].Text = "Not Joined";
            }
        
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[1];
            GvPanelFinal.DataSource = _dt;
            GvPanelFinal.DataBind();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[2];
            GvRoundSch.DataSource = _dt;
            GvRoundSch.DataBind();
        }
        EnableDisableButtons(ds);
    }

    protected void lnkRP_Click(object sender, EventArgs e)
    {
        DivRP.Style["display"] = "block";
        DivRPR.Style["display"] = "none";

        lnkRP.Style["background-color"] = Ebackground_color;
        lnkRP.Style["color"] = Ecolor;
        lnkRPR.Style["background-color"] = Dbackground_color;
        lnkRPR.Style["color"] = Dcolor;
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }
    protected void lnkRPR_Click(object sender, EventArgs e)
    {
        DivRP.Style["display"] = "none";
        DivRPR.Style["display"] = "block";

        lnkRP.Style["background-color"] = Dbackground_color;
        lnkRP.Style["color"] = Dcolor;
        lnkRPR.Style["background-color"] = Ebackground_color;
        lnkRPR.Style["color"] = Ecolor;
    }

    protected void EnableDisableButtons(DataSet _ds)
    {
        btnEdit.Visible = false;
        DivActions.Visible = false;
        btnRounds.Visible = false;
        btnEditRound.Visible = false;
        DivActions.Visible = false;
        DivHRActions.Visible = false;
        ddlAction.Visible = false;
        btnSubmit.Visible = false;
        DivRoundInfo.Visible = false;
        btnOfferLtr.Visible = false;
        btnEditOfferLtr.Visible = false;
        lblOletter.Visible = false;
        lnkDownloadOLetter.Visible = false;

        if (string.Compare(_ds.Tables[0].Rows[0]["VACSTATUSID"].ToString(), "5") != 0) // If Vacancy is closed
        {
            if (string.Compare(_ds.Tables[0].Rows[0]["VCREATEDBY"].ToString(), Session["EmpCode"].ToString()) == 0 && (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "1") == 0 || string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "2") == 0)) /// in case Login user is Initiator
            {
                // Open and login user is initiator 
                DivActions.Visible = true;
            }
            if (string.Compare(ViewState["Type"].ToString(), "HRE") == 0) /// in case Login user is HRExecutive
            {
                DivHRActions.Visible = true;

                // login user is HR Executive And Status is Open
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "1") == 0)
                    btnEdit.Visible = true;

                // login user is HR Executive And Status is Shortlisted
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "2") == 0)
                {
                    btnRounds.Visible = true;
                }
                // login user is HR Executive And Status is Interview in process
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "3") == 0)
                    btnEditRound.Visible = true;

                // login user is HR Executive And Status after Interview in process Completed
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "4") == 0)
                {
                    ddlAction.Visible = true;
                    btnSubmit.Visible = true;
                    btnEditRound.Visible = true;
                }

                // login user is HR Executive And Status after Interview in process Completed
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "4") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "5") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "6") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "7") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "9") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "10") == 0 ||
                    string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "11") == 0)
                {
                    ddlAction.Visible = true;
                    btnSubmit.Visible = true;
                }

                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "5") == 0 && string.Compare(_ds.Tables[0].Rows[0]["IsOffer"].ToString(), "False") == 0)
                {
                    btnOfferLtr.Visible = true;
                }
                if (string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "10") == 0)
                {
                    btnEditOfferLtr.Visible = true;
                }
                if (string.Compare(_ds.Tables[0].Rows[0]["IsRound"].ToString(), "True") == 0 && string.Compare(_ds.Tables[0].Rows[0]["Can_StatusID"].ToString(), "4") == 0)
                {
                    DivHRActions.Visible = true;
                }
            }
        }

        if (string.Compare(_ds.Tables[0].Rows[0]["IsOffer"].ToString(), "True") == 0)
        {
            lblOletter.Visible = true;
            lnkDownloadOLetter.Visible = true;
        }

        if (string.Compare(_ds.Tables[0].Rows[0]["IsRound"].ToString(), "True") == 0)
        {
            DivRoundInfo.Visible = true;

            DivRP.Style["display"] = "block";
            DivRPR.Style["display"] = "none";
            lnkRP.Style["background-color"] = Ebackground_color;
            lnkRP.Style["color"] = Ecolor;
            lnkRPR.Style["background-color"] = Dbackground_color;
            lnkRPR.Style["color"] = Dcolor;
        }
    }

    protected void ddlAction_DataBound(object sender, EventArgs e)
    {
        ddlAction.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select Action---", "0"));
    }

    protected void lnkDownloadOLetter_Click(object sender, EventArgs e)
    {
        _DownloadLetter();
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

    protected void btnShortList_Click(object sender, EventArgs e)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.CanStatusID = 2;
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();
        ObjCanENT.Remarks = txtComments.Text.Trim();

        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "ViewCanRequest.aspx?Type=C";

        if (string.Compare(ObjCanBusiness.Update_CanStatus(ObjCanENT), "1") == 0)
        {
            SendMail("ShortList");

            General.Alert("Candidate has been shortlisted", this, url);
        }
        else
        {
            General.Alert("Operational Error", this);
            return;
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.CanStatusID = 6;
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();
        ObjCanENT.Remarks = txtComments.Text.Trim();

        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "ViewCanRequest.aspx?Type=C";

        if (string.Compare(ObjCanBusiness.Update_CanStatus(ObjCanENT), "1") == 0)
        {
            SendMail("Reject");
            General.Alert("Candidate has been rejected", this, url);
        }
        else
        {
            General.Alert("Operational Error", this);
            return;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanEdit.aspx?ID=" + writer.ToString() + "";

        Response.Redirect(url);
    }

    protected void btnOfferLtr_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanOffer.aspx?ID=" + writer.ToString() + "&E=False";

        Response.Redirect(url);
    }

    protected void btnEditOfferLtr_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanOffer.aspx?ID=" + writer.ToString() + "&E=True";

        Response.Redirect(url);
    }

    protected void btnRounds_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanCreateRound.aspx?ID=" + writer.ToString() + "&E=False";

        Response.Redirect(url);
    }

    protected void btnEditRound_Click(object sender, EventArgs e)
    {
        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanCreateRound.aspx?ID=" + writer.ToString() + "&E=True";

        Response.Redirect(url);
    }

    protected void GvRoundSch_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            Label lblTime = (Label)e.Row.FindControl("lblTime");
            Label lblCurRound = (Label)e.Row.FindControl("lblCurRound");
            
            lblTime.Text = Convert.ToDateTime(lblDate.Text).ToString("t");
            lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());
        }
    }

    protected void GvPanelFinal_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk_Eval = (LinkButton)e.Row.FindControl("lnk_Eval");
            LinkButton lnk_EvalView = (LinkButton)e.Row.FindControl("lnk_EvalView");
            Label lblRoundCode = (Label)e.Row.FindControl("lblRoundCode");
            Label lblIsFeedback = (Label)e.Row.FindControl("lblIsFeedback");
            Label lblFeedback = (Label)e.Row.FindControl("lblFeedback");
            Label lblCurRound = (Label)e.Row.FindControl("lblCurRound");
            Label lblEmpCode = (Label)e.Row.FindControl("lblEmpCode");

            Cryptography objEnc = new Cryptography();
            /// Candidate ID
            string key = objEnc.Encrypt(ViewState["ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);
            // Round ID
            string key1 = objEnc.Encrypt(lblRoundCode.Text);
            StringWriter writer1 = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key1, writer1);
            // EmpCode
            string key2 = objEnc.Encrypt(lblEmpCode.Text);
            StringWriter writer2 = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key2, writer2);

            string url = "CanEval.aspx?ID=" + writer.ToString() + "&RID=" + writer1.ToString();

            lnk_Eval.PostBackUrl = url;

            url = "CanViewEval.aspx?ID=" + writer.ToString() + "&RID=" + writer1.ToString() + "&EMP=" + writer2.ToString();

            lnk_EvalView.Attributes.Add("onClick", "javascript:popup('" + url.ToString() + "');");

            if (string.Compare(lblEmpCode.Text, Session["EmpCode"].ToString()) == 0 && string.Compare(lblCurRound.Text, "True") == 0)
                lnk_Eval.Visible = true;
            else
                lnk_Eval.Visible = false;

            if (string.Compare(lblFeedback.Text, "True") == 0)
            {
                lnk_Eval.Visible = false;

                // Visible to only related employee, COO and HC Admin,,,,,, rest users not able to watch
                if (string.Compare(lblEmpCode.Text, Session["EmpCode"].ToString()) == 0 || string.Compare(Session["Role"].ToString(), "5") == 0 || string.Compare(Session["Role"].ToString(), "3") == 0)
                    lnk_EvalView.Visible = true;
                else
                    lnk_EvalView.Visible = false;
            }
            else
                lnk_EvalView.Visible = false;


            // use this at last of section
            if (string.Compare(lblIsFeedback.Text, "True") == 0)
                lblIsFeedback.Text = "Mandatory";
            else
                lblIsFeedback.Text = "Optional";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.CanStatusID = Convert.ToInt32(ddlAction.SelectedValue);
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();
        ObjCanENT.Remarks = txtComments.Text.Trim();

        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(ViewState["ID"].ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "&Type=HRE";

        if (string.Compare(ObjCanBusiness.Update_CanStatus(ObjCanENT), "1") == 0)
        {
            if (ddlAction.SelectedValue == "11") // Offer Accepted
            {
                SendMail("Accepted");
            }

            General.Alert("Candidate has been updated", this, url);
        }
        else
        {
            General.Alert("Operational Error", this);
            return;
        }
    }

    protected void _DownloadLetter()
    {
        CanOfferENT ObjCanOfferENT = new CanOfferENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjCanOfferENT.Can_ID = ViewState["ID"].ToString();
        ObjCanOfferENT.EmpCode = Session["EmpCode"].ToString();

        DataSet _ds = ObjRoundBusiness.Select_OfferLetter(ObjCanOfferENT);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        dv_text.InnerHtml = _ds.Tables[0].Rows[0]["dsca"].ToString();
        dv_text.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 54, 54, 54, 90);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();

        _SetHeaderFooter(writer, pdfDoc, Convert.ToInt32(_ds.Tables[0].Rows[0]["CompanyID"].ToString()));

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=OfferLetter.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void _SetHeaderFooter(PdfWriter writer, Document doc, int CompanyId)
    {
        CompanyBussiness objSelectALL = new CompanyBussiness();
        CompanyENT userEntity = new CompanyENT();

        userEntity.Companyid = CompanyId;
        userEntity.EmployeeCode = "";
        userEntity.Companyname = "";
        userEntity.Resp_person = "";
        userEntity.Corp_add1 = "";
        userEntity.Pageindex = 0;
        userEntity.PageSize = 0;
        userEntity.SortBy = "companyname";

        DataSet ds = objSelectALL.FetchCompanyCustom(userEntity);
        ds.Tables[0].Rows[0]["logo"].ToString();

        Rectangle page = doc.PageSize;
        string path = "../../images/" + ds.Tables[0].Rows[0]["logo"].ToString() + "";
        String Imgpath = HttpContext.Current.Server.MapPath(path);
        // Step 2 - create two column table;
        PdfPTable head = new PdfPTable(1);
        head.TotalWidth = page.Width / 4;

        // add header image; PdfPCell() overload sizes image to fit cell
        PdfPCell imghead = new PdfPCell(iTextSharp.text.Image.GetInstance(Imgpath), true);
        imghead.HorizontalAlignment = Element.ALIGN_RIGHT;
        imghead.Border = Rectangle.NO_BORDER;
        head.AddCell(imghead);

        // write (write) table to PDF document;
        // WriteSelectedRows() requires you to specify absolute position!
        head.WriteSelectedRows(0, -1, 400, page.Height - doc.TopMargin + head.TotalHeight, writer.DirectContent);

        string F1 = ds.Tables[0].Rows[0]["companyname"].ToString();
        string F2 = ds.Tables[0].Rows[0]["corp_add1"].ToString() + " " + ds.Tables[0].Rows[0]["corp_add2"].ToString() + " ," + ds.Tables[0].Rows[0]["corp_city"].ToString() + " ," + ds.Tables[0].Rows[0]["corp_state"].ToString();
        string F3 = "Phone: " + ds.Tables[0].Rows[0]["corp_phone"].ToString() + " URL:" + ds.Tables[0].Rows[0]["url"].ToString() + " CIN:" + ds.Tables[0].Rows[0]["reg_no"].ToString();

        Paragraph footer = new Paragraph(F1, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
        Paragraph footer1 = new Paragraph(F2, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
        Paragraph footer2 = new Paragraph(F3, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));

        footer.Alignment = Element.ALIGN_CENTER;
        PdfPTable footerTbl = new PdfPTable(1);
        footerTbl.TotalWidth = 500;
        footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cell = new PdfPCell(footer);
        cell.Border = 0;
        cell.PaddingLeft = 1;
        footerTbl.AddCell(cell);

        PdfPCell cell1 = new PdfPCell(footer1);
        cell1.Border = 0;
        cell1.PaddingLeft = 1;
        footerTbl.AddCell(cell1);

        PdfPCell cell2 = new PdfPCell(footer2);
        cell2.Border = 0;
        cell2.PaddingLeft = 1;
        footerTbl.AddCell(cell2);

        footerTbl.WriteSelectedRows(0, -1, 72, 54, writer.DirectContent);
    }

    protected void SendMail(string  StrAction)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
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

        if (StrAction == "ShortList")
        {
            #region MailtoInitator
            subInitator = "Candidate Notification – Candidate Shortlisted( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br />Candidate has been shortlisted for interview. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            #region MailtoHR
            subRM = "Candidate Notification – Candidate Shortlisted ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear Approver,<br /><br />Candidate has been shortlisted for interview. The details are below: ");
            builder.Append(table);
            foreach (DataRow _drow in ds.Tables[4].Rows)
            {
                mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
            }
            #endregion
        }
        if (StrAction == "Reject")
        {
            #region MailtoInitator
            subInitator = "Candidate Notification – Candidate for rejected ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br />Candidate has been rejected. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            #region MailtoHR
            subRM = "Candidate Notification – Candidate rejected ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear Approver,<br /><br />Candidate has been rejected. The details are below: ");
            builder.Append(table);
            foreach (DataRow _drow in ds.Tables[4].Rows)
            {
                mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
            }
            #endregion
        }

        if (StrAction == "Accepted")
        {
            #region MailtoInitator
            subInitator = "Candidate Notification – Candidate has accepted offer ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";

            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br />Candidate has been accepted offer. The details are below: ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            #region MailtoHR
            subRM = "Candidate Notification – Candidate has accepted offer ( Reference Code : " + ds.Tables[0].Rows[0]["CAN_ID"].ToString() + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear Approver,<br /><br />Candidate has been accepted offer. The details are below: ");
            builder.Append(table);
            foreach (DataRow _drow in ds.Tables[4].Rows)
            {
                mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
            }
            #endregion
        }

        
    }
}