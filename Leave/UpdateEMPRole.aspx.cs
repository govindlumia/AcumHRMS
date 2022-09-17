using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic;
using System.Data;

public partial class Leave_UpdateEMPRole : System.Web.UI.Page
{
    DataSet dsData;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(1);
        }
    }

    protected void BindData(int companyID)
    {
        try
        {
            dsData = new DataSet();

            dsData = LeaveBAL.SelectEMPDataCompanyWise(companyID);

            if (!IsPostBack)
            {
                if (dsData.Tables[1].Rows.Count > 0)
                {
                    ViewState["RoleMaster"] = dsData.Tables[1];
                }

                if (dsData.Tables[2].Rows.Count > 0)
                {
                    drpcompany.DataSource = dsData.Tables[2];
                    drpcompany.DataTextField = "companyname";
                    drpcompany.DataValueField = "companyid";
                    drpcompany.DataBind();
                }
            }

            if (dsData.Tables[0].Rows.Count > 0)
            {
                grdResult.DataSource = dsData.Tables[0];
                grdResult.DataBind();

                grdBulk.DataSource = dsData.Tables[0];
                grdBulk.DataBind();
            }
            else
            {
                grdResult.DataSource = null;
                grdResult.DataBind();

                grdBulk.DataSource = null;
                grdBulk.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drpRole = (DropDownList)e.Row.FindControl("ddlRole");
            Label roleID = (Label)e.Row.FindControl("lblRoleID");

            if (ViewState["RoleMaster"] != null)
            {
                drpRole.DataSource = (DataTable)ViewState["RoleMaster"];
                drpRole.DataTextField = "role";
                drpRole.DataValueField = "id";
                drpRole.DataBind();

                if (drpRole.Items.FindByValue(roleID.Text) != null)
                {
                    drpRole.Items.FindByValue(roleID.Text).Selected = true;
                }
            }
        }
    }
    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpType.SelectedIndex > 0)
        {
            btnUpdate.Visible = true;
            bulkUpdate.Style["display"] = "block";
            singleUpdate.Style["display"] = "none";
        }
        else
        {
            btnUpdate.Visible = false;
            bulkUpdate.Style["display"] = "none";
            singleUpdate.Style["display"] = "block";
        }
    }
    protected void drpcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData(Convert.ToInt32(drpcompany.SelectedValue));
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rows in grdResult.Rows)
        {
            Label lblCode = (Label)rows.FindControl("lblEmpCode");
            DropDownList drpRole = (DropDownList)rows.FindControl("ddlRole");

            string result = LeaveBAL.UpdateEMPRole(Convert.ToInt32(lblCode.Text), Convert.ToInt32(drpRole.SelectedValue.ToString()));

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Record Updated Successfully');", true);
        }
    }
    protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            GridViewRow grdRow = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            DropDownList drpRole = (DropDownList)grdRow.FindControl("ddlRole");
            int empCode = Convert.ToInt32(e.CommandArgument.ToString());
            int role = Convert.ToInt32(drpRole.SelectedValue.ToString());

            string result = LeaveBAL.UpdateEMPRole(empCode, role);

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Record Updated Successfully');", true);

            BindData(Convert.ToInt32(drpcompany.SelectedValue));
        }
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BindData(Convert.ToInt32(drpcompany.SelectedValue));

    }
}