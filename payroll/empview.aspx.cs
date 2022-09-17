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
using querystring;

public partial class Admin_company_empview : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["updated"] != null)
            message.InnerHtml = "Employee Profile updated successfully";
        if (Request.QueryString["password"] != null)
            message.InnerHtml = "No such employee exists";
        if (Request.QueryString["passwordreset"] != null)
            message.InnerHtml = "Password reseted sucessfully";
       
            
        
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        if (drp_comp_name.SelectedIndex == -1)
            sqlparam[4].Value = 0;
        else
            sqlparam[4].Value = drp_comp_name.SelectedValue;
        sqlparam[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["empcode"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
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

    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }
  
    protected string linkreset(string id)
    {
        query q = new query();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' title='Reset Password'>Reset</a>";
    }

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("All", "0"));
    }

}
