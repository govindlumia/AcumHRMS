using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using HRMS.BusinessLogic.TimeSheet;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;

public partial class TimeSheet_User_ProjectReportForRM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_fromdate.Attributes.Add("readonly", "readonly");
        txt_todate.Attributes.Add("readonly", "readonly");
        txt_employee.Attributes.Add("readonly", "readonly");
        if (Session["EmpCode"] == null)
      
    //      ACE_txt_employee.ContextKey = Session["EmpCode"].ToString();
       // else
            Response.Redirect("~/notlogged.aspx", false);
    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_fromdate.Text.Trim()) || string.IsNullOrEmpty(txt_todate.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nodatefill", "alert('From/To dates must not blank');", true);
            return;
        }
        DateTime fromDate = new DateTime();
        DateTime toDate = new DateTime();
        //if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("/"))
        //{
        //    fromDate = DateTime.ParseExact(txt_fromdate.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
        //    toDate = DateTime.ParseExact(txt_todate.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
        //}
        //else if (CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator.Equals("-"))
        //{
            fromDate = DateTime.ParseExact(txt_fromdate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            toDate = DateTime.ParseExact(txt_todate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
       // }
        if (fromDate >= toDate)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "dategreater", "alert('From date must be less than to date');", true);
            return;
        }

        ReportsBussiness balObj = new ReportsBussiness();
        DataTable dt_result = balObj.projectReportForRM(txt_employee.Text.Trim(),Session["EmpCode"].ToString(), chk_Isapprove.Checked ? true : false,fromDate,toDate,chk_past_emp.Checked);
        if (dt_result.Rows.Count > 0)
        {
          
             if (dt_result.Rows[0][0].Equals("No Employee"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "noemp", "alert('No Employee with this Name');", true);
                txt_employee.Text = "";
                return;
            }
            else
            {
                List<string> projectList = new List<string>();
                var disctinctProject = (from row in dt_result.AsEnumerable()
                                        select row.Field<string>("ProjectName")).Distinct().ToArray();
                DataTable dt_new_forPro = new DataTable();
                dt_new_forPro.Columns.Add(new DataColumn("EmpName/Project"));

                var distinct_emp = (from row in dt_result.AsEnumerable()
                                    select row.Field<string>("Empcode")).Distinct().ToArray();
                foreach (var empcode in distinct_emp)
                {
                    decimal empTotal = 0;
                    DataRow dr = dt_new_forPro.NewRow(); ;
                    foreach (var proName in disctinctProject)
                    {
                        decimal total = 0;
                        if (!projectList.Contains(proName.ToString()))
                        {
                            dt_new_forPro.Columns.Add(new DataColumn(proName));
                        }
                        projectList.Add(proName);

                        DataRow[] _rows = dt_result.Select("Empcode='" + empcode + "' and ProjectName='" + proName + "'");
                        if (_rows.Length > 0)
                        {
                            DataTable dt_new = dt_result.Select("Empcode='" + empcode + "' and ProjectName='" + proName + "'").CopyToDataTable();
                            foreach (DataRow _dr in dt_new.Rows)
                            {
                                total += Convert.ToDecimal(_dr["MonTime"]) + Convert.ToDecimal(_dr["TuesTime"]) + Convert.ToDecimal(_dr["WedTime"]) + Convert.ToDecimal(_dr["ThurTime"]) + Convert.ToDecimal(_dr["FriTime"]) + Convert.ToDecimal(_dr["SatTime"]) + Convert.ToDecimal(_dr["SunTime"]);

                            }
                            dr["EmpName/Project"] = balObj.getEmployeeName(empcode);
                            dr[proName] = total.ToString();
                            empTotal += total;
                        }
                        else
                        {
                            dr["EmpName/Project"] = balObj.getEmployeeName(empcode);
                            dr[proName] = total.ToString();
                            empTotal += total;
                        }

                    }
                    if (!dt_new_forPro.Columns.Contains("Total"))
                        dt_new_forPro.Columns.Add(new DataColumn("Total"));
                    dr["Total"] = empTotal;
                    dt_new_forPro.Rows.Add(dr);
                }

                DataRow _dr_new_forpro = dt_new_forPro.NewRow();
                dt_new_forPro.Rows.Add(_dr_new_forpro);
                _dr_new_forpro[0] = "Total";

                foreach (DataColumn _newdc in dt_new_forPro.Columns)
                {

                    for (int i = 1; i <= dt_new_forPro.Columns.Count - 1; i++)
                    {
                        decimal _newTotal = 0;
                        for (int j = 0; j <= dt_new_forPro.Rows.Count - 2; j++)
                        {
                            _newTotal += Convert.ToDecimal(dt_new_forPro.Rows[j][i]);

                        }
                        dt_new_forPro.Rows[dt_new_forPro.Rows.Count - 1][i] = _newTotal;
                    }

                }
                ViewState["dataForGrid"] = dt_new_forPro;
                grd_report.DataSource = dt_new_forPro;
                grd_report.DataBind();

            }
        }
        else
        {
            grd_report.DataSource = null;
            grd_report.DataBind();
        }
    }
    protected void grd_report_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_report.PageIndex = e.NewPageIndex;
        bindGrid();
    }
    private void bindGrid()
    {
        if (ViewState["dataForGrid"] != null)
        {
            grd_report.DataSource = (DataTable)ViewState["dataForGrid"];
            grd_report.DataBind();
        }
    }
    [System.Web.Script.Services.ScriptMethod()]

    [System.Web.Services.WebMethod]
    public static List<string> AutoComplete_Employee_For_RM(string prefixText, int count, string contextKey)
    {
        ReportsBussiness balObj = new ReportsBussiness();

        DataTable dt = balObj.getEmployeeListforRM(prefixText,contextKey);

        List<string> employeeList = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            employeeList.Add(dt.Rows[i][0].ToString());

        }
        return employeeList;
    }

    private void exportToExcel(object file)
    {
        Response.Clear();

        Response.Buffer = true;

        this.EnableViewState = false;

        string attachment = "attachment;   filename=ProjectReportForRM.xls";

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        HtmlForm frm = new HtmlForm();

        HomePage.Parent.Controls.Add(frm);

        frm.Attributes["runat"] = "server";

        frm.Controls.Add((Table)file);

        frm.RenderControl(htw);

        string style = @"<style> .textmode { mso-number-format:\@; } img{width:100px;height:60px;} </style>";
        Response.Write(style);
        Response.Write(sw.ToString());

        Response.End();
    
    }



    protected void btn_export_excel_Click(object sender, EventArgs e)
    {
        TableCell cell1;
        TableCell cell2;
        TableRow row;
        Table table_toexport = new Table();
        table_toexport.Style["font-size"] = "10";
        table_toexport.BorderWidth = Unit.Pixel(1);
        table_toexport.BorderColor = Color.Green;
        table_toexport.GridLines = GridLines.Both;
        Label lbl_data;
        DataTable dt_result = (DataTable)(ViewState["dataForGrid"]);
        if (grd_report.Rows.Count > 0)
        {
            row = new TableRow();
            cell1 = new TableCell();
            cell1.Width = Unit.Point(100);
            cell1.Height = Unit.Point(60);
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = Server.MapPath("~") + "\\images\\Rossel-Techsys-Logo1(1).png";
            //img.Style["width"] = "100";
            //img.Style["height"] = "60";
            
            cell1.Controls.Add(img);
            cell2 = new TableCell();
            cell2.Style["text-align"] = "center";
            cell2.Width = Unit.Pixel(700);
            cell2.ColumnSpan = dt_result.Columns.Count-1;
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(20);
            lbl_data.Font.Bold = true;
            lbl_data.Text = "Acuminous Software";
            cell2.Controls.Add(lbl_data);
            cell1.RowSpan = 3;
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);
            row = new TableRow();
            cell2 = new TableCell();
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(8);
            lbl_data.Font.Bold = true;
            lbl_data.Text = "Division of Rossell India Ltd";
            cell2.Controls.Add(lbl_data);
            cell2.Style["text-align"] = "center";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);
            row = new TableRow();
            cell2 = new TableCell();
            lbl_data = new Label();
            lbl_data.Font.Name = "Verdana";
            lbl_data.Font.Size = FontUnit.Point(7);
            lbl_data.Font.Bold = false;
            lbl_data.Text = " No.74, 3rd Cross, Export Promotion Industrial Park,Whitefield, BANGALORE - 560 066, Ph: 080-3999 9401";
            cell2.Controls.Add(lbl_data);
            cell2.Style["text-align"] = "center";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);
            table_toexport.Rows.Add(row);

            row = new TableRow();
            cell1 = new TableCell();
            cell2 = new TableCell();
            cell1.Text = "Report Date";
            cell2.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            cell2.Style["text-align"] = "left";
            row.Cells.Add(cell1);
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell2);
           
            table_toexport.Rows.Add(row);

            row = new TableRow();
            cell1 = new TableCell();
            cell2 = new TableCell();
            cell1.Text = "Report Name";
            cell2.Text = "Project Report For Reporting Manager";
            cell2.Style["text-align"] = "left";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            table_toexport.Rows.Add(row);
            row = new TableRow();

            foreach(TableCell tc in  grd_report.HeaderRow.Cells)
            {

                cell1 = new TableCell();
                cell1.BackColor = Color.Yellow;
                cell1.Text = tc.Text;
                cell1.Style["text-align"] = "center";
                row.Cells.Add(cell1);
            }
            table_toexport.Rows.Add(row);
           
            foreach (DataRow dr in (dt_result.Rows))
            {
                row = new TableRow();
                for (int i = 0; i < dt_result.Columns.Count;i++ )
                {
                    cell1 = new TableCell();
                    cell1.Text = dr[i].ToString();
                    cell1.Style["text-align"] = "center";
                    row.Cells.Add(cell1);
                }
                table_toexport.Rows.Add(row);
            }
            exportToExcel(table_toexport);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nodata", "alert('No Data to export in excel');", true);
        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_employee.Text = "";
        txt_fromdate.Text = "";
        txt_todate.Text = "";
        chk_Isapprove.Checked = false;
        chk_past_emp.Checked = false;
        grd_report.DataSource = null;
        grd_report.DataBind();
    }
}