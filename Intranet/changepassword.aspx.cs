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

public partial class changepassword : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            //sqlstr=@"SELECT coalesce(emp_fname,'') + '' + coalesce(emp_m_name,'') + '' + coalesce(emp_l_name,'') as name,empcode from tbl_intranet_employee_jobDetails where empcode='"+Session["empcode"].ToString()+"'";
            sqlstr = @"SELECT coalesce(emp_fname,'') as name,empcode from tbl_intranet_employee_jobDetails where empcode='" + Session["empcode"].ToString() + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        lbl_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lblcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
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



     private bool IsAuthenticated(string suppliedUserName, string suppliedPassword)
    {
        bool passwordMatch = false;
        SqlParameter[] newparameter = new SqlParameter[1];
        newparameter[0] = new SqlParameter("@employeeID", SqlDbType.VarChar, 50);
        newparameter[0].Value = suppliedUserName.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SELECT_LOOKUPUSER", newparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string dbPasswordHash = ds.Tables[0].Rows[0]["pwd"].ToString();
            Session["empcode"] = ds.Tables[0].Rows[0]["empcode"].ToString();
            int saltSize = 8;
            string salt = dbPasswordHash.Substring(dbPasswordHash.Length - saltSize);//F61AB0B38AAC99B085E8695D951FE00C1E13C96DB
            string hashedPasswordAndSalt = CreatePasswordHash(suppliedPassword, salt);//39CEBFAD161E838026B367A33659E709A3BC8B6B
            passwordMatch = hashedPasswordAndSalt.Equals(dbPasswordHash);
            return passwordMatch;
        }
        else
            return false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsAuthenticated(lbl_name.Text,txt_oldpswd.Text) == true)
        {


            int saltSize = 5;
            string salt = CreateSalt(saltSize);
            string passwordHash = CreatePasswordHash(txt_confrmpassword.Text.Trim(), salt);

            SqlParameter[] arrParam = new SqlParameter[2];
            arrParam[0] = new SqlParameter("@empcode",SqlDbType.VarChar,50);
            arrParam[0].Value=lblcode.Text;
            arrParam[1] = new SqlParameter("@password", passwordHash);
            sqlstr = "update tbl_login set pwd=@password where empcode= @empcode";
            try
            {
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, arrParam);
                message.InnerHtml = "Your new password has been updated successfully";
            }
            catch (Exception ex)
            {
                message.InnerHtml = "Problem in reseting password";
            }
        }
        else
            message.InnerHtml = "Please enter correct old password";
    }

}
