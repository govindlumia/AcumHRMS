using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Runtime;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection;

/// <summary>
/// Summary description for MailScript
/// </summary>
public class MailScript
{
    public MailScript()
    {

    }
    public bool sendMailWithFormat(string toUser, string subJect, string body, string[] toCC, string[] toBCC)
    {
        try
        {
            if (!string.IsNullOrEmpty(toUser))
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                NetworkCredential basicCredential = new NetworkCredential(userName, password);
                message.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Port = 587;
                smtpClient.Credentials = basicCredential;
                smtpClient.EnableSsl = true;


                message.To.Add(toUser);
                if (toCC != null)
                {
                    for (int i = 0; i < toCC.Length; i++)
                    {
                        message.CC.Add(new MailAddress(toCC[i]));
                    }
                }
                if (toBCC != null)
                {
                    for (int i = 0; i < toBCC.Length; i++)
                    {
                        message.Bcc.Add(new MailAddress(toBCC[i]));
                    }
                }
                message.Bcc.Add(new MailAddress("keerti.dwivedi@acuminous.in","ankit.sharma@acuminous.in"));
                message.Subject = subJect;
                message.Body = body;
                message.IsBodyHtml = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpClient.Send(message);
            }
            else
            {
                return false;
            
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public void exportToExcelInCustomized(DataTable dt, GridViewRow headerrow, string fileName, HtmlForm control, string fileNametosave)
     {
        try
        {
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            Table table_toexport = new Table();
            table_toexport.Style["font-size"] = "10";
            table_toexport.BorderWidth = Unit.Pixel(1);
            table_toexport.BorderColor = System.Drawing.Color.Green;
            table_toexport.GridLines = GridLines.Both;
            Label lbl_data;
            DataTable dt_result = dt;

            row = new TableRow();
            cell1 = new TableCell();
            cell1.Width = Unit.Point(100);
            cell1.Height = Unit.Point(60);
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = "~\\images\\Rossel-Techsys-Logo1(1).png";
            //img.Style["width"] = "100";
            //img.Style["height"] = "60";

            cell1.Controls.Add(img);
            cell2 = new TableCell();
            cell2.Style["text-align"] = "center";
            cell2.Width = Unit.Pixel(700);
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(20);
            lbl_data.Font.Bold = true;
            lbl_data.Text = "Acuminous Software";
            cell2.Controls.Add(lbl_data);
            cell1.RowSpan = 3;
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);
            row = new TableRow();
            cell2 = new TableCell();
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(8);
            lbl_data.Font.Bold = true;
            //lbl_data.Text = "Division of Rossell India Ltd";
            lbl_data.Text = "Acuminous Software Pvt. Ltd";
            cell2.Controls.Add(lbl_data);
            cell2.Style["text-align"] = "center";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);
            row = new TableRow();
            cell2 = new TableCell();
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(7);
            lbl_data.Font.Bold = false;
            //lbl_data.Text = " No.74, 3rd Cross, Export Promotion Industrial Park,Whitefield, BANGALORE - 560 066, Ph: 080-3999 9401";
            lbl_data.Text = "154, Sector 27, Gurugram, Haryana 122009";
            cell2.Controls.Add(lbl_data);
            cell2.Style["text-align"] = "center";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);

            row = new TableRow();
            cell1 = new TableCell();
            cell2 = new TableCell();
            cell1.Text = "Report Date";
            cell2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            cell2.Style["text-align"] = "left";
            row.Cells.Add(cell1);
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);

            table_toexport.Rows.Add(row);

            row = new TableRow();
            cell1 = new TableCell();
            cell2 = new TableCell();
            cell1.Text = "Report Name";
            cell2.Text = fileName;
            cell2.Style["text-align"] = "left";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            table_toexport.Rows.Add(row);
            row = new TableRow();

            foreach (TableCell tc in headerrow.Cells)
            {

                cell1 = new TableCell();
                cell1.BackColor = System.Drawing.Color.Yellow;
                cell1.Text = tc.Text;
                cell1.Style["text-align"] = "center";
                row.Cells.Add(cell1);
            }
            table_toexport.Rows.Add(row);

            foreach (DataRow dr in (dt_result.Rows))
            {
                row = new TableRow();
                for (int i = 0; i < dt_result.Columns.Count; i++)
                {
                    cell1 = new TableCell();
                    cell1.Text = dr[i].ToString();
                    cell1.Style["text-align"] = "center";
                    row.Cells.Add(cell1);
                }
                table_toexport.Rows.Add(row);

            }
            exportToExcelInternalFunc(table_toexport, control, fileNametosave);
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
        }
    }
    private void exportToExcelInternalFunc(object file, HtmlForm cntrl, string fileNametosave)
    {
        HttpContext.Current.Response.Clear();

        HttpContext.Current.Response.Buffer = true;

        //this.EnableViewState = false;

        string attachment = "attachment;   filename=" + fileNametosave + ".xls";

        HttpContext.Current.Response.AddHeader("content-disposition", attachment);

        HttpContext.Current.Response.ContentType = "application/ms-excel";

        System.IO.StringWriter sw = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        HtmlForm frm = new HtmlForm();

        //  cntrl.Parent.Controls.Add(frm);

        cntrl.Controls.Add(frm);
        frm.Attributes["runat"] = "server";

        frm.Controls.Add((Table)file);

        frm.RenderControl(htw);

        string style = @"<style> .textmode { mso-number-format:\@; } img{width:100px;height:60px;} </style>";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write(sw.ToString());

        HttpContext.Current.Response.End();

    }

    public decimal convertInHourMin(decimal val)
    {
        decimal div = 0, mode = 0, hr = 0;
        string total = "0";
        try
        {
            string value = val.ToString();
            string[] splitvalue = value.Split('.');
            if (splitvalue.Length == 2)
            {
                if (Convert.ToInt32(splitvalue[1]) > 60)
                {
                    div = Convert.ToInt32(splitvalue[1]) / 60;
                    mode = Convert.ToInt32(splitvalue[1]) % 60;
                    if (mode > 9)
                    {
                        total = (Convert.ToInt32(splitvalue[0]) + div).ToString() + "." + mode;
                    }
                    else
                    {
                        total = (Convert.ToInt32(splitvalue[0]) + div).ToString() + ".0" + mode;
                    }
                    return Convert.ToDecimal(total);
                }
                else
                {
                    return val;
                }

            }
            else
            {
                return val;
            }

        }
        catch (InvalidCastException ex)
        {
            throw new Exception(ex.Message);
        }

    }

    #region Listtodatable
    //Added for converting list to datatable by keerti for exporting excel on 27 june 2018 
    public DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Defining type of data column gives proper data table 
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name, type);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }
    // upto here by keerti for exporting excel on 27 june 2018
    #endregion

}