using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Transactions;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Admin_Company_BannerMaster : System.Web.UI.Page
{
    //GetData getdata;
    //InsertData insertdata;
  
    protected void Page_Load(object sender, EventArgs e)
    {
       
 
        if (!IsPostBack)
        {
            bindGrid();
        }
    }

    private void bindGrid()
    {
        BannerBusiness getdata = new BannerBusiness();
        grd_banners.DataSource = getdata.getBannerGridData();
        grd_banners.DataBind();
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        BannerImage bannerObj = new BannerImage();
        BannerBusiness insertdata = new BannerBusiness();    
        bannerObj.imageName = txt_imagename.Value;
        bannerObj.URL = txt_url.Value;
        bannerObj.fileName="images/banner/"+saveFile();
        if (bannerObj.fileName.Trim() != "")
        {
            int result = insertdata.addBanner(bannerObj);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "result_success", "alert('Data Saved Successfully');", true);
           //     Page.RegisterStartupScript("banner_error", "alert('Data Saved Successfully');");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "result_unsuccess", "alert('Data Saved Successfully');", true);
             //   Page.RegisterStartupScript("banner_error", "alert('Data Could not saved,Please try again');");
            }
        }
        bindGrid();
        ClearAll();
    }

    private void ClearAll()
    {
        txt_imagename.Value = "";
        txt_url.Value = "";

    }
    private string saveFile()
    {
        String file_old_name="";
        if (file_image.HasFile)
        {
           

            file_old_name = DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + file_image.FileName;
         

            file_image.SaveAs(Server.MapPath("~\\images\\banner\\"+file_old_name));
            if(!File.Exists(Server.MapPath("~\\images\\banner\\"+file_old_name)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "banner_error", "alert('Data Saved Successfully');", true);
                //Page.RegisterStartupScript("banner_error", "alert('File Could not Saved');return false;");
            }
           
            }
        return file_old_name;
    }
    protected void grg_banners_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("img_banner");
           img.ImageUrl = "~/" + img.ToolTip;
           
            Image img1 = (Image)e.Row.FindControl("img_status");
            if (img1.AlternateText == "False")
                img1.ImageUrl = "~/images/redmap.png";
            else if (img1.AlternateText == "True")
                img1.ImageUrl = "~/images/greenmap.png";
        }
    }
    protected void grd_banners_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "status")
        {
            BannerBusiness insertdata = new BannerBusiness();
            insertdata.updateBannerStatus(Convert.ToInt32(e.CommandArgument));
        }
        else if (e.CommandName == "deleted")
        {
            BannerBusiness insertdata = new BannerBusiness();
          int result=  insertdata.deleteBanner(Convert.ToInt32(e.CommandArgument));
          if (result == 1)
          {
            //  Image img=(Image)
          }
        }
        bindGrid();
    }
    
    protected void grd_banners_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_banners.PageIndex = e.NewPageIndex;
        bindGrid();
    }
   
}