using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_UserControl_UCViewKRAForm : BasePageUC<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_UserControl_UCViewKRAForm()
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
        List<KRAFormEntity> result = _objBAL.SelectKRAFormDraft(SessionEmpCode);
        if (result != null && result.Any())
        {
            var myResult = result.FirstOrDefault();
            ViewState["KRASettingID"] = myResult.KRASettingId;
            ViewState["KRAFormID"] = myResult.Id;
            ViewState["IsDraft"] = myResult.IsDraft;

            BindDataGridView(result, grdKRAForm);
            

          

            txtComment.Text = myResult.Comment;

            ListTrainingDetail = myResult.KRATrainingDetail;
            if ( !myResult.IsDraft)
            {
                btnClose.Visible = false;
                btnSubmit.Visible = false;
                btnDraft.Visible = false;
                txtComment.ReadOnly = true;
            }
            BindTrainingValues();

        }
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdDetails");
            Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
           

            var intId = Convert.ToInt32(lblID.Text);
            if (grdPK != null)
            {
                var lst = _DataSet.Where(m => m.KRAHeadID == intId);
                //List<KRASettingDetail> detail = lst.SelectMany(b => b.KRASettingDetails).ToList();
                List<KRAFormDetailEntity> detail = lst.SelectMany(m => m.KRAFormDetail).ToList();
                if (detail != null)
                    grdPK.DataSource = detail;
                else
                    grdPK.DataSource = null;

                grdPK.DataBind();
            }
        }
    }
    protected void grdTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView grd = (GridView)sender;

        if (e.CommandName == "DeleteRecord")
        {
            BindValues(grd, Convert.ToInt32(e.CommandArgument), "Delete");
            BindTrainingValues();
        }
    }
    public void BindTrainingValues()
    {

        grdTraining.DataSource = ListTrainingDetail;
        grdTraining.DataBind();

    }
    public List<KRATrainingDetailEntity> ListTrainingDetail { get; set; }
    void BindValues(GridView grd, int idToDelete = 0, string command = "")
    {
        if (grd != null)
        {
            foreach (GridViewRow row in grd.Rows)
            {
                TextBox txtTrainingDesc = (TextBox)row.FindControl("txtTrainingDesc");

                LinkButton lnkDelete = (LinkButton)row.FindControl("lnkDelete");

                if (command == "Delete" && idToDelete > 0 && grd.Rows.Count > 1)
                {
                    if (idToDelete == Convert.ToInt32(lnkDelete.CommandArgument))
                        continue;
                }
                KRATrainingDetailEntity master = new KRATrainingDetailEntity()
                {

                    ID = Convert.ToInt32(lnkDelete.CommandArgument),
                    CreatedBy = Convert.ToString(Session["EmpCode"]),
                    TrainingDesc = txtTrainingDesc.Text
                };

                if (ListTrainingDetail == null)
                {
                    ListTrainingDetail = new List<KRATrainingDetailEntity>();
                    master.ID = 1;
                }

                ListTrainingDetail.Add(master);
            }

        }

    }
    void AddDefaultRow()
    {
        KRATrainingDetailEntity master = new KRATrainingDetailEntity();
        if (ListTrainingDetail == null)
        {
            ListTrainingDetail = new List<KRATrainingDetailEntity>();
            master.ID = 1;
        }
        else
            master.ID = ListTrainingDetail.Max(m => m.ID) + 1;

        ListTrainingDetail.Add(master);

    }
    public void AddRow(object sender, EventArgs e)
    {
        BindValues(grdTraining);
        AddDefaultRow();
        BindTrainingValues();
    }
    public void SavaData(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            if (Convert.ToInt64(ViewState["KRAFormID"]) > 0)
            {
                KRAFormEntity kraForm = new KRAFormEntity();
                kraForm.Id = Convert.ToInt64(ViewState["KRAFormID"]);
                kraForm.IsDraft = btn.ID == btnDraft.ID ? true : false;
                kraForm.KRASettingId = Convert.ToInt64(ViewState["KRASettingID"]);
                kraForm.Comment = txtComment.Text;
                kraForm.CreatedBy=kraForm.ModifiedBy = kraForm.EmpCode = SessionEmpCode;
                kraForm.KRAFormDetail = new List<KRAFormDetailEntity>();
                kraForm.KRATrainingDetail = new List<KRATrainingDetailEntity>();

                foreach (GridViewRow row in grdTraining.Rows)
                {
                    TextBox txtTrainingDesc = (TextBox)row.FindControl("txtTrainingDesc");
                    var kraTraining = new KRATrainingDetailEntity() { TrainingDesc = txtTrainingDesc.Text };
                    kraForm.KRATrainingDetail.Add(kraTraining);
                }

                #region Fetch Values from Grid View
                foreach (GridViewRow row in grdKRAForm.Rows)
                {
                    var grdPK = (GridView)row.FindControl("grdDetails");
                    foreach (GridViewRow rowDetail in grdPK.Rows)
                    {
                        var lblKRASettingDetail = (Label)rowDetail.FindControl("lblKRASettingDetail");
                        var txtAddComment = (TextBox)rowDetail.FindControl("txtAddComment");
                        DropDownList ddlRating = (DropDownList)rowDetail.FindControl("ddlRating");

                        KRAFormDetailEntity formDetail = new KRAFormDetailEntity();
                        formDetail.SelfRating = Convert.ToInt32(ddlRating.SelectedValue);
                        formDetail.Id = Convert.ToInt64(lblKRASettingDetail.Text);

                        formDetail.Comment = txtAddComment.Text;
                        kraForm.KRAFormDetail.Add(formDetail);
                    }
                }
                #endregion

                KRAFormBAL bal = new KRAFormBAL();
                if (bal.Update(kraForm) > 0)
                    General.Alert(ConfigHelper.MessageUpdate, btnClose);
                else
                    General.Alert(ConfigHelper.MessageError, btnClose);
            }
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, btnClose);
        }
    }



    protected void grdTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSelfRating = (Label)e.Row.FindControl("lblSelfRating");
            DropDownList ddlRating = (DropDownList)e.Row.FindControl("ddlRating");
            var txtAddComment = (TextBox)e.Row.FindControl("txtAddComment");
            if (ddlRating.Items.FindByValue(lblSelfRating.Text) != null)
            {
                ddlRating.ClearSelection();
                ddlRating.Items.FindByValue(lblSelfRating.Text).Selected = true;
            }
            if (!Convert.ToBoolean(ViewState["IsDraft"]))
            {
                ddlRating.Enabled = false;
                txtAddComment.ReadOnly = true;
            }
        }
    }
}