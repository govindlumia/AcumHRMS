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
using System.Globalization;
using Utilities;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Leave_BalanceHistory : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            Bindempcode();
           // BindLeaveRegister();
        }
    }
    protected void Bindempcode()
    {
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@approverid", Session["EmpCode"].ToString());

        strsql = @"select employeecode,dbo.GetEmpName(employeecode) as empname ,
                    desg.designationname
                    from tbl_Employee_Hierarchy eh
                    inner join tbl_intranet_employee_jobDetails job
                    on job.empcode=eh.employeecode
                    inner join tbl_DesignationMaster desg
                    on desg.id=job.degination_id
                    where approverid=@approverid and approverpriority='1' order by empname asc ";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        Bind_leave_balance.DataSource = ds;
        Bind_leave_balance.DataBind();
    }
}