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

public partial class leave_admin_check_leavepolicy : System.Web.UI.Page
{
    public string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            GridViewHelper helper = new GridViewHelper(this.policygrid);
            helper.RegisterGroup("policyname", true, true);

            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
           
            if (Request.QueryString["updated"] != null)
            {
                message.InnerHtml = "Leave rule updated successfully.";
            }
            bind_policy();
            DateTime dt;
        }
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "policyname")
        {
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }
    protected void bind_policy()
    {
        sqlstr = @"select tbl_leave_createdefaultrule.leaveid,tbl_leave_createdefaultrule.id,tbl_leave_createleave.leavetype,tbl_leave_createdefaultrule.policyid,tbl_leave_createleavepolicy.policyname,tbl_leave_createdefaultrule.entitled_days
        from tbl_leave_createdefaultrule
        INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_createdefaultrule.policyid=tbl_leave_createleavepolicy.policyid
        INNER JOIN tbl_leave_createleave ON tbl_leave_createdefaultrule.leaveid=tbl_leave_createleave.leaveid WHERE tbl_leave_createleave.leavetype not in ('LWP') order by policyname,leavetype";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        policygrid.DataSource = ds;
        policygrid.DataBind();
    }
}
