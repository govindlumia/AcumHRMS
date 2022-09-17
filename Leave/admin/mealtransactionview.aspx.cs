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
public partial class leave_admin_mealtransactionview : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        bindbrkfstcoupan();
        bindmealcoupan();
    }
    protected void bindbrkfstcoupan()
    {
        sqlstr = "SELECT m.empcodeno empcode,count(t.status) status,m.noofbrkfstcoupan noofbrkfstcoupan,m.month month FROM mealtransaction t inner join mealmaster m on m.empcodeno=t.empcode group by m.empcodeno ,t.status,m.noofbrkfstcoupan,m.month having m.empcodeno='" + txtempcode.Text.Trim().ToString() + "' and t.status=0";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        brkfstgird.DataSource = ds;
        brkfstgird.DataBind();
    }

    protected void bindmealcoupan()
    {
        sqlstr = "SELECT m.empcodeno empcode,count(t.status) status,m.noofmainmealcoupan noofmainmealcoupan,m.month month FROM mealtransaction t inner join mealmaster m on m.empcodeno=t.empcode group by m.empcodeno ,t.status,m.noofmainmealcoupan,m.month having m.empcodeno='" + txtempcode.Text.Trim().ToString() + "' and t.status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
