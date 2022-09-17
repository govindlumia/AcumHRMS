using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_ViewKRASetting : System.Web.UI.Page
{
    Int64 _CurrentKRASettingID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            try
            {
                if (PreviousPage is Appraisal_Admin_ViewKRAApprovals)
                {
                    ucViewKRASetting.CurrentKRAID = ((Appraisal_Admin_ViewKRAApprovals)PreviousPage).CurrentKRASettingID;
                }
                else
                    if (PreviousPage is Appraisal_User_AllKRAFormStatus)
                    {
                        ucViewKRASetting.CurrentKRAID = ((Appraisal_Admin_ViewKRAApprovals)PreviousPage).CurrentKRASettingID;
                    }
                    else
                        if (HttpContext.Current.Items["CurrentKRASettingID"] != null)
                        {
                            ucViewKRASetting.CurrentKRAID = Convert.ToInt32(HttpContext.Current.Items["CurrentKRASettingID"].ToString());
                        }

            }
            catch (Exception ex)
            {
                ucViewKRASetting.CurrentKRAID = Convert.ToInt64(HttpContext.Current.Items["CurrentKRASettingID"]);
            }
        }
    }
}