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
using System.Data.SqlClient;
using DataAccessLayer;
using Utilities;
public partial class Leave_admin_updateholiday : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bindholiday();
        }
    }

    //----------------------------Add year in the Dropdownlist----------------------------

    public void Year()
    {
        ddlyear.Items.Clear();
        ddlyear.Items.Add(new ListItem("Select"));

        for (int yr = 2009; yr < 2020; yr++)
        {
            ddlyear.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }

    //protected void ddlbranch_DataBound1(object sender, EventArgs e)
    //{
    //    ddlbranch.Items.Insert(0, new ListItem("Select", "0"));
    //}

    public void bindholiday()
    {
        sqlstr = "SELECT holidayid,year,name,detail,(CASE WHEN date='01/01/1990' THEN '' ELSE  date END)date FROM tbl_leave_holiday WHERE holidayid=" + Request.QueryString["holidayid"].ToString() + "";
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Year();
        ddlyear.SelectedValue = ds.Tables[0].Rows[0]["year"].ToString();      
        txtholiday.Text = ds.Tables[0].Rows[0]["name"].ToString();
        txtdetail.Text = ds.Tables[0].Rows[0]["detail"].ToString();
        txtdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"].ToString()).ToString("dd-MMM-yyyy");             
    }

    //--------------------------------Clearing Fields------------------------------------

    protected void clearfield()
    {
        ddlyear.SelectedIndex = 0;
        txtholiday.Text = "";
        txtdetail.Text = "";
        txtdate.Text = "";
    }
       
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["holidayid"]);

        bl_navigation.update_holiday_master(id, ddlyear.SelectedItem.Text.ToString(), txtholiday.Text.ToString(), txtdetail.Text.ToString(), Utility.DateTimeForat(txtdate.Text.ToString()), Session["name"].ToString(), ref i);

                   Response.Redirect("editholiday.aspx?updated=true");
       
        clearfield();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("editholiday.aspx");
    }
}