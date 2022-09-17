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

public partial class payroll_admin_ProcessAttendanceForFandF : System.Web.UI.Page
{
    string connStr = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_fyear();
        }

    }
    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            //dt = dt.AddMonths(1);

            if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
                lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
            else
                lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SaveAttendance();
         message.InnerText = "Attendance processed successfully";
    }

    protected void SaveAttendance()
    {
        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar, 50);
        sqlparam[2].Value = lbl_fyear.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        
        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_employee.Text;


        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[Process_attendance_monthly_ForFandF]", sqlparam);

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance_forFandF]", sqlparam);

        
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}