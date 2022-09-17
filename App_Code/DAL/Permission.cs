using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserProfile
/// </summary>
/// 
namespace DAL
{
    public class Permission
    {
        public Permission()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static DataTable getOppPermissionByEmpCode(string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_permission where empcode = '" + empcode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getOppPermissionList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Opportunity_Permission";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int deleteOppPermissionId(string PermissionId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from  tbl_intranet_opportunity_permission where PermissionId = '" + PermissionId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getPermissionByPermissionId(int PermissionId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_permission where PermissionId = '" + PermissionId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int saveOpportunityPermission(int PermissionId, String PermissionName, String Comment, string UpdatedBy, DateTime UpdatedDate, string EmpCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOpportunityPermission";
                objCmd.Parameters.AddWithValue("@PermissionIdout", PermissionId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@PermissionId", PermissionId);
                objCmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                objCmd.Parameters.AddWithValue("@Comment", Comment);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@EmpCode", EmpCode);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@PermissionIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
