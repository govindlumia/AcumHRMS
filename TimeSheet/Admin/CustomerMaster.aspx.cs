using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Data;
using System.Configuration;

public partial class TimeSheet_Admin_CompanyMaster : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    CommonBusiness commonBusiness = null;
    int CustomerID;
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
                    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
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
                lnkCreate.Visible = true;
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
        BindDropDownBussiness binddrop = new BindDropDownBussiness();
      //  BindDropDowns(ddl_company, binddrop.BindDropDowns("", "Company"), "Id", "CustomerName");
     //   BindDropDowns1(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
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
    //----------------------Bind Grid-------------------

    private DataSet BindCompanyGrid()
   {
        try
        {
            CompanyMasterBussiness CompanyselectAll = new CompanyMasterBussiness();
            CompanyMasterENT CompanyselectENT = new CompanyMasterENT();


         //   CompanyselectENT.Id = Convert.ToInt32(ddl_company.SelectedValue);
           CompanyselectENT.Id=0;
            CompanyselectENT.EmployeeCode = "";
            CompanyselectENT.CompanyName = txt_employee.Text.Trim().ToString();
            CompanyselectENT.CompanyCode = "";
            CompanyselectENT.Pageindex = Int_PageIndex;
            CompanyselectENT.PageSize = Int_Page_Size;
            CompanyselectENT.SortBy = "CustomerName";

            ds = CompanyselectAll.FetchCompanyMaster(CompanyselectENT);

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
    //------------------------Create Company--------------------
    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createdept.Visible = true;
        viewdept.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridDept.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
        txt_dept_code.ReadOnly = false;
        txt_dept_code.Text = "";
        txt_dept_name.Text = "";
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
        if (CreateCompany())
        {
            _GvResultBind();
            reset();
            createdept.Visible = false;
            viewdept.Visible = false;
            GridDept.Visible = true;
            divcreate.Visible = false;
            divSave.Visible = false;
            lnkCreate.Visible = true;
            lnkView.Visible = false;
            clearAll();
        }
       }
    private void clearAll()
    {
        txt_dept_code.Text = "";
        txt_dept_name.Text = "";
    }
    protected bool CreateCompany()
    {
   
        try
        {
            CompanyMasterBussiness CompanyselectAll = new CompanyMasterBussiness();
            CompanyMasterENT CompanyselectENT = new CompanyMasterENT();

            CompanyselectENT.Id = 0;
            CompanyselectENT.CompanyName = txt_dept_name.Text;
            CompanyselectENT.CompanyCode = txt_dept_code.Text;
            CompanyselectENT.Createdby = Session["empcode"].ToString();
            CompanyselectENT.EmployeeCode = "";


            string result = CompanyselectAll.CreateCompanyMaster(CompanyselectENT);

            if (result.Equals("Inserted"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                _GvResultBind();
                return true;
            }
            else if (result.Equals("Already Exist"))
            {
                General.Alert("Record already exist", btncreate);
                txt_dept_code.Focus();
                return false;
            }

        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }
        return false;
    }
    protected void reset()
    {
        
        txt_dept_name.Text = "";
        txt_dept_code.Text = "";

    }

    //------------------------Edit Company-------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Editcompany();
        _GvResultBind();
        clearAll();
    }
    protected void Editcompany()
    {
        try
        {
            CompanyMasterBussiness CompanyselectAll = new CompanyMasterBussiness();
            CompanyMasterENT CompanyselectENT = new CompanyMasterENT();


            CompanyselectENT.CompanyName = txt_dept_name.Text;
            CompanyselectENT.CompanyCode = txt_dept_code.Text;
            CompanyselectENT.Modifiedby = Session["empcode"].ToString();
            CompanyselectENT.EmployeeCode = "";
            CompanyselectENT.Id = Convert.ToInt32(ViewState["CustomerID"].ToString());


            int result = CompanyselectAll.UpdatecompanyMaster(CompanyselectENT);

            if (result > 0)
            {
                General.Alert("Record updated successfully", btnSave);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                lnkCreate.Visible = true;
                lnkView.Visible = false;
                _GvResultBind();
            }

        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }
    }

    protected void CompanyEditDetail(int CustomerID)
    {
        CompanyMasterBussiness CompanyselectAll = new CompanyMasterBussiness();
        CompanyMasterENT CompanyselectENT = new CompanyMasterENT();
        CompanyselectENT.Id = CustomerID;
        CompanyselectENT.EmployeeCode = "";
        CompanyselectENT.CompanyName ="";
        CompanyselectENT.CompanyCode = "";
        CompanyselectENT.Pageindex = 0;
        CompanyselectENT.PageSize = 0;
        CompanyselectENT.SortBy = "CustomerName";

        ds = CompanyselectAll.FetchCompanyMaster(CompanyselectENT);
        dt = ds.Tables[0];
        txt_dept_name.Text = dt.Rows[0]["CustomerName"].ToString();
        txt_dept_code.Text = dt.Rows[0]["CustomerCode"].ToString();
        txt_dept_code.ReadOnly = true;
        lnkCreate.Visible = false;
        lnkView.Visible = true;
    }

    //-----------------------------View Company----------------------
    protected void CompanyViewDetail(int CustomerID2)
    {
        CompanyMasterBussiness CompanyselectAll = new CompanyMasterBussiness();
        CompanyMasterENT CompanyselectENT = new CompanyMasterENT();
        CompanyselectENT.Id = CustomerID2;
        CompanyselectENT.EmployeeCode = "";
        CompanyselectENT.CompanyName = "";
        CompanyselectENT.CompanyCode = "";
        CompanyselectENT.Pageindex = 0;
        CompanyselectENT.PageSize = 0;
        CompanyselectENT.SortBy = "CustomerName";

        ds = CompanyselectAll.FetchCompanyMaster(CompanyselectENT);
        dt = ds.Tables[0];
        LblCmpyName.Text = dt.Rows[0]["CustomerName"].ToString();
        LblDeptName.Text = dt.Rows[0]["CustomerCode"].ToString();

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
    //------------------------------Bind Project By ID----------------

    protected void Grid_Dept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            CustomerID = Convert.ToInt32(e.CommandArgument);
            ViewState["CustomerID"] = CustomerID.ToString();
            createdept.Visible = true;
            viewdept.Visible = false;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            //BindCompany();
            FillControl();
            CompanyEditDetail(CustomerID);



        }
        if (e.CommandName == "View")
        {
            int CustomerID2 = Convert.ToInt32(e.CommandArgument);
            createdept.Visible = false;
            viewdept.Visible = true;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            CompanyViewDetail(CustomerID2);

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
        BindCompanyGrid();
        lnkCreate.Visible = true;
        lnkView.Visible = false;
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

        DataView sortedView = new DataView(BindCompanyGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_Dept.DataSource = sortedView;
        Grid_Dept.DataBind();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Int_Page_Size = Convert.ToInt16(ddlPageSize.SelectedItem.Text.ToString());
        //Int_PageIndex = 1;
        //int_TotalRecords = 0;
        //_GvResultBind();
    }
    private void _GvResultBind()
    {
        DataSet _Ds = BindCompanyGrid();
        if (_Ds.Tables.Count > 1)
        {
            if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
                int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
            else
                int_TotalRecords = 0;

            Grid_Dept.DataSource = _Ds.Tables[0];
          //  Grid_Dept.PageSize = Int_Page_Size;
            Grid_Dept.DataBind();

       //     CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
        }
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
    //    switch (e.CommandName)
    //    {
    //        case "First":
    //            Int_PageIndex = 1;
    //            break;

    //        case "Previous":
    //            Int_PageIndex = Int32.Parse(lblCurrentPage.Text) - 1;

    //            break;

    //        case "Next":
    //            Int_PageIndex = Int32.Parse(lblCurrentPage.Text) + 1;
    //            break;

    //        case "Last":
    //            Int_PageIndex = Int32.Parse(lblTotalPages.Text);
    //            break;
    //    }
    //    _GvResultBind();
}
    protected void btn_search_Click(object sender, EventArgs e)
    {
        Int_PageIndex = 1;
        //Int_Page_Size = 25;
        _GvResultBind();
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Autocomplete_Employee(string prefixText)
    {

        CompanyMasterBussiness balObj = new CompanyMasterBussiness();

        DataTable dt = balObj.getCustomerList(prefixText);

        List<string> ProjectList = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            ProjectList.Add(dt.Rows[i][0].ToString());

        }

        return ProjectList;

    }
}