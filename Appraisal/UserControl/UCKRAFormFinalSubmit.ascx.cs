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
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net;

public partial class Appraisal_UserControl_UCKRAFormFinalSubmit : BasePageUC<KRAFormEntity>
{
    KRAFormBAL _objBAL;
    bool isApprover = false;
    public Appraisal_UserControl_UCKRAFormFinalSubmit()
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
            TabContainer1.ActiveTabIndex = 0;
            ViewState["overAllRating"] = 0;
            if (Session["KRAFormID"] == null)
            {
                Response.Redirect("../User/welcome.aspx");
            }
            ViewState["KRAFormID"] = Session["KRAFormID"].ToString();
            ViewState["UserEmpCode"] = Session["UserEmpCode"].ToString();
            Session["KRAFormID"] = null;
            String sqlstrSuperviser = "select * from KRAForm KRF inner join KRAFormApprovalHierarchy KRFAH on KRF.CurrentLevel=KRFAH.LevelId and KRFAH.ApproverCode='" + SessionEmpCode + "' and KRF.Id='" + ViewState["KRAFormID"].ToString() + "'";
            DataSet dsApprover = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser);
            if (dsApprover.Tables[0].Rows.Count > 0)
            {
                isApprover = true;
                btnSubmit.Visible = true;
                btnDraft.Visible = true;
                btnClose.Visible = true;
                tblUserComment.Visible = true;
                //trPromoted.Visible = true;
                a3.Visible = true;
            }
            else
            {
                trPDF.Visible = true;
                tblUserComment.Visible = false;
            }
            FillControls();
            lblRatingOverall.Text = ViewState["overAllRating"].ToString();
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
            var myResult = result.FirstOrDefault();
            //tblUserComment.Visible = myResult.CurrentLevel == 0 ? false : true;
            ViewState["CurrentLevel"] = myResult.CurrentLevel;
            ViewState["KRASettingID"] = myResult.KRASettingId;
            ViewState["KRAFormID"] = myResult.Id;
            ViewState["EmpCode"] = myResult.CreatedBy;
            BindDataGridView(result, grdKRAForm);
            BindDataGridView(result, grdOverAllRating);

            DropDownList drpReview = ((DropDownList)EmployeeDetail1.FindControl("drpReviewPeriod"));
            Label lblReview = ((Label)EmployeeDetail1.FindControl("lblPeriod"));

            drpReview.Visible = false;
            lblReview.Text = myResult.KRADuration;

            ListTrainingDetail = myResult.KRATrainingDetail;

            BindPromotionCheckList();

            TrainingTabData();
            grdTraining.DataSource = null;
            grdTraining.DataBind();
            BindHistoryComments();

            if (myResult.IsDraft && myResult.CreatedBy == SessionEmpCode)
            {
                btnEdit.Visible = true;
                btnSubmit.Visible = false;
                btnDraft.Visible = false;
                btnClose.Visible = false;
                TabContainer1.Tabs[3].Visible = false;
                tblUserComment.Visible = false;
            }

            if (myResult.CreatedBy == SessionEmpCode)
            {
                tblUserComment.Visible = false;
            }

            ConfirmSupervisor();
        }
    }

    private void ConfirmSupervisor()
    {
        String sqlstrSuperviser = "declare @count int set @count = (select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1) set @count += (select count(*) from KRAFormDetail where ISNULL(IsPeerManager,0)=1 and Peer='" + Session["empcode"].ToString() + "') select @count";
        //String sqlstrSuperviser = "select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1 ";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser)) > 0)
        {

            TabContainer1.Tabs[2].Visible = true;
        }
        else
        {
            TabContainer1.Tabs[2].Visible = false;
        }
    }
    private void TrainingTabData()
    {
        String sqlstrSuperviser = "select * from [dbo].[KRATrainingTypeMaster] Select * from [dbo].[KRATrainingMaster] select TrainingName,CONVERT(varchar,FromDate,106)+' - '+CONVERT(varchar,ToDate,106) as Duration from AppraisalTrainingUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' and Status=1 select * from AppraisalSkillsUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' and ManagerRating!=0  Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + "  select distinct RecommendedBy as Status,TrainingDesc as Comments from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + "";
        DataSet dsTrining = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser);

        if (dsTrining.Tables[0].Rows.Count > 0)
        {
            drpTrainingType.DataSource = dsTrining.Tables[0];
            drpTrainingType.DataValueField = "Id";
            drpTrainingType.DataTextField = "TrainingType";
            drpTrainingType.DataBind();
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

            //if (ViewState["CurrentLevel"] != null && ViewState["CurrentLevel"].ToString() != "4")
            //{
            //    grdPK.Columns[5].Visible = false;
            //}
        }
    }
    protected void grdOverAllRating_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdDetails2");
            Label lblID = (Label)e.Row.FindControl("Label14");
            Label weightAge = (Label)e.Row.FindControl("Label13");

            ViewState["weightAge"] = weightAge.Text;


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

        strPromotionQuery = String.Format(strPromotionQuery, ViewState["KRAFormID"].ToString(), 4);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strPromotionQuery);

        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grdPromotion.Rows)
            {
                Label promotion = (Label)gRow.FindControl("Label7");
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
        a2.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&Level=0&Type=P')";
        a4.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&Level=2&Type=P')";
        a3.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&Level=4&Type=P')";
        printPDF.HRef = "JavaScript:newPopup1('PrintPDF.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&EmpCode=" + ViewState["UserEmpCode"].ToString() + "')";

    }

    private String strPromotionQuery = "select distinct AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status,"
    + " KFP.Comment"
    + " from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on"
    + " KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId inner join  "
    + " AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId "
    + " Where KFP.KRAFormId={0} and KFP.LevelId={1}";

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
            var count = 0;
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                General.Alert("Comments are mandatory.", btnSubmit);
                txtComment.Focus();
                TabContainer1.ActiveTabIndex = 0;
                return;
            }

            if (ViewState["CurrentLevel"] != null && ViewState["CurrentLevel"].ToString() != "3")
            {
                foreach (GridViewRow grdRow in grdPromotion.Rows)
                {
                    var promotion = (Label)grdRow.FindControl("Label7");
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
            }

            if (chkPromoted.Checked)
            {
                if (drpDesignation.SelectedIndex == 0)
                {
                    General.Alert("Select promoted designation", btnSubmit);
                    TabContainer1.ActiveTabIndex = 2;
                    return;
                }
            }

            Button btn = (Button)sender;

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
                kraForm.CurrentLevel = 4;
                kraForm.PromotedDesignation = chkPromoted.Checked ? Convert.ToInt32(drpDesignation.SelectedValue) : 0;
                kraForm.IsDraft = btn.ID == "btnDraft" ? true : false;
                decimal finalRating = 0;

                if (ViewState["CurrentLevel"] != null && ViewState["CurrentLevel"].ToString() == "4")
                {
                    #region Fetch Values from Grid View
                    foreach (GridViewRow row in grdKRAForm.Rows)
                    {
                        var grdPK = (GridView)row.FindControl("grdDetails");
                        var weight = (Label)row.FindControl("lblweightage");
                        foreach (GridViewRow rowDetail in grdPK.Rows)
                        {
                            var lblKRASettingDetail = (Label)rowDetail.FindControl("lblKRASettingDetail");
                            var txtAddComment = (TextBox)rowDetail.FindControl("txtAddComment");
                            DropDownList ddlRating = (DropDownList)rowDetail.FindControl("ddlRating");
                            Label txtW = (Label)rowDetail.FindControl("txtWeightage");
                            KRAFormDetailEntity formDetail = new KRAFormDetailEntity();
                            formDetail.KRAFormId = kraForm.Id;
                            formDetail.SelfRating = Convert.ToInt32(ddlRating.SelectedValue);
                            formDetail.Id = Convert.ToInt64(lblKRASettingDetail.Text);
                            formDetail.CreatedBy = SessionEmpCode;
                            formDetail.Comment = formDetail.ManagerComment = txtAddComment.Text;
                            formDetail.IsPeerManager = false;
                            formDetail.PeerManagerCode = "";

                            kraForm.KRAFormDetail.Add(formDetail);

                            finalRating += Math.Round(Convert.ToDecimal((Convert.ToDecimal(txtW.Text) * Convert.ToInt32(ddlRating.SelectedValue) * Convert.ToDecimal(weight.Text)) / 10000), 1);
                        }
                    }
                    #endregion
                }

                #region Fetch Values From Promotion Detail
                foreach (GridViewRow row in grdPromotion.Rows)
                {
                    Label lblPromotion = (Label)row.FindControl("Label7");
                    CheckBox chkPromotion = (CheckBox)row.FindControl("chkPromotion");
                    var txtPromotionComment = (TextBox)row.FindControl("txtComments");
                    if (txtPromotionComment != null && !String.IsNullOrEmpty(txtPromotionComment.Text))
                    {
                        var kraPromotion = new AppraisalPromotionEntity() { Comment = txtPromotionComment.Text, KRAFormID = kraForm.Id, PromotionId = Convert.ToInt32(lblPromotion.ToolTip), CreatedBy = SessionEmpCode, LevelId = 4, PostAction = chkPromotion.Checked };
                        kraForm.PromotionDetail.Add(kraPromotion);
                    }
                }
                #endregion

                kraForm.FinalRating = Math.Round(finalRating, 1);

                KRAFormBAL bal = new KRAFormBAL();
                DraftModeAction(kraForm.Id);
                if (bal.InsertKRARating(kraForm) > 0)
                {
                    if (!kraForm.IsDraft)
                        SendMail();
                    General.Alert("Appraisal Form updated successfully.", btnClose, "../Admin/AllAppraisalStatus.aspx?User=F");
                }
                else
                    General.Alert(ConfigHelper.MessageError, btnClose);
            }
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, btnClose);
        }
    }

    protected void SendMail()
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@kraFormId", ViewState["KRAFormID"].ToString());

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "GetAMSMails", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string ToEmail = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                    string password = ConfigurationManager.AppSettings["Password"].ToString();
                    NetworkCredential basicCredential = new NetworkCredential(userName, password);

                    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 25;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    smtpClient.EnableSsl = true;
                    message.To.Add(ToEmail.ToString());

                    Label lblUserName = ((Label)EmployeeDetail1.FindControl("lbl_emp_name"));

                    message.Subject = "Appraisal Notification – Appraisal process has been completed for " + lblUserName.Text;
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " <br> Appraisal Process has been completed at all levels.<br>Login to HCMS portal to view the appraisal rating.<br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    smtpClient.Send(message);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void DraftModeAction(Int64 kraFormId)
    {
        string queryDelete = "Delete from KRAFormRatingDetail where KRAFormId=" + kraFormId.ToString() + " and LevelId=4 Delete from KRAFormPromotion where KRAFormId=" + kraFormId.ToString() + " and LevelId=4";
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
    private String strComment = "Select top(1) Comment from KRAFormRatingDetail Where KRAFormId={0} and KRASettingDetailId={1} and LevelId=4";
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ratingDrp = (DropDownList)e.Row.FindControl("ddlRating");
            Label RR = (Label)e.Row.FindControl("reviewerRatingLabel");
            HtmlGenericControl divC = (HtmlGenericControl)e.Row.FindControl("comments");
            HtmlAnchor anchor = (HtmlAnchor)e.Row.FindControl("lnkViewAll");
            Label setting = (Label)e.Row.FindControl("lblKRASettingDetail");
            var txtAddComment = (TextBox)e.Row.FindControl("txtAddComment");
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnPeerCode");
            HtmlGenericControl divText = (HtmlGenericControl)e.Row.FindControl("isPeerText");

            if (!string.IsNullOrEmpty(hdn.Value))
            {
                divText.Visible = true;
            }

            if (ViewState["CurrentLevel"] != null && ViewState["CurrentLevel"].ToString() == "4")
            {
                BindRatingScale(ratingDrp);
                ratingDrp.Items.FindByValue(RR.Text).Selected = true;
                RR.Visible = false;
                ratingDrp.Visible = true;
            }
            else
            {
                divC.Visible = false;
            }
            anchor.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&SettingId=" + setting.Text + "')";

            var query1 = String.Format(strKRAComment1, ViewState["KRAFormID"].ToString(), setting.Text);
            var query2 = String.Format(strKRAComment2, ViewState["KRAFormID"].ToString(), setting.Text);
            var count = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query1).Tables[0].Rows[0][0].ToString();
            if (count != "0")
            {
                anchor.Style["Color"] = "blue";
            }
            else
            {
                count = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query2).Tables[0].Rows[0][0].ToString();
                if (count != "0")
                {
                    anchor.Style["Color"] = "blue";
                }
            }
            var queryComment = String.Format(strComment, ViewState["KRAFormID"].ToString(), setting.Text);
            var commentTable = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, queryComment).Tables[0];
            var comment = commentTable.Rows.Count > 0 ? commentTable.Rows[0][0].ToString() : "";
            if (!string.IsNullOrEmpty(comment))
                txtAddComment.Text = comment;
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
    protected void grdDetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label RR = (Label)e.Row.FindControl("lblRR");

            Label weightAge = (Label)e.Row.FindControl("lblWeightAge");
            Label overAllRating = (Label)e.Row.FindControl("lblOverAllRating");

            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnOverPeer");
            HtmlGenericControl divText = (HtmlGenericControl)e.Row.FindControl("isPeerText1");

            if (!string.IsNullOrEmpty(hdn.Value))
            {
                divText.Visible = true;
            }

            var headW = ViewState["weightAge"].ToString();

            if (!String.IsNullOrEmpty(RR.Text))
            {
                decimal rating = Math.Round((Convert.ToDecimal(weightAge.Text) * Convert.ToDecimal(RR.Text) * Convert.ToDecimal(headW.ToString())) / 10000, 1);

                overAllRating.Text = rating.ToString();

                decimal overAll = Convert.ToDecimal(ViewState["overAllRating"].ToString());
                overAll = overAll + rating;
                ViewState["overAllRating"] = overAll;
            }
        }
    }
    protected void drpTrainingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpTraining.Items.Clear();
        DataTable dt = (DataTable)ViewState["Training"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "TrainingTypeId=" + drpTrainingType.SelectedValue;
        drpTraining.DataSource = dv;
        drpTraining.DataValueField = "Id";
        drpTraining.DataTextField = "Training";
        drpTraining.DataBind();
    }
    List<KRATrainingDetailEntity> lstKRATrainingDetailEntity = new List<KRATrainingDetailEntity>();
    protected void btnAddTraining_Click(object sender, EventArgs e)
    {
        BindValues();
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
            Label promotion = (Label)e.Row.FindControl("Label7");
            TextBox comments = (TextBox)e.Row.FindControl("txtComments");
            HtmlAnchor anchor = (HtmlAnchor)e.Row.FindControl("allComments");

            if (ViewState["CurrentLevel"] != null && ViewState["CurrentLevel"].ToString() != "4")
            {
                comments.Visible = false;
            }

            anchor.HRef = "JavaScript:newPopup1('KRAComments.aspx?FormId=" + ViewState["KRAFormID"].ToString() + "&SettingId=" + promotion.ToolTip.ToString() + "&Type=P')";
        }
    }

    private void BindHistoryComments()
    {
        query = String.Format(query, ViewState["KRAFormID"].ToString());
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

        grdHistory.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grdHistory.DataBind();

        foreach (GridViewRow grd in grdHistory.Rows)
        {
            Label status = (Label)grd.FindControl("lblName");
            Label cmmnt = (Label)grd.FindControl("lblDuration");

            if (status.Text.Contains("Management"))
            {
                txtComment.Text = cmmnt.Text;
                break;
            }
        }

        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {
            grdPeerComments.DataSource = ds.Tables[1].Rows.Count > 0 ? ds.Tables[1] : null;
            grdPeerComments.DataBind();

            trPeerComments.Visible = true;
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
    protected void chkPromoted_CheckedChanged(object sender, EventArgs e)
    {
        drpDesignation.Items.Clear();
        drpDesignation.Visible = false;
        if (chkPromoted.Checked)
        {
            BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
            BindDropDowns(drpDesignation, binddrop.BindDropDowns(Session["CompanyId"].ToString(), "Designation"), "id", "designationname");
            drpDesignation.Visible = true;
        }
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    private string query = "Select 0 as LevelId,'User (Comment by: '+Dbo.GetEmpName(EmpCode)+')' as 'Status',Comment from KRAForm where Id={0} Union select KAH.LevelId,Case "
                 + " When KAH.LevelId=1 then 'Manager'+ ' (Comment by: '+dbo.GetEmpName(KAH.ApproverCode)+')'	"
                 + " When KAH.LevelId=2 then 'Reviewer'+ ' (Comment by: '+dbo.GetEmpName(KAH.ApproverCode)+')'	"
        //+ " When KAH.LevelId=3 then 'Manager for Final Submission'"
                 + " When KAH.LevelId=4 then 'Management' end as 'Status'"
         + " ,KAH.Comment from KRAForm KF inner join KRAFormApprovalHierarchy KAH"
         + " on KAH.KRAFormId=KF.Id Where KF.Id={0}   select 0 as LevelId,'Peer Manager (Comment by: '+Dbo.GetEmpName(Peer)+')' as 'Status',PeerComment Comment  from KRAFormDetail where KRAFormId={0} and ISNULL(Peer,'')!=''";

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Session["EditKRAID"] = ViewState["KRAFormID"];
        Response.Redirect("../User/CreateKRAForm.aspx");
    }

    protected void chkPromotion_CheckedChanged(object sender, EventArgs e)
    {
        var chkBox = (CheckBox)sender;
        foreach (GridViewRow grdRow in grdPromotion.Rows)
        {
            var promotion = (Label)grdRow.FindControl("Label7");
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