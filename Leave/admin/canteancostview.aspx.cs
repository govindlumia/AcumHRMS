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
public partial class leave_admin_canteancostview : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlstr = "SELECT * FROM mealcoupanmaster";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbreakfast.Text = ds.Tables[0].Rows[0]["brkfstcost"].ToString();
                lblmeal.Text = ds.Tables[0].Rows[0]["mealcost"].ToString();
            }
            else
            {
                lblbreakfast.Text = "0.00";
                lblmeal.Text = "0.00";
            }
        }
    }
}
