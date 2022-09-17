using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Appraisal;
using System.Net.Mail;
using System.Net;

public partial class Appraisal_Admin_InitiateAppraisal : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();

    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 25;
    public static string Str_SortBy = "JD.Empcode";
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");

                _PageInitialize();
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }

        message.InnerHtml = "";

        if (Request.QueryString["updated"] != null)
            message.InnerHtml = "Employee Profile updated successfully";
        if (Request.QueryString["password"] != null)
            message.InnerHtml = "No such employee exists";
        if (Request.QueryString["passwordreset"] != null)
            message.InnerHtml = "Password reseted sucessfully";
    }

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

    protected void gvDetails_Sorting(object sender, GridViewSortEventArgs e)
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

        DataView sortedView = new DataView(BindGridView().Tables[0]);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        GvResult.DataSource = sortedView;
        GvResult.DataBind();
    }

    private DataSet BindGridView()
    {
        EmpJobDetailENT ObjEmpJobDetailENT = new EmpJobDetailENT();
        ObjEmpJobDetailENT.Empcode = Session["EmpCode"].ToString();
        ObjEmpJobDetailENT.EmployeeName = txt_employee.Text.Trim().ToString();
        ObjEmpJobDetailENT.Degination_id = Convert.ToInt32(dd_designation.SelectedValue);
        ObjEmpJobDetailENT.Category_id = Convert.ToInt32(dd_category.SelectedValue);
        ObjEmpJobDetailENT.StatusView = "Current";
        ObjEmpJobDetailENT.CompanyName = ddl_company.SelectedValue;
        //ObjEmpJobDetailENT.Home_Bussiness_unit = Convert.ToInt32(dd_bu.SelectedValue);
        ObjEmpJobDetailENT.Pageindex = Int_PageIndex;
        ObjEmpJobDetailENT.PageSize = Int_Page_Size;
        ObjEmpJobDetailENT.SortBy = Str_SortBy;

        EmpJobDetailBusiness empDeatil = new EmpJobDetailBusiness();
        ds = empDeatil.SelectEmployee(ObjEmpJobDetailENT);
        return ds;
    }



    protected void _PageInitialize()
    {
        FillControl();
        _GvResultBind();
        BindInitiated("");
    }

    protected void FillControl()
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindDropDowns(ddl_company, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
        //BindDropDowns(dd_bu, binddrop.BindDropDowns(Session["Company"].ToString(), "BusinessUnit"), "ID", "BussinessUnitName");
        //BindDropDowns(dd_category, binddrop.BindDropDowns(Session["Company"].ToString(), "Category"), "ID", "CategoryName");
        //BindDropDowns(dd_designation, binddrop.BindDropDowns(Session["Company"].ToString(), "Designation"), "id", "designationname");
        //BindDropDowns(dd_bu, binddrop.BindDropDowns(ddl_company.SelectedValue, "BusinessUnit"), "ID", "BussinessUnitName");
        BindDropDowns(dd_category, binddrop.BindDropDowns(ddl_company.SelectedValue, "Category"), "ID", "CategoryName");
        BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    private void _GvResultBind()
    {
        DataSet _Ds = BindGridView();

        if (_Ds.Tables[1].Rows[0]["TotalRows"] != null)
            int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        else
            int_TotalRecords = 0;

        GvResult.DataSource = _Ds.Tables[0];
        GvResult.PageSize = Int_Page_Size;
        GvResult.DataBind();

        CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
    }


    protected void GvResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)GvResult.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");
    }

    protected void GvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvResult.PageIndex = e.NewPageIndex;
        Int_PageIndex = e.NewPageIndex;
        _GvResultBind();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int_Page_Size = Convert.ToInt16(ddlPageSize.SelectedItem.Text.ToString());
        Int_PageIndex = 1;
        int_TotalRecords = 0;
        _GvResultBind();
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

    protected string linkreset(string id)
    {
        query q = new query();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' title='Reset Password'>R</a>";
    }
    protected string linkdelete(string id)
    {
        query q = new query();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' title='Delete Record'>D</a>";
    }

    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        //BindDropDowns(dd_bu, binddrop.BindDropDowns(ddl_company.SelectedValue, "BusinessUnit"), "ID", "BussinessUnitName");
        BindDropDowns(dd_category, binddrop.BindDropDowns(ddl_company.SelectedValue, "Category"), "ID", "CategoryName");
        BindDropDowns(dd_designation, binddrop.BindDropDowns(ddl_company.SelectedValue, "Designation"), "id", "designationname");
    }
    protected void GvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Initiate")
        {
            string empcode = e.CommandArgument.ToString();
            KRAFormBAL objBAL = new KRAFormBAL();
            string result = objBAL.InitiateAppraisalEmployeeWise(empcode, Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));

            if (result != "1")
            {
                General.Alert(result, btn_search);
            }
            else
            {
                General.Alert("Appraisal Initiated.", btn_search);
            }
        }
    }
    protected void chkList_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool checkValue = chkList.SelectedIndex == 0 ? true : false;
        foreach (GridViewRow grdRow in GvResult.Rows)
        {
            CheckBox chk = (CheckBox)grdRow.FindControl("chkInitiate");
            chk.Checked = checkValue;
        }
    }
    protected void btnInitiate_Click(object sender, EventArgs e)
    {
        string errorList = string.Empty;
        foreach (GridViewRow grdRow in GvResult.Rows)
        {
            CheckBox chk = (CheckBox)grdRow.FindControl("chkInitiate");
            Label empCode = (Label)grdRow.FindControl("l0");
            Label empName = (Label)grdRow.FindControl("l2");

            if (chk.Checked)
            {
                string empcode = empCode.Text;
                KRAFormBAL objBAL = new KRAFormBAL();
                string result = objBAL.InitiateAppraisalEmployeeWise(empcode, Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));

                if (result != "1")
                {
                    errorList += empName.Text + " (" + result + ").";
                }
                else
                {
                    SendMail(empCode.Text, empName.Text);
                }
            }
        }

        if (!string.IsNullOrEmpty(errorList))
        {
            General.Alert(errorList, btn_search);
        }
        else
        {
            General.Alert("Appraisal Initiated successfully.", btn_search);
        }
    }

    protected void SendMail(string code, string name)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "select EmailId from tbl_login where empcode=" + code);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string ToEmail = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                    string password = ConfigurationManager.AppSettings["Password"].ToString();
                    NetworkCredential basicCredential = new NetworkCredential(userName, password);

                    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 25;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    smtpClient.EnableSsl = true;
                    message.To.Add(ToEmail.ToString());

                    message.Subject = "Appraisal Notification – Appraisal Initiated for " + name;
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + name + " <br> Appraisal has been initiated for the period 1st April 2015–31st March 2016 by HC Team.<br>Login to HCMS portal to proceed with appraisal process.<br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    smtpClient.Send(message);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void BindInitiated(string Name)
    {
        String sqlstrComment = @"select EmpCode,dbo.GetEmpName(EmpCode) as EmpName,dbo.GetDuration(ID) as Duration,
                        Case When (Select count(*) from KRAForm where KRASettingId=KS.ID)=1 then 
                        Case When (Select IsDraft from KRAForm where KRASettingId=KS.ID)=0 Then 
                        Case When (Select CurrentLevel from KRAForm where KRASettingId=KS.ID)=1 then 'Pending at RM'
                        else Case When (Select CurrentLevel from KRAForm where KRASettingId=KS.ID)=2 then 'Pending at Reviewer' 
                        else 'Pending at Management' end end
                        else 'Pending at User (Draft Mode)' end
                        else 'Pending at User' end as 'Status'
                        from KRASetting KS where KS.IsActive=1 {0} order by EmpCode asc";

        if (string.IsNullOrEmpty(Name))
        {
            sqlstrComment = String.Format(sqlstrComment, "");
        }
        else
        {
            sqlstrComment = String.Format(sqlstrComment, " and dbo.GetEmpName(EmpCode) like '%" + Name + "%'");
        }


        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrComment);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdInitiated.DataSource = ds.Tables[0];
        }
        else
        {
            grdInitiated.DataSource = null;
        }
        grdInitiated.DataBind();
    }
    protected void grdInitiated_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInitiated.PageIndex = e.NewPageIndex;
        BindInitiated("");
    }
    protected void btnInitiatedSearch_Click(object sender, EventArgs e)
    {
        BindInitiated(txtSearch.Text.Trim());
    }
}