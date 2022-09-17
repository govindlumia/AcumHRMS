using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_AllKRAFormStatus : BasePage<KRASetting>
{
    KRAMasterBAL _objBAL;
    public Appraisal_User_AllKRAFormStatus()
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
        BindDataGridView(_objBAL.GetAllApprovalPending(SessionEmpCode, 1), grdAppraisalPeriod);
    }
    protected void grdAppraisalPeriod_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdSettingDetails");
            Label lblID = (Label)e.Row.FindControl("lblID");
            var intId = Convert.ToInt32(lblID.Text);
            if (grdPK != null)
            {
                var lst = _DataSet.Where(m => m.ID == intId);
                List<KRASettingDetail> detail = lst.SelectMany(b => b.KRASettingDetails).ToList();

                if (detail != null)
                    grdPK.DataSource = detail;
                else
                    grdPK.DataSource = null;

                grdPK.DataBind();
            }
        }
    }
    public Int64 CurrentKRASettingID
    {
        get;
        set;
    }
    protected void grdAppraisalPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblEmpCode = (Label)gvr.FindControl("lblEmpCode");
            Session["UserEmpCode"] = HttpContext.Current.Items["UserEmpCode"] = lblEmpCode.Text;

            CurrentKRASettingID = Convert.ToInt64(e.CommandArgument);
            HttpContext.Current.Items["CurrentKRASettingID"] = CurrentKRASettingID;
            Server.Transfer("ViewKRASetting.aspx");
        }
    }
    protected void grdAppraisalPeriod_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppraisalPeriod.PageIndex = e.NewPageIndex;
        BindDataGridView(_objBAL.GetAllApprovalPending(SessionEmpCode, 1), grdAppraisalPeriod);
    }
}