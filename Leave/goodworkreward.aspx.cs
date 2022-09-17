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
using DataAccessLayer;
using Utilities;
public partial class leave_goodworkreward : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            //    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //        Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bindemp_formgr();
        }
    }
   

    protected void clear()
    {
        txtdate.Text = "";
        txtnoofhour.Text = "";
        //txtpickuppoint.Text = "";
        ddlempcode.SelectedIndex = 0;
        //ddlmodeoftransport.SelectedIndex = 0;
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = "SELECT dept_id FROM tbl_intranet_employee_jobDetails WHERE empcode='" + Session["empcode"].ToString() + "'";
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);

        int dept_id = Convert.ToInt32(ds.Tables[0].Rows[0]["dept_id"].ToString());

        SqlParameter[] sqlparm = new SqlParameter[5];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 30);
        sqlparm[0].Value = ddlempcode.SelectedValue;

        sqlparm[1] = new SqlParameter("@oddate", SqlDbType.DateTime,8);
        sqlparm[1].Value = Utility.dataformat(txtdate.Text.ToString());

        sqlparm[2] = new SqlParameter("@noofhours", SqlDbType.Decimal);
        sqlparm[2].Value =Convert.ToDecimal(txtnoofhour.Text.Trim() == "" ? "0.00" : txtnoofhour.Text.Trim());

        sqlparm[3] = new SqlParameter("@dept_id", SqlDbType.Int);
        sqlparm[3].Value = dept_id;

        sqlparm[4] = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
        sqlparm[4].Value = Session["name"].ToString();

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_insertgoodwillreward", sqlparm);

        if (i > 0)
        {
            message.InnerHtml = "";
            message.InnerHtml = "Records has been inserted successfully !";
            clear();
        }
        else
        {
            message.InnerHtml = "";
            message.InnerHtml = "Records has not been inserted successfully. Please try later!";
        }
    }

    protected void bindemp_formgr()
    {
        sqlstr = @"select distinct h.employeecode as empcode,m.emp_fname + ' ' + m.emp_m_name + ' ' + m.emp_l_name as name,
                    m.degination_id,tbl_intranet_designation.designationname,
                    m.dept_id,tbl_internate_departmentdetails.department_name,
                    m.branch_id,tbl_intranet_branch_detail.branch_name   
                    from tbl_leave_employee_hierarchy h
                    INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
                    INNER JOIN tbl_intranet_designation ON m.degination_id=tbl_intranet_designation.id
                    INNER JOIN tbl_internate_departmentdetails ON m.dept_id=tbl_internate_departmentdetails.departmentid
                    INNER JOIN tbl_intranet_branch_detail ON m.branch_id=tbl_intranet_branch_detail.Branch_id
                    where h.approverid='" + Session["empcode"].ToString() + "' ORDER BY name";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);


        ////-----Add the employee in the drop down list Box-------------------------------
        ddlempcode.Items.Add(new ListItem("---Select Employee---"));
        string empcode,empname;
        ////--------------------------------------------------------------------------

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                empcode = row1["empcode"].ToString().Trim();
                empname = row1["name"].ToString().Trim();

                ddlempcode.Items.Add(new ListItem(Convert.ToString(empname) + '-' + Convert.ToString(empcode), Convert.ToString(empcode)));

            }
        }
    }


    //protected void ddlmodeoftransport_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlmodeoftransport.SelectedIndex == 0)
    //    {
    //        txtpickuppoint.Enabled = false;
    //    }
    //    else
    //    {
    //        txtpickuppoint.Enabled = true;
    //    }
    //}
}
