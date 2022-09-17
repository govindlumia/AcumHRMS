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
/// Summary description for Appointment
/// </summary>
/// 

namespace DAL
{
    public class Appointment
    {
        public Appointment()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getAppointmentOrgId(string OrgId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Appointment where OrgId = '" + OrgId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static DataTable getAppointmentByAppointmentId(int AppointmentId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Appointment where AppointmentId = '" + AppointmentId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveAppointment(int AppointmentId, string Subject, DateTime StartDate, DateTime EndDate, string Location, string Status, DateTime CreatedDate, string CreatedBy, DateTime UpdatedDate, string UpdatedBy, string orgId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveAppointment";
                objCmd.Parameters.AddWithValue("@AppointmentIdout", AppointmentId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@AppointmentId", AppointmentId);
                objCmd.Parameters.AddWithValue("@Subject", Subject);               

                if (StartDate == null || StartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@StartDate", StartDate);
                }

                if (EndDate == null || EndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@EndDate", EndDate);
                }

                objCmd.Parameters.AddWithValue("@Location", Location);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@OrgId", orgId);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@AppointmentIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteAppointmentid(string AppointmenttId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Appointment where AppointmentId = '" + AppointmenttId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

    }
}
