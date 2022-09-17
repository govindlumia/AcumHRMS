using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemType
/// </summary>
/// 
namespace DAL
{
    public class ItemType
    {
        public ItemType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getItemTypeList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_itemtypedetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }


        public static int saveItemType(int ItemTypeId, string Itemtype, String ItemTypeName, String ItemTypeDescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveItemType";
                objCmd.Parameters.AddWithValue("@itemtypeidout", ItemTypeId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@itemtypeid", ItemTypeId);
                objCmd.Parameters.AddWithValue("@itemgroupname", Itemtype);
                objCmd.Parameters.AddWithValue("@itemtypename", ItemTypeName);
                objCmd.Parameters.AddWithValue("@itemtypedescription", ItemTypeDescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@itemtypeidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteItemTypeId(string ItemTypeid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_product_itemtypedetails where itemtypeid = '" + ItemTypeid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getItemTypeByItemTypeId(int ItemTypeid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_itemtypedetails where itemtypeid = '" + ItemTypeid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getItemGroupByTypeDetails()  //int ItemGrouptid
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ItemgroupTypedetails";// where itemgroupid = '" + ItemGrouptid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
    }
}
