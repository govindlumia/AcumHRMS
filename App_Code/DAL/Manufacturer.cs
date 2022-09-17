using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Manufacturer
/// </summary>
/// 
namespace DAL
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getManufacturerList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_inrtanet_product_manufacturerdetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }
       
        public static int deleteManufactureId(string manufacturerid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_inrtanet_product_manufacturerdetails where manufacturerid = '" + manufacturerid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getManufactureByManufactureId(int manufacturerid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_inrtanet_product_manufacturerdetails where manufacturerid = '" + manufacturerid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int saveManufacture(int manufacturerid, String manufacturername, String manufacturerdescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_Savemanufacturer";
                objCmd.Parameters.AddWithValue("@manufactureridout", manufacturerid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
                objCmd.Parameters.AddWithValue("@manufacturername", manufacturername);
                objCmd.Parameters.AddWithValue("@manufacturerdescription", manufacturerdescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@manufactureridout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
