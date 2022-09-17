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

public partial class leave_admin_updateleave : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    string sqlstr;
    DataSet ds = new DataSet();

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

            binddata();
        }
    }

    protected void binddata()
    {
        sqlstr = "SELECT * FROM tbl_leave_createleave WHERE leaveid=" + Request.QueryString["leaveid"].ToString() +"";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_leave_type.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
        txt_description.Text = ds.Tables[0].Rows[0]["description"].ToString();
        txt_display_name.Text = ds.Tables[0].Rows[0]["displayleave"].ToString();        
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bl_navigation.update_leave_master(Request.QueryString["leaveid"], txt_leave_type.Text, txt_display_name.Text, txt_description.Text, Session["name"].ToString(), ref i);

                   Response.Redirect("editleave.aspx?updated=true");   
        
    }
   
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("editleave.aspx");
    }
}
