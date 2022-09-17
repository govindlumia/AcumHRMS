using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Measurement
/// </summary>
/// 
namespace DAL
{
    public class Measurement
    {
        public Measurement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getMeasurementList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_measurement";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int saveMeasurement(int measurementid, String measurement_name, String measurement_description, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveMeasurement";
                objCmd.Parameters.AddWithValue("@measurementidout", measurementid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@measurementid", measurementid);
                objCmd.Parameters.AddWithValue("@measurement_name", measurement_name);
                objCmd.Parameters.AddWithValue("@measurement_description", measurement_description);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@measurementidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteMeasurementId(string measurementid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_product_measurement where measurementid = '" + measurementid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getMeasurementByMeasurementId(int measurementid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_measurement where measurementid = '" + measurementid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
    }
}
