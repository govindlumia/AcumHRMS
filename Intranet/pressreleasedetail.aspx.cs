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

public partial class pressreleasedetail : System.Web.UI.Page
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
            bindpressrelease();
        }
    }
    //=================================================================================================================================
    protected void bindpressrelease()
    {
        sqlstr = "select id, heading, description, uploadedby, (CASE WHEN uploadeddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), uploadeddate, 106) END) uploadeddate, status from tbl_intranet_pressrelease WHERE id=" + Request.QueryString["detail"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lbldate.Text = "Posted On : " + ds.Tables[0].Rows[0]["uploadeddate"].ToString() + ", ";
        lblname.Text = "By : " + ds.Tables[0].Rows[0]["uploadedby"].ToString();
        lblheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        lbldetails.Text = ds.Tables[0].Rows[0]["description"].ToString();
    }
}
//====================================================END OF PROGRAM==========================================================================
