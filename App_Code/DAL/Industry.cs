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
    public class Industry
    {
        public Industry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getIndustryList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_IndustryType";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteIndustryId(string IndustryId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Organization_IndustryType where IndustryId = '" + IndustryId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getIndustryByIndustryId(int IndustryId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_IndustryType where IndustryId = '" + IndustryId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveIndustry(int IndustryId, String IndustryName, String IndustryDetail, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveIndustry";
                objCmd.Parameters.AddWithValue("@IndustryIdout", IndustryId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@IndustryId", IndustryId);
                objCmd.Parameters.AddWithValue("@IndustryName", IndustryName);
                objCmd.Parameters.AddWithValue("@IndustryDetail", IndustryDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@IndustryIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
