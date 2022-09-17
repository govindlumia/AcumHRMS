using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemGroup
/// </summary>
/// 
namespace DAL
{
    public class ItemGroup
    {
        public ItemGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getItemGroupList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_itemgroupdetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveItemGroup(int ItemGroupId, String ItemGroupName, String ItemGroupDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveItemGroup";
                objCmd.Parameters.AddWithValue("@itemgroupidout", ItemGroupId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@itemgroupid", ItemGroupId);
                objCmd.Parameters.AddWithValue("@itemgroupname", ItemGroupName);
                objCmd.Parameters.AddWithValue("@itemgroupdescription", ItemGroupDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@itemgroupidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteItemGroupId(string ItemGrouptid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_product_itemgroupdetails where itemgroupid = '" + ItemGrouptid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getItemGroupByItemGroupId(int ItemGrouptid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_itemgroupdetails where itemgroupid = '" + ItemGrouptid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

       
    }
}
