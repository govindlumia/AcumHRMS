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
using DataAccessLayer;
using System.Data.SqlClient;
public partial class ceomessage : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindceomessage();
        }
    }

    protected void bindceomessage()
    {
        sqlstr = "Select top 1 * from ceodesk";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txtEmailNotificationP.Text = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["message"].ToString());
        txtEmailNotificationP.ReadOnly = true;
        lblceotitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("editceomessage.aspx");
    }
}
