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

public partial class payroll_admin_viewallowances : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
    }
    protected void payheadgird_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor aEdit = (HtmlAnchor)e.Row.FindControl("anchorEdit");
            string allownaceId = e.Row.Cells[0].Text;
            if (allownaceId == "0" || allownaceId == "1" || allownaceId == "2" || allownaceId == "3" || allownaceId == "4" || allownaceId == "5" || allownaceId == "7"
                || allownaceId == "8" || allownaceId == "9" || allownaceId == "10" || allownaceId == "11" || allownaceId == "12" || allownaceId == "13"
                || allownaceId == "9" || allownaceId == "17" || allownaceId == "37" || allownaceId == "47")
            {
                aEdit.Visible = false;
            }
            else
            {
                aEdit.HRef = "editallowancesmaster.aspx?id=" + allownaceId;
            }
        }
    }
}
