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

public partial class TimeSheet_Admin_TimesheetStatus : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    int StatusID;
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
                createtimesheetstatus.Visible = false;
                viewtimesheetstatus.Visible = false;
                GridempStatus.Visible = true;
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

    //-----------------------Fill Dropdown------------------
    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDownBussiness binddrop = new BindDropDownBussiness();
        BindDropDowns1(dd_Status, binddrop.BindDropDowns("", "TimeSheetStatus"), "Id", "SaveMode");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        if (ddl.ID.Equals("ddlPageSize"))
        {
            ddl.SelectedIndex = 1;
        }
    }
    private void BindDropDowns1(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    //----------------------Bind Grid-------------------
    private DataSet BindStatusGrid()
    {
        try
        {
            TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();
            TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
            statusENT.Id = Convert.ToInt32(dd_Status.SelectedValue);
            statusENT.TimeSheetStatus = txt_employee.Text.Trim().ToString();
            statusENT.Description = "";
            statusENT.Pageindex = Int_PageIndex;
            statusENT.PageSize = Int_Page_Size;
            statusENT.SortBy = "SaveMode";

            ds = StatusselectAll.FetchTimeSheetStatus(statusENT);
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

    //------------------------Create Status--------------------

    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createtimesheetstatus.Visible = true;
        viewtimesheetstatus.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridempStatus.Visible = false;
        // divPaging.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createtimesheetstatus.Visible = false;
        viewtimesheetstatus.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;

        GridempStatus.Visible = true;
        //divPaging.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }

    protected void btncreate_Click(object sender, EventArgs e)
    {
        CreateStatus();
        BindStatusGrid();
    }
    protected void CreateStatus()
    {
        try
        {
           
            TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
            statusENT.Id = 0;
            statusENT.TimeSheetStatus = txt_time_status.Text;
            statusENT.Description = txt_desc.Text;
            statusENT.Createdby = Session["empcode"].ToString();
            statusENT.EmployeeCode = Session["empcode"].ToString();
            TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();

            string result = StatusselectAll.CreateTimeSheetStatus(statusENT);

            if (result.Equals("Inserted"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset();
                createtimesheetstatus.Visible = false;
                viewtimesheetstatus.Visible = false;
                GridempStatus.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                lnkCreate.Visible = true;
                lnkView.Visible = false;
                _GvResultBind();

            }
            else if (result.Equals("Already Exist"))
            {
                General.Alert("Record already exist", btncreate);
                txt_time_status.Focus();
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
        txt_time_status.Text = "";
        txt_desc.Text = "";
    }
    protected void btnsavenew_Click(object sender, EventArgs e)
    {
        saveandaddnew();
    }
    protected void saveandaddnew()
    {
        try
        {
            TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
            statusENT.Id = 0;
            statusENT.TimeSheetStatus = txt_time_status.Text;
            statusENT.Description = txt_desc.Text;
            statusENT.Createdby = Session["empcode"].ToString();
            statusENT.EmployeeCode = Session["empcode"].ToString();

            TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();
            string result = StatusselectAll.CreateTimeSheetStatus(statusENT);

            if (result.Equals("Inserted"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset();
                createtimesheetstatus.Visible = true;
                viewtimesheetstatus.Visible = false;
                GridempStatus.Visible = false;
                divcreate.Visible = true;
                divSave.Visible = false;
                _GvResultBind();
            }
            else if (result.Equals("Already Exist"))
            {
                General.Alert("Record already exist", btncreate);
                txt_time_status.Focus();
            }
        }
        catch (SystemException ex)
        {
        }
        finally
        {
        }

    }

    //---------------------------- Update Status--------------------

    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditStatus();
        BindStatusGrid();
    }
    protected void EditStatus()
    {
        try
        {
            TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
            statusENT.TimeSheetStatus = txt_time_status.Text;
            statusENT.Description = txt_desc.Text;
            statusENT.Modifiedby = Session["empcode"].ToString();
            statusENT.EmployeeCode = Session["empcode"].ToString();
            statusENT.Id = Convert.ToInt32(ViewState["StatusID"].ToString());

            TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();
            string result = StatusselectAll.UpdateTimeSheetStatus(statusENT);

            if (result == "1")
            {
                General.Alert("Record updated successfully", btnSave);
                reset();
                createtimesheetstatus.Visible = false;
                viewtimesheetstatus.Visible = false;
                GridempStatus.Visible = true;
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
    protected void StausEditDetail(int StatusID)
    {
        TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();
        TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
        statusENT.Id = StatusID;
        statusENT.TimeSheetStatus = "";
        statusENT.Description = "";
        statusENT.Pageindex = 0;
        statusENT.PageSize = 0;
        statusENT.SortBy = "SaveMode";

        ds = StatusselectAll.FetchTimeSheetStatus(statusENT);
        dt = ds.Tables[0];
        txt_time_status.Text = dt.Rows[0]["SaveMode"].ToString();
        txt_desc.Text = dt.Rows[0]["Description"].ToString();
    }
    //-------------------cancel button-------------------------------------
    protected void Btncancel1_Click(object sender, EventArgs e)
    {
        createtimesheetstatus.Visible = false;
        viewtimesheetstatus.Visible = false;
        GridempStatus.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        lnkCreate.Visible = true;
        lnkView.Visible = false;
        BindStatusGrid();
        reset();
    }

    //--------------------------View Status---------------------------------

    protected void StatusViewDetail(int StatusID2)
    {
        TimeSheetStatusBussiness StatusselectAll = new TimeSheetStatusBussiness();
        TimeSheetStatusENT statusENT = new TimeSheetStatusENT();
        statusENT.Id = StatusID2;
        statusENT.TimeSheetStatus = "";
        statusENT.Description = "";
        statusENT.Pageindex = 0;
        statusENT.PageSize = 0;
        statusENT.SortBy = "Status";

        ds = StatusselectAll.FetchTimeSheetStatus(statusENT);
        dt = ds.Tables[0];
        LblEmpStatus.Text = dt.Rows[0]["SaveMode"].ToString();
        LblDesc.Text = dt.Rows[0]["Description"].ToString();

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createtimesheetstatus.Visible = false;
        viewtimesheetstatus.Visible = false;
        GridempStatus.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        BindStatusGrid();
        reset();
    }

    //-------------------- Bind Status By ID---------------------

    protected void Grid_empstatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            StatusID = Convert.ToInt32(e.CommandArgument);
            ViewState["StatusID"] = StatusID.ToString();
            createtimesheetstatus.Visible = true;
            viewtimesheetstatus.Visible = false;
            GridempStatus.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            StausEditDetail(StatusID);



        }
        if (e.CommandName == "View")
        {
            int StatusID2 = Convert.ToInt32(e.CommandArgument);
            createtimesheetstatus.Visible = false;
            viewtimesheetstatus.Visible = true;
            GridempStatus.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            StatusViewDetail(StatusID2);

        }
    }
    protected void Grid_empstatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_empstatus.PageIndex = e.NewPageIndex;
        BindStatusGrid();

    }
    protected void Grid_empstatus_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    //---------------------Custom Paging------------------
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
    protected void Grid_empstatus_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindStatusGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_empstatus.DataSource = sortedView;
        Grid_empstatus.DataBind();
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
        DataSet _Ds = BindStatusGrid();
        if (_Ds.Tables.Count > 1)
        {
            if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
                int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
            else
                int_TotalRecords = 0;

            Grid_empstatus.DataSource = _Ds.Tables[0];
            Grid_empstatus.PageSize = Int_Page_Size;
            Grid_empstatus.DataBind();

            CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
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