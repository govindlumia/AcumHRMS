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
public partial class editceomessage : System.Web.UI.Page
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
        txtCeoTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //sqlstr = "UPDATE CeoDesk SET Title='" + txtCeoTitle.Text.Replace("'", "''") + "',message='" + txtEmailNotificationP.Text.Replace("'", "''") + "' ";
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@Title", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txtCeoTitle.Text;
        sqlparm[1] = new SqlParameter("@Message", SqlDbType.VarChar, 5000);
        sqlparm[1].Value = HttpUtility.HtmlEncode(txtEmailNotificationP.Text);
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_updateCEO", sqlparm);

       
        Response.Redirect("ceomessage.aspx");
    }
}
