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
using Utilities;

public partial class Admin_Employee_EmployeeReportDatewise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "1")
                    Response.Redirect("~/Authenticate.aspx");

                ddlCmpy.Attributes.Add("onChange", "return hideShow('" + ddlCmpy.ClientID + "','" + DivCmpy.ClientID + "');");
                ddlStatus.Attributes.Add("onChange", "return hideShow('" + ddlStatus.ClientID + "','" + divstatus.ClientID + "');");
                DDL_CMPY.Attributes.Add("onChange", "return hideShow('" + DDL_CMPY.ClientID + "','" + Divcmpydol.ClientID + "');");
                DDLSTATUSDOL.Attributes.Add("onChange", "return hideShow('" + DDLSTATUSDOL.ClientID + "','" + Div_Status.ClientID + "');");
                _PageInitialize();
                
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void _PageInitialize()
    {

        FillControl();
        if (RadioButtonList1.SelectedValue == "1")
        {
            DivDoj.Style["display"] = "block";
            DivDOL.Style["display"] = "none";
        }
        else
        {
            DivDOL.Style["display"] = "block";
            DivDoj.Style["display"] = "none";
        }
    }

    #region Initialization
    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(drpCmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddlBranch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(Drp_Cmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(Drp_Branch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(drpStatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
        BindDropDowns(DRP_status, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    #endregion 

    #region "Date of joining"

    public void ExportAllColumns()
    {

        try
        {
            DataTable dt = new DataTable();
            if (ViewState["Record"] != null)
                dt = (DataTable)ViewState["Record"];
            else
                dt = new DataTable();
         MailScript scriptObj=new MailScript();
         scriptObj.exportToExcelInCustomized(dt, gvODReport.HeaderRow, "Datewise Employee Report", Page.Form, "datewiseemprep");

           
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
        txtFromDate.Text = "";
        txtToDate.Text = "";
        ddlCmpy.Visible = true;

    }
    protected void ImgExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvODReport.Rows.Count > 0)
            {
                ExportAllColumns();
                Reset();
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
        Reset();
    }
    protected void BindGrid()
    {
        try
        {
            CommonBusiness commonbAL = new CommonBusiness();
            string CmpyID;
            string StatusID;
            string CategoryID;
            DateTime DateFrom;
            DateTime DateTo;

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
        // (CONVERT(date,emp_doj,101)) 
            DateFrom = Utilities.Utility.DateTimeForat(txtFromDate.Text);
            DateTo = Utilities.Utility.DateTimeForat(txtToDate.Text);

            DataTable dt = new DataTable();
            dt = commonbAL.EmployeeDateWiseReportDOJ(CmpyID, CategoryID, DateFrom, DateTo, StatusID);

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
    protected void gvODReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvODReport.PageIndex = e.NewPageIndex;
        DataTable dt = (DataTable)ViewState["Record"];
        gvODReport.DataSource = dt;
        gvODReport.DataBind();
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
    protected void drpCmpy_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlBranch, binddrop.BindDropDowns(drpCmpy.SelectedValue, "CompCategory"), "id", "Category_Name");
        DivCmpy.Style["display"] = "block";
    }

    #endregion 

    #region "Date of Leaving"

    public void ExportAllColumns1()
    {

        try
        {
            DataTable dt = new DataTable();
            if (ViewState["RecordDOL"] != null)
                dt = (DataTable)ViewState["RecordDOL"];
            else
                dt = new DataTable();
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(dt, Grdleaving.HeaderRow, "Datewise Employee Report", Page.Form, "datewiseemprep");

        }
        catch (Exception ex)
        {

        }
    }
    protected void Reset1()
    {
        DDL_CMPY.SelectedValue = "0";
        Divcmpydol.Visible = false;
        DDLSTATUSDOL.SelectedValue = "0";
        Div_Status.Visible = false;
        Drp_Cmpy.SelectedValue = "0";
        DRP_status.SelectedValue = "0";
        Drp_Branch.SelectedValue = "0";
        txt_fromdol.Text = "";
        txttodol.Text = "";

    }
    protected void Btn_dol_Click(object sender, EventArgs e)
    {
        try
        {
            if (Grdleaving.Rows.Count > 0)
            {
                ExportAllColumns1();
                Reset1();
            }
            else
                General.Alert("No Record(s) Found", Btn_dol);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_search1_Click(object sender, EventArgs e)
    {
        BindGrid1();
        Reset1();
    }
    protected void BindGrid1()
    {
        try
        {
            CommonBusiness commonbAL = new CommonBusiness();
            string CmpyID;
            string StatusID;
            string BranchID;
            DateTime DateFrom;
            DateTime DateTo;

            if (DDL_CMPY.SelectedValue == "1")
            {
                CmpyID = Drp_Cmpy.SelectedValue;
            }
            else
            {
                CmpyID = "All";
            }

            if (DDLSTATUSDOL.SelectedValue == "1")
            {
                StatusID = DRP_status.SelectedValue;
            }
            else
            {
                StatusID = "All";
            }

            BranchID = Drp_Branch.SelectedValue;
            // (CONVERT(date,emp_doj,101)) 
            DateFrom = Utilities.Utility.DateTimeForat(txt_fromdol.Text);
            DateTo = Utilities.Utility.DateTimeForat(txttodol.Text);

            DataTable dt = new DataTable();
            dt = commonbAL.EmployeeDateWiseReportDOL(CmpyID, BranchID, DateFrom, DateTo, StatusID);

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
            Grdleaving.DataSource = dt;
            Grdleaving.DataBind();

            if (dt.Rows.Count > 0)
            {
                ViewState["RecordDOL"] = dt;
                LBL_total.Text = dt.Rows.Count.ToString();
            }
            else
                LBL_total.Text = "0";
        }
        catch (Exception Ex)
        { }
    }

    protected void Grdleaving_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grdleaving.PageIndex = e.NewPageIndex;
        DataTable dt = (DataTable)ViewState["RecordDOL"];
        Grdleaving.DataSource = dt;
        Grdleaving.DataBind();
    }

    protected void drpAlldol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpAlldol.SelectedIndex > 0)
        {
            Grdleaving.AllowPaging = false;
            DataTable dt = (DataTable)ViewState["RecordDOL"];
            Grdleaving.DataSource = dt;
            Grdleaving.DataBind();
        }
        else
        {
            Grdleaving.AllowPaging = true;
            DataTable dt = (DataTable)ViewState["RecordDOL"];
            Grdleaving.DataSource = dt;
            Grdleaving.DataBind();
        }
    }
    protected void Drp_Cmpy_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(Drp_Branch, binddrop.BindDropDowns(Drp_Cmpy.SelectedValue, "CompCategory"), "id", "Category_Name");
        Divcmpydol.Style["display"] = "block";
    }

    #endregion
    protected void RadioButtonList1_SelectedIndex(object sender, EventArgs e)
    {
     if (RadioButtonList1.SelectedValue == "1")
     {
         DivDoj.Style["display"] = "block";
         DivDOL.Style["display"] = "none";
     }
     else
     {
         DivDOL.Style["display"] = "block";
         DivDoj.Style["display"] = "none";
     }
    }
}