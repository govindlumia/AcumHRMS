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
public partial class leave_admin_mealmaster : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr=@"INSERT INTO mealmaster(empcodeno,cardno,month,noofbrkfstcoupan,noofmainmealcoupan,year) VALUES ('"+ txtempcode.Text.Trim().ToString() +"','" + txtcardno.Text.Trim().ToString() + "','" + ddlmonth.SelectedValue.ToString() + "'," + txtbrkfstcoupan.Text.Trim().ToString() + "," + txtmealcoupan.Text.Trim().ToString() + ",'" + ddlyear.SelectedValue.ToString() + "')";
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        message.InnerHtml = "Coupan has been issued successfully!";
        clear();
    }

    protected void clear()
    {
        txtcardno.Text = "";
        txtempcode.Text = "";
        txtmealcoupan.Text = "";
        txtbrkfstcoupan.Text = "";
        ddlyear.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
    }
}
