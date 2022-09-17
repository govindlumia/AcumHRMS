using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ReferredBy
/// </summary>
///
namespace DAL
{ 

    public class ReferredBy
    {
        public static DataTable getReferredByOppId(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_ReferredBy where OppId = '" + OppId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            { 
            
            }
            return oData;
        }
        public static DataTable getreferredByReferredId(int ReferredId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * From tbl_internate_ReferredBy where ReferredId = '" + ReferredId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            { 
            
            }
            return oData;
        }
        public static int saveReferredBy(int ReferredId, int OppId, string ReferredBy, string MobileNo, string Mail, string Description)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveReferredBy";
                objCmd.Parameters.AddWithValue("@ReferredIdOut", ReferredId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@ReferredId", ReferredId);
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                objCmd.Parameters.AddWithValue("@ReferredBy", ReferredBy);
                objCmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                objCmd.Parameters.AddWithValue("@Mail", Mail);
                objCmd.Parameters.AddWithValue("@Description", Description);
                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@ReferredIdOut"].Value.ToString());
            }
            catch (Exception ex)
            { 
            
            }
            return 0;
        }
        public static int deleteReferredBy(string ReferredId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_internate_ReferredBy where ReferredId = '" + ReferredId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            { 
            }
            return 0;
        }
    }
}