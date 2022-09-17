using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UesrLogin
/// </summary>
/// 
namespace DAL
{
    public class UesrLogin
    {
        public UesrLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable login(string userid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_getEmployeeLogin";
                objCmd.Parameters.AddWithValue("@LoginId", userid);
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }
    }
}
