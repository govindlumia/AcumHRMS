using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Branch
/// </summary>
/// 
namespace DAL
{
    public class Enquiry
    {
        public Enquiry()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static int saveEnquiry(int EnquriesId, string EnquiryType, int CustomerType, string OrganizationName, string ContactPerson, string ContactNumber, string AssignTo, string NeedIdentification, string ReferredBy, string updated_by, DateTime UpdatedDate, string Priority, double ExpectedValue)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveEnquiry";
                objCmd.Parameters.AddWithValue("@EnquriesIdOut", EnquriesId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EnquriesId", EnquriesId);
                objCmd.Parameters.AddWithValue("@EnquiryType", EnquiryType);
                objCmd.Parameters.AddWithValue("@CustomerType", CustomerType);
                objCmd.Parameters.AddWithValue("@OrganizationName", OrganizationName);
                objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                objCmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@NeedIdentification", NeedIdentification);
                objCmd.Parameters.AddWithValue("@ReferredBy", ReferredBy);
                objCmd.Parameters.AddWithValue("@UpdatedBy", updated_by);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Priority", Priority);
                objCmd.Parameters.AddWithValue("@ExpectedValue", ExpectedValue);

                //objCmd.Parameters.AddWithValue("@ProductCode", ProductCode);
                //objCmd.Parameters.AddWithValue("@Description", Description);
                //objCmd.Parameters.AddWithValue("@Address", Address);
                //objCmd.Parameters.AddWithValue("@Comments", Comments);
                //objCmd.Parameters.AddWithValue("@MoreProduct", MoreProduct);
                //objCmd.Parameters.AddWithValue("@EnquiryNumber", EnquiryNumber);
                //objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                //objCmd.Parameters.AddWithValue("@CapturedBy", CapturedBy);
                
                

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@EnquriesIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        public static int saveEnquiryDetails(int EnquiryId, string EnquiryType, string ProductCode, string ProductName, double Rate, double Quantity, double Amount, string MeasurementId, decimal Discount)
        {
            DataTable oDate = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveEnquiryProducts";
                objCmd.Parameters.AddWithValue("@EnquiryIdOut", EnquiryId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EnquiryId", EnquiryId);
                objCmd.Parameters.AddWithValue("@EnquiryType", EnquiryType);
                objCmd.Parameters.AddWithValue("@ProductCode", ProductCode);
                objCmd.Parameters.AddWithValue("@ProductName", ProductName);
                objCmd.Parameters.AddWithValue("@Quantity", Quantity);
                objCmd.Parameters.AddWithValue("@Rate", Rate);
                objCmd.Parameters.AddWithValue("@Amount", Amount);
                if (MeasurementId == "Sq.Ft.")
                {
                    MeasurementId = "1";
                }
                else if (MeasurementId == "Box")
                {
                    MeasurementId = "2";
                }
              
                objCmd.Parameters.AddWithValue("@MeasurementId", MeasurementId);
                objCmd.Parameters.AddWithValue("@Discount", Discount);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@EnquiryIdOut"].Value.ToString());

            }
            catch (Exception ex)
            { 
            
            }
            return 0;
        }
        /*@customerType varchar(10),
	@priority varchar(50),
	@startValue varchar(50),
	@endValue varchar(50),
	@startdate varchar(50),
	@enddate varchar(50)*/
        public static DataTable SearchEnquiryDetails(string strSortField, string strSortDir, int pageSize, int pageNum, string keyWord, string AssignTo, string AssignEmp, string EnquiryType, string empcode, string role, string customerType, string priority, string startValue, string endValue, string startdate, string enddate,int enquirystatus,string createdby)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchEnquiry";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@role", role);
                objCmd.Parameters.AddWithValue("@customerType", customerType);
                objCmd.Parameters.AddWithValue("@priority", priority);
                objCmd.Parameters.AddWithValue("@startValue", startValue);
                objCmd.Parameters.AddWithValue("@endValue", endValue);
                objCmd.Parameters.AddWithValue("@startdate", startdate);
                objCmd.Parameters.AddWithValue("@enddate", enddate);
                objCmd.Parameters.AddWithValue("@enquirystatus", enquirystatus);
                objCmd.Parameters.AddWithValue("@createdby", createdby);
              //objCmd.Parameters.AddWithValue("@EnquiryType", EnquiryType);
                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return oData;
        }


