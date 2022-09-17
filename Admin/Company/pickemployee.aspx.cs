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
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class Leave_admin_pickemployee : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            _PageInitialize();
            bindempdetail();
        }
    }

    protected void _PageInitialize()
    {
        //BindDesignation();
        FillControl();
    }
    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(dd_designation, binddrop.BindDropDowns(Session["Company"].ToString(), "Designation"), "id", "designationname");
        BindDropDowns(dd_branch, binddrop.BindDropDowns(Session["Company"].ToString(), "Branch"), "branch_id", "branch_name");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }
    //protected void BindDesignation()
    //{
    //    DesignationENT ObjDesignationENT = new DesignationENT();
    //    DesignationBusiness ObjDesignationBusiness = new DesignationBusiness();

    //    ObjDesignationENT.Id = 0;
    //    ObjDesignationENT.Companyid = Convert.ToInt32(Session["Company"]);
    //    ObjDesignationENT.Status = 1;
    //    ObjDesignationENT.Designationname = "";
    //    ObjDesignationENT.EmployeeCode = Session["EmpCode"].ToString();

    //    ds = ObjDesignationBusiness.SelectDesignation(ObjDesignationENT);

    //    dd_designation.DataSource = ds.Tables[0];
    //    dd_designation.DataBind();
    //}


    protected void bindempdetail()
    {
        EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
        EmpJobDetailBusiness ObjEmpJobDetailBusiness = new EmpJobDetailBusiness();

        ObjEmpJobDetailENT.Empcode = "0";
        ObjEmpJobDetailENT.Degination_id = 0;
        ObjEmpJobDetailENT.Category_id = 0;
        ObjEmpJobDetailENT.Status = true;
        ObjEmpJobDetailENT.Home_Bussiness_unit = 0;
        ObjEmpJobDetailENT.EmployeeCode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.Emp_fname = txtEmpCode.Text.Trim();

        ds = ObjEmpJobDetailBusiness.SelectEmployeeJobDetail(ObjEmpJobDetailENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            empgrid.DataSource = ds.Tables[0];
            empgrid.DataBind();
        }
    }

    //protected void dd_designation_DataBound(object sender, EventArgs e)
    //{
    //    dd_designation.Items.Insert(0, new ListItem("All", "0"));
    //}
    //protected void dd_branch_DataBound(object sender, EventArgs e)
    //{
    //    dd_branch.Items.Insert(0, new ListItem("All", "0"));
    //    bindempdetail();
    //}

    protected void btn_search_Click(object sender, EventArgs e)
    {
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
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnk");
            Label lblValue = (Label)e.Row.FindControl("value");
            lnkValue.Attributes.Add("OnClick", "return returnempcode('" + lblValue.Text + "');");
        }
    }
}