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

public partial class Leave_admin_OverViewAttendanceRule : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            GridViewHelper helper = new GridViewHelper(this.rulegrid);
            helper.RegisterGroup("policyname", true, true);

            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            //helper.ApplyGroupSort();

            message.InnerHtml = "";

            if (Request.QueryString["edit_adjust"] != null)
            {
                message.InnerHtml = " Attendance rule updated successfully ";
            }

            if (Request.QueryString["updated"] != null)
            {
                message.InnerHtml = "Attendance rule updated successfully.";
            }


            if (Request.QueryString["edit_club"] != null)
            {
                message.InnerHtml = "Leave clubbing updated successfully";
            }
        }
        bindleaverule();

    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "policyname")
        {
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }
    protected void bindleaverule()
    {
        sqlstr = @"select distinct
         lp.Policyid,lp.policyname  from tbl_Leave_Attendance_Master am inner join tbl_leave_createleavepolicy lp
        on am.Policyid =lp.policyid inner join tbl_Leave_attendance_ActionType_Master aam on 
        aam.id=am.ActionId";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        rulegrid.DataSource = ds;
        rulegrid.DataBind();
    }
}