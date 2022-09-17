using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OwnerShipDetail
/// </summary>
/// 
namespace DAL
{

    public class OwnerShipDetail
    {
        public static DataTable getOwnerShipDetailByOppId(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * From dbo.tbl_internate_OwnerShipDetail where OppId = '" + OppId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch 
            { 
            
            }
            return oData;
        }

        public static DataTable getOwnerShipDetailByOwnerShipId(int OwnerShipId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * From dbo.tbl_internate_OwnerShipDetail where OwnerShipId = '" + OwnerShipId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch

            { 
            
            }
            return oData;
        }

        public static int saveownershipdetails(int OwnerShipId, string OwnerShipName, DateTime OwnerShipFromDate, DateTime OwnerShipToDate, int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOwnerShipDetail";
                objCmd.Parameters.AddWithValue("@OwnerShipIdOut", OwnerShipId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OwnerShipId", OwnerShipId);
                objCmd.Parameters.AddWithValue("@OwnerShipName", OwnerShipName);
                if (OwnerShipFromDate == null || OwnerShipFromDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@OwnerShipFromDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@OwnerShipFromDate", OwnerShipFromDate);
                }
                if (OwnerShipToDate == null || OwnerShipToDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("OwnerShipToDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("OwnerShipToDate", OwnerShipToDate);
                }
                
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@OwnerShipIdOut"].Value.ToString());

            }
            catch (Exception ex)
            { 
            
            }
            return 0;

        }
       
    }
}