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

public partial class payroll_admin_Edittransactionofemployeesalary : System.Web.UI.Page
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
            bindeditpageinfo();
        }
    }
    private void bindeditpageinfo()
    {
        SqlParameter[] sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@TRANSACTIONID", SqlDbType.VarChar, 25);
        sqlparm[0].Value = Request.QueryString["Transactionid"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_GET_PAYMENTDETAILS_EDIT]", sqlparm);
        if(ds.Tables[0].Rows.Count!=0 && ds.Tables[1].Rows.Count!=0)
        {
            Lblmonthh.Text = ds.Tables[1].Rows[0]["MONTH"].ToString();
            lblyear.Text = ds.Tables[1].Rows[0]["YEAR"].ToString();
            Lbldisbursementtype.Text = ds.Tables[1].Rows[0]["DISBURSEMENTTYPE"].ToString();
            lblamountpaytype.Text=ds.Tables[1].Rows[0]["TYPE"].ToString();
            Txttransactiodetails.Text = ds.Tables[1].Rows[0]["TRANSACTIONAME"].ToString();
            if(Lbldisbursementtype.Text !="Bank")
            {
                lblbanknamme.Text = "N.A";              
                btnbankcoverletter.Visible = false;
                btnbankletter.Visible = false;
            }
            else
            {
                lblbanknamme.Text = ds.Tables[1].Rows[0]["BANKNAME"].ToString();
                lblbankname.Text = ds.Tables[1].Rows[0]["BANKNAME"].ToString();
                btnbankcoverletter.Visible = true;
                btnbankletter.Visible = true;
            }
            if (Lbldisbursementtype.Text == "Cheque")
            {
                lblbankname.Text = "Cheque";
            }
            if (Lbldisbursementtype.Text == "Cash")
            {
                lblbankname.Text = "Cash";
            }
            lblmonth.Text = ds.Tables[1].Rows[0]["MONTH"].ToString();
            bindeditablegridview(ds.Tables[0]);
            lbltotalamountpaid.Text = ds.Tables[1].Rows[0]["TOTALAMOUNT"].ToString();
        }
    }
    private void bindeditablegridview(DataTable dt)
    {
        if (Lbldisbursementtype.Text != "Cheque")
        {
            System.Data.DataColumn newColumn = new System.Data.DataColumn("ChequeNo", typeof(System.String));
            newColumn.DefaultValue = "123456123456";
            dt.Columns.Add(newColumn);
        }
        Editbankgrid.DataSource = dt;
        Editbankgrid.DataBind(); 
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string disbursementstaus = string.Empty;
        int count = 0;
        string flag = string.Empty;
        string EmpcodeAdd = string.Empty;
        string EmpcodeDelete = string.Empty;
        int totalamount = Convert.ToInt32(lbltotalamountpaid.Text);
        int disbrsetype=0;
        if(Lbldisbursementtype.Text=="Bank")
        {
            disbrsetype=1;
        }
        if(Lbldisbursementtype.Text=="Cheque")
        {
            disbrsetype=2;
        }
        if(Lbldisbursementtype.Text=="Cash")
        {
            disbrsetype=3;
        }
        if (Lbldisbursementtype.Text != "Cheque")
        {
            foreach (GridViewRow gvrow in Editbankgrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                Label amnt = (Label)gvrow.FindControl("lblTotAmount");
                if (chk != null & chk.Checked==false)
                {
                    int j = gvrow.RowIndex;
                    Label empCode = (Label)Editbankgrid.Rows[j].FindControl("lblEmpCode");
                    if (EmpcodeDelete.Length == 0)
                    {
                        EmpcodeDelete = empCode.Text;
                    }
                    else
                    {
                        EmpcodeDelete = EmpcodeDelete + '-' + empCode.Text;
                    }
                    totalamount = totalamount - Convert.ToInt32(Convert.ToDecimal(amnt.Text));
                }
                if (chk != null & chk.Checked == true)
                {
                    count++;
                }
            }
            flag = "BC";
        }
        else
        {
            foreach (GridViewRow gvrow in Editbankgrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                Label amnt = (Label)gvrow.FindControl("lblTotAmount");
                TextBox Txtchkno = (TextBox)gvrow.FindControl("Txtcheckno");
                if (chk != null && chk.Checked)
                {
                    int j = gvrow.RowIndex;
                    Label empCode = (Label)Editbankgrid.Rows[j].FindControl("lblEmpCode");
                    if (Txtchkno.Text != "")
                    {
                        if (EmpcodeAdd.Length == 0)
                        {
                            EmpcodeAdd = empCode.Text + ":" + Txtchkno.Text;
                        }
                        else
                        {
                            EmpcodeAdd = EmpcodeAdd + '-' + empCode.Text + ":" + Txtchkno.Text;
                        }

                    }
                    else
                    {
                        if (EmpcodeAdd.Length == 0)
                        {
                            EmpcodeAdd = empCode.Text + ":" + null;
                        }
                        else
                        {
                            EmpcodeAdd = EmpcodeAdd + '-' + empCode.Text + ":" + null;
                        }
                    }
                    disbursementstaus = "updatecheckno";
                }
                if (chk != null & chk.Checked == false)
                {
                    int j = gvrow.RowIndex;
                    Label empCode = (Label)Editbankgrid.Rows[j].FindControl("lblEmpCode");
                    if (EmpcodeDelete.Length == 0)
                    {
                        EmpcodeDelete = empCode.Text + ":" + null;
                    }
                    else
                    {
                        EmpcodeDelete = EmpcodeDelete + '-' + empCode.Text + ":" + null;
                    }
                    disbursementstaus = "deleteemp";
                    totalamount = totalamount - Convert.ToInt32(Convert.ToDecimal(amnt.Text));
                }
            }
            flag = "CH";
        }
        int flagg = 0;
        if (flag == "BC" && Editbankgrid.Rows.Count==count)
        {
            //======================Only update transaction name and modified date========
            sqlstr = @"update Tbl_Payment_Transaction_Table set TransactionName='" + Txttransactiodetails.Text + "',ModifiedDate=GETDATE() where Id='"+ Request.QueryString["Transactionid"].ToString()+ "'";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            flagg=1;
        }
        if (flag == "CH" && disbursementstaus=="updatecheckno")  //|| Chcknoblank==true))
        {
            //=====================Only update transaction name,modified date,check number=========
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@TRANSACTIONNAME", SqlDbType.VarChar, 3000);
            sqlparam[0].Value = Txttransactiodetails.Text;

            sqlparam[1] = new SqlParameter("@TYPE", SqlDbType.VarChar, 20);
            sqlparam[1].Value = lblamountpaytype.Text.Trim().ToString();

            sqlparam[2] = new SqlParameter("@EMPLIST", SqlDbType.VarChar, 3000);
            sqlparam[2].Value = EmpcodeAdd;

            sqlparam[3] = new SqlParameter("@MONTH", SqlDbType.VarChar, 10);
            sqlparam[3].Value = Lblmonthh.Text.Trim().ToString();

            sqlparam[4] = new SqlParameter("@YEAR", SqlDbType.VarChar, 10);
            sqlparam[4].Value = lblyear.Text.Trim().ToString();

            sqlparam[5] = new SqlParameter("@TRANSACTIONID", SqlDbType.VarChar, 10);
            sqlparam[5].Value = Request.QueryString["Transactionid"].ToString();

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[SP_TOUPDATE_TRANSACTION_CHECKNUMBER]", sqlparam);
        }
        if (flagg == 0 && EmpcodeDelete.Length!=0)
        {
            updatetransactioninfo(disbrsetype, EmpcodeDelete, totalamount);
        }
        Response.Redirect("Viewpaymenttransactiondetails.aspx");
    }
    public void updatetransactioninfo(int disbursementtype,string employeelist,int totalamount)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[9];
        sqlparam[0] = new SqlParameter("@TRANSACTIONNAME", SqlDbType.VarChar, 2000);
        sqlparam[0].Value = Txttransactiodetails.Text;

        sqlparam[1] = new SqlParameter("@DISBURSEMENTTYPE", SqlDbType.Int);
        sqlparam[1].Value = disbursementtype;

        sqlparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar, 20);
        sqlparam[2].Value = lblamountpaytype.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@EMPLIST", SqlDbType.VarChar, 3000);
        sqlparam[3].Value = employeelist;

        sqlparam[4] = new SqlParameter("@MONTH", SqlDbType.VarChar, 10);
        sqlparam[4].Value = lblmonth.Text.Trim().ToString();

        sqlparam[5] = new SqlParameter("@YEAR", SqlDbType.VarChar, 10);
        sqlparam[5].Value = lblyear.Text.Trim().ToString();

        sqlparam[6] = new SqlParameter("@USERID", SqlDbType.VarChar, 10);
        sqlparam[6].Value = Session["EmpCode"].ToString();

        sqlparam[7] = new SqlParameter("@TOTALAMOUNT", SqlDbType.Int);
        sqlparam[7].Value = totalamount;

        sqlparam[8] = new SqlParameter("@TRANSACTIONID", SqlDbType.Int);
        sqlparam[8].Value =Convert.ToInt32(Request.QueryString["Transactionid"].ToString());
      
        int Recordsupdated = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[SAL_PAY_EMPLOYEE_UPDATE]", sqlparam));
        
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Viewpaymenttransactiondetails.aspx");

    }
    protected void btnbankletter_Click(object sender, EventArgs e)
    {
        bindExcelsheeet(Convert.ToInt32(Request.QueryString["Transactionid"].ToString()));
    }
    private void bindExcelsheeet(int transactionid)
    {
        SqlParameter[] sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@TRANSACTIONID", SqlDbType.VarChar, 25);
        sqlparm[0].Value = transactionid.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_GET_PAYMENTDETAILS_EDIT]", sqlparm);
        if (ds.Tables[0].Rows.Count != 0 && ds.Tables[1].Rows.Count != 0)
        {
            DataTable dt_result = ds.Tables[0];
            MailScript scriptObj = new MailScript();
            GridViewRow _row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell[] cells = new TableCell[3];
            cells[0] = new TableCell();
            cells[1] = new TableCell();
            cells[2] = new TableCell();
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
    }
    protected void Editbankgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Editbankgrid.PageIndex = e.NewPageIndex;
        //bindgrid();
    }
    protected void Editbankgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Editbankgrid.Columns[2].Visible = true;
        if (Lbldisbursementtype.Text == "Cheque")
        {
            Editbankgrid.Columns[2].Visible = true;
        }
        else
        {
            Editbankgrid.Columns[2].Visible = false;
        }
    }
    protected void btnbankcoverletter_Click(object sender, EventArgs e)
    {
        MsWordCoverLetter.Getcoverletter(lbltotalamountpaid.Text, "Rajeev");
    }
    protected void Btndeletetransaction_Click(object sender, EventArgs e)
    {
      if(lblamountpaytype.Text=="Salary")
      {
          sqlstr = @"DELETE FROM TBL_PAYMENT_TRANSACTION_TABLE WHERE ID='" + Request.QueryString["Transactionid"].ToString() + "';UPDATE TBL_PAYROLL_EMPLOYEE_SALARY SET IS_DELIVER_SAL=NULL,TRANSACTION_ID=NULL,CHECKNO=NULL WHERE TRANSACTION_ID='" + Request.QueryString["Transactionid"].ToString() + "' ";
          DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
      }
      if (lblamountpaytype.Text == "Reimbursement")
      {
          sqlstr = @"DELETE FROM TBL_PAYMENT_TRANSACTION_TABLE WHERE ID='" + Request.QueryString["Transactionid"].ToString() + "';UPDATE TBL_PAYROLL_EMPLOYEE_REIMBURSEMENT SET IS_DELIVER_REM=NULL,TRANSACTION_ID=NULL,CHECKNO=NULL WHERE TRANSACTION_ID='" + Request.QueryString["Transactionid"].ToString() + "' ";
          DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
      }
      if (lblamountpaytype.Text == "Bonus")
      {
          sqlstr = @"DELETE FROM TBL_PAYMENT_TRANSACTION_TABLE WHERE ID='" + Request.QueryString["Transactionid"].ToString() + "';UPDATE TBL_PAYROLL_EMPLOYEE_BONUS_DETAIL SET IS_DELIEVER_BONUS=NULL,TRANSACTION_ID=NULL,CHECKNO=NULL WHERE TRANSACTION_ID='" + Request.QueryString["Transactionid"].ToString() + "' ";
          DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
      }
      Response.Redirect("Viewpaymenttransactiondetails.aspx");
    }
}
