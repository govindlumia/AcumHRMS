using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using System.Net.Mail;
using Utilities;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Net;
using System.Collections.Generic;
using System.IO;

public partial class Testing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  bindExcel();
        }
    }

    private void sendMail()
    {
        string ToEmail = "indrajith.ravindran@rosselltechsys.com";
        string userName = ConfigurationManager.AppSettings["UserName"].ToString();
        string password = ConfigurationManager.AppSettings["Password"].ToString();
        NetworkCredential basicCredential = new NetworkCredential(userName, password);
        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();
        MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
        smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Port = 25;
        smtpClient.Credentials = basicCredential;
        message.From = fromAddress;
        smtpClient.EnableSsl = true;
        message.To.Add(ToEmail.ToString());
        message.Bcc.Add("amritmehra227@gmail.com");
        message.Subject = "Leave Notification - Testing ";
        message.IsBodyHtml = true;
        message.Body = " <div runat='server' id='dv_head' style='background-color:Gray;width:500px;height:300px;font: normal 12px Arial, Helvetica, sans-serif;'><h4>Hi, Amrit Mehra</h4><br />Amrit has applied for leave. The leave details are: <table style='width:100%;' runat='server' id='tbl_report'>"+
   " <colgroup><col style='width:35%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' /><col style='width:65%;background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right:none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;' />"+
    "</colgroup><tr><td>From Date</td><td>03-Oct-2014</td> </tr>  <tr> <td>To Date</td>  <td>05-Oct-2014</td></tr><tr><td>Leave Type</td>"+
   "<td>Vacation</td></tr><tr> <td>Reason</td> <td>Not Well</td>   </tr> <tr><td>Remarks</td> <td>Will join as soon as possible.</td>"+
   " </tr></table>    <br />    Thanks,<br />    Acuminous Software<br />This is system generated Mail, do not reply back.    </div>";
        //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
        //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
        //System.Security.Cryptography.X509Certificates.X509Chain chain,
        //System.Net.Security.SslPolicyErrors sslPolicyErrors)
        //    {
        //        return true;
        //    };
        smtpClient.Send(message);
    }


    private void bindExcel()
    {
        Response.Clear();

        Response.Buffer = true;

        this.EnableViewState = false;

        string attachment = "attachment;   filename=yourPageName.xls";

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        HtmlForm frm = new HtmlForm();

        //Table new_tab = new Table();
        //TableRow row1 = new TableRow();
        //TableCell cell1 = new TableCell();
        //cell1.Text = "Hello Amrit";
        //row1.Cells.Add(cell1);
        //new_tab.Rows.Add(row1);

        dv_head.Parent.Controls.Add(frm);

        frm.Attributes["runat"] = "server";

        frm.Controls.Add(tbl_report);

        frm.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End();
    
    }
}