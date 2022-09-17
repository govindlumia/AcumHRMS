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
    public class CategoryItem
    {
        public CategoryItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getItemCategoryList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intrenet_product_itemcategorydetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int deleteItemCategoryId(string itemcategoryid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intrenet_product_itemcategorydetails where itemcategoryid = '" + itemcategoryid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getItemCategoryByCategoryId(int itemcategoryid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intrenet_product_itemcategorydetails where itemcategoryid = '" + itemcategoryid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int saveItemCategory(int itemcategoryid, String itemcategoryname, String itemcategorydescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveItemCategory";
                objCmd.Parameters.AddWithValue("@itemcategoryidout", itemcategoryid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@itemcategoryid", itemcategoryid);
                objCmd.Parameters.AddWithValue("@itemcategoryname", itemcategoryname);
                objCmd.Parameters.AddWithValue("@itemcategorydescription", itemcategorydescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@itemcategoryidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

    }

}
