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
public partial class payroll_admin_bankstatementform : System.Web.UI.Page
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
            transactioncommentssection.Visible = false;
           // bind_month();
        }
    }
    public DataSet Bindgriddatafordisbursement(SqlParameter[] sqlparam, string procedurename)
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, procedurename , sqlparam);
        return ds;
    }
    //===========================Bind Grid On Submit Button Click=======================

    public DataSet Addcolumn(DataSet ds)
    {
        System.Data.DataColumn newColumn = new System.Data.DataColumn("acno", typeof(System.String));
        newColumn.DefaultValue = "123456123456";
        ds.Tables[0].Columns.Add(newColumn);
        return ds;
    }
    protected void bindgrid()
    {
        //====paytype Bank of salary==========================================================
        lblbankname.Text = "";
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex==1)
        {
            SqlParameter[] sqlparm = new SqlParameter[4];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_bank]");
        }
        //====paytype check  of salary=========================================================
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";
            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement]");
            ds=Addcolumn(ds);
           

        }
        //====paytype cash  of salary==========================================================
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex == 3)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";
            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement]");
            ds = Addcolumn(ds);
        }
        //====paytype Bank of reimbursement ==================================================
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 1)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDBANK";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_reimbursement]");
        }
        //====paytype check of reimbursement=================================================== 
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement_reimbursement]");
            ds = Addcolumn(ds);
        }
        //====paytype cash of reimbursement====================================================
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 3) 
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement_reimbursement]");
            ds = Addcolumn(ds);
        }
        //====paytype Bank of bonus============================================================
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 1)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDBANK";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_bonus]");
        }
        //====paytype Check of bonus============================================================
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";

            ds = Bindgriddatafordisbursement(sqlparm, "[SP_PAYROLL_CHECKCASHSTATEMENT_BONUS]");
            ds = Addcolumn(ds);
            
        }
        //====paytype Cash of bonus============================================================= 
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 3)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";

            ds = Bindgriddatafordisbursement(sqlparm, "[SP_PAYROLL_CHECKCASHSTATEMENT_BONUS]");
            ds = Addcolumn(ds);

        }
        bankgrid.DataSource = ds;
        bankgrid.DataBind();

        if (ds.Tables[0].Rows.Count>0)
        {
            ViewState["dataView"] = ds.Tables[0];
            transactioncommentssection.Visible = true;

        }
        else
        {
            ViewState["dataView"] = null;
            transactioncommentssection.Visible = false;

        }
        dsExcel = ds;

        if (Ddldisbursementtype.SelectedIndex == 1)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbankname.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            }
            else
            {
                if (ddl_bank_name.SelectedIndex != 0)
                {
                    lblbankname.Text = ddl_bank_name.SelectedItem.Text.ToString();
                }
                else
                {
                    General.Alert("Please choose bank name!", lnkResign);
                    ddl_bank_name.Focus();

                }
            }
            lblmonth.Text = "Bank-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }
        if (Ddldisbursementtype.SelectedIndex == 2)
        {
            lblmonth.Text = "Check-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }
        if (Ddldisbursementtype.SelectedIndex == 3)
        {
            lblmonth.Text = "Cash-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }
    }
    //==================================================================================

    //protected void bind_month()
    //{
    //    ddlmonth.Items.Insert(0, new ListItem("---Select Month---", "0"));
    //    for (int i = 1; i <= 12; i++)
    //    {
    //        ListItem item = new ListItem();
    //        item.Text = new DateTime(1900, i, 1).ToString("MMM");
    //        item.Value = i.ToString();
    //        ddlmonth.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
    //    }
    //   // DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
    //  //  ddlmonth.SelectedValue = a.Month.ToString();
    //}

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        //dd_branch.Items.Insert(0, new ListItem("---Select Location---", "0"));
        //btnOK.Visible = false;
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
         bindgrid();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
      //  dd_branch.SelectedIndex = 0;
        dd_year.SelectedIndex = 0;
        ddl_bank_name.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        ddl_reimbursement_type.SelectedIndex = 0;
        bankgrid.DataSource = null;
        bankgrid.DataBind();
        Ddldisbursementtype.SelectedIndex = 0;
    }

    protected void bankgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        bankgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank---", "0"));
    }

    protected void exportexcel()
    {
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =BANKSTATEMENT.xls";
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
        //bindgrid();
        //exportexcel();

        if (ViewState["dataView"] != null)
        {
            DataTable dt_result = (DataTable)ViewState["dataView"];
            MailScript scriptObj = new MailScript();
            GridViewRow _row = new GridViewRow(0,0,DataControlRowType.Header,DataControlRowState.Normal);
       TableCell[] cells=new TableCell[3];
            cells[0]=new TableCell();
            cells[1]=new TableCell();
            cells[2]=new TableCell();
            cells[0].Text = "Employee Name";
            cells[1].Text = "Account Number";
            cells[2].Text = "Total Amount";

            _row.Cells.AddRange(cells);
            if (dt_result.Columns.Contains("empcode"))
            {
                dt_result.Columns.Remove("empcode");
            }
            dt_result.Columns["ACNO"].SetOrdinal(2);
            dt_result.Columns["TOTAMOUNT"].SetOrdinal(3);
            dt_result.Columns.Remove("YEAR");
            dt_result.Columns.Remove("MONTH");
            dt_result.Columns.Remove("BANKNAME");
            scriptObj.exportToExcelInCustomized(dt_result, _row, "Bank Statement", this.form1, "bankstatement");
        }
        else
        {
        ScriptManager.RegisterStartupScript(this,GetType(),"nodata","alert('No data ');",true);
        }

    }

    protected void exportexcelNew()
    {
        // bindgrid();
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =BANKSTATEMENT.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        DataTable dt = new DataTable();
        dt.Columns.Add("empname");
        dt.Columns.Add("acno");
        dt.Columns.Add("totamount");
        dt.Columns.Add("bankname");
        dt.Columns.Add("month");

        //foreach (GridViewRow row in bankgrid.Rows)   
        foreach (GridViewRow row in bankgrid.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
            if (chk.Checked == true)
            {
                int i = row.RowIndex;
                Label empN = (Label)bankgrid.Rows[i].FindControl("lblEmpName");
                Label acNo = (Label)bankgrid.Rows[i].FindControl("lblACName");
                Label bName = (Label)bankgrid.Rows[i].FindControl("lblTotAmount");

                DataRow dr = dt.NewRow();
                dr["empname"] = Convert.ToString(empN.Text.Trim());
                dr["acno"] = Convert.ToString(acNo.Text.Trim());
                dr["totamount"] = Convert.ToString(bName.Text.Trim());
                dr["bankname"] = Convert.ToString(ddl_bank_name.SelectedItem.ToString());
                dr["month"] = Convert.ToString(ddlmonth.SelectedItem.ToString());
                dt.Rows.Add(dr);
            }
        }
        GridView GridView1 = new GridView();
        GridView1.DataSource = dt;
        GridView1.DataBind();

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

        GridView1.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void lnkResign_Click(object sender, EventArgs e)
    {
        bindgridRse();
    }
    //=======================Bind Resigned Employee=================
    protected void bindgridRse()
    {
        lblbankname.Text = "";
        //============================================================================================================================
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex == 1)
        {
            SqlParameter[] sqlparm = new SqlParameter[4];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();
            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_bank_leavEmp]");
        }
        //====paytype check  of salary=========================================================
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";
            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement]");

        }
        //====paytype cash  of salary==========================================================
        if (ddl_reimbursement_type.SelectedIndex == 0 && Ddldisbursementtype.SelectedIndex == 3)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";
            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement]");
        }
        //====paytype Bank of reimbursement ==================================================
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 1)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_reimbursement]");
        }
        //====paytype check of reimbursement=================================================== 
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement_reimbursement]");
        }
        //====paytype cash of reimbursement====================================================
        if (ddl_reimbursement_type.SelectedIndex == 1 && Ddldisbursementtype.SelectedIndex == 3)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_cashchequestatement_reimbursement]");
        }
        //====paytype Bank of bonus============================================================
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 1)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
            sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";

            ds = Bindgriddatafordisbursement(sqlparm, "[sp_payroll_bankstatement_bonus]");
        }
        //====paytype Check of bonus============================================================
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 2)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 1;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "NONRESIGNEDCHECKCASH";

            ds = Bindgriddatafordisbursement(sqlparm, "[SP_PAYROLL_CHECKCASHSTATEMENT_BONUS]");

        }
        //====paytype Cash of bonus============================================================= 
        if (ddl_reimbursement_type.SelectedIndex == 2 && Ddldisbursementtype.SelectedIndex == 3)
        {
            SqlParameter[] sqlparm = new SqlParameter[5];

            sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
            sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
            sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

            sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
            sqlparm[2].Value = "1";

            sqlparm[3] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 25);
            sqlparm[3].Value = 2;

            sqlparm[4] = new SqlParameter("@TYPE", SqlDbType.VarChar, 25);
            sqlparm[4].Value = "RESIGNED";

            ds = Bindgriddatafordisbursement(sqlparm, "[SP_PAYROLL_CHECKCASHSTATEMENT_BONUS]");

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            bankgrid.DataSource = ds;
            bankgrid.DataBind();
            transactioncommentssection.Visible = true;
        }
        else
        {
            bankgrid.DataSource = ds;
            bankgrid.DataBind();
            transactioncommentssection.Visible = false;
        }
        if (Ddldisbursementtype.SelectedIndex == 1)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbankname.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            }
            else
            {
                if (ddl_bank_name.SelectedIndex != 0)
                {
                    lblbankname.Text = ddl_bank_name.SelectedItem.Text.ToString();
                }
                else
                {
                    General.Alert("Please choose bank name!", lnkResign);
                    ddl_bank_name.Focus();

                }
            }
            lblmonth.Text = "Bank-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }
        if (Ddldisbursementtype.SelectedIndex == 2)
        {
            lblmonth.Text = "Check-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }
        if (Ddldisbursementtype.SelectedIndex == 3)
        {
            lblmonth.Text = "Cash-(" + ddlmonth.SelectedItem.Text.Trim().ToString() + '/' + dd_year.SelectedItem.Text.Trim().ToString() + ")";
        }

        //foreach (GridViewRow row in bankgrid.Rows)
        //{
        //    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
        //    if (chk.Checked == true)
        //    {
        //        chk.Checked = false;
        //    }
        //}
    }
    //==============================================================
    protected void BtnDeliversal_Click(object sender, EventArgs e)
    {
        string disbursementstaus = string.Empty;
        string flag = string.Empty;
        string Empcode = string.Empty;
        int totalamount = 0;
        if (Ddldisbursementtype.SelectedIndex != 2)
        {
            foreach (GridViewRow gvrow in bankgrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                Label amnt = (Label)gvrow.FindControl("lblTotAmount");
                if (chk != null & chk.Checked)
                {
                    int j = gvrow.RowIndex;
                    Label empCode = (Label)bankgrid.Rows[j].FindControl("lblEmpCode");
                    if (Empcode.Length == 0)
                    {
                        Empcode = empCode.Text;
                    }
                    else
                    {
                        Empcode = Empcode + '-' + empCode.Text;
                    }
                   disbursementstaus = "Bankcash";
                   totalamount = totalamount + Convert.ToInt32(Convert.ToDecimal(amnt.Text));
                }
            }
            flag = "BC";
        }
        else
        {
            foreach (GridViewRow gvrow in bankgrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                Label amnt = (Label)gvrow.FindControl("lblTotAmount");
                TextBox Txtchkno = (TextBox)gvrow.FindControl("Txtcheckno");
                if (chk != null && chk.Checked)
                {
                    int j = gvrow.RowIndex;
                    Label empCode = (Label)bankgrid.Rows[j].FindControl("lblEmpCode");
                    if(Txtchkno.Text!="")
                    {
                        if (Empcode.Length == 0)
                        {
                            Empcode = empCode.Text + ":" + Txtchkno.Text;
                        }
                        else
                        {
                            Empcode = Empcode + '-' + empCode.Text + ":" + Txtchkno.Text;
                        }
                       
                    }
                    else
                    {
                        if (Empcode.Length == 0)
                        {
                            Empcode = empCode.Text + ":" + null;
                        }
                        else
                        {
                            Empcode = Empcode + '-' + empCode.Text + ":" + null;
                        }
                    }
                    disbursementstaus = "Check";
                    totalamount = totalamount +Convert.ToInt32(Convert.ToDecimal(amnt.Text));
                }
            }
            flag = "CH";
        }
        if (flag == "BC" && string.IsNullOrEmpty(disbursementstaus))
        {
            General.Alert("Please select at least one Employee!!", BtnDeliversal);
            return;
        }
        if (flag == "CH" && (string.IsNullOrEmpty(disbursementstaus)))  //|| Chcknoblank==true))
        {
            General.Alert("Please select at least one Employee!!", BtnDeliversal);
            return;
        }
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[9];
        sqlparam[0] = new SqlParameter("@TRANSACTIONNAME", SqlDbType.VarChar, 2000);
        sqlparam[0].Value = Txttransactiondetails.Text;

        sqlparam[1] = new SqlParameter("@DISBURSEMENTTYPE", SqlDbType.VarChar, 10);
        sqlparam[1].Value = Convert.ToInt32(Ddldisbursementtype.SelectedValue);

        sqlparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar, 20);
        sqlparam[2].Value = ddl_reimbursement_type.SelectedItem.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@EMPLIST", SqlDbType.VarChar, 3000);
        sqlparam[3].Value = Empcode;

        sqlparam[4] = new SqlParameter("@MONTH", SqlDbType.VarChar, 10);
        sqlparam[4].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

        sqlparam[5] = new SqlParameter("@YEAR", SqlDbType.VarChar, 10);
        sqlparam[5].Value = dd_year.SelectedItem.Text.Trim().ToString();

        sqlparam[6] = new SqlParameter("@USERID", SqlDbType.VarChar, 10);
        sqlparam[6].Value = Session["EmpCode"].ToString();

        sqlparam[7] = new SqlParameter("@TOTALAMOUNT", SqlDbType.Int);
        sqlparam[7].Value = totalamount;

        sqlparam[8] = new SqlParameter("@BANKNAME", SqlDbType.VarChar,25);
        if (Ddldisbursementtype.SelectedIndex == 1)
        {
            sqlparam[8].Value = ddl_bank_name.SelectedItem.Text;
        }
        else
        {
            sqlparam[8].Value = "N.A";
        }
        int Recordsupdated = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "SAL_PAY_EMPLOYEE", sqlparam));
        General.Alert("Transaction has been completed successfully!!", BtnDeliversal);
        Response.Redirect("Viewpaymenttransactiondetails.aspx");
        clear();
        Refreshcontent();
           
    }
    private void  Refreshcontent()
    {
       
        bankgrid.DataSource = null;
        bankgrid.DataBind();
        transactioncommentssection.Visible = false;
        lblmonth.Text = "";
        lblbankname.Text = "";
    }
   
    protected void bankgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        bankgrid.Columns[2].Visible = true;
        bankgrid.Columns[3].Visible = true;
        if(Ddldisbursementtype.SelectedIndex==1)
        {
            bankgrid.Columns[3].Visible = false;
        }
        if(Ddldisbursementtype.SelectedIndex==2)
        {
            bankgrid.Columns[2].Visible = false;
        }
        if (Ddldisbursementtype.SelectedIndex ==3)
        {
            bankgrid.Columns[2].Visible = false;
            bankgrid.Columns[3].Visible = false;
        }
    }

    protected void btnviewtransaction_Click(object sender, EventArgs e)
    {
        Response.Redirect("Viewpaymenttransactiondetails.aspx");
    }
}
