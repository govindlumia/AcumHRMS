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
using DataAccessLayer;
using Utilities;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data.OleDb;
using HRMS.BusinessLogic;
using HRMS.BusinessEntity;

public partial class leave_uploadcompoffdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
        message.InnerHtml = "";
    }

    protected void ExcelUpload()
    {
        string fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName);
        Random nxt = new Random();
        fn = nxt.Next().ToString() + fn;
        if (fupload.PostedFile.FileName != "")
        {
            string ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xlsx":
                    {
                        //* Starts (Validation for checking whether file name with same name already exists or not)
                        string[] haveFile = Directory.GetFiles(Server.MapPath(".") + "/upload/leavedata/", fn + ".xlsx");
                        while (haveFile.Length > 0)
                        {
                            fn = string.Empty;
                            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName);
                            fn = nxt.Next().ToString() + fn;
                            haveFile = Directory.GetFiles(Server.MapPath(".") + "/upload/leavedata/", fn + ".xlsx");
                        }
                        //* Validation ends

                        fupload.PostedFile.SaveAs(Server.MapPath(".") + "/upload/leavedata/" + fn);
                        ExcelToData(fn);
                        break;
                    }
                default:
                    {
                        message.InnerHtml = "";
                        message.InnerHtml = "Only .xlsx format files supported.";
                        break;
                    }
            }
        }
    }

    protected void ExcelToData(string fileName)
    {
        fileName = Server.MapPath(".") + "/upload/leavedata/" + fileName;

        DataTable dt = new DataTable();
        OleDbCommand excelCmd = new OleDbCommand();
        OleDbDataAdapter excelAdb = new OleDbDataAdapter();

        string excelConnString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0";

        OleDbConnection excelConn = new OleDbConnection(excelConnString);
        excelConn.Open();
        excelCmd = new OleDbCommand("Select * from [sheet1$]", excelConn);
        excelAdb.SelectCommand = excelCmd;
        excelAdb.Fill(dt);
        excelConn.Close();

        File.Delete(fileName);

        if (CheckColumns(dt) != false)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Date"].ToString().Trim()) && !string.IsNullOrEmpty(dt.Rows[i]["EmpCode"].ToString().Trim()))
                    {
                        LeaveEntity objLeaveEnt = new LeaveEntity();
                        objLeaveEnt.EmployeeCode = dt.Rows[i]["EmpCode"].ToString().Trim();
                        objLeaveEnt.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString().Trim());
                        objLeaveEnt.Day = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Day"].ToString().Trim()) ? "1" : dt.Rows[i]["Day"].ToString().Trim());
                        objLeaveEnt.Half = objLeaveEnt.Day == 1 ? true : false;
                        objLeaveEnt.CreatedBy = Session["empcode"].ToString();

                        string result = LeaveBAL.UploadCompOffDetails(objLeaveEnt);
                    }
                }

                divMessage.InnerHtml = "Record uploaded successfully";
                divMessage.Style["color"] = "green";
            }
            catch (Exception ex)
            {
                divMessage.InnerHtml = "Excel file is not in correct format";
                divMessage.Style["color"] = "red";
            }
            finally
            {

            }
        }

    }

    protected bool CheckColumns(DataTable dt)
    {
        bool status = true;

        int dtColumnCount = dt.Columns.Count;

        if (dtColumnCount == 4)
        {
            for (int i = 0; i < dtColumnCount; i++)
            {
                switch (i)
                {
                    case 0:
                        if (dt.Columns[i].ToString().Trim() != "Sno")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 1:
                        if (dt.Columns[i].ToString().Trim() != "EmpCode")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 2:
                        if (dt.Columns[i].ToString().Trim() != "Date")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 3:
                        if (dt.Columns[i].ToString().Trim() != "Day")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                }
            }
        }
        else
        {
            divMessage.InnerHtml = "Excel file is not in correct format";
            divMessage.Style["color"] = "red";
            status = false;
        }

        return status;
    }

    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        ExcelUpload();
    }

}
