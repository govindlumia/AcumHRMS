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
using System.IO;
using System.Collections.Generic;
public partial class payroll_admin_create_view_graduity : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                Response.Redirect("~/Authenticate.aspx");
        }      
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
        txtdate.Attributes.Add("readonly", "readonly");
        if (!IsPostBack)
        {
            BindFY();
        }
    }

    protected void BindFY()
    {
        List<string> lstFY = General.GetFinancialYearList();
        for (int i = 0; i < lstFY.Count; i++)
        {
            dd_year.Items.Add(new ListItem(lstFY[i], lstFY[i]));
        }
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        String currentFY = General.GetFinancialYearByDate(DateTime.Now);
        dd_year.SelectedValue = currentFY;
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
       
        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@date", Convert.ToDateTime(txtdate.Text.ToString()));
        sqlparm[2] = new SqlParameter("@user", Session["name"].ToString());

        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity]", sqlparm);
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bindgrid();
        graduityview.Visible = true;
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity_show]", sqlparm);
        empgrid.DataSource = ds;
        empgrid.DataBind();
        if (ds.Tables[1] != null)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblgraduityamt.Text = ds.Tables[1].Rows[0]["Total_amt"].ToString();
                lblgraduitydate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["Date"]).ToString("dd-MMM-yyyy");
            }
            }
        }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void exportexcel()
    {
        //try
        //{
        SqlParameter[] sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity_show]", sqlparm);
        
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =GRATUITY.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[0].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_doj = (Label)e.Row.FindControl("lbl_doj_grid");
            if (lbl_doj != null)
            { 
            if(!string.IsNullOrEmpty(lbl_doj.Text))
            {
                try
                {
                    DateTime datetime = Convert.ToDateTime(lbl_doj.Text);
                    if (datetime != null)
                    {
                        lbl_doj.Text = datetime.ToString("dd-MMM-yyyy");
                    }
                }
                catch (Exception ex)
                {
                  
                }
            }
            }
        }
    }
}
