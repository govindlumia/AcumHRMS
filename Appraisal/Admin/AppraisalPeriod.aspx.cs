using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;

public partial class Appraisal_Admin_AppraisalPeriod : System.Web.UI.Page
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
            FillControl();
        }
    }

    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(drpCompany, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDurationData(drpPeriod.SelectedValue);
        BindGrid();
    }

    private void BindGrid()
    {
        AppraisalPeriodBAL objBAL = new AppraisalPeriodBAL();
        List<AppraisalPeriodEntity> objResult = objBAL.GetAll();
        grdAppraisalPeriod.DataSource = objResult.Count > 0 ? objResult : null;
        grdAppraisalPeriod.DataBind();
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }

    protected void btncreate_Click1(object sender, EventArgs e)
    {
        if (!Validate())
        {
            return;
        }

        foreach (GridViewRow grdRow in grdAppraisalPeriod.Rows)
        {
            Label compName = (Label)grdRow.FindControl("lblCompanyName");
            Label period = (Label)grdRow.FindControl("lblPeriodType");
            Label duration = (Label)grdRow.FindControl("lblDuration");

            if (drpCompany.SelectedItem.Text == compName.Text)
            {
                General.Alert("Record already exists.", btncreate);
                return;
            }
        }

        AppraisalPeriodEntity objEntity = new AppraisalPeriodEntity();
        objEntity.CompanyId = Convert.ToInt32(drpCompany.SelectedValue);
        objEntity.PeriodType = Convert.ToChar(drpPeriod.SelectedValue);
        objEntity.Duration = drpDuration.SelectedValue;
        objEntity.IsActive = true;
        objEntity.CreatedBy = Session["empcode"].ToString();

        AppraisalPeriodBAL objBAL = new AppraisalPeriodBAL();
        List<AppraisalPeriodEntity> objResult = objBAL.Create(objEntity);

        grdAppraisalPeriod.DataSource = objResult.Count > 0 ? objResult : null;
        grdAppraisalPeriod.DataBind();

        lblMessgae.Text = "Record created successfully";
        lblMessgae.Style["color"] = "green";

        BindGrid();
    }

    private Boolean Validate()
    {
        var isValidate = true;

        if (drpCompany.SelectedValue == "0")
        {
            isValidate = false;
            General.Alert("Select company.", btncreate);
        }

        return isValidate;
    }

    protected void drpPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpDuration.Items.Clear();
        BindDurationData(drpPeriod.SelectedValue);
    }

    private void BindDurationData(string periodType)
    {
        trYearly.Visible = true;
        if (periodType == "M")
        {
            trYearly.Visible = false;
        }
        else
        {
            drpDuration.Items.Insert(0, new ListItem("Jan-Dec", "Jan-Dec"));
        }
    }
    protected void grdAppraisalPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeActivate")
        {
            AppraisalPeriodBAL objBAL = new AppraisalPeriodBAL();
            Int32 periodId = Convert.ToInt32(e.CommandArgument);
            string result = "0";// objBAL.DeActivatePeriod(periodId);

            if (result == "1")
            {
                BindGrid();
            }
            else
            {
                // ToDo: Throw error as there is only one Row who is Active
                lblMessgae.Text = "There is only one Active record. You can not de-activate it";
                lblMessgae.Style["color"] = "red";
            }
        }
    }
}