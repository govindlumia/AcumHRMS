using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserProfile
/// </summary>
/// 
namespace DAL
{
    public class UserProfile
    {
        public UserProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static DataTable getUserProfileByEmpCode(string EmpCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Enquiry_UserProfile where empcode = '" + EmpCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEnquiryUserProfileList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Enquiry_UserProfileDetail";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int deleteEnquiryUserProfileId(string UserProfileId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from  tbl_intranet_Enquiry_UserProfile where UserProfileId = '" + UserProfileId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getEnquiryUserProfileByUserProfileId(int UserProfileId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Enquiry_UserProfile where UserProfileId = '" + UserProfileId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int saveEnquiryUserProfile(int UserProfileId, String UserProfileName, String UserProfileDetail, string UpdatedBy, DateTime UpdatedDate, string EmpCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveEnquiryUserProfile";
                objCmd.Parameters.AddWithValue("@EnquiryUserProfileout", UserProfileId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@UserProfileId", UserProfileId);
                objCmd.Parameters.AddWithValue("@UserProfileName", UserProfileName);
                objCmd.Parameters.AddWithValue("@UserProfileDetail", UserProfileDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@EmpCode", EmpCode);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@EnquiryUserProfileout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
