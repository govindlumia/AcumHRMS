using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity.TimeSheet;
using HRMS.BusinessLogic.TimeSheet;
using System.Data;

public partial class TimeSheet_Admin_ActivityWiseReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDDL();
        }
    }

    private void bindDDL()
    {
        ReportsBussiness balObj = new ReportsBussiness();
        DataTable dt_result = balObj.getProjectList();
        ddl_project.DataSource = dt_result;
        ddl_project.DataValueField = "ID";
        ddl_project.DataTextField = "projectname";
        ListItem item = new ListItem("--Select Project--", "0");
        ddl_project.DataBind();
        ddl_project.Items.Insert(0, item);

    }

    protected void btn_view_Click(object sender, EventArgs e)
    {
        ReportsENT domObj = new ReportsENT();
        ReportsBussiness balObj = new ReportsBussiness();
        domObj.projectID = Convert.ToInt32(ddl_project.SelectedValue);
        if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
        {
            domObj.fromDate = DateTime.ParseExact(txt_frmdate.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            domObj.toDate = DateTime.ParseExact(txt_to_date.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
        }
        if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
        {
            domObj.fromDate = DateTime.ParseExact(txt_frmdate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            domObj.toDate = DateTime.ParseExact(txt_to_date.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }

        domObj.isApproveCheck = chk_Isapprove.Checked ? true : false;
        domObj.User = Session["EmpCode"].ToString();
        DataSet ds_result = balObj.getProjectReportDateWise(domObj);
        if (ds_result.Tables.Count == 2)
        {
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            foreach (DataRow _dr in ds_result.Tables[0].Rows)
            {
                dicList.Add(_dr["ActivityCode"].ToString(), _dr["ActivityName"].ToString());
            }
            if (ds_result.Tables[1].Rows.Count > 0)
            {
                ds_result.Tables[1].Columns.Add(new DataColumn("Total"));

                foreach (DataRow _dr in ds_result.Tables[1].Rows)
                {
                    decimal total = 0;
                    for (int i = 2; i <= ds_result.Tables[1].Columns.Count - 2; i++)
                    {
                        total += Convert.ToDecimal(_dr[i]);
                    }
                    _dr["Total"] = total;
                }
                DataRow newrow = ds_result.Tables[1].NewRow();
                ds_result.Tables[1].Rows.Add(newrow);
                newrow[1] = "Total";
               
                foreach (DataColumn _newdc in ds_result.Tables[1].Columns)
                {

                    for (int i = 2; i <= ds_result.Tables[1].Columns.Count - 1; i++)
                    {
                        decimal _newTotal = 0;
                        for (int j = 0; j <= ds_result.Tables[1].Rows.Count - 2; j++)
                        {
                            _newTotal += Convert.ToDecimal(ds_result.Tables[1].Rows[j][i]);
                        
                        }
                        ds_result.Tables[1].Rows[ds_result.Tables[1].Rows.Count - 1][i] = _newTotal;
                    }

                }

                ds_result.Tables[1].Columns[0].ColumnName = "Employee Code";
                ds_result.Tables[1].Columns[1].ColumnName = "Employee Name";
                foreach (DataColumn dc in ds_result.Tables[1].Columns)
                {
                    if (dc.Ordinal > 1)
                    {
                        if (dicList.ContainsKey(dc.ColumnName.Trim()))
                        {
                            dc.ColumnName = dicList[dc.ColumnName.Trim()];
                        }
                    }
                }
                grd_report.DataSource = ds_result.Tables[1];
                grd_report.DataBind();
            }
            else
            {
                grd_report.DataSource = null;
                grd_report.DataBind();
            }
        }

    }
}