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


public partial class pickempdataforfullandfinal : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
   // bool isNewCheckPoint = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Con"] != null)
        {
            hidden_con.Value = Request.QueryString["Con"].ToString();
        }
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindDropDown(ddl_company, "tbl_intranet_companydetails", "companyid", "companyname", "1=1");
            if (!ddl_company.SelectedValue.Equals("0"))
            {
                bindDropDown(dd_branch, "tbl_category_master", "ID", "CategoryName", "companyid=" + ddl_company.SelectedValue + "");
                bindDropDown(dd_designation, "tbl_designationmaster", "ID", "designationname", "companyid=" + ddl_company.SelectedValue + "");
            }
            else
            {
                bindDropDown(dd_branch, "tbl_category_master", "ID", "CategoryName", "1=1");
                bindDropDown(dd_designation, "tbl_designationmaster", "ID", "designationname", "1=1");
            }
            bindempdetail();

        }


    }

    protected void bindDropDown(object ddl, string tableName, string columnForValue, string columnForText, string where)
    {
        string query = "select distinct " + columnForValue + "," + columnForText + " from " + tableName + " where  " + where + " ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, query, null);
        DropDownList ddl_inner = (DropDownList)ddl;
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_inner.DataSource = ds.Tables[0];
                ddl_inner.DataValueField = columnForValue;
                ddl_inner.DataTextField = columnForText;
                ddl_inner.DataBind();

            }
        }
    }


    protected void bindempdetail()
    {
            DataTable dt_result = null;
            if (ViewState["dataForGrid"] == null)
            {
                SqlParameter[] sqlparam = new SqlParameter[5];

                sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
                sqlparam[0].Value = Session["empcode"].ToString();

                sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
                sqlparam[1].Value = txt_employee.Text;

                sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
                sqlparam[2].Value = dd_designation.SelectedValue;

                sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
                sqlparam[3].Value = dd_branch.SelectedValue;
             
                sqlparam[4] = new SqlParameter("@comp", SqlDbType.VarChar);
                sqlparam[4].Value = ddl_company.SelectedValue.ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_fetch_employee_detail_with_filter_for_fnf", sqlparam);


                dt_result = ds.Tables[0];
                ViewState["dataForGrid"] = dt_result;

            }
            else
            {
                dt_result = (DataTable)ViewState["dataForGrid"];
            }
            if (dt_result.Rows.Count > 0)
            {
                empgrid.DataSource = dt_result;
                empgrid.DataBind();
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
        // bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        empgrid.PageIndex = 0;
        ViewState["dataForGrid"] = null;
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
        Response.Redirect("createemployeeprofile.aspx?empcode=" + Request.QueryString["empcode"] + "");
    }
    protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddl_company.SelectedValue.Equals("0"))
        {
            bindDropDown(dd_branch, "tbl_category_master", "ID", "CategoryName", "companyid=" + ddl_company.SelectedValue + "");
            bindDropDown(dd_designation, "tbl_designationmaster", "ID", "designationname", "companyid=" + ddl_company.SelectedValue + "");
        }
        else
        {
            bindDropDown(dd_branch, "tbl_category_master", "ID", "CategoryName", "1=1");
            bindDropDown(dd_designation, "tbl_designationmaster", "ID", "designationname", "1=1");
        }
    }
    protected void ddl_company_DataBound(object sender, EventArgs e)
    {
        ddl_company.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void btn_clearall_Click(object sender, EventArgs e)
    {
        ddl_company.SelectedValue = "0";
        dd_designation.SelectedValue = "0";
        dd_branch.SelectedValue = "0";
        txt_employee.Text = "";
        chk_empstatus.Checked = false;
        empgrid.DataSource = null;
        empgrid.DataBind();
    }
}