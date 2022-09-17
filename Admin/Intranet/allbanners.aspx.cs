using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Intranet_allbanners : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonClass objCLS = new CommonClass();
        DataSet dsResult = objCLS.SelectAllBanner();

        grdImageView.DataSource = dsResult.Tables[0];
        grdImageView.DataBind();
    }
    protected void grdImageView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image ImgImage = ((Image)e.Row.FindControl("ImgImage"));
            Label lblImageName = ((Label)e.Row.FindControl("lblImageName"));
            ImgImage.ImageUrl = "~/images/banner/" + lblImageName.Text + "";
        }
    }
}