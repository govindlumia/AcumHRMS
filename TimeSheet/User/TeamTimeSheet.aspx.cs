﻿using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Globalization;
using System.Threading;
using HRMS.BusinessLogic.TimeSheet;
using HRMS.BusinessEntity.TimeSheet;

public partial class TimeSheet_User_TeamTimeSheet : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataView dtView = new DataView();
    DataRow dr;
    int _datestart = 0;
    int _dateend = 0;
    DateTime _startDateOfWeek;
    decimal montime = 0, tuetime = 0, wedtime = 0, thurtime = 0, fritime = 0, sattime = 0, suntime = 0, Total = 0, Total_total = 0;
    MailScript scriptObj;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (scriptObj == null)
            {
                scriptObj = new MailScript();
            }
            try
            {
                if (Session["EmpCode"] == null)
                {
                    string str = Server.UrlEncode(Convert.ToString(Request.Url));
                    Response.Redirect("~/Login.aspx?url=" + str);
                }
                //   BindDateAndWeek();
                bindWeek();
                bindSubEmployee();
                BindData();
                Session["Bucket"] = null;
                Session["TimeSheet"] = null;

            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void bindSubEmployee()
    {
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        DataTable dt_result = balObj.getSubEmployees(Session["empcode"].ToString());
        if (dt_result.Rows.Count > 0)
        {
            ddl_employee.DataSource = dt_result;
            ddl_employee.DataTextField = "name";
            ddl_employee.DataValueField = "employeecode";
            ddl_employee.DataBind();
        }
    }

    private void bindWeek()
    {
        try
        {
            //DateTime startDate = Convert.ToDateTime(lblFromDate.Text);
            //DateTime endDate = Convert.ToDateTime(lblToDate.Text);



            DataTable dt_result = null;
            DataTable weekTable = null;
            if (ViewState["tempWeekTable"] == null)
            {
                createWeekTable();
                MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
                dt_result = balObj.getWeeksForTimeSheet();
                if (dt_result.Rows.Count > 0)
                {
                    weekTable = (DataTable)ViewState["tempWeekTable"];
                    DataRow _dr = null;
                    foreach (DataRow dr in dt_result.Rows)
                    {
                        _dr = weekTable.NewRow();
                        DateTime _startDate = Convert.ToDateTime(dr["StartDate"].ToString());
                        DateTime _endDate = Convert.ToDateTime(dr["EndDate"].ToString());
                        string _week = _startDate.ToString("dd/MM/yyyy") + ":" + _endDate.ToString("dd/MM/yyyy");
                        _dr["Id"] = dr["id"].ToString();
                        _dr["Year"] = dr["YEAR"].ToString();
                        _dr["Date"] = _week;
                        _dr["StartDate"] = dr["StartDate"].ToString();
                        _dr["EndDate"] = dr["EndDate"].ToString();
                        weekTable.Rows.Add(_dr);
                    }
                    ViewState["tempWeekTable"] = weekTable;
                }
            }
            else
            {
                weekTable = (DataTable)ViewState["tempWeekTable"];
            }
            ddl_week.DataSource = weekTable;
            ddl_week.DataTextField = "Date";
            ddl_week.DataValueField = "Id";
            ddl_week.DataBind();
            if (Request.QueryString["Week"] != null)
            {
                if (ddl_week.Items.FindByValue(Request.QueryString["Week"].ToString()) != null)
                {
                    ddl_week.SelectedValue = Request.QueryString["Week"].ToString();
                }
            }


        }
        catch (Exception ex)
        {


        }
    }

    private void createWeekTable()
    {
        ViewState["tempWeekTable"] = null;
        DataTable dtWeekTable = new DataTable();
        dtWeekTable.Columns.Add(new DataColumn("Id", typeof(string)));
        dtWeekTable.Columns.Add(new DataColumn("Year", typeof(string)));
        dtWeekTable.Columns.Add(new DataColumn("StartDate", typeof(string)));
        dtWeekTable.Columns.Add(new DataColumn("EndDate", typeof(string)));
        dtWeekTable.Columns.Add(new DataColumn("Date", typeof(string)));
        dtWeekTable.AcceptChanges();
        ViewState["tempWeekTable"] = dtWeekTable;
    }

    //protected void lnkAdd_Click(object sender, EventArgs e)
    //{
    //    BindDropDownBussiness binddrop = new BindDropDownBussiness();
    //    string dtt = binddrop.getDateAndWeek(Convert.ToDateTime("08/17/2014"));
    //    string dtf = DateTime.Now.ToString("MM-dd-yyyy");
    //    CultureInfo ciCurr = CultureInfo.CurrentCulture;
    //    DateTime datenew = Convert.ToDateTime(dtf);
    //    int weekNum = ciCurr.Calendar.GetWeekOfYear(datenew, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
    //}

    protected void BindDateAndWeek()
    {
        try
        {

            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            DayOfWeek firstday = info.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek today = info.Calendar.GetDayOfWeek(DateTime.Now);
            int diff = today - firstday - 1;
            DateTime firstDate = DateTime.Now.AddDays(-diff);
            DateTime StartDate = DateTime.Now.AddDays(-diff);
            DateTime lastDate = DateTime.Now.AddDays(-diff + 6);

        }
        catch (Exception ex)
        {
            BusinessHelper.ErrorLog(Request.Url.AbsolutePath + " " + ex.Message);
        }
        finally
        {

        }
    }

    protected void CreateTempTable()
    {
        //Temporary table for Time Sheet
        ViewState["TimeSheetTemp"] = null;
        DataTable dtSelfTemp = new DataTable();
        dtSelfTemp.Columns.Add(new DataColumn("ID", typeof(int)));
        dtSelfTemp.Columns.Add(new DataColumn("Project", typeof(string)));
        dtSelfTemp.Columns.Add(new DataColumn("Activity", typeof(string)));
        dtSelfTemp.Columns.Add(new DataColumn("Mon", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Tue", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Wed", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Thu", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Fri", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Sat", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Sun", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Total", typeof(decimal)));
        dtSelfTemp.Columns.Add(new DataColumn("Remarks", typeof(string)));

        for (int i = 0; i < 5; i++)
        {
            dr = dtSelfTemp.NewRow();
            dr["ID"] = i;
            dr["Mon"] = 0.0;
            dr["Tue"] = 0.0;
            dr["Wed"] = 0.0;
            dr["Thu"] = 0.0;
            dr["Fri"] = 0.0;
            dr["Sat"] = 0.0;
            dr["Sun"] = 0.0;
            dr["Total"] = 0.0;
            dtSelfTemp.Rows.Add(dr);
        }

        ViewState["SelfTemp"] = dtSelfTemp;

        BindData();
    }
    protected void BindData()
    {
        int count = 0;
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        MyTimeSheetENT domObj = new MyTimeSheetENT();
        domObj.empCode = ddl_employee.SelectedValue;
        domObj.weekID = Convert.ToInt32(ddl_week.SelectedValue);
        DataSet ds_result = balObj.getWeekTimeSheet(domObj);
        if (ds_result.Tables[2].Rows.Count > 0)
        {
            grd_status.DataSource = ds_result.Tables[2];
            grd_status.DataBind();
        }
        else
        {
            grd_status.DataSource = null;
            grd_status.DataBind();
        }


        DataTable dt_result = ds_result.Tables[1];
        dt_result.Columns.Add(new DataColumn("Total"));
        foreach (DataRow dr in dt_result.Rows)
        {
            if (string.IsNullOrEmpty(dr["ProName"].ToString()))
                continue;
            count++;
            Total = 0;
            if (!string.IsNullOrEmpty(dr["MonTime"].ToString()))
            {
                montime += Convert.ToDecimal(dr["MonTime"]);
                Total += Convert.ToDecimal(dr["MonTime"]);
            }
            if (!string.IsNullOrEmpty(dr["TuesTime"].ToString()))
            {
                tuetime += Convert.ToDecimal(dr["TuesTime"]);
                Total += Convert.ToDecimal(dr["TuesTime"]);
            }
            if (!string.IsNullOrEmpty(dr["WedTime"].ToString()))
            {
                wedtime += Convert.ToDecimal(dr["WedTime"]);
                Total += Convert.ToDecimal(dr["WedTime"]);

            }
            if (!string.IsNullOrEmpty(dr["ThurTime"].ToString()))
            {
                thurtime += Convert.ToDecimal(dr["ThurTime"]);
                Total += Convert.ToDecimal(dr["ThurTime"]);
            }
            if (!string.IsNullOrEmpty(dr["FriTime"].ToString()))
            {
                fritime += Convert.ToDecimal(dr["FriTime"]);
                Total += Convert.ToDecimal(dr["FriTime"]);
            }
            if (!string.IsNullOrEmpty(dr["SatTime"].ToString()))
            {
                sattime += Convert.ToDecimal(dr["SatTime"]);
                Total += Convert.ToDecimal(dr["SatTime"]);
            }
            if (!string.IsNullOrEmpty(dr["SunTime"].ToString()))
            {
                suntime += Convert.ToDecimal(dr["SunTime"]);
                Total += Convert.ToDecimal(dr["SunTime"]);
            }
            Total_total += Total;
            if (scriptObj == null)
                scriptObj = new MailScript();
            dr["Total"] = scriptObj.convertInHourMin(Total);

        }
        string _datefull = ddl_week.SelectedItem.Text.Trim();
        string[] _splitFull = _datefull.Split(':');
        DateTime _startdate = new DateTime();
        DateTime _enddate = new DateTime();
        if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
        {
            _startdate = DateTime.ParseExact(_splitFull[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _enddate = DateTime.ParseExact(_splitFull[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
        {
            _startdate = DateTime.ParseExact(_splitFull[0], "dd-MM-yyyy", CultureInfo.InvariantCulture);
            _enddate = DateTime.ParseExact(_splitFull[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        _startDateOfWeek = _startdate;
        _datestart = _startdate.Day;
        _dateend = _enddate.Day;

        if (dt_result.Rows.Count > 0)
        {
            GrdViewTimeSheet.DataSource = dt_result;
        }
        else
        {
            DataRow _dr = dt_result.NewRow();
            dt_result.Rows.Add(_dr);
            GrdViewTimeSheet.DataSource = dt_result;
        }
        GrdViewTimeSheet.DataBind();
        //      lbl_userofsheet.Text = "Timesheet of " + ddl_employee.SelectedItem + "  for week  " + ddl_week.SelectedItem +" ";

        string[] splitDates = ddl_week.SelectedItem.ToString().Split(':');
        if (splitDates.Length == 2)
        {
            try
            {
                lbl_userofsheet.Text = "Timesheet of " + ddl_employee.SelectedItem + " for week " + DateTime.ParseExact(splitDates[0], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy") + " to " + DateTime.ParseExact(splitDates[1], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                lbl_userofsheet.Text = "Timesheet of " + ddl_employee.SelectedItem + "  for week  " + ddl_week.SelectedItem + " ";
            }
        }
        else
            lbl_userofsheet.Text = "Timesheet of " + ddl_employee.SelectedItem + "  for week  " + ddl_week.SelectedItem + " ";

    }
    protected void AmountTotal()
    {

    }

    protected void ddl_week_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindData();
    }
    protected void GrdViewTimeSheet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TableCell column_mon = e.Row.Cells[2];
            if (column_mon != null)
                column_mon.Text = "Mon," + _startDateOfWeek.Day;
            TableCell column_tue = e.Row.Cells[3];
            if (column_tue != null)
                column_tue.Text = "Tue," + _startDateOfWeek.AddDays(1).Day;
            TableCell column_wed = e.Row.Cells[4];
            if (column_wed != null)
                column_wed.Text = "Wed," + _startDateOfWeek.AddDays(2).Day;
            TableCell column_thur = e.Row.Cells[5];
            if (column_thur != null)
                column_thur.Text = "Thu," + _startDateOfWeek.AddDays(3).Day;
            TableCell column_fri = e.Row.Cells[6];
            if (column_fri != null)
                column_fri.Text = "Fri," + _startDateOfWeek.AddDays(4).Day;
            TableCell column_sat = e.Row.Cells[7];
            if (column_sat != null)
                column_sat.Text = "Sat," + _startDateOfWeek.AddDays(5).Day;
            TableCell column_sun = e.Row.Cells[8];
            if (column_sun != null)
                column_sun.Text = "Sun," + _startDateOfWeek.AddDays(6).Day;
            TableCell column_total = e.Row.Cells[9];

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (scriptObj == null)
                scriptObj = new MailScript();
            TableCell column_mon = e.Row.Cells[2];
            if (column_mon != null)
                column_mon.Text = scriptObj.convertInHourMin(montime).ToString();
            TableCell column_tue = e.Row.Cells[3];
            if (column_tue != null)
                column_tue.Text = scriptObj.convertInHourMin(tuetime).ToString();
            TableCell column_wed = e.Row.Cells[4];
            if (column_wed != null)
                column_wed.Text = scriptObj.convertInHourMin(wedtime).ToString();
            TableCell column_thur = e.Row.Cells[5];
            if (column_thur != null)
                column_thur.Text = scriptObj.convertInHourMin(thurtime).ToString();
            TableCell column_fri = e.Row.Cells[6];
            if (column_fri != null)
                column_fri.Text = scriptObj.convertInHourMin(fritime).ToString();
            TableCell column_sat = e.Row.Cells[7];
            if (column_sat != null)
                column_sat.Text = scriptObj.convertInHourMin(sattime).ToString();
            TableCell column_sun = e.Row.Cells[8];
            if (column_sun != null)
                column_sun.Text = scriptObj.convertInHourMin(suntime).ToString();
            TableCell column_total = e.Row.Cells[9];
            if (column_total != null)
            {
                column_total.Text = scriptObj.convertInHourMin(Total_total).ToString();

            }
        }
    }


    protected void btn_view_Click(object sender, EventArgs e)
    {
        BindData();
    }
}