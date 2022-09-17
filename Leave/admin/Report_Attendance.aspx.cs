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

public partial class leave_admin_Report_Attendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["empcode"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }


            txt_sdate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("MM/dd/yyyy");
            txt_edate.Text = System.DateTime.Today.Date.ToString("MM/dd/yyyy");
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
        int search = 0;
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@search", SqlDbType.Int);

        if (rbtnMan.Checked)
            search = 0;
        else if (rbtnAttend.Checked)
            search = 1;
        else if (rbtnHF.Checked)
            search = 2;
        else if (rbtnLeave.Checked)
            search = 3;
        else if (rbtnIN.Checked)
            search = 4;
        else
            search = 5;

        sqlparam[0].Value = search;

        sqlparam[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[1].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[2] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[2].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_leave_attendance_repot", sqlparam);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }


    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        int search = 0;
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@search", SqlDbType.Int);

        if (rbtnMan.Checked)
            search = 0;
        else if (rbtnAttend.Checked)
            search = 1;
        else if (rbtnHF.Checked)
            search = 2;
        else if (rbtnLeave.Checked)
            search = 3;
        else if (rbtnIN.Checked)
            search = 4;
        else
            search = 5;

        sqlparam[0].Value = search;

        sqlparam[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[1].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[2] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[2].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_leave_attendance_repot", sqlparam);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =Attendance_Error_List.xls";
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
        ////}
        ////catch
        ////{
        ////    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        ////}
    }
}
