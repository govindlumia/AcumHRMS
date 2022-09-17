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
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

public partial class Appraisal_UserControl_UCKRAForm : BasePageUC<KRASetting>
{

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

            CommonClass obj = new CommonClass();
            DataTable dt = new DataTable();
            dt = obj.RatingScale();
            ViewState["DtRating"] = dt;

            var isPeriodCheck = true;

            if (Session["EditKRAID"] != null)
            {
                ViewState["EditKRAID"] = Session["EditKRAID"].ToString();
                Session["EditKRAID"] = null;
                FillControlForEdit();
                isPeriodCheck = false;
            }

            FillControls();
            if (isPeriodCheck)
                PeriodCheck();
        }
    }

    void FillControlForEdit()
    {
        KRAFormBAL _objBAL = new KRAFormBAL();
        List<KRAFormEntity> result = _objBAL.SelectKRAFormByFormID(Convert.ToInt64(ViewState["EditKRAID"]));
        if (result != null && result.Any())
        {
            ViewState["KRAFormEntity"] = result;
            txtComment.Text = result.FirstOrDefault().Comment;
            if (result.FirstOrDefault().KRATrainingDetail.Any())
                txtTC.Text = result.FirstOrDefault().KRATrainingDetail.FirstOrDefault().TrainingDesc;
        }
    }

    private void PeriodCheck()
    {
        AppraisalPeriodBAL objPeriodBAL = new AppraisalPeriodBAL();
        DataTable dt = objPeriodBAL.AppraisalPeriodCompanyEmployee(Session["CompanyId"].ToString(), Session["EmpCode"].ToString(), 1);

        if (dt.Rows.Count > 0)
        {
            if (dt.Columns.Contains("Error"))
            {
                General.Alert("You have already submitted Appraisal form for the current period.", btnSubmit, "welcome.aspx");
            }
            else
            {
                DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
                Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

                drpReview.DataSource = dt;
                drpReview.DataValueField = "Year";
                drpReview.DataTextField = "Duration";
                drpReview.DataBind();

                if (dt.Rows.Count == 1)
                {
                    drpReview.Enabled = false;
                }

                if (dt.Rows[0]["RM2"] == null && string.IsNullOrEmpty(dt.Rows[0]["RM2"].ToString()))
                {
                    General.Alert("Reviewer does not exists please contact HR Admin.", btnSubmit, "welcome.aspx");
                }
            }
        }
        else
        {
            General.Alert("KRA does not exists please contact HR Admin.", btnSubmit, "welcome.aspx");
        }
    }
    void FillControls()
    {
        KRAMasterBAL objBAL = new KRAMasterBAL();
        var lst = objBAL.SelectKRAForm(SessionEmpCode);
        if (lst != null && lst.Any())
        {
            ViewState["KRASettingID"] = lst.FirstOrDefault().ID;

            DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
            Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

            drpReview.Visible = false;
            lblReview.Text = lst.FirstOrDefault().KRADuration;
            BindDataGridView(lst, grdKRAHead);
            AddDefaultRow();
            TrainingTabData();
        }
        else
        {
            KRASettingMasterEntity objEntity = new KRASettingMasterEntity();
            objEntity.CompanyId = Convert.ToInt32(Session["CompanyId"].ToString());
            objEntity.DesignationId = 4;//Convert.ToInt32(Session["DesignationId"].ToString());

            DataSet dsResult = objBAL.KTASettingMasterData(objEntity, 1);
            if (dsResult.Tables[0].Rows.Count == 0)
            {
                General.Alert("KRA does not exists, contact HR admin.", btnSubmit, "welcome.aspx");
            }
            else
            {
                General.Alert("There is no active appraisal. Please contact HR admin", btnSubmit, "welcome.aspx");
            }
        }
    }
    private void TrainingTabData()
    {
        String sqlstrSuperviser = "select * from [dbo].[KRATrainingTypeMaster] where IsActive=1 Select * from [dbo].[KRATrainingMaster] select TrainingName,CONVERT(varchar,FromDate,106)+' - '+CONVERT(varchar,ToDate,106) as Duration from AppraisalTrainingUpdate where CreatedBy='" + Session["EmpCode"].ToString() + "' and Status=1 select * from AppraisalSkillsUpdate where CreatedBy='" + Session["EmpCode"].ToString() + "' and ManagerRating!=0";
        if (ViewState["EditKRAID"] != null)
        {
            sqlstrSuperviser += "select * from KRATrainingDetail where KRAFormId='" + ViewState["EditKRAID"].ToString() + "'";
        }
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

        if (dsTrining.Tables.Count > 4)
        {
            grdTraining.DataSource = dsTrining.Tables[4].Rows.Count > 0 ? dsTrining.Tables[4] : null;
            grdTraining.DataBind();
        }

    }
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
            }

        }

    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdDetails");
            Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
            Label lblweightage = (Label)e.Row.FindControl("lblweightage");

            lblweightage.Text = Math.Round(Convert.ToDecimal(lblweightage.Text), 0).ToString();

            var intId = Convert.ToInt32(lblID.Text);
            if (grdPK != null)
            {
                if (ViewState["KRAFormEntity"] == null)
                {
                    var lst = _DataSet.Where(m => m.KRAHeadID == intId);
                    List<KRASettingDetail> detail = lst.SelectMany(m => m.KRASettingDetails).ToList();
                    if (detail != null)
                        grdPK.DataSource = detail;
                    else
                        grdPK.DataSource = null;

                    grdPK.DataBind();
                }
                else
                {
                    var lst = (List<KRAFormEntity>)ViewState["KRAFormEntity"];
                    var lstEntity = lst.Where(m => m.KRAHeadID == intId);
                    List<KRAFormDetailEntity> detail = lstEntity.SelectMany(m => m.KRAFormDetail).ToList();
                    if (detail != null)
                        grdPK.DataSource = detail;
                    else
                        grdPK.DataSource = null;

                    grdPK.DataBind();
                }

            }
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drp = (DropDownList)e.Row.FindControl("ddlRating");
            Label lblSelfRD = (Label)e.Row.FindControl("lblSelfRD");
            BindRatingScale(drp);

            if (lblSelfRD.Text != "0")
            {
                drp.Items.FindByText(lblSelfRD.Text).Selected = true;
            }
        }
    }

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

    void AddDefaultRow()
    {
        KRATrainingDetailEntity master = new KRATrainingDetailEntity();
    }

    public void AddRow(object sender, EventArgs e)
    {
        BindValues(grdTraining);
        AddDefaultRow();
        //BindTrainingValues();
    }
    protected void grdTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView grd = (GridView)sender;

        if (e.CommandName == "DeleteRecord")
        {
            BindValues(grd, Convert.ToInt32(e.CommandArgument), "Delete");
            //BindTrainingValues();
        }
    }

    public void SavaData(object sender, EventArgs e)
    {
        userControlEmployee.Focus();
        Button btn = (Button)sender;

        if (string.IsNullOrEmpty(txtComment.Text))
        {
            General.Alert("Comments is mandatory.", btnSubmit);
            TabContainer1.ActiveTabIndex = 0;
            txtComment.Focus();
            return;
        }

        KRAFormEntity kraForm = new KRAFormEntity();
        kraForm.IsDraft = btn.ID == btnDraft.ID ? true : false;
        kraForm.KRASettingId = Convert.ToInt64(ViewState["KRASettingID"]);
        kraForm.Comment = txtComment.Text;
        kraForm.CreatedBy = kraForm.EmpCode = SessionEmpCode;
        kraForm.KRAFormDetail = new List<KRAFormDetailEntity>();
        kraForm.KRATrainingDetail = new List<KRATrainingDetailEntity>();

        if (ViewState["EditKRAID"] != null)
        {
            String sqlstrSuperviser = "delete from KRAFormDetail where KRAFormId='" + ViewState["EditKRAID"].ToString() + "' delete from KRAFormApprovalHierarchy where KRAFormId='" + ViewState["EditKRAID"].ToString() + "' delete from KRAFormRatingDetail where KRAFormId='" + ViewState["EditKRAID"].ToString() + "' delete from KRATrainingDetail where KRAFormId='" + ViewState["EditKRAID"].ToString() + "'";
            DataSet dsTrining = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser);
            kraForm.Id = Convert.ToInt64(ViewState["EditKRAID"].ToString());
        }

        foreach (GridViewRow row in grdTraining.Rows)
        {
            Label lblTrainingType = (Label)row.FindControl("TrainingType");
            Label lblTrainingTypeId = (Label)row.FindControl("TrainingTypeId");
            Label lblTraining = (Label)row.FindControl("Training");
            Label lblTrainingId = (Label)row.FindControl("TrainingId");
            var kraTraining = new KRATrainingDetailEntity() { TrainingTypeId = Convert.ToInt32(lblTrainingTypeId.Text), TrainingType = lblTrainingType.Text, TrainingId = Convert.ToInt32(lblTrainingId.Text), Training = lblTraining.Text };
            kraTraining.TrainingDesc = txtTC.Text;
            kraTraining.ApproverCode = "User";
            kraForm.KRATrainingDetail.Add(kraTraining);
        }

        #region Fetch Values from Grid View
        foreach (GridViewRow row in grdKRAHead.Rows)
        {
            var grdPK = (GridView)row.FindControl("grdDetails");
            foreach (GridViewRow rowDetail in grdPK.Rows)
            {
                var lblKRASettingDetail = (Label)rowDetail.FindControl("lblKRASettingDetail");
                var txtAddComment = (TextBox)rowDetail.FindControl("txtAddComment");
                DropDownList ddlRating = (DropDownList)rowDetail.FindControl("ddlRating");

                KRAFormDetailEntity formDetail = new KRAFormDetailEntity();
                formDetail.SelfRating = Convert.ToInt32(ddlRating.SelectedValue);
                formDetail.KRASettingDetailId = Convert.ToInt64(lblKRASettingDetail.Text);
                formDetail.Comment = txtAddComment.Text;
                kraForm.KRAFormDetail.Add(formDetail);
            }
        }
        #endregion

        KRAFormBAL bal = new KRAFormBAL();
        int kraFormId = bal.Create(kraForm);
        if (!kraForm.IsDraft)
            SendMail(kraFormId.ToString());
        var msg = kraForm.IsDraft ? "Record save successfully." : "Appraisal has been submitted successfully.";
        General.Alert(msg, btnSubmit, "ViewKRAFormStatus.aspx");
    }

    protected void SendMail(string kraFormId)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@kraFormId", kraFormId);

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

                    message.Subject = "Appraisal Notification – Appraisal Submitted for Approval by " + Session["EmpName"].ToString();
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[0].Rows[0]["EmpName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has submitted his appraisal.<br>Login to HCMS portal to proceed with appraisal process.<br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
    protected void btnNextP_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 0;
    }
}