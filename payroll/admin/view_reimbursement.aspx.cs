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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class payroll_admin_view_reimbursement : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_sdate.Attributes.Add("readonly", "readonly");
        txt_edate.Attributes.Add("readonly", "readonly");
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            dd_reimb.DataBind();
          //  dd_dept.DataBind();
          //  dd_branch.DataBind();
    
            //bind_employee_reimburesment();
        }
        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
    }
    
    protected void bind_employee_reimburesment()
    {
        sqlparam = new SqlParameter[7];
        
        sqlparam[0] = new SqlParameter("@empname", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[1].Value = 1;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = 1;

        sqlparam[3] = new SqlParameter("@reimb_ref_no", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txt_ref.Text.ToString();

        sqlparam[4] = new SqlParameter("@reimb_name", SqlDbType.Int);
        sqlparam[4].Value =dd_reimb.SelectedValue;

        sqlparam[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[5].Value =txt_sdate.Text.Trim();

        sqlparam[6] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[6].Value = txt_edate.Text.Trim();


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_reimbursement_detail", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_employee_reimburesment();
        message.InnerHtml = "";
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
       // dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
       // dd_dept.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_reimb_DataBound(object sender, EventArgs e)
    {
        dd_reimb.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
               empgrid.PageIndex = e.NewPageIndex;
        bind_employee_reimburesment();
    }

    protected void empgrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_employee_reimburesment();
    }
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_sanctiondate = (Label)e.Row.FindControl("lbl_sanctiondate");
            if (lbl_sanctiondate != null)
            {
                if (!string.IsNullOrEmpty(lbl_sanctiondate.Text.Trim()))
                {
                    try
                    {
                        lbl_sanctiondate.Text = Convert.ToDateTime(lbl_sanctiondate.Text).ToString("dd-MMM-yyyy");
                    }
                    catch (Exception ex)
                    { 
                    
                    }
                }
            }
        }
    }
}
