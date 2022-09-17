using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_ViewKRAFormStatus : BasePage<KRASetting>
{
    KRAFormBAL _objBAL;
    public Appraisal_User_ViewKRAFormStatus()
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
        DataTable dt = _objBAL.ViewKRAFormStatus(SessionEmpCode);
        if (dt.Rows.Count > 0)
        {
            grdKRAStatus.DataSource = dt;
        }
        else
        {
            grdKRAStatus.DataSource = null;
        }
        grdKRAStatus.DataBind();
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

            Session["UserEmpCode"] = HttpContext.Current.Items["UserEmpCode"] = lblEmpCode.Text;
            HttpContext.Current.Items["CurrentKRASettingID"] = CurrentKRASettingID;

            Session["UserEmpCode"] = lblEmpCode.Text;
            Session["KRAFormID"] = CurrentKRASettingID;
           
            Response.Redirect("../Admin/FinalSubmit.aspx");
        }
    }
}