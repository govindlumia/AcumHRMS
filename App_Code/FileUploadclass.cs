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
/// Summary description for FileUpload
/// </summary>
public class FileUploadclass
{
    public FileUploadclass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int fileUploadfunction(string folder, FileUpload FileUpload1)
    {
        int i = 0;
        if (FileUpload1.FileName != string.Empty)
        {
            string filepath = string.Empty;
            Random nn = new Random();
            string rt = nn.Next(2998, 25678).ToString();
            filepath = rt + "_" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(folder + "/") + filepath);
            i = 1;
            return i;
        }
        else
        {
            return i;
        }
    }
}
