using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UtilMethods
/// </summary>
public static class UtilMethods
{
    //public static UtilMethods()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public static string ConvertDateTimeddmmyyyy(object strDate)
    {
       // DateTime date = Convert.ToDateTime(strDate);
       //return date.ToString("dd/MM/yyyy");
        DateTime theDate;

        // Attempt to cast object to DateTime
        try
        {
            theDate = (DateTime)strDate;
            return theDate.ToString("dd/MM/yyyy");
        }
        catch (Exception)
        {
            // Do something with failed conversion here, throw for example
            throw;
        }
    }

    public static string ConvertDateTimeddmmmmyyyy(object strDate)
    {
        // DateTime date = Convert.ToDateTime(strDate);
        //return date.ToString("dd/MM/yyyy");
        DateTime theDate;

        // Attempt to cast object to DateTime
        try
        {
            theDate = (DateTime)strDate;
            return theDate.ToString("dd-MMM-yyyy");
        }
        catch (Exception)
        {
            // Do something with failed conversion here, throw for example
            throw;
        }
    }

    public static string ConvertToDecimelUptoZero(object value)
    {
        return Math.Round(Convert.ToDecimal(value), 0).ToString();
    }
}