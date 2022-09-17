using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic;
using System.Data;

public partial class Appraisal_Reports_OrganizationWideReport : System.Web.UI.Page
{
    ReportsBAL objBAL;
    DataTable dt;

    public Appraisal_Reports_OrganizationWideReport()
    {
        objBAL = new ReportsBAL();
        dt = new DataTable();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            BinData();
        }
    }

    private void BinData()
    {
        try
        {
            dt = objBAL.OrganizationRatingReport();
            if (dt.Rows.Count > 0)
            {
                grdResult.DataSource = dt;
            }
            else
            {
                grdResult.DataSource = null;
            }
            grdResult.DataBind();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }
    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Summary")
        {
            try
            {
                int ScaleID = Convert.ToInt32(e.CommandArgument);
                dt = objBAL.OrganizationRatingReportSummary(ScaleID);

                if (dt.Rows.Count > 0)
                {
                    grdSummary.DataSource = dt;
                    divSummary.Visible = true;
                }
                else
                {
                    divSummary.Visible = false;
                    grdSummary.DataSource = null;
                }
                grdSummary.DataBind();
            }
            catch (Exception ex)
            {
                General.Alert(ex.Message, grdResult);
            }

        }
    }
    protected void grdSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdResult.PageIndex = e.NewPageIndex;
            BinData();
        }
        catch (Exception ex)
        {
            General.Alert(ex.Message, grdResult);
        }

    }
    protected void grdSummary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "V")
        {
            try
            {
                string empCode = e.CommandArgument.ToString();
                Response.Redirect("EmployeeMasterReportSummary.aspx?EmpCode=" + empCode);
            }
            catch (Exception ex)
            {
                General.Alert(ex.Message, grdResult);
            }

        }
    }
}