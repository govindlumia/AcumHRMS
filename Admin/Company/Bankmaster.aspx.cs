﻿using System;
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

public partial class Admin_Company_Bankmaster : System.Web.UI.Page
{

    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    int BankID;
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
                    if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                        Response.Redirect("~/Authenticate.aspx");
                }
                else
                    Response.Redirect("~/notlogged.aspx");
                FillControl();
                createdesg.Visible = false;
                viewdesg.Visible = false;
                GridDesg.Visible = true;
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

    protected void FillControl()
    {
        commonBusiness = new CommonBusiness();
        BindDropDowns(drp_comp_name, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns1(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDowns(ddl_grade, commonBusiness.BindDropDowns("", "BankMaster"), "id", "bankname");
        BindDropDowns(ddl_company, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
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
    private DataSet BindGradeGrid()
    {
        try
        {

            BankENT ObjBankENT = new BankENT();

            ObjBankENT.Id = Convert.ToInt32(ddl_grade.SelectedValue);
            ObjBankENT.EmployeeCode = "";
            ObjBankENT.Bankname = txt_employee.Text.Trim().ToString();
            ObjBankENT.Bankcode = "";
            ObjBankENT.Bankifsccode = "";
            ObjBankENT.Bankaddress = "";
            ObjBankENT.Pageindex = Int_PageIndex;
            ObjBankENT.PageSize = Int_Page_Size;
            ObjBankENT.SortBy = "bankname";
            BankBussiness ObjGradeBussiness = new BankBussiness();
            ds = ObjGradeBussiness.FetchBank(ObjBankENT);


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

    //------------------------Create Designation--------------------

    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createdesg.Visible = true;
        viewdesg.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridDesg.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createdesg.Visible = false;
        viewdesg.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;

        GridDesg.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }


    protected void btncreate_Click(object sender, EventArgs e)
    {
         CreateGrade();
        _GvResultBind();
    }

    protected void CreateGrade()
    {
        try
        {
            BankENT ObjBankENT = new BankENT();

            ObjBankENT.Id = 0;
            ObjBankENT.CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue);
            ObjBankENT.Bankcode = Txt_code.Text;
            ObjBankENT.Bankname = txt_grade_name.Text;
            ObjBankENT.Bankaddress = txt_grade_address.Text;
            ObjBankENT.Bankifsccode = txt_grade_ifsc_code.Text;
            ObjBankENT.Createdby = Session["empcode"].ToString();
            ObjBankENT.EmployeeCode = "";

            BankBussiness ObjGradeBussiness = new BankBussiness();
            string result = ObjGradeBussiness.CreateBank(ObjBankENT);

            if (result == "1")
            {
                General.Alert("Record Save Successfully", btncreate);
                reset();
                createdesg.Visible = false;
                viewdesg.Visible = false;
                GridDesg.Visible = true;
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
        Txt_code.Text = "";
        txt_grade_name.Text = "";
    }

    protected void btnsavenew_Click(object sender, EventArgs e)
    {
        saveandaddnew();
    }
    protected void saveandaddnew()
    {
        try
        {
            BankENT ObjBankENT = new BankENT();
            ObjBankENT.Id = 0;
            ObjBankENT.CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue);
            ObjBankENT.Bankcode = Txt_code.Text;
            ObjBankENT.Bankname = txt_grade_name.Text;
            ObjBankENT.Bankaddress = txt_grade_address.Text;
            ObjBankENT.Createdby = Session["empcode"].ToString();
            ObjBankENT.EmployeeCode = "";
            BankBussiness ObjGradeBussiness = new BankBussiness();
            string result = ObjGradeBussiness.CreateBank(ObjBankENT);

            if (result == "1")
            {
                General.Alert("Record Save Successfully", btncreate);
                reset1();
                createdesg.Visible = true;
                viewdesg.Visible = false;
                GridDesg.Visible = false;
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
    protected void reset1()
    {
        Txt_code.Text = "";
        txt_grade_name.Text = "";
    }

    //---------------------------- Update Designation--------------------


    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditGrade();
        _GvResultBind();
    }

    protected void EditGrade()
    {
        try
        {
            BankENT ObjBankENT = new BankENT();

            ObjBankENT.CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue);
            ObjBankENT.Bankcode = Txt_code.Text;
            ObjBankENT.Bankname = txt_grade_name.Text;
            ObjBankENT.Bankaddress = txt_grade_address.Text;
            ObjBankENT.Bankifsccode = txt_grade_ifsc_code.Text;
            ObjBankENT.Createdby = Session["empcode"].ToString();
            ObjBankENT.EmployeeCode = "";
            ObjBankENT.Id = Convert.ToInt32(ViewState["BankID"].ToString());
            BankBussiness ObjGradeBussiness = new BankBussiness();
            string result = ObjGradeBussiness.UpdateGrade(ObjBankENT);




            if (result == "1")
            {
                General.Alert("Record Update Successfully", btnSave);
                reset();
                createdesg.Visible = false;
                viewdesg.Visible = false;
                GridDesg.Visible = true;
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

    protected void GradeEditDetail(int BankID)
    {
        BankENT ObjBankENT = new BankENT();

        ObjBankENT.Id = BankID;
        ObjBankENT.EmployeeCode = "";
        ObjBankENT.CompanyId = 0;
        ObjBankENT.Bankname = "";
        ObjBankENT.Bankcode = "";
        ObjBankENT.Bankaddress = "";
        ObjBankENT.Pageindex = 0;
        ObjBankENT.PageSize = 0;
        ObjBankENT.SortBy = "bankname";
        BankBussiness ObjGradeBussiness = new BankBussiness();
        ds = ObjGradeBussiness.FetchBank(ObjBankENT);

        dt = ds.Tables[0];
        drp_comp_name.SelectedValue = dt.Rows[0]["CompanyId"].ToString();
        //Txt_code.Text = dt.Rows[0]["Bankcode"].ToString();
        Txt_code.Text = dt.Rows[0]["branchcode"].ToString();
        txt_grade_name.Text = dt.Rows[0]["bankname"].ToString();
        txt_grade_address.Text = dt.Rows[0]["address"].ToString();
        txt_grade_ifsc_code.Text = dt.Rows[0]["bankifsccode"].ToString();

        drp_comp_name.Enabled = false;

    }

    //-------------------cancel button-------------------------------------
    protected void Btncancel1_Click(object sender, EventArgs e)
    {
        createdesg.Visible = false;
        viewdesg.Visible = false;
        GridDesg.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }
    //--------------------------View Designation---------------------------------
    protected void GradeViewDetail(int BankID1)
    {
        BankENT ObjBankENT = new BankENT();
        ObjBankENT.Id = BankID1;
        ObjBankENT.EmployeeCode = "";
        ObjBankENT.CompanyId = 0;
        ObjBankENT.Bankname = "";
        ObjBankENT.Bankcode = "";
        ObjBankENT.Bankaddress = "";
        ObjBankENT.Bankifsccode = "";
        ObjBankENT.Pageindex = 0;
        ObjBankENT.PageSize = 0;
        ObjBankENT.SortBy = "bankname";
        BankBussiness ObjGradeBussiness = new BankBussiness();
        ds = ObjGradeBussiness.FetchBank(ObjBankENT);

        dt = ds.Tables[0];
        LblCmpyName.Text = dt.Rows[0]["companyname"].ToString();
        LblGradeName.Text = dt.Rows[0]["branchcode"].ToString();
        LblDesc.Text = dt.Rows[0]["bankname"].ToString();
        Label5.Text = dt.Rows[0]["address"].ToString();
        Label6.Text = dt.Rows[0]["bankifsccode"].ToString();

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createdesg.Visible = false;
        viewdesg.Visible = false;
        GridDesg.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
        reset();
    }

    //-------------------- Bind Designation By ID---------------------

    protected void Grid_Desg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            BankID = Convert.ToInt32(e.CommandArgument);
            ViewState["BankID"] = BankID.ToString();
            createdesg.Visible = true;
            viewdesg.Visible = false;
            GridDesg.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            FillControl();
            GradeEditDetail(BankID);



        }
        if (e.CommandName == "View")
        {
            int BankID1 = Convert.ToInt32(e.CommandArgument);
            createdesg.Visible = false;
            viewdesg.Visible = true;
            GridDesg.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            GradeViewDetail(BankID1);

        }
    }
    protected void Grid_Desg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Desg.PageIndex = e.NewPageIndex;
        _GvResultBind();

    }
    protected void Grid_Desg_RowEditing(object sender, GridViewEditEventArgs e)
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
    protected void Grid_Desg_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindGradeGrid().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        Grid_Desg.DataSource = sortedView;
        Grid_Desg.DataBind();
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
        DataSet _Ds = BindGradeGrid();
        if (_Ds.Tables.Count > 1)
        {
            if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
                int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
            else
                int_TotalRecords = 0;
        }
        else
        { 
        
        }
        Grid_Desg.DataSource = _Ds.Tables[0];
        Grid_Desg.PageSize = Int_Page_Size;
        Grid_Desg.DataBind();

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