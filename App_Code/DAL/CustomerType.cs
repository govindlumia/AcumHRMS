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
/// 
namespace DAL
{
    public class CustomerType
    {
        public CustomerType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getCustomerTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_enquries_CustomerType";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }
        public static int deleteCustomerTypeId(string CustomerTypeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_enquries_CustomerType where CustomerTypeId = '" + CustomerTypeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getCustomerTypeByCustomerTypeId(int CustomerTypeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_enquries_CustomerType where CustomerTypeId = '" + CustomerTypeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveCustomerType(int CustomerTypeId, String CustomerTypeName, String CustomerTypeDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveCustomerType";
                objCmd.Parameters.AddWithValue("@CustomerTypeIdout", CustomerTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                objCmd.Parameters.AddWithValue("@CustomerTypeName", CustomerTypeName);
                objCmd.Parameters.AddWithValue("@CustomerTypeDescription", CustomerTypeDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@CustomerTypeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
