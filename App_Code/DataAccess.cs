using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;


public class DataAccess
{
    public static IList<Product> GetProducts(string criteria)
    {
        List<Product> list = new List<Product>();

        string conn = "Server=72.18.135.251,1533;Database=myjakartaglobe;Trusted_Connection=true";
        string query = "SELECT distinct * FROM UserProfiles WHERE UserName LIKE @Criteria + '%'";

        using (SqlConnection myConnection = new SqlConnection(conn))
        {
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@Criteria", criteria);

            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductName = reader["UserName"] as String;

                list.Add(product); 
            }

            myConnection.Close();
            myCommand.Dispose();
            reader.Close();
        }

        return list;         
    }
}
