using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_SkillsUpdate : System.Web.UI.Page
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
            CreateTempTable();
            btnSubmit.Visible = false;
        }
    }

    protected void CreateTempTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Id", typeof(Guid)));
        dt.Columns.Add(new DataColumn("Skills", typeof(String)));
        dt.Columns.Add(new DataColumn("SelfRating", typeof(Int32)));
        ViewState["tempTable"] = dt;
    }

    protected void BinData()
    {
        DataTable dtResult = GetAllByUser();
        if (dtResult.Rows.Count > 0)
        {
            grdResult.DataSource = dtResult;
            grdResult.DataBind();
        }
        else
        {
            grdResult.DataSource = null;
            grdResult.DataBind();
        }
    }

    protected DataTable GetAllByUser()
    {
        SkillsEntity objEntity = new SkillsEntity();
        SkillsBAL objBAL = new SkillsBAL();

        objEntity.CreatedBy = Session["EmpCode"].ToString();
        DataTable dt = objBAL.GetByUser(objEntity);

        return dt;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["tempTable"];

        DataRow dr = dt.NewRow();
        dr["Id"] = new Guid();
        dr["Skills"] = txtSkills.Text;
        dr["SelfRating"] = Convert.ToInt32(ddlSelfRating.SelectedValue);

        dt.Rows.Add(dr);

        grdAdd.DataSource = dt;
        grdAdd.DataBind();

        ViewState["tempTable"] = dt;
        btnSubmit.Visible = true;
        Reset();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void Reset()
    {
        txtSkills.Text = string.Empty;
        ddlSelfRating.SelectedIndex = 0;
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Reset();
        trView.Visible = true;
        trCreate.Visible = false;
        btnCreate.Visible = true;
        btnView.Visible = false;
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Reset();
        trView.Visible = false;
        trCreate.Visible = true;
        btnCreate.Visible = false;
        btnView.Visible = true;
    }
    protected void grdAdd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            var id = e.CommandArgument.ToString();

            DataTable dt = (DataTable)ViewState["tempTable"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Id"].ToString() == id)
                {
                    dt.Rows.Remove(dt.Rows[i]);
                    dt.AcceptChanges();
                    break;
                }
            }

            grdAdd.DataSource = dt;
            grdAdd.DataBind();

            btnSubmit.Visible = dt.Rows.Count > 0 ? true : false;

            ViewState["tempTable"] = dt;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SkillsEntity objEntity = new SkillsEntity();
        SkillsBAL objBAL = new SkillsBAL();

        foreach (GridViewRow grdRow in grdAdd.Rows)
        {
            Label skills = (Label)grdRow.FindControl("lblSkills");
            Label SR = (Label)grdRow.FindControl("lblSR");
            objEntity.Skills = skills.Text;
            objEntity.Competencies = "";
            objEntity.SelfRating = Convert.ToInt32(SR.Text);
            objEntity.CreatedBy = Session["EmpCode"].ToString();
            objBAL.Create(objEntity);

        }

        Reset();
        trView.Visible = true;
        trCreate.Visible = false;
        btnCreate.Visible = true;
        btnView.Visible = false;
        General.Alert("Record submitted successfully.", btnAdd);
        CreateTempTable();
        grdAdd.DataSource = null;
        grdAdd.DataBind();
        btnSubmit.Visible = false;
        BinData();
    }

    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BinData();
    }
}