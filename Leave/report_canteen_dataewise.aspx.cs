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
using System.Globalization;
using Utilities;

public partial class leave_report_leaveregister : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            DateTime dt = DateTime.Now;
            while (dt.DayOfWeek.ToString() != "Monday")
                dt = dt.AddDays(-1);
            txt_sdate.Text = dt.ToShortDateString();
            txt_edate.Text = dt.AddDays(6).ToShortDateString();
            bindcanteen();
        }
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindcanteen();
    }

    protected void bindcanteen()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@dept", SqlDbType.Int);
        sqlparam[1].Value = "0";

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["branch"].ToString();

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        attendancegrid.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_employee_canteendetail", sqlparam);
        attendancegrid.DataBind();
    }   
   
    protected void attendancegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        attendancegrid.PageIndex = e.NewPageIndex;
        bindcanteen();
    }
    protected void attendancegrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
                e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
            }
    }
}
