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
/// Summary description for VacancyApprovedList
/// </summary>
public class VacancyApprovedList
{
	public VacancyApprovedList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet ApprovedVacanList(string ID, string fromDate, string ToDate, string Location)
    {

        SqlParameter[] param = new SqlParameter[] { 
        
        new SqlParameter ("@VacancyID",ID ),
        new SqlParameter("@FromDate",fromDate ),
        new SqlParameter("@ToDate",ToDate ),
        new  SqlParameter("@Location",Location)
        
        };


        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_GetVacApprovedList", param.ToArray());

        return ds;

    }
   
}
 public class SearchMemberApprovedList
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