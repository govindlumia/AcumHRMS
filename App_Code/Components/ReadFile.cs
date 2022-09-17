using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Summary description for ReadFile
/// </summary>
/// 
namespace FileRead
{
    public class ReadFile
    {
        public ReadFile()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string readTextFile1(string path)
        {
            //Method 1       

            //Load the file contents
            StreamReader textFile = new StreamReader(path);
            string fileContents = textFile.ReadToEnd();
            textFile.Close();

            //Find the number of lines
            StringReader reader = new StringReader(fileContents);
            int lineCount = 0;
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }
            lineCount--;

            //Now read the file line by line
            reader = new StringReader(fileContents);
            string outputText = "";
            for (int i = 0; i <= lineCount; i++)
            {
                outputText += reader.ReadLine() + Environment.NewLine;
            }
            //This may seem redudant, but here is where you would do any line-by-line processing
            //In this case we do nothing so it seems uneccessary.

            return outputText;
        }
    }
}