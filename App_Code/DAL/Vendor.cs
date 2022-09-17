using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Vendor
/// </summary>
/// 
namespace DAL
{
    public class Vendor
    {
        public Vendor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getVendorList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internet_product_vendor";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }
    }
}
