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

public partial class leave_view_emp_approver : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "Approver List for " + Request.QueryString["name"].ToString() + ' ' + '(' + ' ' + Request.QueryString["empcode"].ToString() + ')';
        bindapprover();
    }

    public void bindapprover()
    {
        sqlstr = @"select approverid as empcode, coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as approvername,
                   case when eh.hr=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HR' end as levels
                   from tbl_Employee_Hierarchy eh inner join 
                   tbl_intranet_employee_jobDetails ed
                   on eh.approverid=ed.empcode 
                   where eh.employeecode= '" + Request.QueryString["empcode"].ToString() + "' order by approverpriority";
                
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        approvergrid.DataSource = ds;
        approvergrid.DataBind();

    }
}
