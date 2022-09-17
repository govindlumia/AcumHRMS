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

public partial class Admin_Company_RoleDetail : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    int RoleID;
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
                createrole.Visible = false;
                viewrole.Visible = false;
                Gridrole.Visible = true;
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
    //----------------------Bind Grid-------------------
    private DataSet BindRoleGrid()
    {
        try
        {
            RoleBussiness RoleselectAll = new RoleBussiness();
            RoleENT roleENT = new RoleENT();
            roleENT.Id = Convert.ToInt32(dd_role.SelectedValue);
            roleENT.EmployeeCode="";
            roleENT.Role = txt_employee.Text.Trim().ToString();
            roleENT.Description = "";
            roleENT.Pageindex = Int_PageIndex;
            roleENT.PageSize = Int_Page_Size;
            roleENT.SortBy = "role";

            ds = RoleselectAll.FetchRole(roleENT);
            
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
    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns1(dd_role, binddrop.BindDropDowns("", "Role"), "id", "role");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    private void BindDropDowns1(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    //------------------------Create Role--------------------

   

    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createrole.Visible = true;
        viewrole.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        Gridrole.Visible = false;
        // divPaging.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createrole.Visible = false;
        viewrole.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        Gridrole.Visible = true;
        //divPaging.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }


    protected void btncreate_Click(object sender, EventArgs e)
    {
        CreateRole();
        _GvResultBind();
    }
    protected void CreateRole()
    {
        try
        {
            RoleENT roleENT = new RoleENT();
            roleENT.Id = 0;
            roleENT.Role = txt_role_code.Text;
            roleENT.Description = txt_role.Text;
            roleENT.Createdby = Session["empcode"].ToString();
            roleENT.EmployeeCode = "";
            RoleBussiness RoleselectAll = new RoleBussiness();

            string result = RoleselectAll.CreateRole(roleENT);

            if (result == "1")
            {
                General.Alert("Record Save Successfully", btncreate);
                reset();
                createrole.Visible = false;
                viewrole.Visible = false;
                Gridrole.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;

            }
            else
            {
                General.Alert("Record Already Exist", btncreate);
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
        txt_role_code.Text = "";
        txt_role.Text = "";
    }
    protected void btnsavenew_Click(object sender, EventArgs e)
    {
        saveandaddnew();
    }
    protected void saveandaddnew()
    {
        try
        {
            RoleENT roleENT = new RoleENT();
            roleENT.Id = 0;
            roleENT.Role = txt_role_code.Text;
            roleENT.Description = txt_role.Text;
            roleENT.Createdby = Session["empcode"].ToString();
            roleENT.EmployeeCode = "";

            RoleBussiness RoleselectAll = new RoleBussiness();
            string result = RoleselectAll.CreateRole(roleENT);

            if (result == "1")
            {
                General.Alert("Record Save Successfully", btncreate);
                reset();
                createrole.Visible = true;
                viewrole.Visible = false;
                Gridrole.Visible = false;
                divcreate.Visible = true;
                divSave.Visible = false;
            }
            else
            {
                General.Alert("Record exist", btncreate);
            }
        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }

    }
    //---------------------------- Update role--------------------

    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditRole();
        _GvResultBind();
    }
    protected void EditRole()
    {
        try
        {
            RoleENT roleENT = new RoleENT();
            roleENT.Role = txt_role_code.Text;
            roleENT.Description = txt_role.Text;
            roleENT.Modifiedby = Session["empcode"].ToString();
            roleENT.EmployeeCode = "";
            roleENT.Id = Convert.ToInt32(ViewState["RoleID"].ToString());


            RoleBussiness RoleselectAll = new RoleBussiness();
            string result = RoleselectAll.UpdateRole(roleENT);

            if (result == "1")
            {
                General.Alert("Record Update Successfully", btnSave);
                reset();
                createrole.Visible = false;
                viewrole.Visible = false;
                Gridrole.Visible = true;
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
    protected void RoleEditDetail(int RoleID)
    {
        RoleBussiness RoleselectAll = new RoleBussiness();
       RoleENT roleENT = new RoleENT();
       roleENT.Id = RoleID;
       roleENT.EmployeeCode = "";
       roleENT.Role = "";
       roleENT.Description = "";
       roleENT.Pageindex = 0;
       roleENT.PageSize = 0;
       roleENT.SortBy = "role";

       ds = RoleselectAll.FetchRole(roleENT);
        dt = ds.Tables[0];
        txt_role_code.Text = dt.Rows[0]["role"].ToString();
        txt_role.Text = dt.Rows[0]["description"].ToString();
    }
    //-------------------cancel button-------------------------------------
    protected void Btncancel1_Click(object sender, EventArgs e)
    {
        createrole.Visible = false;
        viewrole.Visible = false;
        Gridrole.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }
    //--------------------------View role---------------------------------

    protected void RoleViewDetail(int RoleID1)
    {
        RoleBussiness RoleselectAll = new RoleBussiness();
        RoleENT roleENT = new RoleENT();
        roleENT.Id = RoleID1;
        roleENT.EmployeeCode = "";
        roleENT.Role = "";
        roleENT.Description = "";
        roleENT.Pageindex = 0;
        roleENT.PageSize = 0;
        roleENT.SortBy = "role";

        ds = RoleselectAll.FetchRole(roleENT);
        dt = ds.Tables[0];
        Lblrolecode.Text = dt.Rows[0]["role"].ToString();
        Lblrole.Text = dt.Rows[0]["description"].ToString();

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createrole.Visible = false;
        viewrole.Visible = false;
        Gridrole.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }
    //-------------------- Bind Role By ID---------------------

    protected void Grid_role_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            RoleID = Convert.ToInt32(e.CommandArgument);
            ViewState["RoleID"] = RoleID.ToString();
            createrole.Visible = true;
            viewrole.Visible = false;
            Gridrole.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            RoleEditDetail(RoleID);



        }
        if (e.CommandName == "View")
        {
            int RoleID1 = Convert.ToInt32(e.CommandArgument);
            createrole.Visible = false;
            viewrole.Visible = true;
            Gridrole.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            RoleViewDetail(RoleID1);

        }
    }
    protected void Grid_role_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_role.PageIndex = e.NewPageIndex;
        _GvResultBind();

    }
    protected void Grid_role_RowEditing(object sender, GridViewEditEventArgs e)
    {

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
    protected void Grid_role_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindRoleGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_role.DataSource = sortedView;
        Grid_role.DataBind();
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
        DataSet _Ds = BindRoleGrid();

        if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
            int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        else
            int_TotalRecords = 0;

        Grid_role.DataSource = _Ds.Tables[0];
        Grid_role.PageSize = Int_Page_Size;
        Grid_role.DataBind();

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