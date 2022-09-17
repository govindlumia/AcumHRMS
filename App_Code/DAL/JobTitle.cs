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
    public class JobTitle
    {
        public JobTitle()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getJobTitleList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Contact_JobTitle order by JobTitleName";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteJobTitleId(string JobTitleId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Contact_JobTitle where JobTitleId = '" + JobTitleId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getJobTitleByJobTitleId(int JobTitleId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Contact_JobTitle where JobTitleId = '" + JobTitleId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveJobTitle(int JobTitleId, String JobTitleName, String JobTitleDetail, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveJobTitle";
                objCmd.Parameters.AddWithValue("@JobTitleIdout", JobTitleId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@JobTitleId", JobTitleId);
                objCmd.Parameters.AddWithValue("@JobTitleName", JobTitleName);
                objCmd.Parameters.AddWithValue("@JobTitleDetail", JobTitleDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@JobTitleIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

    }
}
