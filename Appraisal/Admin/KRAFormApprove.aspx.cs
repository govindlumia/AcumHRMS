using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_KRAFormApprove : BasePage<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_Admin_KRAFormApprove()
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
        BindDataGridView(_objBAL.SelectKRAFormApproval(SessionEmpCode, 1), grdKRAForm);
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
            if (currentLevel.Text != "3")
            {
                if (isPeer.Text == "0")
                {
                    Response.Redirect("KRAFormApproveIndividual.aspx");
                }
                else
                {
                    Response.Redirect("KRAFormPeerApprove.aspx");
                }

            }
            else
            {
                Response.Redirect("FinalSubmit.aspx");
            }

        }
    }
    protected void grdKRAForm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label peer = (Label)e.Row.FindControl("lblIsPeer");
            Label levelText = (Label)e.Row.FindControl("txtApproverComment");
            if (peer.Text == "1")
            {
                levelText.Text = "Pending At Peer Manager";
            }
        }
    }
}