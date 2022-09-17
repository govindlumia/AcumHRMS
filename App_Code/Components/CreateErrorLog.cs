using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public class CreateErrorLog
{


    //private static int _ErrorId;

    //public static int ErrorId
    //{
    //    get { return _ErrorId; }
    //    set { _ErrorId = value; }
    //}

    //public static string ReportErrorToLog(Exception ex)
    //{
    //    try
    //    {
    //        Exception exc = ex.GetBaseException();

    //        if (exc == null)
    //            exc = ex.InnerException;


    //        SqlCommand objCmd = new SqlCommand();
    //        string strFileName, strContents, strSQL;
    //        string strQueryString = "";
    //        string[] strTmp;
    //        string strCookies = "";
    //        string[] strTmpCookie;

    //        strTmp = HttpContext.Current.Request.QueryString.AllKeys;
    //        for (int i = 0; i < strTmp.Length ; i++)
    //        {
    //            strQueryString += strTmp[i] + ",";
    //        }

    //        strTmpCookie = HttpContext.Current.Request.Cookies.AllKeys;
    //        for (int i = 0; i < strCookies.Length; i++)
    //        {
    //            strCookies += strTmpCookie[i] + ",";
    //        }

    //        BE.User oUser;
    //        if (HttpContext.Current.Session["oUser"] != null)
    //            oUser = (BE.User)HttpContext.Current.Session["oUser"];
    //        else
    //            oUser = new BE.User("Undefined");

          
    //        //Getting file name for reading & writing.
    //        strFileName = System.Web.HttpContext.Current.Server.MapPath("..\\ErrorLog\\ErrorLog["+System.DateTime.Now.ToString("MMM dd, yyyy")+"].html");

    //        //Getting old contents of error log and appending to end of error log.
    //        strContents = "<B>ERROR : </B>" + exc.Message.ToString() + "<BR>";
    //        strContents += "<B>Page Name : </B>" + HttpContext.Current.Request.Url.ToString() +"<BR>";
    //        strContents += "<B>QueryString : </B>" + strQueryString +"<BR>";
    //        strContents += "<B>Client IP Address : </B>" + HttpContext.Current.Request.ServerVariables.Get("REMOTE_ADDR").ToString() +"<BR>";
    //        strContents += "<B>UserName : </B>" + oUser.UserName + "<BR>";
    //        strContents += "<B>Method : </B>" + exc.TargetSite.Name.ToString() + "<BR>";
    //        strContents += "<B>Time Of Occurence : </B>" + System.DateTime.Now.ToString() + "<BR>";
    //        strContents += "<B>Stack Trace : </B>" + exc.StackTrace.ToString() + "<BR>";
    //        strContents += "<B>Target Site : </B>" + exc.TargetSite + "<BR>";
    //        strContents += "<B>Source : </B>" + exc.Source + "<BR>";
    //        strContents += "<B>Machine Name : </B>" + Environment.MachineName + "<BR>";
    //        strContents += "<B>Type : </B>" + exc.GetType() + "<BR>";
    //        strContents += "<B>Domain : </B>" + AppDomain.CurrentDomain + "<BR>";
    //        strContents += "<B>Thread Id : </B>" + AppDomain.GetCurrentThreadId() + "<BR>";
    //        strContents += "<B>Query String : </B>" + strQueryString + "<BR>";
    //        strContents += "<B>Cookies : </B>" + strCookies + "<BR>";
    //        strContents += "<BR><BR>" + ReadErrorLog(strFileName);
            
            


    //        //Writing new error to error log.
    //        WriteErrorLog(strFileName, strContents);

    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "uspLogError";
    //        objCmd.Parameters.Add("@ErrorId", SqlDbType.Int).Direction = ParameterDirection.Output;
    //        objCmd.Parameters.AddWithValue("@Error", exc.Message.ToString());
    //        objCmd.Parameters.AddWithValue("@Url", HttpContext.Current.Request.Url.ToString());
    //        objCmd.Parameters.AddWithValue("@IP", HttpContext.Current.Request.ServerVariables.Get("REMOTE_ADDR").ToString());
    //        objCmd.Parameters.AddWithValue("@User", oUser.UserName);
    //        objCmd.Parameters.AddWithValue("@Method", exc.TargetSite.Name.ToString());
    //        objCmd.Parameters.AddWithValue("@TargetSite", exc.TargetSite.ToString());
    //        objCmd.Parameters.AddWithValue("@Date", System.DateTime.Now.ToString());
    //        objCmd.Parameters.AddWithValue("@Trace", exc.StackTrace.ToString());
    //        objCmd.Parameters.AddWithValue("@Source", exc.Source);
    //        objCmd.Parameters.AddWithValue("@Machine", Environment.MachineName);
    //        objCmd.Parameters.AddWithValue("@Type", exc.GetType().ToString());
    //        objCmd.Parameters.AddWithValue("@Domain", AppDomain.CurrentDomain.ToString());
    //        objCmd.Parameters.AddWithValue("@Thread", AppDomain.GetCurrentThreadId().ToString());
    //        objCmd.Parameters.AddWithValue("@Cookies", strCookies);
    //        objCmd.Parameters.AddWithValue("@QueryString", strQueryString);
    //        objCmd.Parameters.AddWithValue("@Module", "PMS");

    //        Mosaic.DataConnect.ExecuteSQLQuery(objCmd);

    //        if (objCmd.Parameters["@ErrorId"] != null)
    //            _ErrorId = int.Parse(objCmd.Parameters["@ErrorId"].Value.ToString());

    //        return strContents;
     

    //    }
    //    catch (Exception e)
    //    {
    //        return "";
    //    }
    //}
  
    //private static string ReadErrorLog(string strFileName)
    //{

    //    string strContent;

    //    //Get a FileStream class object to create a file.
    //    FileStream objFileStream;
    //    //Get a StreamReader class object that can be used to read the file.
    //    StreamReader objStreamReader;

    //    //Checking for file existence.
    //    if (File.Exists(strFileName) == true)
    //    {

    //        //Setting StreamReader class object to read the file.
    //        objStreamReader = File.OpenText(strFileName);

    //        //Reading entire file.
    //        strContent = objStreamReader.ReadToEnd();

    //        //Closing StreamReader class object.
    //        objStreamReader.Close();
    //    }
    //    else
    //    {
    //        //Setting StreamReader class object to create the file.
    //        objFileStream = File.Create(strFileName);

    //        //Closing FileStream class object.
    //        objFileStream.Close();

    //        strContent = "";
    //    }

    //    return strContent;


    //}

    //private static void WriteErrorLog(string strFileName, string strContents)
    //{

    //    //Get a StreamWriter class object that can be used to write to error log.
    //    StreamWriter objStreamWriter;

    //    //Setting StreamWriter class object to write the file.
    //    FileStream fs= File.Create(strFileName);
        
    //    objStreamWriter = new StreamWriter(fs);
        

    //    //Writing contents to error log.
    //    objStreamWriter.Write(strContents);

    //    //Close the stream
    //    objStreamWriter.Close();

    //}


}

