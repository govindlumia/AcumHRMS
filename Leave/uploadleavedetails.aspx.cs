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

public partial class leave_uploadleavedetails : System.Web.UI.Page
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["PolicyType/EmployeeType"].ToString().Trim()) && !string.IsNullOrEmpty(dt.Rows[i]["EmpCode"].ToString().Trim()))
                {
                    LeaveEntity objLeaveEnt = new LeaveEntity();
                    objLeaveEnt.PolicyType = dt.Rows[i]["PolicyType/EmployeeType"].ToString().Trim();
                    objLeaveEnt.EmployeeCode = dt.Rows[i]["EmpCode"].ToString().Trim();
                    objLeaveEnt.PL_Entitled = string.IsNullOrEmpty(dt.Rows[i]["PL_Entitled"].ToString().Trim()) ? "0" : dt.Rows[i]["PL_Entitled"].ToString().Trim();
                    objLeaveEnt.PL_Used = string.IsNullOrEmpty(dt.Rows[i]["PL_Used"].ToString().Trim()) ? "0" : dt.Rows[i]["PL_Used"].ToString().Trim();
                    objLeaveEnt.CL_Entitled = string.IsNullOrEmpty(dt.Rows[i]["CL_Entitled"].ToString().Trim()) ? "0" : dt.Rows[i]["CL_Entitled"].ToString().Trim();
                    objLeaveEnt.CL_Used = string.IsNullOrEmpty(dt.Rows[i]["CL_Used"].ToString().Trim()) ? "0" : dt.Rows[i]["CL_Used"].ToString().Trim();
                    objLeaveEnt.SL_Entitled = string.IsNullOrEmpty(dt.Rows[i]["SL_Entitled"].ToString().Trim()) ? "0" : dt.Rows[i]["SL_Entitled"].ToString().Trim();
                    objLeaveEnt.SL_Used = string.IsNullOrEmpty(dt.Rows[i]["SL_Used"].ToString().Trim()) ? "0" : dt.Rows[i]["SL_Used"].ToString().Trim();
                    objLeaveEnt.ML_Entitled = string.IsNullOrEmpty(dt.Rows[i]["ML_Entitled"].ToString().Trim()) ? "0" : dt.Rows[i]["ML_Entitled"].ToString().Trim();
                    objLeaveEnt.ML_Used = string.IsNullOrEmpty(dt.Rows[i]["ML_Used"].ToString().Trim()) ? "0" : dt.Rows[i]["ML_Used"].ToString().Trim();
                    objLeaveEnt.CreatedBy = Session["empcode"].ToString();

                    string result = LeaveBAL.UploadLeaveDetails(objLeaveEnt);
                }
            }

            divMessage.InnerHtml = "Record uploaded successfully";
            divMessage.Style["color"] = "green";
        }

    }

    protected bool CheckColumns(DataTable dt)
    {
        bool status = true;

        int dtColumnCount = dt.Columns.Count;

        if (dtColumnCount == 11)
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
                        if (dt.Columns[i].ToString().Trim() != "PolicyType/EmployeeType")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 2:
                        if (dt.Columns[i].ToString().Trim() != "EmpCode")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 3:
                        if (dt.Columns[i].ToString().Trim() != "PL_Entitled")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 4:
                        if (dt.Columns[i].ToString().Trim() != "PL_Used")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 5:
                        if (dt.Columns[i].ToString().Trim() != "CL_Entitled")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 6:
                        if (dt.Columns[i].ToString().Trim() != "CL_Used")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 7:
                        if (dt.Columns[i].ToString().Trim() != "SL_Entitled")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 8:
                        if (dt.Columns[i].ToString().Trim() != "SL_Used")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 9:
                        if (dt.Columns[i].ToString().Trim() != "ML_Entitled")
                        {
                            divMessage.InnerHtml = "Excel file is not in correct format";
                            divMessage.Style["color"] = "red";
                            status = false;
                            break;
                        }
                        break;
                    case 10:
                        if (dt.Columns[i].ToString().Trim() != "ML_Used")
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
