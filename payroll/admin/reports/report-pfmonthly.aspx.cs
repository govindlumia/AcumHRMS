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
using System.Data.SqlClient;
using DataAccessLayer;
using HRMS.DataAccessLayer;
public partial class payroll_admin_view_payslip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strPop;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            bind_month();
        }

      
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('FormPFmonthly.aspx?month=" + dd_month.SelectedItem.Text.ToString() + "&year=" + dd_year.SelectedItem.Text.ToString() + "&branch=" + dd_branch.SelectedValue + "')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }
    
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        dd_month.SelectedIndex = -1;
        dd_year.SelectedIndex = -1;
    }

    protected void bind_month()
    {
        CommonDataAccess obj = new CommonDataAccess();
        sqlstr = obj.Bindmonthdropdown(dd_year.SelectedValue);
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }

    protected void bind_year()
    {
        sqlstr = sqlstr = "select distinct year from tbl_payroll_employee_salary order by year desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }


    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("---Select Company---", "0"));
    }
    
}
