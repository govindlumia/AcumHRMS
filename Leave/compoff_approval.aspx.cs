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

public partial class leave_leave_approval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
            //hidd_status.Value = (Request.QueryString["status"] == null) ? "1" : Request.QueryString["status"].ToString();
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

    protected string linkleave(string empcode,string leavename,int id)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if(Convert.ToInt32(Request.QueryString["hr"])!= 1)
             return "<a href='viewcompoff_approver.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

        else
             return "<a href='viewcompoff_hr.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    }

    protected void leave_approval_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_fromdate = (Label)e.Row.FindControl("lbl_fromdate");
            Label lbl_todate = (Label)e.Row.FindControl("lbl_todate");
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
