using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.IO;

public partial class leave_admin_uploadErrorReport : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["empcode"] != null)
            {
                if ((Session["empcode"].ToString() == "AEC-888") || (Session["empcode"].ToString() == "AEC-015"))
                {

                }
                else
                {
                    Response.Redirect("~/Authenticate.aspx");
                }
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
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
                        file_name = Server.MapPath(".") + "\\upload\\ErrorList.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());
                        message.InnerHtml = "";
                        message.InnerHtml = "";
                        return true;
                        break;
                    }
                default:
                    {
                        message.InnerHtml = "";
                        message.InnerHtml = "Only Excel File can be uploaded";
                        return false;
                        break;
                    }
            }
            return true;
        }
        return true;
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (uploaddocument())
            {
                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    try
                    {
                        string file = Server.MapPath(".") + "/upload/ErrorList.xls";
                        String strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Server.MapPath(".") + "\\upload\\ErrorList.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                        OleDbConnection objconn = new OleDbConnection(strConn);
                        objconn.Open();
                        OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                        OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                        objadapter1.SelectCommand = objcmdselect;
                        DataSet dds = new DataSet();
                        objadapter1.Fill(dds, "Attendance");
                        objconn.Close();

                        for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                        {
                            sqlparm = new SqlParameter[6];
                            sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["EMPCODE"].ToString().Trim());
                            sqlparm[1] = new SqlParameter("@date", dds.Tables[0].Rows[i]["DATE"].ToString().Trim());
                            sqlparm[2] = new SqlParameter("@intime", dds.Tables[0].Rows[i]["INTIME"].ToString().Trim());
                            sqlparm[3] = new SqlParameter("@outtime", dds.Tables[0].Rows[i]["OUTTIME"].ToString().Trim());
                            sqlparm[4] = new SqlParameter("@mode", dds.Tables[0].Rows[i]["MODE"].ToString().Trim());
                            sqlparm[5] = new SqlParameter("@flag", dds.Tables[0].Rows[i]["FLAG"].ToString().Trim());

                            if (sqlparm[0].Value.ToString().Trim() != "")
                            {
                                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_leave_attendance_errorlist_upload]", sqlparm);
                            }
                            else
                            {
                                message.InnerHtml = "Please check format of empcode in excel";
                                return;
                            }                            
                        }
                        message.InnerHtml = " Data has been uploaded successfully!";
                    }
                    catch (Exception ex)
                    {
                        message.InnerHtml = "Please check excel name and data properly!";
                    }
                }
            }
        }
    }
}
