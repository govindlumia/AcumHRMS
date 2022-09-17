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
using querystring;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HRMS.DataAccessLayer;
using System.IO;
using System.Net;
using System.Web.Configuration;
using Utilities;
using System.IO.Compression;
using Ionic.Zip;

public partial class payroll_admin_DownloadAllEmpSalarySlip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    ArrayList listfilename = new ArrayList();
    string sqlstr;
    string strPop;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dd_year.Attributes.Add("onChange", "return onChange()");

            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            bind_month();
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        //bind_month();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = @"select distinct tbl_payroll_employee_salary.EMPCODE,tbl_intranet_employee_jobDetails.emp_fname from tbl_payroll_employee_salary inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salary.EMPCODE=tbl_intranet_employee_jobDetails.empcode where tbl_payroll_employee_salary.MONTH='" + dd_month.SelectedItem.Text + "' and tbl_payroll_employee_salary.Year='" + dd_year.SelectedItem.Text + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        if(ds.Tables[0].Rows.Count>0)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("PaySlip");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //==============Create sal slip and convert into pdf and save into folder===========
                    string empcode = ds.Tables[0].Rows[i]["EmpCode"].ToString();
                    var empsalhtml = Getemployeesalhtml(empcode, dd_month.SelectedItem.Text, dd_year.SelectedItem.Text);
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    var pdfBytes = htmlToPdf.GeneratePdf(empsalhtml);
                    string path = Server.MapPath("~/Upload/SalarySlips/") + Utility.Getrandomtext() + "-" + ds.Tables[0].Rows[i]["emp_fname"].ToString() + ".pdf";
                    File.WriteAllBytes(path, pdfBytes);
                    listfilename.Add(path);
                    //==================================================================================
                    //=========Add file in Zip folder===================================================
                      zip.AddFile(path, "PaySlip");
                    //==================================================================================
                }
                //===========Download Zip file==========================================================
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Payslip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);              
                //========================Remove file from folder after downloaded======================
                foreach(var filepath in listfilename)
                {
                    if (filepath.ToString() != null)
                   {
                       System.IO.File.Delete(filepath.ToString());
                   }
                }
                //======================================================================================
                listfilename = null;
                Response.End();

            }
           
        }


    }


    //====================Get Html of salary page==========================
    protected string Getemployeesalhtml(string empcode, string month, string year)
    {
        query q = new query();
        string pairs = String.Format("empcode={0}&month={1}&year={2}", empcode.ToString(), month.ToString(), year.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);

        string url = WebConfigurationManager.AppSettings["BaseUrl"] + "payroll/admin/demopayslip.aspx?q=" + encoded + "";
        string result = "";
        try
        {
            System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());
            StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
            result = sr.ReadToEnd();
            sr.Close();
        }
        catch (WebException webex)
        {
            WebResponse errResp = webex.Response;
            using (Stream respStream = errResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(respStream);
                result = reader.ReadToEnd();
            }
        }

        return result;
    }
    //==================================================

    protected void bind_month()
    {
        CommonDataAccess obj = new CommonDataAccess();
        sqlstr = obj.Bindmonthdropdown(dd_year.SelectedValue);
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

    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }
}
