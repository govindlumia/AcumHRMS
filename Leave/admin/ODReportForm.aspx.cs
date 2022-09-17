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
using Utilities;
using System.IO;

public partial class leave_admin_ODReportForm : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
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

            txt_sdate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("dd-MMM-yyyy");
            txt_edate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            //dd_branch.DataBind();
            //ddlbranch.DataBind();
            //bindempdetail();
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@dept", SqlDbType.Int);
        sqlparam[1].Value = dd_branch.SelectedValue;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
        sqlparam[2].Value = ddlbranch.SelectedValue;

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_leave_attendance_OD", sqlparam);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@dept", SqlDbType.Int);
        sqlparam[1].Value = dd_branch.SelectedValue;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
        sqlparam[2].Value = ddlbranch.SelectedValue;

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_leave_attendance_OD", sqlparam);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =ODReport.xls";
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
                i.Cells[colindex].Attributes.Add("class", "text");
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
}
