using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for GenerateOrgCode
/// </summary>
/// 
namespace DAL
{
    public class GenerateOrgCode
    {
        public GenerateOrgCode()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public static string RandomString(int size, bool Uppercase)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Random random = new Random();
        //    char ch;
        //    for (int i = 0; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }
        //    if (Uppercase)
        //        return builder.ToString().ToUpper();
        //    return builder.ToString();
        //}
        public static int RandomNumber(int min) //, int max
        {
            min = 1000;
            Random random = new Random();
            return random.Next(min); // , max

        }
        public static string GetProductCode(int min) //, int max, int size, bool UpperCase
        {
            
            StringBuilder   builder = new StringBuilder();
            //builder.Append(RandomString(size, UpperCase));
            builder.Append(RandomNumber(min));//, max
            while ( ValidateProductCode(builder.ToString()))
            {
                builder = new StringBuilder();
               // builder.Append(RandomString(size, UpperCase));
                builder.Append(RandomNumber(min));//, max
            }
            return builder.ToString();
        }

        public  static int GetMaxOrganizationId()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "GetMaxOrgDetailId";
              
              return Convert.ToInt32(SFA.DataConnect.GetDataTable(objCmd).Rows[0][0]) + 1;

            }
            catch
            {
                return -1;
            }
           
        }

        public static bool ValidateProductCode(string OrgId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_OrganizationDetail where OrganizationCode = '" + OrgId + "'";
                //oData = SFA.DataConnect.GetDataTable(objCmd);
                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if(oDS != null)
                {
                    oData = oDS.Tables[0];
                DataColumn RecordCount = new DataColumn("RecordCount");
                oData.Columns.Add(RecordCount);
                if (oData.Rows.Count >= 1)
                {
                    
                    oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            }
            catch { }

            return Convert.ToBoolean(oData);
        }

    }
}
