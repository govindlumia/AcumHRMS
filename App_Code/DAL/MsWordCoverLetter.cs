using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for MsWordCoverLetter
/// </summary>
public class MsWordCoverLetter
{
	public MsWordCoverLetter()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }
    public static void Getcoverletter(String Amount, String Name)
    {
        Amount = NumberToWords(Convert.ToInt32(Amount));
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";

        HttpContext.Current.Response.ContentType = "application/msword";

        string strFileName = "BankCoverLetter" + ".doc";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        StringBuilder strHTMLContent = new StringBuilder();
        strHTMLContent.Append(strHTMLContent.Append("<table style='width:100%;font-size:20px;font-family:Times New Roman !important' align='Center'>".ToString()));

        // Row with Column headers
        strHTMLContent.Append("<tr>".ToString()); 
        strHTMLContent.Append("<td style='font-weight:bold;background:# 99CC00' align='left' >To,</td>".ToString());
        strHTMLContent.Append("</tr>".ToString());
        strHTMLContent.Append("<tr>".ToString()); 
        strHTMLContent.Append("<td style='font-weight:bold;background:# 99CC00' align='left'>The Branch Manager</td>".ToString());
        strHTMLContent.Append("</tr>".ToString());
        strHTMLContent.Append("<tr>".ToString()); 
        strHTMLContent.Append("<td style='font-weight:bold;background:# 99CC00' align='left'>Bank Name</td >".ToString());
        strHTMLContent.Append("</tr>".ToString());
        strHTMLContent.Append("<tr>".ToString()); 
        strHTMLContent.Append("<td style='font-weight:bold;background:# 99CC00' align='left'>Bank Address</td >".ToString());
        strHTMLContent.Append("</tr>".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='font-weight:bold;background:# 99CC00' align='left'>Bank Code</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='height:10px' align='left'>&nbsp;</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00' align='left'>Dear Sir,</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='height:10px' align='left'>&nbsp;</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        //===================================MainContent================================================================
        strHTMLContent.Append("<tr style='width:100%'>".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00;text-align:justify'><p style='text-align:justify'>We request you to kindaly credit the salary amount  <b> " + Amount.ToUpper() + " </b> of our staff into their bank accounts. </p></td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='height:20px' align='left'>&nbsp;</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00' align='left'>Date:______</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='height:15px' align='left'>&nbsp;</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00;font-weight:bold' align='left'>Regards,</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00;font-weight:bold' align='left'>Acuminous Software</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00;font-weight:bold' align='left'>Finance Manager</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='height:10px' align='left'>&nbsp;</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<td style='background:# 99CC00;font-weight:bold' align='left'>Seal & Signature</td>".ToString()); strHTMLContent.Append(" </tr> ".ToString());
        strHTMLContent.Append("</table>".ToString());
        HttpContext.Current.Response.Write(strHTMLContent);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();

    }
  
    }
