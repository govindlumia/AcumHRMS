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
    public class ItemCategory
    {
        public ItemCategory()
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
    }
}
