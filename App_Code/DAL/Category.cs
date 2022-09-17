using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Category
/// </summary>
/// 
namespace DAL
{
    public class Category
    {
        public Category()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getCategoryList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Category";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteCategoryId(string CategoryId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Category where CategoryId = '" + CategoryId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getCategoryByCategoryId(int CategoryId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Category where CategoryId = '" + CategoryId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveCategory(int CategoryId, string CategoryName, string CategoryDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveCategory";
                objCmd.Parameters.AddWithValue("@CategoryIdout", CategoryId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                objCmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                objCmd.Parameters.AddWithValue("@CategoryDescription", CategoryDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@CategoryIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
