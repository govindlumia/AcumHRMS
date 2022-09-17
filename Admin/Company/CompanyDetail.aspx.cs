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
using DataAccessLayer;

public partial class Admin_Company_CompanyDetail : System.Web.UI.Page
{

    public static DataSet ds = new DataSet();
    public static DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
     int CompanyID;
     public static int Int_PageIndex = 1;
     public static int Int_Page_Size = 25;
     public static int int_Total = 0;
     public static int int_TotalRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txt_est_date.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "1")

                        Response.Redirect("~/Authenticate.aspx");
                          //Response.Redirect("/Admin/Home.aspx");
                }
                else
                    Response.Redirect("~/notlogged.aspx");
                FillControl();
                createCompany.Visible = false;
                view_Company.Visible = false;
                FillGrid.Visible = true;
                edit.Visible = false;
                create.Visible = false;
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
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(ddlPageSize, commonBusiness.BindDropDowns("", "Paging"), "PageSize", "PageSize");
        BindDropDowns1(drp_comp_name, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
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

    //----------------Bind Grid-----------------------------------------
    private  DataSet  BindCompanyGrid()
    {
        try
        {
            CompanyBussiness objSelectALL = new CompanyBussiness();
            CompanyENT userEntity = new CompanyENT();

            userEntity.Companyid = Convert.ToInt32(drp_comp_name.SelectedValue);
            userEntity.EmployeeCode="";
            userEntity.Companyname = txt_employee.Text.Trim().ToString();
            userEntity.Resp_person="";
            userEntity.Corp_add1="";
            userEntity.Pageindex = Int_PageIndex;
            userEntity.PageSize = Int_Page_Size;
            userEntity.SortBy = "companyname";

            ds = objSelectALL.FetchCompanyCustom(userEntity);
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

    //--------------------------Create Company-----------------------------

  
    
    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        reset();
        createCompany.Visible = true;
        view_Company.Visible = false;
        edit.Visible = false;
        create.Visible = true;
        FillGrid.Visible = false;
        // divPaging.Visible = false;
        lnkView.Visible = true;
        lnkCreate.Visible = false;
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        createCompany.Visible = false;
        view_Company.Visible = false;
        edit.Visible = false;
        create.Visible = true;

        FillGrid.Visible = true;
        //divPaging.Visible = true;
        lnkView.Visible = false;
        lnkCreate.Visible = true;
    }
    protected void reset()
    {

        txtcmpname.Text = "";
        drp_type.SelectedValue = "0";
        txt_est_date.Text = "";
        txtregno.Text = "";
        txt_pan.Text = "";
        txttin.Text = "";
        txtcmpurl.Text = "";
        txt_pre_add1.Text = "";
        txt_pre_Add2.Text = "";
        txt_pre_city.Text = "";
        txt_pre_state.Text = "";
        txt_pre_country.Text = "";
        txt_pre_zip.Text = "";
        txt_pre_phone.Text = "";
        txt_per_add1.Text = "";
        txt_per_add2.Text = "";
        txt_per_city.Text = "";
        txt_per_state.Text = "";
        txt_per_country.Text = "";
        txt_per_zip.Text = "";
        txt_per_phone.Text = "";
        check1.Checked = false;
        txt_tanno.Text = "";
        txt_tds.Text = "";
        drp_pftrust.SelectedValue = "0";
        txtcmpycode.Text = "";
        txt_comp_eng.Text = "";
        txt_resppers.Text = "";
        txt_epfno.Text = "";
        txt_dbffile.Text = "";
        txt_fileext.Text = "";
        txt_esino.Text = "";
        txt_esilocalno.Text = "";
    }
    protected void insert_company_detail()
    {
       // string file_name;

        if (Page.IsValid)
        {
           // string file_name1;
          //  if (f_upload_rep1.GotFile)
            
               // file_name = txtcmpname.Text + System.DateTime.Now.GetHashCode().ToString();
                //f_upload_rep1.FilePost.SaveAs(Server.MapPath("../../Upload/Logo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
               // file_name1 = file_name + "." + f_upload_rep1.FileExt.ToLower();

                //System.DateTime EsttDate = DateTime.ParseExact(txt_est_date.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                //string strEsttDate = EsttDate.ToString();

            if (FileUpload2.HasFile)
            {
                UploadPhoto();
            }

                CompanyENT userEntity = new CompanyENT();

                userEntity.Companyid = 0;
                userEntity.Companyname = txtcmpname.Text;
                userEntity.CompanyCode = txtcmpycode.Text;
                userEntity.Comp_type = Convert.ToString(drp_type.SelectedValue);
              //  userEntity.Estt_date = Convert.ToDateTime(strEsttDate);
                userEntity.Estt_date = Utilities.Utility.DateTimeForat(txt_est_date.Text.ToString());
                userEntity.Pan_no = txt_pan.Text;
                userEntity.Tin_no = txttin.Text;
                userEntity.Reg_no = txtregno.Text;
                userEntity.Tan_no = txt_tanno.Text.Trim().ToString();
                userEntity.Tds_circle = txt_tds.Text.Trim().ToString();
                userEntity.Pf_trust = Convert.ToString(drp_pftrust.SelectedValue);
                userEntity.Url = txtcmpurl.Text;
                //userEntity.Logo = file_name1;
                userEntity.Logo = Label2.Text;
                userEntity.Corp_add1 = txt_pre_add1.Text;
                userEntity.Corp_add2 = txt_pre_Add2.Text;
                userEntity.Corp_city = txt_pre_city.Text;
                userEntity.Corp_state = txt_pre_state.Text;
                userEntity.Corp_country = txt_pre_country.Text;
                userEntity.Corp_zip = txt_pre_zip.Text;
                userEntity.Corp_phone = txt_pre_phone.Text;
                userEntity.Cors_add1 = txt_per_add1.Text;
                userEntity.Cors_add2 = txt_per_add2.Text;
                userEntity.Cors_city = txt_per_city.Text;
                userEntity.Cors_state = txt_per_state.Text;
                userEntity.Cors_country = txt_per_country.Text;
                userEntity.Cors_zip = txt_per_zip.Text;
                userEntity.Cors_phone = txt_per_phone.Text;
                userEntity.Comp_engaged = txt_comp_eng.Text.Trim().ToString();
                userEntity.Epf_no = txt_epfno.Text.Trim().ToString();
                userEntity.Epf_dbf_filecode = txt_dbffile.Text.Trim().ToString();
                userEntity.Epf_dbf_ext = txt_fileext.Text.Trim().ToString();
                userEntity.Esi_no = txt_esino.Text.Trim().ToString();
                userEntity.Esi_local_no = txt_esilocalno.Text.Trim().ToString();
                userEntity.Resp_person = txt_resppers.Text.Trim().ToString();
                userEntity.CreatedBy = Session["EmpCode"].ToString();

                CompanyBussiness objSelectALL = new CompanyBussiness();
                int result = objSelectALL.CreateCompany(userEntity);

                if (result == 1)
                {

                    message.InnerHtml = "Company created successfully";
                    reset();
                    createCompany.Visible = false;
                    view_Company.Visible = false;
                    FillGrid.Visible = true;
                    edit.Visible = false;
                    create.Visible = false;                   
                }        
        }
    }
    private void UploadPhoto()
    {
        Random nxt = new Random();
        string fileName = txtcmpycode.Text + "_" + nxt.Next().ToString() + FileUpload2.PostedFile.FileName.Replace(" ", "_").ToString();

        if ((System.IO.Path.GetExtension(fileName) == ".jpg") || (System.IO.Path.GetExtension(fileName) == ".jpeg")
             || (System.IO.Path.GetExtension(fileName) == ".gip") || (System.IO.Path.GetExtension(fileName) == ".png"))
        {
            if (System.IO.File.Exists(Server.MapPath("~") + "\\upload\\Logo\\" + fileName))
                System.IO.File.Delete(Server.MapPath("~") + "\\upload\\Logo\\" + fileName);

            string files = Server.MapPath("~") + "\\upload\\Logo\\";
            string FilePath = files + fileName;

            Label2.Text = fileName;
            FileUpload2.SaveAs(FilePath);
        }
    }
    protected void check1_CheckedChanged(object sender, EventArgs e)
    {
        if (check1.Checked == true)
        {
            txt_per_add1.Text = txt_pre_add1.Text;
            txt_per_add2.Text = txt_pre_Add2.Text;
            txt_per_city.Text = txt_pre_city.Text;
            txt_per_state.Text = txt_pre_state.Text;
            txt_per_country.Text = txt_pre_country.Text;
            txt_per_zip.Text = txt_pre_zip.Text;
            txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            txt_per_city.Enabled = false;
            txt_per_state.Enabled = false;
            txt_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            txt_per_city.Enabled = true;
            txt_per_state.Enabled = true;
            txt_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            txt_per_city.Text = "";
            txt_per_state.Text = "";
            txt_per_country.Text = "";
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }
    protected void btnCreate_Click1(object sender, EventArgs e)
    {
        insert_company_detail();
        _GvResultBind();
    }
    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        createCompany.Visible = false;
        view_Company.Visible = false;
        FillGrid.Visible = true;
        edit.Visible = false;
        create.Visible = false;
        reset();
    }
    protected void BindCompanyDetailEdit(int CompanyID)
    {
        txtcmpycode.Visible = true;
        txtcmpycode.ReadOnly = true;
           CompanyBussiness objSelectALL = new CompanyBussiness();
        CompanyENT userEntity = new CompanyENT();

        userEntity.Companyid = CompanyID;
        userEntity.EmployeeCode = "";
        userEntity.Companyname = "";
        userEntity.Resp_person = "";
        userEntity.Corp_add1 = "";
        userEntity.Pageindex = 0;
        userEntity.PageSize = 0;
        userEntity.SortBy = "companyname";

        ds = objSelectALL.FetchCompanyCustom(userEntity);
        dt = ds.Tables[0];

        txtcmpname.Text = dt.Rows[0]["companyname"].ToString();
        drp_type.SelectedValue = dt.Rows[0]["comp_type"].ToString();
        //drp_type.SelectedItem.Text = dt.Rows[0]["comp_type"].ToString();

        txtcmpycode.Text = dt.Rows[0]["CompanyCode"].ToString();
        LBLCompanyCode.Text = dt.Rows[0]["CompanyCode"].ToString();
        txt_est_date.Text = Convert.ToDateTime(dt.Rows[0]["estt_date"].ToString()).ToString("dd-MMM-yyyy");
        txtregno.Text = dt.Rows[0]["reg_no"].ToString();
        txt_pan.Text = dt.Rows[0]["pan_no"].ToString();
        txttin.Text = dt.Rows[0]["tin_no"].ToString();
        txtcmpurl.Text = dt.Rows[0]["url"].ToString();
        txt_pre_add1.Text = dt.Rows[0]["corp_add1"].ToString();
        txt_pre_Add2.Text = dt.Rows[0]["corp_add2"].ToString();
        txt_pre_city.Text = dt.Rows[0]["corp_city"].ToString();
        txt_pre_state.Text = dt.Rows[0]["corp_state"].ToString();
        txt_pre_country.Text = dt.Rows[0]["corp_country"].ToString();
        txt_pre_zip.Text = dt.Rows[0]["corp_zip"].ToString();
        txt_pre_phone.Text = dt.Rows[0]["corp_phone"].ToString();
        txt_per_add1.Text = dt.Rows[0]["cors_add1"].ToString();
        txt_per_add2.Text = dt.Rows[0]["cors_add2"].ToString();
        txt_per_city.Text = dt.Rows[0]["cors_city"].ToString();
        txt_per_state.Text = dt.Rows[0]["cors_state"].ToString();
        txt_per_country.Text = dt.Rows[0]["cors_country"].ToString();
        txt_per_zip.Text = dt.Rows[0]["cors_zip"].ToString();
        txt_per_phone.Text = dt.Rows[0]["cors_phone"].ToString();
        check1.Checked = true;
        txt_tanno.Text = dt.Rows[0]["tan_no"].ToString();
        txt_tds.Text = dt.Rows[0]["tds_circle"].ToString();
        drp_pftrust.SelectedValue = dt.Rows[0]["pf_trust"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["logo"].ToString()))

            Imgedit.Src = "../../upload/Logo/" + dt.Rows[0]["logo"].ToString();
        else
            Imgedit.Src = "../../upload/Logo/Rossel-Techsys-Logo1(1).png";
       
        txt_comp_eng.Text = dt.Rows[0]["comp_engaged"].ToString();
        txt_resppers.Text = dt.Rows[0]["resp_person"].ToString();
        txt_epfno.Text = dt.Rows[0]["epf_no"].ToString();
        txt_dbffile.Text = dt.Rows[0]["epf_dbf_filecode"].ToString();
        txt_fileext.Text = dt.Rows[0]["epf_dbf_ext"].ToString();
        txt_esino.Text = dt.Rows[0]["esi_no"].ToString();
        txt_esilocalno.Text = dt.Rows[0]["esi_local_no"].ToString();


    }
    //--------------------Update Company--------------------------
    protected void update_company_detail()
    {
       // string file_name;

        if (Page.IsValid)
        {
           
            
                //file_name = txtcmpname.Text + System.DateTime.Now.GetHashCode().ToString();
                //f_upload_rep1.FilePost.SaveAs(Server.MapPath("../../Upload/Logo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                //file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

                //System.DateTime EsttDate = DateTime.ParseExact(txt_est_date.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                //string strEsttDate = EsttDate.ToString();

            if (FileUpload2.HasFile)
            {
                UploadPhoto();
            }

                CompanyENT userEntity = new CompanyENT();
                userEntity.Companyid = Convert.ToInt32(ViewState["CompanyId"].ToString());
                userEntity.Companyname = txtcmpname.Text;
                userEntity.CompanyCode = LBLCompanyCode.Text;
                userEntity.Comp_type = Convert.ToString(drp_type.SelectedValue);
                userEntity.Estt_date = Utilities.Utility.DateTimeForat(txt_est_date.Text.ToString());
                userEntity.Pan_no = txt_pan.Text;
                userEntity.Tin_no = txttin.Text;
                userEntity.Reg_no = txtregno.Text;
                userEntity.Tan_no = txt_tanno.Text.Trim().ToString();
                userEntity.Tds_circle = txt_tds.Text.Trim().ToString();
                userEntity.Pf_trust = Convert.ToString(drp_pftrust.SelectedValue);
                userEntity.Url = txtcmpurl.Text;
                userEntity.Logo = Label2.Text; ;
                userEntity.Corp_add1 = txt_pre_add1.Text;
                userEntity.Corp_add2 = txt_pre_Add2.Text;
                userEntity.Corp_city = txt_pre_city.Text;
                userEntity.Corp_state = txt_pre_state.Text;
                userEntity.Corp_country = txt_pre_country.Text;
                userEntity.Corp_zip = txt_pre_zip.Text;
                userEntity.Corp_phone = txt_pre_phone.Text;
                userEntity.Cors_add1 = txt_per_add1.Text;
                userEntity.Cors_add2 = txt_per_add2.Text;
                userEntity.Cors_city = txt_per_city.Text;
                userEntity.Cors_state = txt_per_state.Text;
                userEntity.Cors_country = txt_per_country.Text;
                userEntity.Cors_zip = txt_per_zip.Text;
                userEntity.Cors_phone = txt_per_phone.Text;
                userEntity.Comp_engaged = txt_comp_eng.Text.Trim().ToString();
                userEntity.Epf_no = txt_epfno.Text.Trim().ToString();
                userEntity.Epf_dbf_filecode = txt_dbffile.Text.Trim().ToString();
                userEntity.Epf_dbf_ext = txt_fileext.Text.Trim().ToString();
                userEntity.Esi_no = txt_esino.Text.Trim().ToString();
                userEntity.Esi_local_no = txt_esilocalno.Text.Trim().ToString();
                userEntity.Resp_person = txt_resppers.Text.Trim().ToString();
                userEntity.ModifiedBy = Session["EmpCode"].ToString();

                CompanyBussiness objSelectALL = new CompanyBussiness();
                int result = objSelectALL.UpdateCompany(userEntity);
                if (result  ==  1)
                {
                    message.InnerHtml = "Company Updated successfully";

                    createCompany.Visible = false;
                    view_Company.Visible = false;
                    FillGrid.Visible = true;
                    edit.Visible = false;
                    create.Visible = false;
                    reset();

                }

            
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        update_company_detail();
        _GvResultBind();

    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        
        BindCompanyDetailEdit(CompanyID);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        createCompany.Visible = false;
        view_Company.Visible = false;
        FillGrid.Visible = true;
        edit.Visible = false;
        create.Visible = false;
        reset();
    }
    //---------------For View Detail------------------------------
    protected void BindCompanyDetailView(int CompanyID1)
    {
        CompanyBussiness objSelectALL = new CompanyBussiness();
        CompanyENT userEntity = new CompanyENT();

        userEntity.Companyid = CompanyID1;
        userEntity.EmployeeCode = "";
        userEntity.Companyname = "";
        userEntity.Resp_person = "";
        userEntity.Corp_add1 = "";
        userEntity.Pageindex = 0;
        userEntity.PageSize = 0;
        userEntity.SortBy = "companyname";

        ds = objSelectALL.FetchCompanyCustom(userEntity);
        dt = ds.Tables[0];
        int comtype;
        int pftrust;
        LblCmpyName.Text = dt.Rows[0]["companyname"].ToString();
        comtype= Convert.ToInt32(dt.Rows[0]["comp_type"].ToString());

        if(comtype == 1)
        {
            LblCmpyType.Text = "Manufacturing";//"Pvt";
        }
        else if (comtype == 2)
        {
            LblCmpyType.Text = "IT";//"Pvt. Ltd.";
        }
        else
        {
            LblCmpyType.Text = "Others";//"Ltd.";
        }

        LblcmpyCode.Text = dt.Rows[0]["CompanyCode"].ToString();
        LblRegNo.Text = dt.Rows[0]["reg_no"].ToString();
        LblPanNo.Text = dt.Rows[0]["pan_no"].ToString();
        LblTinNo.Text = dt.Rows[0]["tin_no"].ToString();
        LblCmpyUrl.Text = dt.Rows[0]["url"].ToString();
        LblCorAdd1.Text = dt.Rows[0]["corp_add1"].ToString();
        LblCorAdd2.Text = dt.Rows[0]["corp_add2"].ToString();
        LblCorCity.Text = dt.Rows[0]["corp_city"].ToString();
        LblCorState.Text = dt.Rows[0]["corp_state"].ToString();
        LblCorCountry.Text = dt.Rows[0]["corp_country"].ToString();
        LblCorCode.Text = dt.Rows[0]["corp_zip"].ToString();
        LblCorPhone.Text = dt.Rows[0]["corp_phone"].ToString();
        LblCorrAdd1.Text = dt.Rows[0]["cors_add1"].ToString();
        LblCorrAdd2.Text = dt.Rows[0]["cors_add2"].ToString();
        LblCorrCity.Text = dt.Rows[0]["cors_city"].ToString();
        LblCorrState.Text = dt.Rows[0]["cors_state"].ToString();
        LblCorrCountry.Text = dt.Rows[0]["cors_country"].ToString();
        LblCorrCode.Text = dt.Rows[0]["cors_zip"].ToString();
        LblCorrPhone.Text = dt.Rows[0]["cors_phone"].ToString();
       // check1.Checked = false;
        LblTanNo.Text = dt.Rows[0]["tan_no"].ToString();
        LblTdsCircle.Text = dt.Rows[0]["tds_circle"].ToString();

        pftrust = Convert.ToInt32(dt.Rows[0]["pf_trust"].ToString());
        if (pftrust == 1)
        {
            LblPfTrust.Text = "Yes";
        }
        else
        {
            LblPfTrust.Text = "N0";
        }

        if (!string.IsNullOrEmpty(dt.Rows[0]["logo"].ToString()))

            imageProf.Src = "../../upload/Logo/" + dt.Rows[0]["logo"].ToString();
        else
            imageProf.Src = "../../upload/Logo/Rossel-Techsys-Logo1(1).png";
       // ViewState.Add("Logo", dt.Rows[0]["logo"].ToString());
        LblCmpyEng.Text = dt.Rows[0]["comp_engaged"].ToString();
        LblResPer.Text = dt.Rows[0]["resp_person"].ToString();
        LblCmpyPF.Text = dt.Rows[0]["epf_no"].ToString();
        LblDBFFile.Text = dt.Rows[0]["epf_dbf_filecode"].ToString();
        txt_fileext.Text = dt.Rows[0]["epf_dbf_ext"].ToString();
        LblCmpyEsi.Text = dt.Rows[0]["esi_no"].ToString();
        LblEsi.Text = dt.Rows[0]["esi_local_no"].ToString();

    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        createCompany.Visible = false;
        view_Company.Visible = false;
        FillGrid.Visible = true;
        edit.Visible = false;
        create.Visible = false;
        reset();
    }
    protected void Grid_Emp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
             CompanyID = Convert.ToInt32(e.CommandArgument);
             ViewState["CompanyId"] = CompanyID.ToString();

            createCompany.Visible = true;
            FillGrid.Visible = false;
            create.Visible = false;
            edit.Visible = true;
            view_Company.Visible = false;
            BindCompanyDetailEdit(CompanyID);
        }
        if (e.CommandName == "View")
        {
            int  CompanyID1 = Convert.ToInt32(e.CommandArgument);
            createCompany.Visible = false;
            FillGrid.Visible = false;
            create.Visible = false;
            edit.Visible = false;
            view_Company.Visible = true;
            BindCompanyDetailView(CompanyID1);
        }

    }
    protected void Grid_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Emp.PageIndex = e.NewPageIndex;
        _GvResultBind();
    }
    protected void Grid_Emp_RowEditing(object sender, GridViewEditEventArgs e)
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
    protected void Grid_Emp_Sorting(object sender, GridViewSortEventArgs e)
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
        Grid_Emp.DataSource = sortedView;
        Grid_Emp.DataBind();
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
        DataSet _Ds = BindCompanyGrid();

        if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
            int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        else
            int_TotalRecords = 0;

        Grid_Emp.DataSource = _Ds.Tables[0];
        Grid_Emp.PageSize = Int_Page_Size;
        Grid_Emp.DataBind();

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


    protected void Grid_Emp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          //  Label lblSourceDate = (Label)e.Row.FindControl("lblEstDate");

            //lblSourceDate.Text = Convert.ToDateTime(lblSourceDate.Text).ToString(General.DateFormat());
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        Int_PageIndex = 1;
        //Int_Page_Size = 25;
        _GvResultBind();
    }
}