using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessLogic.TimeSheet;
using HRMS.BusinessEntity.TimeSheet;

public partial class TimeSheet_User_ViewEmployeeTimeSheet : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataView dtView = new DataView();
    DataRow dr;
    int _datestart = 0;
    int _dateend = 0;
    DateTime _startDateOfWeek;
    decimal montime = 0, tuetime = 0, wedtime = 0, thurtime = 0, fritime = 0, sattime = 0, suntime = 0, Total = 0, Total_total = 0;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 3)
        {
            if (!IsPostBack)
            {
                if (Session["EmpCode"] == null)
                {
                    string str = Server.UrlEncode(Convert.ToString(Request.Url));
                    Response.Redirect("~/Login.aspx?url=" + str);
                }
               
                    if (Request.QueryString["ID"] != null && Request.QueryString["code"] != null && Request.QueryString["week"] != null)
                    {
                        QueryStringEncryption.Cryptography crypt = new QueryStringEncryption.Cryptography();
                        ViewState["TimeSheetID"] = Convert.ToInt32(crypt.Decrypt(Request.QueryString["ID"]));
                        ViewState["EmpApprCode"] = crypt.Decrypt(Request.QueryString["code"].ToString());
                        ViewState["TimeSheetWeek"] = Convert.ToInt32(crypt.Decrypt(Request.QueryString["week"]));
                    }
                bindGrid();
                bindHeader();
            }
        }
        
    }
    private void bindHeader()
    {
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        MyTimeSheetENT domObj=new MyTimeSheetENT();
        domObj.empCode=ViewState["EmpApprCode"].ToString();
        domObj.weekID=Convert.ToInt32(ViewState["TimeSheetWeek"]);

        DataTable dt_result = balObj.getHeaderDetailsForEmployee(domObj);
        if(dt_result.Rows.Count>0)
        {
            DateTime _startDate = Convert.ToDateTime(dt_result.Rows[0]["StartDate"]);
            DateTime _endDate = Convert.ToDateTime(dt_result.Rows[0]["EndDate"]);
           // string _week = _startDate.ToString("d") + "-" + _endDate.ToString("d");
            lbl_employee.Text = dt_result.Rows[0]["EmpName"].ToString();
            lbl_toweek.Text = _endDate.ToString("dd/MM/yyyy");
            lbl_fromweek.Text = _startDate.ToString("dd/MM/yyyy");
        }
    }

    private void bindGrid()
    {
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        MyTimeSheetENT domObj = new MyTimeSheetENT();
        domObj.empCode = ViewState["EmpApprCode"].ToString();
        domObj.weekID = Convert.ToInt32(Convert.ToInt32(ViewState["TimeSheetWeek"]));
        DataSet ds_result = balObj.getWeekTimeSheet(domObj);

        if (ds_result.Tables[0].Rows.Count > 0)
        {
            int status = Convert.ToInt32(ds_result.Tables[0].Rows[0]["SubmitStatus"].ToString());
            
        }

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
            //                         Total = Convert.ToDecimal(dr["MonTime"]) + Convert.ToDecimal(dr["TuesTime"]) + Convert.ToDecimal(dr["WedTime"]) + Convert.ToDecimal(dr["ThurTime"]) +
            //Convert.ToDecimal(dr["FriTime"]) + Convert.ToDecimal(dr["SatTime"]) + Convert.ToDecimal(dr["SunTime"]);
            Total_total += Total;
            dr["Total"] = Total;
        }
        //string _datefull = ddl_week.SelectedItem.Text.Trim();
        //string[] _splitFull = _datefull.Split('-');
        //DateTime _startdate = DateTime.ParseExact(_splitFull[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //DateTime _enddate = DateTime.ParseExact(_splitFull[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //_startDateOfWeek = _startdate;
        //_datestart = _startdate.Day;
        //_dateend = _enddate.Day;

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
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Session["EmpEditDataByAdmin"] = ViewState["EmpApprCode"].ToString() + "&" + lbl_fromweek.Text.Trim()+':'+lbl_toweek.Text.Trim() + "&" + Convert.ToInt32(ViewState["TimeSheetWeek"].ToString());
        Response.Redirect("EditTimesheet.aspx", false);
    }
    protected void btn_approve_Click(object sender, EventArgs e)
    {
        MyTimeSheetENT domObj = new MyTimeSheetENT();
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        domObj.empCode = Session["EmpCode"].ToString();
        domObj.weekID = Convert.ToInt32(ViewState["TimeSheetWeek"]);
        domObj.timeSheetID = Convert.ToInt32(ViewState["TimeSheetID"]);
        domObj.IsApproved = true;
        domObj.UserComment = txt_comment.Text.Trim();
        //string result = balObj.updateApproveStatus(domObj, ViewState["EmpApprCode"].ToString());
        //if (result.Equals("Inserted"))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "inserted", "alert('User timesheet approved');", true);
        //    Response.Redirect("MyEmployeeTimeSheet.aspx", false);
        //}
        //else if (result.Equals("Error"))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "inserted", "alert('Some error occur,try again');", true);
        //}
    }
    protected void btn_reject_Click(object sender, EventArgs e)
    {
        MyTimeSheetENT domObj = new MyTimeSheetENT();
        MyTimeSheetBussiness balObj = new MyTimeSheetBussiness();
        domObj.empCode = Session["EmpCode"].ToString();
        domObj.weekID = Convert.ToInt32(ViewState["TimeSheetWeek"]);
        domObj.timeSheetID = Convert.ToInt32(ViewState["TimeSheetID"]);
        domObj.IsApproved = false;
        domObj.UserComment = txt_comment.Text.Trim();
        //string result = balObj.updateApproveStatus(domObj, ViewState["EmpApprCode"].ToString());
        //if (result.Equals("Inserted"))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "inserted", "alert('User tiesheet approved');", true);
        //    Response.Redirect("MyEmployeeTimeSheet.aspx", false);
        //}
        //else if (result.Equals("Error"))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "inserted", "alert('Some error occur,try again');", true);
        //}
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
            TableCell column_mon = e.Row.Cells[2];
            if (column_mon != null)
                column_mon.Text = montime.ToString();
            TableCell column_tue = e.Row.Cells[3];
            if (column_tue != null)
                column_tue.Text = tuetime.ToString();
            TableCell column_wed = e.Row.Cells[4];
            if (column_wed != null)
                column_wed.Text = wedtime.ToString();
            TableCell column_thur = e.Row.Cells[5];
            if (column_thur != null)
                column_thur.Text = thurtime.ToString();
            TableCell column_fri = e.Row.Cells[6];
            if (column_fri != null)
                column_fri.Text = fritime.ToString();
            TableCell column_sat = e.Row.Cells[7];
            if (column_sat != null)
                column_sat.Text = sattime.ToString();
            TableCell column_sun = e.Row.Cells[8];
            if (column_sun != null)
                column_sun.Text = suntime.ToString();
            TableCell column_total = e.Row.Cells[9];
            if (column_total != null)
                column_total.Text = Total_total.ToString();
        }
    }
}