using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;

public partial class Leave_Comp_offcredited : System.Web.UI.Page
{
    DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }
    }

    private void bindGrid()
    {
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@empcode", Session["empCode"].ToString());
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_getCompOffCreditHistory", arrParam);
        if (ds.Tables[0] != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
                grd_compoffmarked.DataSource = ds.Tables[0];
            else
                grd_compoffmarked.DataSource = null;
            grd_compoffmarked.DataBind();
        }
    
    }
    protected void grd_compoffmarked_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_compoffmarked.PageIndex = e.NewPageIndex;
        bindGrid();
    }
}