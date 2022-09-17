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

public partial class TrainingStartPage : System.Web.UI.Page
{
    string url = string.Empty;
    int result = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        TrainingRole();
    }
    private void TrainingRole()
    {
        try
        {
            if (Session["empcode"] != null || Session["User"] != null)
            {
                //if (Session["empcode"] != null)
                //{
                //    result = LoginBusiness.TrainingRoleCheck(Session["empcode"].ToString());
                //}
                //else
                //{
                //    result = LoginBusiness.TrainingRoleCheck(((YKKT.BusinessEntity.LoginEntity)Session["User"]).Empcode);
                //}
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
            if (result == 1)
            {
                Session["RoleTraining"] = "HR";
                url = "Welcome.aspx";
            }
            else
                if (result == 2)
                {
                    Session["RoleTraining"] = "HOD";
                    url = "Welcome.aspx";
                }
                else
                    if (result == 4)
                    {
                        Session["RoleTraining"] = "HOD&HC";
                        url = "Welcome.aspx";
                    }
                    else
                    {
                        Session["RoleTraining"] = "User";
                        url = "Welcome.aspx";
                    }

            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            //if (Session["empcode"].ToString() == "97064")
            //{
            //      Session["RoleTraining"] = "HOD";
            //      url = "Welcome.aspx";
            //}
            //else if (Session["empcode"].ToString() == "00043")
            //{
            //    Session["RoleTraining"] = "HOD&HR";
            //    url = "Welcome.aspx";
            //}
            //else
            //{
            //    Session["RoleTraining"] = "User";
            //    url = "Welcome.aspx";
            //}
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }        
}
