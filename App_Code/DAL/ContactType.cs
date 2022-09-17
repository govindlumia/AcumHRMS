using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ContactType
/// </summary>
/// 
namespace DAL
{
    public class ContactType
    {
        public ContactType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getContactTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Contact_ContactType";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int deleteContactTypeId(string ContactTypeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Contact_ContactType where ContactTypeId = '" + ContactTypeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getContactTypeByContactTypeId(int ContactTypeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Contact_ContactType where ContactTypeId = '" + ContactTypeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveContactType(int ContactTypeId, String ContactTypeName, String ContactTypeDetail, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveContactType";
                objCmd.Parameters.AddWithValue("@ContactTypeIdout", ContactTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@ContactTypeId", ContactTypeId);
                objCmd.Parameters.AddWithValue("@ContactTypeName", ContactTypeName);
                objCmd.Parameters.AddWithValue("@ContactTypeDetail", ContactTypeDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@ContactTypeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

    }
}
