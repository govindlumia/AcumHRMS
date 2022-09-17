using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AccountType
/// </summary>
/// 
namespace DAL
{
    public class AccountType
    {
        public AccountType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getAccountTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_AccountType";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteAccountId(string AccountTypeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Organization_AccountType where AccountTypeId = '" + AccountTypeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getAccountByAccountId(int AccountTypeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_AccountType where AccountTypeId = '" + AccountTypeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveAccount(int AccountTypeId, String AccountTypeName, String AccountTypeDetail, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveAccountType";
                objCmd.Parameters.AddWithValue("@AccountTypeIdout", AccountTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@AccountTypeId", AccountTypeId);
                objCmd.Parameters.AddWithValue("@AccountTypeName", AccountTypeName);
                objCmd.Parameters.AddWithValue("@AccountTypeDetail", AccountTypeDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@AccountTypeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }


}
