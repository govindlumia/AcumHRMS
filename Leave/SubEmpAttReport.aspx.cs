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
using Utilities;
using System.IO;


public partial class Leave_admin_SubEmpAttReport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    bool c = false;
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {

            txt_frmdate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("dd-MMM-yyyy");
            txt_todate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            txt_employee.Attributes.Add("ReadOnly", "ReadOnly");
            //  txt_employee.Text = Session["empcode"].ToString();
            //dd_designation.DataBind();
            //dd_categoy.DataBind();
            bind_attendance();
            dvViewMovement.Visible = true;
            dvempcode.Visible = true;
        }
    }
    protected void bind_attendance()
    {
        try
        {
            rbtn.SelectedValue = "0";

            //if (Convert.ToInt32(Session["Department"]) == 17)
            //{
            DateTime FromDate = Utility.DateTimeForat(txt_frmdate.Text);
            DateTime ToDate = Utility.DateTimeForat(txt_todate.Text);

            dvsearch.Visible = false;
           // string sqlstr = @"select Distinct mode,card_no,dbo.GetEmpName(jD.empcode) as empname ,tbl_payroll_employee_attendence_detail.empcode,date,INTIME as Intime,OUTTIME as Outtime from tbl_payroll_employee_attendence_detail INNER JOIN tbl_intranet_employee_jobDetails jD ON tbl_payroll_employee_attendence_detail.empcode=jD.empcode where tbl_payroll_employee_attendence_detail.empcode in (" + txt_employee.Text + ")and date between ('" + FromDate + "') and ('" + ToDate + "') order by date";
            SqlParameter[] param=new SqlParameter[5]{new SqlParameter("@fromDate",FromDate),new SqlParameter("@toDate",ToDate),new SqlParameter("@empcode",txt_employee.Text),new SqlParameter("@isViewMovement",false),new SqlParameter("@userCode",Session["EmpCode"].ToString())};


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_getAttendanceReportForMSS",param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                update.Visible = true;
                empgrid.DataSource = ds;
                empgrid.DataBind();
                Session["dt1"] = ds;
                dvViewMovement.Visible = false;
                dvsearch.Visible = true;

            }
            else
            {
                update.Visible = false;
                message.InnerHtml = "No data found";

            }
         
        }
        catch (Exception ex)
        {
            message.InnerHtml = "";
        }
    }

    protected void bindAttendanceViewMovement()
    {
        try
        {
            dvViewMovement.Visible = true;
            DateTime FromDate = Utilities.Utility.DateTimeForat(txt_frmdate.Text);
            DateTime ToDate = Utilities.Utility.DateTimeForat(txt_todate.Text);
          //  string sqlstr = @"select Distinct dbo.GetEmpName(jD.empcode) as empname ,DATEPART(Year,avm.date) as year,
//avm.empcode,date, avm.intime1 as inTime,
// avm.outtime1 as outtime ,avm.intime2,avm.outtime2,avm.intime3,avm.outtime3,avm.intime4,avm.outtime4,avm.TotWhours
//from tbl_EmployeeAttendanceViewMovement avm 
//INNER JOIN tbl_intranet_employee_jobDetails jD 
//ON avm.empcode=jD.empcode 
//where avm.empcode in ('" + Session["EmpCode"] + "') and date between ('" + FromDate + "') and ('" + ToDate + "') order by date";
            SqlParameter[] param = new SqlParameter[5] { new SqlParameter("@fromDate", FromDate), new SqlParameter("@toDate", ToDate), new SqlParameter("@empcode", txt_employee.Text), new SqlParameter("@isViewMovement", true), new SqlParameter("@userCode", Session["EmpCode"].ToString()) };
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_getAttendanceReportForMSS",param);

            if (ds.Tables[0].Rows.Count > 0)
            {

                dvViewMovement.Visible = true;
                GridViewMovement.DataSource = ds;
                GridViewMovement.DataBind();
                update.Visible = false;
                update.Disabled = true;
                Session["dt1"] = ds;

            }
            else
            {
                dvViewMovement.Visible = false;
                message.InnerHtml = "No data found";

            }

        }
        catch (Exception ex)
        {
            message.InnerHtml = "";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (validate_applieddate())
            bind_attendance();
        else
            return;
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            if (validate_applieddate())
                bind_attendance();
            else
                return;
        }
        else
            if (validate_applieddate())
                bindAttendanceViewMovement();
            else
                return;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_attendance();
    }

    protected void GridViewMovement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewMovement.PageIndex = e.NewPageIndex;
        bindAttendanceViewMovement();
    }

    //---------------------option to select a few and all staff in one go-----------------------

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        bindgrid();
        p3.Visible = true;
    }

    protected void adjustgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
        }
    }


    protected void btn_ok_Click(object sender, EventArgs e)
    {
        string empcode = "";
        //DataRow dr;
        //(TextBox)ShopCartGrid.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
        CheckBox Tmark1;
        for (int j = 0; j <= adjustgrid.Rows.Count - 1; j++)
        {
            Tmark1 = (CheckBox)adjustgrid.Rows[j].Cells[0].FindControl("chkselect");
            if (Tmark1.Checked == true)
            {
                empcode = empcode + "'" + ((Label)adjustgrid.Rows[j].Cells[0].FindControl("l2")).Text.Trim() + "',";
            }
        }
        p3.Visible = false;
        if (empcode != "")
            txt_employee.Text = empcode.Substring(0, empcode.Length - 1);
    }

    protected void bindgrid()
    {
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@managerCode", Session["EmpCode"].ToString());

        string strsql = "getEmployeeHierarchy";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, strsql, arrParam);
        adjustgrid.DataSource = ds;
        adjustgrid.DataBind();
    }


    protected void adjustgrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkselect");
            CheckBox chkBxHeader = (CheckBox)this.adjustgrid.HeaderRow.FindControl("chkBxHeader");
            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
        }
    }

    protected void btn_close_Click(object sender, EventArgs e)
    {
        p3.Visible = false;
    }

    //------------------------------- Validation for Date ------------------------------//
    protected Boolean validate_applieddate()
    {
        DateTime dt1 = Convert.ToDateTime(txt_frmdate.Text);
        DateTime dt2 = Convert.ToDateTime(txt_todate.Text);

        TimeSpan diff = Convert.ToDateTime(txt_todate.Text) - Convert.ToDateTime(txt_frmdate.Text);

        if (diff.Days < 0)
        {
            string message1 = "End date should be greater than start date.";
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
            return false;
        }
        return true;
    }

    protected void bind_shift_time(string empcode, DateTime date)
    {

        HiddenField1.Value = "8:30 AM";
        HiddenField2.Value = "5:30 PM";

    }

    protected void btn_search_click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        //dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_categoy_DataBound(object sender, EventArgs e)
    {
        // dd_categoy.Items.Insert(0, new ListItem("All", "0"));
    }

    //protected void ddlbranch_DataBound(object sender, EventArgs e)
    //{
    //    ddlbranch.Items.Insert(0, new ListItem("All", "0"));
    //}

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        p3.Visible = false;
    }

    protected void update_dutyroaster(string empcode, DateTime date, string mode)
    {
        int shiftcode;
        SqlParameter[] sqlparam = new SqlParameter[4];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@date", SqlDbType.DateTime);
        sqlparam[1].Value = date;

        sqlparam[2] = new SqlParameter("@mode", SqlDbType.VarChar, 10);

        if (mode == "W")
        {
            shiftcode = 0;
        }
        else
        {
            shiftcode = 1;
        }
        sqlparam[2].Value = shiftcode;

        sqlparam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[3].Value = Session["empcode"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_update_employee_dutyroaster_overwrite]", sqlparam);
    }

    protected void empgrid_rowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldate = (Label)e.Row.FindControl("lbldateg");
            string str = lbldate.Text;
            Label lblempcode = (Label)e.Row.FindControl("lblempcode");
            string str1 = lblempcode.Text;
            //lbldate.Attributes.Add("onClick",
        }
    }

    protected void exportexcel()
    {
         DataTable dt_result = ((DataSet)Session["dt1"]).Tables[0];
      GridViewRow _row=null;

        if(dt_result.Rows.Count>0)
        {
            if (rbtn.SelectedValue == "0")
            {
                _row = empgrid.HeaderRow;
                dt_result.Columns["empcode"].SetOrdinal(0);
                dt_result.Columns["empname"].SetOrdinal(1);
                dt_result.Columns["date"].SetOrdinal(2);
                dt_result.Columns["mode"].SetOrdinal(3);
                dt_result.Columns["Intime"].SetOrdinal(4);
                dt_result.Columns["Outtime"].SetOrdinal(5);
            }
            else

            {
                _row = GridViewMovement.HeaderRow;
            }

     //   ds = (DataSet)Session["dt1"];
       // MailScript scriptObj = new MailScript();
      //  Page.Form.Controls.Clear();
        exportToExcelInCustomized(dt_result,_row
            ,"Attendance Report for Manager","attrepformss");

        }
     

    }


    public void exportToExcelInCustomized(DataTable dt,GridViewRow gvr, string fileName, string fileNametosave)
    {
        try
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
            cell2.Text = fileName;
            cell2.Style["text-align"] = "left";
            cell2.ColumnSpan = dt_result.Columns.Count - 1;
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            table_toexport.Rows.Add(row);
            row = new TableRow();

            row = new TableRow();

            foreach (TableCell tc in gvr.Cells)
            {

                cell1 = new TableCell();
                cell1.BackColor = System.Drawing.Color.Yellow;
                cell1.Text = tc.Text;
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
            exportToExcelInternalFunc(table_toexport, fileNametosave);
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
        }
    }
    private void exportToExcelInternalFunc(object file, string fileNametosave)
    {
        HttpContext.Current.Response.Clear();

        HttpContext.Current.Response.Buffer = true;

        //this.EnableViewState = false;

        string attachment = "attachment;   filename=" + fileNametosave + ".xls";

        HttpContext.Current.Response.AddHeader("content-disposition", attachment);

        HttpContext.Current.Response.ContentType = "application/ms-excel";

        System.IO.StringWriter sw = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        HtmlForm frm = new HtmlForm();

        //  cntrl.Parent.Controls.Add(frm);

        dv_toexport.Controls.Add(frm);
        frm.Attributes["runat"] = "server";

        frm.Controls.Add((Table)file);

        frm.RenderControl(htw);

        string style = @"<style> .textmode { mso-number-format:\@; } img{width:100px;height:60px;} </style>";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write(sw.ToString());

        HttpContext.Current.Response.End();

    }






    protected void btn_exporttoexcel_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
    protected void rbtn_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            btn_exporttoexcel.Visible = true;
            bind_attendance();

        }
        else
        {
            btn_exporttoexcel.Visible = true;
            bindAttendanceViewMovement();
        }
    }
}