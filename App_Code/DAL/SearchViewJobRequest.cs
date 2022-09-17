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
/// Summary description for SearchViewJobRequest
/// </summary>
public class SearchViewJobRequest
{
	public SearchViewJobRequest()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet SearchLobRequest(string serchbyVacancyID, string SearchByBranch, string SearchByFromDate, string SearchByToDate)
    {
        SqlParameter[] para = new SqlParameter[]{
            new  SqlParameter("@VacancyID",serchbyVacancyID),
            new  SqlParameter("@Branch", SearchByBranch),
            new  SqlParameter("@FromDate",SearchByFromDate),
            new SqlParameter ("@ToDate",SearchByToDate)
           
        };
        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SearchViewRequestedVacancy", para.ToArray());
        return ds;


    }
}
public class SearchJobRequestMember
{
    public string serchbyVacancyID
    {
        get;
        set;

    }
    public string SearchByBranch
    {
        get;
        set;
    }
    public string SearchByFromDate
    {
        get;
        set;
    }
    public string SearchByToDate
    {
        get;
        set;
    }
}