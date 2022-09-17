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
/// Summary description for Functions
/// </summary>
public class CommonClass
{
    public SqlConnection cn;
    SqlDataAdapter adp;
    SqlCommand cmd;
    DataSet ds;
    SqlDataReader dr;
    Int16 rowSaved = 0;
    public static string message = string.Empty;
    public string connectionString;

    public CommonClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void SetConnection()
    {
        //SqlConnection cn;
        connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();

        cn = new SqlConnection(connectionString);
        cn.Open();
    }
    public Int16 SaveInTable(string str)
    {
        Int16 rowSaved;
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = str;
                rowSaved = Convert.ToInt16(cmd.ExecuteNonQuery());
                rowSaved = 1;
            }
            finally
            {
                cn.Close();
            }
        }
        return rowSaved;
    }
    public Boolean CheckValueExist(string tableName, string fieldName, string value)
    {
        string str;
        Int16 rowCount;
        SqlCommand cmd = new SqlCommand();
        str = "Select count(" + fieldName + ") from " + tableName + " where " + fieldName + "='" + value + "'";
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = str;
        try
        {
            cn.Open();
            rowCount = Convert.ToInt16(cmd.ExecuteScalar());
            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        finally
        {
            cn.Close();
        }
    }

    public DataTable GetTableRowsDT(string str)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString()))
        {
            cn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(str, cn);
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable GetTableRowsDT1()
    {
        string str = "select item_code,item_name from item_master";
        connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();
        SqlDataAdapter adp = new SqlDataAdapter(str, cn);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
        //cn.Close();
    }
    public string ChangeFormat(DateTime dtm, string format)
    {
        return dtm.ToString(format);
    }
    public void AddInCombo(string str, DropDownList comboName)
    {
        comboName.Items.Clear();
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString()))
        {
            cn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(str, cn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            int i;
            i = (int)ds.Tables[0].Rows.Count;
            for (int a = 0; a <= i - 1; a++)
            {
                comboName.Items.Add(ds.Tables[0].Rows[a][0].ToString());
            }
            cn.Close();
            //ds.Clear(); 
        }
    }
    public DataSet FillGridData(string str)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString()))
        {
            cn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(str, cn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cn.Close();
            return ds;
        }
    }
    public void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            //  ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    public string FormatData(object input)
    {
        string data = input.ToString();
        data = data.Replace("'", "&rsquo;");
        data = data.Replace(",", "&sbquo;");
        return data;
    }

    public void ReSubmitLocalConveyance(string SNo, string Clarification)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update_Local_ConveyanceMaster";
                cmd.Parameters.AddWithValue("@SNo", SNo);
                cmd.Parameters.AddWithValue("@Clarification", Clarification);
                rowSaved = Convert.ToInt16(cmd.ExecuteNonQuery());
                rowSaved = 1;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public void ReSubmitGeneralConveyance(string SNo, string Clarification, string Type)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update_General_ConveyanceMaster";
                cmd.Parameters.AddWithValue("@SNo", SNo);
                cmd.Parameters.AddWithValue("@Clarification", Clarification);
                cmd.Parameters.AddWithValue("@Type", Type);
                rowSaved = Convert.ToInt16(cmd.ExecuteNonQuery());
                rowSaved = 1;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable UpdateAmountValidation(string Id, decimal Amount)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAmountValidation";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Amount", Amount);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable SelectEmployeeNameByPrefix(string Prefix)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectEmployeeNameByPrefix";
                cmd.Parameters.AddWithValue("@Prefix", Prefix);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable SelectQueryType()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectQueryType";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable SelectProjectType()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectProjectType";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public string SubmitFeedBackForm(string _queryType, string _subject, string _company, string _department, string _location, string _comments, string file, string user)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SubmitFeedBackForm";
                cmd.Parameters.AddWithValue("@queryType", _queryType);
                cmd.Parameters.AddWithValue("@subject", _subject);
                cmd.Parameters.AddWithValue("@company", _company);
                cmd.Parameters.AddWithValue("@department", _department);
                cmd.Parameters.AddWithValue("@location", _location);
                cmd.Parameters.AddWithValue("@comments", _comments);
                cmd.Parameters.AddWithValue("@file", file);
                cmd.Parameters.AddWithValue("@CreatedBy", user);
                return cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable SelectFeedBackResponse(string TicketNumber)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectFeedBackResponse";
                cmd.Parameters.AddWithValue("@Ticket", TicketNumber);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataTable SelectBannerMaster()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectBannerMaster";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataSet SelectBannerMasterDetail(string Id)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectBannerMasterDetail";
                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public DataSet SelectAllBanner()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllBanner";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public string InsertBannerMaster(string EventName, string Number, string CreatedBy)
    {
        string result = string.Empty;

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertBannerMaster";
                cmd.Parameters.AddWithValue("@EventName", EventName);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                result = cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }

        return result;
    }

    public string UpdateBannerMaster(string ID, string EventName, string Number,  string ModifiedBy)
    {
        string result = string.Empty;

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateBannerMaster";
                cmd.Parameters.AddWithValue("@EventName", EventName);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
                cmd.Parameters.AddWithValue("@ID", ID);
                result = cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }

        return result;
    }

    public void InsertBannerDetails(string ID, string fileName)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertBannerDetails";
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@fileName", fileName);
                cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public string DeleteBannerDetails(string ID)
    {
        string result = string.Empty;

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteBannerMasterDetail";
                cmd.Parameters.AddWithValue("@ID", ID);
                result = cmd.ExecuteScalar().ToString();
                cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }
        return result;
    }

    public string DeleteBannerEvent(string ID)
    {
        string result = string.Empty;

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEvent";
                cmd.Parameters.AddWithValue("@ID", ID);
                result = cmd.ExecuteScalar().ToString();
                cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }
        return result;
    }
    public void ActivateDeActivateBannerDetail(string ID)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActivateDeActivateBannerDetail";
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
        }
    }
    public DataTable RatingScale()
    {
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select RatingFrom,RatingTo from [AppraisalRatingMaster] Where Status=1";
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(dt);
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
    }

}
