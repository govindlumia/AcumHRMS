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
/// Summary description for CandidateSaveasDraft
/// </summary>
public class CandidateSaveasDraft
{
	public CandidateSaveasDraft()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet CandidatesaveasDrat(string Name, string FramDate, string Todate)
    {

        SqlParameter[] param = new SqlParameter[] { 
        
        new SqlParameter ("@Name",Name ),
         new  SqlParameter("@FromDate",FramDate),
        new SqlParameter("@ToDate",Todate ),
              
        };


        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SearchGetsaveasdraft", param.ToArray());

        return ds;

    }
}
public class SaveasDraftserchmember
{
    public string Name
    {
        get;
        set;
    }
    public string FramDate
    {
        get;
        set;
    }
    public string Todate
    {
        get;
        set;
    }


}