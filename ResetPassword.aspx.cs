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
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var empcodefromqry = Request.QueryString["EmpCode"].ToString();
            if(empcodefromqry != null && empcodefromqry != "")
            {
                txtEmpCode.Text = empcodefromqry;
            }
            else
            {

            }
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
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            int saltSize = 5;
            string salt = CreateSalt(saltSize);
            string passwordHash = CreatePasswordHash(txt_confrmpassword.Text.Trim(), salt);

            SqlParameter[] arrParam = new SqlParameter[2];
            arrParam[0] = new SqlParameter("@empcode",SqlDbType.VarChar,50);
            arrParam[0].Value = txtEmpCode.Text;
            arrParam[1] = new SqlParameter("@password", passwordHash);
            sqlstr = "update tbl_login set pwd=@password where empcode= @empcode";
            try
            {
               int res = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, arrParam);
               if(res==1)
                General.Alert("Your new password has been updated successfully",btnSubmit,"Login.aspx");
               else
                   General.Alert("Employee code does not exist in database", btnSubmit);
            }
            catch (Exception ex)
            {
               // message.InnerHtml = "Problem in reseting password";
                General.Alert("Problem in reseting password", btnSubmit);
            }       
    }
}
