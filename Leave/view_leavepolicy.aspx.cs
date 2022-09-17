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

public partial class Leave_view_leavepolicy : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindpolicy();
        }
      
    }

    protected void policygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        policygrid.PageIndex = e.NewPageIndex;
        bindpolicy();
    }
    protected void bindpolicy()
    {
        sqlstr = "SELECT policyid,policyname,policy_file_name FROM tbl_leave_createleavepolicy WHERE status='1' ORDER BY policyid";
        ds = DataAccessLayer.DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);                     
        policygrid.DataSource = ds;
        policygrid.DataBind();
    }
}
