using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class payroll_admin_ViewFNFInfo : System.Web.UI.Page
{
    string sqlstr;
    SqlParameter[] sqlparm;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Bindfnfvieweditgrid();
        }
    }

    private void Bindfnfvieweditgrid()
    {
        sqlstr = @"SELECT DISTINCT CAST(TBL_FNF.EMPCODE AS VARCHAR(20))+'-'+TBL_INTRANET_EMPLOYEE_JOBDETAILS.EMP_FNAME AS EMPNAME,TBL_FNF.EMPCODE,TBL_FNF.DATE_OF_FNF,TBL_FNF.INCLUDE_ONHOLD_SALARY,TBL_FNF.TOTAL_WORKINDAYS,TBL_FNF.BANKNAME,TBL_FNF.TOTAL_EARNINGS,TBL_FNF.TOTAL_DEDUCTIONS,TBL_FNF.TOTAL_PAY,TBL_FNF.REIMBURSEMENT_TYPE FROM TBL_FNF INNER JOIN TBL_INTRANET_EMPLOYEE_JOBDETAILS ON TBL_INTRANET_EMPLOYEE_JOBDETAILS.EMPCODE=TBL_FNF.EMPCODE";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if(ds.Tables[0].Rows.Count!=0)
        {
            Gridviewviewfnfinfo.DataSource = ds.Tables[0];
            Gridviewviewfnfinfo.DataBind();
        }
    }
    protected void Gridviewviewfnfinfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
        }
    }
    protected void Gridviewviewfnfinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = Gridviewviewfnfinfo.Rows[rowIndex];
        string Empcode = row.Cells[0].Text.Split('-')[0];
        string Dateoffnf = row.Cells[1].Text;
        string holdsal = row.Cells[2].Text;
        string workingdays = row.Cells[3].Text;
        string bankname = row.Cells[4].Text;
        string totalearnings = String.Format("{0:#,##0.##}", Convert.ToDouble(row.Cells[5].Text));
        string totaldeductions = String.Format("{0:#,##0.##}", Convert.ToDouble(row.Cells[6].Text));
        string netpay = String.Format("{0:#,##0.##}", Convert.ToDouble(row.Cells[7].Text));
        string paytype = (row.Cells[8].Text); 
      
        if (e.CommandName == "View Fnf Info")
        {
             string redirecturl = "/payroll/Onlyviewfnf.aspx?Empcodeviewfnf=" + Empcode + "&DATE_OF_FNF=" + Dateoffnf + "&onholdsalary=" + holdsal + "&workingdays=" + workingdays + "&bankname=" + bankname + "&TOTAL_EARNINGS=" + totalearnings + "&TOTAL_DEDUCTIONS=" + totaldeductions + "&TOTAL_PAY=" + netpay + "&REIMBURSEMENT_TYPE=" + paytype;
             ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + redirecturl + "');", true);
        }
        if (e.CommandName == "Edit Info")
        {
            string redirecturl = "/payroll/admin/FullandFinalEmployee.aspx?Empcodeeditfnf=" + Empcode + "&DATE_OF_FNF=" + Dateoffnf + "&onholdsalary=" + holdsal + "&workingdays=" + workingdays + "&bankname=" + bankname + "&TOTAL_EARNINGS=" + totalearnings + "&TOTAL_DEDUCTIONS=" + totaldeductions + "&TOTAL_PAY=" + netpay + "&REIMBURSEMENT_TYPE=" + paytype;
            Response.Redirect(redirecturl);
        }


    }
}