using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsExpenseClaimFF
/// </summary>
public class clsExpenseClaimFF
{
	public clsExpenseClaimFF()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertInjuryEntry( ArrayList HOSPITALIZATION)
    {
        int Error = 0;
        int Series = 0;
       
       string conStr = ConfigurationManager.ConnectionStrings["gskConnectionString"].ToString();
       SqlConnection Connection = new SqlConnection(conStr);
        SqlTransaction Transaction = null;
        try
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            Transaction = Connection.BeginTransaction();
            
                foreach (Hashtable ht1 in HOSPITALIZATION)
                {

                    SqlCommand cmd2 = new SqlCommand("sp_insert_plan_details", Connection);
                   
                    cmd2.Parameters.AddWithValue("@PlanCode", String.IsNullOrEmpty(ht1["PlanCode"].ToString()) ? System.DBNull.Value : ht1["PlanCode"]);
                    cmd2.Parameters.AddWithValue("@StartDate", String.IsNullOrEmpty(ht1["StartDate"].ToString()) ? System.DBNull.Value : ht1["StartDate"]);
                    cmd2.Parameters.AddWithValue("@EndDate", String.IsNullOrEmpty(ht1["EndDate"].ToString()) ? System.DBNull.Value : ht1["EndDate"]);
                    cmd2.Parameters.AddWithValue("@FromLocation", String.IsNullOrEmpty(ht1["FromLocation"].ToString()) ? System.DBNull.Value : ht1["FromLocation"]);
                    cmd2.Parameters.AddWithValue("@ToLocation", String.IsNullOrEmpty(ht1["ToLocation"].ToString()) ? System.DBNull.Value : ht1["ToLocation"]);
                    cmd2.Parameters.AddWithValue("@Market", String.IsNullOrEmpty(ht1["Market"].ToString()) ? System.DBNull.Value : ht1["Market"]);
                    cmd2.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ht1["ContactNo"].ToString()) ? System.DBNull.Value : ht1["ContactNo"]);
                    cmd2.Parameters.AddWithValue("@CreatedBy", String.IsNullOrEmpty(ht1["CreatedBy"].ToString()) ? System.DBNull.Value : ht1["CreatedBy"]);
                    cmd2.Parameters.AddWithValue("@Status ", String.IsNullOrEmpty(ht1["Status"].ToString()) ? System.DBNull.Value : ht1["Status"]);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Transaction = Transaction;
                    cmd2.ExecuteNonQuery();
                }
            
            Transaction.Commit();
            Error = 1;
        }
        catch (Exception ex)
        {
            Transaction.Rollback();

        }
        finally
        {
            Connection.Dispose();
        }
        return Error;

    }
    public int InsertUpdatedDetailsOf_FF(ArrayList HOSPITALIZATION)
    {
        int Error = 0;
        int Series = 0;

        string conStr = ConfigurationManager.ConnectionStrings["gskConnectionString"].ToString();
        SqlConnection Connection = new SqlConnection(conStr);
        SqlTransaction Transaction = null;
        try
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            Transaction = Connection.BeginTransaction();

            foreach (Hashtable ht1 in HOSPITALIZATION)
            {

                SqlCommand cmd2 = new SqlCommand("sp_Update_Plan_ForFF", Connection);
                    

                cmd2.Parameters.AddWithValue("@id", String.IsNullOrEmpty(ht1["id"].ToString()) ? System.DBNull.Value : ht1["id"]);
                cmd2.Parameters.AddWithValue("@DepDate", String.IsNullOrEmpty(ht1["StartDate"].ToString()) ? System.DBNull.Value : ht1["StartDate"]);
                cmd2.Parameters.AddWithValue("@ArrDate", String.IsNullOrEmpty(ht1["EndDate"].ToString()) ? System.DBNull.Value : ht1["EndDate"]);
                cmd2.Parameters.AddWithValue("@TourFrom", String.IsNullOrEmpty(ht1["FromLocation"].ToString()) ? System.DBNull.Value : ht1["FromLocation"]);
                cmd2.Parameters.AddWithValue("@TourTo", String.IsNullOrEmpty(ht1["ToLocation"].ToString()) ? System.DBNull.Value : ht1["ToLocation"]);
                cmd2.Parameters.AddWithValue("@AllowanceType", String.IsNullOrEmpty(ht1["Market"].ToString()) ? System.DBNull.Value : ht1["Market"]);
                cmd2.Parameters.AddWithValue("@Remark", String.IsNullOrEmpty(ht1["ContactNo"].ToString()) ? System.DBNull.Value : ht1["ContactNo"]);
                
                
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Transaction = Transaction;
                cmd2.ExecuteNonQuery();
            }

            Transaction.Commit();
            Error = 1;
        }
        catch (Exception ex)
        {
            Transaction.Rollback();

        }
        finally
        {
            Connection.Dispose();
        }
        return Error;

    }
    #region "DML Statement"
    public int executeNonQuery(string SqlQuery)
    {
        object obj = null;
        int result = 0;

        string conStr = ConfigurationManager.ConnectionStrings["gskConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand(SqlQuery, connection);
        SqlTransaction Trans = null;
        cmd.CommandType = CommandType.Text;
        try
        {
            connection.Open();
            Trans = connection.BeginTransaction();
            cmd.Transaction = Trans;
            obj = cmd.ExecuteNonQuery();
            Trans.Commit();
            result = 1;
        }
        catch (SqlException ex)
        {
            Trans.Rollback();
            result = -1;
            throw (ex);
        }
        catch (Exception ex)
        {
            Trans.Rollback();
            result = -1;
            throw (ex);
        }
        finally
        {
            connection.Dispose();
            cmd.Dispose();
        }
        return result;
    }
    #endregion
    #region "Execute Scalar for single object"
    ///Without Param
    public string getSingleObject(string SqlQuery)
    {
        object obj = null;
        string conStr = ConfigurationManager.ConnectionStrings["gskConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand(SqlQuery, connection);

        try
        {
            connection.Open();
            obj = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            cmd.Dispose();
            connection.Dispose();
        }
        return obj == null ? "" : obj.ToString();
    }
    ///With Parameter
   
    #endregion
   
}
