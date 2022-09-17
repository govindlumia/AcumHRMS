using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using System.Security.Cryptography;
public partial class ResetPassword : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindempdetail();
        }
    }

    protected void bindempdetail()
    {
        query q = new query();
        string str = (q["empcode"] != null) ? q["empcode"] : "0";
        if (existence(str))
        {
            SqlParameter[] arrParam = new SqlParameter[1];
            arrParam[0] = new SqlParameter("@id", str);
            strsql = "SELECT  rtrim(tbl_intranet_employee_jobDetails.empcode) as empcode, coalesce(tbl_intranet_employee_jobDetails.emp_fname,'''') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'''') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'''') as name FROM tbl_intranet_employee_jobDetails WHERE empcode=@id";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
            lblcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }
        else
        {
            Response.Redirect("empview.aspx?password=true");
        }
    }
    public Boolean existence(string str)
    {
        int count;
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@id", str);
        strsql = "select count(empcode) from tbl_login where empcode=@id";
        count = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        if (count > 0)
        {
            return true;
        }
        else
        {
            message.InnerHtml = "User Doesnot Exist";
            return false;
        }
    }
    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        query q = new query();
        string str = (q["empcode"] != null) ? q["empcode"] : "0";
       
            int saltSize = 5;
            string salt = CreateSalt(saltSize);
            string passwordHash = CreatePasswordHash(txt_password.Text.Trim(), salt);

            SqlParameter[] arrParam = new SqlParameter[2];
            arrParam[0] = new SqlParameter("@id", str);
            arrParam[1] = new SqlParameter("@password", passwordHash);
            strsql = "update tbl_login set pwd=@password where empcode= @id";
            try
            {
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
                Response.Redirect("empview.aspx?passwordreset=true");
            }
            catch (Exception ex)
            {
                message.InnerHtml = "Problem Reseting Password";
            }
      
    }
}
