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
public partial class leave_admin_mealmastercantean : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        sqlstr="INSERT INTO mealcoupanmaster(brkfstcost,mealcost) VALUES('" + txtbrkfst.Text.Trim().ToString() + "','" + txtmeal.Text.Trim().ToString() + "')";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        message.InnerHtml = "Meal Coupan cost has successfully updated!";
        txtbrkfst.Text = "";
        txtmeal.Text = "";
    }
}
