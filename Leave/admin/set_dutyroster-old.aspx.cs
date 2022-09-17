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

public partial class admin_set_tmt_dutyroster : System.Web.UI.Page
{
    String sqlstr, sqlstrinsert, setsqlstr, sqlstrcountsuperviser, sqlstrcheckduplicateentry, sqldeletedutyroster, sqlstrcheckduplicateentry1, sqlstrHolidays;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet dschk = new DataSet();
    DataSet dschk1 = new DataSet();
    DataSet dssqlstrHolidays = new DataSet();
    DataSet dsShiftHolidaysValue = new DataSet();

    string cONNsTRING_New, cONNsTRING_Old, cONNsTRING1, cONNsTRING2, cONNsTRING3, cONNsTRING4;
    int flagA = 0, flagB = 0, flagC = 0, flagDeleteUser = 0;
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

        HiddenField1.Value = txt_start_date.Text = d.ToString("MM/dd/yyyy");

        HiddenField2.Value = txt_end_date.Text = d.AddDays(6).ToString("MM/dd/yyyy");

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

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text;

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        if (dd_designation.SelectedValue == "")
            sqlparam[1].Value = 0;
        else
            sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        if (dd_dpt.SelectedValue == "")
            sqlparam[2].Value = 0;
        else
            sqlparam[2].Value = dd_dpt.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    //-------------------------------------- Bind Employees under Manager -----------------------------------
    public void bindemployee_mgr()
    {
        sqlstr = @"select distinct h.employeecode as empcode,coalesce(m.emp_fname,'') + ' ' + coalesce(m.emp_m_name,'') + ' ' + coalesce(m.emp_l_name,'') as name,
                    m.degination_id,tbl_intranet_designation.designationname,
                    m.dept_id,tbl_internate_departmentdetails.department_name,
                    m.branch_id,tbl_intranet_branch_detail.branch_name   
                    from tbl_leave_employee_hierarchy h
                    INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
                    INNER JOIN tbl_intranet_designation ON m.degination_id=tbl_intranet_designation.id
                    INNER JOIN tbl_internate_departmentdetails ON m.dept_id=tbl_internate_departmentdetails.departmentid
                    INNER JOIN tbl_intranet_branch_detail ON m.branch_id=tbl_intranet_branch_detail.Branch_id
                    where h.approverid='" + Session["empcode"].ToString() + "' ";
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
        if (!chk_date())
            message.InnerHtml = "To date must not be less than From date";
        else
        {
            int shiftvalue = 0;
            int counter;
            counter = 0;
            string str1 = "";
            string str2 = "";
            bool c = false;

            foreach (GridViewRow GridView in Grid_Emp.Rows)
            {
                CheckBox chkBox = (CheckBox)GridView.FindControl("Chkbox");

                if (chkBox.Checked)
                {
                    c = true;

                    string empCode, empName, Designation, Branch;
                    empCode = Grid_Emp.Rows[counter].Cells[1].Text.ToString();
                    empName = Grid_Emp.Rows[counter].Cells[2].Text.ToString();
                    Designation = Grid_Emp.Rows[counter].Cells[4].Text.ToString();
                    Branch = Grid_Emp.Rows[counter].Cells[3].Text.ToString();

                    DateTime startdate, enddate, tmpDate;
                    DayOfWeek tmpdays;

                    startdate = Convert.ToDateTime(txt_start_date.Text);
                    enddate = Convert.ToDateTime(txt_end_date.Text);
                    TimeSpan ts = enddate.Subtract(startdate);

                    for (int i = 0; ts.TotalDays >= i; i++)
                    {
                        tmpDate = Convert.ToDateTime(startdate.AddDays(i).ToString("MM/dd/yyyy"));

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

                        sqlstrHolidays = @"select A.date from tbl_leave_holiday as A inner join tbl_intranet_branch_detail as B  on  A.branch_id in( B.branch_id,0) where B.branch_name = '" + Branch + "' and date='" + tmpDate + "' ";

                        dssqlstrHolidays = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrHolidays);

                        if (dssqlstrHolidays.Tables[0].Rows.Count > 0)
                            shiftvalue = 1;

                        sqlstrcheckduplicateentry = @"select empcode, date from tbl_leave_dutyroster where empcode='" + empCode.Trim() + "' and date='" + tmpDate + "'";

                        dschk = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrcheckduplicateentry);

                        if (dschk.Tables[0].Rows.Count > 0)
                        {
                            str1 = str1 + " : " + empCode.Trim() + ": For Date " + Convert.ToDateTime(tmpDate).ToShortDateString();

                            cONNsTRING_Old = dschk.Tables[0].Rows[0][0].ToString();
                            flagB = 2;
                        }

                        else
                        {
                            str2 = str2 + " : " + empCode.Trim() + ": For Date " + tmpDate.ToString("dd/MM/yyyy");

                            sqlstrinsert = "insert into tbl_leave_dutyroster(empcode,empshiftcode,date,weekdays,createdby)" + "values('" + empCode.Trim() + "', '" + shiftvalue + "','" + tmpDate + "','" + tmpdays + "','" + Session["empcode"].ToString().Trim() + "')";

                            int chek = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstrinsert);

                            sqlstrcheckduplicateentry1 = @"select empcode, date from tbl_leave_dutyroster where empcode='" + empCode.Trim() + "' and date='" + tmpDate + "'";

                            dschk1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrcheckduplicateentry1);

                            cONNsTRING_New = dschk1.Tables[0].Rows[0][0].ToString();

                            flagA = 1;
                        }
                    }

