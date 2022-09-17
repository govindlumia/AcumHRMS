using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_AppraisalRole : BasePage<AppraisalRoleEntity>
{
    AppraisalRoleBAL _objBAL;
    public Appraisal_Admin_AppraisalRole()
    {
        _objBAL = new AppraisalRoleBAL();
    }
    public int

        AppraisalRoleID
    {
        get
        {
            int ID = 0;
            int.TryParse(Convert.ToString(ViewState["RoleID"]), out ID);
            return ID;
        }
        set { ViewState["RoleID"] = value; }
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
        txtRole.Text = string.Empty;
        BindDataGridView(_objBAL.GetAll(), grdAppraisalPeriod);
        //grdAppraisalPeriod.PageIndexChanging += Grid_PageIndexChanging;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AppraisalRoleEntity entity = new AppraisalRoleEntity();
        entity.Role = txtRole.Text;
        entity.CreatedBy = entity.ModifiedBy = SessionEmpCode;
        entity.AppraisalRoleId = AppraisalRoleID;
        Int32 success = 0;

        if (AppraisalRoleID > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            success = _objBAL.Update(entity);
        else
            success = _objBAL.Create(entity);

        if (success > 0)
        {
            if (AppraisalRoleID > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            {
                General.Alert(ConfigHelper.MessageUpdate, btnSave);
                btnSave.Text = ConfigHelper.TextSave;
                AppraisalRoleID = 0;
            }
            else
                General.Alert(ConfigHelper.MessageSuccess, btnSave);

            FillControls();
            txtRole.Text = string.Empty;

        }
        else if (success == -1)
            General.Alert(ConfigHelper.MessageAlreadyExist, btnSave);
        else
            General.Alert(ConfigHelper.MessageError, btnSave);

    }
    protected void grdAppraisalPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AppraisalRoleEntity entity = new AppraisalRoleEntity();
        if (e.CommandName == "EditRecord")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;
            AppraisalRoleID = Convert.ToInt32(e.CommandArgument);

            Label lblRole = (Label)gvr.FindControl("lblRole");
            txtRole.Text = lblRole.Text;
            btnSave.Text = ConfigHelper.TextUpdate;
        }

        else if (e.CommandName == "DeleteRecord")
        {
            //entity.AppraisalRoleId = Convert.ToInt32(e.CommandArgument);
            //int success = _objBAL.Delete(entity);
            //if (success > 0)
            //{
            //    FillControls();
            //    General.Alert(ConfigHelper.MessageDelete, btnSave);
            //}
            //FillControls();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtRole.Text = string.Empty;
        AppraisalRoleID = 0;
        btnSave.Text = ConfigHelper.TextSave;
    }
    protected void grdAppraisalPeriod_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppraisalPeriod.PageIndex = e.NewPageIndex;
        FillControls();
    }
}