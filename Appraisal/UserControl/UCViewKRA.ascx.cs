using DataAccessLayer;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_UserControl_UCViewKRA : BasePageUC<KRASetting>
{
    KRAMasterBAL _objBAL;
    public Appraisal_UserControl_UCViewKRA()
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
    public Int64 CurrentKRAID
    {
        get;
        set;
    }

    void FillControls()
    {
        ViewState["CurrentKRAID"] = CurrentKRAID;
        var lst = _objBAL.SelectKRASettingByKRASettingID(CurrentKRAID);
        BindDataGridView(lst, grdKRAHead);

        DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
        Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

        drpReview.Visible = false;
        if (lst.Count > 0)
            lblReview.Text = lst.FirstOrDefault().KRADuration;

        tblApproverComment.Visible = false;
        if (_DataSet.Any())
        {
            txtUserComment.Text = _DataSet.FirstOrDefault().Comment;
            ManagerComments();
            if (_DataSet.FirstOrDefault().Status == "1")
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
            else
            {
                if (_DataSet.FirstOrDefault().ApproverCode == SessionEmpCode.ToLower())
                {
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                    tblApproverComment.Visible = true;
                }
                else
                {
                    if (_DataSet.FirstOrDefault().EmpCode == SessionEmpCode.ToLower())
                    {
                        btnApprove.Visible = false;
                        btnReject.Visible = false;
                        txtComment.Attributes.Add("readonly", "readonly");
                        if (_DataSet.FirstOrDefault().IsDraft)
                        {
                            btnEdit.Visible = true;
                        }
                    }
                }
            }
        }

    }

    private void ManagerComments()
    {
        String sqlstrComment = "If exists(select isnull(Comment,'') from KRASettingHistory where KRASettingID=" + ViewState["CurrentKRAID"].ToString() + ") Begin select isnull(Comment,'') from KRASettingHistory where KRASettingID=" + ViewState["CurrentKRAID"].ToString() + "  end Else Select ''";
        string comments = DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrComment).ToString();
        if (!string.IsNullOrEmpty(comments))
        {
            tblApproverComment.Visible = true;
            txtComment.Attributes.Add("readonly", "readonly");
            txtComment.Text = comments;
        }
        else
        {
            tblApproverComment.Visible = false;
        }
    }

    protected void grdKRAHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdSettingDetails");
            Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
            var intId = Convert.ToInt32(lblID.Text);
            if (grdPK != null)
            {
                var lst = _DataSet.Where(m => m.KRAHeadID == intId);
                List<KRASettingDetail> detail = lst.SelectMany(m => m.KRASettingDetails).ToList();
                if (detail != null)
                    grdPK.DataSource = detail;
                else
                    grdPK.DataSource = null;

                grdPK.DataBind();
            }
        }

    }
    public void SaveData(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        var txtApproverComment = txtComment.Text;
        if (string.IsNullOrEmpty(txtApproverComment))
        {
            General.Alert("Approver Comment can not be empty", new Control());
            return;
        }
        var entity = new KRAMasterEntity()
        {
            KRASettingID = Convert.ToInt64(ViewState["CurrentKRAID"]),
            EmpCode = SessionEmpCode,
            KRAComment = txtApproverComment,
            CreatedBy = SessionEmpCode,
            Status = btn.ID == btnReject.ID ? 2 : 1 // 2 As Rejected 1 As Approved
        };

        if (_objBAL.ApproveKRA(entity) > 0)
            General.Alert("Action taken Successfully", btnApprove, "AllKRAFormStatus.aspx");
        else
            General.Alert("An error occurred", btnReject, "AllKRAFormStatus.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Items["CurrentKRAID"] = ViewState["CurrentKRAID"].ToString();
        Server.Transfer("KRASetting.aspx");
    }
}