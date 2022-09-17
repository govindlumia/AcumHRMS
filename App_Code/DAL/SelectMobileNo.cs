using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SelectMobileNo
/// </summary>
public class SelectMobileNo
{
	public SelectMobileNo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string SelectMobileNumber(string empCode)
    {
        string mobileNo=string.Empty;
        SqlCommand objCmd = new SqlCommand();
        try
        {
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SelectMobileNo";
            objCmd.Parameters.AddWithValue("@empcode", empCode);
            
            DataSet oDS = new DataSet();
            oDS = SFA.DataConnect.GetDataSet(objCmd);
            if (oDS != null)
            {
                mobileNo = oDS.Tables[0].Rows[0]["mobile_no"].ToString();              
                
            }
        }
        catch
        {

        }
        return mobileNo;
    }

    public static string SelectMobileNoByOpportunityId(int opportunityId)
    {
        string mobileNo = string.Empty;
        SqlCommand objCmd = new SqlCommand();
        try
        {
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SelectMobileNoByOpportunityId";
            objCmd.Parameters.AddWithValue("@opportunityId", opportunityId);

            DataSet oDS = new DataSet();
            oDS = SFA.DataConnect.GetDataSet(objCmd);
            if (oDS != null)
            {
                mobileNo = oDS.Tables[0].Rows[0]["mobile_no"].ToString();

            }
        }
        catch
        {

        }
        return mobileNo;
    }

    public static DataTable SelectInfoForSMSByOpportunityId(int opportunityId)
    {
        string mobileNo = string.Empty;
        SqlCommand objCmd = new SqlCommand();
        try
        {
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SelectInfoForSMSByOpportunityId";
            objCmd.Parameters.AddWithValue("@opportunityId", opportunityId);

            DataTable oDS = new DataTable();
            oDS = SFA.DataConnect.GetDataTable(objCmd);
            return oDS;
            //if (oDS != null)
            //{
            //    mobileNo = oDS.Tables[0].Rows[0]["mobile_no"].ToString();

            //}
        }
        catch
        {
            return null;
        }

    }

    public static DataTable SelectInfoForSMSByEnquiryId(int enquiryId)
    {
        string mobileNo = string.Empty;
        SqlCommand objCmd = new SqlCommand();
        try
        {
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SelectInfoForSMSByEnquiryId";
            objCmd.Parameters.AddWithValue("@enquiryId", enquiryId);

            DataTable oDS = new DataTable();
            oDS = SFA.DataConnect.GetDataTable(objCmd);
            return oDS;
            //if (oDS != null)
            //{
            //    mobileNo = oDS.Tables[0].Rows[0]["mobile_no"].ToString();

            //}
        }
        catch
        {
            return null;
        }

    }

}
