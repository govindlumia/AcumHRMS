using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using DataAccessLayer;

public partial class Leave_admin_ProcessAttendenceManually : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_fromdate.Attributes.Add("readonly", "readonly");
        txt_todate.Attributes.Add("readonly", "readonly");
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
           // message.InnerHtml = "";
 
        }

    }
    protected void ProcessAttendance()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@startdateback", Convert.ToDateTime(txt_fromdate.Text));
            param[1] = new SqlParameter("@enddateback", Convert.ToDateTime(txt_todate.Text));
           // DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_LMS_fetch_attendancetest]");
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_process_employee_attendance_ondailybasis_backmonth]",param);
         //   DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_JOB_PAYROLL_ATTENDANCEHFDAY1]");
            message.InnerHtml = "Attendance process sucessfully ";
            txt_fromdate.Text = "";
            txt_todate.Text = "";
            //lblMessage.Text = "Attendance process sucessfully";
        }
        catch 
        {
            message.InnerHtml = "Attendance Not Process due to Network Problem";

        }
        
    }


    protected void BtnProcessAttendence_Click(object sender, EventArgs e)
    {
        ProcessAttendance();
        //message.InnerHtml = "Attendance process sucessfully ";
    }
}