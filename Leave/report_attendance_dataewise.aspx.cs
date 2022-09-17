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
            bindattendance();

        }
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindattendance();
    }

    protected void bindattendance()
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[0].Value = Utility.dataformat(txt_sdate.Text.ToString());;

        sqlparm[1] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);
        sqlparm[1].Value = Utility.dataformat(txt_edate.Text.ToString());;

        sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[2].Value = Session["empcode"].ToString();

        attendancegrid.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail_datewise", sqlparm);
        attendancegrid.DataBind();
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
