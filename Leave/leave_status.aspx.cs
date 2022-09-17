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

public partial class leave_leave_status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/Login.aspx");


        }
        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("leavestatus", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        helper.ApplyGroupSort();
    }

    protected string linkleave(string empcode, string leavename, int id, int leavestatus)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (leavestatus == 5)
            return "<a href='editleave.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='viewleave.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }

    protected string linkCompOff(string empcode, string leavename, int id, int leavestatus)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (leavestatus == 5)
            return "<a href='editleave.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='viewcompoff.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "leavestatus")
        {
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }

    protected void leave_approval_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_fromdate =(Label) e.Row.FindControl("l5");
            Label lbl_todate = (Label)e.Row.FindControl("l6");
            if (lbl_fromdate != null && lbl_todate != null)
            { 
            if(!string.IsNullOrEmpty(lbl_fromdate.Text.Trim()))
            {
                lbl_fromdate.Text = Convert.ToDateTime(lbl_fromdate.Text).ToString("dd-MMM-yyyy");
            }
            if (!string.IsNullOrEmpty(lbl_todate.Text.Trim()))
            {
                lbl_todate.Text = Convert.ToDateTime(lbl_todate.Text).ToString("dd-MMM-yyyy");
            }
            }
        }
    }
    protected void compoff_approval_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_fromdate = (Label)e.Row.FindControl("l5");
            Label lbl_todate = (Label)e.Row.FindControl("l6");
            if (lbl_fromdate != null && lbl_todate != null)
            {
                if (!string.IsNullOrEmpty(lbl_fromdate.Text.Trim()))
                {
                    lbl_fromdate.Text = Convert.ToDateTime(lbl_fromdate.Text).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(lbl_todate.Text.Trim()))
                {
                    lbl_todate.Text = Convert.ToDateTime(lbl_todate.Text).ToString("dd-MMM-yyyy");
                }
            }
        }
    }
}
