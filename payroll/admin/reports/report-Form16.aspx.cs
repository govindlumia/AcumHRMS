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

public partial class payroll_admin_view_payslip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    //SqlParameter sqlparm;
    string sqlstr;
    string strPop;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            //bind_year();
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('Form16.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "&detail=0')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }
    //protected Boolean veremp(string empcode, string year)
    //{
    //    sqlparm = new SqlParameter[2];
    //    sqlparm[0] = new SqlParameter("@year", year);
    //    sqlparm[0] = new SqlParameter("@year", year);

    //    DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform6A", sqlparm);
    //}

    protected string encode(string empcode, string year)
    {
        query q = new query();
        string pairs = String.Format("empcode={0}&year={1}", empcode.ToString(), year.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return encoded;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        txt_employee.Text = "";
    }

    protected void bind_year()
    {
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void btn_ack_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('FormACK.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "')</script>";

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);

    }

    protected void btn_itr_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('FormITR.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "')</script>";

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);

    }

    protected void btn_16AA_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('Form16AA.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }

    protected void btn_formD_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('Form16.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "&detail=1')</script>";

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }

    protected void btnform12ba_Click(object sender, EventArgs e)
    {
        strPop = "<script language='javascript'>window.open('perquisite-form12BA.aspx?q=" + encode(txt_employee.Text, dd_year.SelectedItem.Text.ToString()) + "')</script>";

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
    }
}
