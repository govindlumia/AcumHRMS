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
using System.Data.SqlClient;
public partial class payroll_admin_sectionmaster_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindSectionMaster();
            bindSection();
        }
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";

    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO tbl_payroll_sectionmaster(sname,description) values('" + txtsectionname.Text.Trim().ToString().Replace("'", "''") + "','" + txtsectdescription.Text.Trim().ToString().Replace("'", "''") + "')";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        ddlsectionname.DataBind();
        sectiongird.DataBind();
        message.InnerHtml = "Section has been created successfully !";
    }

    private void bindSectionMaster()
    {
        sqlstr = "SELECT distinct id,sname,description from tbl_payroll_sectionmaster";
        DataSet ds_result = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        sectiongird.DataSource = ds_result.Tables[0];
        sectiongird.DataBind();
    }

    protected void bindSection()
    {
        sqlstr = "SELECT distinct id,section_name,section_detail,description from tbl_payroll_sectiondetail";
        DataSet ds_result = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        sectiondetailgrid.DataSource = ds_result.Tables[0];
        sectiondetailgrid.DataBind();

    }

    protected void btncreatsection_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO tbl_payroll_sectiondetail(section_name,description,section_detail) values('" + ddlsectionname.SelectedValue.ToString() + "','" + txtsecdetaildesc.Text.Trim().ToString().Replace("'", "''") + "','" + txtsectiondetail.Text.Trim().ToString().Replace("'", "''") + "')";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        sectiondetailgrid.DataBind();
        message.InnerHtml = "Section Detail has been created successfully !";
    }
    protected void sectiondetailgrid_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void sectiondetailgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        sectiondetailgrid.PageIndex = e.NewPageIndex;
        bindSection();
    }
    protected void sectiongird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        sectiongird.PageIndex = e.NewPageIndex;
        bindSectionMaster();
    }
    protected void sectiongird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow _gvr = sectiongird.Rows[e.RowIndex];
        TextBox txt_secDesc = (TextBox)_gvr.FindControl("txt_sectionDesc");
        int _ID = Convert.ToInt32(sectiongird.DataKeys[e.RowIndex].Value);
        if (txt_secDesc != null)
        {
            sqlstr = "update tbl_payroll_sectionmaster set description='" + txt_secDesc.Text + "' where id=" + _ID + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        }
        sectiongird.EditIndex = -1;
        bindSectionMaster();
    }
    protected void sectiongird_RowEditing(object sender, GridViewEditEventArgs e)
    {
        sectiongird.EditIndex = e.NewEditIndex;
        bindSectionMaster();
    }
    protected void sectiongird_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        sectiongird.EditIndex = -1;
        bindSectionMaster();
    }
    protected void sectiondetailgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        sectiondetailgrid.EditIndex = e.NewEditIndex;
        bindSection();
    }
    protected void sectiondetailgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow _gvr = sectiondetailgrid.Rows[e.RowIndex];
        TextBox txt_secDesc = (TextBox)_gvr.FindControl("txt_sectionDesc_Edit");
        int _ID = Convert.ToInt32(sectiondetailgrid.DataKeys[e.RowIndex].Value);
        if (txt_secDesc != null)
        {
            sqlstr = "update tbl_payroll_sectiondetail set description='" + txt_secDesc.Text + "' where id=" + _ID + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        }
        sectiondetailgrid.EditIndex = -1;
        bindSection();
    }
    protected void sectiondetailgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        sectiondetailgrid.EditIndex = -1;
        bindSection();
    }
}
