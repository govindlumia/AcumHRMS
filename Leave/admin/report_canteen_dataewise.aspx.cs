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
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindattendance();
    }

    protected void bindattendance()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@dept", SqlDbType.Int);
        sqlparam[1].Value = "0";

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
        sqlparam[2].Value = "0";

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        attendancegrid.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_employee_canteendetail", sqlparam);
        attendancegrid.DataBind();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
        txt_employee.Text = "";
    }
   
   
    protected void attendancegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        attendancegrid.PageIndex = e.NewPageIndex;
        bindattendance();
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
