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

public partial class Leave_admin_editholiday : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

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
            binddropdown();
        }
        bindalldata();
       
        if (Request.QueryString["updated"] != null)
            message.InnerHtml = "Holiday updated successfully.";
    }

    private void binddropdown()
    {
        string str1 = "SELECT distinct year from dbo.tbl_leave_holiday  order by year desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
        ddl_year.DataSource = ds.Tables[0];
        ddl_year.DataTextField = "year";
        ddl_year.DataValueField = "year";
        ddl_year.DataBind();

       

    }



    protected void bindalldata()
    {
        string str1 = "SELECT holidayid, year, dbo.tbl_leave_holiday.name,detail,datename(dw,date) dayofweek,(CASE WHEN date='01/01/1990' THEN '' ELSE  date END) date FROM  dbo.tbl_leave_holiday where year='"+ddl_year.SelectedValue+"'  order by MONTH(date), date ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, str1);
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
    public void bindholiday()
    {
        // if (ddlbranch.SelectedValue == "0")
        bindalldata();
        //   else
        //  bindsearchdata();
    }

    protected void holidaygrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code;
        code = (int)holidaygrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("updateholiday.aspx?holidayid=" + Convert.ToInt32(Request.QueryString["holidayid"]) + "");
    }

    protected void holidaygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a = (int)holidaygrid.DataKeys[e.RowIndex].Value;

        SqlParameter[] sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@holidayid", SqlDbType.Int);
        sqlparm[0].Value = a;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_updateholidayshift]", sqlparm);

        sqlstr = "DELETE FROM tbl_leave_holiday WHERE holidayid=" + a + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindholiday();
    }

    protected void holidaygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        holidaygrid.PageIndex = e.NewPageIndex;
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }

    protected void search_Click(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        bindholiday();
    }
    protected void ddl_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindalldata();
    }
}
