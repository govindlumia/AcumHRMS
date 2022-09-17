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
using System.Data.SqlClient;
using DataAccessLayer;
using System.IO;
using System.Data.OleDb;


public partial class payroll_admin_OverTimeUpload : System.Web.UI.Page
{
    string FileName = string.Empty; // For FileName
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dds = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_message.Text = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
            //current_month(); //22Sep2010
        }
        bind_fyear();

    }
    protected void current_month()
    {
        DateTime dt = DateTime.Now;

        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);
        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_fyear()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
       bind_fyear();
        //validate_attendance();
    }
    protected bool uploaddocument()
    {
        string file_name, fn, ftype;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xls":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\OverTime.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());

                        lbl_message.Text = "";
                        return true;
                        //break;
                    }
                default:
                    {
                        lbl_message.Text = "";
                        lbl_message.Text = "Only Excel File can be uploaded";
                        return false;
                        //break;
                    }
            }
            return true;
        }
        return true;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
        try
        {
            //if (uploaddocument())
            //{
            if (fupload.PostedFile.FileName.ToString() != "")
            {
                DataSet dds = new DataSet();
                string fileName = string.Empty;
                string fn = string.Empty;
                if (fupload.HasFile)
                {
                    //---------------------------------------------------------------------------------------
                    fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
                    fileName = Server.MapPath(".") + "\\upload\\" + fn;
                    System.IO.FileAccess.ReadWrite.ToString();
                    ////FileUpload1.SaveAs(Server.MapPath(fileName));
                    fupload.SaveAs(fileName);
                    //string strFileNameRed = Server.MapPath(".") + "\\upload\\" + fupload.FileName;
                    //string[] strfpart = fileName.Split('.');
                    //string getFormat = strfpart[strfpart.Length - 1].ToString();
                    //System.IO.FileAccess.ReadWrite.ToString();

                    //CSVReader objReadFile = new CSVReader();
                    //dds = objReadFile.GetDataTable(strFileNameRed, getFormat);
                    //System.IO.File.Delete(fileName);
                    //---------------------------------------------------------------------------------------------

                    string file = Server.MapPath(".") + "/upload/" + fn;
                    String strConn = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source='" + Server.MapPath(".") + "\\upload\\" + fn + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;

                    System.IO.FileAccess.ReadWrite.ToString();
                    objadapter1.Fill(dds, "OverTime");
                    objconn.Close();

                }


                //string file = Server.MapPath(".") + "/upload/attendance.xls";
                //String strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Server.MapPath(".") + "\\upload\\attendance.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                //OleDbConnection objconn = new OleDbConnection(strConn);
                //objconn.Open();
                //OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                //OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                //objadapter1.SelectCommand = objcmdselect;
                //DataSet dds = new DataSet();
                //System.IO.FileAccess.ReadWrite.ToString();
                //objadapter1.Fill(dds, "Attendance");
                //objconn.Close();

                //DateTime dt = new DateTime(2015, Convert.ToInt32(dd_month.SelectedValue), 25);
                //DateTime dt2 = dt.AddMonths(-1).AddDays(1);

                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {
                    SqlParameter[] sqlparm = new SqlParameter[6];
                    sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["empcode"].ToString().Trim());
                    sqlparm[1] = new SqlParameter("@dep_ot_id", 0.ToString());
                    sqlparm[2] = new SqlParameter("@noofhour", dds.Tables[0].Rows[i]["noofhour"].ToString());
                    sqlparm[3] = new SqlParameter("@date", Convert.ToDateTime(dds.Tables[0].Rows[i]["date"].ToString()));
                    sqlparm[4] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                    sqlparm[5] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());


                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_import_OverTime]", sqlparm);
                }
                lbl_message.Text = "OverTime data uploaded successfully!";
                bindgrid();
            }
            //}
        }
        catch (Exception ex)
        {
            lbl_message.Text = "Please check Excel format.There must be three fields named empcode,No of hours,Date with sheet named SHEET1.There should not be blank data.";
        }
        //}
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];


        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_OverTime]", sqlparm);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void exportexcel()
    {
        string filename = "Process OverTime Details Report for Month :- " + dd_month.SelectedItem.Text;

        SqlParameter[] sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        
        sqlparm[1] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_OverTime]", sqlparm);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

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
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
}