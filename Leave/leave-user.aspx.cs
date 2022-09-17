using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;

public partial class leave_dutyleave : System.Web.UI.Page
{

    string sqlstr = "", sqlstrSuperviser = "", sqlstrDirector="";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["StatusApproval"] != null)
            //{
            //    frame.Attributes.Add("src", "leave_approval.aspx?leavestatus=0&hr=0");
            //}

            if (Session["role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            confirmhr();
            confirmSupervisor();
           // confirmSuperAdmin();
            emp.Visible = true;
           // ConfirmDirector();
        }
    }
    protected void confirmhr()
    {
        sqlstr = "select count(employeecode) as hr from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and hr=1 and approverpriority=3";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr)) > 0)
        {
            ShowHr.Visible = true;
        }
        else
        {
            ShowHr.Visible = false;
        }
    }

    protected void confirmSupervisor()
    {
        sqlstrSuperviser = "select count(approverid) as superviserid from tbl_Employee_Hierarchy where approverid='" + Session["empcode"].ToString() + "' and approverpriority=1 ";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser)) > 0)
        {

            manager.Visible = true;
        }
        else
        {
            manager.Visible = false;
        }
    }

    protected void confirmSuperAdmin()
    {
        sqlstrSuperviser = "select role from tbl_login where empcode='" + Session["empcode"].ToString() + "' ";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrSuperviser)) == 3)
        {
            Reports.Visible = true;
        }
        else
        {
            Reports.Visible = false;
        }
    }
    protected void ConfirmDirector()
    {
        sqlstrDirector = "select Count(ID) from tbl_Director_Emp_Mapping where DEmpCode='" + Session["empcode"].ToString() + "' or EmpCode='" + Session["empcode"].ToString() + "' ";
        if (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrDirector)) > 0)
        {
            //showDirector.Visible = true;
        }
       // else
            ///showDirector.Visible = false;
    }  
}
