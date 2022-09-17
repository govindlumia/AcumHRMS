using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Brand
/// </summary>
/// 
namespace DAL
{
    public class Brand
    {
        public Brand()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getBrandList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_branddetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteBrandId(string brandid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_product_branddetails where brandid = '" + brandid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getBrandByBrandId(int brandid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_branddetails where brandid = '" + brandid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int saveBrand(int brandid, String brandname, String branddescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveBrand";
                objCmd.Parameters.AddWithValue("@brandidout", brandid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@brandid", brandid);
                objCmd.Parameters.AddWithValue("@brandname", brandname);
                objCmd.Parameters.AddWithValue("@branddescription", branddescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@brandidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
