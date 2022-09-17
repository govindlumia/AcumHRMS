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
using System.Data;
using DataAccessLayer;

public partial class Leave_admin_pickapprover : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        sqlparam[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);

        if (Request.QueryString["code"] != null)
        {
            if (Request.QueryString["code"].Equals("hr"))
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView();

                        dv = ds.Tables[0].DefaultView;
                        dv.RowFilter = "role=3";
                        empgrid.DataSource = dv;
                        empgrid.DataBind();
                    }
                }
            }
        }
        else
        {
            empgrid.DataSource = null;
            empgrid.DataBind();
        }
 
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
        bindempdetail();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }
    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }
}
