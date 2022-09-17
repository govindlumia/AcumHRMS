using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for SendSMS
/// </summary>
public class SendSMS
{
	public SendSMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void sendMessage(string mobile_no, string taskDescription)
    {
        try
        {
            if (mobile_no != null && mobile_no != "")
            {
                //comment regarding strUrl                
                //smsgateway-http://prpsms.mobi/sendurlcomma.asp
                //user=hello20031598
                //pwd=demo123
                //senderid=ABC
                //Tested code to send the sms start
                //http://prpsms.mobi/sendurlcomma.asp?user=*20041030*&pwd=*u3aggt*&senderid=ABC&mobileno=9810647691&msgtext=HelloTestMessage.
                //Tested code to send the sms end

                string strUrl = "Just De-comment this code.";// "http://prpsms.mobi/sendurlcomma.asp?user=*20041030*&pwd=*u3aggt*&senderid=ABC&mobileno=" + mobile_no + "&msgtext=" + taskDescription + "";
                
                WebRequest request = HttpWebRequest.Create(strUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
                response.Close();
                s.Close();
                readStream.Close();
            }
        }
        catch (System.Exception ex)
        {
            //str = ex.Message;
            //lblresult.Text = str;
        }
    }
}
