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
using HRMS.BusinessEntity;
using HRMS.DataAccessLayer;

public partial class organizationalchart : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            //FOR WATER MARK IN SEARCH TEXT BOX
            string strWatermark = "Search Organizational Chart";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

            bindgrid();
        }
    }

    //=======================================================================================================================================
    protected void bindgrid()
    {
        string Str_Search = "";
        try
        {
            IntranetDAL objIntranetDAL = new IntranetDAL();
            if (txtsearch.Text == "Search Organizational Chart")
                Str_Search = "";

            ds = objIntranetDAL.Select_OrganizationChart(Str_Search);

            if (ds.Tables[0].Rows.Count > 0)
            {
                griddetails.DataSource = ds;
                griddetails.DataBind();
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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    //=======================================================================================================================================
    protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}
