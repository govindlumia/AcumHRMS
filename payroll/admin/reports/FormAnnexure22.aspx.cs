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
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;
using NumberToEnglish;
using System.Globalization;

public partial class payroll_admin_reports_FormAnnexure22 : System.Web.UI.Page
{
    SqlParameter[] sqlparm;
    string strcmd = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string month = Request.QueryString["month"].ToString();
        string year = Request.QueryString["year"].ToString();
        string branch = Request.QueryString["branch"].ToString();
        string empcode = Request.QueryString["empcode"].ToString();
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@month", month);
        sqlparm[1] = new SqlParameter("@fyear", year);
        sqlparm[2] = new SqlParameter("@CompanyId", branch);
        sqlparm[3] = new SqlParameter("@empcode", empcode);


        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_Annexure22", sqlparm);
        ds.Tables[0].TableName = "Annexure22";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure , "sp_company_detail",sqlparm);
        ds1.Tables[0].TableName = "companydetail";
       
        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("Annexureform22.rpt"));
        myReportDocument.SetDataSource(ds.Tables["Annexure22"]);

        myReportDocument.OpenSubreport("Company.rpt").SetDataSource(ds1.Tables["companydetail"]);

        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

        Response.Buffer = false;
        // Clear the response content and headers
        Response.ClearContent();
        Response.ClearHeaders();
        //try
        //{
        //    // Export the Report to Response stream in PDF format and file name Customers
        //    myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "'" + strempcode.ToString() + "'" + companyname);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    ex = null;
        //}

    }
}