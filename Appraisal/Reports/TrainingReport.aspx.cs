using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic;
using System.Data;
using HRMS.BusinessEntity.Appraisal;


public partial class Appraisal_Reports_TrainingReport : System.Web.UI.Page
{
    ReportsBAL objBAL;
    DataTable dt;
    ReportsEntity objEntity;

    public Appraisal_Reports_TrainingReport()
    {
        objBAL = new ReportsBAL();
        dt = new DataTable();
        objEntity = new ReportsEntity();
    }

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
            BindData();
        }
    }

    protected void FillControl()
    {
        try
        {
            BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
            BindDropDowns(ddl_company, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
            BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
            txtSDate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("dd-MMM-yyyy");
            txtEDate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            txtSDate.Attributes.Add("readonly", "readonly");
            txtEDate.Attributes.Add("readonly", "readonly");
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    private void BindData()
    {
        try
        {
            objEntity.StartDate = Convert.ToDateTime(txtSDate.Text);
            objEntity.Enddate = Convert.ToDateTime(txtEDate.Text);
            objEntity.EmployeeCode = txt_employee.Text;
            objEntity.DesignationId = dd_designation.SelectedValue;
            dt = objBAL.TrainingReport(objEntity);

            grdResult.DataSource = dt.Rows.Count > 0 ? dt : null;
            grdResult.DataBind();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }

    protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
            BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Summary")
        {
            try
            {
                objEntity.EmployeeCode = e.CommandArgument.ToString();
                dt = objBAL.TrainingReportSummary(objEntity);

                if (dt.Rows.Count > 0)
                {
                    grdSummary.DataSource = dt;
                    divSummary.Visible = true;
                }
                else
                {
                    divSummary.Visible = false;
                    grdSummary.DataSource = null;
                }
                grdSummary.DataBind();
            }
            catch (Exception ex)
            {
                General.Alert(ex.Message, grdResult);
            }

        }
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BindData();
    }
}