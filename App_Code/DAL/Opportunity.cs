using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Opportunity
/// </summary>
/// 
namespace DAL
{
    public class Opportunity
    {
        public static int SaveOppProductMap(string ItemCode, int OppId, string Qty, string MeasurementId, Int32 Discount, string DeleteList)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                if (ItemCode == "")
                {
                    ItemCode = "0";
                }
                if (Qty == "0")
                {
                    Qty = "0";
                }
                if (DeleteList == "")
                {
                    DeleteList = "0";
                }
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOppProductsMap";
                objCmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                objCmd.Parameters.AddWithValue("@Qty", Qty);
                objCmd.Parameters.AddWithValue("@MeasurementId", MeasurementId);
                objCmd.Parameters.AddWithValue("@Discount", Discount);
                objCmd.Parameters.AddWithValue("@DeleteList", DeleteList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static DataTable getProductsList(int OppId, string mid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
//                objCmd.CommandText = @"Select A.*,B.itemname,B.dealerprice as Rate,B.itemsize from dbo.tbl_Opp_ProductsMap A,dbo.tbl_intranet_product_productdetails B 
//                                      where
//                                      A.ItemCode = B.itemcode
//                                      and A.OppId=" + OppId.ToString();

//                objCmd.CommandText = @"Select A.*,B.itemname,B.DealerPrice as Rate,B.itemsize,(B.DealerPrice * A.Qty)as Amount  from dbo.tbl_Opp_ProductsMap A,dbo.View_ProductPricelist B 
//                                      where
//                                      A.ItemCode = B.ItemCode
//                                        and A.OppId=" + OppId.ToString();

                if (string.IsNullOrEmpty(mid) == true)
                {
                    objCmd.CommandText = @"Select Distinct A.*,B.itemcode,B.itemname,B.DealerPrice as Rate,(B.DealerPrice * A.Qty)as Amount,B.conversionrate,B.PrimaryMeasurementName,B.SecondaryMeasurementName,B.SecondaryMeasurementId  from dbo.tbl_Opp_ProductsMap A,View_ProductPricelist B 
                                      where
                                      A.ItemCode = B.itemcode
                                      and A.OppId=" + OppId.ToString();
                }
                else
                {
                    objCmd.CommandText = @"Select Distinct A.*,B.itemcode,B.itemname,B.DealerPrice as Rate,(B.DealerPrice * A.Qty)as Amount,B.MeasurementId,B.conversionrate,B.PrimaryMeasurementName,B.SecondaryMeasurementName,B.SecondaryMeasurementId  from dbo.tbl_Opp_ProductsMap A,View_ProductPricelist B 
                                      where
                                      A.ItemCode = B.itemcode
                                      and A.OppId=" + OppId.ToString() + " and B.MeasurementId='" + mid + "'";
                }

                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static DataTable deleteProductsListOfOpp(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_Opp_ProductsMap where OppId= " + OppId ;
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable GetProductsMapbyMapId(int MapId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_Product_ProductMap where Id= '" + MapId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        // get Opportunity Task Details List

        public static DataTable GetTaskByOppId(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_TaskOpportunity where OppId = '" + OppId + "' order by date1 desc";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        // Get Quote  Information TAsk Details

        public static DataTable GetQuotesInformationByOppId(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Quotes where OppId = '" + OppId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public Opportunity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static int saveOpportunity(int OpportunityId, string Customer, string Contact, string Source, string Priority, string SalesType, string MarketingScheme, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, double ExpectedValue, string AssignTo, string NeedInfo, string ReferredBy, string ORGName, string CustomerType, string SiteAddress)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOpportunityDetails";
                objCmd.Parameters.AddWithValue("@OpportunityIdOut", OpportunityId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OpportunityId", OpportunityId);
                objCmd.Parameters.AddWithValue("@Customer", Customer);
                objCmd.Parameters.AddWithValue("@Contact", Contact);
                objCmd.Parameters.AddWithValue("@Source", Source);
                objCmd.Parameters.AddWithValue("@Priority", Priority);
                objCmd.Parameters.AddWithValue("@SalesType", SalesType);
                objCmd.Parameters.AddWithValue("@MarketingScheme", MarketingScheme);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@ExpectedValue", ExpectedValue);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@NeedInfo", NeedInfo);
                objCmd.Parameters.AddWithValue("@ReferredBy", ReferredBy);
                objCmd.Parameters.AddWithValue("@ORGName", ORGName);
                objCmd.Parameters.AddWithValue("@CustomerType", CustomerType);
                objCmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@OpportunityIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        public static DataTable getOpportunityById(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_OpportunityDetails where OpportunityId=" + OppId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getOpportunityAllDetailById(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_OpportunityDetail where OpportunityId=" + OppId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        //17 arguments
        public static DataTable SearchOpportunityDetails(string strSortField, string strSortDir, int pageSize, int pageNum, string keyWord, string status, string CreatedBy, string CreatedDate, string AssignTo, string AssignToOrCreatedBy, string role, string empcode, string customerType, string startValue, string endValue, string startdate, string enddate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchOpportunity";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);
                objCmd.Parameters.AddWithValue("@viewBy", status);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@AssignToOrCreatedBy", AssignToOrCreatedBy);
                objCmd.Parameters.AddWithValue("@role", role);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@customerType", customerType);
                objCmd.Parameters.AddWithValue("@startValue", startValue);
                objCmd.Parameters.AddWithValue("@endValue", endValue);
                objCmd.Parameters.AddWithValue("@startdate", startdate);
                objCmd.Parameters.AddWithValue("@enddate", enddate);
        
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

        public static DataTable SearchOpportunityDetails(string strSortField, string strSortDir, int pageSize, int pageNum, string keyWord, string viewBy, string CreatedBy, string CreatedDate, string AssignTo, string AssignToOrCreatedBy,string role,string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchOpportunity";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);
                objCmd.Parameters.AddWithValue("@viewBy", viewBy);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@AssignToOrCreatedBy", AssignToOrCreatedBy);
                objCmd.Parameters.AddWithValue("@role", role);
                objCmd.Parameters.AddWithValue("@empcode", empcode);

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

        public static int deleteOpportunityById(string Opportunityid, string OpportunityList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteOpportunity";
                objCmd.Parameters.AddWithValue("@Opportunity", Opportunityid);
                objCmd.Parameters.AddWithValue("@Opportunitylist", OpportunityList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getOpportunityBySource(string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                //                objCmd.CommandText = @"Select OpportunityId, Source from tbl_internate_OpportunityDetails
                //                                      Where Source in(Select Source from dbo.tbl_internate_OpportunityDetails
                //                                                        group by Source)"
                //                                        + "' And ( CreatedBy = '" + empcode + "' OR AssignTo = '" + empcode + "') order by Source";

                objCmd.CommandText = @"Select OpportunityId, Source from tbl_internate_OpportunityDetails
                                      Where Source in(Select Source from dbo.tbl_internate_OpportunityDetails
                                                        group by Source)
                                       And (CreatedBy = '" + empcode + "' OR AssignTo = '" + empcode + "') order by Source";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getOpportunityByOrganization(String Organization)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_OpportunityDetail where Customer = '" + Organization + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getAllOpportunityList(string empcode, string CustomerCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                if (CheckRole(empcode) != "3")
                {
                    objCmd.CommandText = "Select OpportunityId from tbl_internate_OpportunityDetails where AssignTo = '" + empcode + "' and Customer = '" + CustomerCode + "'";
                    
                }
                else
                {
                    objCmd.CommandText = "Select OpportunityId from tbl_internate_OpportunityDetails where Customer = '" + CustomerCode + "'";
                    
                }
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getAllOpportunityNo(string CustomerCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select OpportunityId from tbl_internate_OpportunityDetails where Customer = '" + CustomerCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getAllCustomerList(string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                if (CheckRole(empcode) != "3")
                {
                    objCmd.CommandText = @"select distinct b.customer as CustomerId, a.organizationname as CustomerName from tbl_intranet_OrganizationDetail as a
                                       inner join tbl_internate_OpportunityDetails as b on b.customer = a.organizationCode where b.AssignTo = '" + empcode + "'";
                }
                else
                {
                    objCmd.CommandText = @"select distinct b.customer as CustomerId, a.organizationname as CustomerName from tbl_intranet_OrganizationDetail as a
                                       inner join tbl_internate_OpportunityDetails as b on b.customer = a.organizationCode";
               
                }
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        private static string CheckRole(string empcode)
        {

            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {

                objCmd.CommandText = @"select role from tbl_login where empcode = '" + empcode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData.Rows[0]["role"].ToString();
        
        }

        public static DataTable getAllContactPersonList(string empcode, string ContactPerson)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = @"select distinct a.ContactId, coalesce(a.Basic_Fname,'') + ' ' + coalesce(a.Basic_lname,'') as ContactPersonName
                                        from tbl_intranet_ContactInformation as a
                                        inner join tbl_internate_OpportunityDetails as b on b.customer = a.organizationCode
                                        where b.AssignTo = '" + empcode + "' and a.OrganizationCode = '" + ContactPerson + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getQuotesStatus()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = @"select * from tbl_intranet_quotestatus";

                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

             public static DataTable getProductInfo(int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = @"Select Distinct A.*,B.itemcode,B.itemname,B.DealerPrice as Rate,((B.DealerPrice-(B.DealerPrice*A.Discount/100)) * A.Qty)as Amount from dbo.tbl_Opp_ProductsMap A,View_ProductPricelist B 
                                      where
                                      A.ItemCode = B.itemcode and A.MeasurementId = B.MeasurementId
                                      and A.OppId=" + OppId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


    }
}
