using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Reports_AllAppraisalStatusView : BasePage<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_Reports_AllAppraisalStatusView()
    {
        _objBAL = new KRAFormBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            FillControls();
        }
    }
    void FillControls()
    {
        BindDataGridView(_objBAL.SelectKRAFormActionTakenByUser(SessionEmpCode, 5), grdKRAForm);
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

            var currentLevel = (Label)gvr.FindControl("lblCurrentLevel");
            Label isPeer = (Label)gvr.FindControl("lblIsPeer");
            Response.Redirect("../Admin/FinalSubmit.aspx");
        }

        if (e.CommandName == "Print")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            var lblID = (Label)gvr.FindControl("lblID");

            Label lblEmpCode = (Label)gvr.FindControl("lblEmpCode");
            string pageurl = "../Admin/PrintPDF.aspx?FormId=" + lblID.Text.ToString() + "&EmpCode=" + lblEmpCode.Text.ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + pageurl + "','_blank')", true);
            //Response.Redirect("../Admin/PrintPDF.aspx?FormId=" + lblID.Text.ToString() + "&EmpCode=" + lblEmpCode.Text.ToString());
        }
    }
    protected void grdKRAForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdKRAForm.PageIndex = e.NewPageIndex;
        BindDataGridView(_objBAL.SelectKRAFormActionTakenByUser(SessionEmpCode, 5), grdKRAForm);
    }

}