using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_UserApprovalDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string empCode = Convert.ToString(Session["UserEmpCode"]);

        if (!string.IsNullOrEmpty(empCode))
            SqlDataSource2.SelectParameters["empcode"].DefaultValue = empCode;
        else
            SqlDataSource2.SelectParameters["empcode"].DefaultValue = Convert.ToString(Session["EmpCode"]);

        Session["UserEmpCode"] = null;

    }
}