using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_RatingMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinData();
        }
    }

    private void BinData()
    {
        String sqlString = "Select Id,Rating,Case When Status=0 Then 'DeActive' Else 'Active' end as StatusSummary,Status from [dbo].[AppraisalRatingMaster]";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlString);

        grd.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        grd.DataBind();
    }
    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Activate")
        {
            string Id = e.CommandArgument.ToString();
            String sqlString = "Update [AppraisalRatingMaster] Set Status=1 Where Id=" + Id + " Update [AppraisalRatingMaster] Set Status=0 Where Id!=" + Id;
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlString);

            BinData();
        }
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label status = (Label)e.Row.FindControl("lblStatus");
            LinkButton lnk = (LinkButton)e.Row.FindControl("lnkAction");

            if (status.ToolTip.ToString() == "1")
            {
                lnk.Visible = false;
            }
        }
    }
}