using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_PendingSkills : System.Web.UI.Page
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
            GetSkillsForRM();
        }
    }

    protected void GetSkillsForRM(string EmpName = "", string status = "")
    {
        SkillsEntity objEntity = new SkillsEntity();
        SkillsBAL objBAL = new SkillsBAL();
        objEntity.CreatedBy = Session["EmpCode"].ToString();
        objEntity.EmployeeName = EmpName;
        objEntity.Status = status;
        DataSet dsResult = new DataSet();
        dsResult = objBAL.GetSkillsForRM(objEntity);

        //Table 0 contains Pending Request
        grdResult.DataSource = dsResult.Tables[0];
        grdResult.DataBind();

        //Table 1 contains Approved Request
        grdApproved.DataSource = dsResult.Tables[1];
        grdApproved.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SkillsEntity objEntity = new SkillsEntity();
        SkillsBAL objBAL = new SkillsBAL();
        int count = 0;
        foreach (GridViewRow grdRow in grdResult.Rows)
        {
            CheckBox chk = (CheckBox)grdRow.FindControl("chk");
            if (chk != null && chk.Checked)
            {
                count++;
                HiddenField hdn = (HiddenField)grdRow.FindControl("hdnId");
                DropDownList drpMR = (DropDownList)grdRow.FindControl("ddlMR");
                objEntity.Id = Convert.ToInt32(hdn.Value);
                objEntity.ManagerRating = Convert.ToInt32(drpMR.SelectedValue);

                objBAL.UpdateSkillsRating(objEntity);

                General.Alert("Records Approved Successfully.", btnUpdate);
            }
        }

        if (count == 0)
        {
            General.Alert("Select atleast one record.", btnUpdate);
        }

        GetSkillsForRM();
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        GetSkillsForRM();
    }
    protected void grdApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdApproved.PageIndex = e.NewPageIndex;
        GetSkillsForRM();
    }
    protected void btnPSearch_Click(object sender, EventArgs e)
    {
        GetSkillsForRM(txtPName.Text, "0");
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        GetSkillsForRM(txtSName.Text, "1");
    }
}