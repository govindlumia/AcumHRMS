using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SalesType
/// </summary>
/// 
namespace DAL
{
    public class SalesType
    {

        public SalesType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getSalesTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_SalesType order by salestypename asc";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteSalesId(string SalesTypeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_opportunity_SalesType where SalesTypeId = '" + SalesTypeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getSalesBySalesId(int SalesTypeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_SalesType where SalesTypeId = '" + SalesTypeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveSales(int SalesTypeId, String SalesTypeName, String SalesTypeDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveSalesType";
                objCmd.Parameters.AddWithValue("@SalesTypeIdout", SalesTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@SalesTypeId", SalesTypeId);
                objCmd.Parameters.AddWithValue("@SalesTypeName", SalesTypeName);
                objCmd.Parameters.AddWithValue("@SalesTypeDescription", SalesTypeDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@SalesTypeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }




    }
}
