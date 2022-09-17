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

public partial class Recruitment_User_CanOffer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _FillControls();
            VacDetails();
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();

        //BindDropDowns(ddl_jobtitle, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Designation"), "id", "designationname");
        BindDropDowns(ddllocation, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Branch"), "branch_id", "branch_name");

        txtJoinDate.Attributes.Add("readonly", "readonly");
        txtCTC.Attributes.Add("onkeypress", "return numberonly(event);");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }
    //protected void ddljobtitle_DataBound(object sender, EventArgs e)
    //{
    //    ddl_jobtitle.Items.Insert(0, new ListItem("---Select Job Title---", "0"));
    //}
    protected void ddllocation_DataBound(object sender, EventArgs e)
    {
        ddllocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select Job Location---", "0"));
    }
   

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

        if (lbl_txt.Text == "Amrit")
        {
            lbl_txt.Text = txtTerms.Text;
            
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            dv_text.RenderControl(hw);
            
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            Random nxt = new Random();
            string Fname = nxt.Next(0, 10000).ToString() + "Offer.pdf";
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~") + "\\Recruitment\\OfferLetter\\" + Fname + "", FileMode.Create));

            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            return;
        }

        DataSet ds = (DataSet)ViewState["pp"];

        DataRow dr = ds.Tables[0].Rows[0];
        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            Document doc = new Document(PageSize.A4);
            HTMLWorker parser = new HTMLWorker(doc);
            Random nxt = new Random();
            string Fname = nxt.Next(0, 10000).ToString() + "Offer.pdf";
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Server.MapPath("~") + "\\Recruitment\\OfferLetter\\" + Fname + "", FileMode.Create));
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            Color color = null;

            document.Open();

            //Header Table
            table = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.3f });

            //Company Logo
            cell = ImageCell("../../images/Rossel-Techsys-Logo1(1).png", 60f, PdfPCell.ALIGN_RIGHT);
            table.AddCell(cell);

            //Company Name and Address @ Footer
            //phrase = new Phrase();
            //phrase.Add(new Chunk("Acuminous Software\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLACK)));
            //phrase.Add(new Chunk("1st Floor, DCM Building, 16 Barakhambha Road,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //phrase.Add(new Chunk("New Delhi:- 110011,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //phrase.Add(new Chunk("Phone: +91-11-2371 3262, Fax:+91-11-23327512", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            //table.AddCell(cell);

            //Separater Line
            color = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
            DrawLine(writer, 25f, document.Top - 45f, document.PageSize.Width - 25f, document.Top - 45f, color);
            DrawLine(writer, 25f, document.Top - 46f, document.PageSize.Width - 25f, document.Top - 46f, color);
            document.Add(table);

            table = new PdfPTable(1);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SetWidths(new float[] { 0.3f });
            table.SpacingBefore = 20f;

            ////Candidate Details
            cell = PhraseCell(new Phrase("Offer Letter", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)), PdfPCell.ALIGN_CENTER);
            cell.Colspan = 2;
            table.AddCell(cell);
            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            cell.Colspan = 2;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            ////Photo
            //cell = ImageCell(string.Format("~/photos/{0}.jpg", dr["EmployeeId"]), 25f, PdfPCell.ALIGN_CENTER);
            //table.AddCell(cell);

            ////Name
            //phrase = new Phrase();
            //phrase.Add(new Chunk(dr["TitleOfCourtesy"] + " " + dr["FirstName"] + " " + dr["LastName"] + "\n", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)));
            //phrase.Add(new Chunk("(" + dr["Title"].ToString() + ")", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)));
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            //cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            //table.AddCell(cell);
            //document.Add(table);

            //DrawLine(writer, 160f, 80f, 160f, 690f, Color.BLACK);
            //DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, Color.BLACK);

            //table = new PdfPTable(2);
            //table.SetWidths(new float[] { 0.5f, 2f });
            //table.TotalWidth = 340f;
            //table.LockedWidth = true;
            //table.SpacingBefore = 20f;
            //table.HorizontalAlignment = Element.ALIGN_RIGHT;

            ////Employee Id
            //table.AddCell(PhraseCell(new Phrase("Employee code:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //table.AddCell(PhraseCell(new Phrase("000" + dr["EmployeeId"], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            //cell.Colspan = 2;
            //cell.PaddingBottom = 10f;
            //table.AddCell(cell);

            ////Address
            //table.AddCell(PhraseCell(new Phrase("Address:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //phrase = new Phrase(new Chunk(dr["Address"] + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //phrase.Add(new Chunk(dr["City"] + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //phrase.Add(new Chunk(dr["Region"] + " " + dr["Country"] + " " + dr["PostalCode"], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
            //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            //cell.Colspan = 2;
            //cell.PaddingBottom = 10f;
            //table.AddCell(cell);

            ////Date of Birth
            //table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["BirthDate"]).ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            //cell.Colspan = 2;
            //cell.PaddingBottom = 10f;
            //table.AddCell(cell);

            ////Phone
            //table.AddCell(PhraseCell(new Phrase("Phone Number:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //table.AddCell(PhraseCell(new Phrase(dr["HomePhone"] + " Ext: " + dr["Extension"], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            //cell.Colspan = 2;
            //cell.PaddingBottom = 10f;
            //table.AddCell(cell);

            ////Addtional Information
            //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
            table.AddCell(PhraseCell(new Phrase(dr["Remarks"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_JUSTIFIED_ALL));

            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            cell.Colspan = 2;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            StringBuilder strBuilder = new StringBuilder();

            string text = HttpUtility.HtmlDecode(txtTerms.Text.Trim());

            string text_regex = System.Text.RegularExpressions.Regex.Replace(txtTerms.Text, "<!--(\n|.)*-->", string.Empty);

            strBuilder.Append("<html><body><table width='99%' border='1' align='center' cellpadding='0' cellspacing='0' style='border-right:#FFFFFF 1px solid;'>"
              + "<tr>"
              + "<td >" + (text) + "</td>"
              + "</tr></body></html>".ToString());

            table.AddCell(PhraseCell(new Phrase(strBuilder.ToString()), PdfPCell.ALIGN_JUSTIFIED));

            //  document.Add(new iTextSharp.text.Paragraph(txtTerms.Text.Trim()));

            document.Add(table);
            document.AddTitle("Joining Letter");
            document.AddSubject("Joining Letter");
            document.AddKeywords("Joining Letter");
            document.AddCreator("Rossel Techsys");
            document.AddAuthor("Rossel Techsys");
            document.AddHeader("Nothing", "No Header");

            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.ContentType = "application/octet-stream ";
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "\"" + Fname + "\""); //Response.AddHeader("Content-Disposition", "attachment;filename=9699Latin.docx");
            Response.TransmitFile(Server.MapPath("~") + "\\Recruitment\\OfferLetter\\" + Fname + "");
            Response.End();
        }
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

    protected void VacDetails()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = "VAC00014";
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

       DataSet ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

       ViewState["pp"] = ds;

       txtTerms.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
       
    }

}
