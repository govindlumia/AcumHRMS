using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Product
/// </summary>
/// 
namespace DAL
{
    public class Product
    {
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getProductList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_productdetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getSampleProductList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_productdetails where itemcode like 'sample%'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductById(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ProductDetail where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductByName(string ProductName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ProductDetail where itemName= '" + ProductName + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        //public static DataTable getProductByPrice(string ProductName)
        //{
        //    DataTable oData = new DataTable();
        //    SqlCommand objCmd = new SqlCommand();
        //    try
        //    {
        //        objCmd.CommandText = "Select * from View_ProductPricelist where itemname= '" + ProductName + "'";
        //        oData = SFA.DataConnect.GetDataTable(objCmd);
        //    }
        //    catch
        //    {

        //    }
        //    return oData;
        //}

        // get price from pricelist

        public static DataTable getProductByPrice(string ProductName, string mid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ProductPricelist where itemname = '" + ProductName + "' ";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductItemSizeByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_product_itemsize_map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductMeasurementByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_Measurement_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductLikeProductName(string ProName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_product_productdetails where itemname like '" + ProName + "%'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductItemCategoryByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ItemCategory_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductItemGroupByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ItemGroup_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductItemTypeByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ItemType_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductBrandByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_Brand_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductModelByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_Model_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductManufacturerByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_Manufacturer_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductVendorByProduct(string Productid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_Vendor_Map where itemcode= '" + Productid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static string saveProduct(string operation, string itemcode, string itemname, string barcode, string itemdescription, string openingstock, string closingstock, string minimumstock, string updated_by, DateTime updated_date, string itemsize, string UnitOfMeasurementid, string ItemCategoryid, string ItemGroupid, string ItemTypeid, string Brandid, string Modelid, string Vendorid, string ImageName, string packing, string productcategory, string additionalvender,string conversionrate,string secondaryunit) // double costprice, double mrp, double dealerprice,
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveProduct";
                objCmd.Parameters.AddWithValue("@Operation", operation);
                objCmd.Parameters.AddWithValue("@itemcodeout", itemcode).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@itemcode", itemcode);
                objCmd.Parameters.AddWithValue("@itemname", itemname);
                objCmd.Parameters.AddWithValue("@barcode", barcode);
                objCmd.Parameters.AddWithValue("@itemdescription", itemdescription);
                objCmd.Parameters.AddWithValue("@openingstock", openingstock);
                objCmd.Parameters.AddWithValue("@closingstock", closingstock);
                objCmd.Parameters.AddWithValue("@minimumstock", minimumstock);
                //objCmd.Parameters.AddWithValue("@costprice", costprice);
                //objCmd.Parameters.AddWithValue("@mrp", mrp);
                //objCmd.Parameters.AddWithValue("@dealerprice", dealerprice);
                objCmd.Parameters.AddWithValue("@updated_by", updated_by);
                objCmd.Parameters.AddWithValue("@updated_date", updated_date);
                objCmd.Parameters.AddWithValue("@itemsize", itemsize);
                objCmd.Parameters.AddWithValue("@measurementid", UnitOfMeasurementid);
                objCmd.Parameters.AddWithValue("@itemcategoryid", ItemCategoryid);
                objCmd.Parameters.AddWithValue("@itemgroupid", ItemGroupid);
                objCmd.Parameters.AddWithValue("@itemtypeid", ItemTypeid);
                objCmd.Parameters.AddWithValue("@brandid", Brandid);
                objCmd.Parameters.AddWithValue("@modelid", Modelid);
                objCmd.Parameters.AddWithValue("@vendorid", Vendorid);
                objCmd.Parameters.AddWithValue("@imagename", ImageName);
                objCmd.Parameters.AddWithValue("@packing", packing);
                objCmd.Parameters.AddWithValue("@productcategory", productcategory);
                objCmd.Parameters.AddWithValue("@additionalvender", additionalvender);
                objCmd.Parameters.AddWithValue("@conversionrate", conversionrate);
                objCmd.Parameters.AddWithValue("@secondarymeasurementid", secondaryunit);
                
                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return objCmd.Parameters["@itemcodeout"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            return "";
        }


        public static DataTable SearchProductDetails(string strSortField, string strSortDir, int pageSize, int pageNum, string Keywords, string Alphabet, string proCat, int itemgroupid, int itemtypeid, string modelid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchProductDetails";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Keywords", Keywords);
                objCmd.Parameters.AddWithValue("@Alphabet", Alphabet);
                objCmd.Parameters.AddWithValue("@proCat", proCat);
                objCmd.Parameters.AddWithValue("@itemgroupid", itemgroupid);
                objCmd.Parameters.AddWithValue("@itemtypeid", itemtypeid);
                objCmd.Parameters.AddWithValue("@modelid", modelid);


                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteProductById(string Productid, string ProductList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteProduct";
                objCmd.Parameters.AddWithValue("@itemcode", Productid);
                objCmd.Parameters.AddWithValue("@itemcodelist", ProductList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getProductInformation(string Field)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_getPorductinfromation";
                objCmd.Parameters.AddWithValue("@Field", Field);
                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getproductEnquiry(string ProductId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_getPorductEnquiry";
                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");

                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        // save price list

        public static string saveProductPriceList(int Pricelist, string itemcode, string UnitOfMeasurementid, double costprice, double mrp, double dealerprice)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[SFA_usp_SaveProductsPriceList]";
                
                objCmd.Parameters.AddWithValue("@PriceIdOut", Pricelist).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@PriceId", Pricelist);
                objCmd.Parameters.AddWithValue("@itemcode", itemcode);
                objCmd.Parameters.AddWithValue("@MeasurementId", UnitOfMeasurementid);
                objCmd.Parameters.AddWithValue("@costprice", costprice);
                objCmd.Parameters.AddWithValue("@mrp", mrp);
                objCmd.Parameters.AddWithValue("@dealerprice", dealerprice);
                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return objCmd.Parameters["@PriceIdOut"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            return "";
        }


    }
}
