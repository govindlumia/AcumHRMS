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
using System.IO;

public partial class leave_report_leaveregister : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_employee.Attributes.Add("readonly", "readonly");
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
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        if (chk_temp.Checked)
        {
            //current week
            if (drp_template.SelectedValue == "0")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt;
                edate = sdate.AddDays(6);

            }
            //previous week
            if (drp_template.SelectedValue == "1")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(-7);
                edate = sdate.AddDays(6);
            }
            ////next week
            //if (drp_template.SelectedValue == "2")
            //{
            //    while (dt.DayOfWeek.ToString() != "Monday")
            //        dt = dt.AddDays(-1);
            //    sdate = dt.AddDays(7);
            //    edate = sdate.AddDays(6);
            //}

            if (drp_template.SelectedValue == "2")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(1).AddDays(-1);

                sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
                edate = lastday;
            }

            if (drp_template.SelectedValue == "3")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddDays(-1);

                if (DateTime.Today.Month == 1)
                {
                    sdate = Convert.ToDateTime("12/1/" + (DateTime.Today.Year - 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month - 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }
            //if (drp_template.SelectedValue == "5")
            //{
            //    sdate = Utility.dataformat((DateTime.Today.Month + 1) + "/1/" + DateTime.Today.Year.ToString());
            //    edate = Utility.dataformat((DateTime.Today.Month + 1) + "/30/" + DateTime.Today.Year.ToString());
            //}
            txt_sdate.Text = sdate.ToShortDateString();
            txt_edate.Text = edate.ToShortDateString();
        }
        else
        {
            sdate = Utility.DateTimeForat(txt_sdate.Text.ToString());
            edate = Utility.DateTimeForat(txt_edate.Text.ToString());
        }
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[0].Value = sdate;

        sqlparm[1] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);
        sqlparm[1].Value = edate;

        sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[2].Value = txt_employee.Text;
        sqlparm[3] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparm[3].Value = chk_empstatus.Checked;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail_datewise", sqlparm);
        ViewState["ExportToExcel"] = ds.Tables[0];
        attendancegrid.DataSource = ds;
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

    protected void chk_temp_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_temp.Checked == true)
        {
            date.Visible = false;
            template.Visible = true;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator11.Enabled = false;
        }
        else
        {
            date.Visible = true;
            template.Visible = false;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
        }
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

    public string GetDay(String uDate)
    {

        string day;
        DateTime date = Convert.ToDateTime(uDate);
        day = date.DayOfWeek.ToString();
        return day;
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
       
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        if (chk_temp.Checked)
        {
            //current week
            if (drp_template.SelectedValue == "0")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt;
                edate = sdate.AddDays(6);

            }
            //previous week
            if (drp_template.SelectedValue == "1")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(-7);
                edate = sdate.AddDays(6);
            }
            if (drp_template.SelectedValue == "2")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(1).AddDays(-1);

                sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
                edate = lastday;
            }

            if (drp_template.SelectedValue == "3")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddDays(-1);

                if (DateTime.Today.Month == 1)
                {
                    sdate = Convert.ToDateTime("12/1/" + (DateTime.Today.Year - 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month - 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }

            txt_sdate.Text = sdate.ToShortDateString();
            txt_edate.Text = edate.ToShortDateString();
        }
        else
        {
            sdate = Utility.DateTimeForat(txt_sdate.Text.ToString());
            edate = Utility.DateTimeForat(txt_edate.Text.ToString());
        }
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[0].Value = sdate;

        sqlparm[1] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);
        sqlparm[1].Value = edate;

        sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[2].Value = txt_employee.Text;

        sqlparm[3] = new SqlParameter("@emp_status", SqlDbType.Bit);
        sqlparm[3].Value = chk_empstatus.Checked;


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail_datewise", sqlparm);
        if (ds.Tables.Count > 0)
        {
            ds.Tables[0].Columns.Add(new DataColumn("day"));
            foreach (DataRow _dr in ds.Tables[0].Rows)
            {
                _dr["day"] = GetDay(_dr["Date"].ToString());
                _dr["Date"] = Convert.ToDateTime(_dr["Date"]).ToString("dd-MMM-yyyy");
            }
            DataTable dt_result = ds.Tables[0];
            dt_result.Columns["Category_name"].SetOrdinal(2);
            dt_result.Columns["mode"].SetOrdinal(3);
            dt_result.Columns["day"].SetOrdinal(4);
            dt_result.Columns["Date"].SetOrdinal(5);
            dt_result.Columns.Remove("empstatus");
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(ds.Tables[0], attendancegrid.HeaderRow, "Attendance Report Employee Wise", Page.Form, "attrepempwise");

        }
    }

    protected void exportexcel()
    {
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        if (chk_temp.Checked)
        {
            //current week
            if (drp_template.SelectedValue == "0")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt;
                edate = sdate.AddDays(6);

            }
            //previous week
            if (drp_template.SelectedValue == "1")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(-7);
                edate = sdate.AddDays(6);
            }
            if (drp_template.SelectedValue == "2")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(1).AddDays(-1);

                sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
                edate = lastday;
            }

            if (drp_template.SelectedValue == "3")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddDays(-1);

                if (DateTime.Today.Month == 1)
                {
                    sdate = Convert.ToDateTime("12/1/" + (DateTime.Today.Year - 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month - 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }

            txt_sdate.Text = sdate.ToShortDateString();
            txt_edate.Text = edate.ToShortDateString();
        }
        else
        {
            sdate = Utility.DateTimeForat(txt_sdate.Text.ToString());
            edate = Utility.DateTimeForat(txt_edate.Text.ToString());
        }
        SqlParameter[] sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
        sqlparm[0].Value = sdate;

        sqlparm[1] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);
        sqlparm[1].Value = edate;

        sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[2].Value = txt_employee.Text;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail_datewise", sqlparm);
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =Attendance1.xls";
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
                i.Cells[colindex].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

}
