using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.OleDb;

/// <summary>
/// Summary description for CSVReader
/// </summary>
public class CSVReader
{
    DataTable dt;
    public CSVReader()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public System.Data.DataTable GetDataTable(string strFileName, string getFormat)
    {
        //if (getFormat.ToUpper().Equals("CSV") || getFormat.ToUpper().Equals("TXT"))
        //{
        //    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
        //    conn.Open();
        //    string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
        //    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
        //    dt = new System.Data.DataTable("CSV File");
        //    try
        //    {
        //        adapter.Fill(dt);
        //    }
        //    catch {throw;}
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return dt;
        //}
        //else
        if (getFormat.ToUpper().Equals("XLS") || getFormat.ToUpper().Equals("XLSX"))
        {
            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + ";Extended Properties=Excel 5.0";

            OleDbConnection conn = new OleDbConnection(ConnectionString);


            String strQuery = "SELECT * from [Sheet1$]";
            OleDbCommand objCmdSelect = new OleDbCommand(strQuery, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = objCmdSelect;
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        else
        {
            return dt;
        }

    }
}
