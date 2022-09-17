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
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class Leave_admin_createemployeeprofile : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
    DataView dview;
    Boolean add;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            Session.Remove("hiearchy");
            GridViewHelper helper = new GridViewHelper(this.grid_customizerule);
            helper.RegisterGroup("policyname", true, true);

            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            fetchemphierarchy();           
        }
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
    protected void fetchemphierarchy()
    {
        lbl_empcode.Text = Request.QueryString["empcode"].ToString();
        SqlParameter sqlparm = new SqlParameter("@empid", Request.QueryString["empcode"].ToString());
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_hr.Text = ds.Tables[0].Rows[0]["approverid"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            approvalgrid.DataSource = ds.Tables[1];
            approvalgrid.DataBind();
        }
    }
    protected void create_approver_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("empcode", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"] };
        dtable.Columns.Add(new DataColumn("name", typeof(string)));
        dtable.Columns.Add(new DataColumn("level", typeof(int)));
        Session["hiearchy"] = dtable;
    }


    protected void createhiearchy()
    {
        if (Session["hiearchy"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["hiearchy"];
            dview = new DataView(dtable);
            dview.Sort = "level";
        }
    }
    protected void bindapprovallist()
    {
        dtable = (DataTable)Session["hiearchy"];
        dview = new DataView(dtable);
        dview.Sort = "level";
        approvalgrid.DataSource = dview;
        approvalgrid.DataBind();      
    }
}










