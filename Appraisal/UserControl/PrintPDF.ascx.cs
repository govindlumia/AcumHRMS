using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Appraisal;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Appraisal_UserControl_PrintPDF : BasePageUC<KRAFormEntity>
{
    KRAFormBAL _objBAL;

    public Appraisal_UserControl_PrintPDF()
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
            try
            {
                if (Request.QueryString.HasKeys())
                {
                    if (Request.QueryString["FormId"] != null)
                    {
                        ViewState["KRAFormID"] = Request.QueryString["FormId"].ToString();
                        ViewState["UserEmpCode"] = Request.QueryString["EmpCode"].ToString();
                    }
                }
                bind_job_detail(ViewState["UserEmpCode"].ToString());
                ViewState["overall"] = 0;
                FillControls();
                lblScore.Text = ViewState["overall"].ToString();
            }
            catch (Exception ex)
            {
                General.Alert(ex.Message, btnPDF);
            }                   
        }
    }
    protected void bind_job_detail(string emp_code)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();
        //companyname	companyid	empcode	card_no	emp_gender	emp_fname	emp_m_name	emp_l_name	emp_status	employeestatus	Status	
        //degination_id	designationname	Job_type	DesgCode	category	CategoryName	HomeBU	HomeBUnit	SecondaryBU	SecondaryBUnit
        //photo	login_id	role1	role	emp_doj	salary_cal_from	emp_doleaving	emp_doreleiving
        userentity.Empcode = emp_code;
        DataSet ds = objSelectALL.SelectJobDetails(userentity);
        DataTable dt;
        dt = ds.Tables[0];

        if (dt.Rows.Count < 1)
            return;

        lbl_emp_name.Text = dt.Rows[0]["emp_fname"].ToString() + " " + Convert.ToString(dt.Rows[0]["emp_l_name"]);
        lbl_emp_code.Text = dt.Rows[0]["empcode"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["emp_doj"].ToString()))
        {
            lbl_dated.Text = Convert.ToDateTime(dt.Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            lbl_dated.Text = "--NA--";
        }


        lbl_Designation.Text = dt.Rows[0]["designationname"].ToString();
        lbl_department.Text = dt.Rows[0]["CategoryName"].ToString();

        if (ds.Tables[1].Rows.Count > 0)
        {
            lblExp.Text = ds.Tables[1].Rows[0][0].ToString();
        }

    }
    void PrintPDF()
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Appraisal.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            kraDiv.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize._11X17, 10f, 10f, 0f, 0f);
            //Document pdfDoc = new Document(PageSize._11X17, 10f, 10f, 50f, 20f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, btnPDF);
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
            ViewState["CurrentLevel"] = myResult.CurrentLevel;
            ViewState["KRASettingID"] = myResult.KRASettingId;
            ViewState["KRAFormID"] = myResult.Id;
            ViewState["EmpCode"] = myResult.CreatedBy;
            BindDataGridView(result, grdOverAllRating);
            lblPeriod.Text = myResult.KRADuration;

            ListTrainingDetail = myResult.KRATrainingDetail;

            //BindPromotionCheckList();

            TrainingTabData();
            BindHistoryComments();
            BindKRAComments();
        }
    }
    private void BindKRAComments()
    {
        SqlParameter pmtrKRAFormId = new SqlParameter();
        pmtrKRAFormId.ParameterName = "@KRAFormId";
        pmtrKRAFormId.SqlDbType = SqlDbType.BigInt;
        pmtrKRAFormId.Value = Convert.ToInt32(ViewState["KRAFormID"].ToString());

        SqlParameter[] objParameter = new SqlParameter[1];
        objParameter[0] = pmtrKRAFormId;
        DataSet dsKRAComments = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "GetKRAComments", objParameter);

        grdKCommentsHistory.DataSource = dsKRAComments.Tables[0].Rows.Count > 0 ? dsKRAComments.Tables[0] : null;
        grdKCommentsHistory.DataBind();

        grdPromotion.DataSource = dsKRAComments.Tables[1].Rows.Count > 0 ? dsKRAComments.Tables[1] : null;
        grdPromotion.DataBind();

    }

    private void TrainingTabData()
    {
        String sqlstrSuperviser = "select * from [dbo].[KRATrainingTypeMaster] Select * from [dbo].[KRATrainingMaster] select TrainingName,CONVERT(varchar,FromDate,106)+' - '+CONVERT(varchar,ToDate,106) as Duration from AppraisalTrainingUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' select * from AppraisalSkillsUpdate where CreatedBy='" + ViewState["UserEmpCode"].ToString() + "' and ManagerRating!=0  Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + " and RecommendedBy='User'  Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + " and RecommendedBy='Manager'  Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + " and RecommendedBy='Reviewer'   Select * from KRATrainingDetail where KRAFormId=" + ViewState["KRAFormID"].ToString() + "";
        DataSet dsTrining = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser);

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

        grdTManager.DataSource = dsTrining.Tables[5].Rows.Count > 0 ? dsTrining.Tables[5] : null;
        grdTManager.DataBind();

        grdTReviewer.DataSource = dsTrining.Tables[6].Rows.Count > 0 ? dsTrining.Tables[6] : null;
        grdTReviewer.DataBind();

        grdTComments.DataSource = dsTrining.Tables[7].Rows.Count > 0 ? dsTrining.Tables[7] : null;
        grdTComments.DataBind();
    }
    protected void grdOverAllRating_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdDetails2");
            Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
            Label weight = (Label)e.Row.FindControl("lblweightage");


            ViewState["weight"] = weight.Text;

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

        master.CanDelete = true;

        ListTrainingDetail.Add(master);

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
    private void BindRatingScale(DropDownList drp)
    {
    }
    protected void grdDetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label RR = (Label)e.Row.FindControl("lblRR");

            Label weightAge = (Label)e.Row.FindControl("Label8");
            Label overAllRating = (Label)e.Row.FindControl("lblOverAllRating");

            if (!String.IsNullOrEmpty(RR.Text))
            {
                decimal rating = Math.Round((Convert.ToDecimal(weightAge.Text) * Convert.ToDecimal(RR.Text) * Convert.ToDecimal(ViewState["weight"].ToString())) / 10000, 1);

                overAllRating.Text = rating.ToString();

                decimal total = Convert.ToDecimal(ViewState["overall"].ToString());

                total += rating;
                ViewState["overall"] = total;
            }
        }
    }
    protected void grdPromotion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    private void BindHistoryComments()
    {
        query = String.Format(query, ViewState["KRAFormID"].ToString());
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

        grdHistory.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grdHistory.DataBind();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }

    private string query = "select distinct Case "
                + " When KAH.LevelId=1 then 'Manager Comment'	"
                + " When KAH.LevelId=2 then 'Reviewer Comment'	"
                + " When KAH.LevelId=4 then 'Management Comment' end as 'Status'"
        + " ,KAH.Comment from KRAForm KF inner join KRAFormApprovalHierarchy KAH"
        + " on KAH.KRAFormId=KF.Id Where KF.Id={0} Union Select 'User',Comment from KRAForm where Id={0}";
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        PrintPDF();
    }
}