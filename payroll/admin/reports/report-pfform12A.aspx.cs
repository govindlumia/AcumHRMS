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

public partial class payroll_admin_reports_report_pfform12 : System.Web.UI.Page
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
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('pfform12A.aspx?year=" + dd_year.SelectedItem.Text.ToString() + "&month=" + dd_month.SelectedItem.Text.ToString().Substring(0,3) +  "&monthvalue=" + dd_month.SelectedItem.Value + "&branch_id=1&Com="+ddl_company.SelectedValue+"')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {

    }

    protected void bind_year()
    {
        sqlstr = sqlstr = "select distinct year from tbl_payroll_employee_salary order by year desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();

        sqlstr = "select companyid,companyname from tbl_intranet_companydetails";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        ddl_company.DataTextField = "companyname";
        ddl_company.DataValueField = "companyid";
        ddl_company.DataSource = ds;
        ddl_company.DataBind();
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
      //  ddlbranch.Items.Insert(0, new ListItem("---Select Cost Center---", "0"));
    }
}
