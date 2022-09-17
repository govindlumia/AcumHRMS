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
using DataAccessLayer;
using querystring;
using System.Data.SqlClient;

public partial class Leave_HRleavehistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/Login.aspx");
        }
        Bindgrid();
    }
    protected string linkleave(string empcode, string leavename, int id, int status)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        //return "<a href='editleave.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        if(status == 6)
        return "<a href='ViewApprovedLeaveDetail.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='ViewLeaveDetail.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "leavestatus")
        {
            //row.CssClass = "frm-rght-clr123";
            //row.HorizontalAlign = HorizontalAlign.Left;
            //row.Cells[0].Text = "&nbsp;&nbsp; Status : " + row.Cells[0].Text;
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }

    protected void Bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 20);
        sqlparam[0].Value = Session["empcode"].ToString();
        sqlparam[1] = new SqlParameter("@hr", SqlDbType.Int);
        sqlparam[1].Value = 1;
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetchleavesummary_hr", sqlparam);
        leave_approval_grid.DataSource = ds;
        leave_approval_grid.DataBind();

        GridViewHelper helper = new GridViewHelper(this.leave_approval_grid);
        helper.RegisterGroup("leavestatus", true, true);

        helper.GroupHeader += new GroupEvent(helper_GroupHeader);

    }

}