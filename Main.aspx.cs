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
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Generic;
using QueryStringEncryption;
using System.IO;

public partial class admin_index : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    string folder;
    public string img_src_path;

    protected void Page_Init(object sender, EventArgs e)
    {
        CheckSession();
    }

    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public static List<string> GetImages()
    //{
    //    System.Threading.Thread.Sleep(5000);
    //    List<string> allCompany = new List<string>();
    //    CommonClass objCLS = new CommonClass();
    //    DataTable dtResult = objCLS.SelectBannerMaster();
    //    for (int i = 0; i < dtResult.Rows.Count; i++)
    //    {
    //        allCompany.Add("images/banner/" + dtResult.Rows[i][0].ToString());
    //    }
    //    return allCompany;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["imagesData"] != null)
        {
            DataTable dtresult = (DataTable)ViewState["imagesData"];
            banner_rotate.DataSource = dtresult;
            banner_rotate.DataBind();
        }
        if (!IsPostBack)
        {
            if (Session["EmpName"] != null)
            {
                if ((Session["Role"].ToString().Trim() == "2") || (Session["Role"].ToString().Trim() == "3") || Session["Role"].ToString().Trim() == "1" || Session["Role"].ToString().Trim() == "4")
                {
                    admin.Visible = true;
                }
                else
                {
                    admin.Visible = false;
                }
                _pageInitialize();

                 img_src_path = "images/banner/"+folder+"/1.jpg";
            }
        }

        bindRotator();
        img_src_path = "images/banner/" + folder + "/1.jpg";
       // img_banner.Src = img_src_path;
      //  lbl_imagefolder.Text = folder;
    }
    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    private void bindRotator()
    {
        BannerBusiness getdata = new BannerBusiness();
        DataTable dtresult = getdata.getHomeBannerData();
        banner_rotate.DataSource = dtresult;
        banner_rotate.DataBind();
        ViewState["imagesData"] = dtresult;
    }

    protected void _pageInitialize()
    {
        bindpersonalInfo();
        bindEnterpriseLink();
        bindHelpfulLink();
        bindCEOMessage();
        //bindEvents();
        bindAnnouncements();
        bindAchievements();
        _EmployeeDetails();
        bindbirthdaytoday();
        bindanniversarytoday();
        //bindNotification();
        bindnewjob();
    }

    public void _EmployeeDetails()
    {
        EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
        EmpJobDetailBusiness ObjEmpJobDetailBusiness = new EmpJobDetailBusiness();

        ObjEmpJobDetailENT.Empcode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Degination_id = 0;
        ObjEmpJobDetailENT.Category_id = 0;
        ObjEmpJobDetailENT.Status = true;
        ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
        ObjEmpJobDetailENT.EmployeeCode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Emp_fname = "";

        ds = ObjEmpJobDetailBusiness.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            lblNameA.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            lblDept.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            lblDesig.Text = ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString();
        }
    }

    //-----------------------Binding CEO MESSAGE-------------------------------------------------------
    protected void bindpersonalInfo()
    {
        SqlParameter[] newparameter = new SqlParameter[1];
        newparameter[0] = new SqlParameter("@employeeID", SqlDbType.VarChar, 50);
        newparameter[0].Value = Session["login"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SELECT_LOOKUPUSER", newparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Photo"].ToString()))

                imageProf.Src = "UploadPhoto/" + ds.Tables[0].Rows[0]["Photo"].ToString();
            else
                imageProf.Src = "UploadPhoto/avatar_2x.png";
        }
    }

    //---------------------------Binding ENTERPRISE LINK------------------------------------------------
    protected void bindEnterpriseLink()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "ENTERPRISELINK_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptenterprise.DataSource = ds;
            rptenterprise.DataBind();
        }
    }

    //----------------------------Binding HELPFUL LINK-------------------------------------------------
    protected void bindHelpfulLink()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "HELPFULLINK_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpthelpful.DataSource = ds;
            rpthelpful.DataBind();
        }
    }

    //-----------------------Binding CEO MESSAGE-------------------------------------------------------
    protected void bindCEOMessage()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CEODESK_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptceo.DataSource = ds;
            rptceo.DataBind();
        }
    }

    //-----------------------Binding EVENTS-----------------------------------------------------------
    protected void bindEvents()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "COMPANY_EVENTS_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptevents.DataSource = ds;
            rptevents.DataBind();
        }
    }

    //------------------------Binding Real estate news--------------------------------------------------
    protected void bindAnnouncements()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "ANNOUNCEMENTS_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptannouncements.DataSource = ds;
            rptannouncements.DataBind();
        }
    }

    //----------------------Binding Press Release----------------------------------------------------
    protected void bindAchievements()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "ACHIEVEMENTS_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptachievements.DataSource = ds;
            rptachievements.DataBind();
        }
    }


    
    //------------------------ Bind BirthDay Today--------------------------------------------------------
    protected void bindbirthdaytoday()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_Birthday");
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlstbirthday.DataSource = ds;
            dlstbirthday.DataBind();
        }

        //lblc.text = DateTime.Now.ToString();
    }


    //------------------------ Bind Anniversary Today--------------------------------------------------------
    protected void bindanniversarytoday()
    {

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_Anniversary");

        if (ds.Tables[0].Rows.Count > 0)
        {
            DlsAnniversary.DataSource = ds;
            DlsAnniversary.DataBind();
        }
    }
    protected void dlstbirthday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("light");
            Label dateTime = (Label)e.Item.FindControl("lblCurrentDate");
            dateTime.Text = System.DateTime.Now.ToString("MMM dd yyyy");
            Label lbl_name1 = (Label)e.Item.FindControl("lbl_name");

            Label lbl_name2 = (Label)e.Item.FindControl("txt_name");

            Label lbl_desig = (Label)e.Item.FindControl("lbl_desg");

            Label lbl_mobile = (Label)e.Item.FindControl("Lbl_fone");

            SqlParameter[] newparameter = new SqlParameter[1];
            newparameter[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            newparameter[0].Value = e.CommandArgument.ToString();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_employeeFind", newparameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_name1.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                lbl_name2.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                lbl_desig.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
                lbl_mobile.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "alert_1", "document.getElementById('" + div.ClientID + "').style.display='block';document.getElementById('fade').style.display='block';", true);
        }
        else
        {
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("light");
            ScriptManager.RegisterStartupScript(this, GetType(), "alert_2", "document.getElementById('" + div.ClientID + "').style.display='none';document.getElementById('fade').style.display='none';", true);
        }
    }
    protected void DlsAnniversary_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            HtmlGenericControl div1 = (HtmlGenericControl)e.Item.FindControl("light1");
            Label dateTime = (Label)e.Item.FindControl("lblCurrentDate1");
            dateTime.Text = System.DateTime.Now.ToString("MMM dd yyyy");
            Label LBL_Name = (Label)e.Item.FindControl("LBL_Name");

            Label LBL_Name1 = (Label)e.Item.FindControl("LBL_Name1");

            Label LBL_Desg = (Label)e.Item.FindControl("LBL_Desg");

            Label LBL_Mobile = (Label)e.Item.FindControl("LBL_Mobile");

            SqlParameter[] newparameter = new SqlParameter[1];
            newparameter[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            newparameter[0].Value = e.CommandArgument.ToString();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_employeeFindAnniversary", newparameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                LBL_Name.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                LBL_Name1.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                LBL_Desg.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
                LBL_Mobile.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "document.getElementById('" + div1.ClientID + "').style.display='block';document.getElementById('fade1').style.display='block'", true);
        }
        else
        {
            HtmlGenericControl div1 = (HtmlGenericControl)e.Item.FindControl("light1");
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "document.getElementById('" + div1.ClientID + "').style.display='none';document.getElementById('fade1').style.display='none'", true);
        }
    }

    //-----------------------------Binding (Notifications)--------------------------------------------------
    protected void bindNotification()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Notification_sp");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptnews.DataSource = ds;
            rptnews.DataBind();
        }
    }
    
    //--------------------------------Binding New Oppening-----------------------------------------------------
    private void bindnewjob()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        string Type = "Employee";

        ObjVacENT.Vac_ID = "";
        ObjVacENT.ReqType = Type;
        ObjVacENT.Location_ID = 0;
        ObjVacENT.Vac_StatusID = 0;
        ObjVacENT.ApprovalStatusID = 0;
        ObjVacENT.FromDate = "";
        ObjVacENT.ToDate = "";
        ObjVacENT.Pageindex = 1;
        ObjVacENT.PageSize = 1000;
        ObjVacENT.SortBy = "";
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjVacBusiness.SelectVaccancy(ObjVacENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //rprJoboppening.DataSource = ds;
            //rprJoboppening.DataBind();
        }
    }


    protected void rprJoboppening_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        {
            Label lblVac_ID = (Label)item.FindControl("lblVac_ID");
            LinkButton lnkView = (LinkButton)item.FindControl("lnkView");
            Label lblTitle = (Label)item.FindControl("lblTitle");

            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lblVac_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            lnkView.Text = lblVac_ID.Text + "-" + lblTitle.Text;

            string url = "Recruitment/User/VacViewDetails.aspx?ID=" + writer.ToString() + "&Type=EMP";
            lnkView.PostBackUrl = url;
        }
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}