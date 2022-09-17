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

public partial class TimeSheet_Admin_ProjectMaster : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    CommonBusiness commonBusiness = null;
    int ProjectID;
    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 25;
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txt_delaydate.Attributes.Add("readonly", "readonly");
            txt_duedate.Attributes.Add("readonly", "readonly");
            txt_proadmin.Attributes.Add("readonly", "readonly");
            txt_pro_code.Attributes.Remove("readonly");
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
                BindActivities();
                _GvResultBind();

            }
        }
        catch (Exception ex)
        {

        }
    }
    //---------------------Bind Company------------------

    private void BindActivities()
    {
        ProjectMasterBussiness balObj = new ProjectMasterBussiness();
        DataTable dt_result = balObj.getActivityList();
        if (dt_result.Rows.Count > 0)
        {
            grdActivity.DataSource = dt_result;
        }
        else
        {
            grdActivity.DataSource = null;
        }
        grdActivity.DataBind();
    }

    protected void FillControl()
    {
        commonBusiness = new CommonBusiness();
        BindDropDownBussiness binddrop = new BindDropDownBussiness();
        //  BindDropDowns(drp_Project_Status, binddrop.BindDropDowns("", "ProjectStatus"), "Id", "Status");
        BindDropDowns1(ddl_prostat_create, binddrop.BindDropDowns("", "ProjectStatus"), "Id", "Status");
        BindDropDowns1(ddl_customer, binddrop.BindDropDowns("", "CustomerMaster"), "id", "CustomerName");
        BindDropDowns1(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDowns(ddl_Projectstatus, binddrop.BindDropDowns("", "ProjectStatus"), "Id", "Status");
        // BindDropDowns(ddl_Project, binddrop.BindDropDowns("", "Project"), "Id", "ProjectName");

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
    private DataSet BindProjectGrid()
    {
        try
        {
            ProjectMasterBussiness ProjectselectAll = new ProjectMasterBussiness();
            ProjectMasterENT ProjectselectENT = new ProjectMasterENT();


            ProjectselectENT.Id = 0;
            ProjectselectENT.EmployeeCode = "";
            ProjectselectENT.ProjectStatus = Convert.ToInt32(ddl_Projectstatus.SelectedValue);
            ProjectselectENT.ProjectName = txt_employee.Text.Trim().ToString();
            ProjectselectENT.ProjectCode = "";
            ProjectselectENT.Pageindex = Int_PageIndex;
            ProjectselectENT.PageSize = Int_Page_Size;
            ProjectselectENT.SortBy = "ProjectName";

            ds = ProjectselectAll.FetchProjectMaster(ProjectselectENT);

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
    //------------------------Create Project--------------------
    private void clearAll()
    {
        if (ddl_customer.Items.Count > 0)
            ddl_customer.SelectedIndex = 0;
        if (ddl_Projectstatus.Items.Count > 0)
            ddl_Projectstatus.SelectedIndex = 0;
        txt_pro_code.Text = "";
        txt_pro_name.Text = "";
        txt_proadmin.Text = "";
        txt_desc.Text = "";
        BindActivities();
    }


    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        createdept.Visible = true;
        viewdept.Visible = false;
        divSave.Visible = false;
        divcreate.Visible = true;
        GridDept.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
        clearAll();
        // BindActivities();
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
        CreateProject();
        _GvResultBind();
        reset();
        createdept.Visible = false;
        viewdept.Visible = false;
        GridDept.Visible = true;
        divcreate.Visible = false;
        divSave.Visible = false;
        lnkCreate.Visible = true;
        lnkView.Visible = false;
    }

    protected void CreateProject()
    {

        try
        {
            ProjectMasterBussiness ProjectselectAll = new ProjectMasterBussiness();
            ProjectMasterENT ProjectselectENT = new ProjectMasterENT();

            ProjectselectENT.Id = 0;
            ProjectselectENT.CustName = ddl_customer.SelectedValue;
            ProjectselectENT.ProjectStatus = Convert.ToInt32(ddl_prostat_create.SelectedValue);
            ProjectselectENT.ProjectName = txt_pro_name.Text;
            ProjectselectENT.ProjectCode = txt_pro_code.Text;
            ProjectselectENT.proAdmin = txt_proadmin.Text.Trim();
            ProjectselectENT.desc = txt_desc.Text.Trim();
            if (!string.IsNullOrEmpty(txt_duedate.Text))
                ProjectselectENT.DueDate = Convert.ToDateTime(txt_duedate.Text);
            else
                ProjectselectENT.DueDate = new DateTime(1900,1,1) ;
            if (!string.IsNullOrEmpty(txt_delaydate.Text))
                ProjectselectENT.DelayDate = Convert.ToDateTime(txt_delaydate.Text);
            else
                ProjectselectENT.DelayDate = new DateTime(1900, 1, 1);
            ProjectselectENT.activities = new List<int>();
            foreach (GridViewRow dr in grdActivity.Rows)
            {
                if (dr.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk_select = (CheckBox)dr.FindControl("chkselect");
                    if (chk_select != null)
                    {
                        if (chk_select.Checked)
                        {
                            try
                            {
                                int ID = Convert.ToInt32(grdActivity.DataKeys[dr.RowIndex].Value);
                                ProjectselectENT.activities.Add(ID);
                            }
                            catch (FormatException ex)
                            {

                            }
                        }
                    }
                }

            }
            ProjectselectENT.Createdby = Session["empcode"].ToString();
            ProjectselectENT.EmployeeCode = "";


            string result = ProjectselectAll.CreateProjectMaster(ProjectselectENT);

            if (result.Equals("Already Exist"))
            {
                General.Alert("Project already exists", btncreate);
                txt_pro_code.Focus();
            }

            else if (result.Equals("Added"))
            {
                General.Alert("Record saved successfully", btncreate);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
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
    protected void reset()
    {
        ddl_customer.SelectedIndex = 0;
        ddl_prostat_create.SelectedIndex = 0;
        txt_pro_name.Text = "";
        txt_pro_code.Text = "";
        txt_proadmin.Text = "";
        txt_desc.Text = "";
        txt_duedate.Text = "";
        txt_delaydate.Text = "";


    }

    //------------------------Edit Project-------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EditDepartment();
        _GvResultBind();
    }
    protected void EditDepartment()
    {
        try
        {
            ProjectMasterBussiness ProjectselectAll = new ProjectMasterBussiness();
            ProjectMasterENT ProjectselectENT = new ProjectMasterENT();
        
            ProjectselectENT.ProjectStatus = Convert.ToInt32(ddl_prostat_create.SelectedValue);
            ProjectselectENT.ProjectName = txt_pro_name.Text;
            ProjectselectENT.ProjectCode = txt_pro_code.Text;
            ProjectselectENT.Modifiedby = Session["empcode"].ToString();
            ProjectselectENT.Createdby = Session["empcode"].ToString();
            if (!string.IsNullOrEmpty(txt_delaydate.Text))
                ProjectselectENT.DelayDate = Convert.ToDateTime(txt_delaydate.Text);
            else
                ProjectselectENT.DelayDate = new DateTime(1900,1,1);
            if (!string.IsNullOrEmpty(txt_duedate.Text))
                ProjectselectENT.DueDate = Convert.ToDateTime(txt_duedate.Text);
            else
                ProjectselectENT.DueDate = new DateTime(1900, 1, 1);
            ProjectselectENT.EmployeeCode = "";
            ProjectselectENT.Id = Convert.ToInt32(ViewState["ProjectID"].ToString());
            ProjectselectENT.desc = txt_desc.Text.Trim();
            ProjectselectENT.proAdmin = txt_proadmin.Text.Trim();
            ProjectselectENT.activities = new List<int>();
            foreach (GridViewRow dr in grdActivity.Rows)
            {
                if (dr.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk_select = (CheckBox)dr.FindControl("chkselect");
                    if (chk_select != null)
                    {
                        if (chk_select.Checked)
                        {
                            try
                            {
                                int ID = Convert.ToInt32(grdActivity.DataKeys[dr.RowIndex].Value);
                                ProjectselectENT.activities.Add(ID);
                            }
                            catch (FormatException ex)
                            {

                            }
                        }
                    }
                }

            }
            int result = ProjectselectAll.UpdateProjectMaster(ProjectselectENT);

            if (result > 0)
            {
                General.Alert("Record Update Successfully", btnSave);
                reset();
                createdept.Visible = false;
                viewdept.Visible = false;
                GridDept.Visible = true;
                divcreate.Visible = false;
                divSave.Visible = false;
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

    protected void ProjectEditDetail(int ProjectID)
    {
        ProjectMasterBussiness ProjectselectAll = new ProjectMasterBussiness();
        ProjectMasterENT ProjectselectENT = new ProjectMasterENT();
        ProjectselectENT.Id = ProjectID;
        ProjectselectENT.EmployeeCode = "";
        ProjectselectENT.ProjectStatus = 0;
        ProjectselectENT.ProjectName = "";
        ProjectselectENT.ProjectCode = "";
        ProjectselectENT.Pageindex = 0;
        ProjectselectENT.PageSize = 0;
        ProjectselectENT.SortBy = "ProjectName";

        ds = ProjectselectAll.FetchProjectMaster(ProjectselectENT);
        dt = ds.Tables[0];
        ddl_customer.SelectedValue = dt.Rows[0]["CustomerID"].ToString();
        ddl_prostat_create.SelectedValue = dt.Rows[0]["ProjectStatusId"].ToString();
        txt_pro_name.Text = dt.Rows[0]["ProjectName"].ToString();
        txt_pro_code.Text = dt.Rows[0]["ProjectCode"].ToString();
        txt_pro_code.Attributes.Add("readonly", "readonly");
        if(!string.IsNullOrEmpty(dt.Rows[0]["ProAdmin"].ToString()))
        txt_proadmin.Text = dt.Rows[0]["ProAdmin"].ToString();
        else
            txt_proadmin.Text="";
        txt_desc.Text = dt.Rows[0]["projectdescription"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["duedate"].ToString()) && !Convert.ToDateTime(dt.Rows[0]["duedate"]).Equals(new DateTime(1900, 1, 1)))
            txt_duedate.Text = Convert.ToDateTime(dt.Rows[0]["duedate"]).ToString("dd-MMM-yyyy");
        else
            txt_duedate.Text = "";
        if (!string.IsNullOrEmpty(dt.Rows[0]["delaydate"].ToString()) && !Convert.ToDateTime(dt.Rows[0]["delaydate"]).Equals(new DateTime(1900, 1, 1)))
            txt_delaydate.Text = Convert.ToDateTime(dt.Rows[0]["delaydate"]).ToString("dd-MMM-yyyy");
        else
            txt_delaydate.Text = "";
        List<String> listData = new List<string>();
        foreach (DataRow _dr in ds.Tables[1].Rows)
        {
            listData.Add(_dr["ActivityID"].ToString().Trim());
        }
        BindActivities();
        GridViewRow gr = grdActivity.HeaderRow;
        if (gr != null)
        {
            CheckBox chk_header = (CheckBox)gr.FindControl("chkBxHeader");
            chk_header.Enabled = false;
        }
        foreach (GridViewRow _gvr in grdActivity.Rows)
        {
            CheckBox _chkheader = (CheckBox)_gvr.FindControl("chkselect");
            int _ID = Convert.ToInt32(grdActivity.DataKeys[_gvr.RowIndex].Value);
            if (_chkheader != null)
            {
                if (listData.Contains(_ID.ToString()))
                {
                    _chkheader.Checked = true;
                    _chkheader.Enabled = false;
                    foreach (TableCell cell in _gvr.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Crimson;
                    }
                    // _gvr.BackColor= System.Drawing.Color.Brown;
                }
            }
        }
    }

    //-----------------------------View Project----------------------


    protected void ProjectViewDetail(int ProjectID2)
    {
        ProjectMasterBussiness ProjectselectAll = new ProjectMasterBussiness();
        ProjectMasterENT ProjectselectENT = new ProjectMasterENT();
        ProjectselectENT.Id = ProjectID2;
        ProjectselectENT.EmployeeCode = "";
        ProjectselectENT.ProjectStatus = 0;
        ProjectselectENT.ProjectName = "";
        ProjectselectENT.ProjectCode = "";
        ProjectselectENT.Pageindex = 0;
        ProjectselectENT.PageSize = 0;
        ProjectselectENT.SortBy = "ProjectName";

        ds = ProjectselectAll.FetchProjectMaster(ProjectselectENT);
        dt = ds.Tables[0];
        LblCmpyName.Text = dt.Rows[0]["CustomerID"].ToString();
        LblDeptName.Text = dt.Rows[0]["ProjectName"].ToString();
        LblDeptCode.Text = dt.Rows[0]["ProjectCode"].ToString();
        lbl_admin.Text = dt.Rows[0]["adminName"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["duedate"].ToString()) && !Convert.ToDateTime(dt.Rows[0]["duedate"]).Equals(new DateTime(1900, 1, 1)))
            lbl_duedate.Text = Convert.ToDateTime(dt.Rows[0]["duedate"]).ToString("dd-MMM-yyyy");
        else

            lbl_duedate.Text = "NA";
        if (!string.IsNullOrEmpty(dt.Rows[0]["delaydate"].ToString()) && !Convert.ToDateTime(dt.Rows[0]["delaydate"]).Equals(new DateTime(1900, 1, 1)))
            lbl_delaydate.Text = Convert.ToDateTime(dt.Rows[0]["delaydate"]).ToString("dd-MMM-yyyy");
        else
            lbl_delaydate.Text = "NA";
        lbl_status.Text = dt.Rows[0]["Status"].ToString();
        string activity = string.Empty;
        foreach (DataRow _dr in ds.Tables[1].Rows)
        {
            activity += _dr[1].ToString() + ",";
        }
        //  lbl_activities.Text = activity;
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
            ProjectID = Convert.ToInt32(e.CommandArgument);
            ViewState["ProjectID"] = ProjectID.ToString();
            createdept.Visible = true;
            viewdept.Visible = false;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = true;
            lnkCreate.Visible = false;
            lnkView.Visible = true;
            //BindCompany();
            FillControl();
            ProjectEditDetail(ProjectID);



        }
        if (e.CommandName == "View")
        {
            int ProjectID2 = Convert.ToInt32(e.CommandArgument);
            createdept.Visible = false;
            viewdept.Visible = true;
            GridDept.Visible = false;
            divcreate.Visible = false;
            divSave.Visible = false;
            ProjectViewDetail(ProjectID2);

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
        lnkCreate.Visible = true;
        lnkView.Visible = false;
        BindProjectGrid();
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

        DataView sortedView = new DataView(BindProjectGrid().Tables[0]);
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
        DataSet _Ds = BindProjectGrid();
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
    protected void grdActivity_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void Grid_Dept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_duedate_edit = (Label)e.Row.FindControl("lbl_duedate");
            try
            {
                if (!string.IsNullOrEmpty(lbl_duedate_edit.Text))
                {
                    if (Convert.ToDateTime(lbl_duedate_edit.Text).Equals(new DateTime(1900, 1, 1)))
                    {
                        lbl_duedate_edit.Text = "";
                    }
                    else
                    {
                        DateTime due_date = Convert.ToDateTime(lbl_duedate_edit.Text);
                        lbl_duedate_edit.Text = due_date.ToString("dd-MMM-yyyy");
                        if (due_date < DateTime.Now)
                            e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                        else
                            e.Row.Cells[4].BackColor = System.Drawing.Color.Green;
                    }
                       
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}