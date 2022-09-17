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

public partial class Admin_Employee_EmpRepotingOfficerWiseReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "1")
                    Response.Redirect("~/Authenticate.aspx");
                FillControl();
                _PageInitialize();
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }
     protected void _PageInitialize()
    {

        FillControl();
       // drpCmpy.Visible = false;
      //  drpStatus.Visible = false;
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(ddlCmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddlBranch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlStatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
        ListItem item_company = new ListItem("All", "All");
        ListItem item_branch = new ListItem("All", "All");
        ListItem item_status = new ListItem("All", "All");
        ddlCmpy.Items.Insert(ddlCmpy.Items.Count , item_company);
        ddlBranch.Items.Insert(ddlBranch.Items.Count , item_branch);
        ddlStatus.Items.Insert(ddlStatus.Items.Count , item_status);
    
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
            scriptObj.exportToExcelInCustomized(dt, gvODReport.HeaderRow, "Employee Officer wise report", Page.Form, "emprepofficerwise");
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename =EmployeeDetails.xls");
            ////Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //StringWriter writer = new StringWriter();
            //HtmlTextWriter htmlwriter = new HtmlTextWriter(writer);
            //DataGrid dg = new DataGrid();
            //dg.DataSource = dt;
            //dg.DataBind();
            //dg.RenderControl(htmlwriter);
            //Response.Write(writer);
            //Response.End();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Reset()
    {
     //   drpCmpy.SelectedValue = "0";
     //   drpCmpy.Visible = false;
        //drpStatus.SelectedValue = "0";
     //   drpStatus.Visible = false;
        ddlCmpy.SelectedValue = "0";
        ddlStatus.SelectedValue = "0";
        ddlBranch.SelectedValue = "0";
        ddlCmpy.Visible = true;
        ddlStatus.Visible = true;
    }

    protected void ddlCmpy_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCmpy.SelectedValue == "1")
        //{
        //    CommonBusiness commonBusiness = new CommonBusiness();
        //    BindDropDowns(drpCmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        //    drpCmpy.Visible = true;
        //    ddlCmpy.Visible = false;
        //}
        //else
        //{
        //    drpCmpy.Visible = false;
        //}
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlStatus.SelectedValue == "1")
        //{

        //    BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        //    BindDropDowns(drpStatus, binddrop.BindDropDowns("", "Status"), "id", "employeestatus");
        //    drpStatus.Visible = true;
        //    ddlStatus.Visible = false;
        //}
        //else
        //{
        //    drpStatus.Visible = false;
        //}

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
            string CmpyID=ddlCmpy.SelectedValue;
            string StatusID=ddlStatus.SelectedValue;
            string CategoryID = ddlBranch.SelectedValue;

            DataTable dt = new DataTable();
            dt = commonbAL.EmployeeReportingOfficerWiseReport(CmpyID, CategoryID, StatusID);

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
        //BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        //BindDropDowns(ddlBranch, binddrop.BindDropDowns(drpCmpy.SelectedValue, "CompCategory"), "id", "Category_Name");
    }

}