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
using querystring;

public partial class leave_compoff_status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["compoffstatus"] != null)
            {
                if (Request.QueryString["compoffstatus"].ToString() == "0")
                    Label1.Text = "View Pending Comp-off";
                else if (Request.QueryString["compoffstatus"].ToString() == "1")
                    Label1.Text = "View Approved Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "2")
                    Label1.Text = "View Cancelled Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "3")
                    Label1.Text = "View Rejected Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "5")
                    Label1.Text = "View Draft Comp-off";

            }
        }
        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("leavestatus", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        helper.ApplyGroupSort();
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "leavestatus")
        {
            //row.CssClass = "frm-rght-clr123";
            //row.HorizontalAlign = HorizontalAlign.Left;
            //row.Cells[0].Text = "&nbsp;&nbsp; Status : " + row.Cells[0].Text;
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    } 
    protected string linkleave(string empcode, string leavename, int id, int approvalstatus)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if ((Request.QueryString["compoffstatus"].ToString() == "0" || Request.QueryString["compoffstatus"].ToString() == "5") && approvalstatus == 0)
            return "<a href='edit_applied_compoff.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='viewcompoff.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }
}
