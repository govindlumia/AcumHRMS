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
using querystring;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Admin_company_empviewresign : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            message.InnerHtml = "";
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
                _PageInitialize();
            }
            else
                Response.Redirect("~/notlogged.aspx");

            //if (Request.QueryString["updated"] != null)
            //    message.InnerHtml = "Employee Profile updated successfully";
            //if (Request.QueryString["password"] != null)
            //    message.InnerHtml = "No such employee exists";
            //if (Request.QueryString["passwordreset"] != null)
            //    message.InnerHtml = "Password reseted sucessfully";
        }
    }

    protected void _PageInitialize()
    {
        FillControl();
        bindempdetail();
    }


    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddl_company, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(dd_category, binddrop.BindDropDowns(ddl_company.SelectedValue, "Category"), "ID", "CategoryName");
        BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.Trim();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = Convert.ToInt32(dd_designation.SelectedValue);

        sqlparam[2] = new SqlParameter("@category", SqlDbType.Int);
        sqlparam[2].Value = Convert.ToInt32(dd_category.SelectedValue);

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "Past";

        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = Session["empcode"].ToString();

        sqlparam[5] = new SqlParameter("@comp", SqlDbType.VarChar, 50);
       sqlparam[5].Value=ddl_company.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_resign_emp_detail", sqlparam);
        ViewState["EmpDetails"] = ds.Tables[0];
        
        empgrid.DataSource = ds;
        empgrid.DataBind();
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink view = (HyperLink)e.Row.Cells[5].Controls[0];
           // HyperLink edit = (HyperLink)e.Row.Cells[6].Controls[0];

            view.ToolTip = "View";
        //    edit.ToolTip = "Edit";
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }
    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        }
        set
        {
            ViewState["dirState"] = value;
        }
    }
    protected void empgrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            sortingDirection = "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            sortingDirection = "Asc";
        }
        if (ViewState["EmpDetails"] != null)
        {
            DataView sortedView = new DataView((DataTable)ViewState["EmpDetails"]);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            empgrid.DataSource = sortedView;
            empgrid.DataBind();
        }
        }

    protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(dd_category, binddrop.BindDropDowns(ddl_company.SelectedValue, "Category"), "ID", "CategoryName");
        BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
    }
}

