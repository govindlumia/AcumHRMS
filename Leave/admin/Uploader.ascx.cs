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

public partial class CustomControl : System.Web.UI.UserControl
{
    //Has the user browsed for a file?
    private bool pGotFile;
    //The file extension of the Posted File
    private string pFileExt;
    //The File itself
    private HttpPostedFile pFilePost;
    //Is the user required to upload an image?
    private bool pRequired;
    //The validation group that the Custom Validator belongs to on the page
    private string pVgroup;
    //Extensions you allow to be uploaded
    private string[] pFileTypeRange;
    //Boolean indicator to check if file extension is allowed
    private bool Ind = false;
    //The Image Minimum Width
    private int maxWidth = 0;
    //The Image Minimum height
    private int maxHeight = 0;
    // The Size of the Image 
    private int maxWeight = 0;
    //file type name
    private string file_name;

    /*
     * Get and Sets for the above private variables.
     * */
    
    
    public bool GotFile
    {
        get { return pGotFile; }
    }
    public string FileExt
    {
        get { return pFileExt; }
    }
    public HttpPostedFile FilePost
    {
        get { return pFilePost; }
    }
    public bool Required
    {
        set { pRequired = value; }
    }
    public string Vgroup
    {
        set { pVgroup = value; }
    }
    public string FileTypeRange
    {
        set { pFileTypeRange = value.ToString().Split(','); }
    }
    public int MaxWidth
    {
        set { maxWidth = value; }
    }
    public int MaxHeignt
    {
        set { maxHeight = value; }
    }
    public int MaxWeight
    {
        set { maxWeight = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //here we assign the validation group to the Custom Validator, which I have inefficiently named ErrorMsg
        ErrorMsg.ValidationGroup = pVgroup;
    }

    protected void ErrorMsg_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (FilUpl.HasFile)
        {
            pGotFile = true;
            pFileExt = GetExtension(FilUpl.PostedFile.FileName);
            pFilePost = FilUpl.PostedFile;
            string check = "";
            foreach (string str in pFileTypeRange)
            {
                if (str == pFileExt)
                {
                    Ind = true;
                }
                else
                {
                    if (check == "")
                    {
                        check = "." + str;
                    }
                    else
                    {
                        check = check + ",." + str;
                    }
                }
            }

            if (!Ind)
            {
                //file_name

                args.IsValid = false;
                ErrorMsg.Text = "Only file format " + check + " will be supportable . ";//"The file format " + pFileTypeRange.ToString() + " will only supported";
                //Stop the function
                return;
            }

            if ((maxWidth  > 0) && (maxHeight > 0))
            {
                //If you get here then you have set the MinWidth because you are expecting an image,
                //and due to validation once at this stage in the code, we know that the user has uploaded
                //some sort of image type
                System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
                if ((CheckSize.PhysicalDimension.Width > maxWidth) && (CheckSize.PhysicalDimension.Height > maxHeight))
                {
                    args.IsValid = false;
                    ErrorMsg.Text = "Your image does not meet the Max width " + maxWidth.ToString() +"px and Max Height " + maxHeight.ToString() +"px .";
                    //Stop the function
                    return;
                }
            }
            if (maxWeight > 0) 
            {
                //If you get here then you have set the MinWidth because you are expecting an image,
                //and due to validation once at this stage in the code, we know that the user has uploaded
                //some sort of image type
                //System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
                int File_Weight = FilUpl.PostedFile.ContentLength;

                if (File_Weight >= maxWeight)
                {
                    args.IsValid = false;
                    float dip = (maxWeight / 1048576);
                    ErrorMsg.Text = "The Size is Maximum " + dip.ToString() + " Mb.";
                    //Stop the function
                    return;
                }
            }


        }
        else
        {
            //So if we get here the user has not browsed for a file
            pGotFile = false;
            //If you have stated that the user has to browse for a file.
            //then we must stop now and inform the user of such.
            if (pRequired)
            {
                args.IsValid = false;
                ErrorMsg.Text = "You must upload something";
            }
        }
    }
    /// <summary>
    /// This returns the file extension.  It does not contain the preceding full stop
    /// so it would return jpg and NOT .jpg . Please adjust your coding accordingly.
    /// </summary>
    /// <param name="FileName">string</param>
    /// <returns>string: the file extension e.g. jpg</returns>
    private string GetExtension(string FileName)
    {
        string[] split = FileName.Split('.');
        string Extension = split[split.Length - 1];
        return Extension.ToLower();
    }
}
