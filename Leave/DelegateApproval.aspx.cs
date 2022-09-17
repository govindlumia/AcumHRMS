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
using System.Net.Mail;
using querystring;

public partial class Leave_Default : System.Web.UI.Page
{
    string sqlstr;
    SqlParameter[] sqlparam;
    DataSet ds, ds1, ds2, ds3, ds4 = new DataSet();
    string message1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["Manager"].ToString() == "0")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void insert_delegation_detail()
    {
        try
        {
            sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Session["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@del_empcode", SqlDbType.VarChar, 50);
            sqlparam[1].Value = txt_employee.Text.ToString();
            HiddenField1.Value = txt_employee.Text.ToString();

            sqlparam[2] = new SqlParameter("@del_sdate", SqlDbType.DateTime);
            sqlparam[2].Value = Convert.ToDateTime(txt_sdate.Text.ToString());

            sqlparam[3] = new SqlParameter("@del_enddate", SqlDbType.DateTime);
            sqlparam[3].Value = Convert.ToDateTime(txt_edate.Text.ToString());

            sqlparam[4] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparam[4].Value = 0;

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_delegate_leave_right]", sqlparam);

            message.InnerHtml = "Job delegated successfully";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem in delegating leave right,try later";
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (validate_selfdelegation())
        {
            if (validate_running_delegation())
            {
                if (validate_pending_request_in_hierarchy())
                {
                    if (validate_applieddate())
                    {
                        if (!validate_delegation())
                            return;
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else
                return;
        }
        else
            return;

        //try
        //{
        insert_delegation_detail();
        mailtoapprover(txt_employee.Text.ToString());
        clear();
        //}
        //catch (Exception ex)
        //{
        //    message.InnerHtml = "Problem in delegating leave right,try later";
        //}        
    }

    protected void mailtoapprover(string empcode)
    {
        try
        {
            //string url;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            sqlstr = "select lg.EmailId,lg.role,job.emp_fname from tbl_intranet_employee_jobdetails job inner join tbl_login lg on job.empcode=lg.empcode where job.empcode=" + empcode + "";

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
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
                string smtp_address = Convert.ToString(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["cebConnectionString"].ConnectionString.ToString(), CommandType.Text, sqladdress));
                smtpClient.Host = smtp_address;
                //smtpClient.Host = "localhost";

                smtpClient.Port = 25;
                message.To.Add(ds.Tables[0].Rows[0]["EmailId"].ToString());
                message.From = fromadd;
                message.Subject = "Leave rights delegation request";
                message.IsBodyHtml = true;
                message.Body = "Hello " + ds.Tables[0].Rows[0]["emp_fname"].ToString() + ",<br><br>You have received leave rights delegation request through " + Session["name"] + ". Please login to HRMS and review the same within 3 days.<br><br>Thanks,<br><br>Acuminous Software<br>";
                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Job delegated successfully,but there is some problem in sending mail.";
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }
    protected void clear()
    {
        txt_edate.Text = "";
        txt_employee.Text = "";
        txt_sdate.Text = "";
    }

    //-------------------------------  Validation for checking existing leave right delegation ------------------------------//

    protected Boolean validate_delegation()
    {
        SqlParameter[] sqlprm = new SqlParameter[4];

        sqlprm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlprm[0].Value = Session["empcode"].ToString();

        sqlprm[1] = new SqlParameter("@del_empcode", SqlDbType.VarChar, 50);
        sqlprm[1].Value = txt_employee.Text.ToString();

        sqlprm[2] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlprm[2].Value = Convert.ToDateTime(txt_sdate.Text.ToString());

        sqlprm[3] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlprm[3].Value = Convert.ToDateTime(txt_edate.Text.ToString());

        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_validate_delegation", sqlprm);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            message1 = "You have already requested for leave rights delegation during this span! Please check delegation status.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    //-------------------------------  Validation for Back-dated leave right delegation ------------------------------//

    protected Boolean validate_applieddate()
    {
        DateTime dt1 = Convert.ToDateTime(txt_sdate.Text);
        DateTime dt2 = Convert.ToDateTime(txt_edate.Text);

        TimeSpan diff = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);

        if (diff.Days < 0)
        {
            message1 = "End date should be greater than start date.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        else
        {
            TimeSpan d = dt1 - Utilities.Utility.indiantime();

            if (d.TotalDays <= -1)
            {
                message1 = "Back-dated delegation is not allowed.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                return false;
            }
        }

        return true;
    }

    //-------------------------------  Validation for self leave right delegation ------------------------------//

    protected Boolean validate_selfdelegation()
    {
        if (txt_employee.Text == Session["empcode"].ToString())
        {
            message1 = "Self delegation is not allowed.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    //-------------------------------  Validation for checking -->having leave right delegation(delegated to applicant)------------------------------//

    protected Boolean validate_running_delegation()
    {
        SqlParameter[] sqlprm = new SqlParameter[4];

        sqlprm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlprm[0].Value = Session["empcode"].ToString();

        sqlprm[1] = new SqlParameter("@del_empcode", SqlDbType.VarChar, 50);
        sqlprm[1].Value = txt_employee.Text.ToString();

        sqlprm[2] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlprm[2].Value = Convert.ToDateTime(txt_sdate.Text.ToString());

        sqlprm[3] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlprm[3].Value = Convert.ToDateTime(txt_edate.Text.ToString());

        ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_validate_accepted_delegation]", sqlprm);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            message1 = "You have been assigned with leave rights during this span. Please check the delegation status";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    //-------------------------------  Validation for checking -->existence of pending application of DR------------------------------//

    protected Boolean validate_pending_request_in_hierarchy()
    {
        string str1 = @"select * from tbl_Employee_Hierarchy where employeecode='" + txt_employee.Text.ToString() + "' and approverid='" + Session["empcode"].ToString() + "'";

        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            SqlParameter[] sqlprm = new SqlParameter[2];

            sqlprm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlprm[0].Value = txt_employee.Text.ToString();

            sqlprm[1] = new SqlParameter("@dempcode", SqlDbType.VarChar, 50);
            sqlprm[1].Value = Session["empcode"].ToString();

            //SqlParameter sqlprm = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //sqlprm.Value = txt_employee1.Text.ToString();//whom want to delegate

            ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_validate_hierarchy_delegation", sqlprm);

            if (ds4.Tables[0].Rows.Count > 0 || ds4.Tables[1].Rows.Count > 0 || ds4.Tables[2].Rows.Count > 0)
            {
                message1 = "There are some pending applications of manager. Kindly respond them before delegating your leave right";//"There are some pending applications in hierarchy of your DR. Kindly respond them before delegating your leave right to your DR.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
                return false;
            }
        }
        return true;
    }
    protected void txt_sdate_TextChanged(object sender, EventArgs e)
    {

    }
}