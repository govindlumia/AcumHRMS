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
using DataAccessLayer;
using Utilities;
public partial class leave_admin_mealtransaction : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
    }
    protected void btnbreakfst_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO mealtransaction(empcode,cardno,status,datetime) VALUES ('" + txtempcode.Text.Trim().ToString() + "','" + txtcardno.Text.Trim().ToString() + "','0','" + System.DateTime.Now + "')";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        message.InnerHtml = "Breakfast Coupan has been issued successfully!";
        clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO mealtransaction(empcode,cardno,status,datetime) VALUES ('" + txtempcode.Text.Trim().ToString() + "','" + txtcardno.Text.Trim().ToString() + "','1','" + System.DateTime.Now + "')";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        message.InnerHtml = "Main Meal Coupan has been issued successfully!";
        clear();
    }

    protected void clear()
    {
        txtcardno.Text = "";
        txtempcode.Text = "";
    }
}
