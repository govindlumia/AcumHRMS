using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public class General
{
    public General()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void Alert(string msg, Control ctl)
    {
        ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "alert('" + msg + "');", true);
    }

    public static void Alert(string msg, Control ctl, string pageName)
    {
        ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "alert('" + msg + "');window.location.href ='" + pageName + "';", true);
    }

    public static void Confirm(string msg, Control ctl, int res)
    {
        ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "var res = confirm('" + msg + "')", true);
    }

    public static void Alert(string msg, Control ctl, bool _bool)
    {
        ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "alert('" + msg + "');", _bool);
    }
    public static void CloseAlertWindow(Control ctl, string type)
    {
        if (type == "Success")
            ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "close", "window.opener.location.href = window.opener.location.href;self.close();", true);
        else
            ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "close", "self.close();", true);
    }
    public static string DateFormat()
    {
        //return "dd-MMM-yyyy";
        return "MM/dd/yyyy";
    }
    public static string DateTimeFormat()
    {
        return "dd-MMM-yyyy hh:mm tt";
    }


    public static string DateFormatRecruitment()
    {
        return "dd-MMM-yyyy";
    }



    public static int AmountLength()
    {
        return 9;
    }

    public static string[] AcceptedFileTypes()
    {
        string[] acceptedFileTypes = new string[10];
        acceptedFileTypes[0] = ".pdf";
        acceptedFileTypes[1] = ".doc";
        acceptedFileTypes[2] = ".docx";
        acceptedFileTypes[3] = ".jpg";
        acceptedFileTypes[4] = ".jpeg";
        acceptedFileTypes[5] = ".gif";
        acceptedFileTypes[6] = ".png";
        acceptedFileTypes[7] = ".xls";
        acceptedFileTypes[8] = ".xlsx";
        acceptedFileTypes[9] = ".txt";

        return acceptedFileTypes;
    }

    public static int UploadFileLength()
    {
        return 2100000;
    }

    //Return financial Year by Date
    public static string GetFinancialYearByDate(DateTime date)
    {
        int month = date.Month;
        int year = date.Year;
        string FY = string.Empty;

        if (month >= 1 && month <= 3)
        {
            FY = (year - 1).ToString() + "-" + year.ToString();
        }
        else
        {
            FY = year.ToString() + "-" + (year + 1).ToString();
        }
        return FY;
    }

    public static List<string> GetFinancialYearList()
    {
        List<string> lstFY = new List<string>();
        int startYear = 2015;
        int endYear = DateTime.Now.Year;

        for (int i = startYear; i <= endYear; i++)
        {
            lstFY.Add(i.ToString() + "-" + (i + 1).ToString());
        }
        return lstFY;
    }
}

namespace EnumService
{
    public enum ServiceList : int { Bus = 1, Hotel, AirLines, Railway, Taxi };
}
