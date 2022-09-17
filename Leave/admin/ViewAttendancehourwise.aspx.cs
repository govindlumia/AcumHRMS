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
using Utilities;
using System.IO;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Leave_admin_ViewAttendancehourwise : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            txt_sdate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            FillControl();
            bindempdetail();
        }
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(dd_branch, commonBusiness.BindDropDowns("", "Category"), "id", "CategoryName");
        BindDropDowns(dd_designation, commonBusiness.BindDropDowns("", "Designation"), "id", "designationname");
        BindDropDowns(ddl_cmpny, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }

    public string GetDay(String uDate)
    {

        string day;
        DateTime date = Convert.ToDateTime(uDate);
        day = date.DayOfWeek.ToString();
        return day;
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    protected void attendancegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        attendancegrid.PageIndex = e.NewPageIndex;
        bindempdetail();

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void bindempdetail()
    {

        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@category", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.DateTimeForat(txt_sdate.Text.ToString());

        sqlparam[5] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparam[5].Value = chk_emp_status.Checked;
        sqlparam[6] = new SqlParameter("@company", SqlDbType.VarChar, 50);
        sqlparam[6].Value = ddl_cmpny.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_hourwise", sqlparam);
        attendancegrid.DataSource = ds;
        attendancegrid.DataBind();
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        //try
        //{
        //string filename="Attendance Report";
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@category", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@startdate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.DateTimeForat(txt_sdate.Text.ToString());

        sqlparam[5] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparam[5].Value = chk_emp_status.Checked;
        sqlparam[6] = new SqlParameter("@company", SqlDbType.VarChar, 50);
        sqlparam[6].Value = ddl_cmpny.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_hourwise", sqlparam);
        DataTable dt = ds.Tables[0];
        DataColumn column_new = new DataColumn("Day");
        dt.Columns.Add(column_new);
        dt.Columns["Day"].SetOrdinal(4);
        dt.Columns["category_name"].SetOrdinal(2);
        dt.Columns["mode"].SetOrdinal(3);
        dt.Columns["date"].SetOrdinal(5);
        dt.Columns["TotalworkingHours"].SetOrdinal(6);
        dt.Columns.Remove("categoryID");
        dt.Columns.Remove("DesignationID");
        dt.Columns.Remove("emp_status");
        dt.Columns.Remove("companyid");
        foreach (DataRow dr in dt.Rows)
        {
            if (!string.IsNullOrEmpty(dr["date"].ToString()))
            {
                dr["Day"] = GetDay(dr["date"].ToString());
            }
            dr["date"] = Convert.ToDateTime(dr["date"]).ToString("dd-MMM-yyyy");
        }
        MailScript scriptObj = new MailScript();


        scriptObj.exportToExcelInCustomized(ds.Tables[0], attendancegrid.HeaderRow, "Hourwise attendance report", Page.Form, "hourwiseattrep");


    }
    protected void ddl_cmpny_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}