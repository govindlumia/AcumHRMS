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
using HRMS.BusinessLogic.Leave;


public partial class leave_view_approver_subemp : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "List of Employees under " + Request.QueryString["name"].ToString() + ' ' + '(' + ' ' + Request.QueryString["empcode"].ToString() + ')';
        bindapprover();
    }

    public void bindapprover()
    {
       CommonBAL balbj=new CommonBAL();
       DataTable dt_result = balbj.getApproverSubEmp(Request.QueryString["empcode"].ToString(), chk_includeall.Checked);
        approvergrid.DataSource = dt_result;
        approvergrid.DataBind();

    }
    protected void approvergrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        approvergrid.PageIndex = e.NewPageIndex;
        bindapprover();
    }
    protected void Unnamed1_CheckedChanged(object sender, EventArgs e)
    {
        bindapprover();
    }
}
