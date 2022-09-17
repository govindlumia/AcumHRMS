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

public partial class Admin_Company_EmployeeCodeCounter : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    int CounterID;
    CommonBusiness commonBusiness = null;
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
                createcodecounter.Visible = false;
                viewCodeCounter.Visible = false;
                GridCodeCounter.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                lnkView.Visible = false;
                _GvResultBind();
            }
            drp_comp_name.Enabled = true;
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
        BindDropDowns(dd_company, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
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

    private DataSet BindCodeCounterGrid()
    {
        try
        {
            EmpCodeCounterBusiness CodeCounterAll = new EmpCodeCounterBusiness();
            CompanyENT CmpyENT = new CompanyENT();
            CmpyENT.ID = 0;
            CmpyENT.Companyid = Convert.ToInt32(dd_company.SelectedValue);
            CmpyENT.Pageindex = Int_PageIndex;
            CmpyENT.PageSize = Int_Page_Size;
            CmpyENT.SortBy = "companyname";

            ds = CodeCounterAll.FetchEmpCounterNo(CmpyENT);

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

    //------------------------Create Role--------------------



    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createcodecounter.Visible = true;
        viewCodeCounter.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridCodeCounter.Visible = false;
        // divPaging.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createcodecounter.Visible = false;
        viewCodeCounter.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;

        GridCodeCounter.Visible = true;
        //divPaging.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }


    protected void btncreate_Click(object sender, EventArgs e)
    {
        CreateEmpCodeCounter();
        _GvResultBind();
    }
    protected void CreateEmpCodeCounter()
    {
        try
        {
            CompanyENT CmpyENT = new CompanyENT();
            CmpyENT.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            CmpyENT.CounterNo = txt_Code.Text;
            CmpyENT.EmployeeCode = Session["empcode"].ToString();
            EmpCodeCounterBusiness CodeCounterAll = new EmpCodeCounterBusiness();

            string result = CodeCounterAll.CreateEmpCounterNo(CmpyENT);

            if (result == "1")
            {
                General.Alert("Record Save Successfully", btncreate);
                reset();
                createcodecounter.Visible = false;
                viewCodeCounter.Visible = false;
                GridCodeCounter.Visible = true;
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
        drp_comp_name.SelectedValue = "0";
        txt_Code.Text = "";
    }

    //---------------------------- Update role--------------------

    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditEmpCodeCounter();
        _GvResultBind();
    }
    protected void EditEmpCodeCounter()
    {
        try
        {
            CompanyENT CmpyENT = new CompanyENT();
            CmpyENT.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            CmpyENT.CounterNo = txt_Code.Text;
            CmpyENT.EmployeeCode = Session["empcode"].ToString();
            CmpyENT.ID = Convert.ToInt32(ViewState["CounterID"].ToString());


            EmpCodeCounterBusiness CodeCounterAll = new EmpCodeCounterBusiness();
            string result = CodeCounterAll.UpdateEmpCounterNo(CmpyENT);

            if (result == "1")
            {
                General.Alert("Record Update Successfully", btnSave);
                reset();
                createcodecounter.Visible = false;
                viewCodeCounter.Visible = false;
                GridCodeCounter.Visible = true;
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
    protected void EmpCodeEditDetail(int CounterID)
    {
        EmpCodeCounterBusiness CodeCounterAll = new EmpCodeCounterBusiness();
        CompanyENT CmpyENT = new CompanyENT();
        CmpyENT.ID = CounterID;
        CmpyENT.Companyid = 0;
        CmpyENT.Pageindex = 0;
        CmpyENT.PageSize = 0;
        CmpyENT.SortBy = "companyname";


        ds = CodeCounterAll.FetchEmpCounterNo(CmpyENT);
        dt = ds.Tables[0];
        drp_comp_name.SelectedValue = dt.Rows[0]["Companyid"].ToString();
        txt_Code.Text = dt.Rows[0]["Counter"].ToString();
    }
    //-------------------cancel button-------------------------------------
    protected void Btncancel1_Click(object sender, EventArgs e)
    {
        createcodecounter.Visible = false;
        viewCodeCounter.Visible = false;
        GridCodeCounter.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }
    //--------------------------View role---------------------------------

    protected void EmpCodeViewDetail(int CounterID1)
    {
        EmpCodeCounterBusiness CodeCounterAll = new EmpCodeCounterBusiness();
        CompanyENT CmpyENT = new CompanyENT();
        CmpyENT.ID = CounterID1;
        CmpyENT.Companyid = 0;
        CmpyENT.Pageindex = 0;
        CmpyENT.PageSize = 0;
        CmpyENT.SortBy = "companyname";

        ds = CodeCounterAll.FetchEmpCounterNo(CmpyENT);
        dt = ds.Tables[0];
        Lblcmpyname.Text = dt.Rows[0]["companyname"].ToString();
        Lblcounter.Text = dt.Rows[0]["Counter"].ToString();

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createcodecounter.Visible = false;
        viewCodeCounter.Visible = false;
        GridCodeCounter.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }
    //-------------------- Bind Role By ID---------------------

    protected void Grid_counter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            CounterID = Convert.ToInt32(e.CommandArgument);
            ViewState["CounterID"] = CounterID.ToString();
            createcodecounter.Visible = true;
            viewCodeCounter.Visible = false;
            GridCodeCounter.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            EmpCodeEditDetail(CounterID);



        }
        if (e.CommandName == "View")
        {
            int CounterID1 = Convert.ToInt32(e.CommandArgument);
            createcodecounter.Visible = false;
            viewCodeCounter.Visible = true;
            GridCodeCounter.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            EmpCodeViewDetail(CounterID1);

        }
    }
    protected void Grid_counter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_counter.PageIndex = e.NewPageIndex;
        _GvResultBind();

    }
    protected void Grid_counter_RowEditing(object sender, GridViewEditEventArgs e)
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
    protected void Grid_counter_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindCodeCounterGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_counter.DataSource = sortedView;
        Grid_counter.DataBind();
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
        DataSet _Ds = BindCodeCounterGrid();

        if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
            int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        else
            int_TotalRecords = 0;

        Grid_counter.DataSource = _Ds.Tables[0];
        Grid_counter.PageSize = Int_Page_Size;
        Grid_counter.DataBind();

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