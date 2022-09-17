using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic;

public partial class Admin_Employee_ChangeUserCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_check_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_currentCode.Text.Trim()))
        {
            lbl_check_result.Text = "Enter Current Employee Code";
            dv_newcode.Visible = false;
            lbl_emp_detail.Text = "";
        }
        else
        {
            lbl_check_result.Text = "";
            dv_newcode.Visible = false;
            lbl_emp_detail.Text = "";
        }
        EmployeeEditBussiness balObj = new EmployeeEditBussiness();
        string result = balObj.checkUser(txt_currentCode.Text.Trim());
        if (result.Equals("No Avail"))
        {
            lbl_check_result.Text = "No Employee with this code";
            dv_newcode.Visible = false;
            lbl_emp_detail.Text = "";
        }
        else if (!string.IsNullOrEmpty(result.Trim()))
        {
            lbl_emp_detail.Text = result;
            dv_newcode.Visible = true;
        }
    }
    protected void btn_change_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_new_emp_code.Text.Trim()))
        {
            lbl_new_result.Text = "Enter new employee code";
            return;
        }
        else
        {
            string result=string.Empty;
            try
            {
                EmployeeEditBussiness balObj = new EmployeeEditBussiness();
                 result = balObj.changeEmpCode(txt_currentCode.Text.Trim(), txt_new_emp_code.Text.Trim());
              
            }
            catch (Exception ex)
            {
                lbl_new_result.Text = "Empcode Updated from "+txt_currentCode.Text+" to "+txt_new_emp_code.Text;
                txt_currentCode.Text = "";
                txt_new_emp_code.Text = "";
            }

        }



    }
}
