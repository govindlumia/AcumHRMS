using HRMS.BusinessEntity.Leave;
using HRMS.BusinessLogic.Leave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_ViewApplyOd : System.Web.UI.Page
{
    EmployeeLeaveStatusBAL employeeLeaveStatusBAL = new EmployeeLeaveStatusBAL();
    EmployeeLeaveStatus employeeLeaveStatus = new EmployeeLeaveStatus();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            var empcode = Session["empcode"].ToString();
            var btnval = 0;

            if(Request.QueryString["btnval"] == null || Request.QueryString["btnval"] == "")
            {
                btnval = 0;
            }

            else
            {
                btnval = Convert.ToInt32(Request.QueryString["btnval"]);
            }

            if ((Session["Role"].Equals("1") || Session["Role"].Equals("2")) || Session["Role"].Equals("3"))
            {
                if(btnval ==1)
                { 
                    List<EmployeeLeaveStatus> lst = employeeLeaveStatusBAL.readAllApplyOdAdmin();
                    //Added for converting list to datatable by keerti for exporting excel on 27 june 2018 
                    MailScript scriptOd = new MailScript();
                    DataTable table = scriptOd.ToDataTable(lst);
                    table.Columns.Remove("fromdate");
                    table.Columns.Remove("todate");
                    ViewState["RecordOd"] = table;
                    ImgExcel.Visible = true;
                    // changed upto here.....

                    grdviewEmpod.DataSource = lst;
                grdviewEmpod.DataBind();
                }
                else
                {
                    List<EmployeeLeaveStatus> lst = employeeLeaveStatusBAL.readAllApplyOd(empcode);
                    ImgExcel.Visible = false;

                    grdviewEmpod.DataSource = lst;
                    grdviewEmpod.DataBind();
                }
            }
            else
            {
                List<EmployeeLeaveStatus> lst = employeeLeaveStatusBAL.readAllApplyOd(empcode);
                ImgExcel.Visible = false;

                grdviewEmpod.DataSource = lst;
                grdviewEmpod.DataBind();
            }
               
            
        }
    }
    protected void BindLeaveDateType()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparam[0].Value = Session["empcode"].ToString();
    }

    #region Serch Record By Date
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    EmployeeLeaveStatus employeeLeaveStatus=new EmployeeLeaveStatus();
    //    List<EmployeeLeaveStatus> lstemployeeLeaveStatus = new List<EmployeeLeaveStatus>();
    //    employeeLeaveStatus.fromDate = Convert.ToDateTime(txt_Fromdate.Text);
    //    employeeLeaveStatus.todate = Convert.ToDateTime(txt_Todate.Text);
    //    employeeLeaveStatus.EmployeeCode= Session["empcode"].ToString();
    //    lstemployeeLeaveStatus=employeeLeaveStatusBAL.readApplyOdByDate(employeeLeaveStatus);
    //  grdviewEmpod.DataSource = lstemployeeLeaveStatus;
    //  grdviewEmpod.DataBind();
    //  clear();
    //}
    //public void clear()
    //{
    //    txt_Fromdate.Text = "";
    //    txt_Todate.Text = "";

    //}
    #endregion
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {


    }


    //Added by keerti for exporting excel on 27 june 2018 
    protected void ImgExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdviewEmpod.Rows.Count > 0)
            {
                ExportAllColumns();
                Reset();
                grdviewEmpod.DataSource = null;

            }
            else
                General.Alert("No Record(s) Found", ImgExcel);
        }
        catch (Exception ex)
        {

        }
    }

    public void ExportAllColumns()
    {
        try
        {

            DataTable dt = new DataTable();
            if (ViewState["RecordOd"] != null)
                dt = (DataTable)ViewState["RecordOd"];
            else
                dt = new DataTable();
            MailScript scriptObj = new MailScript();
            scriptObj.exportToExcelInCustomized(dt, grdviewEmpod.HeaderRow, "Employee OD Report", Page.Form, "OdRep");

        }
        catch (Exception ex)
        {

        }
    }

    protected void Reset()
    {

    }

    // Upto here..............

}
