using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DTUtility;
using QueryStringEncryption;
using System.IO;
using HRMS.DataAccessLayer;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CandidateApprovedList
/// </summary>
public class CandidateApprovedList
{
	public CandidateApprovedList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet ApprovedList(string CandiateID, string fromDate, string ToDate)
    {

        SqlParameter[] param = new SqlParameter[] { 
        
        new SqlParameter ("@CandidateID",CandiateID ),
        new SqlParameter("@FromDate",fromDate ),
        new SqlParameter("@ToDate",ToDate ),
       
        
        };


        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SerchbyApprovedCandidateList", param.ToArray());

        return ds;

    }
}
public class CandidateSearchMember
{
    public string CandiateID
    {
        get;
        set;
    }
    public string fromDate
    {
        get;
        set;
    }
    public string ToDate
    {
        get;
        set;
    }
   
}