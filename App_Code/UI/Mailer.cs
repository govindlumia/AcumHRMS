using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Mail
{
    public class Mailer
    {
        /// <summary>
        /// This function send mail to Admin.
        /// </summary>
        /// <param name="strFromMail">Please leave it blank to use Admin EMail Address</param>
        /// <param name="strToMail">Please leave it blank to use Admin EMail Address</param>
        /// <param name="strSubject">Specify subject line.</param>
        /// <param name="strBody">Specify Email Content / Body part.</param>
        /// <returns>Function returns 1 if successfully sent the mail otherwise returns 0.</returns>

        public Mailer()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static int SendEmail(string strFromMail, string mailTo, string mailSubject, string mailBody)
        {
            try
            {
                if (strFromMail == "")
                {
                    strFromMail = ConfigurationManager.AppSettings["FromAdminEmail"].ToString();
                }
                if (mailTo == "")
                {
                    mailTo = ConfigurationManager.AppSettings["ToAdminEmail"].ToString();
                }
                string strSMTPServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();

                string FromMailCrendential = ConfigurationManager.AppSettings["FromMailCrendential"].ToString();
                string FromMailPassword = ConfigurationManager.AppSettings["FromMailPassword"].ToString();

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(FromMailCrendential, FromMailCrendential);
                message.To.Add(new MailAddress(mailTo));
                message.IsBodyHtml = true;
                message.Subject = mailSubject;
                message.Body = mailBody;
                smtp.Host = strSMTPServer;//"relay-hosting.secureserver.net";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;


                smtp.Credentials = new NetworkCredential(FromMailCrendential, FromMailPassword);
                smtp.Send(message);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return 0;
        }

    }
}