        public static DataTable SearchEnquirySales(string strSortField, string strSortDir, int pageSize, int pageNum, string keyWord, string AssignTo, string AssignEmp, string EnquiryType, string customerType, string priority, string startValue, string endValue, string startdate, string enddate, int enquirystatus, string createdby)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchEnquirySales";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);
                objCmd.Parameters.AddWithValue("@customerType", customerType);
                objCmd.Parameters.AddWithValue("@priority", priority);
                objCmd.Parameters.AddWithValue("@startValue", startValue);
                objCmd.Parameters.AddWithValue("@endValue", endValue);
                objCmd.Parameters.AddWithValue("@startdate", startdate);
                objCmd.Parameters.AddWithValue("@enddate", enddate);
                objCmd.Parameters.AddWithValue("@enquirystatus", enquirystatus);
                objCmd.Parameters.AddWithValue("@createdby", createdby);
                //objCmd.Parameters.AddWithValue("@AssignEmp", AssignEmp);
                //objCmd.Parameters.AddWithValue("@EnquiryType", EnquiryType);
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
            catch (Exception ex)
            {

            }
            return oData;
        }
        public static DataTable getAllEnquiryNo(string CustomerCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select EnquriesId from tbl_internate_EnquriesDetails where assignto not in ('Won','Drop','Lost') and OrganizationName = '" + CustomerCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static int deleteEnquiryById(string Enquiryid, string EnquiryList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteEnquiry";
                objCmd.Parameters.AddWithValue("@Enquiry", Enquiryid);
                objCmd.Parameters.AddWithValue("@Enquirylist", EnquiryList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        public static int deleteEnquiryProdductsByEnquiryId(string Enquiryid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteEnquiryProducts";
                objCmd.Parameters.AddWithValue("@EnquiryId", Enquiryid);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static int UpadteEnquiry(string EnquriesList, string assignEmp, string Comments, string AssignTo, string userId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_UpdateEnquary";
                objCmd.Parameters.AddWithValue("@UserId", userId);
                objCmd.Parameters.AddWithValue("@EnquriesIdList", EnquriesList);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@Comments", Comments);
                objCmd.Parameters.AddWithValue("@empcode", userId);

                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static int UpadteEnquirytype(string EnquriesList, string EnquiryType, string TypeComment, string AssignTo)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_UpdateSolveEnquiry";
                objCmd.Parameters.AddWithValue("@EnquriesIdList", EnquriesList);
                objCmd.Parameters.AddWithValue("@EnquiryType", EnquiryType);
                objCmd.Parameters.AddWithValue("@TypeComment", TypeComment);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);

                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }


        public static DataTable getEnquiryById(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_EnquriesDetails where EnquriesId=" + EnqId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getProductEnquiryByEnqId(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_Product_Enquiry where EnqId =" + EnqId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getAllEnquiry()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_EnquriesDetails";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEnquiryViewById(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_EnquiryDetails where EnquriesId=" + EnqId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEnquiryViewById_stock(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_EnquiryDetails where EnquriesId=" + EnqId.ToString() + " and enquirytype='Stock'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEnquiryViewById_sample(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_EnquiryDetails where EnquriesId=" + EnqId.ToString() + " and enquirytype='Sample'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {
            }
            return oData;
        }


       
        public static DataTable getEnquiryViewById_sales(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_EnquiryDetails where EnquriesId=" + EnqId.ToString() + " and enquirytype='Sales'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getEnquiryViewById_General(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_EnquiryDetails where EnquriesId=" + EnqId.ToString() + " and enquirytype='General'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {
            }
            return oData;
        }


        public static DataTable GetTaskByEnquiryId(int EnqId)
       {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_TaskDetailsNew where EnquiryId = '" + EnqId + "' order by date1 desc";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getEnquiryStatus()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_Intranet_EnquiryStatus order by enquirystatus";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int getEnquiryStatus(int EnqId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select assignto from tbl_internate_EnquriesDetails where enquriesid = " + EnqId.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {
                return 2; // 2 - pending
            }
            if (oData.Rows.Count > 0)
            {
                if (Convert.ToInt32(oData.Rows[0][0]) == 1)
                {
                    return 2;
                }
                else
                  return Convert.ToInt32(oData.Rows[0][0].ToString());
            }
            else
            {
                return 2; // 2 - pending
            }
        }
    }
}
