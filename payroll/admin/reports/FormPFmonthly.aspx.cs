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
public partial class payroll_admin_reports_Form16 : System.Web.UI.Page
{
    SqlParameter [] sqlparm;
    string strcmd = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string month = Request.QueryString["month"].ToString();
        string year = Request.QueryString["year"].ToString();
        string branch = Request.QueryString["branch"].ToString();
        sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@month", month);
        sqlparm[1] = new SqlParameter("@fyear", year);
        sqlparm[2] = new SqlParameter("@branch", branch);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_pf_monthlyreport", sqlparm);
        ds.Tables[0].TableName = "pf_monthly";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("pfmonthlyreport.rpt"));
        myReportDocument.SetDataSource(ds.Tables["pf_monthly"]);

        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}
