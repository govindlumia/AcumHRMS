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
            _BindCandidate();
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
        BindDropDowns(ddlStatus, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "CanStatus"), "ID", "Dsca");

       // ddlStatus.SelectedValue = "2"; // By default Pending
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void _BindCandidate()
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        string Type = "HRExecutive";

        if (string.Compare(ViewState["Type"].ToString(), "C") == 0)
        {
            Type = "CREATOR";
        }
        else if (string.Compare(ViewState["Type"].ToString(), "HRE") == 0)
        {
            Type = "HREXECUTIVE";
        }
        else if (string.Compare(ViewState["Type"].ToString(), "EMP") == 0)
        {
            Type = "EMPLOYEE";
        }
        else if (string.Compare(ViewState["Type"].ToString(), "COO") == 0)
        {
            Type = "COO";
        }

        ObjCanENT.Vac_ID = txtVacancyID.Text.Trim();
        ObjCanENT.Can_ID = txtCanID.Text.Trim();
        ObjCanENT.ReqType = Type;
        ObjCanENT.CanStatusID = int.Parse(ddlStatus.SelectedValue.ToString());
        ObjCanENT.FromDate = txt_FromDate.Text.ToString();
        ObjCanENT.ToDate = txt_Todate.Text.ToString();
        ObjCanENT.Pageindex = Int_PageIndex;
        ObjCanENT.PageSize = Int_Page_Size;
        ObjCanENT.SortBy = "";
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanMaster(ObjCanENT);

        if (ds.Tables[1].Rows[0]["TOTALROWS"] != null)
            int_TotalRecords = Convert.ToInt32(ds.Tables[1].Rows[0]["TOTALROWS"]);
        else
            int_TotalRecords = 0;

        GvCanRequest.DataSource = ds;
        GvCanRequest.DataBind();

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

        _BindCandidate();
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
        //_BindCandidate();
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _BindCandidate();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtVacancyID.Text = "";
        txtCanID.Text = "";
        txt_FromDate.Text = "";
        txt_Todate.Text = "";
        ddlStatus.SelectedIndex = 0;

        _BindCandidate();
    }

    #region /// Dropdown DataBound
    protected void ddlStatus_DataBound(object sender, EventArgs e)
    {
        ddlStatus.Items.Insert(0, new ListItem("---All---", "0"));
    }
    #endregion

    protected void GvCanRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton lnkDraft = (LinkButton)e.Row.FindControl("lnkDraft");
            Label lbCAN_ID = (Label)e.Row.FindControl("lbCAN_ID");
            Label lblCreatedDate = (Label)e.Row.FindControl("lblCreatedDate");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");

            lblCreatedDate.Text = Convert.ToDateTime(lblCreatedDate.Text).ToString(General.DateFormatRecruitment());

            #region // Details
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(lbCAN_ID.Text.ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "";
            if (string.Compare(ViewState["Type"].ToString(), "HRE") == 0)
                url = "CanViewDetails.aspx?ID=" + writer.ToString() + "&Type=HRE";
            else
                url = "CanViewDetails.aspx?ID=" + writer.ToString() + "";

            lnkView.PostBackUrl = url;

            url = "CanEdit.aspx?ID=" + writer.ToString() + "";
            lnkDraft.PostBackUrl = url;

            if (lnkDraft.ToolTip == "8")
            {
                lnkDraft.Visible = true;
                lblStatus.Visible = false;
            }

            #endregion
        }
    }
}