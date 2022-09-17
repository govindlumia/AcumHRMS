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
using System.Text;

public partial class payroll_admin_Viewpaymenttransactiondetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string strquery=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            bindtransactiongrid();
        }

    }
    private void bindtransactiongrid()
    {
        strquery = @"SELECT ID,TRANSACTION_REF_ID,TRANSACTIONNAME,TYPE,MONTH,YEAR,CREATEDATE,MODIFIEDDATE,CREATEDBY,(CASE WHEN DISBURSEMENTTYPE='1' THEN 'Bank' WHEN DISBURSEMENTTYPE='2' THEN 'Cheque' WHEN DISBURSEMENTTYPE='3' THEN 'Cash' END) AS DISBURSEMENTTYPE,TOTALAMOUNT FROM TBL_PAYMENT_TRANSACTION_TABLE ORDER BY 1 DESC";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strquery);
        Viewtransactiongrid.DataSource = ds;
        Viewtransactiongrid.DataBind();
    }
    protected void Viewtransactiongrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Viewtransactiongrid.PageIndex = e.NewPageIndex;
        bindtransactiongrid();
    }
   
    protected void btn_search_Click(object sender, EventArgs e)
    {
        string disbursmentid = Ddlpaytype.SelectedIndex == 0 ? null : Ddlpaytype.SelectedIndex.ToString();
        string monthname = Ddlmonth.SelectedIndex == 0 ? null : Ddlmonth.SelectedItem.Text;
        string yearname = ddlfinancialyear.SelectedIndex == 0 ? null : ddlfinancialyear.SelectedItem.Text;
        if (disbursmentid == null && monthname == null && yearname == null)
        {
            bindtransactiongrid();
        }
        else
        {
            SqlParameter[] sqlparm = new SqlParameter[3];
            sqlparm[0] = new SqlParameter("@DISBURSEMENTTYPE", SqlDbType.VarChar, 25);
            sqlparm[0].Value = disbursmentid;
            sqlparm[1] = new SqlParameter("@MONTH", SqlDbType.VarChar, 25);
            sqlparm[1].Value = monthname;
            sqlparm[2] = new SqlParameter("@YEAR", SqlDbType.VarChar, 25);
            sqlparm[2].Value = yearname;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_FILTER_TANSACTION]", sqlparm);
            Viewtransactiongrid.DataSource = ds.Tables[0];
            Viewtransactiongrid.DataBind();
        }
    }
    protected void ddlfinancialyear_DataBound(object sender, EventArgs e)
    {
        ddlfinancialyear.Items.Insert(0, new ListItem("Select Financial Year", "0"));
    }
    protected void Viewtransactiongrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = Viewtransactiongrid.Rows[rowIndex];
        Label lbltransactionid = (Label)row.FindControl("lbltransactioid");
        Label lbltotalamount = (Label)row.FindControl("LBLTOTALAMOUNT");
        if (e.CommandName == "Edit Info")
        {
            string redirecturl = "/payroll/admin/Edittransactionofemployeesalary.aspx?Transactionid=" + lbltransactionid.Text;
            Response.Redirect(redirecturl);
        }
        if (e.CommandName == "Bank Letter")
        {
            bindExcelsheeet(Convert.ToInt32(lbltransactionid.Text));
        }
        if (e.CommandName == "Cover Letter")
        {
            MsWordCoverLetter.Getcoverletter(lbltotalamount.Text,"Rajeev");
        }
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
    protected void Viewtransactiongrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbltransactionid = (Label)e.Row.FindControl("LBLDISBURSEMENTTYPE");
            Button Bankletter = (Button)e.Row.Cells[7].Controls[0];
            Button Coverletter = (Button)e.Row.Cells[8].Controls[0];
            if(lbltransactionid.Text !="Bank")
            {
                Bankletter.Visible = false;
                Coverletter.Visible = false;
            }
            else
            {
                Bankletter.Visible = true;
                Coverletter.Visible = true;
            }
          
        }   
    }
}