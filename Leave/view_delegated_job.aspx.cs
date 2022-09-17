using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using DataAccessLayer;
using System.Net.Mail;

public partial class Leave_Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else
                Response.Redirect("~/notlogged.aspx");


            bind_requested_del();
        }
    }

    protected void bind_requested_del()
    {
        sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 20);
        sqlparam[0].Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "view_requested_del_jobs", sqlparam);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
   
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reject")
        {
            //int index = Convert.ToInt32(e.CommandArgument);

            //GridViewRow a = ((GridView)e.CommandArgument).Rows[index];

            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            sqlstr = "update tbl_delegation_details set status='3' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            message.InnerHtml = "Leave rights delegation request rejected successfully";

            mailtoapprover(ecode);
        }
        if (e.CommandName == "accept")
        {
            //int index = Convert.ToInt32(e.CommandArgument);

            //GridViewRow a = ((GridView)e.CommandArgument).Rows[index];

            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            sqlstr = "update tbl_delegation_details set status='1' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            message.InnerHtml = "Leave rights delegation request accepted successfully";

            mailtoapprover(ecode);
        }

        bind_requested_del();
    }

    protected void mailtoapprover(string empcode)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            sqlstr = "select lg.EmailId,lg.role,job.emp_fname from tbl_intranet_employee_jobdetails job inner join tbl_login lg on job.empcode=lg.empcode where job.empcode=" + empcode + "";

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MailAddress fromadd = new MailAddress(Session["email"].ToString());

                string sqladdress = "select smtp_addr from tbl_smtp_address";
                string smtp_address = Convert.ToString(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqladdress));
                smtpClient.Host = smtp_address;
                //smtpClient.Host = "localhost";

                smtpClient.Port = 25;
                message.To.Add(ds.Tables[0].Rows[0]["EmailId"].ToString());
                message.From = fromadd;
                message.Subject = "Leave rights delegation status";
                message.IsBodyHtml = true;
                message.Body = "Hello " + ds.Tables[0].Rows[0]["emp_fname"].ToString() + ",<br><br>Your leave right delegation request has been responded. Please login to HRMS to review the same.<br><br>Thanks,<br><br>Acuminous Software<br>";
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Activity performed successfully,but there is some problem in sending mail.";
        }
    }
}