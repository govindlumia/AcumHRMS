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

public partial class leave_approved_oddetails : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindod();
        }
    }
    protected void bindod()
    {
        sqlstr = "select id,empcode,convert(varchar,date,101)date,convert(varchar,fromtime,101)fromtime,leave_status,working_hour from tbl_leave_apply_od where empcode='" + Session["empcode"] + "' and Leave_status ='" + 1 + "' and Approval_status='" + 1 + "' ORDER BY date DESC";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        pendinggrid.DataSource = ds;
        pendinggrid.DataBind();

    }
}
