using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.IO;

public partial class leave_ResignedEmployee : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            FillControl();
        }
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(dd_branch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(dd_designation, commonBusiness.BindDropDowns("", "Designation"), "id", "designationname");
        BindDropDowns(ddlbranch, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text.Trim();

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        sqlparam[5].Value = 0;

        sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparam[6].Value = chk_emp_status.Checked;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_bal_report", sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        else
        {
            empgrid.DataSource = null;
            empgrid.DataBind();
        }
    }

    protected void btn_search_click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    

    protected void dd_status_DataBound(object sender, EventArgs e)
    {
        //dd_status.Items.Insert(0, new ListItem("All", "All"));
        //bindempdetail();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text.Trim();

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        sqlparam[5].Value = 0;

        sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparam[6].Value = chk_emp_status.Checked;


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_bal_report", sqlparam);
       
        DataTable dt = ds.Tables[0];
        dt.Columns.Remove("BussinessUnitName");
        dt.Columns.Remove("Used_days");
        MailScript scriptObj = new MailScript();
        scriptObj.exportToExcelInCustomized(dt, empgrid.HeaderRow, "Employee leave balance details", Page.Form, "empleavebal");
        
        //  exportexcel(dt);
    }

    protected void exportexcel(DataTable dt)
    {
        try
        {
            string filename = string.Empty;
            filename = "attachment;";
            Response.Clear(); //this clears the Response of any headers or previous output 
            Response.Charset = "";
            Response.Buffer = true; //make sure that the entire output is rendered simultaneously
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel";

            filename = "attachment;filename =EmployeeLeaveBalanceReport.xls";
            Response.AddHeader("content-disposition", "attachment;filename =EmployeeLeaveBalanceReport.xls");// TeamLeaveStatus.xls");
            //Response.Write(filename);
            //Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            String style = @"<style>.text{mso-number-format:\@;}</style>";
            HttpContext.Current.Response.Write(style);
            int colindex = 0;

            foreach (DataColumn dc in dt.Columns)
            {
                string valuetype = dc.DataType.ToString();

                foreach (DataGridItem i in dg.Items)
                    i.Cells[colindex].Attributes.Add("class", "text");
                colindex++;
            }

            dg.RenderControl(htmlwrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception Ex)
        {

        }
    }
    protected void empgrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}