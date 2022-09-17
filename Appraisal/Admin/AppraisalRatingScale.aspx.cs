using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using System.Data;


public partial class Appraisal_Admin_AppraisalRatingScale : BasePage<AppraisalRatingScaleEntity>
{
    AppraisalRatingScaleBAL _objBAL;
    public Appraisal_Admin_AppraisalRatingScale()
    {
        _objBAL = new AppraisalRatingScaleBAL();
    }
    public int AppraisalRatingScaleId
    {
        get { return Convert.ToInt32(ViewState["RatingScaleID"]); }
        set { ViewState["RatingScaleID"] = value; }
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
        drpScaleFrom.ClearSelection();
        drpScaleTo.ClearSelection();
        BindRatingScale();
        txt_rating.Text = string.Empty;
        BindDataGridView(_objBAL.GetAll(), grdAppraisalRatingScale);
    }

    private void BindRatingScale()
    {
        CommonClass obj = new CommonClass();
        DataTable dt = new DataTable();
        dt = obj.RatingScale();
        int from = Convert.ToInt32(dt.Rows[0][0].ToString());
        int to = Convert.ToInt32(dt.Rows[0][1].ToString());

        drpScaleFrom.Items.Insert(0, new ListItem("0", "0"));
        drpScaleTo.Items.Insert(0, new ListItem("0", "0"));

        for (int i = from; i <= to; i++)
        {
            drpScaleFrom.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
            drpScaleTo.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        AppraisalRatingScaleEntity entity = new AppraisalRatingScaleEntity();

        entity.ScaleFrom = Convert.ToInt32(drpScaleFrom.SelectedValue);
        entity.ScaleTo = Convert.ToInt32(drpScaleTo.SelectedValue);
        entity.Rating = txt_rating.Text;
        entity.CreatedBy = entity.ModifiedBy = SessionEmpCode;
        entity.AppraisalRatingScaleId = AppraisalRatingScaleId;
        entity.IsActive = true;
        Int32 success = 0;

        if (AppraisalRatingScaleId > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            success = _objBAL.Update(entity);
        else if (entity.ScaleFrom > entity.ScaleTo)
        {
            success = 0;
        }
        else
            success = _objBAL.Create(entity);

        if (success > 0)
        {
            FillControls();
            if (AppraisalRatingScaleId > 0 && btnSave.Text == ConfigHelper.TextUpdate)
            {
                General.Alert(ConfigHelper.MessageUpdate, btnSave);
                drpScaleFrom.Enabled = true;
                drpScaleTo.Enabled = true;
                btnSave.Text = ConfigHelper.TextSave;
            }
            else
                General.Alert(ConfigHelper.MessageSuccess, btnSave);
        }
        else if (success == -1)
            General.Alert(ConfigHelper.MessageAlreadyExist, btnSave);
        else
            General.Alert(ConfigHelper.MessageError, btnSave);

    }
    protected void grdAppraisalRatingScale_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        AppraisalRatingScaleId = Convert.ToInt32(e.CommandArgument);

        AppraisalRatingScaleEntity entity = new AppraisalRatingScaleEntity();
        if (e.CommandName == "EditRecord")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblScaleFrom = (Label)gvr.FindControl("lblScaleFrom");
            Label lblScaleTo = (Label)gvr.FindControl("lblScaleTo");
            Label lblRating = (Label)gvr.FindControl("lblRating");

            drpScaleFrom.Text = lblScaleFrom.Text;
            drpScaleTo.Text = lblScaleTo.Text;
            drpScaleFrom.Enabled = false;
            drpScaleTo.Enabled = false;
            txt_rating.Text = lblRating.Text;
            btnSave.Text = ConfigHelper.TextUpdate;
            entity.IsActive = true;
        }

        if (e.CommandName == "DeleteRecord")
        {
            entity.AppraisalRatingScaleId = AppraisalRatingScaleId;
            int success = _objBAL.Delete(entity);
            if (success > 0)
            {
                FillControls();
                General.Alert(ConfigHelper.MessageDelete, btnSave);
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        drpScaleFrom.ClearSelection();
        drpScaleTo.ClearSelection();
        txt_rating.Text = string.Empty;
        btnSave.Text = ConfigHelper.TextSave;
    }

    protected void grdAppraisalRatingScale_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppraisalRatingScale.PageIndex = e.NewPageIndex;
        FillControls();
    }
}