using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemCategory
/// </summary>
/// 
namespace DAL
{
    public class Department
    {
        public Department()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getDepartmentList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_DeprtmentBranchDetail ";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getDepartmentListByBranchId(int BranchId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_departmentdetails where branchid=" + BranchId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteDepartmentId(string departmentid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_internate_departmentdetails where departmentid = '" + departmentid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getDepartmentByOrg(string orgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_DeprtmentBranchDetail where company_id = '" + orgCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getDepartmentByDepartmentId(int departmentid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_departmentdetails where departmentid = '" + departmentid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveDepartment(int departmentid, int branchid, string department_name, string department_code, System.Data.SqlTypes.SqlDateTime estt_date, string status, bool flag, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveDepartmentDetail";
                objCmd.Parameters.AddWithValue("@departmentidout", departmentid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@departmentid", departmentid);
                objCmd.Parameters.AddWithValue("@branchid", branchid);
                objCmd.Parameters.AddWithValue("@department_name", department_name);
                objCmd.Parameters.AddWithValue("@department_code", department_code);
                objCmd.Parameters.AddWithValue("@estt_date", estt_date);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@flag", flag);

                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@departmentidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

    }
}
