using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Appraisal_Admin_AppraisalPromotion : BasePage<AppraisalPromotionEntity>
{
    AppraisalPromotionBAL _objPromotionBAL;

    public Appraisal_Admin_AppraisalPromotion()
    {
        _objPromotionBAL = new AppraisalPromotionBAL();
    }
    public int AppraisalPromotionID
    {
        get { return Convert.ToInt32(ViewState["PromotionID"]); }
        set { ViewState["PromotionID"] = value; }
    }
    protected void FillControls()
    {
        txt_promotion.Text = string.Empty;
        BindDataGridView(_objPromotionBAL.GetAll(), grdAppraisalPromotion);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillControls();
        }
    }

    protected void btnPromotionSave_Click(object sender, EventArgs e)
    {
        AppraisalPromotionEntity PromotionEntity = new AppraisalPromotionEntity();

        PromotionEntity.IsActive    = true;        
        PromotionEntity.Promotion   = txt_promotion.Text;        
        PromotionEntity.CreatedBy   = SessionEmpCode;
        PromotionEntity.ModifiedBy  = SessionEmpCode;

        Int32 success = 0;
        if (AppraisalPromotionID > 0 && btnPromotionSave.Text == ConfigHelper.TextUpdate)
        {
            PromotionEntity.PromotionId = AppraisalPromotionID;
            success = _objPromotionBAL.Update(PromotionEntity);
        }
        else
            success = _objPromotionBAL.Create(PromotionEntity);

        if (success > 0)
        {
            FillControls();
            txt_promotion.Text = string.Empty;

            if (AppraisalPromotionID > 0 && btnPromotionSave.Text == ConfigHelper.TextUpdate)
            {
                General.Alert(ConfigHelper.MessageUpdate, btnPromotionSave);
                btnPromotionSave.Text = ConfigHelper.TextSave;
            }
            else
                General.Alert(ConfigHelper.MessageSuccess, btnPromotionSave);
        }
        else if (success == -1)
            General.Alert(ConfigHelper.MessageAlreadyExist, btnPromotionSave);
        else
            General.Alert(ConfigHelper.MessageError, btnPromotionSave);
    }


    protected void grdAppraisalPromotion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int32 success = 0;
        GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

        AppraisalPromotionID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "EditRecord")
        {
            Label lblCtrl = (Label)gvRow.FindControl("lblPromotion");
            txt_promotion.Text = lblCtrl.Text;

            btnPromotionSave.Text = ConfigHelper.TextUpdate;            
        }
        else if (e.CommandName == "DeleteRecord")
        {
            if (AppraisalPromotionID > 0)
            {
                AppraisalPromotionEntity PromotionEntity = new AppraisalPromotionEntity();

                PromotionEntity.PromotionId = AppraisalPromotionID;
                success = _objPromotionBAL.Delete(PromotionEntity);

                if (success > 0)
                {
                    FillControls();
                    General.Alert(ConfigHelper.MessageDelete, btnPromotionSave);
                }
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txt_promotion.Text = string.Empty;
    }
}