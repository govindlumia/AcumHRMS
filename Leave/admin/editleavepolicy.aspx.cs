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

public partial class Leave_admin_editleavepolicy : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (Request.QueryString["updated"] != null)
            message.InnerHtml = "Leave policy updated successfully.";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bindpolicy();    
        }
                  
    }

    protected void bindpolicy()
    {
        sqlstr = "select policyid,policyname,policy_file_name,policy_file_type,(CASE WHEN date='01/01/1900' THEN '' ELSE  date END)date from tbl_leave_createleavepolicy order by policyid ";
        ds = DataAccessLayer.DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        policygrid.DataSource = ds;
        policygrid.DataBind();
    }

    protected void policygird_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        int a;
        a = (int)policygrid.DataKeys[e.RowIndex].Value;
        string strcheck = "select policyid from tbl_leave_createdefaultrule where policyid=" + a + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strcheck);

        if (ds.Tables[0].Rows.Count > 0)
        {
            message.InnerHtml = "You can not delete this policy as it is used in leave system";
        }
        else
        {
            sqlstr = "delete from tbl_leave_createleavepolicy where policyid=" + a + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            bindpolicy();
        }
    }

    protected void policygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        policygrid.PageIndex = e.NewPageIndex;
        bindpolicy();
    }    
}
