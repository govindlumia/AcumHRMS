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
using System.IO;
using System.Data.OleDb;

using System.Security.Cryptography;
using HRMS.BusinessLogic;
using System.Collections.Generic;
using HRMS.BusinessEntity;


public partial class payroll_admin_SalarySheetNew : System.Web.UI.Page
{
    string FileName = string.Empty; // For FileName
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dds = new DataTable();
    string companyId;
    protected void Page_Load(object sender, EventArgs e)
    {

        lbl_message.Text = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            FillControl();

            //current_month(); //22Sep2010
        }
        bind_fyear();

    }
    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlcompany, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
     //   BindDropDowns(ddlbranch, binddrop.BindDropDowns("", "Branch"), "branch_id", "branch_name");
      //  BindDropDowns(ddlDepartment, binddrop.BindDropDowns("", "Department"), "departmentid", "department_name");

    }
    protected void bind_fyear()
    {
        //int d;
        //DateTime dt = DateTime.Now;

        //d = Convert.ToInt32(dt.Month);
        //if (d <= 3)
        //{
        //    dt = dt.AddMonths(-1);

        //    if (d == 1)
        //        lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //    else if (d == 2)
        //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
        //    else
        //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;

        //}
        //else
        //{
        //    if (Convert.ToInt16(dt.Day) > 30)
        //        dt = dt.AddMonths(1);

        //    if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //        lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //    else
        //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
        //}
        ListItem item;
        for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
        {
            item = new ListItem(i + "-" + (i + 1));
            ddl_fyear.Items.Add(item);
        }
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void ddlcompany_selectIndexChanged(object sender, EventArgs e)
    {
     //   BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
     //   BindDropDowns(ddlbranch, binddrop.BindDropDowns(ddlcompany.SelectedValue, "Branch"), "branch_id", "branch_name");
     //   BindDropDowns(ddlDepartment, binddrop.BindDropDowns(ddlcompany.SelectedValue, "Department"), "departmentid", "department_name");


    }
    protected void current_month()
    {
        DateTime dt = DateTime.Now;

        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);
        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
       
    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        
        bindgrid();
        //lbl_message.Text = lbl_message.Text = "Attendance processed successfully";
        //validate_attendance();
    }
         
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
        //validate_attendance();
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
       // ddlbranch.Items.Insert(0, new ListItem("---- All ----", "0"));
    }

    protected void ddlDepartment_DataBound(object sender, EventArgs e)
    {
     //   ddlDepartment.Items.Insert(0, new ListItem("---- All ----", "0"));
    }

    protected void bindgrid()
    {
        //SqlParameter[] sqlparm = new SqlParameter[2];


        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[6];

     

        sqlparam[0] = new SqlParameter("@YEAR", SqlDbType.VarChar, 50);
       // sqlparam[0].Value = lbl_fyear.Text.Trim().ToString()
             sqlparam[0].Value = ddl_fyear.SelectedValue;

        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[1].Value = dd_month.SelectedItem.Text;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
        //if (ddlbranch.SelectedIndex != 0)
        //{
        //    sqlparam[2].Value = ddlbranch.SelectedValue;
        //}
        //else
        //{
            sqlparam[2].Value = "";
       // }
        sqlparam[3] = new SqlParameter("@dept", SqlDbType.VarChar, 50);
        //if (ddlDepartment.SelectedIndex != 0)
        //{
        //    sqlparam[3].Value = ddlDepartment.SelectedValue;
        //}
        //else
        //{
            sqlparam[3].Value = "";
      // }
        sqlparam[4] = new SqlParameter("@phase", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "1";

        sqlparam[5] = new SqlParameter("@CompanyId", SqlDbType.Int);
        sqlparam[5].Value = ddlcompany.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_salary_sheet_monthly_Report_Sample1]", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
        //Session["ds"] = ds;
        if (ds.Tables.Count > 0)
        {
            ViewState["dataView"] = ds.Tables[0];
        }
        else
        {
            ViewState["dataView"] = null;
        }

  
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void exportexcel()
    {
        //string filename = "Salary Sheet :- " + dd_month.SelectedItem.Text;

        //SqlParameter[] sqlparm = new SqlParameter[2];

        //sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        //sqlparm[1] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_salary_sheet_monthly_Report_Sample]", sqlparm);
        ds = (DataSet)Session["ds"];
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =SalarySheet.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[0].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
     
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        //exportexcel();
        if (ViewState["dataView"] != null)
        {
            DataTable dt_result = (DataTable)ViewState["dataView"];
            GridViewRow _row=new GridViewRow(0,0,DataControlRowType.DataRow,DataControlRowState.Normal);
            TableCell[] _cells=new TableCell[dt_result.Columns.Count];
           List<TableCell> cells=new List<TableCell>();
          TableCell cell;
          foreach(DataColumn dc in dt_result.Columns)
          {
              cell=new TableCell();
              cell.Text=dc.ColumnName;
              cells.Add(cell);
          }
           _row.Cells.AddRange(cells.ToArray());
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(dt_result, _row, "Salary Sheet", this.form1, "salarysheet");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nodata", "alert('No Data')", true);
        }

    }
    protected void ddlcompany_DataBound(object sender, EventArgs e)
    {
        //ddlcompany.Items.Insert(0, new ListItem("---Select Company---", "0"));
        //ddlcompany.Items.Insert(0, new ListItem("---Select Company---", "0"));

    }
  
}