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
using querystring;
using Utilities;
using System.IO;


public partial class Leave_admin_AttendanceReport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    bool c = false;
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
           
            txt_frmdate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("dd-MMM-yyyy");
            txt_todate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            txt_employee.Attributes.Add("ReadOnly", "ReadOnly");
            txt_frmdate.Attributes.Add("readonly", "readonly");
            txt_todate.Attributes.Add("readonly", "readonly");
            txt_employee.Text = Session["empcode"].ToString();
            dd_designation.DataBind();
            dd_categoy.DataBind();
            bind_attendance();
            dvViewMovement.Visible = true;
            dvempcode.Visible = true;
        }
    }
    protected void bind_attendance()
    {
        try
        {
            rbtn.SelectedValue = "0";  

            //if (Convert.ToInt32(Session["Department"]) == 17)
            //{
            DateTime FromDate = Utility.DateTimeForat(txt_frmdate.Text);
            DateTime ToDate = Utility.DateTimeForat(txt_todate.Text);

                dvsearch.Visible = false;
                string sqlstr = @"select Distinct mode,card_no,dbo.GetEmpName(jD.empcode) as empname ,tbl_payroll_employee_attendence_detail.empcode,date,INTIME as Intime,OUTTIME as Outtime from tbl_payroll_employee_attendence_detail INNER JOIN tbl_intranet_employee_jobDetails jD ON tbl_payroll_employee_attendence_detail.empcode=jD.empcode where tbl_payroll_employee_attendence_detail.empcode in (" + txt_employee.Text + ")and date between ('" + FromDate + "') and ('" + ToDate + "') order by date";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    update.Visible = true;
                    empgrid.DataSource = ds;
                    empgrid.DataBind();
                    Session["dt1"] = ds;
                    dvViewMovement.Visible = false;
                    dvsearch.Visible = true;
                   
                }
                else
                {
                    update.Visible = false;
                    message.InnerHtml = "No data found";
                    
                }
            //}
            //else 
            //{
            //    dvempcode.Disabled = true;
            //    dvempcode.Visible = false;
            //    string sqlstr = @"select Distinct mode,card_no,(emp_fname+' '+emp_m_name+' '+emp_l_name) as empname,tbl_payroll_employee_attendence_detail.empcode,convert(varchar(10),date,101)date,Right(CONVERT(VARCHAR(26), INTIME, 22),12) Intime,Right(CONVERT(VARCHAR(26), OUTTIME, 22),12) Outtime from tbl_payroll_employee_attendence_detail INNER JOIN tbl_intranet_employee_jobDetails jD ON tbl_payroll_employee_attendence_detail.empcode=jD.empcode where tbl_payroll_employee_attendence_detail.empcode in ('" + Session["EmpCode"] + "')and date between ('" + txt_frmdate.Text + "') and ('" + txt_todate.Text + "') order by date";
            //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        update.Visible = true;
            //        empgrid.DataSource = ds;
            //        empgrid.DataBind();
            //        Session["dt1"] = ds;
            //        dvViewMovement.Visible = false;

            //    }
            //    else
            //    {
            //        update.Visible = false;
            //        message.InnerHtml = "No data found";
            //        dvempcode.Disabled = true;
            //        dvempcode.Visible = false;
            //        // Button1.Visible = false;
            //        //an.Visible = false;
            //    }
            //}
        }
        catch (Exception ex)
        {
            message.InnerHtml = "";
        }
    }

    protected void bindAttendanceViewMovement()
    {
        try
        {
            dvViewMovement.Visible = true;
            DateTime FromDate = Utilities.Utility.DateTimeForat(txt_frmdate.Text);
            DateTime ToDate = Utilities.Utility.DateTimeForat(txt_todate.Text);
            string sqlstr = @"select Distinct dbo.GetEmpName(jD.empcode) as empname ,DATEPART(Year,avm.date) as year,
avm.empcode,date, avm.intime1 as inTime,
 avm.outtime1 as outtime ,avm.intime2,avm.outtime2,avm.intime3,avm.outtime3,avm.intime4,avm.outtime4,avm.TotWhours
from tbl_EmployeeAttendanceViewMovement avm 
INNER JOIN tbl_intranet_employee_jobDetails jD 
ON avm.empcode=jD.empcode 
where avm.empcode in ('" + Session["EmpCode"] + "') and date between ('" + FromDate + "') and ('" + ToDate + "') order by date";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                
               dvViewMovement.Visible = true;
                GridViewMovement.DataSource = ds;
                GridViewMovement.DataBind();
                update.Visible = false;
                update.Disabled = true;
                Session["dt2"] = ds;

            }
            else
            {
                dvViewMovement.Visible = false;
                message.InnerHtml = "No data found";

            }
 
        }
        catch (Exception ex)
        {
            message.InnerHtml = "";
        }
 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (validate_applieddate())
            bind_attendance();
        else
            return;
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            if (validate_applieddate())
                bind_attendance();
            else
                return;
        }
        else
            if (validate_applieddate())
                bindAttendanceViewMovement();
            else
                return;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_attendance();
    }

    protected void GridViewMovement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewMovement.PageIndex = e.NewPageIndex;
        bindAttendanceViewMovement();
    }

    //protected void updateattendance()
    //{
    //    foreach (GridViewRow GridView in empgrid.Rows)
    //    {
    //        CheckBox chkbox = (CheckBox)GridView.FindControl("Chkbox");
    //        if (chkbox.Checked)
    //        {
    //            c = true;
    //            string mode = ((DropDownList)empgrid.Rows[GridView.RowIndex].Cells[4].Controls[1]).SelectedItem.Text;
    //            string code = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[2].Controls[1]).Text);
    //            //empgrid.DataKeys[GridView.RowIndex].Value.ToString();
    //            string empcode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[1].Controls[1]).Text);
    //            DateTime date = Convert.ToDateTime(((Label)empgrid.Rows[GridView.RowIndex].Cells[0].Controls[1]).Text);
    //            //string empcode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[1].Controls[1]).Text);
    //            string oldmode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[3].Controls[1]).Text);
    //            string intime = Convert.ToString(((TextBox)empgrid.Rows[GridView.RowIndex].Cells[5].Controls[1]).Text);
    //            string outtime = Convert.ToString(((TextBox)empgrid.Rows[GridView.RowIndex].Cells[5].Controls[3]).Text);

    //            if (mode != oldmode)
    //            {
    //                if (date.Month == DateTime.Now.Month)
    //                {
    //                    string str1 = @"delete from tbl_leave_attendance where empcode ='" + code + "' and date='" + date + "'";
    //                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
    //                    if (mode == "P")
    //                    {
    //                        // bind_shift_time(empcode, date);

    //                        HiddenField1.Value = intime;
    //                        HiddenField2.Value = outtime;


    //                        //To pass date with time 9:30 AM in time field in table tbl_leave_attendance
    //                        //DateTime ttime = date.Date.AddHours(9.5);
    //                        DateTime ttime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField1.Value);
    //                        DateTime etime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField2.Value);

    //                        //ttime = new DateTime();
    //                        //string str5 = @"select empcode from tbl_leave_attendance where empcode =" + code + " and date='" + date + "'";
    //                        //DataSet ds1 = new DataSet();
    //                        //ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str5);
    //                        //if (ds1.Tables[0].Rows.Count <= 0)
    //                        //{
    //                        string str3 = @"insert into tbl_leave_attendance(empcode,date,time,outtime,createdby) values('" + code + "','" + date + "','" + ttime + "','" + etime + "','" + Session["name"].ToString() + "') ";
    //                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str3);
    //                        //}
    //                    }

    //                    if ((mode == "H") || (mode == "W"))
    //                    {
    //                        update_dutyroaster(empcode, date, mode);
    //                    }
    //                }
    //                else
    //                {
    //                    HiddenField1.Value = intime;
    //                    HiddenField2.Value = outtime;

    //                    DateTime ttime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField1.Value);
    //                    DateTime etime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField2.Value);

    //                    string str1 = @"update tbl_payroll_employee_attendence_detail set mode='" + mode + "',intime='" + ttime + "',outtime='" + etime + "' where empcode='" + empcode + "' and date='" + date + "'";
    //                    //string str1 = @"delete from tbl_leave_attendance where empcode ='" + code + "' and date='" + date + "'";
    //                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
    //                }
    //            }
    //        }
    //    }
    //    if (c == false)
    //    {
    //        string message1 = "Please check atleast one employee before overwriting attendance";
    //        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //    }
    //    message.InnerHtml = "Attendance updated successfully";

    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_process_employee_attendance_ondailybasis]");
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_JOB_PAYROLL_ATTENDANCEHFDAY1]");

    //    bind_attendance();
    //}

    //protected void Button1_Click2(object sender, EventArgs e)
    //{
    //    updateattendance();
    //}

    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    updateattendance();
    //}

    //---------------------option to select a few and all staff in one go-----------------------

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        bindgrid();
        p3.Visible = true;
    }

    protected void adjustgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
        }
    }

   
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        string empcode = "";
        //DataRow dr;
        //(TextBox)ShopCartGrid.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
        CheckBox Tmark1;
        for (int j = 0; j <= adjustgrid.Rows.Count - 1; j++)
        {
            Tmark1 = (CheckBox)adjustgrid.Rows[j].Cells[0].FindControl("chkselect");
            if (Tmark1.Checked == true)
            {
                empcode = empcode + "'" + ((Label)adjustgrid.Rows[j].Cells[0].FindControl("l2")).Text.Trim() + "',";
            }
        }
        p3.Visible = false;
        if (empcode != "")
            txt_employee.Text = empcode.Substring(0, empcode.Length - 1);
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txtempcode.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        sqlparam[3].Value = dd_categoy.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        sqlparam[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_fetch_emp_detail]", sqlparam);

        adjustgrid.DataSource = ds;
        adjustgrid.DataBind();
    }

    //protected void img_close_Click(object sender, ImageClickEventArgs e)
    //{
    //    p3.Visible = false;
    //}

    protected void btn_close_Click(object sender, EventArgs e)
    {
        p3.Visible = false;
    }

    //------------------------------- Validation for Date ------------------------------//
    protected Boolean validate_applieddate()
    {
        DateTime dt1 = Convert.ToDateTime(txt_frmdate.Text);
        DateTime dt2 = Convert.ToDateTime(txt_todate.Text);

        TimeSpan diff = Convert.ToDateTime(txt_todate.Text) - Convert.ToDateTime(txt_frmdate.Text);

        if (diff.Days < 0)
        {
            string message1 = "End date should be greater than start date.";
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    protected void bind_shift_time(string empcode, DateTime date)
    {
        
        HiddenField1.Value = "8:30 AM";
        HiddenField2.Value = "5:30 PM";
        
    }

    protected void btn_search_click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_categoy_DataBound(object sender, EventArgs e)
    {
        dd_categoy.Items.Insert(0, new ListItem("All", "0"));
    }

    //protected void ddlbranch_DataBound(object sender, EventArgs e)
    //{
    //    ddlbranch.Items.Insert(0, new ListItem("All", "0"));
    //}

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        p3.Visible = false;
    }

    protected void update_dutyroaster(string empcode, DateTime date, string mode)
    {
        int shiftcode;
        SqlParameter[] sqlparam = new SqlParameter[4];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@date", SqlDbType.DateTime);
        sqlparam[1].Value = date;

        sqlparam[2] = new SqlParameter("@mode", SqlDbType.VarChar, 10);

        if (mode == "W")
        {
            shiftcode = 0;
        }
        else
        {
            shiftcode = 1;
        }
        sqlparam[2].Value = shiftcode;

        sqlparam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[3].Value = Session["empcode"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_update_employee_dutyroaster_overwrite]", sqlparam);
    }

    protected void empgrid_rowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldate =(Label) e.Row.FindControl("lbldateg");
            string str = lbldate.Text;
            Label lblempcode = (Label)e.Row.FindControl("lblempcode");
            string str1 = lblempcode.Text;
            //lbldate.Attributes.Add("onClick",
        }
    }
    
    protected void exportexcel()
    {

       
       
            ds = (DataSet)Session["dt1"];
        

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =Attendance.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =DutyRoster.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        //dg.DataSource = ds.Tables[0];
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
    protected void btn_exporttoexcel_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
    protected void rbtn_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            btn_exporttoexcel.Visible = true;
            bind_attendance();

        }
        else
        {
            btn_exporttoexcel.Visible = false;
            bindAttendanceViewMovement();
        }
    }
}