using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_KRAFormReviewer : BasePage<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_Admin_KRAFormReviewer()
    {
        _objBAL = new KRAFormBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillControls();
        }
    }
    void FillControls()
    {
        BindDataGridView(_objBAL.SelectKRAFormApproval(SessionEmpCode, 2), grdKRAForm);
    }
    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            var lblID = (Label)gvr.FindControl("lblID");

            Label lblEmpCode = (Label)gvr.FindControl("lblEmpCode");
            Session["UserEmpCode"] = lblEmpCode.Text;
            Session["KRAFormID"] = lblID.Text;
            Response.Redirect("KRAFormApproveReviewer.aspx");
        }
    }
}