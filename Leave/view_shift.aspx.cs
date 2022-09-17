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
using DataAccessLayer;

public partial class Leave_view_shift : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            binddata();
        }
        }

    protected void ddselbranch_DataBound(object sender, EventArgs e)
    {
        ddselbranch.Items.Insert(0, new ListItem("For all branch", "0"));
    }

    protected void ddselbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindshift();
    }

    protected void binddata()
    {
        sqlstr = "SELECT shiftid,shiftname,right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description FROM tbl_leave_shift where shiftid not in (0,1,2)";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();
    }

    protected void bindshift()
    {
        if (ddselbranch.SelectedItem.Text == "For all branch")
        {
            sqlstr = "SELECT shiftid,shiftname,right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description FROM tbl_leave_shift where shiftid not in (0,1,2)";
        }
        else
        {
            sqlstr = "SELECT shiftid,shiftname,right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description FROM tbl_leave_shift WHERE branch_id ='" + ddselbranch.SelectedValue + "'";
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();        
    }

    protected void shiftgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        shiftgrid.PageIndex = e.NewPageIndex;
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();
    }
}
