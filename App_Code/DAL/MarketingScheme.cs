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
    public class Marketing
    {
        public Marketing()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getMarketingTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_marketingscheme";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static int deleteMarketingId(string MarketingSchemeId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_opportunity_marketingscheme where MarketingSchemeId = '" + MarketingSchemeId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getMarketingByMarketingId(int MarketingSchemeId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_opportunity_marketingscheme  where MarketingSchemeId = '" + MarketingSchemeId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveMarketing(int MarketingSchemeId, String MarketingSchemeName, String MarketingSchemeDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveMarketingScheme";
                objCmd.Parameters.AddWithValue("@MarketingSchemeIdout", MarketingSchemeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@MarketingSchemeId", MarketingSchemeId);
                objCmd.Parameters.AddWithValue("@MarketingSchemeName", MarketingSchemeName);
                objCmd.Parameters.AddWithValue("@MarketingSchemeDescription", MarketingSchemeDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@MarketingSchemeIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
