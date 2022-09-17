using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace DAL
{
    public class Employeedetail
    {
        public Employeedetail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getEmployeeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_employee_jobDetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }


        public static DataTable getEmployeeDetailList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_Employee_LoginDetail";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteEmployeeDetailId(string EmpId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_Employee_LoginDetail where EmpId = '" + EmpId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getEmployeeByEmployeeId(string EmpId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_Employee_LoginDetail where EmpId = '" + EmpId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEmployeeByEmailId(string EmailId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_Employee_LoginDetail where EmailId = '" + EmailId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static string saveEmployeeDetail(String Employee, String EmpId, String EmpName, int Role, String EmpPassword, String EmailId, String Phone, String City, String State, String Mobile, String Country, String UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveEmployeeDetail";
                objCmd.Parameters.AddWithValue("@Employee", Employee);
                objCmd.Parameters.AddWithValue("@EmpIdout", EmpId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EmpId", EmpId);
                objCmd.Parameters.AddWithValue("@EmpName", EmpName);
                objCmd.Parameters.AddWithValue("@RoleId", Role);
                objCmd.Parameters.AddWithValue("@EmpPassword", EmpPassword);
                objCmd.Parameters.AddWithValue("@Phone", EmpPassword);
                objCmd.Parameters.AddWithValue("@Mobile", EmpPassword);
                objCmd.Parameters.AddWithValue("@City", EmpPassword);
                objCmd.Parameters.AddWithValue("@State", EmpPassword);
                objCmd.Parameters.AddWithValue("@Country", Country);
                objCmd.Parameters.AddWithValue("@EmailId", EmailId);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return objCmd.Parameters["@EmpIdout"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            return "0";
        }
        public static string Getpayheadtype(int payheadid)
        {

            string strquery = string.Empty;
            DataSet ds = new DataSet();
            strquery = "select   CASE WHEN payhead_type =  0 THEN 'Earnings' ELSE 'Deductions' END as Type from tbl_payroll_payhead where id= " + payheadid + "";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strquery);
            return ds.Tables[0].Rows[0]["Type"].ToString();

        }
       
    }
}
