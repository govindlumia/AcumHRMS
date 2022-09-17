using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
 namespace DAL
 {
     public class Meeting
     {
         public Meeting()
         {
             //
             // TODO: Add constructor logic here
             //
         }

         public static DataTable getmeetingOppId(int OppId)
         {
             DataTable oData = new DataTable();
             SqlCommand objCmd = new SqlCommand();
             try
             {
                 objCmd.CommandText = "Select * from tbl_intranet_Meeting where OppId = '" + OppId + "'";
                 oData = SFA.DataConnect.GetDataTable(objCmd);
             }
             catch
             {

             }
             return oData;
         }

         public static DataTable getMeetingByMeetingId(int MeetingId)
         {
             DataTable oData = new DataTable();
             SqlCommand objCmd = new SqlCommand();
             try
             {
                 objCmd.CommandText = "Select * from tbl_intranet_Meeting where MeetingId = '" + MeetingId + "'";
                 oData = SFA.DataConnect.GetDataTable(objCmd);
             }
             catch
             {

             }
             return oData;
         }

         public static int deleteMeetingId(string MeetingId)
         {
             SqlCommand objCmd = new SqlCommand();
             try
             {
                 objCmd.CommandText = "Delete from tbl_intranet_Meeting where MeetingId = '" + MeetingId + "'";
                 return SFA.DataConnect.ExecuteSQLQuery(objCmd);
             }
             catch
             {

             }
             return 0;
         }

         public static int saveMeeting(int MeetingId, DateTime MeetingDate, string MeetingType, string ContactPerson, string Status, string Description, string NextActionPlan, string MinutesMeeting, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, int  OppId)
         {
             DataTable oData = new DataTable();
             SqlCommand objCmd = new SqlCommand();
             try
             {
                 objCmd.CommandType = CommandType.StoredProcedure;
                 objCmd.CommandText = "SFA_usp_SaveMeeting";
                 objCmd.Parameters.AddWithValue("@meetingIdout", MeetingId).Direction = ParameterDirection.InputOutput;
                 objCmd.Parameters.AddWithValue("@MeetingId", MeetingId);

                 if (MeetingDate == null || MeetingDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                 {
                     objCmd.Parameters.AddWithValue("@MeetingDate", DBNull.Value);
                 }
                 else
                 {
                     objCmd.Parameters.AddWithValue("@MeetingDate", MeetingDate);
                 }

                 objCmd.Parameters.AddWithValue("@MeetingType", MeetingType);
                 objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                 objCmd.Parameters.AddWithValue("@Status", Status);
                 objCmd.Parameters.AddWithValue("@Description", Description);
                 objCmd.Parameters.AddWithValue("@NextActionPlan", NextActionPlan);
                 objCmd.Parameters.AddWithValue("@MinutesMeeting", MinutesMeeting);
                 objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                 objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                 objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                 objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                 objCmd.Parameters.AddWithValue("@OppId", OppId);

                 SFA.DataConnect.ExecuteSQLQuery(objCmd);
                 return Convert.ToInt32(objCmd.Parameters["@meetingIdout"].Value.ToString());
             }
             catch (Exception ex)
             {

             }
             return 0;
         }
     }
}
