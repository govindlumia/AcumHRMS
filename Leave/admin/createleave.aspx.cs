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

public partial class Leave_admin_createleave : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    DataSet ds = new DataSet();
    public int i, ptr1, ptr2;
    string sqlstr, sqlstr1, str_contry_name, str_contry_name1;

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
        }
    }

    public void btnsbmit_Click(object sender, EventArgs e)
    {
        bl_navigation.create_leave_master(txt_leave_type.Text, txt_description.Text, txt_display_name.Text, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), ref i);

        if (i <= 0)
        {
            message.InnerHtml = "Leave name already exists, please enter another name";
        }
        else
        {
            message.InnerHtml = "New leave created successfully";
        }
        clearfield();
    }

    public void clearfield()
    {
        txt_display_name.Text = "";
        txt_description.Text = "";
        txt_leave_type.Text = "";
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }
}
