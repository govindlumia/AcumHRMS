using HRMS.BusinessEntity.Api;
using HRMS.BusinessLogic.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recruitment_Admin_ResumeList : System.Web.UI.Page
{
    public static DataSet ds = new DataSet();

    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 25;
    public static string Str_SortBy = "ID";
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        // changed on Sept 5 for implementing Searchable Grid by Keerti Dwivedi
        if (!this.IsPostBack)
        {
            _GvResultBind();
        }
        // upto here
    }

    protected void GvResume_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //int a = (int)GvResume.DataKeys[e.NewEditIndex].Value;
        //Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");
    }

    // Added on Sept 5 for implementing Searchable Grid by Keerti Dwivedi
    protected void GvResume_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvResume.PageIndex = e.NewPageIndex;
        Int_PageIndex = e.NewPageIndex;
        _GvResultBind();
    }
    // upto here
    private void _GvResultBind()
    {
        DataSet _Ds = BindGridView();
        // changed on Sept 5 for implementing Searchable Grid by Keerti Dwivedi
        txtSearch.Text = string.Empty;
        // upto here

        //if (_Ds.Tables[0].Rows[0]["TotalRows"] != null)
        //    int_TotalRecords = Convert.ToInt32(_Ds.Tables[1].Rows[0]["TotalRows"]);
        //else
        //    int_TotalRecords = 0;

        GvResume.DataSource = _Ds.Tables[0];
        GvResume.PageSize = Int_Page_Size;
        GvResume.DataBind();

        //CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);
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
        //switch (e.CommandName)
        //{
        //    case "First":
        //        Int_PageIndex = 1;
        //        break;

        //    case "Previous":
        //        Int_PageIndex = Int32.Parse(lblCurrentPage.Text) - 1;

        //        break;

        //    case "Next":
        //        Int_PageIndex = Int32.Parse(lblCurrentPage.Text) + 1;
        //        break;

        //    case "Last":
        //        Int_PageIndex = Int32.Parse(lblTotalPages.Text);
        //        break;
        //}
        //_GvResultBind();
    }

    protected void GvResume_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HyperLink view = (HyperLink)e.Row.Cells[4].Controls[0];
            //HyperLink edit = (HyperLink)e.Row.Cells[5].Controls[0];

            //view.ToolTip = "View";
            //edit.ToolTip = "Edit";
        }
    }


    protected void GvResume_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd_DownloadResume")
        {
            var imagePath = ConfigurationManager.AppSettings["JobSeekerResumePath"];
            //Response.TransmitFile(imagePath + e.CommandArgument);
            //Response.End();
            WebClient client = new WebClient();
            byte[] imageData = client.DownloadData(imagePath + e.CommandArgument);

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument);
            //Response.ContentType = "image/JPEG";
            Response.OutputStream.Write(imageData, 0, imageData.Length);
            Response.End();
        }
    }

    private DataSet BindGridView()
    {
        ResumeModel objModel = new ResumeModel();
        //objModel.Name = HttpContext.Current.Request["Name"];
        //objModel.Phone = HttpContext.Current.Request["Phone"];
        //objModel.Email = HttpContext.Current.Request["Email"];
        //objModel.Subject = HttpContext.Current.Request["Subject"];
        //objModel.Message = HttpContext.Current.Request["Message"];
        //objModel.Job_Profile = HttpContext.Current.Request["Profile"];
        //objModel.Total_Exp = HttpContext.Current.Request["Experience"];
        //objModel.ResumeName = Photo1.FileName;
        ////ObjEmpJobDetailENT.Home_Bussiness_unit = Convert.ToInt32(dd_bu.SelectedValue);
        objModel.Pageindex = Int_PageIndex;
        objModel.PageSize = Int_Page_Size;
        objModel.SortBy = Str_SortBy;

        ResumeManager resManager = new ResumeManager();
        // changed on Sept 5 for implementing Searchable Grid by Keerti Dwivedi
        if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
        {
            objModel.SearchText = txtSearch.Text.Trim().ToString();
        }
        else
        {
            objModel.SearchText = string.Empty;
        }
        // upto here
        ds = resManager.SelectResumeList(objModel);
        return ds;
    }

    protected void GvResume_Sorting(object sender, GridViewSortEventArgs e)
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
        GvResume.DataSource = sortedView;
        GvResume.DataBind();
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

    // Added on Sept 5 for implementing Searchable Grid by Keerti Dwivedi
    protected void Search(object sender, EventArgs e)
    {
        this._GvResultBind();
    }
    // upto here
}