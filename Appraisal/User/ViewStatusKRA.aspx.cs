using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_ViewStatusKRA : BasePage<KRASetting>
{
    KRAMasterBAL _objBAL;
    public Appraisal_User_ViewStatusKRA()
    {
        _objBAL = new KRAMasterBAL();
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
        BindDataGridView(_objBAL.SelectKRAStatus(SessionEmpCode), grdKRAStatus);
    }
    protected void grdAppraisalPeriod_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    public Int64 CurrentKRASettingID
    {
        get;
        set;
    }
    protected void grdAppraisalPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        if (e.CommandName == "View")
        {
            CurrentKRASettingID = Convert.ToInt64(e.CommandArgument);
            Label lblEmpCode = (Label)gvr.FindControl("lblEmpCode");

            Session["UserEmpCode"]= HttpContext.Current.Items["UserEmpCode"] = lblEmpCode.Text;
            HttpContext.Current.Items["CurrentKRASettingID"] = CurrentKRASettingID;

            Server.Transfer("ViewKRASetting.aspx");
        }
    }
}