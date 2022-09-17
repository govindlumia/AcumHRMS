using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemCategory
/// </summary>
/// 
namespace DAL
{
    public class CompanyType
    {
        public CompanyType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getCompanyTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_CompanyType";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteCompanyId(string CompanyTypeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Organization_CompanyType where CompanyTypeId = '" + CompanyTypeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getCompanyByCompanyId(int CompanyTypeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_CompanyType where CompanyTypeId = '" + CompanyTypeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveCompany(int CompanyTypeId, String CompanyTypeName, String CompanyTypeDetail, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveCompanyType";
                objCmd.Parameters.AddWithValue("@CompanyTypeIdout", CompanyTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@CompanyTypeId", CompanyTypeId);
                objCmd.Parameters.AddWithValue("@CompanyTypeName", CompanyTypeName);
                objCmd.Parameters.AddWithValue("@CompanyTypeDetail", CompanyTypeDetail);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@CompanyTypeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }



    }
}
