using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Reports_EmployeeMasterReport : System.Web.UI.Page
{
    ReportsBAL objBAL;
    DataTable dt;
    ReportsEntity objEntity;

    public Appraisal_Reports_EmployeeMasterReport()
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

    private void BindData()
    {
        try
        {
            objEntity.CompanyId = ddl_company.SelectedValue;
            objEntity.EmployeeCode = txt_employee.Text;
            objEntity.DesignationId = dd_designation.SelectedValue;
            dt = objBAL.EmployeeMasterReport(objEntity);

            grdResult.DataSource = dt.Rows.Count > 0 ? dt : null;
            grdResult.DataBind();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }

    protected void FillControl()
    {
        try
        {
            BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
            BindDropDowns(ddl_company, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
            BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
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

    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdResult.PageIndex = e.NewPageIndex;
            BindData();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }
    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "V")
        {
            try
            {
                string empCode = e.CommandArgument.ToString();
                Response.Redirect("EmployeeMasterReportSummary.aspx?EmpCode=" + empCode);
            }
            catch (Exception ex)
            {
                General.Alert(ex.Message, grdResult);
            }

        }
    }
}