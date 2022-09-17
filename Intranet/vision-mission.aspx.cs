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

public partial class vision_mission : System.Web.UI.Page
{
   public static DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            //FOR WATER MARK IN SEARCH TEXT BOX
            string strWatermark = "Search Vision-Mission";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

            _Gridbind();

            if (Convert.ToInt32(Request.QueryString["d"]) == 1)
            {
                divDetail.Style["display"] = "block";
                divResult.Style["display"] = "none";

                lbldate.Text = "Posted On : " + ds.Tables[0].Rows[0]["uploadeddate"].ToString() + ", ";
                lblname.Text = "By : " + ds.Tables[0].Rows[0]["uploadedby"].ToString();
                lblheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
                lbldetails.Text = ds.Tables[0].Rows[0]["description"].ToString();
            }
            else
            {
                divDetail.Style["display"] = "none";
                divResult.Style["display"] = "block";
            }

            
        }
    }

    //=======================================================================================================================================
    protected void _Gridbind()
    {
        string Category="Vision";
        string Str_Search = "";
        try
        {
            if (Convert.ToInt32(Request.QueryString["type"]) == 1)
            {
                Category = "Vision";
            }
            if (Convert.ToInt32(Request.QueryString["type"]) == 2)
            {
                Category = "Mission";
            }

            if (txtsearch.Text == "Search Vision-Mission")
                Str_Search = "";

            IntranetDAL objIntranetDAL = new IntranetDAL();

            ds = objIntranetDAL.Select_mission_vision(Category, Str_Search);

            gridvision.DataSource = ds;
            gridvision.DataBind();
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
        _Gridbind();
    }

    //=======================================================================================================================================
    protected void gridvision_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridvision.PageIndex = e.NewPageIndex;
        _Gridbind();
    }
}
