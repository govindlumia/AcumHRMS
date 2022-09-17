using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Contact
/// </summary>
/// 
namespace DAL
{
    public class Contact
    {
        public Contact()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getContactDetailsByContactID(string ContactID)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_ContactInformation where ContactId= '" + ContactID + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getContactByName(string ContactName)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_ContactInformation where Basic_FName like '" + ContactName + "%'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getOpportunityByContact(int Contact)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ContactOpportunity where ContactId = '" + Contact + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable getContactDetailsByOrgCode(string OrgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ContactDetail where OrganizationCode = '" + OrgCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getContactDetailsByContactId(int ContactId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_ContactDetail where ContactId = '" + ContactId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable SearchContactDetails(string strSortField, string strSortDir, int pageSize, int pageNum, string keyWord, string OrgCode, string Alphabet, string CreatedBy, string AssignTo, string AssignToOrCreatedBy)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchContact";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);
                objCmd.Parameters.AddWithValue("@OrgCode", OrgCode);
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

        public static int SaveContact(string Oper, int ContactId, string OrganizationCode, string Basic_Title, string Basic_FName, string Basic_MName, string Basic_LName, int Basic_JobTitle, int DepartmentId, int Basic_BranchId, string Basic_Type, string Basic_EMail, string Buis_Phone_Country, string Buis_Phone_CityCode, string Buis_Phone_Number, string Buis_Phone_Extension, string Buis_Fax_Country, string Buis_Fax_CityCode, string Buis_Fax_Number, string Buis_Fax_Extension, string Moblie_Country, string Moblie_CityCode, string Moblie_Number, string Moblie_Extension, string Perso_Street, string Perso_City, string Perso_State, string Perso_Country, string Perso_PinNo, DateTime BirthDay, DateTime Anniversary, string Spouse_Name, string Children, string Updated_By, DateTime Updated_Date, string Created_By, DateTime Created_Date)  //, string AssignTo
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveContact";
                objCmd.Parameters.AddWithValue("@Oper", Oper);
                objCmd.Parameters.AddWithValue("@ContactId", ContactId);
                objCmd.Parameters.AddWithValue("@ContactIdOut", ContactId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OrganizationCode", OrganizationCode);
                objCmd.Parameters.AddWithValue("@Basic_Title", Basic_Title);
                objCmd.Parameters.AddWithValue("@Basic_FName", Basic_FName);
                objCmd.Parameters.AddWithValue("@Basic_MName", Basic_MName);
                objCmd.Parameters.AddWithValue("@Basic_LName", Basic_LName);
                objCmd.Parameters.AddWithValue("@Basic_JobTitle", Basic_JobTitle);
                objCmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                objCmd.Parameters.AddWithValue("@Basic_BranchId", Basic_BranchId);
                objCmd.Parameters.AddWithValue("@Basic_Type", Basic_Type);
                objCmd.Parameters.AddWithValue("@Basic_EMail", Basic_EMail);
                objCmd.Parameters.AddWithValue("@Buis_Phone_Country", Buis_Phone_Country);
                objCmd.Parameters.AddWithValue("@Buis_Phone_CityCode", Buis_Phone_CityCode);
                objCmd.Parameters.AddWithValue("@Buis_Phone_Number", Buis_Phone_Number);
                objCmd.Parameters.AddWithValue("@Buis_Phone_Extension", Buis_Phone_Extension);
                objCmd.Parameters.AddWithValue("@Buis_Fax_Country", Buis_Fax_Country);
                objCmd.Parameters.AddWithValue("@Buis_Fax_CityCode", Buis_Fax_CityCode);
                objCmd.Parameters.AddWithValue("@Buis_Fax_Number", Buis_Fax_Number);
                objCmd.Parameters.AddWithValue("@Buis_Fax_Extension", Buis_Fax_Extension);
                objCmd.Parameters.AddWithValue("@Moblie_Country", Moblie_Country);
                objCmd.Parameters.AddWithValue("@Moblie_CityCode", Moblie_CityCode);
                objCmd.Parameters.AddWithValue("@Moblie_Number", Moblie_Number);
                objCmd.Parameters.AddWithValue("@Moblie_Extension", Moblie_Extension);
                objCmd.Parameters.AddWithValue("@Perso_Street", Perso_Street);
                objCmd.Parameters.AddWithValue("@Perso_City", Perso_City);
                objCmd.Parameters.AddWithValue("@Perso_State", Perso_State);
                objCmd.Parameters.AddWithValue("@Perso_Country", Perso_Country);
                objCmd.Parameters.AddWithValue("@Perso_PinNo", Perso_PinNo);
                if (BirthDay == null || BirthDay == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@BirthDay", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@BirthDay", BirthDay);
                }
                if (Anniversary == null || Anniversary == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@Anniversary", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Anniversary", Anniversary);
                }
                objCmd.Parameters.AddWithValue("@Spouse_Name", Spouse_Name);
                objCmd.Parameters.AddWithValue("@Children", Children);
                objCmd.Parameters.AddWithValue("@Updated_By", Updated_By);
                objCmd.Parameters.AddWithValue("@Updated_Date", Updated_Date);
                objCmd.Parameters.AddWithValue("@Created_By", Created_By);
                objCmd.Parameters.AddWithValue("@Created_Date", Created_Date);
               // objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return int.Parse(objCmd.Parameters["@ContactIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        public static int deleteContactById(string Contactid, string ContactList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteContact";
                objCmd.Parameters.AddWithValue("@Contactid", Contactid);
                objCmd.Parameters.AddWithValue("@ContactList", ContactList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
    }
}