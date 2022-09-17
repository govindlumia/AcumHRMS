using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.IO;

public partial class Admin_Employee_EmpReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "1")
                    Response.Redirect("~/Authenticate.aspx");

                _PageInitialize();
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }


    }
    protected void _PageInitialize()
    {

        FillControl();

    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(drpCmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddlBranch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(ddlDesg, commonBusiness.BindDropDowns("", "Designation"), "id", "designationname");
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(drpStatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");

    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }


    public void ExportAllColumns()
    {

        try
        {

            DataTable dt = new DataTable();
            if (ViewState["Record"] != null)
                dt = (DataTable)ViewState["Record"];
            else
                dt = new DataTable();
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(dt, gvODReport.HeaderRow, "Employee Report", Page.Form, "emprep");

        }
        catch (Exception ex)
        {

        }
    }

    protected void Reset()
    {
        drpCmpy.SelectedValue = "0";
        DivCmpy.Visible = false;
        drpStatus.SelectedValue = "0";
        divstatus.Visible = false;
        ddlCmpy.SelectedValue = "0";
        ddlStatus.SelectedValue = "0";
        ddlBranch.SelectedValue = "0";
        ddlDesg.SelectedValue = "0";

    }


    protected void ImgExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvODReport.Rows.Count > 0)
            {
                ExportAllColumns();
                Reset();
                gvODReport.DataSource = null;

            }
            else
                General.Alert("No Record(s) Found", ImgExcel);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
        //Reset();
    }
    protected void BindGrid()
    {
        try
        {
            CommonBusiness commonbAL = new CommonBusiness();
            string CmpyID;
            string StatusID;
            string CategoryID;
            string DesgID;

            if (ddlCmpy.SelectedValue == "1")
            {
                CmpyID = drpCmpy.SelectedValue;
            }
            else
            {
                CmpyID = "All";
            }

            if (ddlStatus.SelectedValue == "1")
            {
                StatusID = drpStatus.SelectedValue;
            }
            else
            {
                StatusID = "All";
            }

            CategoryID = ddlBranch.SelectedValue;
            DesgID = ddlDesg.SelectedValue;

            DataTable dt = new DataTable();
            dt = commonbAL.ExportToExcel(CmpyID, CategoryID, DesgID, StatusID, true);

            dt.Columns.Add(new DataColumn("Emp_DOJ"));
            dt.Columns.Add(new DataColumn("Sal_Calculation_Date"));
            dt.Columns.Add(new DataColumn("Emp_Date_of_Leaving"));
            dt.Columns.Add(new DataColumn("Emp_Date_of_Releiving"));
            dt.Columns.Add(new DataColumn("Spouse_Date_of_Birth"));
            dt.Columns.Add(new DataColumn("Emp_Date_of_Birth"));
            dt.Columns.Add(new DataColumn("Emp_Date_of_Anniversary"));
            dt.Columns.Add(new DataColumn("Passport_Valid_Date"));
            dt.Columns.Add(new DataColumn("Policy_Valid_from"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["Emp_DOJ"] = Convert.ToDateTime(dr["Employee_DOJ"]).ToString("dd-MMM-yyyy");
                dr["Sal_Calculation_Date"] = Convert.ToDateTime(dr["Salary_Calculation_Date"]).ToString("dd-MMM-yyyy");
                if (!string.IsNullOrEmpty(dr["Date_of_Leaving"].ToString()))
                {
                    dr["Emp_Date_of_Leaving"] = Convert.ToDateTime(dr["Date_of_Leaving"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Date_of_Releiving"].ToString()))
                {
                    dr["Emp_Date_of_Releiving"] = Convert.ToDateTime(dr["Date_of_Releiving"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Spouse_DOB"].ToString()))
                {
                    dr["Spouse_Date_of_Birth"] = Convert.ToDateTime(dr["Spouse_DOB"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Employee_DOB"].ToString()))
                {
                    dr["Emp_Date_of_Birth"] = Convert.ToDateTime(dr["Employee_DOB"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Date_of_Anniversary"].ToString()))
                {
                    dr["Emp_Date_of_Anniversary"] = Convert.ToDateTime(dr["Date_of_Anniversary"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Passport_Valid_From"].ToString()))
                {
                    dr["Passport_Valid_Date"] = Convert.ToDateTime(dr["Passport_Valid_From"]).ToString("dd-MMM-yyyy");
                }
                if (!string.IsNullOrEmpty(dr["Valid_From"].ToString()))
                {
                    dr["Policy_Valid_from"] = Convert.ToDateTime(dr["Valid_From"]).ToString("dd-MMM-yyyy");
                }

            }
            dt.Columns.Remove("Employee_DOJ");
            dt.Columns.Remove("Salary_Calculation_Date");
            dt.Columns.Remove("Date_of_Leaving");
            dt.Columns.Remove("Date_of_Releiving");
            dt.Columns.Remove("Spouse_DOB");
            dt.Columns.Remove("Employee_DOB");
            dt.Columns.Remove("Date_of_Anniversary");
            dt.Columns.Remove("Passport_Valid_From");
            dt.Columns.Remove("Valid_From");
            dt.Columns["Emp_DOJ"].SetOrdinal(11);
            dt.Columns["Sal_Calculation_Date"].SetOrdinal(12);
            dt.Columns["Emp_Date_of_Leaving"].SetOrdinal(13);
            dt.Columns["Emp_Date_of_Releiving"].SetOrdinal(14);
            dt.Columns["Spouse_Date_of_Birth"].SetOrdinal(46);
            dt.Columns["Emp_Date_of_Birth"].SetOrdinal(47);
            dt.Columns["Emp_Date_of_Anniversary"].SetOrdinal(48);
            dt.Columns["Passport_Valid_Date"].SetOrdinal(54);
            dt.Columns["Policy_Valid_from"].SetOrdinal(59);
            gvODReport.DataSource = dt;
            gvODReport.DataBind();

            if (dt.Rows.Count > 0)
            {
                ViewState["Record"] = dt;
                lblTotalRecord.Text = dt.Rows.Count.ToString();
            }
            else
                lblTotalRecord.Text = "0";
        }
        catch (Exception Ex)
        { }
    }
    protected void drpAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpAll.SelectedIndex > 0)
        {
            gvODReport.AllowPaging = false;
            DataTable dt = (DataTable)ViewState["Record"];
            gvODReport.DataSource = dt;
            gvODReport.DataBind();
        }
        else
        {
            gvODReport.AllowPaging = true;
            DataTable dt = (DataTable)ViewState["Record"];
            gvODReport.DataSource = dt;
            gvODReport.DataBind();
        }
    }
    protected void gvODReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvODReport.PageIndex = e.NewPageIndex;
        DataTable dt = (DataTable)ViewState["Record"];
        gvODReport.DataSource = dt;
        gvODReport.DataBind();
    }
    protected void drpCmpy_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlBranch, binddrop.BindDropDowns(drpCmpy.SelectedValue, "CompCategory"), "id", "Category_Name");
        BindDropDowns(ddlDesg, binddrop.BindDropDowns(drpCmpy.SelectedValue, "CompDesignation"), "id", "designationname");

    }
    protected void ddlCmpy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCmpy.SelectedValue == "1")
        {
            DivCmpy.Style["display"] = "block";
        }
        else
        {
            DivCmpy.Style["display"] = "none";
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue == "1")
        {
            divstatus.Style["display"] = "block";
        }
        else
        {
            divstatus.Style["display"] = "none";
        }
    }
    protected void gvODReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void gvODReport_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}