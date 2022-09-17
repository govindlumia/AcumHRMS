using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Organization
/// </summary>
/// 
namespace DAL
{
    public class Organization
    {
        public Organization()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getOrganizationList(string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "SFA_usp_SelectOrganizationListing";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static DataTable getVendors()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where accounttype=6";   // 6 is for vendor
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }
        public static DataTable getOrganizationByName(string OrgName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where OrganizationName like '" + OrgName + "%'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getOrganizationBy_Name(string OrgName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where OrganizationName = '" + OrgName + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getOrganizationByAccountType(int type)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where AccountType= '" + type + "' ORDER BY organizationName";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }



        public static DataTable getOrganizationByOrganizationCode(string OrganizationCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where OrganizationCode= '" + OrganizationCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static string saveOrganization(string operation, string OrganizationCode, string OrganizationName, string AccountType, string NatureofBusiness, int IndustryId, int CompanyType, int NumberOfLocations, string Status, DateTime CreationDate, string Tan_No, string Pan_No, string Vat_No, string ServiceTax_No, int NumberOfEmployee, double AnnualTurnOver, string URL, string PhoneNo, string FaxNo, string CorporateEmailId, string Cors_Add1, string Cors_Add2, string Cors_City, string Cors_State, string Cors_Country, string Cors_Pin, string Bill_Add1, string Bill_Add2, string Bill_City, string Bill_State, string Bill_Country, string Bill_Pin, string Ship_Add1, string Ship_Add2, string Ship_City, string Ship_State, string Ship_Country, string Ship_Pin, string Reg_Add1, string Reg_Add2, string Reg_City, string Reg_State, string Reg_Country, string Reg_Pin,  string Reporting_To, string Updated_By, DateTime Updated_Date, string Created_By, DateTime Created_Date, string CustomerReference, string AssignTo)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOrganization";
                objCmd.Parameters.AddWithValue("@Operation", operation);
                objCmd.Parameters.AddWithValue("@OrganizationCodeout", OrganizationCode).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OrganizationCode", OrganizationCode);
                objCmd.Parameters.AddWithValue("@OrganizationName", OrganizationName);
                objCmd.Parameters.AddWithValue("@AccountType", AccountType);
                objCmd.Parameters.AddWithValue("@NatureofBusiness", NatureofBusiness);
                objCmd.Parameters.AddWithValue("@IndustryId", IndustryId);
                objCmd.Parameters.AddWithValue("@CompanyType", CompanyType);
                objCmd.Parameters.AddWithValue("@NumberOfLocations", NumberOfLocations);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@CreationDate", CreationDate);
                objCmd.Parameters.AddWithValue("@Tan_No", Tan_No);
                objCmd.Parameters.AddWithValue("@Pan_No", Pan_No);
                objCmd.Parameters.AddWithValue("@Vat_No", Vat_No);
                objCmd.Parameters.AddWithValue("@ServiceTax_No", ServiceTax_No);
                objCmd.Parameters.AddWithValue("@NumberOfEmployee", NumberOfEmployee);
                objCmd.Parameters.AddWithValue("@AnnualTurnOver", AnnualTurnOver);
                objCmd.Parameters.AddWithValue("@URL", URL);
                objCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                objCmd.Parameters.AddWithValue("@FaxNo", FaxNo);
                objCmd.Parameters.AddWithValue("@CorporateEmailId", CorporateEmailId);
                objCmd.Parameters.AddWithValue("@Cors_Add1", Cors_Add1);
                objCmd.Parameters.AddWithValue("@Cors_Add2", Cors_Add2);
                objCmd.Parameters.AddWithValue("@Cors_City", Cors_City);
                objCmd.Parameters.AddWithValue("@Cors_State", Cors_State);
                objCmd.Parameters.AddWithValue("@Cors_Country", Cors_Country);
                objCmd.Parameters.AddWithValue("@Cors_Pin", Cors_Pin);
                objCmd.Parameters.AddWithValue("@Bill_Add1", Bill_Add1);
                objCmd.Parameters.AddWithValue("@Bill_Add2", Bill_Add2);
                objCmd.Parameters.AddWithValue("@Bill_City", Bill_City);
                objCmd.Parameters.AddWithValue("@Bill_State", Bill_State);
                objCmd.Parameters.AddWithValue("@Bill_Country", Bill_Country);
                objCmd.Parameters.AddWithValue("@Bill_Pin", Bill_Pin);
                objCmd.Parameters.AddWithValue("@Ship_Add1", Ship_Add1);
                objCmd.Parameters.AddWithValue("@Ship_Add2", Ship_Add2);
                objCmd.Parameters.AddWithValue("@Ship_City", Ship_City);
                objCmd.Parameters.AddWithValue("@Ship_State", Ship_State);
                objCmd.Parameters.AddWithValue("@Ship_Country", Ship_Country);
                objCmd.Parameters.AddWithValue("@Ship_Pin", Ship_Pin);
                objCmd.Parameters.AddWithValue("@Reg_Add1", Reg_Add1);
                objCmd.Parameters.AddWithValue("@Reg_Add2", Reg_Add2);
                objCmd.Parameters.AddWithValue("@Reg_City", Reg_City);
                objCmd.Parameters.AddWithValue("@Reg_State", Reg_State);
                objCmd.Parameters.AddWithValue("@Reg_Country", Reg_Country);
                objCmd.Parameters.AddWithValue("@Reg_Pin", Reg_Pin);

                objCmd.Parameters.AddWithValue("@Updated_By", Updated_By);
                objCmd.Parameters.AddWithValue("@Updated_Date", Updated_Date);
                objCmd.Parameters.AddWithValue("@Created_By", Created_By);
                objCmd.Parameters.AddWithValue("@Created_Date", Created_Date);
                objCmd.Parameters.AddWithValue("@Reporting_To", Reporting_To);
                objCmd.Parameters.AddWithValue("@CustomerReference", CustomerReference);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return objCmd.Parameters["@OrganizationCodeout"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public static string saveOrganizationPopup(string orgCode, string orgName, string accType, string orgmail, string address, string city, string contactPerson, string CreationBy, DateTime CreationDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOrganizationPopup";
                objCmd.Parameters.AddWithValue("@OrganizationCodeout", orgCode).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@orgCode", orgCode);
                objCmd.Parameters.AddWithValue("@orgName", orgName);
                objCmd.Parameters.AddWithValue("@accType", accType);
                objCmd.Parameters.AddWithValue("@orgmail", orgmail);
                objCmd.Parameters.AddWithValue("@address", address);
                objCmd.Parameters.AddWithValue("@city", city);
                objCmd.Parameters.AddWithValue("@contactPerson", contactPerson);
                objCmd.Parameters.AddWithValue("@CreationBy", CreationBy);
                objCmd.Parameters.AddWithValue("@CreationDate", CreationDate);



                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return objCmd.Parameters["@OrganizationCodeout"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        /// <summary>
        /// Gives the list of all organization
        /// </summary>
        /// <returns>Returning DataTable object.</returns>
        public static DataTable SearchOrgnization(string strSortField, string strSortDir, int pageSize, int pageNum, string ColList, string Keywords, string Alphabet, string CreatedBy, string AssignTo, string AssignToOrCreatedBy)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchOrgnization";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@ColList", ColList.ToString());
                objCmd.Parameters.AddWithValue("@Keywords", Keywords);
                objCmd.Parameters.AddWithValue("@Alphabet", Alphabet);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@AssignToOrCreatedBy", AssignToOrCreatedBy);

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

        public static int deleteOrgnaizationById(string Orgid, string OrgList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteOrgnaization";
                objCmd.Parameters.AddWithValue("@Orgid", Orgid);
                objCmd.Parameters.AddWithValue("@OrgList", OrgList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static int saveShipping(int ShippingId, string OrganizationCode, string Address1, string Address2, string city, string PinCode, string State, string Country, string Updated_by, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveOrganizationShipping";
                objCmd.Parameters.AddWithValue("@ShippingIdOut", ShippingId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@ShippingId", ShippingId);
                objCmd.Parameters.AddWithValue("@OrganizationCode", OrganizationCode);
                objCmd.Parameters.AddWithValue("@Address1", Address1);
                objCmd.Parameters.AddWithValue("@Address2", Address2);
                objCmd.Parameters.AddWithValue("@city", city);
                objCmd.Parameters.AddWithValue("@PinCode", PinCode);
                objCmd.Parameters.AddWithValue("@State", State);
                objCmd.Parameters.AddWithValue("@Country", Country);
                objCmd.Parameters.AddWithValue("@Updated_by", Updated_by);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@ShippingIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        public static DataTable getShippingListByOrgCOde(string orgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_Shipping where OrganizationCode ='" + orgCode + "' ";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getShippingByShippingId(int ShippingId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_Organization_Shipping where ShippingId= '" + ShippingId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int deleteShippingId(int ShippingId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_Organization_Shipping where ShippingId = '" + ShippingId + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

    }
}
