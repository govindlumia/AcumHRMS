using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Company_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }
        checkRights();
    }
    private void checkRights()
    {
        if (Session["Role"] != null)
        {
            if ((Session["Role"].Equals("1") || Session["Role"].Equals("2")) || Session["Role"].Equals("3") || Session["Role"].Equals("4"))
            {
                if ((Session["Role"].Equals("1") || Session["Role"].Equals("2")) || Session["Role"].Equals("3") || Session["Role"].Equals("4") ) 
                {
                    dv_com_module.Visible = true;
                    dv_timesheet_module.Visible = true;
                    dv_payroll_module.Visible = true;
                    dv_infocenter_module.Visible = true;
                    dv_emp_module.Visible = true;
                  
                    dv_recruit_module.Visible = true;

                }

                dv_leave_module.Visible = true;
            }
            //if (Session["Role"].Equals("2"))
            if (Session["Role"].Equals("4") || Session["Role"].Equals("5")) // payroll 
            {
                dv_payroll_module.Visible = true;
            }
            if (Session["Role"].Equals("6")) // super admin 
            {
                dv_infocenter_module.Visible = true;
            }
        }
    }
}