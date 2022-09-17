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

public partial class leave_leave_approved_cancelled : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }

        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("leavestatus", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        helper.ApplyGroupSort();

        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
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

    protected string linkleave(string empcode, string leavename, int id)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='viewleave_approver.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='view_leave_hr_cancelled.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";
    }

}
