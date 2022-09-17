using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DTUtility;


public partial class Recruitment_User_Viewdraft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GvResultBind();


    }

    protected void Grid_Cndidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Savedraft")
        {
            Session["Candidate_Id"] = e.CommandArgument.ToString();
            Response.Redirect("UploadResume.aspx");
        }
    }


    protected void GvResultBind()
    {
        if(string.IsNullOrEmpty(ApplicationStartupSetting._connectionString))
        {

            ApplicationStartupSetting.RecounsructMe();
        }

        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString,"usp_Getsaveasdraft");
        Grid_draft.DataSource = ds;
        Grid_draft.DataBind();

    
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CandidateSaveasDraft obj = new CandidateSaveasDraft();
        SaveasDraftserchmember objsearchDraft = new SaveasDraftserchmember();
        objsearchDraft.Name = txtCandidateID.Text;
        objsearchDraft.FramDate = txt_FromDate.Text;
        objsearchDraft.Todate = txt_Todate.Text;
        DataSet ds = obj.CandidatesaveasDrat(objsearchDraft.Name, objsearchDraft.FramDate, objsearchDraft.Todate);
        if (ds.Tables[0].Rows.Count != 0)
        {
            Grid_draft.DataSource = ds;
            Grid_draft.DataBind();
        }
        else
        {
            Grid_draft.DataSource = null;
            Grid_draft.DataBind();
           ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Record not found..!');", true);
        }
         
      
      
    }
}