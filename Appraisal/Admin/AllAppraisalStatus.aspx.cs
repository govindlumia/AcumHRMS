using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_AllAppraisalStatus : BasePage<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_Admin_AllAppraisalStatus()
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
        if (Request.QueryString.HasKeys())
        {
            string type = Request.QueryString[0].ToString();
            int level = 1;
            switch (type)
            { 
                case "M":
                    level = 1;
                    break;
                case "R":
                    level = 2;
                    break;
                case "F":
                    level = 4;
                    break;
                default:
                    level = 1;
                    break;
            }
            BindDataGridView(_objBAL.SelectKRAFormActionTakenByUser(SessionEmpCode, level), grdKRAForm);
        }
        else 
        {
            Response.Redirect("welcome.aspx");
        }
        
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
    }
    protected void grdKRAForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdKRAForm.PageIndex = e.NewPageIndex;
        string type = Request.QueryString[0].ToString();
        int level = 1;
        switch (type)
        {
            case "M":
                level = 1;
                break;
            case "R":
                level = 2;
                break;
            case "F":
                level = 4;
                break;
            default:
                level = 1;
                break;
        }
        BindDataGridView(_objBAL.SelectKRAFormActionTakenByUser(SessionEmpCode, level), grdKRAForm);
    }
}