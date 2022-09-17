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
using Utilities;
using System.IO;

public partial class payroll_admin_view_employee_tds : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
            
            bind_year();
            bind_month();
            ddl_bank_name.DataBind();
            //bindchallaninfo();
            //bind_tds_detail();  
        }
        //dd_year.DataValueField = "year";
        //dd_year.DataSource = ds;
        //dd_year.DataBind();
    }

    protected void bind_year()
    {
        sqlstr = "select [financial_year] as year from tbl_payroll_tax_master order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }

    protected void bind_tds_detail()
    {
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[3];

            sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_year.SelectedValue;

            sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

            sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
            if ((drp_comp_name.SelectedIndex == 0) || (drp_comp_name.SelectedIndex == -1))  
            {
                sqlparam[2].Value = 0;
            }
            else
            {
                sqlparam[2].Value = drp_comp_name.SelectedValue;
            }

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_fetch_tds_detail]", sqlparam);
            griddetail.DataSource = ds.Tables[0];
            griddetail.DataBind();

            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();
        }
        catch
        {
            message.InnerHtml = "Monthly TDS Detail Can not be viewed";
        }
    }
   
    protected void griddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        bind_tds_detail();
    }

    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
        //bindchallaninfo();
        //bind_tds_detail();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (griddetail.Rows.Count < 1)
        {
            message.InnerHtml = "Monthly TDS Detail cannot be saved";
            return;
        }

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[9];

        sqlparam[0] = new SqlParameter("@year", SqlDbType.VarChar);
        sqlparam[0].Value = dd_year.SelectedValue;

        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar);
        sqlparam[1].Value = dd_month.SelectedValue;

        sqlparam[2] = new SqlParameter("@cheque_dd_number", SqlDbType.VarChar);
        sqlparam[2].Value = (txt_no.Text.Trim() == "") ? "0" : txt_no.Text;

        sqlparam[3] = new SqlParameter("@bsr_bank_code", SqlDbType.VarChar);
        sqlparam[3].Value = txt_bsr.Text;

        sqlparam[4] = new SqlParameter("@tax_deposite_date", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_date.Text);

        sqlparam[5] = new SqlParameter("@tranfer_voucher_id_no", SqlDbType.VarChar);
        sqlparam[5].Value = txt_vou.Text;
        
        sqlparam[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar);
        sqlparam[6].Value = Session["name"].ToString();

        sqlparam[7] = new SqlParameter("@bankcode", SqlDbType.VarChar);
        sqlparam[7].Value = ddl_bank_name.SelectedValue;

        sqlparam[8] = new SqlParameter("@branch", SqlDbType.Int);
        if ((drp_comp_name.SelectedIndex == 0) || (drp_comp_name.SelectedIndex == -1))
            sqlparam[8].Value = 0;
        else
            sqlparam[8].Value = drp_comp_name.SelectedValue;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_tds_monthlychallan", sqlparam);
        message.InnerHtml = "Monthly Challan Saved Successfully";
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bindchallaninfo();
        //bind_tds_detail();
    }

    protected void bindchallaninfo()
    {
        if (dd_year.SelectedValue == "" || dd_month.SelectedValue == "")
        {
            message.InnerHtml = "Monthly TDS Detail Can not be viewed";
            return;
        }
        SqlParameter[] sqlparam = new SqlParameter[3];
        sqlstr = "select cheque_dd_number,bankcode,bsr_bank_code,convert(varchar,tax_deposite_date,101) tax_deposite_date,tranfer_voucher_id_no from tbl_payroll_employee_tdsmonthly_challan where financial_year=@financial_year and month=@month and branch=@branch";
        sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_year.SelectedValue;

        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
        if((drp_comp_name.SelectedIndex == 0) || (drp_comp_name.SelectedIndex == -1))     
            sqlparam[2].Value = 0;
        else
            sqlparam[2].Value = drp_comp_name.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_no.Text = Convert.ToString(ds.Tables[0].Rows[0]["cheque_dd_number"]);
            txt_bsr.Text = Convert.ToString(ds.Tables[0].Rows[0]["bsr_bank_code"]);
            txt_date.Text = Convert.ToString(ds.Tables[0].Rows[0]["tax_deposite_date"]);
            txt_vou.Text = Convert.ToString(ds.Tables[0].Rows[0]["tranfer_voucher_id_no"]);
            ddl_bank_name.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["bankcode"]);
        }
        else
        {
            txt_no.Text = ""; txt_vou.Text = ""; txt_bsr.Text = ""; txt_date.Text = ""; ddl_bank_name.SelectedIndex = 0;
        }  
    }

    protected DateTime dataformat(string date)
    {
        string [] datesplit= date.Split('/');
        DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]),Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
        return dates;
    }

    protected void griddetail_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        bind_tds_detail();
    }

    protected void lnkbtnexcelexport_Click(object sender, EventArgs e)
    {
        bind_tds_detail();
        exportexcel();
    }

    protected void exportexcel()
    {
        try
        {
            //SqlParameter[] sqlparam = new SqlParameter[2];

            //sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
            //sqlparam[0].Value = dd_year.SelectedValue;

            //sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            //sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

            //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_fetch_tds_detail]", sqlparam);
            Response.Clear(); //this clears the Response of any headers or previous output 
            Response.Charset = "";
            Response.Buffer = true; //make sure that the entire output is rendered simultaneously
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel";
            string filename = "attachment;filename =MONTHLY_TDS_CHALLAN.xls";
            //string filename = "attachment;filename =Attendance-1.xls";
            //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
            Response.Write(filename);
            Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
            DataGrid dg = new DataGrid();
            dg.DataSource = ds.Tables[2];
            dg.DataBind();

            String style = @"<style>.text{mso-number-format:\@;}</style>";
            HttpContext.Current.Response.Write(style);
            int colindex = 0;
            foreach (DataColumn dc in ds.Tables[2].Columns)
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
        catch
        {
            message.InnerHtml = "Monthly TDS Detail Can not be exported";
        }
    }

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select branch--", "0"));
    }

    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void ddl_bank_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlParameter sqlparm = new SqlParameter("@bankcode", ddl_bank_name.SelectedValue.Trim().ToString());
        
        sqlstr = "SELECT bsrcode FROM tbl_payroll_bank WHERE branchcode=@bankcode and tds=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
       
        txt_bsr.Text = ds.Tables[0].Rows[0]["bsrcode"].ToString();
    }

    protected void drp_comp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_tds_detail();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bindchallaninfo();
        bind_tds_detail();
    }
    
}
