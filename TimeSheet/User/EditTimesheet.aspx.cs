﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic.TimeSheet;
using HRMS.BusinessEntity.TimeSheet;
using System.Data;
using System.Globalization;
using HRMS.BusinessEntity.Leave;
using HRMS.BusinessLogic;

public partial class TimeSheet_User_EditTimesheet : System.Web.UI.Page
{

    int _datestart = 0;
    int _dateend = 0;
    LeaveBAL leaveBAL = new LeaveBAL();
    DateTime _startDateOfWeek;
    decimal montime = 0, tuetime = 0, wedtime = 0, thurtime = 0, fritime = 0, sattime = 0, suntime = 0, Total = 0, Total_total = 0;
    MailScript scriptObj;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (scriptObj == null)
        {
            scriptObj = new MailScript();
        }

        //if (Request.QueryString.Count > 0)
        //{
        //if (Request.QueryString["data"] != null)
        //{
        //QueryStringEncryption.Cryptography crypt = new QueryStringEncryption.Cryptography();
        //string data = crypt.Decrypt(Request.QueryString["data"].ToString());
        if (!IsPostBack)
        {
            if (Session["EmpEditData"] != null)
            {
                string empEditData = Session["EmpEditData"].ToString();
                string[] splitData = empEditData.Split('&');
                if (splitData.Length == 3)
                {
                    ViewState["weekForTimehsset"] = splitData[1];
                    string[] week_split = splitData[1].Split(':');

                    ViewState["FromDate"] = week_split[0];
                    ViewState["Todate"] = week_split[1];
                    //   lbl_fromweek.Text = week_split[0];
                    // lbl_toweek.Text = week_split[1];

                    lbl_fromweek.Text = DateTime.ParseExact(week_split[0], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");

                    //  lbl_fromweek.Text = Convert.ToDateTime(week_split[0]).ToString("dd-MMM-yyyy");
                    lbl_toweek.Text = DateTime.ParseExact(week_split[1], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");

                    ViewState["weekID"] = splitData[2];
                    ViewState["empForTimeSheet"] = splitData[0];
                    if (!Session["EmpCode"].Equals(splitData[0].Trim()))
                    {
                        Response.Redirect("MyTimesheet.aspx", false);
                    }

                    bindGrid();
                }
                else
                {
                    hideAll();
                }
            }
            else if (Session["EmpEditDataByAdmin"] != null)
            {
                string empEditData = Session["EmpEditDataByAdmin"].ToString();
                string[] splitData = empEditData.Split('&');
                if (splitData.Length == 3)
                {
                    string[] week_split = splitData[1].Split(':');
                    //lbl_fromweek.Text = week_split[0];
                    //lbl_toweek.Text = week_split[1];
                    lbl_fromweek.Text = DateTime.ParseExact(week_split[0], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
                    lbl_toweek.Text = DateTime.ParseExact(week_split[1], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
                    ViewState["weekID"] = splitData[2];
                    ViewState["empForTimeSheet"] = splitData[0];
                    //Response.Redirect("MyEmployeeTimeSheet.aspx", false);


                    bindGrid();
                }
                else
                {
                    hideAll();
                }
            }
            else
            {
                hideAll();
            }
        }
        // }
        //  }
    }
    //Added By RK Chauhan
    /// <summary>
    /// Read user applyed leave
    /// </summary>
    /// <returns></returns>
    protected List<AppliedLeave> readLeavByEmpcode()
    {
        AppliedLeave appliedLeave = new AppliedLeave();
        var lstappliedLeave = new List<AppliedLeave>();

        appliedLeave.EmployeeCode = Convert.ToString(ViewState["empForTimeSheet"]);
        lstappliedLeave = leaveBAL.readAppliedLeavByCode(appliedLeave);

        return lstappliedLeave;
    }
    private List<AppliedLeave> readOdByEmpcode()
    {
        AppliedLeave appliedLeave = new AppliedLeave();

        var lstappliedOd = new List<AppliedLeave>();
        appliedLeave.EmployeeCode = Convert.ToString(ViewState["empForTimeSheet"]);
        lstappliedOd = leaveBAL.readAppliedOdByCode(appliedLeave);
        return lstappliedOd;
    }
    /// <summary>
    /// Chekc the daywise leave
    /// </summary>
    /// <param name="lstAppliedLeaves"></param>
    /// <param name="leaveCheckDate"></param>
    /// <returns></returns>
    private bool IsLeavThatDay(List<AppliedLeave> lstAppliedLeaves, DateTime leaveCheckDate)
    {
        foreach (var item in lstAppliedLeaves)
        {
            if (leaveCheckDate >= item.FromDate && leaveCheckDate <= item.ToDate)
            {
                return true;
            }
        }
        return false;
    }
    private bool IsOdThatDay(List<AppliedLeave> lstAppliedOd, DateTime leaveCheckDate)
    {
        foreach (var item in lstAppliedOd)
        {
            if ((leaveCheckDate >= item.FromDate && leaveCheckDate <= item.ToDate) && (item.status))
            {
                return true;
            }
        }
        return false;
    }
    //End Added By Rk Chauhan
    private void hideAll()
    {
        btn_add_row.Visible = false;
        btn_cancel.Visible = false;
        btn_reset.Visible = false;
        btn_rmv_row.Visible = false;
        btn_save.Visible = false;
    }

    private void bindGrid()
    {
        DataTable dt_result = null;
        if (ViewState["dataForGrid"] != null)
            dt_result = (DataTable)ViewState["dataForGrid"];
        else
        {
            MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
            MyTimeSheetENT domObj = new MyTimeSheetENT();
            // domObj.empCode = Session["EmpCode"].ToString();    --Change
            domObj.empCode = ViewState["empForTimeSheet"].ToString();
            domObj.weekID = Convert.ToInt32(ViewState["weekID"]);
            DataSet ds_result = balObj.getWeekTimeSheet(domObj);
            dt_result = ds_result.Tables[1];
            dt_result.Columns.Add(new DataColumn("Total"));
            if (dt_result.Rows.Count > 0)
            {
                ViewState["TimeSheetID"] = dt_result.Rows[0]["TimeSheetID"].ToString();
                foreach (DataRow dr in dt_result.Rows)
                {
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
                        Total += Convert.ToDecimal(dr["SunTime"]);
                        suntime += Convert.ToDecimal(dr["SunTime"]);
                    }

                    Total_total += Total;

                    dr["Total"] = scriptObj.convertInHourMin(Total);
                }

                DateTime _startdate = new DateTime();
                DateTime _enddate = new DateTime();
                _startdate = Convert.ToDateTime(lbl_fromweek.Text);
                _enddate = Convert.ToDateTime(lbl_toweek.Text);
                //if (lbl_fromweek.Text.Contains('/'))
                //{
                //    //_startdate = DateTime.ParseExact(lbl_fromweek.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //    //_enddate = DateTime.ParseExact(lbl_toweek.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //}
                //if (lbl_fromweek.Text.Contains('-'))
                //{
                //    _startdate = DateTime.ParseExact(lbl_fromweek.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //    _enddate = DateTime.ParseExact(lbl_toweek.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //}

                _startDateOfWeek = _startdate;
                _datestart = _startdate.Day;
                _dateend = _enddate.Day;

                ViewState["dataForGrid"] = dt_result;
            }
            else
            {
                DataRow _dr_new = dt_result.NewRow();
                _dr_new["ID"] = "0";
                dt_result.Rows.Add(_dr_new);
            }
        }
        if (dt_result.Rows.Count > 0)
        {
            montime = 0; tuetime = 0; wedtime = 0; thurtime = 0; fritime = 0; sattime = 0;
            suntime = 0;
            Grd_edit_timesheet.DataSource = dt_result;
            Grd_edit_timesheet.DataBind();
            //Added By RK Chauhan

            //Find The  start Date of week 
            string fromDate = Convert.ToString(ViewState["FromDate"]);
            var lstappliedLeave = new List<AppliedLeave>();
            //Call the Method for finding applied leave List
            lstappliedLeave = readLeavByEmpcode();

            //Find the all textbox Which are Bind in grid
            for (int i = 0; i < Grd_edit_timesheet.Rows.Count; i++)
            {

                TextBox textboxMon = null; TextBox textboxWed = null;
                TextBox textboxTue = null; TextBox textboxThu = null;
                TextBox textboxFri = null; TextBox textboxSat = null; TextBox textboxSan = null;
                //Check For applied leave and valide for can't fill the time at applied leave day.  
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                {

                    textboxMon = (TextBox)Grd_edit_timesheet.Rows[i].Cells[3].FindControl("txt_montime");
                    textboxMon.Enabled = false;
                }

                else
                {
                    textboxMon = (TextBox)Grd_edit_timesheet.Rows[i].Cells[3].FindControl("txt_montime");
                    textboxMon.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1)))
                {
                    textboxTue = (TextBox)Grd_edit_timesheet.Rows[i].Cells[4].FindControl("txt_tuestime");
                    textboxTue.Enabled = false;
                }
                else
                {
                    textboxTue = (TextBox)Grd_edit_timesheet.Rows[i].Cells[4].FindControl("txt_tuestime");
                    textboxTue.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(2)))
                {
                    textboxWed = (TextBox)Grd_edit_timesheet.Rows[i].Cells[5].FindControl("txt_wedtime");
                    textboxWed.Enabled = false;
                }
                else
                {
                    textboxWed = (TextBox)Grd_edit_timesheet.Rows[i].Cells[5].FindControl("txt_wedtime");
                    textboxWed.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(3)))
                {
                    textboxThu = (TextBox)Grd_edit_timesheet.Rows[i].Cells[6].FindControl("txt_thutime");
                    textboxThu.Enabled = false;
                }
                else
                {
                    textboxThu = (TextBox)Grd_edit_timesheet.Rows[i].Cells[6].FindControl("txt_thutime");
                    textboxThu.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(4)))
                {
                    textboxFri = (TextBox)Grd_edit_timesheet.Rows[i].Cells[7].FindControl("txt_fritime");
                    textboxFri.Enabled = false;
                }
                else
                {
                    textboxFri = (TextBox)Grd_edit_timesheet.Rows[i].Cells[7].FindControl("txt_fritime");
                    textboxFri.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(5)))
                {
                    textboxSat = (TextBox)Grd_edit_timesheet.Rows[i].Cells[8].FindControl("txt_sattime");
                    textboxSat.Enabled = false;
                }
                else
                {
                    textboxSat = (TextBox)Grd_edit_timesheet.Rows[i].Cells[8].FindControl("txt_sattime");
                    textboxSat.Enabled = true;
                }
                if (IsLeavThatDay(lstappliedLeave, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(6)))
                {
                    textboxSan = (TextBox)Grd_edit_timesheet.Rows[i].Cells[9].FindControl("txt_suntime");
                    textboxSan.Enabled = false;
                }
                else
                {
                    textboxSan = (TextBox)Grd_edit_timesheet.Rows[i].Cells[9].FindControl("txt_suntime");
                    textboxSan.Enabled = true;
                }
            }
            //End Added By RK Chauhan
            GridViewRow gvr = Grd_edit_timesheet.FooterRow;
            if (gvr != null)
            {

                Label lbl_montime = (Label)gvr.FindControl("MonTotal");
                Label lbl_tuetime = (Label)gvr.FindControl("TueTotal");
                Label lbl_wedtime = (Label)gvr.FindControl("WedTotal");
                Label lbl_thurtime = (Label)gvr.FindControl("ThuTotal");
                Label lbl_fritime = (Label)gvr.FindControl("FriTotal");
                Label lbl_sattime = (Label)gvr.FindControl("SatTotal");
                Label lbl_suntime = (Label)gvr.FindControl("SunTotal");
                Label lbl_totalAll = (Label)gvr.FindControl("TxtTotal");
                foreach (DataRow _dr in dt_result.Rows)
                {
                    if (!string.IsNullOrEmpty(_dr["MonTime"].ToString()))
                        montime += Convert.ToDecimal(_dr["MonTime"]);
                    if (!string.IsNullOrEmpty(_dr["TuesTime"].ToString()))
                        tuetime += Convert.ToDecimal(_dr["TuesTime"]);
                    if (!string.IsNullOrEmpty(_dr["WedTime"].ToString()))
                        wedtime += Convert.ToDecimal(_dr["WedTime"]);
                    if (!string.IsNullOrEmpty(_dr["ThurTime"].ToString()))
                        thurtime += Convert.ToDecimal(_dr["ThurTime"]);
                    if (!string.IsNullOrEmpty(_dr["FriTime"].ToString()))
                        fritime += Convert.ToDecimal(_dr["FriTime"]);
                    if (!string.IsNullOrEmpty(_dr["SatTime"].ToString()))
                        sattime += Convert.ToDecimal(_dr["SatTime"]);
                    if (!string.IsNullOrEmpty(_dr["SunTime"].ToString()))
                        suntime += Convert.ToDecimal(_dr["SunTime"]);

                }
                lbl_montime.Text = scriptObj.convertInHourMin(montime).ToString();
                lbl_tuetime.Text = scriptObj.convertInHourMin(tuetime).ToString();
                lbl_wedtime.Text = scriptObj.convertInHourMin(wedtime).ToString();
                lbl_thurtime.Text = scriptObj.convertInHourMin(thurtime).ToString();
                lbl_fritime.Text = scriptObj.convertInHourMin(fritime).ToString();
                lbl_sattime.Text = scriptObj.convertInHourMin(sattime).ToString();
                lbl_suntime.Text = scriptObj.convertInHourMin(suntime).ToString();
                lbl_totalAll.Text = scriptObj.convertInHourMin((montime + tuetime + wedtime + thurtime + fritime + sattime + suntime)).ToString();

            }
            ViewState["dataForGrid"] = dt_result;
        }
        else
        {
            Grd_edit_timesheet.DataSource = null;
            Grd_edit_timesheet.DataBind();
        }
    }
    protected void btn_add_row_Click(object sender, EventArgs e)
    {
        DataTable dt_result = (DataTable)ViewState["dataForGrid"];
        DataRow dr = dt_result.NewRow();
        if (dt_result.Rows.Count > 0)
        {
            dr["ID"] = Convert.ToInt32(dt_result.Rows[dt_result.Rows.Count - 1]["ID"]) + 1;
            dr["TimeSheetID"] = ViewState["TimeSheetID"].ToString();
        }
        else
        {
            dr["ID"] = "0";
            dr["TimeSheetID"] = ViewState["TimeSheetID"].ToString();
        }
        dt_result.Rows.Add(dr);
        ViewState["dataForGrid"] = dt_result;
        bindGrid();
    }
    protected void btn_rmv_row_Click(object sender, EventArgs e)
    {
        int count = 0;
        DataTable dt_result = (DataTable)ViewState["dataForGrid"];
        foreach (GridViewRow gvr in Grd_edit_timesheet.Rows)
        {
            CheckBox chk = (CheckBox)gvr.FindControl("chk_data");

            if (chk != null)
            {
                if (chk.Checked)
                {
                    count++;
                    DataRow[] dr = dt_result.Select("ID=" + Grd_edit_timesheet.DataKeys[gvr.RowIndex].Value);
                    dt_result.Rows.Remove(dr[0]);

                }
            }
        }
        if (count > 0)
        {
            ViewState["dataForGrid"] = dt_result;
            bindGrid();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "noselect", "alert('No row selected to delete');", true);
            return;
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        ViewState["dataForGrid"] = null;
        bindGrid();
    }
    protected void changeStatus(object sender, EventArgs e)
    {
        DropDownList ddl_activity = sender as DropDownList;
        if (ddl_activity != null)
        {
            DataTable dt_result = (DataTable)ViewState["dataForGrid"];
            DataRow[] rows = dt_result.Select("ID=" + ddl_activity.ToolTip);
            if (rows.Length > 0)
            {
                DataRow dr = rows[0];
                dr["ActivityName"] = ddl_activity.SelectedItem.Text.Trim();
                ViewState["dataForGrid"] = dt_result;
            }

        }
    }
    private bool checkLimit(string ID, string newValue, DataTable _dtresult, string rowID)
    {
        decimal fullValue = 0;
        foreach (DataRow _dr in _dtresult.Rows)
        {
            if (rowID != _dr["ID"].ToString())
                fullValue += string.IsNullOrEmpty(_dr[ID].ToString()) ? 0 : Convert.ToDecimal(_dr[ID]);
        }
        if ((fullValue + Convert.ToDecimal(newValue)) > 10)
            return false;
        else
            return true;
    }
    protected void calculateTotal_Click(object sender, EventArgs e)
    {
        TextBox txt_bx = null;
        //Find The  start Date of week 
        string fromDate = Convert.ToString(ViewState["FromDate"]);
        var empcode = Session["empcode"].ToString();
        //Read All Applied Od By user
        var lstappliedOd = new List<AppliedLeave>();
        lstappliedOd = readOdByEmpcode();
        try
        {
            txt_bx = sender as TextBox;
            string txt = txt_bx.Text;
            string id = txt_bx.ID;
            string tool = txt_bx.ToolTip;
            DataTable dt_result = (DataTable)ViewState["dataForGrid"];
            DataRow[] rows = dt_result.Select("ID=" + tool);
            if (rows.Length > 0)
            {
                DataRow dr = rows[0];
                if (id.Equals("txt_montime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("MonTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mon", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                        {
                            var validatemon = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), empcode);
                            dr["MonTime"] = txt_bx.Text;
                            if (validatemon)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "mon", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }
                        }
                        dr["MonTime"] = txt_bx.Text;
                    }
                    else
                        dr["MonTime"] = 0;
                }
                else if (id.Equals("txt_tuestime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("TuesTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "tue", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1)))
                        {
                            var validatetue = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1), empcode);
                            dr["TuesTime"] = txt_bx.Text;
                            if (validatetue)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "tue", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["TuesTime"] = txt_bx.Text;
                    }
                    else
                        dr["TuesTime"] = 0;
                }
                else if (id.Equals("txt_wedtime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("WedTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "wed", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(2)))
                        {
                            var validatewed = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(2), empcode);

                            dr["WedTime"] = txt_bx.Text;
                            if (validatewed)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "wed", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["WedTime"] = txt_bx.Text;
                    }
                    else
                        dr["WedTime"] = 0;
                }
                else if (id.Equals("txt_thutime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("ThurTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "thu", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(3)))
                        {
                            var validatethru = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(3), empcode);

                            dr["ThurTime"] = txt_bx.Text;
                            if (validatethru)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "thu", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["ThurTime"] = txt_bx.Text;
                    }
                    else
                        dr["ThurTime"] = 0;
                }
                else if (id.Equals("txt_fritime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("FriTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "fri", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(4)))
                        {
                            var validatefri = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(4), empcode);

                            dr["FriTime"] = txt_bx.Text;
                            if (validatefri)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "fri", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["FriTime"] = txt_bx.Text;
                    }
                    else
                        dr["FriTime"] = 0;
                }
                else if (id.Equals("txt_sattime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("SatTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "sat", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(5)))
                        {
                            var validatesat = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(5), empcode);

                            dr["SatTime"] = txt_bx.Text;
                            if (validatesat)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "sat", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["SatTime"] = txt_bx.Text;
                    }
                    else
                        dr["SatTime"] = 0;
                }
                else if (id.Equals("txt_suntime"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                    {
                        if (!checkLimit("SunTime", txt_bx.Text.Trim(), dt_result, tool))
                        {
                            txt_bx.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "sun", "alert('Max working hours for a day can be 10 hr');", true);
                            return;
                        }
                        if (!IsOdThatDay(lstappliedOd, DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(6)))
                        {
                            var validatesun = leaveBAL.ValidateApplieOd(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(6), empcode);

                            dr["SunTime"] = txt_bx.Text;
                            if (validatesun)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "sun", "alert('You OD is not approved , you will be able to fill the data once your OD is approved by your Manager');", true);
                                return;
                            }

                        }
                        dr["SunTime"] = txt_bx.Text;
                    }
                    else
                        dr["SunTime"] = 0;
                }

                else if (id.Equals("txt_comment"))
                {
                    if (!string.IsNullOrEmpty(txt_bx.Text.Trim()))
                        dr["UserComment"] = txt_bx.Text;
                    else
                        dr["UserComment"] = "";
                }
                else if (id.Equals("txt_projectName"))
                {
                    {
                        dr["ProName"] = txt_bx.Text;
                        foreach (GridViewRow _gvr in Grd_edit_timesheet.Rows)
                        {
                            if (Grd_edit_timesheet.DataKeys[_gvr.RowIndex].Value.ToString().Trim().Equals(tool.Trim()))
                            {
                                //TextBox txt_activity = (TextBox)_gvr.FindControl("txt_ActivityName");
                                //txt_activity.Text = "";
                                //AjaxControlToolkit.AutoCompleteExtender ace = (AjaxControlToolkit.AutoCompleteExtender)_gvr.FindControl("AutoCom_Activity");
                                //ace.ContextKey = txt_bx.Text;
                                // TextBox txt_activity = (TextBox)_gvr.FindControl("txt_ActivityName");
                                DropDownList ddl_activity = (DropDownList)_gvr.FindControl("ddl_category");
                                MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
                                DataTable dt_result_new = balObj.getActivityList_New(txt_bx.Text.Trim());
                                if (dt_result_new.Rows.Count > 0)
                                {
                                    ddl_activity.DataSource = dt_result_new;
                                    ddl_activity.ToolTip = tool.Trim();
                                    ddl_activity.DataTextField = "ActivityName";
                                    ddl_activity.DataValueField = "id";
                                    ddl_activity.DataBind();
                                    dr["ActivityName"] = ddl_activity.SelectedItem.Text.Trim();
                                }
                                else
                                {

                                    ddl_activity.Items.Clear();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "noactivity", "alert('No Activity defined for this project');", true);
                                    txt_bx.Text = "";
                                    txt_bx.Focus();
                                }
                                break;
                            }
                        }
                    }
                }

                decimal _total = 0;

                if (!string.IsNullOrEmpty(dr["MonTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["MonTime"]);
                }
                if (!string.IsNullOrEmpty(dr["TuesTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["TuesTime"]);
                }
                if (!string.IsNullOrEmpty(dr["WedTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["WedTime"]);
                }
                if (!string.IsNullOrEmpty(dr["ThurTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["ThurTime"]);
                }
                if (!string.IsNullOrEmpty(dr["FriTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["FriTime"]);
                }
                if (!string.IsNullOrEmpty(dr["SatTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["SatTime"]);
                }
                if (!string.IsNullOrEmpty(dr["SunTime"].ToString()))
                {
                    _total += Convert.ToDecimal(dr["SunTime"]);
                }
                dr["Total"] = _total;

                foreach (GridViewRow gvr_new in Grd_edit_timesheet.Rows)
                {
                    if (Grd_edit_timesheet.DataKeys[gvr_new.RowIndex].Value.ToString().Trim().Equals(dr["ID"].ToString().Trim()))
                    {
                        Label lbl_total = (Label)gvr_new.FindControl("lbl_total");
                        if (lbl_total != null)
                            lbl_total.Text = scriptObj.convertInHourMin(_total).ToString(); //doubt
                        break;
                    }
                }

                dt_result.AcceptChanges();
                decimal total_new = 0;
                GridViewRow gvr = Grd_edit_timesheet.FooterRow;
                if (gvr != null)
                {
                    Label lbl_montime = (Label)gvr.FindControl("MonTotal");
                    Label lbl_tuetime = (Label)gvr.FindControl("TueTotal");
                    Label lbl_wedtime = (Label)gvr.FindControl("WedTotal");
                    Label lbl_thurtime = (Label)gvr.FindControl("ThuTotal");
                    Label lbl_fritime = (Label)gvr.FindControl("FriTotal");
                    Label lbl_sattime = (Label)gvr.FindControl("SatTotal");
                    Label lbl_suntime = (Label)gvr.FindControl("SunTotal");
                    Label lbl_total = (Label)gvr.FindControl("TxtTotal");

                    foreach (DataRow _dr in dt_result.Rows)
                    {
                        if (!string.IsNullOrEmpty(_dr["MonTime"].ToString()))
                        {
                            montime += Convert.ToDecimal(_dr["MonTime"]);
                        }
                        if (!string.IsNullOrEmpty(_dr["TuesTime"].ToString()))
                            tuetime += Convert.ToDecimal(_dr["TuesTime"]);
                        if (!string.IsNullOrEmpty(_dr["WedTime"].ToString()))
                            wedtime += Convert.ToDecimal(_dr["WedTime"]);
                        if (!string.IsNullOrEmpty(_dr["ThurTime"].ToString()))
                            thurtime += Convert.ToDecimal(_dr["ThurTime"]);
                        if (!string.IsNullOrEmpty(_dr["FriTime"].ToString()))
                            fritime += Convert.ToDecimal(_dr["FriTime"]);
                        if (!string.IsNullOrEmpty(_dr["SatTime"].ToString()))
                            sattime += Convert.ToDecimal(_dr["SatTime"]);
                        if (!string.IsNullOrEmpty(_dr["SunTime"].ToString()))
                            suntime += Convert.ToDecimal(_dr["SunTime"]);

                    }
                    lbl_montime.Text = scriptObj.convertInHourMin(montime).ToString();
                    lbl_tuetime.Text = scriptObj.convertInHourMin(tuetime).ToString();
                    lbl_wedtime.Text = scriptObj.convertInHourMin(wedtime).ToString();
                    lbl_thurtime.Text = scriptObj.convertInHourMin(thurtime).ToString();
                    lbl_fritime.Text = scriptObj.convertInHourMin(fritime).ToString();
                    lbl_sattime.Text = scriptObj.convertInHourMin(sattime).ToString();
                    lbl_suntime.Text = scriptObj.convertInHourMin(suntime).ToString();
                    lbl_total.Text = scriptObj.convertInHourMin((montime + tuetime + wedtime + thurtime + fritime + sattime + suntime)).ToString();

                }
                ViewState["dataForGrid"] = dt_result;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nomatch", "alert('Enter only numeric values');", true);
            if (txt_bx != null)
            {
                txt_bx.Text = "";
            }
        }

    }
    protected void Grd_edit_timesheet_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    [System.Web.Script.Services.ScriptMethod()]

    [System.Web.Services.WebMethod]

    public static List<string> AutoComplete_Project(string prefixText, int count, string contextKey)
    {
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();

        DataTable dt = balObj.getProjectsList(prefixText);

        List<string> ProjectList = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            ProjectList.Add(dt.Rows[i][0].ToString());

        }

        return ProjectList;

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> AutoComplete_Activities(string prefixText, int count, string contextKey)
    {
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();

        DataTable dt = balObj.getActivityList(prefixText, contextKey);

        List<string> ProjectList = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ProjectList.Add(dt.Rows[i][0].ToString());
        }
        return ProjectList;
    }
    protected void Grd_edit_timesheet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TableCell column_mon = e.Row.Cells[3];
            if (column_mon != null)
                column_mon.Text = "Mon," + _startDateOfWeek.Day;
            TableCell column_tue = e.Row.Cells[4];
            if (column_tue != null)
                column_tue.Text = "Tue," + _startDateOfWeek.AddDays(1).Day;
            TableCell column_wed = e.Row.Cells[5];
            if (column_wed != null)
                column_wed.Text = "Wed," + _startDateOfWeek.AddDays(2).Day;
            TableCell column_thur = e.Row.Cells[6];
            if (column_thur != null)
                column_thur.Text = "Thu," + _startDateOfWeek.AddDays(3).Day;
            TableCell column_fri = e.Row.Cells[7];
            if (column_fri != null)
                column_fri.Text = "Fri," + _startDateOfWeek.AddDays(4).Day;
            TableCell column_sat = e.Row.Cells[8];
            if (column_sat != null)
                column_sat.Text = "Sat," + _startDateOfWeek.AddDays(5).Day;
            TableCell column_sun = e.Row.Cells[9];
            if (column_sun != null)
                column_sun.Text = "Sun," + _startDateOfWeek.AddDays(6).Day;
            TableCell column_total = e.Row.Cells[10];

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int ID = Convert.ToInt32(Grd_edit_timesheet.DataKeys[e.Row.RowIndex].Value);
            DropDownList ddl_activity = (DropDownList)e.Row.FindControl("ddl_category");
            TextBox txt_project = (TextBox)e.Row.FindControl("txt_projectName");
            Label lbl_category = (Label)e.Row.FindControl("lbl_category");
            if (ddl_activity != null && txt_project != null)
            {
                MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
                DataTable dt_result_new = balObj.getActivityList_New(txt_project.Text.Trim());
                if (dt_result_new.Rows.Count > 0)
                {
                    ddl_activity.DataSource = dt_result_new;
                    ddl_activity.ToolTip = ID + "";
                    ddl_activity.DataTextField = "ActivityName";
                    ddl_activity.DataValueField = "id";
                    ddl_activity.DataBind();
                    ListItem lst_item = ddl_activity.Items.FindByText(lbl_category.Text.Trim());
                    if (lst_item != null)
                    {
                        ddl_activity.SelectedIndex = ddl_activity.Items.IndexOf(lst_item);
                    }
                }

            }
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_result = (DataTable)ViewState["dataForGrid"];
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow _dr in dt_result.Rows)
            {
                if (string.IsNullOrEmpty(_dr["ProName"].ToString().Trim()) || string.IsNullOrEmpty(_dr["ActivityName"].ToString().Trim()))
                {
                    rows.Add(_dr);
                }
            }
            foreach (DataRow _dr_new in rows)
            {
                dt_result.Rows.Remove(_dr_new);
            }
            MyTimeSheetENT domObj = null;
            MyTimeSheetBussiness balObj = null;
            if (dt_result.Rows.Count > 0)
            {
                Random randomNumber = new Random();
                int generatedNo = randomNumber.Next(100, int.MaxValue);
                string rannum = generatedNo.ToString();
                foreach (DataRow _dr_final in dt_result.Rows)
                {
                    domObj = new MyTimeSheetENT();
                    balObj = new MyTimeSheetBussiness();
                    //domObj.empCode = Session["EmpCode"].ToString();    --change
                    domObj.empCode = ViewState["empForTimeSheet"].ToString();
                    domObj.weekID = Convert.ToInt32(ViewState["weekID"]);
                    domObj.timeSheetID = Convert.ToInt32(ViewState["TimeSheetID"]);
                    domObj.ProName = _dr_final["ProName"].ToString();
                    domObj.ActivityName = _dr_final["ActivityName"].ToString();
                    if (!string.IsNullOrEmpty(_dr_final["MonTime"].ToString().Trim()))
                        domObj.MonTime = Convert.ToDecimal(_dr_final["MonTime"]);
                    else
                        domObj.MonTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["TuesTime"].ToString().Trim()))
                        domObj.TuesTime = Convert.ToDecimal(_dr_final["TuesTime"]);
                    else
                        domObj.TuesTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["WedTime"].ToString().Trim()))
                        domObj.WedTime = Convert.ToDecimal(_dr_final["WedTime"]);
                    else
                        domObj.WedTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["ThurTime"].ToString().Trim()))
                        domObj.ThurTime = Convert.ToDecimal(_dr_final["ThurTime"]);
                    else
                        domObj.ThurTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["FriTime"].ToString().Trim()))
                        domObj.FriTime = Convert.ToDecimal(_dr_final["FriTime"]);
                    else
                        domObj.FriTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["SatTime"].ToString().Trim()))
                        domObj.SatTime = Convert.ToDecimal(_dr_final["SatTime"]);
                    else
                        domObj.SatTime = 0;
                    if (!string.IsNullOrEmpty(_dr_final["SunTime"].ToString().Trim()))
                        domObj.SunTime = Convert.ToDecimal(_dr_final["SunTime"]);
                    else
                        domObj.SunTime = 0;
                    domObj.UserComment = _dr_final["UserComment"].ToString();
                    domObj.session = Session.SessionID;
                    domObj.autoCode = rannum;
                    string result = balObj.insertTimeSheetByUser(domObj);
                }
            }
            else
            {
                domObj = new MyTimeSheetENT();
                balObj = new MyTimeSheetBussiness();
                //  domObj.empCode = Session["EmpCode"].ToString();   --change
                domObj.empCode = ViewState["empForTimeSheet"].ToString();
                domObj.weekID = Convert.ToInt32(ViewState["weekID"]);
                domObj.timeSheetID = Convert.ToInt32(ViewState["TimeSheetID"]);
                string result = balObj.deleteUserTimeSheet(domObj);
            }
            //  Session["EmpEditData"] = null;   --change
            if (Session["EmpEditData"] != null)
            {
                Session["EmpEditData"] = null;
                Response.Redirect("MyTimeSheet.aspx?Week=" + ViewState["weekID"] + "", false);
            }
            else if (Session["EmpEditDataByAdmin"] != null)
            {
                Session["EmpEditDataByAdmin"] = null;
                Response.Redirect("ViewEmployeeTimeSheet.aspx", false);
            }
        }
        catch (Exception err)
        {

        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (Session["EmpEditData"] != null)
        {
            Session["EmpEditData"] = null;
            Response.Redirect("MyTimeSheet.aspx?Week=" + ViewState["weekID"] + "", false);
        }
        else if (Session["EmpEditDataByAdmin"] != null)
        {
            Session["EmpEditDataByAdmin"] = null;
            Response.Redirect("ViewEmployeeTimeSheet.aspx", false);
        }
        //ScriptManager.RegisterStartupScript(this, GetType(), "goBack", "history.go(-1);", true);
    }
}