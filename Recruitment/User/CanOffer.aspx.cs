using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using QueryStringEncryption;

public partial class Recruitment_User_CanOffer : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["EmpCode"])))
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }
            if (Request.QueryString["E"] != null)
            {
                ViewState["Edit"] = Request.QueryString["E"].ToString();
            }
            else
            {
                ViewState["Edit"] = "";
            }

            _FillControls();
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();
        BindDropDowns(ddlTemplate, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Templatemaster"), "ID", "Name");
        BindDropDowns(ddlCompany, _ObjCommonBAL.BindDropDowns("", "Company"), "companyid", "companyname");


        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        lblCanID.Text = ds.Tables[0].Rows[0]["Can_ID"].ToString();
        lblCanName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();

        btnEdit.Visible = false;
        btnDownload.Visible = false;

        if (string.Compare(ViewState["Edit"].ToString(), "True") == 0)
        {
            btnEdit.Visible = true;
            btnDownload.Visible = true;
            btnSave.Visible = false;

            CanOfferENT ObjCanOfferENT = new CanOfferENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjCanOfferENT.Can_ID = ViewState["ID"].ToString();
            ObjCanOfferENT.EmpCode = Session["EmpCode"].ToString();

            DataSet _ds = ObjRoundBusiness.Select_OfferLetter(ObjCanOfferENT);

            txtTerms.Text = _ds.Tables[0].Rows[0]["Dsca"].ToString();

        }
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void ddlCompany_DataBound(object sender, EventArgs e)
    {
        ddlCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select Company---", "0"));
    }
    protected void ddlTemplate_DataBound(object sender, EventArgs e)
    {
        ddlTemplate.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select Template---", "0"));
    }

    protected void _Save()
    {
        CanOfferENT ObjCanOfferENT = new CanOfferENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjCanOfferENT.Can_ID = ViewState["ID"].ToString();
        ObjCanOfferENT.Dsca = txtTerms.Text.Trim();
        ObjCanOfferENT.CompanyID = ddlCompany.SelectedValue.ToString();
        ObjCanOfferENT.EmpCode = Session["EmpCode"].ToString();

        if (string.Compare(ObjRoundBusiness.Create_OfferLetter(ObjCanOfferENT).ToString(), "1") == 0)
        {
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(ViewState["ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "&Type=HRE";

            General.Alert("Offer Letter Created Successfully", this, url);
        }
    }

    protected void _Edit()
    {
        CanOfferENT ObjCanOfferENT = new CanOfferENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjCanOfferENT.Can_ID = ViewState["ID"].ToString();
        ObjCanOfferENT.Dsca = txtTerms.Text.Trim();
        ObjCanOfferENT.EmpCode = Session["EmpCode"].ToString();

        if (string.Compare(ObjRoundBusiness.Update_OfferLetter(ObjCanOfferENT).ToString(), "1") == 0)
        {
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(ViewState["ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "&Type=HRE";

            General.Alert("Offer Letter Updated Successfully", this, url);
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

        if (chkheader.Checked == true)
            _SetHeaderFooter(writer, pdfDoc);

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=OfferLetter.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        _Save();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        _Edit();
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        _DownloadLetter();
    }

    

    protected void _SetHeaderFooter(PdfWriter writer, Document doc)
    {
        CompanyBussiness objSelectALL = new CompanyBussiness();
        CompanyENT userEntity = new CompanyENT();

        userEntity.Companyid = Convert.ToInt32(ddlCompany.SelectedValue.ToString());
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

    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }

    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTemplate.SelectedIndex != 0)
        {
            CanOfferENT ObjCanOfferENT = new CanOfferENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjCanOfferENT.ID = ddlTemplate.SelectedValue.ToString();
            ObjCanOfferENT.Name = "";
            ObjCanOfferENT.EmpCode = Session["EmpCode"].ToString();

            DataSet ds = ObjRoundBusiness.Select_OfferMaster(ObjCanOfferENT);

            txtTerms.Text = ds.Tables[0].Rows[0]["Dsca"].ToString();

        }
    }
}

