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
/// Summary description for CloseVacancyListSerch
/// </summary>
public class CloseVacancyListSerch
{
	public CloseVacancyListSerch()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet closeVanList(string ID, string Location, string fromDate, string ToDate)
    {

        SqlParameter[] param = new SqlParameter[] { 
        
        new SqlParameter ("@VacancyID",ID ),
         new  SqlParameter("@Location",Location),
        new SqlParameter("@FromDate",fromDate ),
        new SqlParameter("@ToDate",ToDate ),
       
        };


        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_SerchVacClosedList", param.ToArray());

        return ds;

    }
}
public class SearchMemberforCloseVacList
{
    public string ID
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
    public string Location
    {
        get;
        set;
    }
}