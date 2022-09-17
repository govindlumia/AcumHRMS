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


public partial class Admin_Company_DepartmentDetail : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    CommonBusiness commonBusiness = null;
    int DepartmentID;
    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 25;
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() != "1" || Session["role"].ToString() != "2")
                        Response.Redirect("~/Authenticate.aspx");
                        
                }
                else
                    Response.Redirect("~/notlogged.aspx");
                FillControl();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                lnkView.Visible = false;
                _GvResultBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
  
    //---------------------Bind Company------------------

    protected void FillControl()
    {
        commonBusiness = new CommonBusiness();
        BindDropDowns(drp_comp_name, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns1(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDowns(ddl_company, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddl_Department, commonBusiness.BindDropDowns("", "Category"), "ID", "CategoryName");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    private void BindDropDowns1(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
       
    }
    protected void ddl_company_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddl_Department, binddrop.BindDropDowns(ddl_company.SelectedValue, "Category"), "ID", "CategoryName");
    }
    
    //----------------------Bind Grid-------------------
    private  DataSet BindDepartmentGrid()
    {
        try
        {
            DepartmentBussiness deptselectAll = new DepartmentBussiness();
            DepartmentENT deptselectENT = new DepartmentENT();


            deptselectENT.Departmentid = Convert.ToInt32(ddl_Department.SelectedValue);
            deptselectENT.EmployeeCode = "";
            deptselectENT.Companyid = Convert.ToInt32(ddl_company.SelectedValue);
            deptselectENT.Department_name = txt_employee.Text.Trim().ToString();
            deptselectENT.Department_code = "";
            deptselectENT.Pageindex = Int_PageIndex;
            deptselectENT.PageSize = Int_Page_Size;
            deptselectENT.SortBy = "CategoryName";

            ds = deptselectAll.FetchDepartment(deptselectENT);
           
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }

        return ds;
    }
     //------------------------Create Department--------------------

   

    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createdept.Visible = true;
        viewdept.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridDept.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createdept.Visible = false;
        viewdept.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;

        GridDept.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }


    protected void btncreate_Click(object sender, EventArgs e)
    {
        CreateDepartment();
        _GvResultBind();
        reset();
        createdept.Visible = false;
        viewdept.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
    }

    protected void CreateDepartment()
    {
        try
        {
            DepartmentENT deptselectENT = new DepartmentENT();
            deptselectENT.Departmentid = 0;
            deptselectENT.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            deptselectENT.Department_name = txt_dept_name.Text;
            deptselectENT.Department_code = txt_dept_code.Text;
            deptselectENT.CreatedBy = Session["empcode"].ToString();
            deptselectENT.EmployeeCode = "";

            DepartmentBussiness deptselectAll = new DepartmentBussiness();
            int result = deptselectAll.CreateDepartment(deptselectENT);

            if (result == 1)
            {
                General.Alert("Record Save Successfully", btncreate);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;

            }

        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }
    }
    protected void reset()
    {
        drp_comp_name.SelectedValue = "0";
        txt_dept_name.Text = "";
        txt_dept_code.Text = "";

    }
    protected void btnsavenew_Click(object sender, EventArgs e)
    {
        saveandaddnew();
    }

    protected void saveandaddnew()
    {
        try
        {
            DepartmentENT deptselectENT = new DepartmentENT();
            deptselectENT.Departmentid = 0;
            deptselectENT.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            deptselectENT.Department_name = txt_dept_name.Text;
            deptselectENT.Department_code = txt_dept_code.Text;
            deptselectENT.CreatedBy = Session["empcode"].ToString();
            deptselectENT.EmployeeCode = "";

            DepartmentBussiness deptselectAll = new DepartmentBussiness();
            int result = deptselectAll.CreateDepartment(deptselectENT);

            if (result == 1)
            {
                General.Alert("Record Save Successfully", btncreate);
                reset1();
                createdept.Visible = true;
                viewdept.Visible = false;
                GridDept.Visible = false;
                divcreate.Visible = true;
                divSave.Visible = false;

            }
        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }
    }
    protected void reset1()
    {
        txt_dept_name.Text = "";
        txt_dept_code.Text = "";
    }
    //------------------------Edit Department-------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditDepartment();
        _GvResultBind();
    }
    protected void EditDepartment()
    {
        try
        {
            DepartmentENT deptselectENT = new DepartmentENT();
           
            deptselectENT.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            deptselectENT.Department_name = txt_dept_name.Text;
            deptselectENT.Department_code = txt_dept_code.Text;
            deptselectENT.ModifiedBy = Session["empcode"].ToString();
            deptselectENT.EmployeeCode = "";
            deptselectENT.Departmentid = Convert.ToInt32(ViewState["DepartmentID"].ToString());

            DepartmentBussiness deptselectAll = new DepartmentBussiness();
            int result = deptselectAll.UpdateDepartment(deptselectENT);

            if (result > 0)
            {
                General.Alert("Record Update Successfully", btnSave);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;

            }

        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }
    }

    protected void DepartmentEditDetail(int DepartmentID)
    {
        DepartmentBussiness deptselectAll = new DepartmentBussiness();
        DepartmentENT deptselectENT = new DepartmentENT();
        deptselectENT.Departmentid = DepartmentID;
        deptselectENT.EmployeeCode = "";
        deptselectENT.Company_name = "";
        deptselectENT.Department_name = "";
        deptselectENT.Department_code = "";
        deptselectENT.Pageindex = 0;
        deptselectENT.PageSize = 0;
        deptselectENT.SortBy = "department_name";

        ds = deptselectAll.FetchDepartment(deptselectENT);
        dt = ds.Tables[0];
        drp_comp_name.SelectedValue = dt.Rows[0]["CompanyId"].ToString();
        txt_dept_name.Text = dt.Rows[0]["CategoryName"].ToString();
        txt_dept_code.Text = dt.Rows[0]["CategoryCode"].ToString();
    }
    //-----------------------------View Deparment----------------------


    protected void DepartmentViewDetail(int DepartmentID2)
    {
        DepartmentBussiness deptselectAll = new DepartmentBussiness();
        DepartmentENT deptselectENT = new DepartmentENT();
        deptselectENT.Departmentid = DepartmentID2;
        deptselectENT.EmployeeCode = "";
        deptselectENT.Company_name = "";
        deptselectENT.Department_name = "";
        deptselectENT.Department_code = "";
        deptselectENT.Pageindex = 0;
        deptselectENT.PageSize = 0;
        deptselectENT.SortBy = "department_name";

        ds = deptselectAll.FetchDepartment(deptselectENT);
        dt = ds.Tables[0];
        LblCmpyName.Text = dt.Rows[0]["companyname"].ToString();
        LblDeptName.Text = dt.Rows[0]["CategoryName"].ToString();
        LblDeptCode.Text = dt.Rows[0]["CategoryCode"].ToString();

    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createdept.Visible = false;
        viewdept.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
    }
    //------------------------------Bind Department By ID----------------

    protected void Grid_Dept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            DepartmentID = Convert.ToInt32(e.CommandArgument);
            ViewState["DepartmentID"] = DepartmentID.ToString();
            createdept.Visible = true;
            viewdept.Visible = false;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            //BindCompany();
            FillControl();
            DepartmentEditDetail(DepartmentID);
            


        }
        if (e.CommandName == "View")
        {
            int DepartmentID2 = Convert.ToInt32(e.CommandArgument);
            createdept.Visible = false;
            viewdept.Visible = true;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            DepartmentViewDetail(DepartmentID2);

        }
    }
    protected void Grid_Dept_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Dept.PageIndex = e.NewPageIndex;
        _GvResultBind();

    }
    protected void Grid_Dept_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    //----------------------------Cancel button ---------------------------
    protected void Btncancel1_Click(object sender, EventArgs e)
    {
        createdept.Visible = false;
        viewdept.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        BindDepartmentGrid();
    }
    //-----------------------Custom Paging---------------------------------
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
    protected void Grid_Dept_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindDepartmentGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_Dept.DataSource = sortedView;
        Grid_Dept.DataBind();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int_Page_Size = Convert.ToInt16(ddlPageSize.SelectedItem.Text.ToString());
        Int_PageIndex = 1;
        int_TotalRecords = 0;
        _GvResultBind();
    }
    private void _GvResultBind()
    {
        DataSet _Ds = BindDepartmentGrid();

        if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
            int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        else
            int_TotalRecords = 0;

        Grid_Dept.DataSource = _Ds.Tables[0];
        Grid_Dept.PageSize = Int_Page_Size;
        Grid_Dept.DataBind();

        CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
    }
    public void CustomPaging(Label lblTotalPages, Label lblCurrentPage, int cp, double totalRows, LinkButton Btn_Previous, LinkButton Btn_Next)
    {
        lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblCurrentPage.Text = cp.ToString();

        if (cp == 1)
        {
            Btn_Previous.Enabled = false;
            Btn_Next.Enabled = false;
            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                Btn_Previous.Enabled = false;
                Btn_Next.Enabled = true;
            }
            else
            {
                Btn_Previous.Enabled = true;
                Btn_Next.Enabled = true;
            }

            if ((Int32.Parse(lblTotalPages.Text) == 1) && (Int32.Parse(lblCurrentPage.Text) == 1))
            {
                Btn_Previous.Enabled = false;
                Btn_Next.Enabled = false;
            }
        }
        else
        {
            Btn_Previous.Enabled = true;

            if (cp == Int32.Parse(lblTotalPages.Text))
            {
                Btn_Next.Enabled = false;
            }

            else
            {
                Btn_Next.Enabled = true;
            }
        }


    }
    private int CalculateTotalPages(double totalRecords)
    {
        int totalPages = (int)Math.Ceiling(totalRecords / Int_Page_Size);
        return totalPages;
    }
    public void ButtonEvent(int pageNo)
    {
        Int_PageIndex = pageNo;
    }
    protected void ChangePage(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "First":
                Int_PageIndex = 1;
                break;

            case "Previous":
                Int_PageIndex = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":
                Int_PageIndex = Int32.Parse(lblCurrentPage.Text) + 1;
                break;

            case "Last":
                Int_PageIndex = Int32.Parse(lblTotalPages.Text);
                break;
        }
        _GvResultBind();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        Int_PageIndex = 1;
        //Int_Page_Size = 25;
        _GvResultBind();
    }
   
}