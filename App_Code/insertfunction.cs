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

/// <summary>
/// Summary description for insertfunction
/// </summary>
public class insertfunction
{
	

    /// <summary>
    /// Returns a string with a given seperator inserted after a specified interval of characters.
    /// </summary>
    /// <param name="input">The original string.</param>
    /// <param name="separator">The separator to insert.</param>
    /// <param name="interval">The number of characters between separators.</param>
    public static string InsertSeparator(string input, string separator, int interval)
    {
        //Validate string
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
}
