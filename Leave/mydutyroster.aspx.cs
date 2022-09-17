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
using System.Text;

public partial class leave_mydutyroster : System.Web.UI.Page
{
    string sqlstrBindDutyRoster;
    
    DataSet dsBindDutyRoster = new DataSet();
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindweekdutyroaster();
        }
    }

    protected void binddutyrosteremployee()
    {
        if (Session["empcode"] != null)
        {
            sqlstrBindDutyRoster = @" select A.empcode AS EMPCODE, (CASE WHEN A.date='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), A.date, 101) END) AS DATE,A.date As date1, A.weekdays AS DAYS, B.ShiftName AS SHIFT from tbl_leave_dutyroster as A inner join tbl_leave_shift as B on B.shiftid = A.empshiftcode where A.empcode='" + Session["empcode"].ToString() + "' ";

            if ((txt_sdate.Text.Trim().ToString() != "") && (txt_edate.Text.Trim().ToString() != ""))
            {
                sqlstrBindDutyRoster = sqlstrBindDutyRoster + " AND A.date between '" + txt_sdate.Text + "' and '" + txt_edate.Text.Trim() + "'";
            }

            sqlstrBindDutyRoster = sqlstrBindDutyRoster + " ORDER BY A.date";

            dsBindDutyRoster = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrBindDutyRoster);

            empdutyrosterdetails.DataSource = dsBindDutyRoster;

            empdutyrosterdetails.DataBind();
        }
        else
        {
        }

    }

    
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        binddutyrosteremployee();
    }

    protected void bindweekdutyroaster()
    {
        DateTime d;

        d = DateTime.Today.AddDays(0);

        DayOfWeek monday = DayOfWeek.Monday;

        while (d.DayOfWeek != monday)
        {
            d = d.AddDays(-1);
        }

        HiddenField1.Value = txt_sdate.Text = d.ToString("MM/dd/yyyy");

        HiddenField2.Value = txt_edate.Text = d.AddDays(6).ToString("MM/dd/yyyy");

        sqlstrBindDutyRoster = @" select A.empcode AS EMPCODE, (CASE WHEN A.date='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), A.date, 101) END) AS DATE,A.date As date1, A.weekdays AS DAYS, B.ShiftName AS SHIFT from tbl_leave_dutyroster as A inner join tbl_leave_shift as B on B.shiftid = A.empshiftcode where A.empcode='" + Session["empCode"].ToString() + "' ";

        sqlstrBindDutyRoster = sqlstrBindDutyRoster + " and A.date between '" + txt_sdate.Text + "' and '" + txt_edate.Text + "'";
        
        dsBindDutyRoster = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrBindDutyRoster);


        if (dsBindDutyRoster.Tables[0].Rows.Count > 0)
        {

            empdutyrosterdetails.DataSource = dsBindDutyRoster;

            empdutyrosterdetails.DataBind();

            divmessage.Visible = false;
            divgrid.Visible =true;
        }
        else
        {
            divmessage.Visible  =true ;
            divgrid.Visible = false;
            lblmessage.Text = "No Duty Roster has been created.";
        }
    }

    protected void chk_temp_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_temp.Checked == true)
        {
            date.Visible = false;
            template.Visible = true;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
        }
        else
        {
            date.Visible = true;
            template.Visible = false;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
        }
    }


    protected void bindrange()
    {
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        //current weeks
        if (drp_template.SelectedValue == "0")
        {
            while (dt.DayOfWeek.ToString() != "Monday")
            dt = dt.AddDays(-1);
            sdate = dt;
            edate = sdate.AddDays(6);
        }
        //next week
        if (drp_template.SelectedValue == "1")
        {
            while (dt.DayOfWeek.ToString() != "Monday")
            dt = dt.AddDays(-1);
            sdate = dt.AddDays(7);
            edate = sdate.AddDays(6);
        }
        //select day(dateadd(month,1,getdate()) - day(dateadd(month,1,getdate())))
        //string strnoofdays = "select day(dateadd(month,1,getdate()) - day(dateadd(month,1,getdate())))";
        //DataSet dsnoofdays = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strnoofdays);

        //int days = Convert.ToInt32(dsnoofdays.Tables[0].Rows[0][0]);
        //current month
        if (drp_template.SelectedValue == "2")
        {
            //select day(dateadd(month,1,getdate()) - day(dateadd(month,1,getdate())))
            string strnoofdays = "select day(dateadd(month,1,getdate()) - day(dateadd(month,1,getdate())))";
            DataSet dsnoofdays = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strnoofdays);

            int days = Convert.ToInt32(dsnoofdays.Tables[0].Rows[0][0]);
            sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
            edate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/" + days + "/" + DateTime.Today.Year.ToString());
        }

        //next month
        if (drp_template.SelectedValue == "3")
        {
            //select day(dateadd(month,1,getdate()) - day(dateadd(month,1,getdate())))
            string strnoofdays1 = "select day(dateadd(month,2,getdate()) - day(dateadd(month,2,getdate())))";
            DataSet dsnoofdays1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strnoofdays1);

            int days1 = Convert.ToInt32(dsnoofdays1.Tables[0].Rows[0][0]);
            sdate = Convert.ToDateTime((DateTime.Today.Month + 1) + "/1/" + DateTime.Today.Year.ToString());
            edate = Convert.ToDateTime((DateTime.Today.Month + 1) + "/" + days1 + "/" + DateTime.Today.Year.ToString());
        }
        //current year
        if (drp_template.SelectedValue == "4")
        {
            sdate = Convert.ToDateTime("1/1/" + DateTime.Today.Year.ToString());
            edate = Convert.ToDateTime("12/31/" + DateTime.Today.Year.ToString());
        }

        //next year
        if (drp_template.SelectedValue == "5")
        {
            int year = Convert.ToInt32(DateTime.Today.Year) + 1;

            sdate = Convert.ToDateTime("1/1/" + year.ToString());
            edate = Convert.ToDateTime("12/31/" + year.ToString());
        }
        txt_sdate.Text = sdate.ToShortDateString();
        txt_edate.Text = edate.ToShortDateString();
    }
    protected void drp_template_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindrange();
        binddutyrosteremployee();
    }
    protected void empdutyrosterdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empdutyrosterdetails.PageIndex = e.NewPageIndex;
        binddutyrosteremployee();
    }

    protected void Chk_holiday_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_holiday.Checked == true)
        {
           
            holiday.Visible = false;
            holiday.Visible = true;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
        }
        else
        {
            holiday.Visible = true;
            holiday.Visible = false;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;

        }
    }
   protected void drp_holiday_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}



