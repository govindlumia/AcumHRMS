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
using System.Data.SqlClient;

public partial class pressreleaseview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    //=======================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            //FOR WATER MARK IN SEARCH TEXT BOX
            string strWatermark = "Search Press Release";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

                bindpressrelease();
        }
    }

    //=======================================================================================================================================
    protected void bindpressrelease()
    {
        try
        {
            sqlstr = "SELECT id,heading,substring(description,1,200) description,(CASE WHEN uploadeddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), uploadeddate, 106) END) uploadeddate,uploadeddate uploadeddate1,uploadedby,status FROM tbl_intranet_pressrelease ORDER BY uploadeddate1 desc";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            gridpressrelease.DataSource = ds;
            gridpressrelease.DataBind();
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }
    }

    //=======================================================================================================================================
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        ViewState["search"] = 1;
        bindsearch();
    }

    //=======================================================================================================================================
    protected void bindsearch()
    {
        try
        {
            if (Convert.ToInt32(ViewState["search"]) == 1)
            {
                sqlstr = "";
                sqlstr = "SELECT id,heading,substring(description,1,200) description,(CASE WHEN uploadeddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), uploadeddate, 106) END) uploadeddate,uploadeddate uploadeddate1,uploadedby,status FROM tbl_intranet_pressrelease WHERE 1=1";
                sqlstr = sqlstr + " AND (heading like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%' OR description like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";

                sqlstr = sqlstr + " OR uploadedby like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR uploadeddate like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%')";
                sqlstr = sqlstr + " ORDER BY uploadeddate1 DESC";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                gridpressrelease.DataSource = ds;
                gridpressrelease.DataBind();
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }
    }

    //=======================================================================================================================================
    protected void gridpressrelease_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridpressrelease.PageIndex = e.NewPageIndex;
        bindpressrelease();
    }

}
//=======================================================================================================================================

