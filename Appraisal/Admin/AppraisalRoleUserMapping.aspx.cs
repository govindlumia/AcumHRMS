using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_AppraisalRoleUserMapping : BasePage<AppraisalRoleUserMappingEntity>
{
    AppraisalRoleUserMappingBAL _objBAL;
    public Appraisal_Admin_AppraisalRoleUserMapping()
    {
        _objBAL = new AppraisalRoleUserMappingBAL();
    }
    public int UserRoleMappingID
    {
        get
        {
            int id = 0;
            int.TryParse(Convert.ToString(ViewState["ID"]), out id);
            return id;
        }
        set { ViewState["ID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillControls();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        AppraisalRoleUserMappingEntity entity = new AppraisalRoleUserMappingEntity();
        entity.RoleId = Convert.ToInt32(ddlRole.SelectedValue);
        entity.EmpCode = txtEmpCode.Text.Trim();
        entity.CreatedBy = entity.ModifiedBy = SessionEmpCode;
        entity.ID = UserRoleMappingID;
        Int32 success = 0;

        if (UserRoleMappingID > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            success = _objBAL.Update(entity);
        else
            success = _objBAL.Create(entity);

        if (success > 0)
        {
            if (UserRoleMappingID > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            {
                General.Alert(ConfigHelper.MessageUpdate, btnSave);
                btnSave.Text = ConfigHelper.TextSave;
                UserRoleMappingID = 0;
            }
            else
                General.Alert(ConfigHelper.MessageSuccess, btnSave);

            FillControls();
            

        }
        else if (success == -1)
            General.Alert(ConfigHelper.MessageAlreadyExist, btnSave);
        else
            General.Alert(ConfigHelper.MessageError, btnSave);

    }
    void FillControls()
    {
        txtEmpCode.Text = string.Empty;
        ClearDropDownSelection(ddlRole);
        BindRoles();
        BindDataGridView(_objBAL.GetAll(), grdUserMapping);
    }
    public void BindRoles()
    {
        AppraisalRoleBAL roles = new AppraisalRoleBAL();
        BindDropDowns(ddlRole, roles.GetAll().Where(m => m.IsActive).ToList(), "AppraisalRoleId", "Role");
        
    }
    protected void grdUserMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
       
        UserRoleMappingID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "EditRecord")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblEmpCode = (Label)gvr.FindControl("lblEmpCode");
            Label lblRoleID = (Label)gvr.FindControl("lblRoleID");
            txtEmpCode.Text = lblEmpCode.Text;
            // Set Selected Value
            SetSelectedValue(ddlRole, lblRoleID.Text);

            btnSave.Text = ConfigHelper.TextUpdate;
        }

        if (e.CommandName == "Active")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            AppraisalRoleUserMappingEntity entity = new AppraisalRoleUserMappingEntity();
            entity.CreatedBy = entity.ModifiedBy = SessionEmpCode;
            entity.ID = UserRoleMappingID;
            LinkButton btnActive = (LinkButton)gvr.FindControl("btnActive");
            if (_objBAL.ChangeSatus(entity) > 0)
                General.Alert(ConfigHelper.MessageDelete,btnSave);
            else
                General.Alert(ConfigHelper.MessageError, btnSave);

            FillControls();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtEmpCode.Text = string.Empty;
        ClearDropDownSelection(ddlRole);
        UserRoleMappingID = 0;
        btnSave.Text = ConfigHelper.TextSave;
    }
    protected void grdUserMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdUserMapping.PageIndex = e.NewPageIndex;
        FillControls();
    }
}