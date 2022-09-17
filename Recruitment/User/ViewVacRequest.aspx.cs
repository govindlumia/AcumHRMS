using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;
using System.IO;
using QueryStringEncryption;
using InfoSoftGlobal;
using Utilities;

public partial class Recruitment_User_ViewVacRequest : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();
    DataTable _DtEmpty = new DataTable();

    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 25;
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();
            ViewState["Type"] = Request.QueryString["Type"].ToString();

            _FillControls();
            _BindVaccancy();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();

        BindDropDowns(ddl_joblocation, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Branch"), "branch_id", "branch_name");
        BindDropDowns(ddlStatus, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "VacStatus"), "ID", "Dsca");
        BindDropDowns(ddlAppStatus, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "VacApprovalStatus"), "ID", "Dsca");

       // ddlStatus.SelectedValue = "2"; // By default Pending
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void _BindVaccancy()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        string Type = "Creator";
        
        if(string.Compare(ViewState["Type"].ToString(),"C") == 0)
            Type = "Creator";
        else if(string.Compare(ViewState["Type"].ToString(),"A") == 0)
            Type = "Approver";
        else if (string.Compare(ViewState["Type"].ToString(), "H") == 0)
            Type = "HR";
        else if(string.Compare(ViewState["Type"].ToString(), "O") == 0)
            Type = "COO";
        else if (string.Compare(ViewState["Type"].ToString(), "HRE") == 0)
            Type = "HRExecutive";
        else if (string.Compare(ViewState["Type"].ToString(), "HRH") == 0)
            Type = "HRHead";

        ObjVacENT.Vac_ID = txtVacancyID.Text.Trim();
        ObjVacENT.ReqType = Type;
        ObjVacENT.Location_ID = int.Parse(ddl_joblocation.SelectedValue.ToString());
        ObjVacENT.Vac_StatusID = int.Parse(ddlStatus.SelectedValue.ToString());
        ObjVacENT.ApprovalStatusID = int.Parse(ddlAppStatus.SelectedValue.ToString());
        ObjVacENT.FromDate = txt_FromDate.Text.ToString();
        ObjVacENT.ToDate = txt_Todate.Text.ToString();
        ObjVacENT.Pageindex= Int_PageIndex;
        ObjVacENT.PageSize = Int_Page_Size;
        ObjVacENT.SortBy = "";
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjVacBusiness.SelectVaccancy(ObjVacENT);

        if (ds.Tables[1].Rows[0]["TOTALROWS"] != null)
            int_TotalRecords = Convert.ToInt32(ds.Tables[1].Rows[0]["TOTALROWS"]);
        else
            int_TotalRecords = 0;

        GvVacRequest.DataSource = ds;
        GvVacRequest.DataBind();

        if (GvVacRequest.Rows.Count > 0)
        {
            if (string.Compare(ViewState["Type"].ToString(), "HRE") == 0)
                GvVacRequest.Columns[9].Visible = false;
            else
                GvVacRequest.Columns[10].Visible = false;
        }

        CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
    }

    #region custom paging----------
    public void CustomPaging(Label lblTotalPages, Label lblCurrentPage, int cp, double totalRows, LinkButton Btn_Previous, LinkButton Btn_Next)
    {
        lblTotalPages.Text = CalculateTotalPage(totalRows).ToString();
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
            // Btn_First.Enabled = true;

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
    private void ButtonEvent(int pageNo)
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

        _BindVaccancy();
    }
    private int CalculateTotalPage(double totalRecords)
    {
        int totalPages = (int)Math.Ceiling(totalRecords / Int_Page_Size);
        return totalPages;
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Int_Page_Size = Convert.ToInt16(ddlPageSize.SelectedItem.Text.ToString());
        //Int_Page_Size = 25;
        //Int_PageIndex = 1;
        //int_TotalRecords = 0;
        //_BindVaccancy();
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _BindVaccancy();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtVacancyID.Text = "";
        txt_FromDate.Text = "";
        txt_Todate.Text = "";
        ddl_joblocation.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlAppStatus.SelectedIndex = 0;

        _BindVaccancy();
    }

    #region /// Dropdown DataBound
    protected void ddljoblocation_DataBound(object sender, EventArgs e)
    {
        ddl_joblocation.Items.Insert(0, new ListItem("---All---", "0"));
    }
    protected void ddlStatus_DataBound(object sender, EventArgs e)
    {
        ddlStatus.Items.Insert(0, new ListItem("---All---", "0"));
    }
    protected void ddlAppStatus_DataBound(object sender, EventArgs e)
    {
        ddlAppStatus.Items.Insert(0, new ListItem("---All---", "0"));
    }
    #endregion

    protected void GvVacRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton lnkAddCan = (LinkButton)e.Row.FindControl("lnkAddCan");
            Label lblVac_ID = (Label)e.Row.FindControl("lblVac_ID");
            Label lblCreatedDate = (Label)e.Row.FindControl("lblCreatedDate");
            Label lblVacStatusID = (Label)e.Row.FindControl("lblVacStatusID");
            
            lblCreatedDate.Text = Convert.ToDateTime(lblCreatedDate.Text).ToString(General.DateFormatRecruitment());

            #region // Link to redirect page Details
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lblVac_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "VacViewDetails.aspx?ID=" + writer.ToString() + "";
            lnkView.PostBackUrl = url;

            url = "CreateCan.aspx?ID=" + writer.ToString() + "";
            lnkAddCan.PostBackUrl = url;

            #endregion

            if (string.Compare(lblVacStatusID.Text, "2") == 1)
            {
                lnkAddCan.Visible = false;
            }
        }
    }
}