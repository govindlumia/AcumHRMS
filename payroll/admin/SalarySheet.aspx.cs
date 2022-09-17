using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using System.IO;

public partial class payroll_admin_paystructureempview : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }

    //protected void dd_designation_DataBound(object sender, EventArgs e)
    //{
    //    dd_designation.Items.Insert(0, new ListItem("All", "0"));
    //}

    //protected void dd_branch_DataBound(object sender, EventArgs e)
    //{
    //    dd_branch.Items.Insert(0, new ListItem("All", "0"));
    //}

    protected void btn_search_Click(object sender, EventArgs e)
    {
        string month = (ddl_month.SelectedValue.ToString() == "None") ? "" : ddl_month.SelectedValue.ToString();
        string strPop;
        if (rpt_D.Checked)
            strPop = "<script language='javascript'>window.open('reports/SalarySheet.aspx?q=" + encode("0", "0", month, ddl_year.SelectedValue.ToString()) + "')</script>";
        else
            strPop = "<script language='javascript'>window.open('reports/SalarySheetSummarize.aspx?q=" + encode("0", "0", month, ddl_year.SelectedValue.ToString()) + "')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }

    protected string encode(string branch, string dept, string month, string year)
    {
        query q = new query();
        string pairs = String.Format("branch={0}&dept={1}&month={2}&year={3}", branch, dept, month, year);
        string encoded;
        encoded = q.EncodePairs(pairs);
        return encoded;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds1;
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@branch", "0");
        sqlparm[1] = new SqlParameter("@dept", "0");
        sqlparm[2] = new SqlParameter("@month", ddl_month.SelectedValue);
        sqlparm[3] = new SqlParameter("@year", ddl_year.SelectedValue);

        if (rpt_D.Checked)
        {
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_salary_sheet_monthly_export]", sqlparm);
        }
        else
        {
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_salary_sheet_monthly_summary_export]", sqlparm);
        }
        
        ds1.Tables[0].TableName = "table";

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =Salary Sheet.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds1.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds1.Tables[0].Columns)
        {
            //if (dc.Table.Columns["Empcode"].Caption=="Empcode")
            //{
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[0].Attributes.Add("class", "text");
            colindex++;
            //}
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