                    if (flagDeleteUser == 1)
                    {
                        sqldeletedutyroster = @" delete from tbl_leave_dutyroster where empcode = '" + ViewState["StoreValueforDeleteUser"].ToString() + "' ";

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqldeletedutyroster);

                        flagDeleteUser = 0;
                    }
                }

                counter = counter + 1;

                flagC = flagA + flagB;

                if (flagC == 3)
                {
                    cONNsTRING2 = cONNsTRING2 + " " + cONNsTRING1;
                    cONNsTRING1 = "";
                    cONNsTRING3 = cONNsTRING3 + " " + cONNsTRING4;
                    cONNsTRING4 = "";
                }
                else
                {
                    if (flagA == 1)
                    {
                        cONNsTRING1 = cONNsTRING1 + " " + cONNsTRING_New;
                        cONNsTRING_New = "";
                    }
                    else if (flagB == 2)
                    {
                        cONNsTRING4 = cONNsTRING4 + " " + cONNsTRING_Old;
                        cONNsTRING_Old = "";
                    }
                }
            }

            //string totalString = "";

            if (str2 != "")
            {
                message.InnerHtml = "Work Roster is successfully created";
                //totalString = totalString + "Work Roster is created for following user:" + str2.ToString();
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + totalString.ToString() + "')</script>", false);
            }
            if (str1 != "")
            {
                message.InnerHtml = "Work Roster is already created for this date span";
                //totalString = totalString + "Work Roster is already created for following user:" + str1.ToString();
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + totalString.ToString() + "')</script>", false);
            }

            //totalString = "Work roster is already created for this date span";
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + totalString.ToString() + "')</script>", false);

            foreach (GridViewRow GridView in Grid_Emp.Rows)
            {
                CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

                if (Chkbox.Checked)
                    Chkbox.Checked = false;
            }

            FirstDayOfWeek();

            if (c == false)
            {
                message.InnerHtml = "Please select atleast one employee";
                //string message1 = "Please select atleast one employee";
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1 + "')</script>", false);
            }
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
            drpSatShift.SelectedIndex = drpMonShift.SelectedIndex;
            drpSunShift.SelectedValue = "0";
    }
}
