using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Model
/// </summary>
/// 
namespace DAL
{
    public class Model
    {
        public Model()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getModelList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_modeldetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static int deleteModelId(string modelid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_product_modeldetails where modelid = '" + modelid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getModelByModelId(int modelid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_modeldetails where modelid = '" + modelid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        // get type and group details in  model details list 


        public static DataTable getModelByGroupModelId(string modelid)

        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_modeldetails where modelid = '" + modelid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static DataTable getItemtypeModelList(string itemgroupname)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ItemgroupTypedetails where itemgroupname = '" + itemgroupname + "'";// View_ProductItemTypeModelDetail"; 
                //objCmd.CommandText = "select * from tbl_intranet_product_itemtypedetails where itemgroupname = '" + itemgroupname + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static DataTable getModeItemlList(string itemtypename)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_modeldetails where itemtypename = '" + itemtypename + "'";// View_ProductItemTypeModelDetail"; 
                //objCmd.CommandText = "select * from tbl_intranet_product_itemtypedetails where itemgroupname = '" + itemgroupname + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }


        //public static DataTable getItemtypeModelList1(int itemgroupname)
        //{
        //    DataTable oData = new DataTable();
        //    SqlCommand objCmd = new SqlCommand();
        //    try
        //    {
        //        objCmd.CommandText = "Select * from View_Product_ItemgroupTypedetails where itemgroupname = '" + itemgroupname + "'";// View_ProductItemTypeModelDetail"; 
        //        //objCmd.CommandText = "select * from tbl_intranet_product_itemtypedetails where itemgroupname = '" + itemgroupname + "'";
        //        oData = SFA.DataConnect.GetDataTable(objCmd);
        //    }
        //    catch
        //    {

        //    }
        //    return oData;

        //}

        public static DataTable getItemtypeModelViewList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                //objCmd.CommandText = "Select itemgroupname,itemtypename from View_Product_ItemgroupTypedetails where itemgroupid = '" + itemgroupid + "'";

                objCmd.CommandText = "Select * from View_Product_ModelDetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }



        public static int saveModel(int modelid, string itemgroupname, string itemtypename, String modelname, String modeldescription, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveModel";
                objCmd.Parameters.AddWithValue("@modelidout", modelid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@modelid", modelid);
                objCmd.Parameters.AddWithValue("@itemgroupname", itemgroupname);
                objCmd.Parameters.AddWithValue("@itemtypename", itemtypename);
                objCmd.Parameters.AddWithValue("@modelname", modelname);
                objCmd.Parameters.AddWithValue("@modeldescription", modeldescription);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@modelidout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
