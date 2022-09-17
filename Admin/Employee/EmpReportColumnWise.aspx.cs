using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.IO;

public partial class Admin_Employee_EmpReportColumnWise : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string columnname = string.Empty;
    public static bool cheked;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindcheckColumns();

            
        }
    }
    protected void bindcheckColumns()
    {
        CommonBusiness commonbAL = new CommonBusiness();
        DataTable dt = new DataTable();
        dt = commonbAL.Bindcolumnswithcheklist("Tbl_checkcolumns");

        checkcolumns.DataValueField = "column_name";
        checkcolumns.DataTextField = "column_name";

        checkcolumns.DataSource = dt;
        checkcolumns.DataBind();
    }
    public void chekdata()
    {

        try
        {

            for (int i = 0; i <= checkcolumns.Items.Count - 1; i++)
            {
                if (checkcolumns.Items[i].Selected == true)
                {

                    cheked = true;
                    break;


                }
                else
                {
                    cheked = false;

                }


            }

          


        }
        catch (Exception ex)
        {
        }
    }

    protected void exportexcel(DataTable dt)
    {
        TableCell cell1;
        TableCell cell2;
        TableRow row;
        Table table_toexport = new Table();
        table_toexport.Style["font-size"] = "10";
        table_toexport.BorderWidth = Unit.Pixel(1);
        table_toexport.BorderColor = System.Drawing.Color.Green;
        table_toexport.GridLines = GridLines.Both;
        Label lbl_data;
        DataTable dt_result = dt;

        row = new TableRow();
        cell1 = new TableCell();
        cell1.Width = Unit.Point(100);
        cell1.Height = Unit.Point(60);
        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
        img.ImageUrl = "~\\images\\Rossel-Techsys-Logo1(1).png";
        //img.Style["width"] = "100";
        //img.Style["height"] = "60";

        cell1.Controls.Add(img);
        cell2 = new TableCell();
        cell2.Style["text-align"] = "center";
        cell2.Width = Unit.Pixel(700);
        cell2.ColumnSpan = dt_result.Columns.Count - 1;
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
        cell2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        cell2.Style["text-align"] = "left";
        row.Cells.Add(cell1);
        cell2.ColumnSpan = dt_result.Columns.Count - 1;
        row.Cells.Add(cell2);

        table_toexport.Rows.Add(row);

        row = new TableRow();
        cell1 = new TableCell();
        cell2 = new TableCell();
        cell1.Text = "Report Name";
        cell2.Text = "Employee Report";
        cell2.Style["text-align"] = "left";
        cell2.ColumnSpan = dt_result.Columns.Count - 1;
        row.Cells.Add(cell1);
        row.Cells.Add(cell2);

        table_toexport.Rows.Add(row);
        row = new TableRow();

        foreach (DataColumn dc in dt.Columns)
        {

            cell1 = new TableCell();
            cell1.BackColor = System.Drawing.Color.Yellow;
            cell1.Text = dc.ColumnName;
            cell1.Style["text-align"] = "center";
            row.Cells.Add(cell1);
        }
        table_toexport.Rows.Add(row);

        foreach (DataRow dr in (dt_result.Rows))
        {
            row = new TableRow();
            for (int i = 0; i < dt_result.Columns.Count; i++)
            {
                cell1 = new TableCell();
                cell1.Text = dr[i].ToString();
                cell1.Style["text-align"] = "center";
                row.Cells.Add(cell1);
            }
            table_toexport.Rows.Add(row);

        }
        HttpContext.Current.Response.Clear();

        HttpContext.Current.Response.Buffer = true;

        //this.EnableViewState = false;

        string attachment = "attachment;   filename=empreportcolumnwise.xls";

        HttpContext.Current.Response.AddHeader("content-disposition", attachment);

        HttpContext.Current.Response.ContentType = "application/ms-excel";

        System.IO.StringWriter sw = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        HtmlForm frm = new HtmlForm();

        //  cntrl.Parent.Controls.Add(frm);

        Page.Form.Controls.Add(frm);
        frm.Attributes["runat"] = "server";

        frm.Controls.Add((Table)table_toexport);

        frm.RenderControl(htw);

        string style = @"<style> .textmode { mso-number-format:\@; } img{width:100px;height:60px;} </style>";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write(sw.ToString());

        HttpContext.Current.Response.End();

        //try
        //{
        //    string filename = string.Empty;
        //    filename = "attachment;";
        //    Response.Clear(); //this clears the Response of any headers or previous output 
        //    Response.Charset = "";
        //    Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        //    Response.ClearContent();
        //    Response.ContentType = "application/vnd.ms-excel";

        //    filename = "attachment;filename =SelectedEmployeeDetails.xls";
        //    Response.AddHeader("content-disposition", "attachment;filename =SelectedEmployeeDetails.xls");// TeamLeaveStatus.xls");
        //    //Response.Write(filename);
        //    //Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        //    StringWriter stringWrite = new StringWriter();
        //    HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        //    DataGrid dg = new DataGrid();
        //    dg.DataSource = dt;
        //    dg.DataBind();

        //    String style = @"<style>.text{mso-number-format:\@;}</style>";
        //    HttpContext.Current.Response.Write(style);
        //    int colindex = 0;

        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        string valuetype = dc.DataType.ToString();

        //        foreach (DataGridItem i in dg.Items)
        //            i.Cells[colindex].Attributes.Add("class", "text");
        //        colindex++;
        //    }

        //    dg.RenderControl(htmlwrite);
        //    Response.Write(stringWrite.ToString());
        //    Response.End();
        //}
        //catch (Exception Ex)
        //{

        //}
    }


    protected void ImgExcel_Click(object sender, EventArgs e)
    {
        try
        {


            chekdata();
            if (cheked == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Suc",
           "document.getElementById('chklist').style.display = 'block';", true);

                ScriptManager.RegisterStartupScript(this, GetType(), "Success Message12",
           "alert('Pls Select the Fields  ');", true);
            }
            else
            {

                integratevalues();
                
            }
        }


        catch (Exception ex)
        {
        }
    }
    public void integratevalues()
    {
        for (int i = 0; i <= checkcolumns.Items.Count - 1; i++)
        {
            if (checkcolumns.Items[i].Selected == true)
            {
                columnname = columnname + checkcolumns.Items[i].Text.ToString() + ",";
            }
        }

        

        CommonBusiness commonbAL = new CommonBusiness();
        DataTable dt = new DataTable();
        string value = columnname.Remove(columnname.LastIndexOf(','));
     //   value = value.Replace("Home_BusinessUnit", "Home_BussinessUnit").Replace("Secondary_BusinessUnit","Secondary_BussinessUnit").Replace("","");
        dt = commonbAL.ExportCheckedColumns(value);

        if (dt.Columns.Contains("Employee_DOJ"))
       {
           dt.Columns.Add(new DataColumn("Emp_DOJ"));
           foreach (DataRow dr in dt.Rows)
           {
               if (!string.IsNullOrEmpty(dr["Employee_DOJ"].ToString()))
               {
                   dr["Emp_DOJ"] = Convert.ToDateTime(dr["Employee_DOJ"]).ToString("dd-MMM-yyyy");
               }
           }
                dt.Columns.Remove("Employee_DOJ");
       
       }
        if (dt.Columns.Contains("Salary_Calculation_Date"))
        {
            dt.Columns.Add(new DataColumn("Sal_Calculation_Date"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Salary_Calculation_Date"].ToString()))
                {
                    dr["Sal_Calculation_Date"] = Convert.ToDateTime(dr["Salary_Calculation_Date"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Salary_Calculation_Date");
        }

        if (dt.Columns.Contains("Date_of_Leaving"))
        {
            dt.Columns.Add(new DataColumn("Emp_Date_of_Leaving"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Date_of_Leaving"].ToString()))
                {
                    dr["Emp_Date_of_Leaving"] = Convert.ToDateTime(dr["Date_of_Leaving"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Date_of_Leaving");
        }
        if (dt.Columns.Contains("Date_of_Relieving"))
        {
            dt.Columns.Add(new DataColumn("Emp_Date_of_Relieving"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Date_of_Relieving"].ToString()))
                {
                    dr["Emp_Date_of_Relieving"] = Convert.ToDateTime(dr["Date_of_Relieving"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Date_of_Relieving");
        }
        if (dt.Columns.Contains("Spouse_DOB"))
        {
            dt.Columns.Add(new DataColumn("Spouse_Date_of_Birth"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Spouse_DOB"].ToString()))
                {
                    dr["Spouse_Date_of_Birth"] = Convert.ToDateTime(dr["Spouse_DOB"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Spouse_DOB");
        }

        if (dt.Columns.Contains("Employee_DOB"))
        {
            dt.Columns.Add(new DataColumn("Emp_Date_of_Birth"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Employee_DOB"].ToString()))
                {
                    dr["Emp_Date_of_Birth"] = Convert.ToDateTime(dr["Employee_DOB"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Employee_DOB");
        }

        if (dt.Columns.Contains("Date_of_Anniversary"))
        {
            dt.Columns.Add(new DataColumn("Emp_Date_of_Anniversary"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Date_of_Anniversary"].ToString()))
                {
                    dr["Emp_Date_of_Anniversary"] = Convert.ToDateTime(dr["Date_of_Anniversary"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Date_of_Anniversary");
        }

        if (dt.Columns.Contains("Passport_Valid_From"))
        {
            dt.Columns.Add(new DataColumn("Passport_Valid_Date"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Passport_Valid_From"].ToString()))
                {
                    dr["Passport_Valid_Date"] = Convert.ToDateTime(dr["Passport_Valid_From"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Passport_Valid_From");
        }
        if (dt.Columns.Contains("Valid_From"))
        {
            dt.Columns.Add(new DataColumn("Policy_Valid_from"));
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Valid_From"].ToString()))
                {
                    dr["Policy_Valid_from"] = Convert.ToDateTime(dr["Valid_From"]).ToString("dd-MMM-yyyy");
                }
            }
            dt.Columns.Remove("Valid_From");
        }
        exportexcel(dt);
        

    }
}