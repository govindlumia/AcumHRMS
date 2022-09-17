using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Data;

public partial class Home : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();

    protected void Page_Init(object sender, EventArgs e)
    {
        CheckSession();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblname.Text = Session["EmpName"].ToString();
            if ((Session["role"].ToString().Trim() == "2") || (Session["role"].ToString().Trim() == "3") || (Session["role"].ToString().Trim() == "1"))
            {
                admin.Visible = true;
                adminline.Visible = true;
            }
            else
            {
                admin.Visible = false;
                adminline.Visible = false;
            }

            bindpersonalInfo();
        }
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

    protected void bindpersonalInfo()
    {
        LoginBusiness ObjLoginBusiness = new LoginBusiness();
        LoginENT ObjLoginENT = new LoginENT();
        ObjLoginENT.Login_id = Session["empcode"].ToString();

        ds = ObjLoginBusiness.LookupUser(ObjLoginENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //rptpersonalinfo.DataSource = ds;
            //rptpersonalinfo.DataBind();
        }
    }

    ////-----------------------Binding CEO MESSAGE-------------------------------------------------------
    protected void bindCEOMessage()
    {

        MainBusiness objMainBusiness = new MainBusiness();

        ds = objMainBusiness.Select_CEODESK();

        if (ds.Tables[0].Rows.Count > 0)
        {
            //rptceo.DataSource = ds;
            //rptceo.DataBind();
        }
    }

    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}
