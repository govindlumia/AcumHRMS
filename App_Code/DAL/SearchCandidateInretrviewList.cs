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
/// Summary description for SearchCandidateList
/// </summary>
public class SearchCandidateList
{
	public SearchCandidateList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet SearchCandidateInterList(string EmpId,string CandidateId ,string fromDate, string ToDate)
    {

        SqlParameter[] param = new SqlParameter[] { 
        new  SqlParameter("@EmpID",EmpId),
        new SqlParameter ("@CandidateId",CandidateId ),
        new SqlParameter("@FromDate",fromDate ),
        new SqlParameter("@ToDate",fromDate ),
               
        };


        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SearchCanInterview", param.ToArray());

        return ds;

    }
}
public class SearchMemberInterViewList
{
    public string EmpId
    {
        get;
        set;
    }
    public string CandidateId
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