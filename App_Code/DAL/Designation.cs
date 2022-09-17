using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Designation
/// </summary>
/// 
namespace DAL
{
    public class Designation
    {
        public Designation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getDesignationList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_employee_designationDetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getEmplyeeByDesignation(string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_employee_jobDetails where empcode = '" + empcode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getAllEmplyeeByUserRole()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_UserRole_Detail";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveUserRole(int roleId, string empcode, int desigId, string supervisor, string altSupervisor, string right, string createdBy, DateTime createdDate, string updatedBy, DateTime updateddate)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_saveUserRole";
                objCmd.Parameters.AddWithValue("@roleIdeout", roleId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@roleId", roleId);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@desigId", desigId);
                objCmd.Parameters.AddWithValue("@supervisorId", supervisor);
                objCmd.Parameters.AddWithValue("@altSupervisorId", altSupervisor);
                objCmd.Parameters.AddWithValue("@rightSupervisor", right);
                objCmd.Parameters.AddWithValue("@createdBy", createdBy);
                objCmd.Parameters.AddWithValue("@createdDate", createdDate);
                objCmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                objCmd.Parameters.AddWithValue("@updatedDate", updateddate);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@roleIdeout"].Value.ToString());

            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getUserRoleByRoleId(int roleId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_UserRole_Detail where roleId = '" + roleId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getUserRoleDetailByDesignationid(int designationid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_UserRole_Detail where designationid = '" + designationid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getUserRoleByEmpCode(string empCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_employee_RoleSFA where empcode = '" + empCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteUserProfile(string roleId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_employee_RoleSFA where RoleId = '" + roleId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getEmployeeByRole(string empCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                if (HttpContext.Current.Session["role"].ToString() == "3")
                {
                    objCmd.CommandText = "Select * from View_UserRole_Detail order by empfullname";
                }
                else
                    objCmd.CommandText = "Select * from View_UserRole_Detail where SupervisorId = '" + empCode + "'  order by empfullname";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        // for organization emp role
        public static DataTable getEmployeeByRoleOrg(string empCode, string orgEmp)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_UserRole_Detail where SupervisorId = '" + empCode + "' or empcode = '" + orgEmp + "' ";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEmployeeByAltSuper(string empCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_UserRole_Detail where AltSupervisorId = '" + empCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

    }
}
