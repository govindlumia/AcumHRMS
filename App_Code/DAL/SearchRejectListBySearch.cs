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
/// Summary description for ViewRejectListBySearch
/// </summary>
public class ViewRejectListBySearch
{
	public ViewRejectListBySearch()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet SearchRejectJobList(string SearchByID, string SearchByLocation, string SearchByFromDate, string SearchByToDate)
    {
        SqlParameter[] para = new SqlParameter[]{
            new  SqlParameter("@VacancyID", SearchByID),
            //new SqlParameter("@VacancyName",SearchByVacancyName),
            new  SqlParameter("@Location",SearchByLocation),
            new SqlParameter ("@FromDate",SearchByFromDate),
            new SqlParameter("@ToDate",SearchByToDate)
        };
        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, CommandType.StoredProcedure, "usp_GetRejectListBySearch", para.ToArray());
        return ds;
    }
   
}
 public class FilterMember
    {
        public string SearchByID
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
        public string SearchByLocation
        {
            get;
            set;
        }
    }