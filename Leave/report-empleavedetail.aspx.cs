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

public partial class leave_report_empleavedetail : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            GridViewHelper helper = new GridViewHelper(this.grid_leave);
            helper.RegisterGroup("date", true, true);

            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            // helper.ApplyGroupSort();


            if (Request.QueryString["empcode"] == null)
            {
                message.InnerHtml = "No Data Found";
                return;
            }
            try
            {
                fetchemp();
                fetchleavedetail();
            }
            catch (Exception ex)
            {
                message.InnerHtml = "Problem fetching data";
            }
        }
    }


    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "date")
        {
            //row.CssClass = "frm-rght-clr123";
            //row.HorizontalAlign = HorizontalAlign.Left;
            //row.Cells[0].Text = "&nbsp;&nbsp; Status : " + row.Cells[0].Text;
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }



    protected void fetchemp()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", Request.QueryString["empcode"].ToString());
        strsql = "select empcode,coalesce(emp_fname,'') + ' '  + coalesce(emp_l_name,'') as ename from tbl_intranet_employee_jobDetails where empcode=@empcode";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_name.Text = ds.Tables[0].Rows[0]["ename"].ToString();
        }
        else
            message.InnerHtml = "No data found";

    }
    protected void fetchleavedetail()
    {
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparm[0].Value = Request.QueryString["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[1].Value = Request.QueryString["status"].ToString();

        sqlparm[2] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);
        sqlparm[2].Value = Request.QueryString["sdate"].ToString();

        sqlparm[3] = new SqlParameter("@todate", SqlDbType.DateTime, 8);
        sqlparm[3].Value = Request.QueryString["edate"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_showempleave", sqlparm);
        grid_leave.DataSource = ds;
        grid_leave.DataBind();
    }
}
