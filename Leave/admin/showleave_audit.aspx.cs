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
using Utilities;
public partial class leave_admin_showleave_audit : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
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

    protected void fetchleavedetail()
    {
        SqlParameter[] sqlparm = new SqlParameter[4];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparm[0].Value = txt_employee.Text.Trim().ToString();

        sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[1].Value = 6;

        sqlparm[2] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);
        sqlparm[2].Value = Utility.dataformat(txt_sdate.Text);

        sqlparm[3] = new SqlParameter("@todate", SqlDbType.DateTime, 8);
        sqlparm[3].Value = Utility.dataformat(txt_edate.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_showempleave_audit]", sqlparm);
        grid_leave.DataSource = ds;
        grid_leave.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridViewHelper helper = new GridViewHelper(this.grid_leave);
        helper.RegisterGroup("date", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        // helper.ApplyGroupSort();

        
        try
        {
            //fetchemp();
            fetchleavedetail();
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem fetching data";
        }
    }
}
