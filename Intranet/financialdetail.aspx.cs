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

public partial class financialdetail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    //=================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindfinancial();
        }
    }
    //=================================================================================================================================
    protected void bindfinancial()
    {
        sqlstr = "SELECT id,heading,description,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,postedby,run_status FROM tbl_intranet_financial WHERE id=" + Request.QueryString["detail"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lbldate.Text = "Posted On : " + ds.Tables[0].Rows[0]["posteddate"].ToString() + ", ";
        lblname.Text = "By : " + ds.Tables[0].Rows[0]["postedby"].ToString();
        lblheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        lbldetails.Text = ds.Tables[0].Rows[0]["description"].ToString();
    }
}
//====================================================END OF PROGRAM==========================================================================
