using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Appraisal_UserControl_UCKRAFormPeerRating : BasePageUC<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    public Appraisal_UserControl_UCKRAFormPeerRating()
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
            if (Session["KRAFormID"] == null)
            {
                Response.Redirect("KRAFormApprove.aspx");
            }
            ViewState["KRAFormID"] = Session["KRAFormID"].ToString();
            ViewState["UserEmpCode"] = Session["UserEmpCode"].ToString();
            Session["KRAFormID"] = null;
            FillControls();
        }
    }
    void FillControls()
    {
        CommonClass obj = new CommonClass();
        DataTable dt = new DataTable();
        dt = obj.RatingScale();
        ViewState["DtRating"] = dt;
        List<KRAFormEntity> result = _objBAL.SelectKRAFormByFormID(Convert.ToInt64(ViewState["KRAFormID"]));
        if (result != null && result.Any())
        {
            BindDataGridView(result, grdKRAForm);
            var myResult = result.FirstOrDefault();

            DropDownList drpReview = ((DropDownList)EmployeeDetail1.FindControl("drpReviewPeriod"));
            Label lblReview = ((Label)EmployeeDetail1.FindControl("lblPeriod"));

            drpReview.Visible = false;
            lblReview.Text = myResult.KRADuration;

            ViewState["KRASettingID"] = myResult.KRASettingId;
            ViewState["KRAFormID"] = myResult.Id;
            ViewState["EmpCode"] = myResult.CreatedBy;

            //txtComment.Text = myResult.Comment;
            ListTrainingDetail = myResult.KRATrainingDetail;

            TrainingTabData();
            grdTraining.DataSource = null;
            grdTraining.DataBind();

            //if (myResult.PromotionDetail.Count > 0)
            //{
            //    grdPromotion.DataSource = myResult.PromotionDetail;
            //    grdPromotion.DataBind();
            //}
            //else
            //{
            //    BindPromotionCheckList();
            //}
            BindPromotionCheckList();
            BindHistoryComments();
        }
    }
    private void TrainingTabData()
    {
        String sqlstrSuperviser = "select * from [dbo].[KRATrainingTypeMaster] where IsActive=1 Select * from [dbo].[KRATrainingMaster] select TrainingName,CONVERT(varchar,FromDate,106)+' - '+CONVERT(varchar,ToDate,106) as Duration from AppraisalTrainingUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' and Status=1 select * from AppraisalSkillsUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' and ManagerRating!=0  Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + "  select distinct RecommendedBy as Status,TrainingDesc as Comments from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + "";
        DataSet dsTrining = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser);

        if (dsTrining.Tables[0].Rows.Count > 0)
        {
            drpTrainingType.DataSource = dsTrining.Tables[0];
            drpTrainingType.DataValueField = "Id";
            drpTrainingType.DataTextField = "TrainingType";
            drpTrainingType.DataBind();

            drpTrainingType.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        if (dsTrining.Tables[1].Rows.Count > 0)
        {
            ViewState["Training"] = dsTrining.Tables[1];
            DataView dv = new DataView(dsTrining.Tables[1]);
            dv.RowFilter = "TrainingTypeId=" + dsTrining.Tables[0].Rows[0]["Id"].ToString();
            drpTraining.DataSource = dv;
            drpTraining.DataValueField = "Id";
            drpTraining.DataTextField = "Training";
            drpTraining.DataBind();

            drpTraining.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        if (dsTrining.Tables[2].Rows.Count > 0)
        {
            grdTrainingAttended.DataSource = dsTrining.Tables[2];
        }
        else
        {
            grdTrainingAttended.DataSource = null;
        }
        grdTrainingAttended.DataBind();

        grdSkills.DataSource = dsTrining.Tables[3].Rows.Count > 0 ? dsTrining.Tables[3] : null;
        grdSkills.DataBind();

        grdTrainingEmployee.DataSource = dsTrining.Tables[4].Rows.Count > 0 ? dsTrining.Tables[4] : null;
        grdTrainingEmployee.DataBind();

        grdTrainingComments.DataSource = dsTrining.Tables[5].Rows.Count > 0 ? dsTrining.Tables[5] : null;
        grdTrainingComments.DataBind();
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

                var detail = lst.SelectMany(m => m.KRAFormDetail);
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
        }
    }
    public void BindPromotionCheckList()
    {
        AppraisalPromotionBAL objPromotionBAL = new AppraisalPromotionBAL();
        grdPromotion.DataSource = objPromotionBAL.GetAll();
        grdPromotion.DataBind();

        strPromotionQuery = String.Format(strPromotionQuery, ViewState["KRAFormID"].ToString(), 0, SessionEmpCode);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strPromotionQuery);

        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grdPromotion.Rows)
            {
                Label promotion = (Label)gRow.FindControl("lblPromotion");
                CheckBox chk = (CheckBox)gRow.FindControl("chkPromotion");
                TextBox txtC = (TextBox)gRow.FindControl("txtComments");

                if (promotion.Text.ToString() == ds.Tables[0].Rows[0][0].ToString())
                {
                    chk.Checked = true;
                    txtC.Enabled = true;
                    txtC.Text = ds.Tables[0].Rows[0][2].ToString();
                }
            }
        }

        a1.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&Level=1&Type=P')";

    }

    private String strPromotionQuery = "select distinct AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status,"
    + " KFP.Comment"
    + " from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on"
    + " KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId inner join  "
    + " AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId "
    + " Where KFP.KRAFormId={0} and KFP.LevelId={1} and KFP.CreatedBy={2}";

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

        master.CanDelete = true;

        ListTrainingDetail.Add(master);

    }
    public void AddRow(object sender, EventArgs e)
    {
        BindValues(grdTraining);
        AddDefaultRow();
    }
    public void SaveData(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;

            var count = 0;
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                General.Alert("Comments are mandatory.", btnSubmit);
                txtComment.Focus();
                TabContainer1.ActiveTabIndex = 0;
                return;
            }

            foreach (GridViewRow grdRow in grdPromotion.Rows)
            {
                var promotion = (Label)grdRow.FindControl("lblPromotion");
                var comments = (TextBox)grdRow.FindControl("txtComments");
                var chk = (CheckBox)grdRow.FindControl("chkPromotion");
                if (chk.Checked == true)
                {
                    count++;
                    if (string.IsNullOrEmpty(comments.Text))
                    {
                        General.Alert("Comments are mandatory in Promotion and Future Direction.", btnSubmit);
                        TabContainer1.ActiveTabIndex = 2;
                        return;
                    }
                }
            }

            if (count == 0)
            {
                General.Alert("Promotion and Future Direction is mandatory.", btnSubmit);
                TabContainer1.ActiveTabIndex = 2;
                return;
            }

            if (Convert.ToInt64(ViewState["KRAFormID"]) > 0)
            {
                KRAFormEntity kraForm = new KRAFormEntity();
                kraForm.Id = Convert.ToInt64(ViewState["KRAFormID"]);
                kraForm.KRASettingId = Convert.ToInt64(ViewState["KRASettingID"]);
                kraForm.Comment = txtComment.Text;
                kraForm.CreatedBy = kraForm.ModifiedBy = kraForm.EmpCode = SessionEmpCode;
                kraForm.KRAFormDetail = new List<KRAFormDetailEntity>();
                kraForm.KRATrainingDetail = new List<KRATrainingDetailEntity>();
                kraForm.PromotionDetail = new List<AppraisalPromotionEntity>();
                kraForm.CurrentLevel = 0;
                foreach (GridViewRow row in grdTraining.Rows)
                {
                    Label lblTrainingType = (Label)row.FindControl("TrainingType");
                    Label lblTrainingTypeId = (Label)row.FindControl("TrainingTypeId");
                    Label lblTraining = (Label)row.FindControl("Training");
                    Label lblTrainingId = (Label)row.FindControl("TrainingId");
                    var kraTraining = new KRATrainingDetailEntity() { TrainingTypeId = Convert.ToInt32(lblTrainingTypeId.Text), TrainingType = lblTrainingType.Text, TrainingId = Convert.ToInt32(lblTrainingId.Text), Training = lblTraining.Text, KRAFormId = kraForm.Id, CreatedBy = SessionEmpCode };
                    kraTraining.TrainingDesc = txtTC.Text;
                    kraTraining.ApproverCode = "Peer Manager";
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
                        Label isPeer = (Label)rowDetail.FindControl("lblIsPeerManager");
                        Label peerCode = (Label)rowDetail.FindControl("lblPeerCode");

                        KRAFormDetailEntity formDetail = new KRAFormDetailEntity();
                        if (isPeer.Text == "True" && peerCode.Text == SessionEmpCode)
                        {
                            formDetail.KRAFormId = kraForm.Id;
                            formDetail.SelfRating = Convert.ToInt32(ddlRating.SelectedValue);
                            formDetail.Id = Convert.ToInt64(lblKRASettingDetail.Text);
                            formDetail.CreatedBy = SessionEmpCode;
                            formDetail.Comment = formDetail.ManagerComment = txtAddComment.Text;
                            formDetail.IsPeerManager = btn.ID == "btnDraft" ? true : false;
                            formDetail.PeerManagerCode = "";
                            kraForm.KRAFormDetail.Add(formDetail);
                        }
                    }
                }
                #endregion

                #region Fetch Values From Promotion Detail
                foreach (GridViewRow row in grdPromotion.Rows)
                {
                    Label lblPromotion = (Label)row.FindControl("lblPromotion");
                    CheckBox chkPromotion = (CheckBox)row.FindControl("chkPromotion");
                    var txtPromotionComment = (TextBox)row.FindControl("txtComments");
                    if (txtPromotionComment != null && !String.IsNullOrEmpty(txtPromotionComment.Text))
                    {
                        var kraPromotion = new AppraisalPromotionEntity() { Comment = txtPromotionComment.Text, KRAFormID = kraForm.Id, PromotionId = Convert.ToInt32(lblPromotion.ToolTip), CreatedBy = SessionEmpCode, LevelId = 0, PostAction = chkPromotion.Checked };
                        kraForm.PromotionDetail.Add(kraPromotion);
                    }
                }
                #endregion

                KRAFormBAL bal = new KRAFormBAL();
                DraftModeAction(kraForm.Id);
                if (bal.InsertKRARating(kraForm) > 0)
                    General.Alert("Appraisal Form updated successfully.", btnClose, "../Admin/AllAppraisalStatus.aspx?User=M");
                else
                    General.Alert(ConfigHelper.MessageError, btnClose);
            }
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, btnClose);
        }
    }

    protected void DraftModeAction(Int64 kraFormId)
    {
        string queryDelete = "Delete from KRAFormRatingDetail where KRAFormId=" + kraFormId.ToString() + " and LevelId=0 and CreatedBy=" + SessionEmpCode + "  Delete from KRAFormPromotion where KRAFormId=" + kraFormId.ToString() + " and LevelId=0 and CreatedBy=" + SessionEmpCode + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, queryDelete);
    }

    protected void grdTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            if (lnkDelete != null)
            {
                lnkDelete.Visible = Convert.ToBoolean(lnkDelete.ToolTip);
            }
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblManagerRating = (HiddenField)e.Row.FindControl("lblManagerRating");
            DropDownList ddlRating = (DropDownList)e.Row.FindControl("ddlRating");
            BindRatingScale(ddlRating);
            var txtAddComment = (TextBox)e.Row.FindControl("txtAddComment");
            Label peerManager = (Label)e.Row.FindControl("lblIsPeerManager");
            Label peerCode = (Label)e.Row.FindControl("lblPeerCode");
            HtmlGenericControl divText = (HtmlGenericControl)e.Row.FindControl("isPeerText");
            if (lblManagerRating != null)
            {
                if (ddlRating.Items.FindByValue(lblManagerRating.Value) != null)
                {
                    ddlRating.ClearSelection();
                    ddlRating.Items.FindByValue(lblManagerRating.Value).Selected = true;
                }
            }
            if (peerManager.Text == "False" || peerCode.Text != SessionEmpCode)
            {
                ddlRating.Enabled = false;
                divText.Visible = false;
            }
            HtmlAnchor anchorAll = (HtmlAnchor)e.Row.FindControl("lnkViewAll");
            Label setting = (Label)e.Row.FindControl("lblKRASettingDetail");
            anchorAll.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&SettingId=" + setting.Text + "')";

            var query1 = String.Format(strKRAComment1, ViewState["KRAFormID"].ToString(), setting.Text);
            var query2 = String.Format(strKRAComment2, ViewState["KRAFormID"].ToString(), setting.Text);
            var count = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query1).Tables[0].Rows[0][0].ToString();
            if (count != "0")
            {
                anchorAll.Style["Color"] = "blue";
            }
            else
            {
                count = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query2).Tables[0].Rows[0][0].ToString();
                if (count != "0")
                {
                    anchorAll.Style["Color"] = "blue";
                }
            }
        }
    }

    private String strKRAComment1 = "Select count(Comment) from KRAFormDetail Where KRAFormId={0} and KRASettingDetailId={1} and isnull(Comment,'')!=''";
    private String strKRAComment2 = "Select count(Comment) from KRAFormRatingDetail Where KRAFormId={0} and KRASettingDetailId={1} and isnull(Comment,'')!=''";

    private void BindRatingScale(DropDownList drp)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["DtRating"];
        int from = Convert.ToInt32(dt.Rows[0][0].ToString());
        int to = Convert.ToInt32(dt.Rows[0][1].ToString());

        for (int i = from; i <= to; i++)
        {
            drp.Items.Insert(i - 1, new ListItem(i.ToString(), i.ToString()));
        }
    }
    protected void drpTrainingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpTrainingType.SelectedItem.Text == "Other")
        {
            txtt.Visible = true;
            txtTType.Visible = true;
            drpTraining.Visible = false;
        }
        else
        {
            txtt.Visible = false;
            txtTType.Visible = false;
            drpTraining.Visible = true;
            drpTraining.Items.Clear();
            DataTable dt = (DataTable)ViewState["Training"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "TrainingTypeId=" + drpTrainingType.SelectedValue;
            drpTraining.DataSource = dv;
            drpTraining.DataValueField = "Id";
            drpTraining.DataTextField = "Training";
            drpTraining.DataBind();
            drpTraining.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    List<KRATrainingDetailEntity> lstKRATrainingDetailEntity = new List<KRATrainingDetailEntity>();
    protected void btnAddTraining_Click(object sender, EventArgs e)
    {
        if (drpTrainingType.SelectedItem.Text == "Other")
        {
            var id = 0;
            id = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "Insert into KRATrainingTypeMaster(TrainingType) values('" + txtTType.Text + "') select @@IDENTITY").ToString());

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "Insert into KRATrainingMaster(TrainingTypeId,Training) values('" + id.ToString() + "','" + txtt.Text + "')");

            drpTrainingType.Items.Clear();
            drpTraining.Items.Clear();

            TrainingTabData();

            drpTrainingType.Items.FindByValue(id.ToString()).Selected = true;

            DataTable dt = (DataTable)ViewState["Training"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "TrainingTypeId=" + drpTrainingType.SelectedValue;
            drpTraining.DataSource = dv;
            drpTraining.DataValueField = "Id";
            drpTraining.DataTextField = "Training";
            drpTraining.DataBind();

            drpTraining.Items.FindByText(txtt.Text).Selected = true;

            BindValues();

            txtt.Visible = false;
            txtTType.Visible = false;

            txtTType.Text = txtt.Text = string.Empty;

            drpTraining.Visible = true;

        }
        else
        {
            if (drpTrainingType.SelectedIndex == 0)
            {
                General.Alert("Select Training Type", btnAddTraining);
                drpTrainingType.Focus();
                return;
            }

            if (drpTraining.SelectedIndex == 0)
            {
                General.Alert("Select Training", btnAddTraining);
                drpTraining.Focus();
                return;
            }
            BindValues();
        }
    }
    protected void BindValues(string commandText = "", int rowIndex = 0)
    {
        KRATrainingDetailEntity objEntity;
        if (string.IsNullOrEmpty(commandText))
        {
            objEntity = new KRATrainingDetailEntity();
            objEntity.TrainingTypeId = Convert.ToInt32(drpTrainingType.SelectedValue);
            objEntity.TrainingType = drpTrainingType.SelectedItem.Text;
            objEntity.TrainingId = Convert.ToInt32(drpTraining.SelectedValue);
            objEntity.Training = drpTraining.SelectedItem.Text;

            var isExists = IsExists(objEntity);

            if (!isExists)
            {
                lstKRATrainingDetailEntity.Add(objEntity);
            }
        }

        foreach (GridViewRow row in grdTraining.Rows)
        {
            Label lblTrainingType = (Label)row.FindControl("TrainingType");
            Label lblTrainingTypeId = (Label)row.FindControl("TrainingTypeId");
            Label lblTraining = (Label)row.FindControl("Training");
            Label lblTrainingId = (Label)row.FindControl("TrainingId");

            if (commandText != "rowDelete")
            {
                objEntity = new KRATrainingDetailEntity();

                objEntity.TrainingTypeId = Convert.ToInt32(lblTrainingTypeId.Text);
                objEntity.TrainingType = lblTrainingType.Text;
                objEntity.TrainingId = Convert.ToInt32(lblTrainingId.Text);
                objEntity.Training = lblTraining.Text;

                lstKRATrainingDetailEntity.Add(objEntity);
            }
            else
            {
                if (row.RowIndex != rowIndex)
                {
                    objEntity = new KRATrainingDetailEntity();

                    objEntity.TrainingTypeId = Convert.ToInt32(lblTrainingTypeId.Text);
                    objEntity.TrainingType = lblTrainingType.Text;
                    objEntity.TrainingId = Convert.ToInt32(lblTrainingId.Text);
                    objEntity.Training = lblTraining.Text;

                    lstKRATrainingDetailEntity.Add(objEntity);
                }
            }
        }

        grdTraining.DataSource = lstKRATrainingDetailEntity;
        grdTraining.DataBind();
    }
    private bool IsExists(KRATrainingDetailEntity objEntity)
    {
        bool isExists = false;
        foreach (GridViewRow row in grdTraining.Rows)
        {
            Label lblTrainingTypeId = (Label)row.FindControl("TrainingTypeId");
            Label lblTrainingId = (Label)row.FindControl("TrainingId");

            if (objEntity.TrainingTypeId == Convert.ToInt32(lblTrainingTypeId.Text) && objEntity.TrainingId == Convert.ToInt32(lblTrainingId.Text))
            {
                isExists = true;
                break;
            }
        }
        return isExists;
    }
    protected void grdTraining_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "rowDelete")
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowIndex = gvr.RowIndex;

            BindValues("rowDelete", RowIndex);
        }
    }
    protected void grdPromotion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label promotion = (Label)e.Row.FindControl("lblPromotion");
            HtmlAnchor anchor = (HtmlAnchor)e.Row.FindControl("allComments");

            anchor.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&SettingId=" + promotion.ToolTip.ToString() + "&Type=P')";
        }
    }
    private void BindHistoryComments()
    {
        query = String.Format(query, ViewState["KRAFormID"].ToString());
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

        grdHistory.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grdHistory.DataBind();

        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {
            grdPeerComments.DataSource = ds.Tables[1].Rows.Count > 0 ? ds.Tables[1] : null;
            grdPeerComments.DataBind();

            trPeerComments.Visible = true;

            foreach (GridViewRow grd in grdPeerComments.Rows)
            {
                Label status = (Label)grd.FindControl("Label26");
                Label cmmnt = (Label)grd.FindControl("Label28");

                if (status.Text.Contains(Session["EmpName"].ToString()))
                {
                    txtComment.Text = cmmnt.Text;
                    break;
                }
            }
        }
    }

    private string query = "Select 0 as LevelId,'User (Comment by: '+Dbo.GetEmpName(EmpCode)+')' as 'Status',Comment from KRAForm where Id={0} Union select KAH.LevelId,Case "
                 + " When KAH.LevelId=1 then 'Manager'+ ' (Comment by: '+dbo.GetEmpName(KAH.ApproverCode)+')'	"
                 + " When KAH.LevelId=2 then 'Reviewer'+ ' (Comment by: '+dbo.GetEmpName(KAH.ApproverCode)+')'	"
        //+ " When KAH.LevelId=3 then 'Manager for Final Submission'"
                 + " When KAH.LevelId=4 then 'Management' end as 'Status'"
         + " ,KAH.Comment from KRAForm KF inner join KRAFormApprovalHierarchy KAH"
         + " on KAH.KRAFormId=KF.Id Where KF.Id={0}  select 0 as LevelId,'Peer Manager (Comment by: '+Dbo.GetEmpName(Peer)+')' as 'Status',PeerComment Comment  from KRAFormDetail where KRAFormId={0} and ISNULL(Peer,'')!=''";

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }

    protected void chkPromotion_CheckedChanged(object sender, EventArgs e)
    {
        var chkBox = (CheckBox)sender;
        foreach (GridViewRow grdRow in grdPromotion.Rows)
        {
            var promotion = (Label)grdRow.FindControl("lblPromotion");
            var comments = (TextBox)grdRow.FindControl("txtComments");
            var chk = (CheckBox)grdRow.FindControl("chkPromotion");
            comments.Text = string.Empty;
            comments.Enabled = false;
            if (promotion.ToolTip.ToString() == chkBox.ToolTip.ToString() && chk.Checked == true)
            {
                comments.Enabled = true;
            }
            else
            {
                chk.Checked = false;
            }
        }
    }
}