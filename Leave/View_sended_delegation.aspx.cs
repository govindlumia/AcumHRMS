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

            bind_delegation_detail();
        }
    }

    protected void bind_delegation_detail()
    {
        sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 20);
        sqlparam[0].Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "view_delegated_jobs", sqlparam);
        del_grid.DataSource = ds;
        del_grid.DataBind();
    }

    protected void del_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "send_terminate")
        {
            //int index = Convert.ToInt32(e.CommandArgument);

            //GridViewRow a = ((GridView)e.CommandArgument).Rows[index];

            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
            string ecode = commandArgsAccept[1].ToString();//it gives second ID

            sqlstr = "update tbl_delegation_details set status='2' where id=" + eid + "";
            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            message.InnerHtml = "Delegation status updated successfully";

            mailtoapprover(ecode);

            //mailtoapprover(ecode,eid);
        }
        bind_delegation_detail();
    }


    protected void mailtoapprover(string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            sqlstr = "select lg.EmailId,lg.role,job.emp_fname from tbl_intranet_employee_jobdetails job inner join tbl_login lg on job.empcode=lg.empcode where job.empcode=" + empcode + "";

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //query q = new query();
                //string pairs = String.Format("email_id={0}", ds.Tables[0].Rows[0]["email_id"].ToString());
                //string encoded;
                //encoded = q.EncodePairs(pairs);

                //url = "<a href='http://192.168.1.8/ceb/leavedetail.aspx?q=" + encoded + "'>http://192.168.1.8/ceb/leavedetail.aspx</a>";

                //url = "<a href='" + ConfigurationManager.AppSettings["url"].ToString() + "/login.aspx'>" + ConfigurationManager.AppSettings["url"].ToString() + "/login.aspx</a>";

                MailAddress fromadd = new MailAddress(Session["email"].ToString());

                string sqladdress = "select smtp_addr from tbl_smtp_address";
                string smtp_address = Convert.ToString(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqladdress));
                smtpClient.Host = smtp_address;
                //smtpClient.Host = "localhost";

                smtpClient.Port = 25;
                message.To.Add(ds.Tables[0].Rows[0]["EmailId"].ToString());
                message.From = fromadd;
                message.Subject = "Leave rights delegation request status";
                message.IsBodyHtml = true;
                message.Body = "Hello " + ds.Tables[0].Rows[0]["emp_fname"].ToString() + ",<br><br>" + Session["name"] + " has stopped the Leave rights delegation request sent by him . Please login to HCMS and review the same.<br><br>Thanks,<br><br>Acuminous Software<br>";
                //Session["name"]+" has sent you leave right delegation request. Please login to the system and accept delegation request  <br><br>" + url;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpClient.Send(message);
                //Vivekanand Roy has stopped the Leave rights delegation request sent by him . Please login to LMS and review the same.
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Activity performed successfully,but there is some problem in sending mail.";
        }
    }
}