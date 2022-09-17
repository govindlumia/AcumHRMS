using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Event
/// </summary>
/// 
namespace DAL
{
    public class Event
    {
        public Event()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable geEventList(string OrgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Event where OrgId = '" + OrgCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static DataTable getEventByEventId(int EventId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Event where EventId = '" + EventId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static int saveEvent(int EventId, string EventTitle, string EventDescription, DateTime EventDate, string Location, string RelatedTo, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, string OrgId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveEvent";
                objCmd.Parameters.AddWithValue("@EventIdout", EventId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EventId", EventId);
                objCmd.Parameters.AddWithValue("@EventTitle", EventTitle);
                objCmd.Parameters.AddWithValue("@EventDescription", EventDescription);

                if (EventDate == null || EventDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@EventDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@EventDate", EventDate);
                }

                objCmd.Parameters.AddWithValue("@Location", Location);
                objCmd.Parameters.AddWithValue("@RelatedTo", RelatedTo);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@OrgId", OrgId);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@EventIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteEventById(string EventId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Event where EventId = '" + EventId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

    }
}
