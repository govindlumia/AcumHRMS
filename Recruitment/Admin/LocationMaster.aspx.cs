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
            CheckSession();
            BindLocation();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
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

    protected void BindLocation()
    {
        VacLocationENT ObjVacLocationENT = new VacLocationENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacLocationENT.Dsca = txtRoundSearch.Text.Trim();
        ObjVacLocationENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjVacBusiness.Select_VacLocationMaster(ObjVacLocationENT);

        grdResult.DataSource = ds;
        grdResult.DataBind();

        divCreate.Style["display"] = "none";
        divView.Style["display"] = "block";
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        VacLocationENT ObjVacLocationENT = new VacLocationENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacLocationENT.Dsca = txtRName.Text.Trim();
        ObjVacLocationENT.EmpCode = Session["EmpCode"].ToString();

        string re = ObjVacBusiness.Create_VacLocationMaster(ObjVacLocationENT);

        if (re == "1")
        {
            General.Alert("Location Created Successfully", this);
            txtRName.Text = "";
            txtRoundSearch.Text = "";
            lnkCreateView.Text = "Create";
            BindLocation();
        }
        else
            General.Alert("Location Already Exists", this);
    }

    protected void grdResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdResult.EditIndex = e.NewEditIndex;
        BindLocation();
    }
    protected void grdResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdResult.EditIndex = -1;
        BindLocation();
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BindLocation();
    }
    protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        VacLocationENT ObjVacLocationENT = new VacLocationENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        TextBox txtRoundName = (TextBox)grdResult.Rows[e.RowIndex].FindControl("txtRoundName");
        Label lblID = (Label)grdResult.Rows[e.RowIndex].FindControl("lblID");

        if (txtRoundName.Text.Trim() != string.Empty)
        {
            ObjVacLocationENT.ID = lblID.Text;
            ObjVacLocationENT.Dsca = txtRoundName.Text.Trim();
            ObjVacLocationENT.EmpCode = Session["EmpCode"].ToString();

            string _result = ObjVacBusiness.Update_VacLocationMaster(ObjVacLocationENT);

            if (_result.Equals("1"))
            {
                grdResult.EditIndex = -1;
                BindLocation();
                General.Alert("Location Name Updated Successfully", this);
            }
            else
            {
                General.Alert("Location Already Exists", this);
            }
        }
        else
        {
            General.Alert("Please Insert Location name", this);
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
            VacLocationENT ObjVacLocationENT = new VacLocationENT();
            VacBusiness ObjVacBusiness = new VacBusiness();

            ObjVacLocationENT.ID = e.CommandArgument.ToString();
            ObjVacLocationENT.EmpCode = Session["EmpCode"].ToString();
            ObjVacLocationENT.Status = "0";

            string result = ObjVacBusiness.Update_VacLocationMasterStatus(ObjVacLocationENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindLocation();
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
            VacLocationENT ObjVacLocationENT = new VacLocationENT();
            VacBusiness ObjVacBusiness = new VacBusiness();

            ObjVacLocationENT.ID = e.CommandArgument.ToString();
            ObjVacLocationENT.EmpCode = Session["EmpCode"].ToString();
            ObjVacLocationENT.Status = "1";

            string result = ObjVacBusiness.Update_VacLocationMasterStatus(ObjVacLocationENT);

            if (result.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "statusupdated", "alert('Status Updated');", true);
                BindLocation();
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
        BindLocation();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtRoundSearch.Text = "";
        BindLocation();
    }
} 