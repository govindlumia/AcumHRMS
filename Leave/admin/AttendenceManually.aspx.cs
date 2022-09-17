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
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity;

public partial class Leave_admin_AttendenceManually : System.Web.UI.Page
{
    string FileName = string.Empty; // For FileName
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dds = new DataTable();
    string companyId;

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
            bind_fyear();
            FillControl();


        }
       


    }

    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddlcompany_new, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddlbranch, binddrop.BindDropDowns("1", "Category"), "ID", "CategoryName");

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
        BindDropDowns(ddlbranch, binddrop.BindDropDowns(ddlcompany_new.SelectedValue, "Category"), "ID", "CategoryName");

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
    //protected void bind_fyear()
    //{
    //    DateTime dt = DateTime.Now;

    //    if (Convert.ToInt16(dt.Day) > 30)
    //        dt = dt.AddMonths(1);

    //    if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
    //        lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
    //    else
    //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    //}


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
        //  DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
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

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@startdateback", SqlDbType.DateTime);
        param[0].Value = dt2;
        param[1] = new SqlParameter("@enddateback", SqlDbType.DateTime);
        param[1].Value = dt;


        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_process_employee_attendance_ondailybasis_backmonth]", param);


        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar, 50);
        sqlparam[2].Value = dd_year.SelectedItem.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@catID", SqlDbType.Int);
        sqlparam[4].Value = Convert.ToInt32(ddlbranch.SelectedValue);
        //  }
        //   sqlparam[5] = new SqlParameter("@phase", SqlDbType.VarChar, 50);
        //// sqlparam[5].Value = ddlPhase.Text;
        //   sqlparam[5].Value = 1;

        sqlparam[5] = new SqlParameter("@CompanyId", SqlDbType.Int);
        sqlparam[5].Value = ddlcompany_new.SelectedValue;

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance]", sqlparam);
        // DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[Process_attendance_monthly_AN_BranchWise_Phase1]", sqlparam);


        //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance_AN]", sqlparam);

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
        bindgrid();
        lbl_message.Text = lbl_message.Text = "Attendance computed successfully";
        //validate_attendance();
    }

    protected void bind_salary()
    {
        if (Session["name"] != null)
        {
            DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 26);
            DateTime dt2 = dt.AddMonths(1).AddDays(-1);

            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

            sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
            sqlparam[1].Value = dt2;

            sqlparam[2] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
            sqlparam[2].Value = dt;

            sqlparam[3] = new SqlParameter("@user", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["name"].ToString();

            sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
            sqlparam[4].Value = dd_year.SelectedItem.Text;

            sqlparam[5] = new SqlParameter("@branchid", SqlDbType.Int);
            if (ddlbranch.SelectedIndex != 0)
            {
                sqlparam[5].Value = ddlbranch.SelectedValue;
            }
            else
            {
                sqlparam[5].Value = 0;
            }

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_EMPLOYEE_SALARY_GENERATE", sqlparam);
        }
    }
    protected void btn_procs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary processed successfully";
        //validate_attendance();
    }
    protected void btn_reprocs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary re-processed successfully";
        //validate_attendance();
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
        //validate_attendance();
    }

    //protected void find_end_start_date()
    //{
    //    DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 24);
    //    DateTime dt2 = dt.AddMonths(-1).AddDays(1);


    //}
    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("---- All ----", "-1"));
    }

    protected bool uploaddocument()
    {
        string file_name, fn, ftype;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xls":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\attendance.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());

                        lbl_message.Text = "";
                        return true;
                        //break;
                    }
                default:
                    {
                        lbl_message.Text = "";
                        lbl_message.Text = "Only Excel File can be uploaded";
                        return false;
                        //break;
                    }
            }
            return true;
        }
        return true;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
        try
        {
            //if (uploaddocument())
            //{
            if (fupload.PostedFile.FileName.ToString() != "")
            {
                DataSet dds = new DataSet();
                string fileName = string.Empty;
                string fn = string.Empty;
                if (fupload.HasFile)
                {
                    //---------------------------------------------------------------------------------------
                    fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
                    fileName = Server.MapPath(".") + "\\upload\\" + fn;
                    System.IO.FileAccess.ReadWrite.ToString();
                    ////FileUpload1.SaveAs(Server.MapPath(fileName));
                    fupload.SaveAs(fileName);
                    //string strFileNameRed = Server.MapPath(".") + "\\upload\\" + fupload.FileName;
                    //string[] strfpart = fileName.Split('.');
                    //string getFormat = strfpart[strfpart.Length - 1].ToString();
                    //System.IO.FileAccess.ReadWrite.ToString();

                    //CSVReader objReadFile = new CSVReader();
                    //dds = objReadFile.GetDataTable(strFileNameRed, getFormat);
                    //System.IO.File.Delete(fileName);
                    //---------------------------------------------------------------------------------------------

                    string file = Server.MapPath(".") + "/upload/" + fn;
                    String strConn = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source='" + Server.MapPath(".") + "\\upload\\" + fn + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;

                    System.IO.FileAccess.ReadWrite.ToString();
                    objadapter1.Fill(dds, "Attendance");
                    objconn.Close();

                }                

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

                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {
                    SqlParameter[] sqlparm = new SqlParameter[7];
                    sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["empcode"].ToString().Trim());
                    sqlparm[1] = new SqlParameter("@lwp", dds.Tables[0].Rows[i]["lwp"].ToString());
                    sqlparm[2] = new SqlParameter("@working_days", dds.Tables[0].Rows[i]["days"].ToString());
                    sqlparm[3] = new SqlParameter("@fromdate", startDate);
                    sqlparm[4] = new SqlParameter("@todate", endDate);
                    sqlparm[5] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                    sqlparm[6] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());


                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_import_attendance]", sqlparm);
                }
                lbl_message.Text = "Attendance data uploaded successfully!";
                bindgrid();
            }
            //}
        }
        catch (Exception ex)
        {
            lbl_message.Text = "Please check Excel format.There must be three fields named empcode,lwp and days with sheet named SHEET1.There should not be blank data.";
        }
        //}
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
        Int64 CategoryId = 0;
        if (ddlbranch.SelectedIndex!=0)
        {
            CategoryId =Convert.ToInt64(ddlbranch.SelectedValue);
        }
        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@year", dd_year.Text.Trim().ToString());
        sqlparm[2] = new SqlParameter("@CategoryId", CategoryId);
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_attendance]", sqlparm);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }


    protected void exportexcel()
    {
        string filename = "Process Attendance Details Report for Month :- " + dd_month.SelectedItem.Text;

        SqlParameter[] sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_attendance]", sqlparm);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[0].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
    protected void ddlcompany_DataBound(object sender, EventArgs e)
    {
        //ddlcompany.Items.Insert(0, new ListItem("---Select Company---", "0"));
        //ddlcompany.Items.Insert(0, new ListItem("---Select Company---", "0"));

    }
}