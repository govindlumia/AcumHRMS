using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Quotes
/// </summary>
/// 
namespace DAL
{
    public class Quotes
    {
        public Quotes()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getQuotesList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Quotes";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getQuotesByQuoteId(int QuoteId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Quotes where QuoteId = '" + QuoteId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static void EnableDisableddlApprovalStatus(string empcode, int QuoteId)
        { 
          
        }

        public static int SaveQuotes(int QuoteId, string CustomerId, string CustomerName, int OppId, string RefNo, string Subject, string ContactPerson, DateTime Dated, string Status, string Designation, string Updatedby, DateTime UpdatedDate, string CreatedBy, DateTime CreatedDate, int approvalstatus, decimal discount, decimal cartage, decimal totaltaxamount, decimal netamount)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveQuotes";
                objCmd.Parameters.AddWithValue("@QuoteIdOut", QuoteId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@QuoteId", QuoteId);
                objCmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                objCmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                objCmd.Parameters.AddWithValue("@RefNo", RefNo);
                objCmd.Parameters.AddWithValue("@Subject", Subject);
                objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                objCmd.Parameters.AddWithValue("@approvalstatus", approvalstatus);
                objCmd.Parameters.AddWithValue("@discount", discount);
                objCmd.Parameters.AddWithValue("@cartage", cartage);
                objCmd.Parameters.AddWithValue("@totaltaxamount", totaltaxamount);
                objCmd.Parameters.AddWithValue("@netamount", netamount);

                if (Dated == null || Dated == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@Dated", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Dated", Dated);
                }
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@Designation", Designation);

                objCmd.Parameters.AddWithValue("@Updatedby", Updatedby);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@QuoteIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static DataTable SearchQuotes(string strSortField, string strSortDir, int pageSize, int pageNum, string Alphabet, string createdBy, string createdDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchQuotes";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Alphabet", Alphabet);
                objCmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", createdDate);


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

        public static DataTable SearchQuotesForApproval(string strSortField, string strSortDir, int pageSize, int pageNum, string Alphabet, string empcode, string createdDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchQuotesForApproval";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Alphabet", Alphabet);
                objCmd.Parameters.AddWithValue("@CreatedBy", empcode);    // will select all the quotes created by employees under this empcode 
                objCmd.Parameters.AddWithValue("@CreatedDate", createdDate);


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

        public static int deleteQuotesById(string Quotesid, string QuotesList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteQuotes";
                objCmd.Parameters.AddWithValue("@Quotesid", Quotesid);
                objCmd.Parameters.AddWithValue("@QuotesList", QuotesList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }


        public static int deleteQuotesById(int QuotesId, string QuotesList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteQuotes";
                objCmd.Parameters.AddWithValue("@itemcode", QuotesId);
                objCmd.Parameters.AddWithValue("@itemcodelist", QuotesList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getQuotesTermList(int QuoteId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_QuoteDescription where QuoteId = " + QuoteId ;
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getQuotesTermBYId(int QuoteId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_QuoteDescription where QuoteId = '" + QuoteId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int SaveQuotesDescription(int DespId, int QuoteID, string Description, string Updatedby, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveQuoteDescription";
                objCmd.Parameters.AddWithValue("@DespIdout", DespId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@DespId", DespId);
                objCmd.Parameters.AddWithValue("@QuoteId", QuoteID);
                objCmd.Parameters.AddWithValue("@Description", Description);
                objCmd.Parameters.AddWithValue("@UpdatedBy", Updatedby);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@DespIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteQuoteDescriptionById(int DespId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "Delete from tbl_intranet_QuoteDescription where DespId = '" + DespId + "'";

                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getQuotesItemList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_QuotesItem";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getQuotesItemByQuotesId(int QuoteID)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_QuotesItems where QuoteID = '" + QuoteID + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
       
        public static DataTable getQuotesItemById(int ItemId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_QuotesItem where ItemId = '" + ItemId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int delQuotesItemById(string ItemId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_QuotesItem where ItemId = '" + ItemId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static int delQuotesItemByQuoteId(string QuoteId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_QuotesItem where QuoteId = " + QuoteId ;
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static int SaveQuoteItem(int ItemId, int QuoteID, string ItemCode, string ItemName, string Unit, decimal Qty, decimal ItemRate, string Amount, int QuotesId, string Updatedby, DateTime UpdatedDate,int TaxTypeId,decimal TaxPerc) //, string TaxType, string TaxAmt
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveQuoteItem";
                objCmd.Parameters.AddWithValue("@ItemIdOut", ItemId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@ItemId", ItemId);
                objCmd.Parameters.AddWithValue("@QuoteID", QuoteID);
                objCmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                objCmd.Parameters.AddWithValue("@ItemName", ItemName);
                objCmd.Parameters.AddWithValue("@Unit", Unit);
                objCmd.Parameters.AddWithValue("@Qty", Qty);
                objCmd.Parameters.AddWithValue("@ItemRate", ItemRate);
                objCmd.Parameters.AddWithValue("@Amount", Amount);
                //objCmd.Parameters.AddWithValue("@TaxType", TaxType);
               //objCmd.Parameters.AddWithValue("@TaxAmount", TaxAmt);
                objCmd.Parameters.AddWithValue("@QuotesId", QuotesId);
                objCmd.Parameters.AddWithValue("@Updatedby", Updatedby);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@TaxPerc", TaxPerc);
                objCmd.Parameters.AddWithValue("@TaxTypeId", TaxTypeId);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@ItemIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        // Get Tax Details

        public static DataTable getQuotesTax()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_TaxDetails";// where Tax ='" + tax + "'"; //string tax where Tax ='" + tax + "' ";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getReteByMeasurementId(string itemname, string mid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
               // objCmd.CommandText = "select * from View_ProductPricelist where ItemName ='" + itemname + "'";  //DealerPrice,MeasurementId 
                objCmd.CommandText = "Select * from View_ProductPricelist where itemname = '" + itemname + "' and MeasurementId = '" + mid + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductByPrice(string ProductName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ProductPricelist where itemname= '" + ProductName + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getTaxTypes()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_TaxTypes order by TaxId;";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
    }
}
