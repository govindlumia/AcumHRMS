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

public partial class leave_admin_viewattendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_sdate.Attributes.Add("readonly", "readonly");
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
        BindDropDowns(ddl_cmpy, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
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
        sqlparam[5].Value = chk_empstatus.Checked;
        sqlparam[6] = new SqlParameter("@company",SqlDbType.VarChar,50);
        sqlparam[6].Value = ddl_cmpy.SelectedValue;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail", sqlparam);
        attendancegrid.DataSource = ds;
        attendancegrid.DataBind();
    }
    
    protected void btnexport_Click(object sender, EventArgs e)
    {
      //  exportexcel();
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
        sqlparam[5].Value = chk_empstatus.Checked;
        sqlparam[6] = new SqlParameter("@company", SqlDbType.VarChar, 50);
        sqlparam[6].Value = ddl_cmpy.SelectedValue;
     
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail", sqlparam);
        MailScript scriptObj = new MailScript();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt_result = ds.Tables[0];
            dt_result.Columns.Add(new DataColumn("day"));
            foreach (DataRow dr in dt_result.Rows)
            {
                if (!string.IsNullOrEmpty(dr["date"].ToString()))
                    {
                        dr["day"] = GetDay(dr["date"].ToString());
                }
                dr["date"]=Convert.ToDateTime(dr["date"].ToString()).ToString("dd/MMM/yyyy");

            }

            dt_result.Columns["category_name"].SetOrdinal(2);
            dt_result.Columns["mode"].SetOrdinal(3);
            dt_result.Columns["day"].SetOrdinal(4);
            dt_result.Columns["date"].SetOrdinal(5);
            dt_result.Columns.Remove("categoryid");
            dt_result.Columns.Remove("designationID");
            dt_result.Columns.Remove("emp_status");
            dt_result.Columns.Remove("COMPANYID");
            scriptObj.exportToExcelInCustomized(ds.Tables[0], attendancegrid.HeaderRow, "Datewise Attendance", this.Page.Form, "attrepdatewise");
        }
        else

            ScriptManager.RegisterStartupScript(this, GetType(), "nodata", "alert('No data to export');", true);
    }

  
}
