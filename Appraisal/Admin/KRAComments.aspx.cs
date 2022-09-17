using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_KRAComments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {

            string FormId = Request.QueryString["FormId"].ToString();


            if (Request.QueryString["Type"] != null)
            {
                string level = Request.QueryString["Level"].ToString();
                divKRA.Visible = false;
                strPromotionQuery = String.Format(strPromotionQuery, FormId, level);
                BindPromotions();
            }
            else
            {
                string SettingId = Request.QueryString["SettingId"].ToString();
                divPromotion.Visible = false;
                strKRAQuery = String.Format(strKRAQuery, FormId, SettingId);
                BindComments();
            }

        }

    }

    private void BindComments()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strKRAQuery);

        grdResult.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grdResult.DataBind();
    }

    private void BindPromotions()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strPromotionQuery);

        grdPromotion.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grdPromotion.DataBind();
    }

    private String strKRAQuery = "Select distinct * from("
    + "Select 'User' as 'Status',Comment from KRAFormDetail Where KRAFormId={0} and KRASettingDetailId={1}"
    + " Union "
    + " Select Case "
            + " When LevelId=1 then 'Manager Comment' "
            + " When LevelId=0 then 'Peer Manager Comment'	"
            + " When LevelId=2 then 'Reviewer Comment'	"
            + " When LevelId=4 then 'Management Comment' end as 'Status' "
    + ",Comment from KRAFormRatingDetail KRD Where KRAFormId={0} and KRASettingDetailId={1}) result";

    //private String strPromotionQuery = "select distinct AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status,"
    //+ " KFP.Comment"
    //+ " from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on"
    //+ " KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId inner join  "
    //+ " AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId "
    //+ " Where KFP.KRAFormId={0} and KFP.LevelId={1}";

    private String strPromotionQuery = @"select distinct 'Manager (Comment by: '+Dbo.GetEmpName(KFP.CreatedBy)+')' as 'User',AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status, KFP.Comment 
        from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId 
        inner join   AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId  Where KFP.KRAFormId={0} and KFP.LevelId=1

        union

        select 'Peer Manager (Comment by: '+Dbo.GetEmpName(KFP.CreatedBy)+')' as 'User',AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status, KFP.Comment 
        from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId 
        inner join   AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId  Where KFP.KRAFormId={0} and KFP.LevelId=0

        union

        select distinct 'Reviewer (Comment by: '+Dbo.GetEmpName(KFP.CreatedBy)+')' as 'User',AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status, KFP.Comment 
        from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId 
        inner join   AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId  Where KFP.KRAFormId={0} and KFP.LevelId=2

        union

        select distinct 'Management' as 'User',AP.Promotion,Case When KFP.PostAppraisalAction=0 then 'No' else 'Yes' end as Status, KFP.Comment 
        from KRAFormPromotion KFP left join KRAFormApprovalHierarchy KAH on KFP.CreatedBy=KAH.ApproverCode and KFP.KRAFormId=KAH.KRAFormId 
        inner join   AppraisalPromotion AP on AP.PromotionId=KFP.PromotionId  Where KFP.KRAFormId={0} and KFP.LevelId=4";
}