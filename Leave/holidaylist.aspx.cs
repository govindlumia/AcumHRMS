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

public partial class Leave_holidaylist : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
           // bindbranch();
            bindholiday();            
        }
    }
          
    protected void holidaygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {      
        holidaygrid.PageIndex = e.NewPageIndex;
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }

    public string GetDay(String uDate)
    {

        string day;
        DateTime date = Convert.ToDateTime(uDate);
        day = date.DayOfWeek.ToString();
        return day;
    }

   
    private string getMonthfromValue(int value)
    {
        switch (value)
        {
            case 1: return "Jan";
            case 2: return "Feb";
            case 3: return "March";
            case 4: return "April";
            case 5: return "May";
            case 6: return "June";
            case 7: return "July";
            case 8: return "Aug";
            case 9: return "Sep";
            case 10: return "Oct";
            case 11: return "Nov";
            case 12: return "Dec";
        }
        return "NA";
    }
    protected void bindholiday()
    {
        sqlstr = @"SELECT tbl_leave_holiday.holidayid,
                  tbl_leave_holiday.year, tbl_leave_holiday.name,
                  tbl_leave_holiday.detail,datename(dw,tbl_leave_holiday.date) dayofweek,
                  (CASE WHEN tbl_leave_holiday.date='01/01/1990' THEN '' ELSE  tbl_leave_holiday.date end) as date 
                  FROM  tbl_leave_holiday 
                 where tbl_leave_holiday.year=year(getdate()) order by tbl_leave_holiday.year desc,tbl_leave_holiday.date";
        //sqlstr = "SELECT tbl_intranet_employee_jobDetails.empcode, tbl_leave_holiday.holidayid, tbl_leave_holiday.name, tbl_leave_holiday.detail,(CASE WHEN tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), tbl_leave_holiday.date, 106) END) date, tbl_intranet_branch_detail.branch_name FROM tbl_leave_holiday INNER JOIN tbl_intranet_employee_jobDetails ON tbl_leave_holiday.branch_id = tbl_intranet_employee_jobDetails.branch_id INNER JOIN tbl_intranet_branch_detail ON tbl_leave_holiday.branch_id = tbl_intranet_branch_detail.branch_Id CROSS JOIN tbl_employee_personaldetails where empcode = '" + Session["empcode"] + "' AND tbl_leave_holiday.status='1' ORDER BY date";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString, CommandType.Text, sqlstr);
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }
    
    protected void bindallbranchholiday()
    {
        sqlstr = "SELECT dbo.tbl_leave_holiday.holidayid, isnull(dbo.tbl_intranet_branch_detail.branch_name,'All Branch') branch_name, dbo.tbl_leave_holiday.year, dbo.tbl_leave_holiday.name, dbo.tbl_leave_holiday.detail,datename(dw,convert(varchar(11),tbl_leave_holiday.date,101)) dayofweek, (CASE WHEN dbo.tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), dbo.tbl_leave_holiday.date, 106) END) date FROM  dbo.tbl_leave_holiday left outer JOIN dbo.tbl_intranet_branch_detail ON dbo.tbl_leave_holiday.branch_id = dbo.tbl_intranet_branch_detail.branch_id where tbl_leave_holiday.year=year(getdate()) order by dbo.tbl_leave_holiday.year desc,dbo.tbl_leave_holiday.date";
        //sqlstr = "SELECT DISTINCT holidayid,(CASE WHEN date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), date, 106) END) date,name,detail FROM  tbl_leave_holiday WHERE tbl_leave_holiday.status='1' and tbl_leave_holiday.branch_id=0 order by date";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString, CommandType.Text, sqlstr);
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }

    protected void lbBranch_Click(object sender, EventArgs e)
    {
        bindholiday();
    }

    protected void lbAllBranch_Click(object sender, EventArgs e)
    {
        bindallbranchholiday();
    }  
}
