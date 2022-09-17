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
public partial class leave_casualworkcapture : System.Web.UI.Page
{
    DataSet ds;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            binddepartment();
        }
    }

    protected void binddepartment()
    {
        sqlstr = @"SELECT departmentid as deptcode,department_name as deptname FROM tbl_internate_departmentdetails 
                WHERE departmentid=(SELECT dept_id FROM tbl_intranet_employee_jobDetails WHERE empcode='" + Session["empcode"].ToString() + "')";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lbldepartment.Text = ds.Tables[0].Rows[0]["deptname"].ToString();
        lbldept_id.Text = ds.Tables[0].Rows[0]["deptcode"].ToString();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        insertrecords();
        clear();
    }

    protected void insertrecords()
    {
        if (Session["name"] != null)
        {
            SqlParameter[] sqlparm = new SqlParameter[7];

            sqlparm[0] = new SqlParameter("@dept_id", SqlDbType.Int);
            sqlparm[0].Value = lbldept_id.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@casualdate", SqlDbType.DateTime);
            sqlparm[1].Value = Utility.dataformat(txtdate.Text);

            sqlparm[2] = new SqlParameter("@casualno", SqlDbType.Int);
            sqlparm[2].Value = txtpersons.Text.Trim().ToString();

            sqlparm[3] = new SqlParameter("@noofhours", SqlDbType.Decimal);
            sqlparm[3].Value = txtnoofhour.Text.Trim().ToString();

            sqlparm[4] = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
            sqlparm[4].Value = Session["name"].ToString();

            sqlparm[5] = new SqlParameter("@updateddate", SqlDbType.DateTime);
            sqlparm[5].Value = System.DateTime.Now;

            sqlparm[6] = new SqlParameter("@empcode", SqlDbType.VarChar);
            sqlparm[6].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_insertcasualworkcapture", sqlparm);

            if (i > 0)
            {
                message.InnerHtml = "";
                message.InnerHtml = "Requested hours for casual has been successfully sent to admin for approval";
            }
            else
            {
                message.InnerHtml = "";
                message.InnerHtml = "Requested hours for casual has not been successfully sent";
            }
        }
        else
        {
            message.InnerHtml = "";
            message.InnerHtml = "Your current session has been expired. Please login again!";
        }
    }

    protected void clear()
    {
        txtdate.Text = "";
        txtpersons.Text = "";
        txtnoofhour.Text = "";
    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
    }
}
