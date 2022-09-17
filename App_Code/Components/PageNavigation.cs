
using System.Web.UI.WebControls;
/// <summary>
/// SD : This will class will contain functions and properties releated to Navigation and Others.
/// </summary>
public class PageNavigation
{
    public static string strErrorMessage = "An error has occured while your request.<br>Message is sent to the techinical person for the same.";

    /// <summary>
    /// SD : Property is placed to hold previously loaded page URL.    
    /// </summary>
    private static string strNavigationURL;
    private static string _RedirectURL = "~/Default.aspx";
    private static string _CurrentNavigationURL;
    private static string _NextNavigationURL;
    private static string strTotalrecords;

    /// <summary>
    /// SD : Property to set NavigationURL.
    /// </summary>
    public static string NavigationURL
	{
		get { return strNavigationURL;}
		set { strNavigationURL = value;}
	}

    /// <summary>
    /// SD : Property to set NavigationURL.
    /// </summary>
    public static string Totalrecords
    {
        get { return strTotalrecords; }
        set { strTotalrecords = value; }
    }


    /// <summary>
    /// SD : This property is used to redirect unauthenticated users to login
    /// </summary>
    public static string  RedirectURL
    {
        get { return _RedirectURL; }
    }


    /// <summary>
    /// SD : Property to set CurrentNavigationURL.
    /// </summary>
    public static string CurrentNavigationURL
    {
        get { return _CurrentNavigationURL; }
        set { _CurrentNavigationURL = value; }
    }

    ///<summary>
    ///SD : Property that returns the url to navigate next.
    /// <summary>
    public static string NextNavigationURL
    {
        get { return _NextNavigationURL; }
        set { _NextNavigationURL = value; }
    }
  
    private static string _CurrentIPAddress;

    /// <summary>
    /// SD : Local machine's Ip address for error log
    /// </summary>
    public static string CurrentIPAddress
    {
        get { return _CurrentIPAddress; }
        set { _CurrentIPAddress = value; }
    }

    /// <summary>
    /// SD : Function to set page count.
    /// </summary>
    /// <param name="lblPageCount"></param>
    /// <param name="grdView"></param>
    /// <param name="intTotalRows"></param>
    public static void PageCount(Label lblPageCount, GridView grdView, int intTotalRows)
    {
        int intPageSize = grdView.PageSize;
        int intCurrentPage = grdView.PageIndex + 1;

        int intRowCount = grdView.Rows.Count;
        int intFrom = (intCurrentPage) * (intPageSize) - (intPageSize - 1);
        int intTo = intFrom + (grdView.Rows.Count - 1);
        int i = grdView.PageIndex + 1;
        lblPageCount.Text = "[Page " + i.ToString() + " of " + grdView.PageCount.ToString() + "]/[ Showing records " + intFrom.ToString() + " - " + intTo.ToString() + " of " + intTotalRows.ToString() + " records.]";
    }
    
    private static string  _strSortField;

    public static  string SortField
    {
        get { return _strSortField; }
        set { _strSortField = value; }
    }
    private static string  _strSortDir;

    public static  string  SortDir
    {
        get { return _strSortDir; }
        set { _strSortDir = value; }
    }
	

    public static void SetSortParam(LinkButton lnkBtn)
    {
       // string sortField = "", sortDir = "";
        string str1 = "";
        str1 = lnkBtn.CommandName;
        if (str1.IndexOf(" DESC") > -1)
        {
            lnkBtn.CommandName = str1.Substring(0, str1.IndexOf(" DESC"));
           // SortFi
           _strSortField  = str1.Substring(0, str1.IndexOf(" DESC"));
            _strSortDir = "ASC";
        }
        else
        {
            lnkBtn.CommandName = str1 + " DESC";
            _strSortField = str1;
            _strSortDir = "DESC";
        }
    }

    public static void SetSortParam(HiddenField hdnField)
    {
        // string sortField = "", sortDir = "";
        string str1 = "";
        str1 = hdnField.Value;
       // str1 = lnkBtn.CommandName;
        if (str1.IndexOf(" ASC") > -1)
        {
            hdnField.Value = str1.Substring(0, str1.IndexOf(" ASC"));
            //lnkBtn.CommandName = str1.Substring(0, str1.IndexOf(" DESC"));
            // SortFi
            _strSortField = str1.Substring(0, str1.IndexOf(" ASC"));
            _strSortDir = "DESC";
        }
        else
        {
            hdnField.Value = str1 + " ASC";
           // lnkBtn.CommandName = str1 + " DESC";
            _strSortField = str1;
            _strSortDir = "ASC";
        }
    }
}

