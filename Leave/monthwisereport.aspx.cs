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
using System.Data.SqlTypes;
using DataAccessLayer;
using System.IO;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class leave_monthwisereport : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            month();
            FillControl();
            //bindgrid(DateTime.Now.Month);
            //dd_month.SelectedValue = DateTime.Now.Month.ToString();
        }
    }



    protected void month()
    {
        dd_month.DataTextField = "monthname";
        dd_month.DataValueField = "month";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_getmonth_name]");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem item = new ListItem();
            //    item.Text = ds.Tables[0].Rows[i]["monthname"].ToString();
            item.Text = getMonthfromValue(Convert.ToInt32(ds.Tables[0].Rows[i]["month"]));
            item.Value = ds.Tables[0].Rows[i]["month"].ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
    }

    private string getMonthfromValue(int value)
    {
        switch (value)
        {
            case 1: return "January";
            case 2: return "February";
            case 3: return "March";
            case 4: return "April";
            case 5: return "May";
            case 6: return "June";
            case 7: return "July";
            case 8: return "August";
            case 9: return "September";
            case 10: return "October";
            case 11: return "November";
            case 12: return "December";
        }
        return "NA";
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bindgrid(Convert.ToInt32(dd_month.SelectedValue));
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(dd_dept, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(ddl_cmpny, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }


    /*
    protected Boolean chk_date()
    {
        DateTime sdate = Convert.ToDateTime(txt_start_date.Text);
        DateTime edate = Convert.ToDateTime(txt_end_date.Text);

        TimeSpan ts = edate - sdate;

        if (Convert.ToInt32(ts.TotalDays) < 0)
            return false;

        return true;
    }
    */

    protected void bindgrid()
    {

        int month;
        int year;


        if (Convert.ToInt32(dd_year.SelectedValue) == 0)
            year = DateTime.Now.Year;
        else
            year = Convert.ToInt32(dd_year.SelectedValue);

        if (Convert.ToInt32(dd_year.SelectedValue) == 0)
            month = DateTime.Now.Month;
        else
            month = Convert.ToInt32(dd_month.SelectedValue);

        // added by ashok for add two parameter

        //startdate = Convert.ToDateTime(txt_start_date.Text);
        //enddate = Convert.ToDateTime(txt_end_date.Text);

        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@month", SqlDbType.Int);
        sqlparam[0].Value = month;

        sqlparam[1] = new SqlParameter("@type", SqlDbType.Int);
        sqlparam[1].Value = 0;

        sqlparam[2] = new SqlParameter("@name", SqlDbType.VarChar);
        sqlparam[2].Value = txt_employee.Text.Trim().ToString();


        sqlparam[3] = new SqlParameter("@categoryid", SqlDbType.Int);
        sqlparam[3].Value = dd_dept.SelectedValue;

        sqlparam[4] = new SqlParameter("@year", SqlDbType.Int);
        sqlparam[4].Value = year;

        sqlparam[5] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparam[5].Value = chk_empstatus.Checked;

        sqlparam[6] = new SqlParameter("@company", SqlDbType.VarChar,50);
        sqlparam[6].Value = ddl_cmpny.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_LEAVE_FETCH_ATTENDANCE_TMT", sqlparam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["GridData"] = ds.Tables[0];
                DataColumn dc = new DataColumn("Emp Doj");

                ds.Tables[0].Columns.Add(dc);
                dc.SetOrdinal(ds.Tables[0].Columns["DOJ"].Ordinal);
                foreach (DataRow _dr in ds.Tables[0].Rows)
                {

                    if (!string.IsNullOrEmpty(_dr["DOJ"].ToString()))
                    {
                        try
                        {
                            _dr["Emp Doj"] = Convert.ToDateTime(_dr["DOJ"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                ds.Tables[0].Columns.Remove("DOJ");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
    }






    protected void dd_month_DataBound(object sender, EventArgs e)
    {
        dd_month.Items.Insert(0, new ListItem("Select Month", " 0"));
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        bindgrid();
    }



    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {

        int month;
        int year;
        DataTable dt_result = null;
        if (ViewState["GridData"] == null)
        {
            if (Convert.ToInt32(dd_year.SelectedValue) == 0)
                year = DateTime.Now.Year;
            else
                year = Convert.ToInt32(dd_year.SelectedValue);

            if (Convert.ToInt32(dd_month.SelectedValue) == 0)
                month = DateTime.Now.Month;
            else
                month = Convert.ToInt32(dd_month.SelectedValue);
            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@month", SqlDbType.Int);
            sqlparam[0].Value = month;

            sqlparam[1] = new SqlParameter("@type", SqlDbType.Int);
            sqlparam[1].Value = 0;

            sqlparam[2] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlparam[2].Value = txt_employee.Text.Trim().ToString();


            sqlparam[3] = new SqlParameter("@categoryid", SqlDbType.Int);
            sqlparam[3].Value = dd_dept.SelectedValue;

            sqlparam[4] = new SqlParameter("@year", SqlDbType.Int);
            sqlparam[4].Value = year;

            sqlparam[5] = new SqlParameter("@emp_status", SqlDbType.Bit);
            sqlparam[5].Value = chk_empstatus.Checked;
            sqlparam[6] = new SqlParameter("@company", SqlDbType.VarChar, 50);
            sqlparam[6].Value = ddl_cmpny.SelectedValue;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_LEAVE_FETCH_ATTENDANCE_TMT", sqlparam);
            dt_result = ds.Tables[0];
            DataColumn dc = new DataColumn("Emp Doj");

            dt_result.Columns.Add(dc);
            dc.SetOrdinal(dt_result.Columns["DOJ"].Ordinal);
            foreach (DataRow _dr in dt_result.Rows)
            {

                if (!string.IsNullOrEmpty(_dr["DOJ"].ToString()))
                {
                    try
                    {
                        _dr["Emp Doj"] = Convert.ToDateTime(_dr["DOJ"].ToString()).ToString("dd-MMM-yyyy");
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            dt_result.Columns.Remove("DOJ");
            GridView1.DataSource = dt_result;
            GridView1.DataBind();
        }
        else
        {
            dt_result = (DataTable)ViewState["GridData"];
        }

        if (dt_result.Rows.Count > 0)
        {
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(dt_result, GridView1.HeaderRow, "Monthwise Attendance Report ", Page.Form, "attrepmonwise");
        }
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", " 0"));
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
