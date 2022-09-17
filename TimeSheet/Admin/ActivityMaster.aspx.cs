using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class TimeSheet_Admin_ActivityMaster : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    CommonBusiness commonBusiness = null;
    int ActivityID;
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
                createActivity.Visible = false;
                viewactivity.Visible = false;
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

    //---------------------Bind Dropdown------------------

    protected void FillControl()
    {
        commonBusiness = new CommonBusiness();
        BindDropDownBussiness binddrop = new BindDropDownBussiness();
        BindDropDowns1(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDowns(ddl_activity, binddrop.BindDropDowns("", "Activity"), "Id", "ActivityName");
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
        if (ddl.ID.Equals("ddlPageSize"))
        {
            ddl.SelectedIndex = 1;
        }
    }
  


    //----------------------Bind Grid-------------------
    private DataSet BindActivityGrid()
    {
        try
        {
            ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
            ActivityMasterENT activityselectENT = new ActivityMasterENT();


            activityselectENT.Id = Convert.ToInt32(ddl_activity.SelectedValue);
            activityselectENT.EmployeeCode = "";
            activityselectENT.ActivityName = txt_employee.Text.Trim().ToString();
            activityselectENT.ActivityCode = "";
            activityselectENT.Pageindex = Int_PageIndex;
            activityselectENT.PageSize = Int_Page_Size;
            activityselectENT.SortBy = "ActivityName";

            ds = activityselectAll.FetchActivityMaster(activityselectENT);

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

    //------------------------Create Activity--------------------



    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createActivity.Visible = true;
        viewactivity.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridDept.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
        txt_Activity_code.ReadOnly = false;
    }

    private void clearAll()
    {
        txt_Activity_code.Text = "";
        txt_activity_name.Text = "";
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createActivity.Visible = false;
        viewactivity.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;

        GridDept.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }


    protected void btncreate_Click(object sender, EventArgs e)
    {
        if (CreateActivity())
        {
            _GvResultBind();
            reset();
            createActivity.Visible = false;
            viewactivity.Visible = false;
            GridDept.Visible = true;
            divcreate.Visible = false;
            divSave.Visible = false;
            lnkCreate.Visible = true;
            lnkView.Visible = false;
            clearAll();
        }
       }

    protected bool CreateActivity()
    {
        try
        {
            ActivityMasterENT activityselectENT = new ActivityMasterENT();
            activityselectENT.Id = 0;
            activityselectENT.ActivityName = txt_activity_name.Text;
            activityselectENT.ActivityCode = txt_Activity_code.Text;
            activityselectENT.Createdby = Session["empcode"].ToString();
            activityselectENT.EmployeeCode = "";

            ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
          string result = activityselectAll.CreateActivityMaster(activityselectENT);

          if (result.Equals("Inserted"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset();
                createActivity.Visible = false;
                viewactivity.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
                _GvResultBind();
                return true;
            }
          else if (result.Equals("Already Exist"))
          {
              General.Alert("Activity already exist",btncreate);
              txt_Activity_code.Focus();
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
        
        txt_activity_name.Text = "";
        txt_Activity_code.Text = "";

    }
    protected void btnsavenew_Click(object sender, EventArgs e)
    {
        saveandaddnew();
        clearAll();
    }

    protected void saveandaddnew()
    {
        try
        {
            ActivityMasterENT activityselectENT = new ActivityMasterENT();
            activityselectENT.Id = 0;
            activityselectENT.ActivityName = txt_activity_name.Text;
            activityselectENT.ActivityCode = txt_Activity_code.Text;
            activityselectENT.Createdby = Session["empcode"].ToString();
            activityselectENT.EmployeeCode = "";

            ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
            string result = activityselectAll.CreateActivityMaster(activityselectENT);

            if (result.Equals("Inserted"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset1();
                createActivity.Visible = true;
                viewactivity.Visible = false;
                GridDept.Visible = false;
                divcreate.Visible = true;
                divSave.Visible = false;

            }
            else if (result.Equals("Already Exist"))
            {
                General.Alert("Activity already exist", btncreate);
                txt_Activity_code.Focus();
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
        txt_activity_name.Text = "";
        txt_Activity_code.Text = "";
    }

    //------------------------Edit Activity-------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditActivity();
        _GvResultBind();
        clearAll();
    }
    protected void EditActivity()
    {
        try
        {
            ActivityMasterENT activityselectENT = new ActivityMasterENT();

           
            activityselectENT.ActivityName = txt_activity_name.Text;
            activityselectENT.ActivityCode = txt_Activity_code.Text;
            activityselectENT.Modifiedby = Session["empcode"].ToString();
            activityselectENT.EmployeeCode = "";
            activityselectENT.Id = Convert.ToInt32(ViewState["ActivityID"].ToString());

            ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
            int result = activityselectAll.UpdateActivityMaster(activityselectENT);

            if (result > 0)
            {
                General.Alert("Record updated successfully", btnSave);
                reset();
                createActivity.Visible = false;
                viewactivity.Visible = false;
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

    protected void ActivityEditDetail(int ActivityID)
    {
        ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
        ActivityMasterENT activityselectENT = new ActivityMasterENT();
        activityselectENT.Id = ActivityID;
        activityselectENT.EmployeeCode = "";
        activityselectENT.ActivityName = "";
        activityselectENT.ActivityCode = "";
        activityselectENT.Pageindex = 0;
        activityselectENT.PageSize = 0;
        activityselectENT.SortBy = "ActivityName";

        ds = activityselectAll.FetchActivityMaster(activityselectENT);
        dt = ds.Tables[0];
        txt_activity_name.Text = dt.Rows[0]["ActivityName"].ToString();
        txt_Activity_code.Text = dt.Rows[0]["ActivityCode"].ToString();
        txt_Activity_code.ReadOnly = true;
    }

    //-----------------------------View Activity----------------------


    protected void ActivityViewDetail(int ActivityID2)
    {
        ActivityMasterBussiness activityselectAll = new ActivityMasterBussiness();
        ActivityMasterENT activityselectENT = new ActivityMasterENT();
        activityselectENT.Id = ActivityID2;
        activityselectENT.EmployeeCode = "";
        activityselectENT.ActivityName = "";
        activityselectENT.ActivityCode = "";
        activityselectENT.Pageindex = 0;
        activityselectENT.PageSize = 0;
        activityselectENT.SortBy = "ActivityName";

        ds = activityselectAll.FetchActivityMaster(activityselectENT);
        dt = ds.Tables[0];
        LblDeptName.Text = dt.Rows[0]["ActivityName"].ToString();
        LblDeptCode.Text = dt.Rows[0]["ActivityCode"].ToString();

    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        createActivity.Visible = false;
        viewactivity.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        _GvResultBind();
    }

    //------------------------------Bind Activity By ID----------------

    protected void Grid_Dept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            ActivityID = Convert.ToInt32(e.CommandArgument);
            ViewState["ActivityID"] = ActivityID.ToString();
            createActivity.Visible = true;
            viewactivity.Visible = false;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            //BindCompany();
            FillControl();
            ActivityEditDetail(ActivityID);



        }
        if (e.CommandName == "View")
        {
            int ActivityID2 = Convert.ToInt32(e.CommandArgument);
            createActivity.Visible = false;
            viewactivity.Visible = true;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            ActivityViewDetail(ActivityID2);

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

        createActivity.Visible = false;
        viewactivity.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        BindActivityGrid();
        lnkCreate.Visible = true;
        lnkView.Visible = false;
        clearAll();
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

        DataView sortedView = new DataView(BindActivityGrid().Tables[0]);
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
        DataSet _Ds = BindActivityGrid();
        if (_Ds.Tables.Count > 1)
        {
            if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
                int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
            else
                int_TotalRecords = 0;

            Grid_Dept.DataSource = _Ds.Tables[0];
            Grid_Dept.PageSize = Int_Page_Size;
            Grid_Dept.DataBind();

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