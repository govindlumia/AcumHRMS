using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;
using System.IO;
using QueryStringEncryption;

public partial class Recruitment_User_CanSkillMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["EmpCode"])))
            {
                Response.Redirect("~/Login.aspx");
            }
            BindSkills();
        }
    }

    protected void lnkCreateView_Click(object sender, EventArgs e)
    {
        if (lnkCreateView.Text.Equals("Create"))
        {
            divCreate.Style["display"] = "block";
            divView.Style["display"] = "none";
            lnkCreateView.Text = "View";
        }
        else
        {
            divCreate.Style["display"] = "none";
            divView.Style["display"] = "block";
            lnkCreateView.Text = "Create";
        }
        txtSName.Text = string.Empty;
    }

    protected void BindSkills()
    {
        EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjEvalSkillParaENT.Dsca = txtSkillSearch.Text.Trim();
        ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjRoundBusiness.Select_SkillMaster(ObjEvalSkillParaENT);

        grdResult.DataSource = ds;
        grdResult.DataBind();

        divCreate.Style["display"] = "none";
        divView.Style["display"] = "block";
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjEvalSkillParaENT.Dsca = txtSName.Text.Trim();
        ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();

        string re = ObjRoundBusiness.Create_SkillMaster(ObjEvalSkillParaENT);

        if (re == "1")
        {
            General.Alert("Skill Created Successfully", this);
            txtSkillSearch.Text = "";
            txtSName.Text = "";
            lnkCreateView.Text = "Create";
            BindSkills();
        }
        else
            General.Alert("Skill Already Exists", this);
    }

    protected void grdResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdResult.EditIndex = e.NewEditIndex;
        BindSkills();
    }
    protected void grdResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdResult.EditIndex = -1;
        BindSkills();
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BindSkills();
    }
    protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        TextBox txtSkillName = (TextBox)grdResult.Rows[e.RowIndex].FindControl("txtSkillName");
        Label lblID = (Label)grdResult.Rows[e.RowIndex].FindControl("lblID");

        if (txtSkillName.Text.Trim() != string.Empty)
        {
            ObjEvalSkillParaENT.ID = lblID.Text;
            ObjEvalSkillParaENT.Dsca = txtSkillName.Text.Trim();
            ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();

            string _result = ObjRoundBusiness.Update_SkillMaster(ObjEvalSkillParaENT);

            if (_result.Equals("1"))
            {
                grdResult.EditIndex = -1;
                BindSkills();
                General.Alert("Skill Name Updated Successfully", this);
            }
            else
            {
                General.Alert("Skill Already Exists", this);
            }
        }
        else
        {
            General.Alert("Please Insert Skill name", this);
            return;
        }
    }

    protected void grdResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lnkStatus = (Label)e.Row.FindControl("lnkStatus");
            LinkButton lnk_disable = (LinkButton)e.Row.FindControl("lnk_disable");
            LinkButton lnk_enable = (LinkButton)e.Row.FindControl("lnk_enable");

            if (lnkStatus.Text == "True")
            {
                lnkStatus.Text = "Enable";
                lnk_disable.Visible = true;
                lnk_enable.Visible = false;
            }
            else
            {
                lnkStatus.Text = "Disable";
                lnk_disable.Visible = false;
                lnk_enable.Visible = true;
            }
        }
    }

    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("disable"))
        {
            EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjEvalSkillParaENT.ID = e.CommandArgument.ToString();
            ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();
            ObjEvalSkillParaENT.Status = "0";

            string result = ObjRoundBusiness.Update_SkillMasterStatus(ObjEvalSkillParaENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindSkills();
                return;
            }
            else if (result.Equals("Error"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorinstatus", "alert('Error occur,try again');", true);
                return;
            }
        }
        if (e.CommandName.Equals("enable"))
        {
            EvalSkillParaENT ObjEvalSkillParaENT = new EvalSkillParaENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjEvalSkillParaENT.ID = e.CommandArgument.ToString();
            ObjEvalSkillParaENT.EmpCode = Session["EmpCode"].ToString();
            ObjEvalSkillParaENT.Status = "1";

            string result = ObjRoundBusiness.Update_SkillMasterStatus(ObjEvalSkillParaENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindSkills();
                return;
            }
            else if (result.Equals("Error"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorinstatus", "alert('Error occur,try again');", true);
                return;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindSkills();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSkillSearch.Text = "";
        BindSkills();
    }
}