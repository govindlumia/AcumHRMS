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

public partial class payroll_admin_viewdeclaration : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["message"] != null)
            message.InnerHtml = Request.QueryString["message"].ToString();

        //bind_emp_declaration();
    }
   
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
       // dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
      //  dd_dept.Items.Insert(0, new ListItem("All", "0"));       
    }

    protected string linkviewdedit(string ref_no,string visiblity)
    {
        if (visiblity == "1")
        {
            return @"<a class='link05'   href='viewdeclarationdetail.aspx?ref_no=" + ref_no + @"' target='_self'>View</a> |  
                       <a class='link05'  href='editdeclarationdetail.aspx?ref_no=" + ref_no + @"' target='_self'>Edit</a>";
        }
        else
            return "No Links";
    }

    protected void bind_emp_declaration()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_fyr.SelectedItem.Text;

        sqlparam[1] = new SqlParameter("@empname", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[2].Value = 1;
        //if (dd_branch.SelectedValue == "")
        //    sqlparam[2].Value = 0;
        //else
        //    sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[3].Value = 1;
        //if (dd_dept.SelectedValue == "")
        //    sqlparam[3].Value = 0;
        //else
        //    sqlparam[3].Value = dd_dept.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 1);
        sqlparam[4].Value = ddl_status.SelectedValue;
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_declaration_detail", sqlparam);
        
        griddetail.DataSource = ds;
        ViewState["Record"] = ds;
        griddetail.DataBind();    
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_emp_declaration();
    }

    protected void griddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        DataSet dt = (DataSet)ViewState["Record"];
        bind_emp_declaration();
    }

    #region "Export to Excel"

    protected void imgExportExcel_Click(object sender, EventArgs e)
    {
        //if (griddetail.Rows.Count > 0)
        //    ExportToExcel();
        //else
        //    General.Alert("No Record(s) Found", imgExportExcel);
    }

    public void ExportToExcel()
    {
        try
        {
            DataSet dt = new DataSet();
            if (ViewState["Record"] != null)
                dt = (DataSet)ViewState["Record"];
            else
                dt = new DataSet();
            Response.AddHeader("content-disposition", "attachment; filename=InvestmentDeclarationReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataGrid g = new DataGrid();
            g.DataSource = dt;
            g.DataBind();
            foreach (DataGridItem i in g.Items)
            {
                foreach (TableCell tc in i.Cells)
                    tc.Attributes.Add("class", "text");
            }
            g.HeaderStyle.Font.Bold = true;
            g.RenderControl(htmlWrite);
            string style = @"<style> .text { mso-number-format:\@; } </style> ";
            Response.Write(style);
            Response.Write(stringWrite.ToString());
            Response.End();

            //------

        }
        catch (Exception ex)
        {
        }
    }

    #endregion
}
