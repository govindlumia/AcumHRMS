using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Appraisal_Admin_AppraisalKRAHead : BasePage<AppraisalKRAHeadEntity>
{
    AppraisalKRAHeadBAL _objKRAHeadBAL;

    public Appraisal_Admin_AppraisalKRAHead()
    {
        _objKRAHeadBAL = new AppraisalKRAHeadBAL();
    }
    public int AppraisalKRAHeadID
    {
        get { return Convert.ToInt32(ViewState["KRAHeadID"]); }
        set { ViewState["KRAHeadID"] = value; }
    }
    protected void FillControls()
    {
        AppraisalPeriodBAL objBAL = new AppraisalPeriodBAL();
        List<AppraisalPeriodEntity> objResult = objBAL.GetAll();

        txt_kra_head.Text = string.Empty;
        txt_weightage.Text = string.Empty;
        BindDataGridView(_objKRAHeadBAL.GetAll(), grdAppraisalKRAHead);
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
    protected void btnKRAHeadSave_Click(object sender, EventArgs e)
    {
        if (!Validate())
            return;

        AppraisalKRAHeadEntity KRAHeadEntity = new AppraisalKRAHeadEntity();

        KRAHeadEntity.IsActive = true;
        KRAHeadEntity.PeriodId = 0;
        KRAHeadEntity.KRAHead = txt_kra_head.Text;
        KRAHeadEntity.Weightage = Convert.ToDecimal(txt_weightage.Text);
        KRAHeadEntity.CreatedBy = SessionEmpCode;
        KRAHeadEntity.ModifiedBy = SessionEmpCode;

        Int32 success = 0;
        if (AppraisalKRAHeadID > 0 && btnKRAHeadSave.Text == ConfigHelper.TextUpdate)
        {
            KRAHeadEntity.Id = AppraisalKRAHeadID;
            success = _objKRAHeadBAL.Update(KRAHeadEntity);
            AppraisalKRAHeadID = 0;
        }
        else
            success = _objKRAHeadBAL.Create(KRAHeadEntity);

        if (success > 0)
        {
            FillControls();
            txt_kra_head.Text = string.Empty;
            txt_weightage.Text = string.Empty;

            if (btnKRAHeadSave.Text == ConfigHelper.TextUpdate)
            {
                General.Alert(ConfigHelper.MessageUpdate, btnKRAHeadSave);
                btnKRAHeadSave.Text = ConfigHelper.TextSave;
            }
            else
                General.Alert(ConfigHelper.MessageSuccess, btnKRAHeadSave);
        }
        else if (success == -1)
            General.Alert(ConfigHelper.MessageAlreadyExist, btnKRAHeadSave);
        else
            General.Alert(ConfigHelper.MessageError, btnKRAHeadSave);
    }

    private Boolean Validate()
    {
        var isValidate = true;

        if (String.IsNullOrEmpty(txt_kra_head.Text))
        {
            isValidate = false;
            General.Alert("Enter KRA Head.", btnKRAHeadSave);
        }

        if (String.IsNullOrEmpty(txt_kra_head.Text))
        {
            isValidate = false;
            General.Alert("Enter Weightage.", btnKRAHeadSave);
        }

        try
        {
            int n;
            bool isNumeric = int.TryParse("123", out n);
            if (!isNumeric)
            {
                General.Alert("Enter digit only in Weightage.", btnKRAHeadSave);
            }
        }
        catch
        {
            isValidate = false;
            General.Alert("Enter digit only in Weightage.", btnKRAHeadSave);
        }

        decimal totalValue = 0;        
        foreach (GridViewRow grdRow in grdAppraisalKRAHead.Rows)
        {
            Label weightAge = (Label)grdRow.FindControl("lblWeightage");
            totalValue += Convert.ToDecimal(weightAge.Text);

            if (AppraisalKRAHeadID != null && AppraisalKRAHeadID > 0 && AppraisalKRAHeadID == Convert.ToInt32(weightAge.ToolTip))
            {
                totalValue -= Convert.ToDecimal(weightAge.Text);
            }

        }

        if (totalValue >= 100)
        {
            isValidate = false;
            General.Alert("KRA weightage sum is already equals to 100.", btnKRAHeadSave);
        }

        totalValue += Convert.ToDecimal(txt_weightage.Text);

        if (totalValue > 100)
        {
            isValidate = false;
            General.Alert("KRA weightage sum should not exceed 100.", btnKRAHeadSave);
        }

        return isValidate;
    }

    protected void grdAppraisalKRAHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int32 success = 0;
        AppraisalKRAHeadID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "EditRecord")
        {
            GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblCtrl = (Label)gvRow.FindControl("lblPeriodId");

            lblCtrl = (Label)gvRow.FindControl("lblKRAHead");
            txt_kra_head.Text = lblCtrl.Text;

            lblCtrl = (Label)gvRow.FindControl("lblWeightage");
            txt_weightage.Text = lblCtrl.Text;

            btnKRAHeadSave.Text = ConfigHelper.TextUpdate;
        }
        else if (e.CommandName == "DeleteRecord")
        {
            if (AppraisalKRAHeadID > 0)
            {
                AppraisalKRAHeadEntity KRAHeadEntity = new AppraisalKRAHeadEntity();
                KRAHeadEntity.Id = AppraisalKRAHeadID;
                success = _objKRAHeadBAL.Delete(KRAHeadEntity);
                if (success > 0)
                {
                    FillControls();
                    General.Alert(ConfigHelper.MessageDelete, btnKRAHeadSave);
                }
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        btnKRAHeadSave.Text = ConfigHelper.TextSave;
        txt_kra_head.Text = string.Empty;
        txt_weightage.Text = string.Empty;
    }
    protected void grdAppraisalKRAHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppraisalKRAHead.PageIndex = e.NewPageIndex;
        FillControls();
    }

} //End of class Appraisal_Admin_AppraisalKRAHead