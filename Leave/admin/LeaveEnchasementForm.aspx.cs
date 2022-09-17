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
public partial class leave_admin_LeaveEnchasementForm : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_year();
            bind_month();
        }
    }
    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        //commented by sudhir
        //sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='2010-2011' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }
    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = "SELECT case when entitled_days - used_days - " + txtleaveencashed.Text.Trim().ToString() + " >= 24 then 1 else 0 end checkdays from tbl_leave_employee_leave_master where empcode='" + txt_employee.Text.Trim().ToString() + "' and leaveid=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 1)
        {
            string sql = "UPDATE tbl_leave_employee_leave_master set entitled_days=entitled_days - " + txtleaveencashed.Text.Trim().ToString() + " where empcode='" + txt_employee.Text.Trim().ToString() + "' and leaveid=1";
            DataSet dst = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sql);
            message.InnerHtml = "Leave Encashment successfully !";

            string sql1 = @"INSERT INTO tbl_leave_employee_leave_master_encashment(empcode,fyear,month,leaveencashed,updatedby,updateddate)
                            VALUES('" + txt_employee.Text.Trim().ToString() + "','" + dd_year.SelectedItem.Text + "','" + dd_month.SelectedItem.Text + "','" + txtleaveencashed.Text.Trim() + "','" + Session["empcode"].ToString() + "','" + System.DateTime.Now + "')";
            DataSet dst1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sql1);
            
        }
        else
        {
            message.InnerHtml = "Earned Leave balance should be greater than 24 days !";
        }
    }
    protected void txt_employee_TextChanged(object sender, EventArgs e)
    {
        if (txt_employee.Text.Trim() != "")
        {
            sqlstr = "select entitled_days from tbl_leave_employee_leave_master where empcode='" + txt_employee.Text.Trim().ToString() + "' and leaveid=1";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
                lblentitled.Text = ds.Tables[0].Rows[0][0].ToString();
            else
                lblentitled.Text = "0.0";
        }
    }
}
