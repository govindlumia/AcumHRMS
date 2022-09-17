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
public partial class leave_admin_view_duty_roster : System.Web.UI.Page
{
    String sqlstr, sqlstrdept, sqlstrfindempid, ids, sqlstrinsert, setsqlstr, sqlstrcountsuperviser, sqlstrbranch, sqlstrdepartment, sqlstrgetdate;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet dsgetdate = new DataSet();
    DateTime Min_date, Max_date;
    int fflag = 0;


    string empNameCode;

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
            //lnkViewEmpDetails.Visible = false;

            bind_branch();

            bind_department();

            string employeecode = Session["empcode"].ToString().Trim();

            if (Session["role"].ToString().Trim() == "2")
            {
                chkempfilters.Checked = false;
                bindemployee();
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
                    lnkrefresh.Visible = true;
                    bindemployee();

                    pic_more.Visible = true;
                    chkempfilters.Visible = false;
                }

                else
                {

                    chkempfilters.Checked = false;
                    bindemployee();
                    Label1.Visible = false;
                    Label2.Visible = false;
                }

            }

            SetGrdRadiosOnClick();
         }

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
                sqlstr = sqlstr + " WHERE tbl_intranet_employee_jobDetails.empcode IN (select employeecode from tbl_leave_employee_hierarchy where approverid='" + Session["empcode"].ToString() + "') and tbl_intranet_employee_jobDetails.empcode in (select distinct empcode from tbl_leave_dutyroster)";
            }
            else
            {
                if (chkempfilters.Checked)
                {

                    if (DropDownList8.SelectedIndex != 0)
                    {
                        sqlstr = sqlstr + " where dbo.tbl_intranet_branch_detail.branch_id = '" + DropDownList8.SelectedValue + "' and dbo.tbl_internate_departmentdetails.departmentid = '" + drpDept.SelectedValue + "' and dbo.tbl_intranet_employee_jobDetails.empcode in (select distinct empcode from dbo.tbl_leave_dutyroster)";
                    }
                    else
                    {
                        sqlstr = sqlstr + " where dbo.tbl_internate_departmentdetails.departmentid = '" + drpDept.SelectedValue + "' and dbo.tbl_intranet_employee_jobDetails.empcode in (select distinct empcode from dbo.tbl_leave_dutyroster)";

                    }

                }
                else
                {
                    if (DropDownList8.SelectedIndex != 0)
                    {
                        sqlstr = sqlstr + " where dbo.tbl_intranet_branch_detail.branch_id = '" + DropDownList8.SelectedValue + "' and dbo.tbl_intranet_employee_jobDetails.empcode in (select distinct empcode from tbl_leave_dutyroster)";
                    }
                    else
                    {

                        sqlstr = sqlstr + " where dbo.tbl_intranet_employee_jobDetails.empcode in (select distinct empcode from dbo.tbl_leave_dutyroster)";

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

    protected void DropDownList8_DataBound(object sender, EventArgs e)
    {
        DropDownList8.Items.Insert(0, new ListItem("ALL", "0"));
    }


    protected void txt_start_date_TextChanged(object sender, EventArgs e)
    {
        DateTime sdate;

        sdate = Convert.ToDateTime(txt_start_date.Text);

        TimeSpan ts = DateTime.Now - sdate;

        if (Convert.ToInt16(ts.TotalDays) >= 8)
        {

            DateTime d;

            d = DateTime.Today.AddDays(0);

            DayOfWeek monday = DayOfWeek.Monday;

            while (d.DayOfWeek != monday)
            {
                d = d.AddDays(-1);
            }

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('Can not select back date')</script>", false);

            txt_start_date.Text = d.ToString("MM/dd/yyyy");

        }

        if (Convert.ToInt16(ts.TotalDays) < 1)
        {

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('To Date Should be less Than From Date')</script>", false);

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
        }
        else
        {
            pic_more.Visible = false;
            txtempID.Text = "";
            bindemployee();
        }

    }

    protected void bind_branch()
    {
        sqlstrbranch = @"SELECT [branch_id], [company_id], [branch_name], [branch_code] FROM [tbl_intranet_branch_detail]";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrbranch);

        DropDownList8.DataTextField = "branch_name";
        DropDownList8.DataValueField = "branch_id";

        DropDownList8.DataSource = ds;
        DropDownList8.DataBind();
    }

    protected void bind_department()
    {

        //sqlstrdepartment = @" select A.departmentid, A.department_name  from tbl_internate_departmentdetails as A inner join tbl_intranet_branch_detail as B on A.branchid = B.branch_id where B.branch_id='" + DropDownList8.SelectedValue + "' or 0='" + DropDownList8.SelectedValue + "'";
        sqlstrdepartment = @" select departmentid, department_name  from tbl_internate_departmentdetails";


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
    }


    protected void imgbtn4empid_Click(object sender, ImageClickEventArgs e)
    {
        bindemployee();
    }

    protected void lnkrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("view-duty-roster.aspx");
    }


    protected void Grid_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Emp.PageIndex = e.NewPageIndex;
        bindemployee();
    }

    protected void Optbox_CheckedChanged(object sender, EventArgs e)
    {
        SetGrdRadiosOnClick();
    }

    protected void lnkViewEmpDetails_Click(object sender, EventArgs e)
    {


        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            RadioButton Optbox = (RadioButton)GridView.FindControl("Optbox");
            Optbox.Attributes.Add("OnClick", "SelectMeOnly(" + Optbox.ClientID + ", " + "'Grid_Emp'" + ")");

            if (Optbox.Checked)
            {
                fflag = 1;
            }
        }

        if (fflag == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('Please Select Any User')</script>", false);
        }
        else
        {
            Min_date = Utility.dataformat(txt_start_date.Text.ToString());
            Max_date = Utility.dataformat(txt_end_date.Text.ToString());
            empNameCode = ViewState["empNameCode_persist"].ToString();

            Response.Redirect("empdutyroster.aspx?empCode=" + empNameCode.ToString() + "&Min_date=" + Min_date.ToString("MM/dd/yyyy") + "&Max_date=" + Max_date.ToString("MM/dd/yyyy") + " ");
        }
    }

    public void SetGrdRadiosOnClick()
    {
        int i;

        foreach (GridViewRow GridView in Grid_Emp.Rows)
        {
            RadioButton Optbox = (RadioButton)GridView.FindControl("Optbox");
            Optbox.Attributes.Add("OnClick", "SelectMeOnly(" + Optbox.ClientID + ", " + "'Grid_Emp'" + ")");

            if (Optbox.Checked)
            {
                
                empNameCode = Optbox.Text.ToString().Trim();

                ViewState["empNameCode_persist"] = Optbox.Text.ToString().Trim();

                sqlstrgetdate = @"select CONVERT(Char(10),MIN(DATE),101) AS SDATE, CONVERT(Char(10),MAX(DATE),101) AS EDATE from tbl_leave_dutyroster where empcode = '" +  empNameCode  + "' ";

                dsgetdate = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrgetdate);

                HiddenField1.Value = txt_start_date.Text = Utility.dataformat(dsgetdate.Tables[0].Rows[0][0].ToString()).ToString("MM/dd/yyyy");
                HiddenField2.Value = txt_end_date.Text = Utility.dataformat(dsgetdate.Tables[0].Rows[0][1].ToString()).ToString("MM/dd/yyyy");
            }
        }
    }
}

