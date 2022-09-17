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

public partial class leave_admin_over_write_attendance_update : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    bool c = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "3" || Session["role"].ToString() != "1")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            //bind_attendance();
            an.Visible = false;
            txt_frmdate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("MM/dd/yyyy");
            txt_todate.Text = System.DateTime.Today.Date.ToString("MM/dd/yyyy");
            dd_designation.DataBind();
            dd_branch.DataBind();
            ddlbranch.DataBind();
        }
    }

    protected void bind_attendance()
    {
        try
        {
            //SqlParameter[] sqlparam = new SqlParameter[3];
            //sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //sqlparam[0].Value = txt_employee.Text;

            //sqlparam[1] = new SqlParameter("@frmdate", SqlDbType.DateTime);
            //sqlparam[1].Value = txt_frmdate.Text;

            //sqlparam[2] = new SqlParameter("@todate", SqlDbType.DateTime);
            //sqlparam[2].Value = txt_todate.Text;

            //sqlstr = "select mode,empcode,convert(varchar(10),date,101)date from tbl_payroll_employee_attendence_detail where empcode=@empcode and  date between @frmdate and @todate";
            //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

            string sqlstr = @"select Distinct mode,card_no,tbl_payroll_employee_attendence_detail.empcode,convert(varchar(10),date,101)date,Right(CONVERT(VARCHAR(26), INTIME, 22),12) Intime,Right(CONVERT(VARCHAR(26), OUTTIME, 22),12) Outtime from tbl_payroll_employee_attendence_detail INNER JOIN tbl_intranet_employee_jobDetails jD ON tbl_payroll_employee_attendence_detail.empcode=jD.empcode where tbl_payroll_employee_attendence_detail.empcode in (" + txt_employee.Text + ")and date between ('" + txt_frmdate.Text + "') and ('" + txt_todate.Text + "') order by date";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                update.Visible = true;
                empgrid.DataSource = ds;
                empgrid.DataBind();
                an.Visible = true;
                Button1.Visible = true;

                //txt_mode.Text = ds.Tables[0].Rows[0]["mode"].ToString();
            }
            else
            {
                update.Visible = false;
                message.InnerHtml = "No data found";
                Button1.Visible = false;
                an.Visible = false;
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

    protected void Button1_Click1(object sender, EventArgs e)
    {
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_attendance();
    }

    protected void updateattendance()
    {
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox chkbox = (CheckBox)GridView.FindControl("Chkbox");
            if (chkbox.Checked)
            {
                c = true;
                string mode = ((DropDownList)empgrid.Rows[GridView.RowIndex].Cells[4].Controls[1]).SelectedItem.Text;
                string code = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[2].Controls[1]).Text);
                //empgrid.DataKeys[GridView.RowIndex].Value.ToString();
                string empcode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[1].Controls[1]).Text);
                DateTime date = Convert.ToDateTime(((Label)empgrid.Rows[GridView.RowIndex].Cells[0].Controls[1]).Text);
                //string empcode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[1].Controls[1]).Text);
                string oldmode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[3].Controls[1]).Text);
                string intime = Convert.ToString(((TextBox)empgrid.Rows[GridView.RowIndex].Cells[5].Controls[1]).Text);
                string outtime = Convert.ToString(((TextBox)empgrid.Rows[GridView.RowIndex].Cells[5].Controls[3]).Text);

                if (mode != oldmode)
                {
                    if (date.Month == DateTime.Now.Month)
                    {
                        string str1 = @"delete from tbl_leave_attendance where empcode ='" + code + "' and date='" + date + "'";
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
                        if (mode == "P")
                        {
                           // bind_shift_time(empcode, date);

                            HiddenField1.Value = intime;
                            HiddenField2.Value = outtime;


                            //To pass date with time 9:30 AM in time field in table tbl_leave_attendance
                            //DateTime ttime = date.Date.AddHours(9.5);
                            DateTime ttime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField1.Value);
                            DateTime etime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField2.Value);

                            //ttime = new DateTime();
                            //string str5 = @"select empcode from tbl_leave_attendance where empcode =" + code + " and date='" + date + "'";
                            //DataSet ds1 = new DataSet();
                            //ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str5);
                            //if (ds1.Tables[0].Rows.Count <= 0)
                            //{
                            string str3 = @"insert into tbl_leave_attendance(empcode,date,time,outtime,createdby) values('" + code + "','" + date + "','" + ttime + "','" + etime + "','" + Session["name"].ToString() + "') ";
                            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str3);
                            //}
                        }

                        if ((mode == "H") || (mode == "W"))
                        {
                            update_dutyroaster(empcode, date, mode);
                        }
                    }
                    else
                    {
                        HiddenField1.Value = intime;
                        HiddenField2.Value = outtime;

                        DateTime ttime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField1.Value);
                        DateTime etime = Convert.ToDateTime(date.ToShortDateString() + " " + HiddenField2.Value);

                        string str1 = @"update tbl_payroll_employee_attendence_detail set mode='" + mode + "',intime='" + ttime + "',outtime='" + etime + "' where empcode='" + empcode + "' and date='" + date + "'";
                        //string str1 = @"delete from tbl_leave_attendance where empcode ='" + code + "' and date='" + date + "'";
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
                    }
                }
            }
        }
        if (c == false)
        {
            string message1 = "Please check atleast one employee before overwriting attendance";
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
        }
        message.InnerHtml = "Attendance updated successfully";

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_process_employee_attendance_ondailybasis]");
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_JOB_PAYROLL_ATTENDANCEHFDAY1]");

        bind_attendance();
    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        updateattendance();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        updateattendance();
    }

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

    protected void adjustgrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkselect");
            CheckBox chkBxHeader = (CheckBox)this.adjustgrid.HeaderRow.FindControl("chkBxHeader");
            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
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
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        sqlparam[5].Value = ddlbranch.SelectedValue;

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
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    protected void bind_shift_time(string empcode, DateTime date)
    {
        //SqlParameter[] sqlparam = new SqlParameter[2];
        //sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        //sqlparam[0].Value = empcode;

        //sqlparam[1] = new SqlParameter("@date", SqlDbType.DateTime);
        //sqlparam[1].Value = date;

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_bind_employee_shift_detail_overwrite]", sqlparam);
        ////if (ds.Tables[0].Rows.Count <= 0)
        ////{
        ////    string message1 = "Your work roster is not created! Please contact with TMT";
        ////    Button1.Enabled = false;
        ////    //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
        ////    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
        ////    return false;
        ////}
        ////else
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    HiddenField1.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["starttime"]).ToShortTimeString();
        //    HiddenField2.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["endtime"]).ToShortTimeString();
        //    //return true;
        //}
        //else
        //{
            HiddenField1.Value = "8:30 AM";
            HiddenField2.Value = "5:30 PM";
        //}
    }

    protected void btn_search_click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("All", "0"));
    }

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
}
