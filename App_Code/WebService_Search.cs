using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;
using querystring;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for WebService_Search
/// </summary>
/// 
[System.Web.Script.Services.ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService_Search : System.Web.Services.WebService {

    public WebService_Search () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

  
[WebMethod]
 public string[] GetCityInfo(string prefixText)
  {
       DataSet ds=new DataSet();
        DataTable dt = new DataTable(); 
     int count = 10;
     SqlParameter sqlpc = new SqlParameter("@CityName", SqlDbType.NVarChar, 150);
     sqlpc.Value = prefixText.Trim();
     string sql = @"select CityCode,CityName from tblCityMaster where CityName like @CityName + '%'";
     ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["gskConnectionString"].ToString(), CommandType.Text, sql, sqlpc);
     string[] items = new string[ds.Tables[0].Rows.Count];
     int i = 0;
     foreach (DataRow dr in ds.Tables[0].Rows) 
     {
         items.SetValue(dr["CityName"].ToString() + " | " + dr["CityCode"].ToString(), i); 
         i++; 
     } 
     return items; 
  } 
    
}

