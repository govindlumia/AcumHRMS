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
using CrystalDecisions.Shared;
using System.Data.SqlClient;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;

public partial class payroll_admin_reports_pfform10 : System.Web.UI.Page
{
    SqlParameter[] sqlparm;

    protected void Page_Load(object sender, EventArgs e)
    {
        string year = Request.QueryString["year"].ToString();
        string monthvalue = Request.QueryString["monthvalue"].ToString();

        string month = Request.QueryString["month"].ToString();
        string branch = Request.QueryString["branch"].ToString();
        string company = Request.QueryString["com"].ToString();
        string monthyear;

        sqlparm = new SqlParameter[5];
        string fromyear = year.Substring(0, 4);
        string toyear = Convert.ToString(Convert.ToInt32(year.Substring(5, 4)) + 1);

        sqlparm[0] = new SqlParameter("@fromyear", fromyear);
        sqlparm[1] = new SqlParameter("@toyear", toyear);
        sqlparm[2] = new SqlParameter("@monthvalue", monthvalue);
        sqlparm[3] = new SqlParameter("@branch", branch);
        sqlparm[4] = new SqlParameter("@company", company);
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform10", sqlparm);
        ds1.Tables[0].TableName = "pfform10";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_pfdetils", new SqlParameter("@company", company));
        ds2.Tables[0].TableName = "company";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();

        myReportDocument.Load(Server.MapPath("pfform10.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["pfform10"]);

        myReportDocument.OpenSubreport("pfform10_headerSectionDetails.rpt").SetDataSource(ds2.Tables["company"]);
        myReportDocument.SetParameterValue("financialyear", Request.QueryString["year"].ToString());
        
        if (month == "Jan" || month == "Feb" || month == "Mar")
        {
            monthyear = month + "/" + year.Substring(5, 4);
        }
        else
        {
            monthyear = month + "/" + year.Substring(0, 4);
        }

        myReportDocument.SetParameterValue("monthyear", monthyear);
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
