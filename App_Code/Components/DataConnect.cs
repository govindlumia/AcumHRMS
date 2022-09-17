using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace SFA
{

    public class DataConnect
    {
        // 
        public static string strConn = ConfigurationManager.ConnectionStrings["SFAConnectionString"].ToString();

        // Creating SqlConnection class object.
        SqlConnection objDBConn = new SqlConnection(DataConnect.strConn);

        // Creating SqlCommand class object.
        static SqlCommand objCmd = new SqlCommand();

        private bool OpenDBConnection()
        {
            try
            {
                Object sysObj = new Object();
                lock (sysObj)
                {
                    if (objDBConn.State == ConnectionState.Closed)
                        // Opening connection to database.
                        objDBConn.Open();

                    // Assigning connection object to command object.
                    objCmd.Connection = objDBConn;
                }
                // Returning true as connection to database established successfully.
                return true;
            }
            catch (Exception e)
            {
                // Error.
                objDBConn.Close();              
                throw e;
            }
        }

        private bool CloseDBConnection()
        {
            try
            {
                if (objDBConn.State == ConnectionState.Open)
                    // Closing connection to database.
                    objDBConn.Close();

                // Destroying command object.
                objCmd.Dispose();

                // Returning true as connection to database closed successfully.
                return true;
            }
            catch (Exception e)
            {
                // Error.
                objDBConn.Close();             
                throw e;
            }
        }

   
        public static long ExecuteSQLQuery(string strSQL, string strSQLType)
        {
            long lngReturnValue = 0;

            Object objNewID = 0;

            DataConnect DT = new DataConnect();

            try
            {                
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Assiging sql query to command object.
                    objCmd.CommandText = strSQL;

                    // Executing sql query.
                    lngReturnValue = objCmd.ExecuteNonQuery();

                    if (strSQLType.ToUpper() == "INSERT")
                    {
                        // Assiging sql query to command object.
                        objCmd.CommandText = "SELECT @@IDENTITY";

                        objNewID = objCmd.ExecuteScalar();

                        if (objNewID != System.DBNull.Value)
                        {
                            lngReturnValue = long.Parse(objNewID.ToString());
                        }
                    }

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // Returning record id or rows affected as sql query executed successfully.
                    return lngReturnValue;
                }
                else
                    // Returning 0 as connection to database not established.
                    return lngReturnValue;
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;                            
                throw e;
            }
        }

        public static int ExecuteSQLQuery(SqlCommand objSqlCommand)
        {
           int intReturnValue = 0;

            Object objNewID = 0;
            DataConnect DT = new DataConnect();
            try
            {                
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Assiging sql query to command object.
                    //objCmd = objSqlCommand;
                    //objCmd.Connection = objDBConn;  
                    objSqlCommand.Connection = DT.objDBConn;
                    // Executing sql query.
                    intReturnValue = objSqlCommand.ExecuteNonQuery();
                  
                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // Returning record id or rows affected as sql query executed successfully.
                    return intReturnValue;
                }
                else
                    // Returning 0 as connection to database not established.
                    return intReturnValue;
            }
            catch (SqlException sqe)
            {
                int count;
                count = sqe.Errors.Count;
                for (int i = 0; i < count; i++)
                {
                    SqlError sqlErr;
                    sqlErr = sqe.Errors[i];
                    if (sqlErr.Number == 547)
                        return intReturnValue;
                    else
                        throw sqe;
                }
                throw sqe;
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;
            }
        }

        public static int ExecuteSQLQuery2(SqlCommand objSqlCommand)
        {
            int intReturnValue = 0;

            Object objNewID = 0;
            DataConnect DT = new DataConnect();
            try
            {
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Assiging sql query to command object.
                    //objCmd = objSqlCommand;
                    //objCmd.Connection = objDBConn;  
                    objSqlCommand.Connection = DT.objDBConn;
                    // Executing sql query.
                    intReturnValue =int.Parse(objSqlCommand.ExecuteScalar().ToString());

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // Returning record id or rows affected as sql query executed successfully.
                    return intReturnValue;
                }
                else
                    // Returning 0 as connection to database not established.
                    return intReturnValue;
            }
            catch (SqlException sqe)
            {
                int count;
                count = sqe.Errors.Count;

                for (int i = 0; i < count; i++)
                {
                    SqlError sqlErr;
                    sqlErr = sqe.Errors[i];
                    if (sqlErr.Number == 547)
                        return intReturnValue;
                    else
                        throw sqe;
                }
                throw sqe;
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;
            }
        }

        public static bool CheckDuplicateValue(string strTableName, string strFieldName, string strValue)
        {
            DataConnect DT = new DataConnect();
            try
            {               
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Creating object of class SqlDataReader to hold the recordset.
                    SqlDataReader objDR;

                    bool bDuplicate = false;
                    string strSQL = "";

                    strSQL = "SELECT " + strFieldName + " FROM " + strTableName + " WHERE " +
                             "UPPER(LTRIM(RTRIM(" + strFieldName + "))) = '" + strValue.Trim().ToUpper() + "'";

                    objCmd.CommandType = CommandType.Text;
                    // Assiging sql query to command object.
                    objCmd.CommandText = strSQL;

                    // Executing sql query and assigning recorset to SqlDataReader object.
                    objDR = objCmd.ExecuteReader();

                    if (objDR.HasRows == true)
                    {
                        // Duplicate value exist.
                        bDuplicate = true;
                    }

                    // Closing DataReader object.
                    objDR.Close();

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    return bDuplicate;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;               
                throw e;
            }
        }

        public static DataSet GetRecordDetails(string strSQL)
        {
            DataConnect DT = new DataConnect();
            try
            {               
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Creating object of DataSet class.
                    DataSet objDS = new DataSet();

                    // Creating object of DataAdapter class and assiging sql query and 
                    // connection object to DataAdapter object.
                    objCmd.CommandText = strSQL;
                    SqlDataAdapter objDA = new SqlDataAdapter(objCmd);

                    // Filling records in DataAdapter object.
                    objDA.Fill(objDS);

                    // Destroying DataAdapter object, releasing memory.
                    objDA.Dispose();

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning DataSet.
                    return objDS;
                }
                else
                {
                    DT.CloseDBConnection();
                    DT = null;
                    // Returning null as connection to database not established. 
                    return null;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;               
            }
        }
        public static DataSet GetDataSet(SqlCommand objCmd)
        {
            DataConnect DT = new DataConnect();
            try
            {

                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    //objCmd.Connection =objDBConn;
                    // Creating object of DataSet class.
                    // DataTable objDT = new DataTable();
                    DataSet objDS = new DataSet();

                    SqlDataReader objDR;

                    objCmd.Connection = DT.objDBConn;
                    // Creating object of DataAdapter class and assiging sql query and 
                    // connection object to DataAdapter object.
                    SqlDataAdapter objDA = new SqlDataAdapter(objCmd);

                    //objDR = objCmd.ExecuteReader();
                    // objDT.Load(objDR);

                    //  DataTable[]  oDataRecord = new DataTable[2] ;//= new DataTable();
                    //DataTable oDataNum = new DataTable();


                    //objDS.Tables.Add(oDataRecords);
                    //  objDS.Tables.Add(oDataNum);

                    //      objDS.Load(objDR, LoadOption.OverwriteChanges, oDataRecord);

                    // Filling records in DataAdapter object.
                    objDA.Fill(objDS);

                    // Destroying DataAdapter object, releasing memory.
                    objDA.Dispose();

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning DataTable.
                    return objDS;
                }
                else
                {
                    // Returning null as connection to database not established. 
                    return null;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;
            }
        }
        public static DataTable GetDataTable(string strSQL)
        {
            DataConnect DT = new DataConnect();
            try
            {                
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Creating object of DataSet class.
                    DataTable objDT = new DataTable();

                    // Creating object of DataAdapter class and assiging sql query and 
                    // connection object to DataAdapter object.
                    objCmd.CommandText = strSQL;
                    SqlDataAdapter objDA = new SqlDataAdapter(objCmd);

                    // Filling records in DataAdapter object.
                    objDA.Fill(objDT);

                    // Destroying DataAdapter object, releasing memory.
                    objDA.Dispose();

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning DataTable.
                    return objDT;
                }
                else
                {
                    // Returning null as connection to database not established. 
                    return null;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;               
                throw e;         
            }
        }

        public static DataTable GetDataTable(SqlCommand objCmd)
        {
            DataConnect DT = new DataConnect();
            try
            {              
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    //objCmd.Connection =objDBConn;
                    // Creating object of DataSet class.
                    DataTable objDT = new DataTable();
                    SqlDataReader objDR;
                    objCmd.Connection = DT.objDBConn;
                    objDR = objCmd.ExecuteReader();
                    objDT.Load(objDR);
                    // Creating object of DataAdapter class and assiging sql query and 
                    // connection object to DataAdapter object.
                    //SqlDataAdapter objDA = new SqlDataAdapter(objCmd);


                    // Filling records in DataAdapter object.
                   // objDA.Fill(objDT);

                    // Destroying DataAdapter object, releasing memory.
                    //objDA.Dispose();

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning DataTable.
                    return objDT;
                }
                else
                {
                    // Returning null as connection to database not established. 
                    return null;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;                
                throw e;                
            }
        }

        public static bool GetFlag(string strSQL)
        {
            DataConnect DT = new DataConnect();
            try
            {                
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    bool bFlag = false;

                    SqlDataReader objDR;

                    objCmd.CommandText = strSQL;

                    objDR = objCmd.ExecuteReader();

                    if (objDR.HasRows == true)
                    {
                        while (objDR.Read())
                        {
                            bFlag = objDR.GetBoolean(0);
                        }
                    }

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning data.
                    return bFlag;
                }
                else
                {
                    // Returning false as connection to database not established. 
                    return false;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;                
                throw e;
            }
        }

        public static bool GetFlag(SqlCommand objSqlCommand)
        {
            DataConnect DT = new DataConnect();
            try
            {                
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    bool bFlag = false;

                    SqlDataReader objDR;

                    objCmd = objSqlCommand;
                    objCmd.Connection = DT.objDBConn;

                    objDR = objCmd.ExecuteReader();

                    if (objDR.HasRows == true)
                    {
                        while (objDR.Read())
                        {
                            bFlag = objDR.GetBoolean(0);
                        }
                    }

                    // Closing database connection.
                    DT.CloseDBConnection();
                    DT = null;

                    // returning data.
                    return bFlag;
                }
                else
                {
                    // Returning false as connection to database not established. 
                    return false;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;
            }
        }

        public static bool CheckDuplicateValueTask(string strTableName, string strFieldName, string strField2, string strValue, string strValue2)
        {
            DataConnect DT = new DataConnect();
            try
            {               
                // Opening database connection.
                if (DT.OpenDBConnection() == true)
                {
                    // Creating object of class SqlDataReader to hold the recordset.
                    SqlDataReader objDR;

                    bool bDuplicate = false;
                    string strSQL = "";

                    strSQL = "SELECT " + strFieldName + " FROM " + strTableName + " WHERE " +
                             "UPPER(LTRIM(RTRIM(" + strFieldName + "))) = '" + strValue.Trim().ToUpper() +
                             "' and UPPER(LTRIM(RTRIM(" + strField2 + "))) = " + strValue2;

                    objCmd.CommandType = CommandType.Text;
                    // Assiging sql query to command object.
                    objCmd.CommandText = strSQL;

                    // Executing sql query and assigning recorset to SqlDataReader object.
                    objDR = objCmd.ExecuteReader();

                    if (objDR.HasRows == true)
                    {
                        // Duplicate value exist.
                        bDuplicate = true;
                    }

                    // Closing DataReader object.
                    objDR.Close();

                    // Closing database connection.
                    DT.CloseDBConnection();

                    return bDuplicate;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                // Error.
                DT.CloseDBConnection();
                DT = null;
                throw e;
            }
        }

        public static DataTable ImportExcel(string strPath, string strSql)
        {
            try
            {
                string tmpConn = strConn;

                //set excel connection string for connection object
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                   "Data Source=" + strPath + ";" +
                                   "Extended Properties=Excel 8.0;";

                //// Opening database connection.
                //if (OpenDBConnection() == true)
                //{
                // Creating object of DataSet class.
                DataTable objDT = new DataTable();

                // Creating object of DataAdapter class and assiging sql query and 
                // connection object to DataAdapter object.
                OleDbDataAdapter objDA = new OleDbDataAdapter(strSql, strConn);

                // Filling records in DataAdapter object.
                objDA.Fill(objDT);

                // Destroying DataAdapter object, releasing memory.
                objDA.Dispose();

                // Closing database connection.
                // CloseDBConnection();

                //set sql connection string for connection object
                strConn = tmpConn;

                // returning DataTable.
                return objDT;
                //}
                //else
                //{
                //    // Returning null as connection to database not established. 
                //    return null;
                //}
            }
            catch (Exception e)
            {
                // Error.
                throw e;
            }
        }

        internal static int ExecuteSQLQuery1(SqlCommand objCmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}