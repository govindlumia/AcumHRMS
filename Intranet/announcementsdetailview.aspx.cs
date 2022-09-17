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
using DataAccessLayer;
public partial class announcementsdetailview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindannouncements();
        }
    }

    protected void bindannouncements()
    {
        sqlstr = "select id,heading,description,postedby, posteddate,run_status,category,priority,RichDesc from announcements WHERE id=" + Request.QueryString["detail"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lbldate.Text = "Posted On : " + Convert.ToDateTime(ds.Tables[0].Rows[0]["posteddate"].ToString()).ToString("dd-MMM-yyyy") + ", ";
        lblname.Text = "By : " + ds.Tables[0].Rows[0]["postedby"].ToString();
        lblheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        lbldetails.Text = ds.Tables[0].Rows[0]["description"].ToString();
        lbl_richData.Text=HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["RichDesc"].ToString());
    }
}
