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
using Utilities;
public partial class leave_admin_set_duty_roster_for_all_employee : System.Web.UI.Page
{
    String sqlstr, sqlstrdept, sqlstrfindempid, ids, sqlstrinsert, setsqlstr, sqlstrcountsuperviser, sqlstrbranch, sqlstrdepartment, sqlstrcheckduplicateentry, sqldeletedutyroster, sqlstrcheckduplicateentry1, sqlstrHolidays, sqlstrShiftHolidaysValue;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet dschk = new DataSet();
    DataSet dschk1 = new DataSet();
    DataSet dssqlstrHolidays = new DataSet();
    DataSet dsShiftHolidaysValue = new DataSet();


    string cONNsTRING_New, cONNsTRING_Old, cONNsTRING1, cONNsTRING2, cONNsTRING3, cONNsTRING4;
    int flagA = 0, flagB = 0, flagC = 0, flagDeleteUser=0;


    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            lnkrefresh.Visible = true;
            bind_branch();

            bind_department();

            string employeecode = Session["empcode"].ToString().Trim();

            if (Session["role"].ToString().Trim() == "2")
            {
                    chkempfilters.Checked = false;
                    bindemployee();
                    bindshift();
                    FirstDayOfWeek();
                    Label1.Visible = false;
                    Label2.Visible = false;            
            }
            else
            {
                sqlstrcountsuperviser = @"select count(*) from tbl_leave_employee_hierarchy where approverid='" + employeecode + "'";

                int c = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrcountsuperviser));

                if (c > 0)
                {
                    setsqlstr = @" select tbl_intranet_branch_detail.branch_id, tbl_internate_departmentdetails.departmentid
                        FROM tbl_intranet_employee_jobDetails INNER JOIN tbl_internate_departmentdetails ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id 
                        INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id = tbl_intranet_employee_jobDetails.branch_id
                        where tbl_intranet_employee_jobDetails.empcode='" + employeecode + "'";

                    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, setsqlstr);

                    DropDownList8.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
                    drpDept.SelectedValue = ds.Tables[0].Rows[0][1].ToString();
                    DropDownList8.Visible = false;
                    Label1.Text = DropDownList8.SelectedItem.ToString();
                    Label2.Text = drpDept.SelectedItem.ToString();
                    drpDept.Visible = false;
                    //checkuserforsuperviser = 1;
                    lnkrefresh.Visible = true;
                    bindemployee();
                    bindshift();
                    FirstDayOfWeek();

                    pic_more.Visible = true;
                    chkempfilters.Visible = false;
                }
                else
                {
                    chkempfilters.Checked = false;
                    bindemployee();
                    bindshift();
                    FirstDayOfWeek();
                    Label1.Visible = false;
                    Label2.Visible = false;
                }      
            }                   
        }
        
    }

    //=======================FINDING FIRST DAY OF WEEK===========================================================
    protected void FirstDayOfWeek()
    {
        DateTime d;

        d = DateTime.Today.AddDays(0);

        DayOfWeek monday = DayOfWeek.Monday;

        while (d.DayOfWeek != monday)
        {
            d = d.AddDays(-1);
        }

        HiddenField1.Value = txt_start_date.Text = d.ToString("MM/dd/yyyy");

        HiddenField2.Value = txt_end_date.Text = d.AddDays(6).ToString("MM/dd/yyyy");
        
    }

    public void bindemployee()
    {
        try
        {
            sqlstr = @"SELECT tbl_internate_departmentdetails.department_name, tbl_intranet_designation.designationname,
                     tbl_intranet_employee_jobDetails.empcode, coalesce(tbl_intranet_employee_jobDetails.emp_fname,' ') + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,' ') + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,' ') as emp_name,
                     tbl_intranet_branch_detail.branch_name FROM tbl_internate_departmentdetails INNER JOIN tbl_intranet_employee_jobDetails
                     ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id  INNER JOIN tbl_intranet_designation
                     ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id INNER JOIN tbl_intranet_branch_detail
                     ON tbl_intranet_branch_detail.branch_id = tbl_intranet_employee_jobDetails.branch_id";

            if (Session["role"].ToString().Trim() != "2")
            {
                sqlstr = sqlstr + " WHERE tbl_intranet_employee_jobDetails.empcode IN (select employeecode from tbl_leave_employee_hierarchy where approverid='" + Session["empcode"].ToString() + "')";
            }
            else
            {
                if (chkempfilters.Checked)
                {
                    
                    if (DropDownList8.SelectedIndex != 0)
                    {
                        sqlstr = sqlstr + " where tbl_intranet_branch_detail.branch_id = '" + DropDownList8.SelectedValue + "' and tbl_internate_departmentdetails.departmentid = '" + drpDept.SelectedValue + "'";
                    }
                    else
                    {
                        sqlstr = sqlstr + " where tbl_internate_departmentdetails.departmentid = '" + drpDept.SelectedValue + "'";

                    }

                }
                else
                {
                    if (DropDownList8.SelectedIndex != 0)
                    {
                        sqlstr = sqlstr + " where tbl_intranet_branch_detail.branch_id = '" + DropDownList8.SelectedValue + "'";
                    }

                }
                
            }


            if (txtempID.Text.Trim() != "")
                sqlstr = sqlstr + " and (tbl_intranet_employee_jobDetails.empcode like '%" + txtempID.Text.Trim().ToString() + "%' OR tbl_intranet_employee_jobDetails.emp_fname +' '+ tbl_intranet_employee_jobDetails.emp_m_name+' '+ tbl_intranet_employee_jobDetails.emp_l_name like '%" + txtempID.Text.Trim().ToString() + "%')";

          
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
           
        }
        catch (Exception ex)
        {
        }
    }

    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
            {

                txtempID.Text = "";
                if (chkempfilters.Checked == true)
                {
                    change_deptdata();
                }
                bindemployee();
                bindshift();
            }

    public void change_deptdata()
    { 
        sqlstrdept = "";

        sqlstrdept = @"select A.departmentid, A.department_name  from tbl_internate_departmentdetails as A inner join tbl_intranet_branch_detail as B on A.branchid = B.branch_id where B.branch_id= '" + DropDownList8.SelectedValue + "' or 0='" + DropDownList8.SelectedValue + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrdept);

        drpDept.DataTextField = "department_name";
        drpDept.DataValueField = "departmentid";
        drpDept.DataSource = ds.Tables[0];
        drpDept.DataBind();
    }

    public void bindshift()
    {
        sqlstr = "";

         sqlstr = @"SELECT tbl_leave_shift.shiftid, tbl_leave_shift.shiftname FROM tbl_leave_shift ";

        if (DropDownList8.SelectedIndex != 0)
        {
            sqlstr = sqlstr + " where tbl_leave_shift.branch_id in (" + DropDownList8.SelectedValue + ",0) and shiftid not in (1,2)";
        }

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
                drpMonShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(),row1["shiftid"].ToString().Trim()));
                drpTueShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpWedShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpThruShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpFriShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpSatShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
                drpSunShift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));
            } 
        }        
    }

    protected void DropDownList8_DataBound(object sender, EventArgs e)
    {
        DropDownList8.Items.Insert(0, new ListItem("ALL","0"));
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            
            if (!Chkbox.Checked)
            {
                Chkbox.Checked = true;
            }

        }
    }


    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            if (Chkbox.Checked)
            {
                Chkbox.Checked = false;
            }
        }
    }
    protected void txt_start_date_TextChanged(object sender, EventArgs e)
    {
        DateTime sdate;

         sdate = Utility.dataformat(txt_start_date.Text.ToString());
       
            TimeSpan ts = DateTime.Now - sdate;
                    
            if (Convert.ToInt16(ts.TotalDays) < 1)

                    {                      
                      DateTime d;

                      d = DateTime.Today.AddDays(0);

                      DayOfWeek monday = DayOfWeek.Monday;

                      while (d.DayOfWeek != monday)
                      {
                          d = d.AddDays(-1);
                      }

                      txt_start_date.Text = d.ToString("MM/dd/yyyy");
    
                    }
    }

    protected void chkempfilters_CheckedChanged(object sender, EventArgs e)
    {
        if (chkempfilters.Checked)
        {
            pic_more.Visible = true;
            txtempID.Text = "";
            change_deptdata();
            bindemployee();
            bindshift();
        }
        else
        {
            pic_more.Visible = false;
            txtempID.Text = "";
            bindemployee();
            bindshift();
        }
    }

    protected void bind_branch()

    {
        sqlstrbranch = @"SELECT [branch_id], [company_id], [branch_name], [branch_code] FROM [tbl_intranet_branch_detail]";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrbranch);

        DropDownList8.DataTextField ="branch_name";
        DropDownList8.DataValueField = "branch_id";

        DropDownList8.DataSource = ds;
        DropDownList8.DataBind();    
    }

    protected void bind_department()
    {

        sqlstrdepartment = @" select A.departmentid, A.department_name  from tbl_internate_departmentdetails as A inner join tbl_intranet_branch_detail as B on A.branchid = B.branch_id where B.branch_id='" + DropDownList8.SelectedValue + "' or 0='" + DropDownList8.SelectedValue + "'";

        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrdepartment);

        drpDept.DataTextField = "department_name";
        drpDept.DataValueField = "departmentid";

        drpDept.DataSource = ds1;
        drpDept.DataBind();
       
    }

    protected void drpDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtempID.Text = "";
        bindemployee();
        bindshift();
    }


    protected void imgbtn4empid_Click(object sender, ImageClickEventArgs e)
    {
        bindemployee();
    }

 protected void submitbtn_Click(object sender, EventArgs e)
 {

     int shiftvalue = 0;
     int counter;
     counter = 0;
     
     foreach (GridViewRow GridView in Grid_Emp.Rows)
     {
         CheckBox chkBox = (CheckBox)GridView.FindControl("Chkbox");

         if (chkBox.Checked)
         {

             string empCode, empName, Designation, Branch, Department;
             empCode = Grid_Emp.Rows[counter].Cells[1].Text.ToString();
             empName = Grid_Emp.Rows[counter].Cells[2].Text.ToString();
             Designation = Grid_Emp.Rows[counter].Cells[3].Text.ToString();
             Branch = Grid_Emp.Rows[counter].Cells[4].Text.ToString();
             Department = Grid_Emp.Rows[counter].Cells[5].Text.ToString();


             DateTime startdate, enddate, tmpDate;
             DayOfWeek tmpdays;


             startdate = Utility.dataformat(txt_start_date.Text.ToString());
             enddate = Utility.dataformat(txt_end_date.Text.ToString());
             TimeSpan ts = enddate.Subtract(startdate);

             for (int i = 0; ts.TotalDays >= i; i++)
             {

                 tmpDate = Convert.ToDateTime(startdate.AddDays(i).ToString("dd MMM, yy"));

                 tmpdays = tmpDate.DayOfWeek;

                 if (tmpdays == DayOfWeek.Monday)
                 {
                     shiftvalue = Convert.ToInt32(drpMonShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Tuesday)
                 {
                     shiftvalue = Convert.ToInt32(drpTueShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Wednesday)
                 {
                     shiftvalue = Convert.ToInt32(drpWedShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Thursday)
                 {
                     shiftvalue = Convert.ToInt32(drpThruShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Friday)
                 {
                     shiftvalue = Convert.ToInt32(drpFriShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Saturday)
                 {
                     shiftvalue = Convert.ToInt32(drpSatShift.SelectedValue);
                 }
                 else if (tmpdays == DayOfWeek.Sunday)
                 {
                     shiftvalue = Convert.ToInt32(drpSunShift.SelectedValue);
                 }

                 sqlstrHolidays = @"select A.date from tbl_leave_holiday as A inner join tbl_intranet_branch_detail as B  on  A.branch_id in( B.branch_id,0) where B.branch_name = '" + Branch + "' and date='" + tmpDate.ToString("MM/dd/yyyy") + "' ";

                 dssqlstrHolidays = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrHolidays);

                 if (dssqlstrHolidays.Tables[0].Rows.Count > 0)
                 {
                     shiftvalue = 1;
                 }

                 sqldeletedutyroster = @" delete from tbl_leave_dutyroster where empcode='" + empCode.Trim() + "' and date='" + tmpDate.ToString("MM/dd/yyyy") + "'";

                 DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqldeletedutyroster);

                    sqlstrinsert = "insert into tbl_leave_dutyroster(empcode,empshiftcode,date,weekdays,createdby)" + "values('" + empCode.Trim() + "', '" + shiftvalue + "','" + tmpDate.ToString("MM/dd/yyyy") + "','" + tmpdays + "','" + Session["empcode"].ToString().Trim() + "')";

                     int chek = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstrinsert);
             }

         }

         counter = counter + 1;
     }
     message.InnerHtml = "Work Roster Created Successfully";

 }
   protected void lnkrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("set-duty-roster-for-all-employee.aspx");
    }


    protected void Grid_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Emp.PageIndex = e.NewPageIndex;
        bindemployee();
    }

    protected void txt_start_date_TextChanged1(object sender, EventArgs e)
    {
        
    }
    protected void drpMonShift_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

