using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Globalization;
public partial class admin_set_tmt_dutyroster : System.Web.UI.Page
{
    String sqlstr, sqlstrinsert, sqldeletedutyroster, sqlstrHolidays;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet dschk = new DataSet();
    DataSet dschk1 = new DataSet();
    DataSet dssqlstrHolidays = new DataSet();
    DataSet dsShiftHolidaysValue = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["manager"].ToString() == "0")
                //{
                    //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    //    Response.Redirect("~/Authenticate.aspx");
                //}
            }
            else
                Response.Redirect("~/notlogged.aspx");
            
            lnkrefresh.Visible = true;            
            bindshift();
            FirstDayOfWeek();
            drpSunShift.SelectedValue = "0";
            drpSatShift.SelectedValue = "0";
            validate_emp();
        }
    }

    //=======================FINDING FIRST DAY OF WEEK===========================================================
    protected void FirstDayOfWeek()
    {
        DateTime d;

        d = DateTime.Today.AddDays(0);

        DayOfWeek monday = DayOfWeek.Monday;

        while (d.DayOfWeek != monday)
            d = d.AddDays(-1);

        HiddenField1.Value = txt_start_date.Text = d.ToString("dd-MMM-yyyy");

        HiddenField2.Value = txt_end_date.Text = d.AddDays(6).ToString("dd-MMM-yyyy");

    }

    //-------------------------------------- Bind Shifts -----------------------------------
    public void bindshift()
    {
        sqlstr = "";

        sqlstr = @"SELECT tbl_leave_shift.shiftid, tbl_leave_shift.shiftname FROM tbl_leave_shift order by shiftname";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drpMonShift.Items.Clear();
            drpTueShift.Items.Clear();
            drpWedShift.Items.Clear();
            drpThruShift.Items.Clear();
            drpFriShift.Items.Clear();
            drpSatShift.Items.Clear();
            drpSunShift.Items.Clear();

            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                drpMonShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpTueShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpWedShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpThruShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpFriShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpSatShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpSunShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
            }
        }
    }

    //-------------------------------------- Bind Employees under Admin-----------------------------------

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value =Session["empcode"].ToString();


        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        if (dd_designation.SelectedValue == "")
            sqlparam[2].Value = 0;
        else
            sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        if (dd_dpt.SelectedValue == "")
            sqlparam[3].Value = 0; 
        else
            sqlparam[3].Value = dd_dpt.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "Current";

        //sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        //sqlparam[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    //-------------------------------------- Bind Employees under Manager -----------------------------------
    public void bindemployee_mgr()
    {
        sqlstr = @"select distinct h.employeecode as empcode,
                   coalesce(m.emp_fname,'') + ' ' + coalesce(m.emp_l_name,'') as name,
                    m.degination_id,
                    tbl_DesignationMaster.designationname,
                    m.category,tbl_category_master.CategoryName
                    from tbl_Employee_Hierarchy h
                    INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
                    INNER JOIN tbl_DesignationMaster ON m.degination_id=tbl_DesignationMaster.id
                    INNER JOIN tbl_category_master ON m.category=tbl_category_master.ID
                    where h.approverid='" + Session["empcode"].ToString() + "' and m.emp_status != '3'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    //------------------------------------- Check Admin/Manager ---------------------------------------------
    protected void validate_emp()
    {
        if ((Session["role"].ToString() == "2") || (Session["role"].ToString() == "3"))
        {
            bindempdetail();
            divempsearch.Visible = true;
        }
        else
        {
            bindemployee_mgr();
            divempsearch.Visible = false;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        validate_emp();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("------ All ------", "0"));
    }
    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
        validate_emp();
    }  
    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            if (!Chkbox.Checked)
                Chkbox.Checked = true;
        }
    }
    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            if (Chkbox.Checked)
                Chkbox.Checked = false;
        }
    }

    protected Boolean chk_date()
    {
        DateTime sdate = Convert.ToDateTime(txt_start_date.Text);
        DateTime edate = Convert.ToDateTime(txt_end_date.Text);

        TimeSpan ts = edate - sdate;

        if (Convert.ToInt32(ts.TotalDays) < 0)       
            return false;

        return true;
    }
  
    protected void imgbtn4empid_Click(object sender, ImageClickEventArgs e)
    {
        validate_emp();
    }
    protected void submitbtn_Click(object sender, EventArgs e)
    {
        bool c = false;
        if (!chk_date())
            message.InnerHtml = "To date must not be less than From date";
        else
        {
            int shiftvalue = 0;
            int counter;
            counter = 0;
            foreach (GridViewRow GridView in Grid_Emp.Rows)
            {
                CheckBox chkBox = (CheckBox)GridView.FindControl("Chkbox");

                if (chkBox.Checked)
                {
                    c = true;

                    string empCode, empName, Designation;
                    empCode = Grid_Emp.Rows[counter].Cells[1].Text.ToString();
                    empName = Grid_Emp.Rows[counter].Cells[2].Text.ToString();
                    Designation = Grid_Emp.Rows[counter].Cells[4].Text.ToString();

                    DateTime startdate, enddate, tmpDate;
                    DayOfWeek tmpdays;

                    startdate = Convert.ToDateTime(txt_start_date.Text);
                    enddate = Convert.ToDateTime(txt_end_date.Text);
                    TimeSpan ts = enddate.Subtract(startdate);
                    tmpDate = new DateTime();
                    for (int i = 0; ts.TotalDays >= i; i++)
                    {
                        if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
                        {
                            tmpDate = Convert.ToDateTime(startdate.AddDays(i).ToString("MMM/dd/yyyy"));
                        }
                        else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
                        {
                            tmpDate = Convert.ToDateTime(startdate.AddDays(i).ToString("MMM-dd-yyyy"));
                        }
                        tmpdays = tmpDate.DayOfWeek;

                        if (tmpdays == DayOfWeek.Monday)
                            shiftvalue = Convert.ToInt32(drpMonShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Tuesday)
                            shiftvalue = Convert.ToInt32(drpTueShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Wednesday)
                            shiftvalue = Convert.ToInt32(drpWedShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Thursday)
                            shiftvalue = Convert.ToInt32(drpThruShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Friday)
                            shiftvalue = Convert.ToInt32(drpFriShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Saturday)
                            shiftvalue = Convert.ToInt32(drpSatShift.SelectedValue);
                        else if (tmpdays == DayOfWeek.Sunday)
                            shiftvalue = Convert.ToInt32(drpSunShift.SelectedValue);

                        sqlstrHolidays = @"select A.date from tbl_leave_holiday as A  where date='" + tmpDate + "' ";

                        dssqlstrHolidays = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrHolidays);

                        if (dssqlstrHolidays.Tables[0].Rows.Count > 0)
                            shiftvalue = 1;

                        sqldeletedutyroster = @" delete from tbl_leave_dutyroster where empcode='" + empCode.Trim() + "' and date='" + tmpDate + "'";

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqldeletedutyroster);

                        sqlstrinsert = "insert into tbl_leave_dutyroster(empcode,empshiftcode,date,weekdays,createdby)" + "values('" + empCode.Trim() + "', '" + shiftvalue + "','" + tmpDate + "','" + tmpdays + "','" + Session["empcode"].ToString().Trim() + "')";

                        int chek = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstrinsert);

                     }
                    }
                counter = counter + 1;
                }
            }

            message.InnerHtml = "Work Roster is successfully created from :" + txt_start_date.Text + " to " + txt_end_date.Text;
           
            //FirstDayOfWeek();

            if (c == false)
            {
                message.InnerHtml = "Please select atleast one employee";
            }
    }
    protected void lnkrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("set_dutyroster.aspx");
    }
    protected void Grid_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Emp.PageIndex = e.NewPageIndex;
        validate_emp();
    }
    protected void drpMonShift_SelectedIndexChanged(object sender, EventArgs e)
    {
            drpTueShift.SelectedIndex = drpMonShift.SelectedIndex;
            drpWedShift.SelectedIndex = drpMonShift.SelectedIndex;
            drpThruShift.SelectedIndex = drpMonShift.SelectedIndex;
            drpFriShift.SelectedIndex = drpMonShift.SelectedIndex;
            drpSatShift.SelectedValue = "0";
            drpSunShift.SelectedValue = "0";
    }
}
