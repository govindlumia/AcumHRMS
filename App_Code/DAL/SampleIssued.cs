using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SampleIssued
/// </summary>
namespace DAL
{
    public class SampleIssued
    {

        public static DataTable getAllSampleByOppId(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_SampleIssued where OppId = '" + OppId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getSampleBySampleId(int SampleId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_SampleIssued where SampleId = '" + SampleId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static int saveSample(int SampleId, int OppId, string ItemCode, string Quantity, DateTime IssueDate, string IssuedTo, string ReceivedFrom, string ReceivedThrough, string SampleStatus, string ReturnedBy, string UpdateBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveSampleIssued";
                objCmd.Parameters.AddWithValue("@SampleIdout", SampleId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@SampleId", SampleId);
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                objCmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                objCmd.Parameters.AddWithValue("@Quantity", Quantity);
                objCmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                objCmd.Parameters.AddWithValue("@IssuedTo", IssuedTo);
                objCmd.Parameters.AddWithValue("@ReceivedFrom", ReceivedFrom);
                objCmd.Parameters.AddWithValue("@ReceivedThrough", ReceivedThrough);
                objCmd.Parameters.AddWithValue("@SampleStatus", SampleStatus);
                objCmd.Parameters.AddWithValue("@ReturnedBy", ReturnedBy);

                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdateBy);
                objCmd.Parameters.AddWithValue("@UpdateDate", UpdatedDate);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@SampleIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteSampleId(string SampleId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_SampleIssued where SampleId = '" + SampleId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

    }
}