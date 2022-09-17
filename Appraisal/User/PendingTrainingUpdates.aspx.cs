using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Appraisal_User_PendingTrainingUpdates : System.Web.UI.Page
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
            BinData();
        }
    }

    protected void BinData(string EmpName = "", string status = "")
    {
        DataSet ds = GetByApprover(EmpName, status);
        if (ds.Tables[0].Rows.Count > 0)
            grdPending.DataSource = ds.Tables[0];
        else
            grdPending.DataSource = null;


        grdPending.DataBind();

        if (ds.Tables[1].Rows.Count > 0)
            grdApproved.DataSource = ds.Tables[1];
        else
            grdApproved.DataSource = null;

        grdApproved.DataBind();
    }

    protected DataSet GetByApprover(string EmpName, string status)
    {
        TrainingEntity objEntity = new TrainingEntity();
        TrainingBAL objBAL = new TrainingBAL();
        objEntity.EmployeeName = EmpName;
        objEntity.Status = status;
        objEntity.CreatedBy = Session["EmpCode"].ToString();
        DataSet ds = objBAL.GetByApprover(objEntity);

        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        TrainingEntity objEntity = new TrainingEntity();
        TrainingBAL objBAL = new TrainingBAL();
        foreach (GridViewRow grdRow in grdPending.Rows)
        {
            CheckBox chk = (CheckBox)grdRow.FindControl("chkBox");
            Label trainingId = (Label)grdRow.FindControl("lblTrainingName");
            if (chk.Checked)
            {
                objEntity.Id = Convert.ToInt32(trainingId.ToolTip);
                objBAL.UpdateTrainingStatusById(objEntity);
            }
        }

        BinData();
    }
    protected void grdPending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnValue");
            HtmlAnchor lnkV = (HtmlAnchor)e.Row.FindControl("lnkView");

            lnkV.HRef = "JavaScript:newPopup1('TrainingDetail.aspx?Id=" + Convert.ToInt32(hdn.Value) + "')";
        }
    }
    protected void grdApproved_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnValue");
            HtmlAnchor lnkV = (HtmlAnchor)e.Row.FindControl("lnkView");

            lnkV.HRef = "JavaScript:newPopup1('TrainingDetail.aspx?Id=" + Convert.ToInt32(hdn.Value) + "')";
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        BinData(txtSName.Text, "0");
    }
    protected void btnSearchApproved_Click(object sender, EventArgs e)
    {
        BinData(txtAName.Text, "1");
    }
    protected void grdApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdApproved.PageIndex = e.NewPageIndex;
        BinData();
    }
    protected void grdPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPending.PageIndex = e.NewPageIndex;
        BinData();
    }
}