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
using Utilities;
using System.IO;
public partial class leave_admin_viewattendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            txt_sdate.Text = System.DateTime.Today.Date.ToString("MM/dd/yyyy");
            txt_edate.Text = System.DateTime.Today.Date.AddDays(7).ToString("MM/dd/yyyy");
            //bindempdetail();
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void bindempdetail()
    {
       
        SqlParameter[] sqlparam = new SqlParameter[7];
        
        sqlparam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[0].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
        sqlparam[1].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        sqlparam[2] = new SqlParameter("@TYPE", SqlDbType.Int);
        sqlparam[2].Value = 1;

        sqlparam[3] = new SqlParameter("@empcode", SqlDbType.VarChar,50);
        sqlparam[3].Value = "";

        sqlparam[4] = new SqlParameter("@Category", SqlDbType.Int);
        sqlparam[4].Value = ddlbranch.SelectedValue;

        sqlparam[5] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[5].Value =dd_dep.SelectedValue;

        sqlparam[6] = new SqlParameter("@name", SqlDbType.VarChar,100);
        sqlparam[6].Value = txt_employee.Text;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_LEAVE_FETCH_DUTYROSTER", sqlparam);
       //GridView1.DataSource = ds;
        //GridView1.DataBind();
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[0].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
        sqlparam[1].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

        sqlparam[2] = new SqlParameter("@TYPE", SqlDbType.Int);
        sqlparam[2].Value = 1;

        sqlparam[3] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "";

        sqlparam[4] = new SqlParameter("@Category", SqlDbType.Int);
        sqlparam[4].Value = ddlbranch.SelectedValue;

        sqlparam[5] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[5].Value = dd_dep.SelectedValue;

        sqlparam[6] = new SqlParameter("@name", SqlDbType.VarChar, 100);
        sqlparam[6].Value = txt_employee.Text;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_LEAVE_FETCH_DUTYROSTER", sqlparam);
       
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =DutyRoster.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =DutyRoster.xls");// TeamLeaveStatus.xls");
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
                i.Cells[colindex].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
       
    }

    protected void dd_dep_DataBound(object sender, EventArgs e)
    {
        dd_dep.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindempdetail();
    }
}
