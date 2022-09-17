using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Employee_EmpBulkUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string empcode { get; set; }
    protected void btnAddDoc_Click(object sender, EventArgs e)
    {
        //objInquiryModel = new InquiryModel();
        //InquiryBAL objInquiryBAL = new InquiryBAL();
        EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();
        GenerateEmpCode();

        string filePath = string.Empty;

        if (flUpload.HasFile)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/upload/ImportEmployee/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string extension = "";
            //filePath = path + Path.GetFileName(postedFile.FileName);
            // extension = Path.GetExtension(postedFile.FileName);
            //postedFile.SaveAs(filePath);
            //foreach (var file in flUpload.)
            //{
            //    if (file != null)
            //    {
            //        filePath = path + Path.GetFileName(file.FileName);
            //        extension = Path.GetExtension(file.FileName);
            //        file.SaveAs(filePath);

            //    }
            //}
            string FileName = Path.GetFileName(flUpload.PostedFile.FileName);

            string Extension = Path.GetExtension(flUpload.PostedFile.FileName);

            string FolderPath = "/upload/ImportEmployee/";



            string FilePath = Server.MapPath(FolderPath + FileName);
            filePath = FilePath;
            flUpload.SaveAs(FilePath);


            string conString = string.Empty;
            switch (Extension)
            {
                case ".xls": //Excel 97-03.
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 and above.
                    conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }

            DataTable dt = new DataTable();
            conString = string.Format(conString, filePath);
            string[] AllsheetName = new string[20];
            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;

                        //Get the name of First Sheet.
                        connExcel.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                        {
                            //string sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                            AllsheetName[i] = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + AllsheetName[i] + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);

                            DataRow[] TotalRows = dt.Select();
                            int numberOfCalls;
                            string result;

                            foreach (DataRow dr in TotalRows)
                            {
                                // Get value of Calls here
                                result = dr["empcode"].ToString();

                                // Optionally, you can check the result of the attempted try parse here
                                // and do something if you wish
                                if (result != "")
                                {
                                    int id = empBusiness.CheckDuplicateInquiry(result);
                                    if (id == 1)
                                    {
                                        //return Content("Records are duplicat, Please check your Excel sheet !");
                                    }
                                    else
                                    {
                                        //TempData["message"] = " !";
                                    }

                                }
                                else
                                {
                                    // Try parse to 32-bit integer failed

                                }
                            }
                            connExcel.Close();
                        
                        }

                    }
                }
            }

            for (int j = 0; j < AllsheetName.Length; j++)
            {


                string conString2 = ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString;
                string CommandText = "sp_ImportEmployeeFromExcel";
                SqlConnection con = new SqlConnection(conString2);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = CommandText;

                cmd.Parameters.Add("@SheetName", SqlDbType.VarChar).Value = AllsheetName[j];

                cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FolderPath + FileName;

                cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "YES";
                if (AllsheetName[j] == "tbl_employee_job$")
                {
                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "dbo.tbl_intranet_employee_jobDetails";
                }

                else if (AllsheetName[j] == "tbl_intranet_personal$")
                {
                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "dbo.tbl_intranet_employee_personalDetails";
                }
                cmd.Connection = con;
                try
                {
                    con.Open();
                    object count = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            //using (SqlConnection con = new SqlConnection(conString))
            //{
            //    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //    {
            //        //Set the database table name.
            //        sqlBulkCopy.DestinationTableName = "dbo.tbl_intranet_employee_jobDetails";

            //        //[OPTIONAL]: Map the Excel columns with that of the database table
            //        sqlBulkCopy.ColumnMappings.Add("empcode", "empcode");
            //        sqlBulkCopy.ColumnMappings.Add("card_no", "card_no");
            //        sqlBulkCopy.ColumnMappings.Add("emp_gender", "emp_gender");
            //        sqlBulkCopy.ColumnMappings.Add("emp_fname", "emp_fname");
            //        sqlBulkCopy.ColumnMappings.Add("emp_l_name", "emp_l_name");
            //        sqlBulkCopy.ColumnMappings.Add("emp_status", "emp_status");
            //        sqlBulkCopy.ColumnMappings.Add("degination_id", "degination_id");
            //        sqlBulkCopy.ColumnMappings.Add("Job_type", "Job_type");
            //        sqlBulkCopy.ColumnMappings.Add("category", "category");
            //        sqlBulkCopy.ColumnMappings.Add("emp_doj", "emp_doj");
            //       // sqlBulkCopy.ColumnMappings.Add("salary_cal_from", "salary_cal_from");
            //        //sqlBulkCopy.ColumnMappings.Add("emp_doleaving", "emp_doleaving");
            //        //sqlBulkCopy.ColumnMappings.Add("emp_doreleiving", "emp_doreleiving");
            //        //sqlBulkCopy.ColumnMappings.Add("emp_doreleiving", "emp_doreleiving");


            //        con.Open();
            //        sqlBulkCopy.WriteToServer(dt);
            //        con.Close();
            //    }
            //}


        }
        //else
        //{
        //    return Content("Excel empty!");
        //}

        //return Content("Data Import Successfully!");

    }

    protected void GenerateEmpCode()
    {
        try
        {
            EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
            empcode = empBusiness.GenerateEmpCode(Convert.ToInt32(1));
        }
        catch
        {

        }
    }

    //protected void insert_Log_in_detail()
    //{
    //    int saltSize = 5;
    //    string salt = CreateSalt(saltSize);
    //    string passwordHash = CreatePasswordHash("password", salt);

    //    EmployeeCreateBusiness empBusiness = new EmployeeCreateBusiness();
    //    LoginENT userentity = new LoginENT();


    //    userentity.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
    //    userentity.Login_id = txtpwd.Text.Trim().ToString();
    //    userentity.Empcode = txtempcode.Text.Trim().ToString();
    //    userentity.Pwd = passwordHash.Trim().ToString();
    //    userentity.Role = Convert.ToInt32(drprole.SelectedValue);
    //    userentity.EmailId = txt_email.Text.Trim().ToString();
    //    userentity.EmployeeCode = Session["EmpCode"].ToString();

    //    int result = empBusiness.CreateLogin(userentity);


    //}

    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }
}