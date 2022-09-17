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

public partial class payroll_admin_cashstatement : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds, dsExcel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_month();
        }
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[4];

        sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
        sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

        sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
        sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

        sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
        sqlparm[2].Value = "1";

        sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
        sqlparm[3].Value = (rbtnCash.Checked ? 2:1);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_cashchequestatement]", sqlparm);

        bankgrid.DataSource = ds;
        bankgrid.DataBind();
        if (ds.Tables.Count > 0)
        {
            ViewState["dataView"] = ds.Tables[0];
        }
        else
            ViewState["dataView"] = null;
        lblmonth.Text = ddlmonth.SelectedItem.Text.Trim().ToString() + '-' + dd_year.SelectedItem.Text.Trim().ToString();
    }

    protected void bind_month()
    {
        ddlmonth.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            ddlmonth.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        ddlmonth.SelectedValue = a.Month.ToString();
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
        //btnOK.Visible = false;
    }

    //protected void dd_branch_DataBound(object sender, EventArgs e)
    //{
    //    dd_branch.Items.Insert(0, new ListItem("---Select Location---", "0"));
    //    //btnOK.Visible = false;
    //}

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bindgrid();
        //btnOK.Visible = false;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        //btnOK.Visible = false;
    }

    protected void clear()
    {
      //  dd_branch.SelectedIndex = 0;
        dd_year.SelectedIndex = 0;
        //ddlmonth.SelectedIndex = 0;
        // ddl_reimbursement_type.SelectedIndex = 0;
    }

    protected void bankgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        bankgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    //protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    //{
    //    ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank---", "0"));
    //}

    protected void exportexcel()
    {
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =CASH_CHEQUE_STATEMENT.xls";
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
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        MailScript scriptObj = new MailScript();

        if (ViewState["dataView"] != null)
        {
            DataTable dt_result = (DataTable)ViewState["dataView"];
            if (dt_result.Columns.Contains("year"))
            dt_result.Columns.Remove("year");
            if (dt_result.Columns.Contains("month"))
            dt_result.Columns.Remove("month");
            dt_result.Columns["paymentmode"].SetOrdinal(2);
            scriptObj.exportToExcelInCustomized(dt_result, bankgrid.HeaderRow, "Cash Statement", this.form1, "cashstatement");

        
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nodata", "alert('No data');", true);
        }



        //bindgrid();
        //exportexcel();
        //exportexcelNew();
    }

    //protected void exportexcelNew()
    //{
    //    // bindgrid();
    //    Response.Clear(); //this clears the Response of any headers or previous output 
    //    Response.Charset = "";
    //    Response.Buffer = true; //make sure that the entire output is rendered simultaneously
    //    Response.ClearContent();
    //    Response.ContentType = "application/vnd.ms-excel";
    //    string filename = "attachment;filename =BANKSTATEMENT.xls";
    //    //string filename = "attachment;filename =Attendance-1.xls";
    //    //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
    //    Response.Write(filename);
    //    Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
    //    StringWriter stringWrite = new StringWriter();
    //    HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
    //    //DataGrid dg = new DataGrid();
    //    //dg.DataSource = ds.Tables[0];
    //    //dg.DataBind();

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("empname");
    //    dt.Columns.Add("acno");
    //    dt.Columns.Add("totamount");
    //    dt.Columns.Add("bankname");
    //    dt.Columns.Add("month");

    //    //foreach (GridViewRow row in bankgrid.Rows)   
    //    foreach (GridViewRow row in bankgrid.Rows)
    //    {
    //        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
    //        if (chk.Checked == true)
    //        {
    //            int i = row.RowIndex;
    //            Label empN = (Label)bankgrid.Rows[i].FindControl("lblEmpName");
    //            Label acNo = (Label)bankgrid.Rows[i].FindControl("lblACName");
    //            Label bName = (Label)bankgrid.Rows[i].FindControl("lblTotAmount");

    //            DataRow dr = dt.NewRow();
    //            dr["empname"] = Convert.ToString(empN.Text.Trim());
    //            dr["acno"] = Convert.ToString(acNo.Text.Trim());
    //            dr["totamount"] = Convert.ToString(bName.Text.Trim());
    //            dr["bankname"] = Convert.ToString(ddl_bank_name.SelectedItem.ToString());
    //            dr["month"] = Convert.ToString(ddlmonth.SelectedItem.ToString());
    //            dt.Rows.Add(dr);
    //        }
    //    }
    //    GridView GridView1 = new GridView();
    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();

    //    String style = @"<style>.text{mso-number-format:\@;}</style>";
    //    HttpContext.Current.Response.Write(style);
    //    int colindex = 0;
    //    //foreach (DataColumn dc in dt.Columns)
    //    //{
    //    //    string valuetype = dc.DataType.ToString();
    //    //    foreach (DataGridItem i in GridView1.ro GridView1.Items)
    //    //        i.Cells[0].Attributes.Add("class", "text");
    //    //    colindex++;
    //    //}

    //    GridView1.RenderControl(htmlwrite);
    //    Response.Write(stringWrite.ToString());
    //    Response.End();
    //}

    //protected void lnkResign_Click(object sender, EventArgs e)
    //{

    //    bindgridRse();
    //}

    //protected void bindgridRse()
    //{
    //    SqlParameter[] sqlparm = new SqlParameter[4];

    //    sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
    //    sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

    //    sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
    //    sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

    //    sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
    //    sqlparm[2].Value = dd_branch.SelectedValue.ToString();

    //    sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
    //    sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

    //    if (ddl_reimbursement_type.SelectedIndex == 0)
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_bankstatement_bank_leavEmp", sqlparm);

    //    if (ddl_reimbursement_type.SelectedIndex == 1)
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_bankstatement_reimbursement]", sqlparm);
    //    //[sp_payroll_bankstatement_bonus]
    //    if (ddl_reimbursement_type.SelectedIndex == 2)
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_bankstatement_bonus]", sqlparm);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        bankgrid.DataSource = ds;
    //        bankgrid.DataBind();
    //        btnOK.Visible = true;
    //    }
    //    else
    //    {
    //        bankgrid.DataSource = ds;
    //        bankgrid.DataBind();
    //        btnOK.Visible = false;
    //    }

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblbankname.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
    //    }
    //    else
    //    {
    //        lblbankname.Text = ddl_bank_name.SelectedItem.Text.ToString();
    //    }
    //    lblmonth.Text = ddlmonth.SelectedItem.Text.Trim().ToString() + '-' + dd_year.SelectedItem.Text.Trim().ToString();

    //    foreach (GridViewRow row in bankgrid.Rows)
    //    {
    //        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
    //        if (chk.Checked == true)
    //        {
    //            chk.Checked = false;
    //        }
    //    }
    //}

    //protected void btnOK_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in bankgrid.Rows)
    //    {
    //        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
    //        if (chk.Checked == true)
    //        {
    //            int j = row.RowIndex;
    //            Label empCode = (Label)bankgrid.Rows[j].FindControl("lblEmpCode");

    //            SqlParameter[] sqlparm = new SqlParameter[3];

    //            sqlparm[0] = new SqlParameter("@empcode", SqlDbType.NVarChar, 50);
    //            sqlparm[0].Value = empCode.Text.Trim();

    //            sqlparm[1] = new SqlParameter("@year", SqlDbType.NVarChar, 50);
    //            sqlparm[1].Value = dd_year.SelectedItem.ToString();

    //            sqlparm[2] = new SqlParameter("@month", SqlDbType.NVarChar, 50);
    //            sqlparm[2].Value = ddlmonth.SelectedItem.ToString();

    //            int ii = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "usp_update_holdSal", sqlparm);

    //        }
    //    }
    //}
    protected void BtnDeliversal_Click(object sender, EventArgs e)
    {

    }
}
