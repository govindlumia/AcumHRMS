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

public partial class announcementsview : System.Web.UI.Page
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
            string strWatermark = "Search Your News";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

            bindcategory();//BINDING CATEGORY

            //DATE WISE announcements
            if (Request.QueryString["announcements"] == "1")
            {
                binddatewise();
            }

            //PRIORITY announcements
            if (Request.QueryString["announcements"] == "2")
            {
                bindpriority();
            }

            //TODAY'S announcements
            if ((Request.QueryString["announcements"] != "1") && (Request.QueryString["announcements"] != "2"))
            {
                bindannouncements();
            }
        }
    }

    //=======================================================================================================================================
    protected void bindannouncements()
    {
        try
        {
            if ((Request.QueryString["announcements"] != "1") && (Request.QueryString["announcements"] != "2"))
            {
                sqlstr = "";
               // sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority from ANNOUNCEMENTS WHERE 1=1 AND CONVERT(CHAR(15), posteddate, 106)=CONVERT(CHAR(15), getdate(), 106)";

                sqlstr = "select id,heading,substring(description,1,200) description,postedby, posteddate,run_status,category,priority from ANNOUNCEMENTS WHERE 1=1 ";
                
                //if (ddlcategory.SelectedIndex != 0)
                //{
                //    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedItem.Text + "'";

                //}
                //sqlstr = sqlstr + " AND run_status=0 AND priority=0 ORDER BY Posteddate desc,category";

                sqlstr = sqlstr + " AND run_status=0 ORDER BY Posteddate desc,category";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                announcementsgrid.DataSource = ds;
                announcementsgrid.DataBind();

                searchgrid.Visible = false;
                announcementsgrid.Visible = true;
                announcementsdatewise.Visible = false;
                priority.Visible = false;
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
    protected void bindcategory()
    {
        try
        {
            string category;
            ////-----Add the CATEGORY in the drop down list Box-------------------------------
            ddlcategory.Items.Add(new ListItem("---Select Category---"));

            sqlstr = "SELECT distinct category FROM ANNOUNCEMENTS";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    category = row1["category"].ToString().Trim();

                    ddlcategory.Items.Add(new ListItem(Convert.ToString(category)));
                }
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Errors in records fetching. Please try later!";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Session expired. Please login again!";
        }
        finally
        {

        }
    }

    //=======================================================================================================================================
    protected void binddatewise()
    {
        try
        {
            if (Request.QueryString["announcements"] == "1")
            {
                sqlstr = "";
                sqlstr = "select id,heading,substring(description,1,200) description,postedby,posteddate,posteddate posteddate1,run_status,category,priority from ANNOUNCEMENTS WHERE 1=1";

                if (ddlcategory.SelectedIndex != 0)
                {
                    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedItem.Text + "'";

                }
                sqlstr = sqlstr + " AND run_status=0 ORDER BY posteddate1 desc,category";


                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                announcementsdatewise.DataSource = ds;
                announcementsdatewise.DataBind();

                searchgrid.Visible = false;
                announcementsgrid.Visible = false;
                announcementsdatewise.Visible = true;
                priority.Visible = false;
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
    protected void bindpriority()
    {
        try
        {
            if (Request.QueryString["announcements"] == "2")
            {
                sqlstr = "";
                sqlstr = "select id,heading,substring(description,1,200) description,postedby, posteddate,posteddate posteddate1,run_status,category,priority from ANNOUNCEMENTS WHERE 1=1";

                if (ddlcategory.SelectedIndex != 0)
                {
                    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedItem.Text + "'";

                }
                sqlstr = sqlstr + " AND run_status=0 ORDER BY priority desc,posteddate1 desc,category";


                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                priority.DataSource = ds;
                priority.DataBind();

                searchgrid.Visible = false;
                announcementsgrid.Visible = false;
                announcementsdatewise.Visible = false;
                priority.Visible = true;
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
    protected void btngo_Click(object sender, EventArgs e)
    {
        bindannouncements();
        binddatewise();
        bindpriority();
        bindsearch();
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
                sqlstr = "SELECT id,heading,substring(description,1,200) description,postedby, posteddate,posteddate posteddate1,run_status,category,priority from ANNOUNCEMENTS WHERE 1=1";
                sqlstr = sqlstr + " AND (heading like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%' OR description like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";

                sqlstr = sqlstr + " OR category like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR postedby like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR posteddate like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%')";
                if (ddlcategory.SelectedIndex != 0)
                {
                    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedItem.Text + "'";
                }
                sqlstr = sqlstr + " AND run_status=0";
                sqlstr = sqlstr + " ORDER BY priority DESC, posteddate1 DESC";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                searchgrid.DataSource = ds;
                searchgrid.DataBind();

                searchgrid.Visible = true;
                announcementsgrid.Visible = false;
                announcementsdatewise.Visible = false;
                priority.Visible = false;
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
    protected void announcementsgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        announcementsgrid.PageIndex = e.NewPageIndex;
        bindannouncements();
    }

    //=======================================================================================================================================
    protected void announcementsdatewise_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        announcementsdatewise.PageIndex = e.NewPageIndex;
        binddatewise();
    }

    //=======================================================================================================================================
    protected void priority_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        priority.PageIndex = e.NewPageIndex;
        bindpriority();
    }

    //=======================================================================================================================================
    protected void searchgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        searchgrid.PageIndex = e.NewPageIndex;
        bindsearch();
    }
}
//=======================================================================================================================================
