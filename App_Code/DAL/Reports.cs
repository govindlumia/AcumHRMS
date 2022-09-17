using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Reports
/// </summary>


namespace Reports
{
    public class Reports
    {
        public Reports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable SearchQuantityItem(int option)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.CommandText = "SFA_usp_SearchProductQuantity";
                objCmd.Parameters.AddWithValue("@option", option);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    //    DataColumn RecordCount = new DataColumn("RecordCount");
                    //    oData.Columns.Add(RecordCount);
                    //    if (oData.Rows.Count > 0)
                    //    {
                    //       //oData.Rows[0]["RecordCount"] = oDS.Tables[0].Rows[0][0].ToString();
                    //    }
                }
            }
            catch
            {

            }
            return oData;
        }

        /// <summary>
        /// Gives the list of all organization with creation information
        /// </summary>
        /// <returns>Returning DataTable object.</returns>
        public static DataTable SearchOrgnizationWithCreationInfo(string strSortField, string strSortDir, int pageSize, int pageNum, string ColList, string Keywords, string Alphabet, string CreatedBy, string AssignTo, string AssignToOrCreatedBy)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SearchOrgnizationWithCreationInfo";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@ColList", ColList.ToString());
                objCmd.Parameters.AddWithValue("@Keywords", Keywords);
                objCmd.Parameters.AddWithValue("@Alphabet", Alphabet);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@AssignToOrCreatedBy", AssignToOrCreatedBy);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

    }
}
