using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic;
using System.Data;

public partial class Appraisal_Reports_AppraisalStatusReport : System.Web.UI.Page
{
    ReportsBAL objBAL;
    DataTable dt;

    public Appraisal_Reports_AppraisalStatusReport()
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
            dt = objBAL.AppraisalStatusReport();
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
        catch(Exception ex)
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
                int Status = Convert.ToInt32(e.CommandArgument);
                dt = objBAL.AppraisalStatusReportSummary(Status);

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
}