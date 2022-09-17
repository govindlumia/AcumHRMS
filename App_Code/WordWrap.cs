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
using System.Text.RegularExpressions;

public class WordWrap
{
    public WordWrap()
    {

    }

    public static string StringWordWrap(string input, string separator, int interval)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        List<char> outputChars = new List<char>(input.ToCharArray());
        char[] separatorChars = separator.ToCharArray();

        int i = interval;
        while (i < outputChars.Count)
        {
            if (i != outputChars.Count) //don't add separator to the end of string
                outputChars.InsertRange(i, separatorChars);

            i += interval + separator.Length; //go up the interval amount plus separator
        }

        return new string(outputChars.ToArray());
    }


    public static string RemoveMultipleSpace(string input)
    {
        string result = string.Empty;
        Regex r = new Regex(@"\s+");
        result = r.Replace(input, @" ");
        return result;
    }
}
