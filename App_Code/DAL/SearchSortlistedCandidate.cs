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
/// Summary description for SearchSortlistedCandidate
/// </summary>
public class SearchSortlistedCandidate
{
    public SearchSortlistedCandidate()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet SearchSortlistedCan(string serchbyEmployeeid, string SearchByCandidateID, string SearchByFromDate, string SearchByToDate)
    {
        SqlParameter[] para = new SqlParameter[]{
            new  SqlParameter("@Emp",serchbyEmployeeid),
            new  SqlParameter("@CandidateID", SearchByCandidateID),
            new  SqlParameter("@FromDate",SearchByFromDate),
            new SqlParameter ("@ToDate",SearchByToDate)
           
        };
        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SearchApplyedCandidateList", para.ToArray());
        return ds;


    }
}
public class FilterMemberby
{
    public string serchbyEmployeeid
    {
        get;
        set;

    }
    public string SearchByCandidateID
    {
        get;
        set;
    }
    public string SearchFromDate
    {
        get;
        set;
    }
    public string SearchToDate
    {
        get;
        set;
    }
}