using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using querystring;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;


public partial class ForgotPassword : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    public void RaiseCallbackEvent(string eventArgument)
    {
        try
        {
            //Registrations userEntity = new Registrations();
            //userEntity.EmailId = eventArgument.Trim();
            //Registration userBusiness = new Registration();
            //userEntity = userBusiness.UserAuthentication(userEntity);
            //if (userEntity.UserId != -1)
            //{
            //    Mail(userEntity.UserName, userEntity.EmailId, userEntity.UserName);
            //    test = "A mail has been sent on the email id " + eventArgument + ". Follow the instructions in the mail. ";
            //}
            //else
            //{
            //    test = "Email Address not present in the database.";
            //}
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        LoginENT entity = new LoginENT();
        LoginBusiness objBAL = new LoginBusiness();
        entity.EmployeeCode = txtEmpCode.Text.Trim();
        dt = objBAL.SelectEmailId(entity);
        if (dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["EmailId"].ToString()))
            {
              string m =  Mail(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
              General.Alert(m, btnSendMail);
              General.CloseAlertWindow(btnSendMail, "Success");
            }
            else
            {
                General.Alert("Email Address not present in the database.", btnSendMail);
                General.CloseAlertWindow(btnSendMail, "");
            }
        }
        else
        {
            General.Alert("Employee code not present in the database.", btnSendMail);
            General.CloseAlertWindow(btnSendMail, "");
        }

    }

    private string Mail(string toEmail, string username) // Reset Password
    {
        string result = string.Empty;
        SmtpClient smtpClient = new SmtpClient();
        string userName = ConfigurationManager.AppSettings["UserName"].ToString();
        string password = ConfigurationManager.AppSettings["Password"].ToString();

        NetworkCredential basicCredential = new NetworkCredential(userName, password);
        MailMessage message = new MailMessage();
        MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
        smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = basicCredential;
        message.From = fromAddress;
        message.To.Add(toEmail.ToString());
        message.Subject = "Reset Your Password";

        //Set IsBodyHtml to true means you can send HTML email.
        message.IsBodyHtml = true;
       
        StringBuilder ObjStringBuilder = new StringBuilder();

        ObjStringBuilder = ObjStringBuilder.Append("<html><Body>Dear " + username + ", <br> We have received your request to reset your password. <br>Please use this secure URL to reset your password.<br>");
        ObjStringBuilder = ObjStringBuilder.Append(" To reset your password, please enter your new password twice on the page that opens. <br> If you cannot access the link above, you can paste<br> the following address into your browser:<br>");
        ObjStringBuilder = ObjStringBuilder.Append("<a href='#'>Click Here</a> <br>- Admin Team, Acuminous Software Pvt. Ltd<br></Body></html>");
        message.Body = ObjStringBuilder.ToString();
        try
        {
            smtpClient.Send(message);
            result = "A mail has been sent your email id. Follow the instructions in the mail.";
        }
        catch (Exception ex)
        {
            //Error, could not send the message
            Response.Write(ex.Message);
            result = "Mail has not been sent";
        }
        return result;
    }
}