using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic.TimeSheet;
using System.Data;

public partial class TimeSheet_User_MyEmployeeTieSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }
        Session["EmpDataForApproval"] = null;
           }
    private void bindGrid()
    {
        EmployeeTimeSheetBAL balObj = new EmployeeTimeSheetBAL();
        DataTable _dtresult = balObj.getPendingSheets(Session["EmpCode"].ToString());
        if (_dtresult.Rows.Count > 0)
        {
            grd_pending.DataSource = _dtresult;
        }
        else
            grd_pending.DataSource = null;
        grd_pending.DataBind();
    }
    protected void grd_pending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            //LinkButton lnk_view = (LinkButton)e.Row.FindControl("lnk_viewed");
          
            //if (lnk_view != null)
            //{
            //    lnk_view.PostBackUrl = "ViewEmployeeTimeSheet.aspx";
            //}
        }
    }
    protected void grd_pending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Viewed"))
        {
            GridViewRow _gvr = (GridViewRow)grd_pending.Rows[Convert.ToInt32(e.CommandArgument)];
            string ID = (grd_pending.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            Label lbl_empcode = (Label)_gvr.FindControl("lbl_empcode");
            Label lbl_week = (Label)_gvr.FindControl("lbl_weekID");
            if (lbl_empcode != null && lbl_week != null )
            {
                Session["EmpDataForApproval"] = ID + ":" + lbl_empcode.Text.Trim() + ":" + lbl_week.Text.Trim();
            }
            Response.Redirect("ViewEmployeeTimeSheet.aspx", false);
        }
    }
    protected void grd_pending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_pending.PageIndex = e.NewPageIndex;
        bindGrid();
    }
}