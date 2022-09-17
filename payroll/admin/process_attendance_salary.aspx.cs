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
using System.Data.OleDb;
using DataAccessLayer;
using System.Security.Cryptography;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity;
using System.IO;
public partial class payroll_admin_process_attendance_salary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_message.Text = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            FillControl();
            bind_fyear();

            //current_month(); //22Sep2010
        }


        //validate_attendance();
    }

    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlcompany, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        //  BindDropDowns(ddlbranch, binddrop.BindDropDowns("1", "Category"), "ID", "CategoryName");

    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void ddlcompany_selectIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        //    BindDropDowns(ddlbranch, binddrop.BindDropDowns(ddlcompany.SelectedValue, "Category"), "ID", "CategoryName");

    }

    protected void current_month()
    {
        DateTime dt = DateTime.Now;
        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);

        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_fyear()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }
    protected void validate_attendance()
    {
        sqlstr = "select count(MONTH) as rows from tbl_payroll_employee_attendence_detail where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //******************  Case 1: when there is data for the selected month for attendance in tbl_payroll_employee_attendence **************// 

        if (Convert.ToInt16(ds.Tables[0].Rows[0]["rows"]) > 0)
        {
            sqlstr = "select count(MONTH) as salary_rows from tbl_payroll_employee_salary where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            //******************  Case 2: when there is  data for slected month for salary in tbl_payroll_employee_salary **************// 

            if (Convert.ToInt16(ds.Tables[0].Rows[0]["salary_rows"]) > 0)
            {
                btn_procs_att.Enabled = false;
                btn_procs_salary.Enabled = false;
                btn_reprocs_att.Enabled = true;
                btn_reprocs_salary.Enabled = true;
            }
            //******************  Case 3: when there is no data for slected month for salary in tbl_payroll_employee_salary **************// 
            else
            {
                btn_procs_salary.Enabled = true;
                btn_reprocs_salary.Enabled = false;
                btn_procs_att.Enabled = false;
                btn_reprocs_att.Enabled = true;
            }
        }
        //******************  Case 4: when there is no data for slected month for attendance in tbl_payroll_employee_salary **************// 

        else
        {
            btn_procs_att.Enabled = true;
            btn_procs_salary.Enabled = false;
            btn_reprocs_att.Enabled = false;
            btn_reprocs_salary.Enabled = false;
        }
    }

    protected void bind_attendance()
    {
        // DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 26);

        int d;
        string str = (dd_year.SelectedItem.Text).ToString();
        str = str.Substring(0, 4);
        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        d = Convert.ToInt32(dt.Month);
        if (d <= 3)
        {
            if (d == 1)
                dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
            else if (d == 2)
                dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
            else
                dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);

        }
        else if (str == dt.Year.ToString())
        {
            dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        }
        else
        {
            dt = new DateTime(dt.AddYears(-1).Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        }





        DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar, 50);
        sqlparam[2].Value = dd_year.SelectedItem.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@branchid", SqlDbType.Int);
        //if (ddlbranch.SelectedIndex != 0)
        //{
        //    sqlparam[4].Value = ddlbranch.SelectedValue;
        //}
        //else
        //{
        sqlparam[4].Value = 1;
        //  }

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance]", sqlparam);

        //    SqlParameter[] sqlparam;
        //    sqlparam = new SqlParameter[3];

        //    sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //    sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

        //    sqlparam[1] = new SqlParameter("@enddate", SqlDbType.DateTime);
        //    sqlparam[1].Value = dt;

        //    sqlparam[2] = new SqlParameter("@sdate", SqlDbType.DateTime);
        //    sqlparam[2].Value = dt2;


        //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_process_employee_attendance", sqlparam); 
    }
    protected void btn_reprocs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance re-processed successfully";
        //validate_attendance();
    }
    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance processed successfully";
        //validate_attendance();
    }

    protected void bind_salary()
    {
        int from = 1;
        int to = 31;
        String sqlstr = "Select * from PayPeriod";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            from = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            to = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
        }

        string[] arrYear = dd_year.SelectedItem.Text.Split('-');
        int year = 0;
        int month = Convert.ToInt32(dd_month.SelectedValue);
        if (month >= 4 && month <= 12)
        {
            year = Convert.ToInt32(arrYear[0]);
        }
        else
        {
            year = Convert.ToInt32(arrYear[1]);
        }

        DateTime startDate = new DateTime(year, month, from);
        int toDaysMonth = DateTime.DaysInMonth(year, month);
        DateTime endDate = new DateTime(year, month, toDaysMonth);

        if (rbtnbranch.Checked)
        {
            if (Session["name"] != null)
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[7];

                sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

                sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
                sqlparam[1].Value = endDate;

                sqlparam[2] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
                sqlparam[2].Value = startDate;

                sqlparam[3] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                sqlparam[3].Value = Session["name"].ToString();

                sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                sqlparam[4].Value = dd_year.SelectedItem.Text;

                sqlparam[5] = new SqlParameter("@branchid", SqlDbType.Int);
                sqlparam[5].Value = 1;
                sqlparam[6] = new SqlParameter("@CompanyId", SqlDbType.Int);
                sqlparam[6].Value = ddlcompany.SelectedValue;

                DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_EMPLOYEE_SALARY_GENERATE_ALLBRANCH", sqlparam);
                lbl_message.Text = "Salary has been processed successfully.";
            }
        }
        if (rbtnemp.Checked)
        {
            sqlstr = @"select count(*) as Details from tbl_payroll_employee_salary where EMPCODE='" + txt_employee.Text + "' and MONTH='" + dd_month.SelectedItem.Text.ToString() + "' and YEAR='" + dd_year.SelectedItem.Text + "' and IS_DELIVER_SAL=1";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0]["Details"].ToString() != "0")
            {
                lbl_message.Text = "Salary already paid for this employee.";
            }
            else
            {
                bind_emp_sal(startDate, endDate);
                lbl_message.Text = "Salary has been processed successfully.";
            }

        }
    }

    protected void bind_emp_sal(DateTime startDate, DateTime endDate)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[1] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
        sqlparam[1].Value = startDate;

        sqlparam[2] = new SqlParameter("@TODATE", SqlDbType.DateTime);
        sqlparam[2].Value = endDate;

        sqlparam[3] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_year.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_employee.Text;

        sqlparam[5] = new SqlParameter("@user", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["name"].ToString();

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_SINGLE_EMPLOYEE_SALARY_GENERATE", sqlparam);
    }

    protected void btn_procs_salary_Click(object sender, EventArgs e)
    {
        try
        {
            bind_salary();
        }
        catch
        {
        }
        //lbl_message.Text = "Salary processed successfully";
    }

    protected void btn_reprocs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary re-processed successfully";
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_fyear();
    }

    protected void rbtnemp_CheckedChanged(object sender, EventArgs e)
    {
        divemp.Visible = true;
        divbranch.Visible = false;
    }

    protected void rbtnbranch_CheckedChanged(object sender, EventArgs e)
    {
        divemp.Visible = false;
        divbranch.Visible = true;
    }

    protected void Btnverifieddetils_Click(object sender, EventArgs e)
    {
        string filename = "Process Salary Details for Month :- " + dd_month.SelectedItem.Text;
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[4];
        if (rbtnbranch.Checked)
        {
            sqlparam[0] = new SqlParameter("@SingleEmpcode", SqlDbType.VarChar, 20);
            sqlparam[0].Value = null;
        }
        else
        {
            sqlparam[0] = new SqlParameter("@SingleEmpcode", SqlDbType.VarChar, 20);
            sqlparam[0].Value = txt_employee.Text;

        }
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 20);
        sqlparam[1].Value = dd_month.SelectedItem.Text.ToString(); ;

        sqlparam[2] = new SqlParameter("@fyear", SqlDbType.VarChar, 20);
        sqlparam[2].Value = dd_year.SelectedItem.Text;

        sqlparam[3] = new SqlParameter("@companyId", SqlDbType.Int);
        sqlparam[3].Value = ddlcompany.SelectedValue;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Verify_employee_processed_salary", sqlparam);
        if (ds.Tables[0].Rows.Count != 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=Salary-Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                GridView1.Rows[i].Attributes.Add("class", "textmode");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}


