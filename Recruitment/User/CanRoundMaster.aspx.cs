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

public partial class Recruitment_User_CanRoundMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["EmpCode"])))
            {
                Response.Redirect("~/Login.aspx");
            }
            BindRounds();
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
        txtRName.Text = string.Empty;
    }

    protected void BindRounds()
    {
        RoundENT ObjRoundENT = new RoundENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjRoundENT.Dsca = txtRoundSearch.Text.Trim();
        ObjRoundENT.EmpCode = Session["EmpCode"].ToString();
        
        DataSet ds = ObjRoundBusiness.Select_RoundMaster(ObjRoundENT);

        grdResult.DataSource = ds;
        grdResult.DataBind();

        divCreate.Style["display"] = "none";
        divView.Style["display"] = "block";
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        RoundENT ObjRoundENT = new RoundENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjRoundENT.Dsca = txtRName.Text.Trim();
        ObjRoundENT.EmpCode = Session["EmpCode"].ToString();

        string re = ObjRoundBusiness.Create_RoundMaster(ObjRoundENT);

        if (re == "1")
        {
            General.Alert("Round Created Successfully", this);
            txtRName.Text = "";
            txtRoundSearch.Text = "";
            lnkCreateView.Text = "Create";
            BindRounds();
        }
        else
            General.Alert("Round Already Exists", this);
    }

    protected void grdResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdResult.EditIndex = e.NewEditIndex;
        BindRounds();
    }
    protected void grdResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdResult.EditIndex = -1;
        BindRounds();
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BindRounds();
    }
    protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        RoundENT ObjRoundENT = new RoundENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        TextBox txtRoundName = (TextBox)grdResult.Rows[e.RowIndex].FindControl("txtRoundName");
        Label lblID = (Label)grdResult.Rows[e.RowIndex].FindControl("lblID");

        if (txtRoundName.Text.Trim() != string.Empty)
        {
            ObjRoundENT.ID = Convert.ToInt32(lblID.Text);
            ObjRoundENT.Dsca = txtRoundName.Text.Trim();
            ObjRoundENT.EmpCode = Session["EmpCode"].ToString();

            string _result = ObjRoundBusiness.Update_RoundMaster(ObjRoundENT);

            if (_result.Equals("1"))
            {
                grdResult.EditIndex = -1;
                BindRounds();
                General.Alert("Round Name Updated Successfully", this);
            }
            else
            {
                General.Alert("Round Already Exists", this);
            }
        }
        else
        {
            General.Alert("Please Insert Round name", this);
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
            RoundENT ObjRoundENT = new RoundENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjRoundENT.ID = Convert.ToInt32(e.CommandArgument.ToString());
            ObjRoundENT.EmpCode = Session["EmpCode"].ToString();
            ObjRoundENT.Status = "0";

            string result = ObjRoundBusiness.Update_RoundMasterStatus(ObjRoundENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindRounds();
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
            RoundENT ObjRoundENT = new RoundENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjRoundENT.ID = Convert.ToInt32(e.CommandArgument.ToString());
            ObjRoundENT.EmpCode = Session["EmpCode"].ToString();
            ObjRoundENT.Status = "1";

            string result = ObjRoundBusiness.Update_RoundMasterStatus(ObjRoundENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindRounds();
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
        BindRounds();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtRoundSearch.Text = "";
        BindRounds();
    }
}