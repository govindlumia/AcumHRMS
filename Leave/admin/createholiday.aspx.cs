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
public partial class Leave_admin_create_holiday : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    DataSet ds = new DataSet();
    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            txtdate.Attributes.Add("readonly", "readonly");
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            Year();
        }
    }

    //------------------------------Add year in the Dropdownlist-----------------------------------

    public void Year()
    {
        ddlyear.Items.Clear();
        ddlyear.Items.Add(new ListItem("Select"));

        for (int yr = 2009; yr < 2020; yr++)
        {
            ddlyear.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }

    //protected void ddlbranch_DataBound(object sender, EventArgs e)
    //{
    //    ddlbranch.Items.Insert(0, new ListItem("Select", "0"));
    //}

    //--------------------------------Clearing Fields------------------------------------

    protected void clearfield()
    {
        ddlyear.SelectedIndex = 0;
        txtdate.Text = "";
        txtholiday.Text = "";
        txtdetail.Text = "";
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bl_navigation.create_holiday_master(ddlyear.SelectedItem.Text.ToString(), txtholiday.Text.ToString(), txtdetail.Text.ToString(), Utility.DateTimeForat(txtdate.Text.ToString()), Session["name"].ToString(), System.DateTime.Now, Session["name"].ToString(), ref i);

        if (i <= 0)
        {
            message.InnerHtml = "Holiday already exists, try again.";
        }
        else
        {
            message.InnerHtml = "Holiday entry has been made successfully.";
        }
        clearfield();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }
}

//===========================================END OF PROGRAM====================================================

